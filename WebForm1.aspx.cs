using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace crud1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetEmployeeList();
            }
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-V2UQTG1\\SQLEXPRESS;Initial Catalog=swt;Integrated Security=True");

        protected void Button1_Click(object sender, EventArgs e)
        {
            int empid = int.Parse(TextBox1.Text);
            string empname = TextBox2.Text, city = DropDownList1.SelectedValue, sex = RadioButtonList1.SelectedValue, contact = TextBox5.Text;
            double age = double.Parse(TextBox3.Text);
            DateTime jdate = DateTime.Parse(TextBox4.Text);
            connection.Open();
            SqlCommand command = new SqlCommand("Insert into crud values('" + empid + "','" + empname + "','" + city + "','" + age + "','" + sex + "','" + jdate + "','" + contact + "')", connection);
            command.ExecuteNonQuery();

            connection.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully saved');", true);

            GetEmployeeList();
        }
        void GetEmployeeList()
        {
            SqlCommand Command = new SqlCommand("Select * from crud", connection);
            SqlDataAdapter sd = new SqlDataAdapter(Command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
      

       protected void Button2_Click(object sender, EventArgs e)
       {
           int empid = int.Parse(TextBox1.Text);
           string empname = TextBox2.Text, city = DropDownList1.SelectedValue, sex = RadioButtonList1.SelectedValue, contact = TextBox5.Text;
           double age = double.Parse(TextBox3.Text);
           DateTime jdate = DateTime.Parse(TextBox4.Text);
          connection.Open();
          SqlCommand command = new SqlCommand("Update   crud set EmpName= '" + empname + "', City= '" + city + "',  Age= '" + age + "', Sex= '" + sex + "', JoiningDate= '" + jdate + "', Contact= '" + contact + "' where EmpID='" + empid + "'", connection);
            command.ExecuteNonQuery();

            connection.Close();
           ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated');", true);

           GetEmployeeList();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int empid = int.Parse(TextBox1.Text);
            connection.Open();
            SqlCommand command = new SqlCommand("Delete from crud where EmpID='" + empid + "'", connection);
            command.ExecuteNonQuery();

            connection.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Deleted');", true);

            GetEmployeeList();

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int empid = int.Parse(TextBox1.Text);
            //connection.Open();
            SqlCommand command = new SqlCommand("Select * from crud where EmpID='"+ empid +"'", connection);
           SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
           // connection.Close(); 
           
                
          
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            GetEmployeeList();
        }
      
    }
}
    
   