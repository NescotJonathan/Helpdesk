using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Helpdesk
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtFirstname.Text = GridView1.SelectedValue.ToString();       //Setting the Pizza ID FIELD to the value of the first COLUMN in the SELECTED GRID ROW
            int idx = 2;       //The second Column of the SELECTED GRID row
            txtFirstname.Text = GridView1.SelectedRow.Cells[idx].Text;      //Setting the FIELD to the value of the SECOND COLUMN in the SELECTED GRID ROW
            idx = 3;        // 0=first column, 1=second column, 2=third column...
            txtLastname.Text = GridView1.SelectedRow.Cells[idx].Text;     //Setting the FIELD to the value of the THIRD COLUMN in the SELECTED GRID ROW
            idx = 4;        // 0=first column, 1=second column, 2=third column...
            txtPassword.Text = GridView1.SelectedRow.Cells[idx].Text;     //Setting the FIELD to the value of the THIRD COLUMN in the SELECTED GRID ROW
            idx = 5;        // 0=first column, 1=second column, 2=third column...
            txtEmail.Text = GridView1.SelectedRow.Cells[idx].Text;     //Setting the FIELD to the value of the THIRD COLUMN in the SELECTED GRID ROW


            //int myNumber = int.Parse(GridView1.SelectedRow.Cells[idxx].Text.ToString().Trim());     //CONVERT a string to an integer
            //grdSelectedPerson.SelectRow(myNumber - 1);        //The Value in this GRID begins at 0, so had to USE minus 1 (because the VALUE began at 1)
        }

        protected void btnSaveNewItem_Click(object sender, EventArgs e)
        {
            HelpdeskEntities db = new HelpdeskEntities();     //Your Database as listed in your Web.config FILE under: <connectionStrings> < add name = "testEntities" ...  < add name = "testEntities1" ...
            var user = new User();
            user.FirstName = txtFirstname.Text.ToString();
            user.LastName = txtLastname.Text.ToString();
            user.Passcode = txtPassword.Text.ToString(); 
            user.Email = txtEmail.Text.ToString();  
            db.Users.Add(user);
            db.SaveChanges();
            GridView1.DataBind();
        }

        protected void btnSaveEdit_Click(object sender, EventArgs e)
        {
            HelpdeskEntities db = new HelpdeskEntities();     //Your Database as listed in your Web.config FILE under: <connectionStrings> < add name = "testEntities" ...  < add name = "testEntities1" ...
            var user = db.Users.Find(GridView1.SelectedValue);
            user.FirstName = txtFirstname.Text.ToString();
            user.LastName = txtLastname.Text.ToString();
            user.Passcode = txtPassword.Text.ToString();
            user.Email = txtEmail.Text.ToString();
            db.SaveChanges();
            GridView1.DataBind();
        }

        protected void btnDeleteItem_Click(object sender, EventArgs e)
        {
            HelpdeskEntities db = new HelpdeskEntities();     //Your Database as listed in your Web.config FILE under: <connectionStrings> < add name = "testEntities" ...  < add name = "testEntities1" ...
            var user = db.Users.Find(GridView1.SelectedValue);
            db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            GridView1.DataBind();
        }
    }
}