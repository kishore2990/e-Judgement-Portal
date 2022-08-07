using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
	public partial class Judgepg2 : System.Web.UI.Page
	{
		SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J7NT5O4\SQLEXPRESS;Initial Catalog=cfc;Integrated Security=True");
		SqlCommand cmd = new SqlCommand();
		SqlDataReader dr;
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			cmd.CommandText = "select count(*) from log where uid='" + TextBox1.Text + "' and pwd='" + TextBox2.Text + "' and type='judge'";
			cmd.Connection = con;
			if (con.State == ConnectionState.Closed)
				con.Open();
			dr = cmd.ExecuteReader();
			int c = 0;
			if (dr.Read())
				c = Convert.ToInt32(dr[0]);
			if (c == 1)
			{
				Session["jid"] = TextBox1.Text;
				Response.Redirect("judgepg.aspx");
			}
			else
			{
				Response.Write("<script>alert('Invalid Credential')</script>");
				TextBox1.Text = "";
			}
		}
	}
}