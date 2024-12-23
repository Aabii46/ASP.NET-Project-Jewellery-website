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
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        static string jeweleryConnection = ConfigurationManager.ConnectionStrings["jeweleryConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(jeweleryConnection);
        protected void btn_submit_Click(object sender, EventArgs e)
        {
           
            con.Open();

            SqlCommand cmd = new SqlCommand("sp_Fetchuser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DA.Fill(ds);

            gv_dashboard.DataSource = ds.Tables[0];
            gv_dashboard.DataBind();
            con.Close();
        }
    }
}