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
	public partial class Complaintpg : System.Web.UI.Page
	{
		SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J7NT5O4\SQLEXPRESS;Initial Catalog=cfc;Integrated Security=True");
		SqlCommand cmd = new SqlCommand();
		SqlDataReader dr;
		protected void Page_Load(object sender, EventArgs e)
		{

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
			catch(Exception ex)
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
			string s = "insert into complaint([name],fathername,dob,aadhar,complaint_det," +
				"complaint_aga,evidence,complaint_date,phone_no,email,address) values('" + TextBox1.Text + "'" +
				",'" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "'" +
				",'" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "','" + TextBox10.Text + "','" + TextBox11.Text + "')";
			if(query(s))
			{
				Response.Write("<script>alert('Added')</script>");
				clear();
			}			
		}
		void clear()
		{
			TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = TextBox5.Text = TextBox6.Text =
				TextBox7.Text = TextBox8.Text = TextBox9.Text = TextBox10.Text = TextBox11.Text = "";
		}
	}
}