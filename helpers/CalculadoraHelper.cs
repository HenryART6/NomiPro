using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NomiPro.ModelDB;

namespace NomiPro.helpers
{
    public class CalculadoraHelper
    {
        public static void CalculoDeHoras(HETRAXEMPLEADO hExtraxEmpleado, NomiProEntities db)

        {
            CalculoDehoras(hExtraxEmpleado.ID_Emple.Value, hExtraxEmpleado.Mes, db);
        }
        public static void CalculoDeHoras(PARAXEMPLE paraxEmple, NomiProEntities db)

        {
            CalculoDehoras(paraxEmple.ID_EmpleP.Value, paraxEmple.Mes, db);
        }
        public static void CalculoDehoras(int IdEmpleado, string Mes, NomiProEntities db)

        {
            var cargos = db.CARGOS.FirstOrDefault(c => c.ID_Cargos == (db.EMPLEADOS.FirstOrDefault(e => e.ID_Emple == IdEmpleado).ID_Cargos));
            double calculoHoras = 0;
            var controlPago = db.CONTROL_PAGO.FirstOrDefault(p => p.ID_EmpleCP == IdEmpleado && p.Mes == Mes);

            if (controlPago == null)
            {
                controlPago = db.CONTROL_PAGO.Add(new CONTROL_PAGO()
                {
                    ID_EmpleCP = IdEmpleado,

                    Mes = Mes

                });
            }
            foreach (var item in db.HETRAXEMPLEADO.Where(he => he.ID_Emple ==
            IdEmpleado
            && he.Mes == Mes))
            {
                var horaExtra = db.HORA_EXTRAS.FirstOrDefault(he => he.ID_HExtras ==
                item.ID_HExtras);
                if (horaExtra.Valor.HasValue && cargos.Valor_cargo.HasValue &&
                item.Numero_Horas.HasValue && cargos.Valor_cargo.HasValue)
                {
                    //Valor hora fija: suponemos que el valor de la hora es el total

                    //calculoHoras += (horaExtra.Valor.Value) *

                    
                    calculoHoras += ((cargos.Valor_cargo.Value / 192) *
                    horaExtra.Valor.Value) * item.Numero_Horas.Value;
                }
            }
            controlPago.Valor_Horas_Extra = int.Parse(Math.Round(calculoHoras,
            0).ToString());
            double calculoParafiscal = 0;

            foreach (var item in db.PARAFISCALES
            .Where(p => p.Estado == "Activo")

            .Join(db.PARAXEMPLE.Where(pax => pax.Mes == Mes
            && pax.ID_EmpleP == IdEmpleado), p => p.ID_Parafiscales, pa => pa.ID_Parafiscales,
            (p, pa) => new { p.Valor })
            )
            {
                calculoParafiscal += (double.Parse(item.Valor.Value.ToString()) /
                100) * cargos.Valor_cargo.Value;
            }
            controlPago.Valor_Parafiscal = int.Parse(Math.Round(calculoParafiscal,
            0).ToString());
            db.SaveChanges();
            CalculoDeNomina(cargos, IdEmpleado, Mes, controlPago, db);
        }
        public static void CalculoDeNomina(CARGOS cargo, int IdEmpleado, string Mes,
        CONTROL_PAGO controlPago, NomiProEntities db)
        {
            var nomina = db.NOMINA.FirstOrDefault(p => p.ID_EmpleN == IdEmpleado &&
            p.Mes == Mes);
            if (nomina == null)
            {
                nomina = db.NOMINA.Add(new NOMINA()
                {
                    ID_EmpleN = IdEmpleado,

                    Mes = Mes,
                    ID_Control_PagoN = controlPago.ID_Control_Pago,
                    ID_Nomina = cargo.ID_Cargos,
                    Estado = "Activo"

                });
            }
            nomina.Subtotal = cargo.Valor_cargo.Value -
            controlPago.Valor_Parafiscal;
            nomina.Total = nomina.Subtotal + controlPago.Valor_Horas_Extra;
            db.SaveChanges();
        }
    }
}