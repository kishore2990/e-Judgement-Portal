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
	public partial class Report : System.Web.UI.Page
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

		protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
		{
			cmd.CommandText = "select final_judgement,reason from judge where cid=" + DropDownList1.SelectedValue + "";
			cmd.Connection = con;
			if (con.State == ConnectionState.Closed)
				con.Open();
			dr = cmd.ExecuteReader();
			if (dr.Read())
			{
				Label5.Text = dr[0].ToString();
				TextBox2.Text = dr[1].ToString();
			}
			dr.Close();
			cmd.CommandText = "select [name],fathername,dob,complaint_det,complaint_aga," +
			"evidence,complaint_date from complaint where cid=" + DropDownList1.SelectedValue + "";
			cmd.Connection = con;
			dr = cmd.ExecuteReader();
			if (dr.Read())
			{
				TextBox1.Text = "Name: " + dr[0].ToString() + "\n";
				TextBox1.Text += "Father Name: " + dr[1].ToString() + "\n";
				TextBox1.Text += "DOB: " + dr[2].ToString() + "\n";
				TextBox1.Text += "Complaint Detail: " + dr[3].ToString() + "\n";
				TextBox1.Text += "Complaint Against: " + dr[4].ToString() + "\n";
				TextBox1.Text += "Date: " + dr[6].ToString() + "\n";
				TextBox1.Text += "Evidence: " + dr[5].ToString() + "\n";
			}
			dr.Close();
			cmd.CommandText = "select charge_det from chargesheet where cid=" + DropDownList1.SelectedValue + "";
			cmd.Connection = con;
			dr = cmd.ExecuteReader();
			if (dr.Read())
			{
				TextBox1.Text += "Charge Sheet Details:\n" + dr[0].ToString() + "\n";
			}
			con.Close();
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			TextBox1.Text = TextBox2.Text = "";
			DropDownList1.SelectedIndex = 0;
			Label5.Text = "Final Result";
		}
	}
}