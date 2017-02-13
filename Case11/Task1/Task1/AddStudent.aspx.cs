using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Task1.Objects;
using Task1.DAL;

namespace Task1
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GroupList.Items.Clear();
                GroupList.Items.Add(GroupName.Group1.ToString());
                GroupList.Items.Add(GroupName.Group2.ToString());
                GroupList.Items.Add(GroupName.Group3.ToString());
                GroupList.Items.Add(GroupName.Group4.ToString());
                CampusCostBox.Text = "300";
            }
            if (Request.Params["student"] != null)
            {
                string student = Request.Params["student"];
                DataService.DeleteStudent(student);
                var newUri = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf(Request.Url.Query, StringComparison.Ordinal));
                Response.Redirect(newUri);
            }
            StudentsRepeater.DataSource = DataService.GetAllStudents();
            StudentsRepeater.DataBind();
      
        }

        private void ClearControls()
        {
            NameBox.Text = string.Empty;
            GroupList.SelectedIndex = 0;
            PrivelegeCheck.Checked = false;
            CampusCheck.Checked = false;            
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            Group addGroup = null;
            foreach (Group gr in DataService.GetGroups())
                if (gr.name.ToString() == GroupList.SelectedItem.Value)
                    addGroup = gr;
            Student student = new Student()
            {
                Name = NameBox.Text,
                group = addGroup,
                privelege = PrivelegeCheck.Checked,
                campus = CampusCheck.Checked                
            };
            DataService.AddStudent(student, Double.Parse(CampusCostBox.Text));
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void ClearButon_Click(object sender, EventArgs e)
        {
            DataService.ClearStudents();
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}