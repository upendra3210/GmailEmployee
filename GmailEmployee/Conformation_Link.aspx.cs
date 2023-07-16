using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace GmailEmployee
{
    public partial class Conformation_Link : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        string str = ConfigurationManager.ConnectionStrings["Gmail_Employee"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                allgrid();
            }
        }
        private void allgrid()
        {

            conn = new SqlConnection(str);
            cmd = new SqlCommand("Select Eid,EmpName,EmpDob,EmpPhone,EmpAge,Address,Gmail from Gmail_Employee", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            conn.Close();

        }

        protected void GridView1_RowCancelingEdit1(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            allgrid();
        }

        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(GridView1.Rows[e.RowIndex].Cells[1].Text);
           // string id = (GridView1.Rows[e.RowIndex].Cells[1].Controls[0].ToString());
            conn = new SqlConnection(str);
            cmd = new SqlCommand($"delete Gmail_Employee where Eid={id}", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            allgrid();
        }

        protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            allgrid();
        }

        protected void GridView1_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        {
            string Name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string Dob = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string Phone = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            string Age = ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
            string Address = ((TextBox)GridView1.Rows[e.RowIndex].Cells[6].Controls[0]).Text;
            string Gmail = ((TextBox)GridView1.Rows[e.RowIndex].Cells[7].Controls[0]).Text;
            conn = new SqlConnection(str);
            cmd = new SqlCommand($"Update Gmail_Employee set EmpName='{Name}',EmpDob='{Dob}',EmpPhone='{Phone}',EmpAge={Age},Address='{Address}',Gmail='{Gmail}'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            allgrid();
        }
    }
}