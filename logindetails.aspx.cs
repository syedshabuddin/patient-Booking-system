﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
namespace WebApplication1
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ToString());
        //SqlConnection con;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            //con = new SqlConnection("Data Source=localhost;Integrated Security=SSPI;Initial Catalog=mydb");
            con.Open();
            eaddress.Focus();
        }
        protected void btncreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
        protected void btnllogin_Click(object sender, EventArgs e)
        {
            if (eaddress.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter Email Address');", true);
            }
            else if (cpass.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Provide Password');", true);
            }
            object n;
            int result;
            cmd = new SqlCommand("Select count(*) from dbo.login where eaddress='" + eaddress.Text + "' and cpass='" + cpass.Text + "'", con);
            n = cmd.ExecuteScalar();
            result = (int)n;
            if (result > 0)
            {      
               Session["username"] = eaddress.Text;
               Response.Redirect("home.aspx");
               con.Close();   
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid email/password');", true);
                cpass.Text = "";
                con.Close();
            }
        }
        protected void btnfordoctor_Click(object sender, EventArgs e)
        {
            Response.Redirect("fordoctor.aspx");
        }
    }
}
