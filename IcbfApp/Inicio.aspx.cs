using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;

namespace IcbfApp
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Persona objPersona = new Persona();

            if (objPersona.login(Login1.UserName, Login1.Password) > 0)
            {
               Response.Redirect("Menu.aspx");
            }
            else
            {
                
            }
        }
        }
}