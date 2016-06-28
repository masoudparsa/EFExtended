using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework.Extensions;
namespace EF6SeconLevelCache.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Repository.Context context = new Repository.Context();
            //************** Ussing Caching in Entity
            //Person personExistObj = context.Persons.Where(p => p.Barcode == "111").FromCache(EntityFramework.Caching.CachePolicy.WithDurationExpiration(TimeSpan.FromSeconds(20))).FirstOrDefault();
            

            //if (personExistObj == null)
            //{
            //    personExistObj = new Person();
            //    personExistObj.Address = "Tehran";
            //    personExistObj.Barcode = "111";
            //    personExistObj.Family = "Parsa";
            //    personExistObj.FatherName = "Mohammad";
            //    personExistObj.Name = "Masoud";
            //    personExistObj.Tel = "09125270217";
            //    context.Persons.Add(personExistObj);
            //    context.SaveChanges();
               
            //}
            //Model.User userExistObj = context.Users.Where(p => p.Username == "parsa").FromCache(EntityFramework.Caching.CachePolicy.WithDurationExpiration(TimeSpan.FromSeconds(20))).FirstOrDefault();


            //if (userExistObj == null)
            //{
            //    userExistObj = new User();
            //    userExistObj.Username = "parsa";
            //    userExistObj.Paswword = "111";
            //    userExistObj.IsActive = true;
               
          
            //    context.Users.Add(userExistObj);
            //    context.SaveChanges();

            //}

//************* using bach insert in entity
            if (context.Persons.Count() < 2000)
            {
                List<Person> personList = new List<Person>();
                int counter = 0;
                while (counter < 2000)
                {


                    string barcode = GeneratePersonRendom.GetBarcode();
                    Model.Person personExistObj = context.Persons.FirstOrDefault(p => p.Barcode == barcode);
                    if (personExistObj == null)
                    {
                        personExistObj = new Person();
                        personExistObj.Address = "Tehran";
                        personExistObj.Barcode = barcode;
                        personExistObj.Family = GeneratePersonRendom.GetFamily();
                        personExistObj.FatherName = "mohammad";
                        personExistObj.Name = GeneratePersonRendom.GetName();
                        personExistObj.Tel = "09125270217";
                        personList.Add(personExistObj);
                        counter++;
                    }

                }
                EntityFramework.Utilities.EFBatchOperation.For(context, context.Persons).InsertAll(personList);
            
          

            }
            
           // context.Persons.Delete();
            return View();
        }
    }
}