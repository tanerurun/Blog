﻿using DataAccess.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Test
    {
        public Test()
        {
            DataContext db= new DataContext();
         //db.Database.Delete();
            db.Database.CreateIfNotExists();   
        }
    }

}
