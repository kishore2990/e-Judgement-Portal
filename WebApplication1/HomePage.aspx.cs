using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
	public partial class HomePage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			Response.Redirect("Peoplelog.aspx");
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			Response.Redirect("PoliceLog2.aspx");
		}

		protected void Button3_Click(object sender, EventArgs e)
		{
			Response.Redirect("Judgepg2.aspx");
		}
	}
}