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
	public partial class Judgepg : System.Web.UI.Page
	{
		SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J7NT5O4\SQLEXPRESS;Initial Catalog=cfc;Integrated Security=True");
		SqlCommand cmd = new SqlCommand();
		SqlDataReader dr;
		
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				TextBox13.Text = Session["jid"].ToString();
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

		protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
		{
			cmd.CommandText = "select * from complaint where cid=" +DropDownList1.SelectedItem.ToString()+ "";
			cmd.Connection = con;
			if (con.State == ConnectionState.Closed)
				con.Open();
			TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = TextBox5.Text = TextBox6.Text =
				TextBox7.Text = TextBox8.Text = TextBox9.Text = TextBox10.Text = TextBox11.Text =
				TextBox12.Text = TextBox13.Text = TextBox14.Text = TextBox15.Text = TextBox16.Text =
				TextBox17.Text = "";
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
				TextBox17.Text = dr[0].ToString();
				TextBox12.Text = dr[2].ToString();
			}
			dr.Close();
			cmd.CommandText = "select * from judge where cid=" + Convert.ToInt32(DropDownList1.SelectedItem.ToString()) + "";
			cmd.Connection = con;
			dr = cmd.ExecuteReader();
			if (dr.Read())
			{
				TextBox13.Text = dr[0].ToString();
				TextBox14.Text = dr[3].ToString();
				TextBox15.Text = dr[4].ToString();
				TextBox16.Text = dr[5].ToString();
			}
			con.Close();

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			string s = "insert into judge(jid,cid,pid,judgement1,judgement2,judgement3,vo1,vo2,vo3)" +
				"values('" + TextBox13.Text + "'," + DropDownList1.SelectedValue + "" +
				",'" + TextBox17.Text + "','" + TextBox14.Text + "','" + TextBox15.Text + "','" + TextBox16.Text + "',0,0,0)";
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
				TextBox12.Text = TextBox13.Text = TextBox14.Text = TextBox15.Text = TextBox16.Text =
				TextBox17.Text="";
				DropDownList1.SelectedIndex = 0;
		}
		protected void Button2_Click(object sender, EventArgs e)
		{
			string s = "update judge set jid='" + TextBox13.Text + "', pid= '" + TextBox17.Text + "'," +
				"judgement1='" + TextBox14.Text + "',judgement2='" + TextBox15.Text + "'" +
				",judgement3='" + TextBox16.Text + "' where cid=" + DropDownList1.SelectedValue + "";
			if (query(s))
			{
				Response.Write("<script>alert('Updated')</script>");
				clear();
			}
		}
	}
}