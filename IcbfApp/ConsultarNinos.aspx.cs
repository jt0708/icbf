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
                txtCodigo.Enabled = false;
                btnActualizar.Enabled = false;
                cargarGrilla();
                DDLAcudiente.DataSource = ninoDto.consultarAcudientes();

                DDLJardin.DataSource = jardinDto.consultarJardinesActivos();
                DDLJardin.DataTextField = "id";
                DDLJardin.DataValueField = "nombreJardin";
                DDLJardin.DataBind();

                using (var DataContext = new ORMDataContext())
                {
                    DDLAcudiente.DataSource = from p in DataContext.Personas
                                              where p.tipoRol == 4
                                              select new { p.nombres, p.id };
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
            ninoDao.numeroIdentificacion = int.Parse(txtDocumento.Text);
            ninoDao.nombres = txtNombre.Text;
            ninoDao.apellidos = txtApellido.Text;
            ninoDao.fechaNacimiento = Convert.ToDateTime(txtFecha.Text);
            ninoDao.ciudadNacimiento = txtCiudad.Text;
            ninoDao.direccion = txtDireccion.Text;
            ninoDao.telefono = txtTelefono.Text;
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
                limpiarCampos();

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

        public void limpiarCampos()
        {
            txtCodigo.Text = "";
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtFecha.Text = "";
            txtCiudad.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtPeso.Text = "";
            txtTalla.Text = "";
            DDLTipoSangre.Text = "";
            DDLEps.Text = "";
            btnCrear.Enabled = true;
            btnActualizar.Enabled = false;

        }

        protected void gvNinos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "eliminar")
            {
                int indice = Convert.ToInt32(e.CommandArgument.ToString());
                string variable = gvNinos.Rows[indice].Cells[0].Text;

                if (ninoDto.eliminarPersona(int.Parse(variable)))
                {
                    Response.Write("<script>alert('Eliminacion correctamente')</script>");
                    cargarGrilla();
                }
                else
                {
                    Response.Write("<script>alert('Error, no se pudo eliminar')</script>");
                }
            }
            if (e.CommandName == "editar")
            {
                int indice = Convert.ToInt32(e.CommandArgument.ToString());
                txtCodigo.Text = gvNinos.Rows[indice].Cells[0].Text;
                txtDocumento.Text = gvNinos.Rows[indice].Cells[1].Text;
                txtNombre.Text = gvNinos.Rows[indice].Cells[2].Text;
                txtApellido.Text = gvNinos.Rows[indice].Cells[3].Text;
                txtFecha.Text = gvNinos.Rows[indice].Cells[4].Text;
                txtCiudad.Text = gvNinos.Rows[indice].Cells[5].Text;
                txtDireccion.Text = gvNinos.Rows[indice].Cells[6].Text;
                txtTelefono.Text = gvNinos.Rows[indice].Cells[7].Text;
                txtPeso.Text = gvNinos.Rows[indice].Cells[8].Text;
                txtTalla.Text = gvNinos.Rows[indice].Cells[9].Text;
                DDLTipoSangre.Text = gvNinos.Rows[indice].Cells[10].Text;
                DDLEps.Text = gvNinos.Rows[indice].Cells[11].Text;
                btnCrear.Enabled = false;
                btnActualizar.Enabled = true;
                actualizarGrilla();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Persona ninoDto = new Persona();
            Personas ninoDao = new Personas();

            ninoDao.tipoRol = 3;
            ninoDao.numeroIdentificacion = int.Parse(txtDocumento.Text);
            ninoDao.nombres = txtNombre.Text;
            ninoDao.apellidos = txtApellido.Text;
            ninoDao.fechaNacimiento = Convert.ToDateTime(txtFecha.Text);
            ninoDao.ciudadNacimiento = txtCiudad.Text;
            ninoDao.direccion = txtDireccion.Text;
            ninoDao.telefono = txtTelefono.Text;
            ninoDao.peso = txtPeso.Text;
            ninoDao.talla = txtTalla.Text;
            ninoDao.tipoSangre = DDLTipoSangre.Text;
            ninoDao.eps = DDLEps.Text;
            ninoDao.codAcudiente = int.Parse(DDLAcudiente.SelectedValue.ToString());
            ninoDao.codJardin = int.Parse(DDLJardin.SelectedValue.ToString());
            if (ninoDto.actualizarPersona(ninoDao))
            {
                Response.Write("<script>alert('actualización exitosa');</script>");
                actualizarGrilla();
                limpiarCampos();

            }
            else
            {
                Response.Write("<script>alert('Error, no se puedo actualizar información');</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }
    }
}