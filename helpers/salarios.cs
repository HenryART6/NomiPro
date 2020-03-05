using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomiPro.helpers
{
    public class salarios
    {
        public static string Convert(string number)
        {
            return decimal.Parse(number).ToString("C2");
        }
    }
}