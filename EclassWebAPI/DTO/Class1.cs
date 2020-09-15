using EclassWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EclassWebAPI.DTO
{
    public class Class1
    {
        List<Student> listItem;

        public List<Student> ListItem
        {
            get { return listItem; }
            set { listItem = value; }
        }

        string nienkhoa;
        public string Nienkhoa
        {
            get { return nienkhoa; }
            set { nienkhoa = value; }
        }
    }
}