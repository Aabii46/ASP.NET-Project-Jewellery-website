using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jewellery_shop
{
    public partial class Newuserform : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        static string jeweleryConnection = ConfigurationManager.ConnectionStrings["jeweleryConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(jeweleryConnection);
        protected void btn_submit_Click(object sender, EventArgs e)
        {
           
            con.Open();

            SqlCommand cmd = new SqlCommand("sp_newuser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@username", SqlDbType.VarChar);
            cmd.Parameters.Add(p1).Value = txt_uname.Text;

            SqlParameter p2 = new SqlParameter("@pwd", SqlDbType.VarChar);
            cmd.Parameters.Add(p2).Value = txt_pwd.Text;

            SqlParameter p3 = new SqlParameter("@email", SqlDbType.VarChar);
            cmd.Parameters.Add(p3).Value = txt_email.Text;


            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                Response.Write("User Added");
            }
            else
            {
                Response.Write("User Failed!!!!");
            }
        }
    }
}