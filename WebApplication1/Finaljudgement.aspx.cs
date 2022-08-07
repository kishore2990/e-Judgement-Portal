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
	public partial class Finaljudgement : System.Web.UI.Page
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
			cmd.CommandText = "Select judgement1,vo1,judgement2,vo2,judgement3,vo3,final_judgement,reason,(vo1+vo2+vo3)as res from judge where cid=" + DropDownList1.SelectedValue + "";
			cmd.Connection = con;
			TextBox1.Text = TextBox2.Text = "";
			RadioButton1.Text = "Judgement 1";
			RadioButton2.Text = "Judgement 2";
			RadioButton3.Text = "Judgement 3";
			RadioButton1.Checked = RadioButton2.Checked =
				RadioButton3.Checked = false;
			if (con.State == ConnectionState.Closed)
				con.Open();
			dr = cmd.ExecuteReader();
			if (dr.Read())
			{
				double sum = Convert.ToDouble(dr[8]);
				double v1 = Convert.ToDouble(dr[1]) * 100 / sum;
				double v2 = Convert.ToDouble(dr[3]) * 100 / sum;
				double v3 = Convert.ToDouble(dr[5]) * 100 / sum;
				RadioButton1.Text = dr[0].ToString();
				RadioButton2.Text = dr[2].ToString();
				RadioButton3.Text = dr[4].ToString();
				if (dr[6].ToString() == RadioButton1.Text)
				{
					RadioButton1.Checked = true;
				}
				else if (dr[6].ToString() == RadioButton2.Text)
				{
					RadioButton2.Checked = true;
				}
				else if (dr[6].ToString() == RadioButton3.Text)
				{
					RadioButton3.Checked = true;
				}
				RadioButton1.Text += " " + v1 + "%";
				RadioButton2.Text += " " + v2 + "%";
				RadioButton3.Text += " " + v3 + "%";
				TextBox2.Text = dr[7].ToString();
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

		protected void Button1_Click(object sender, EventArgs e)
		{
			string fj = "";
			if (RadioButton1.Checked)
				fj = RadioButton1.Text;
			else if (RadioButton2.Checked)
				fj = RadioButton2.Text;
			else if (RadioButton3.Checked)
				fj = RadioButton3.Text;
			string s = "update judge set final_judgement='" + fj + "', reason='" + TextBox2.Text + "' where cid=" + DropDownList1.SelectedValue + "";
			if (query(s))
			{
				Response.Write("<script>alert('Recorded')</script>");
				clear();
			}

		}
		void clear()
		{
			TextBox1.Text =TextBox2.Text= "";
			
			RadioButton1.Text = "Judgement 1";
			RadioButton2.Text = "Judgement 2";
			RadioButton3.Text = "Judgement 3";
			RadioButton1.Checked = RadioButton2.Checked = 
				RadioButton3.Checked = false;
			DropDownList1.SelectedIndex = 0;
		}
		protected void Button2_Click(object sender, EventArgs e)
		{
			clear();
		}
	}
}