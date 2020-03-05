using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomiPro.helpers
{
    public class Helpers
    {
        public static List<SelectListItem> ListaEstado()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Activo", Value = "Activo" });
            list.Add(new SelectListItem() { Text = "Inactivo", Value = "Inactivo" });
            return list;
        }

        public static List<SelectListItem> ListaMes()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Enero", Value = "Enero" });
            list.Add(new SelectListItem() { Text = "Febrero", Value = "Febrero" });
            list.Add(new SelectListItem() { Text = "Marzo", Value = "Marzo" });
            list.Add(new SelectListItem() { Text = "Abril", Value = "Abril" });
            list.Add(new SelectListItem() { Text = "Mayo", Value = "Mayo" });
            list.Add(new SelectListItem() { Text = "Junio", Value = "Junio" });
            list.Add(new SelectListItem() { Text = "Julio", Value = "Julio" });
            list.Add(new SelectListItem() { Text = "Agosto", Value = "Agosto" });
            list.Add(new SelectListItem() { Text = "Septiembre", Value = "Septiembre" });
            list.Add(new SelectListItem() { Text = "Octubre", Value = "Octubre" });
            list.Add(new SelectListItem() { Text = "Noviembre", Value = "Noviembre" });
            list.Add(new SelectListItem() { Text = "Diciembre", Value = "Diciembre" });
            return list;
        }
    }
}