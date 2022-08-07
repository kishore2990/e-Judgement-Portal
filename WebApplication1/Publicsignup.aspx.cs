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
	public partial class Publicsignup : System.Web.UI.Page
	{
		SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J7NT5O4\SQLEXPRESS;Initial Catalog=cfc;Integrated Security=True");
		SqlCommand cmd = new SqlCommand();
		protected void Page_Load(object sender, EventArgs e)
		{
			ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
		}
		bool query(String s)
		{
			bool f = false;
			try
			{
				cmd.CommandText = s;
				cmd.Connection = con;
				if (con.State == ConnectionState.Closed)
					con.Open();
				cmd.ExecuteNonQuery();
				f = true;
			}
			catch (Exception ex)
			{
				Response.Write("<script>alert('Error Occured.')</script>");
			}
			finally
			{
				con.Close();
			}
			return f;
		}
		protected void Button1_Click(object sender, EventArgs e)
		{
			string s = "insert into log([name],email,uid,pwd,type) values('" + TextBox2.Text + "'" +
				",'" + TextBox1.Text + "','" + TextBox6.Text + "','" + TextBox4.Text + "','public')";
			if (query(s))
			{
				Response.Write("<script>alert('Signed up Successfully')</script>");
				Response.Redirect("peoplelog.aspx");
			}
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			TextBox1.Text = TextBox2.Text = TextBox4.Text =
				TextBox5.Text = TextBox6.Text = "";
		}

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}