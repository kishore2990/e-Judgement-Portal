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
	public partial class Voting : System.Web.UI.Page
	{
		SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J7NT5O4\SQLEXPRESS;Initial Catalog=cfc;Integrated Security=True");
		SqlCommand cmd = new SqlCommand();
		SqlDataReader dr;
		
		
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
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
			cmd.CommandText = "select judgement1,judgement2,judgement3 from judge where cid=" + DropDownList1.SelectedValue+ "";
			cmd.Connection = con;
			if (con.State == ConnectionState.Closed)
				con.Open();
			dr = cmd.ExecuteReader();
			if (dr.Read())
			{
				RadioButton1.Text = dr[0].ToString();
				RadioButton2.Text = dr[1].ToString();
				RadioButton3.Text = dr[2].ToString();
			}
			dr.Close();
			cmd.CommandText = "select [name],fathername,dob,complaint_det,complaint_aga," +
				"evidence,complaint_date from complaint where cid=" + DropDownList1.SelectedValue + "";
			cmd.Connection = con;
			//if (con.State == ConnectionState.Closed)
			//	con.Open();
			dr = cmd.ExecuteReader();
			if (dr.Read())
			{
				TextBox1.Text ="Name: "+ dr[0].ToString()+"\n";
				TextBox1.Text +="Father Name: "+ dr[1].ToString()+"\n";
				TextBox1.Text +="DOB: "+ dr[2].ToString()+"\n";
				TextBox1.Text +="Complaint Detail: "+ dr[3].ToString()+"\n";
				TextBox1.Text +="Complaint Against: "+ dr[4].ToString()+"\n";
				TextBox1.Text += "Date: " + dr[6].ToString() + "\n";
				TextBox1.Text +="Evidence: "+ dr[5].ToString()+"\n";
			}
			dr.Close();
			cmd.CommandText = "select charge_det from chargesheet where cid=" + DropDownList1.SelectedValue+ "";
			cmd.Connection = con;
			dr = cmd.ExecuteReader();
			if (dr.Read())
			{
				TextBox1.Text += "Charge Sheet Details:\n" + dr[0].ToString() + "\n";
			}

			con.Close();
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			int v1 = 0, v2 = 0, v3 = 0;

			if (RadioButton1.Checked)
				v1 = 1;
			else if (RadioButton2.Checked)
				v2 = 1;
			else if (RadioButton3.Checked)
				v3 = 1;

			string s = "update judge set vo1+="+v1+", vo2+="+v2+", vo3+="+v3+" where cid=" + DropDownList1.SelectedValue + "";
			if (query(s))
			{
				Response.Write("<script>alert('Recorded')</script>");
				clear();
			}
		}
		void clear()
		{
			TextBox1.Text =  "";
			DropDownList1.SelectedIndex = 0;
			RadioButton1.Text = "Judgement 1";
			RadioButton2.Text = "Judgement 2";
			RadioButton3.Text = "Judgement 3";
			RadioButton1.Checked = RadioButton2.Checked = RadioButton3.Checked = false;
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			clear();
		}
	}
}