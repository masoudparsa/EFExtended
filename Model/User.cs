﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Paswword { get; set; }
        public bool IsActive { get; set; }

        //public Person Person { get; set; }

    }
}
