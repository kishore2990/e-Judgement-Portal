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
	public partial class Police : System.Web.UI.Page
	{
		SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J7NT5O4\SQLEXPRESS;Initial Catalog=cfc;Integrated Security=True");
		SqlCommand cmd = new SqlCommand();
		SqlDataReader dr;
		
		protected void Page_Load(object sender, EventArgs e)
		{
			
			if (!IsPostBack)
			{
				TextBox13.Text = Session["pid"].ToString();
				cmd.CommandText = "Select cid from complaint";
				cmd.Connection = con;
				if (con.State == ConnectionState.Closed)
					con.Open();
				dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					DropDownList1.Items.Add(dr[0].ToString());
				}
				dr.Close();
				
			}	
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
			string s = "insert into chargesheet(pid,cid,charge_det,charge_date) values('"+TextBox13.Text+"'" +
				","+DropDownList1.SelectedValue+",'"+TextBox12.Text+"','"+DateTime.Now.ToString("dd/MM/yyyy")+"')";
			if (query(s))
			{
				Response.Write("<script>alert('Added')</script>");
				clear();
			}
		}
		void clear()
		{
			TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = TextBox5.Text = TextBox6.Text =
				TextBox7.Text = TextBox8.Text = TextBox9.Text = TextBox10.Text = TextBox11.Text =
				TextBox12.Text = TextBox13.Text ="";
			DropDownList1.SelectedIndex = 0;
		}
		protected void Button2_Click(object sender, EventArgs e)
		{
			string s = "update chargesheet set pid='" + TextBox13.Text + "', charge_det= '" + TextBox12.Text + "',charge_date='" + DateTime.Now.ToString("dd/MM/yyyy") + "' where cid=" + DropDownList1.SelectedValue + "";
			if (query(s))
			{
				Response.Write("<script>alert('Updated')</script>");
				clear();
			}
		}

		protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
		{
			cmd.CommandText = "select * from complaint where cid=" +DropDownList1.SelectedValue+ "";
			cmd.Connection = con;
			if (con.State == ConnectionState.Closed)
				con.Open();
			TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = TextBox5.Text = TextBox6.Text =
				TextBox7.Text = TextBox8.Text = TextBox9.Text = TextBox10.Text = TextBox11.Text =
				TextBox12.Text = TextBox13.Text = "";
			dr = cmd.ExecuteReader();
			if (dr.Read())
			{
				TextBox1.Text = dr[1].ToString();
				TextBox2.Text = dr[2].ToString();
				TextBox3.Text = dr[3].ToString();
				TextBox4.Text = dr[4].ToString();
				TextBox5.Text = dr[5].ToString();
				TextBox6.Text = dr[6].ToString();
				TextBox7.Text = dr[7].ToString();
				TextBox8.Text = dr[8].ToString();
				TextBox9.Text = dr[9].ToString();
				TextBox10.Text = dr[10].ToString();
				TextBox11.Text = dr[11].ToString();
			}
			dr.Close();
			cmd.CommandText = "select * from chargesheet where cid=" + Convert.ToInt32(DropDownList1.SelectedItem.ToString()) + "";
			cmd.Connection = con;
			dr = cmd.ExecuteReader();
			if (dr.Read())
			{
				TextBox13.Text = dr[0].ToString();
				TextBox12.Text = dr[2].ToString();
			}
			
			con.Close();

		}

		protected void TextBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}