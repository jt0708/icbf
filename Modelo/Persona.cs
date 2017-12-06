using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Windows.Forms;


namespace Modelo
{
    public class Persona
    {


        public int login(string nombre, string clave)
        {
            ORMDataContext db = new ORMDataContext();
            bool bandera = false;
            var consulta = from u in db.sp_login(nombre, clave)
                           select new { u.id, u.nombres };
            foreach (var item in consulta)
            {
                VariableSesion.id = item.id;
                VariableSesion.nombre = item.nombres;
                bandera = true;
            }
             return VariableSesion.id;
        }

        public bool registrarPersona(Personas persona)
        {
            bool bandera = false;

            ORMDataContext bd = new ORMDataContext();
            try
            {
                bd.Personas.InsertOnSubmit(persona);

                bd.SubmitChanges();

                return bandera = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return bandera = false;
            }
        }

        public bool eliminarPersona(int id)
        {
            bool bandera = false;

            ORMDataContext bd = new ORMDataContext();
            try
            {
                var sentencia = (from p in bd.Personas
                                 where p.id == id
                                 select p).First();
                bd.Personas.DeleteOnSubmit(sentencia);

                bd.SubmitChanges();

                return bandera = true;
            }
            catch (Exception e)
            {
                return bandera = false;

                Console.WriteLine(e.Message);
            }
        }

        public bool actualizarPersona(Personas persona)
        {
            bool bandera = false;

            ORMDataContext bd = new ORMDataContext();
            try
            {
                var sentencia = (from p in bd.Personas
                                 where p.id == persona.id
                                 select p).First();

                sentencia.tipoRol = persona.tipoRol;
                sentencia.numeroIdentificacion = persona.numeroIdentificacion;
                sentencia.nombres = persona.nombres;
                sentencia.apellidos = persona.apellidos;
                sentencia.fechaNacimiento = persona.fechaNacimiento;
                sentencia.ciudadNacimiento = persona.ciudadNacimiento;
                sentencia.tipoSangre = persona.tipoSangre;
                sentencia.codAcudiente = persona.codAcudiente;
                sentencia.telefono = persona.telefono;
                sentencia.celular = persona.celular;
                sentencia.direccion = persona.direccion;
                sentencia.eps = persona.eps;
                sentencia.peso = persona.peso;
                sentencia.talla = persona.talla;
                sentencia.correo = persona.correo;
                sentencia.codJardin = persona.codJardin;
                bd.SubmitChanges();

                return bandera = true;
            }
            catch (Exception e)
            {
                return bandera = false;

                Console.WriteLine(e.Message);
            }
        }

        public object consultarPorNino()
        {
            ORMDataContext bd = new ORMDataContext();

            var sentencia = from p in bd.Personas
                            join r in bd.Rol on p.tipoRol equals r.id
                            join a in bd.Personas on p.id equals a.id
                            join g in bd.Jardin on p.codJardin equals g.id
                            where p.tipoRol == 3
                            select new { Codigo = p.id, Documento = p.numeroIdentificacion, p.nombres, p.apellidos, p.fechaNacimiento, p.peso, p.talla, p.tipoSangre, p.eps, Acudiente = p.Personas1.nombres, Jardin = g.nombreJardin };
            return sentencia;

        }

        public object consultarAcudientes()
        {
            ORMDataContext bd = new ORMDataContext();

            var sentencia = (from p in bd.Personas
                             where p.talla == null
                             select p).ToList();
            return sentencia;
        }

        public Personas seleccionarBychild(int ti)
        {
            ORMDataContext bd = new ORMDataContext();

            var sentencia = (from p in bd.Personas
                             where p.numeroIdentificacion == ti
                             select p).First();
            return sentencia;
        }

        public object consultarPorAcudiente()
        {
            ORMDataContext bd = new ORMDataContext();

            var sentencia = (from p in bd.Personas
                             where p.talla == null
                             select p).ToList();

            return sentencia;
        }
    }
}
