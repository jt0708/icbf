using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using System.Windows.Forms;

namespace IcbfApp
{
    public partial class ConsultarNinos : System.Web.UI.Page
    {

        Persona ninoDto = new Persona();
        Personas ninoDao = new Personas();
        Jardin jardinDao = new Jardin();
        ClsJardin jardinDto = new ClsJardin();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrilla();
                DDLAcudiente.DataSource = ninoDto.consultarAcudientes();
                
                DDLJardin.DataSource = jardinDto.consultarJardinesActivos();
                DDLJardin.DataTextField = "id";
                DDLJardin.DataValueField = "nombreJardin";
                DDLJardin.DataBind();

                using (var DataContext = new ORMDataContext())
                {
                    DDLAcudiente.DataSource = from p in DataContext.Personas
                                              where p.tipoRol == 3
                                              select new {p.nombres, p.id};
                    DDLAcudiente.DataTextField = "nombres";
                    DDLAcudiente.DataValueField = "id";
                    DDLAcudiente.DataBind();

                    DDLJardin.DataSource = from j in DataContext.Jardin
                                              where j.estado == "Aprobado"
                                              select new { j.nombreJardin, j.id };
                    DDLJardin.DataTextField = "nombreJardin";
                    DDLJardin.DataValueField = "id";
                    DDLJardin.DataBind();

                }
            }
        }    
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            ninoDao.tipoRol = 3;
            ninoDao.nombres = txtNombre.Text;
            ninoDao.apellidos = txtApellido.Text;
            ninoDao.numeroIdentificacion = int.Parse(txtDocumento.Text);            
            ninoDao.fechaNacimiento = Convert.ToDateTime(txtFecha.Text);
            ninoDao.peso = txtPeso.Text;
            ninoDao.talla = txtTalla.Text;
            ninoDao.tipoSangre = DDLTipoSangre.Text;
            ninoDao.eps = DDLEps.Text;
            ninoDao.codAcudiente = int.Parse(DDLAcudiente.SelectedValue.ToString());
            ninoDao.codJardin = int.Parse(DDLJardin.SelectedValue.ToString());
            if (ninoDto.registrarPersona(ninoDao))
            {
                Response.Write("<script>alert('Niño Creado exitosamente');</script>");
                actualizarGrilla();

            }
            else
            {
                Response.Write("<script>alert('Error, no se puedo crear el Niño');</script>");
            }


        }

        protected void dtFecha_SelectionChanged(object sender, EventArgs e)
        {
            txtFecha.Text = dtFecha.SelectedDate.ToShortDateString();
        }

        public void actualizarGrilla()
        {
            gvNinos.DataSource = ninoDto.consultarPorNino();
            gvNinos.DataBind();
        }

        public void cargarGrilla()
        {
            gvNinos.DataSource = ninoDto.consultarPorNino();
            gvNinos.DataBind();
        }
    }
}