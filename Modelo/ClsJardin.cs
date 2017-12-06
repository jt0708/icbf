using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ClsJardin
    {

        public bool registrarJardin(Jardin jardin)
        {
            bool bandera = false;

            ORMDataContext bd = new ORMDataContext();
            try
            {
                bd.Jardin.InsertOnSubmit(jardin);

                bd.SubmitChanges();

                return bandera = true;
            }
            catch (Exception e)
            {
                return bandera = false;

                Console.WriteLine(e.Message);
            }
        }

        public bool eliminarJardin(int id)
        {
            bool bandera = false;

            ORMDataContext bd = new ORMDataContext();
            try
            {
                var sentencia = (from j in bd.Jardin
                                 where j.id == id
                                 select j).First();

                sentencia.estado = "Inactivo";
                bd.SubmitChanges();

                return bandera = true;
            }
            catch (Exception e)
            {
                return bandera = false;

                Console.WriteLine(e.Message);
            }
        }

        public Jardin seleccionarJardin(int id)
        {
            ORMDataContext bd = new ORMDataContext();
            var sentencia = (from j in bd.Jardin
                             where j.id == id
                             select j).First();

            return sentencia;
        }

        public bool actualizarJardin(Jardin jardin)
        {
            bool bandera = false;

            ORMDataContext bd = new ORMDataContext();
            try
            {
                var sentencia = (from j in bd.Jardin
                                 where j.id == jardin.id
                                 select j).First();
                sentencia.nombreJardin = jardin.nombreJardin;
                sentencia.direccion = jardin.direccion;
                sentencia.telefono = jardin.telefono;
                sentencia.estado = jardin.estado;

                bd.SubmitChanges();

                return bandera = true;
            }
            catch (Exception e)
            {
                return bandera = false;

                Console.WriteLine(e.Message);
            }
        }

        public object consultarJardin()
        {
            ORMDataContext bd = new ORMDataContext();

            var sentencia = (from j in bd.Jardin
                             select j).ToList();

            return sentencia;

        }

        public object consultarJardinesActivos()
        {
            ORMDataContext bd = new ORMDataContext();

            var sentencia = (from j in bd.Jardin
                             where j.estado == "Activo"
                             select j).ToList();

            return sentencia;

        }
    }
}
