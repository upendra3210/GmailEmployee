using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using System.Text;

namespace GmailEmployee
{
    public partial class gmailEmp : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        string str = ConfigurationManager.ConnectionStrings["Gmail_Employee"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            cmd = new SqlCommand($"insert into Gmail_Employee(EmpName,EmpDob,EmpPhone,EmpAge,Address,Gmail) values('{TxtName.Text}','{EmpDob.Text}','{EmpPhone.Text}',{EmpAge.Text},'{Address.Text}','{txtGmail.Text}')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MailCall();

        }
        private void MailCall()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Hello User,");
            stringBuilder.Append("<br /><br />");
            stringBuilder.Append("This is only for pratice purpos only<br >Click below link to verification:");
            stringBuilder.Append("<br /><br />");
            stringBuilder.Append("<a href='http://localhost:59424/Conformation_Link.aspx'>Verification link</a>");
            //Mail massage Pre-defined Class
            MailMessage Mail = new MailMessage();
            Mail.From = new MailAddress("uppendra9000@gmail.com");
            Mail.To.Add($"{txtGmail.Text}");
            Mail.Subject = "Grid Link";
            Mail.Body = stringBuilder.ToString();
            Mail.IsBodyHtml=true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
            smtp.Credentials = new System.Net.NetworkCredential("uppendra9000@gmail.com", "eprsocmvsjkabjqy");
            smtp.EnableSsl = true;
            smtp.Send(Mail);
            Label1.Visible = true;
            Label1.Text = "Check your mail and click on the That link";
           // Label1.ForeColor = System.Drawing.Color.Green;
        }
       
    }
}