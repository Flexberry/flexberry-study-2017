using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Task1.DAL;
using Task1.Objects;

namespace Task1
{
    public partial class FindByGroup : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GroupList.Items.Clear();
                foreach (GroupName gr in Enum.GetValues(typeof(GroupName)))
                {
                    GroupList.Items.Add(gr.ToString());
                    if (gr.ToString() == Request.Params["group"])
                        GroupList.SelectedIndex = GroupList.Items.Count - 1;
                }
                CampusCostBox.Text = DataService.campus_cost.ToString();
                CampusCostBox.Enabled = false;
                
            }
            GroupName groupName = GroupName.Group1;
            foreach (GroupName gr in Enum.GetValues(typeof(GroupName)))
                if (gr.ToString() == GroupList.SelectedItem.Value)
                    groupName = gr;
            StudentsRepeater.DataSource = DataService.GetStudentsByGroup(groupName);
            StudentsRepeater.DataBind();
        }

        protected void ShowByGroupBtn_Click(object sender, EventArgs e)
        {
            GroupName groupName = GroupName.Group1;
            foreach (GroupName gr in Enum.GetValues(typeof(GroupName)))
                if (gr.ToString() == GroupList.SelectedItem.Value)
                    groupName = gr;
            String url;
            if (Request.Url.AbsoluteUri.Contains("?"))
                url = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf('?')) + "?group=" + groupName.ToString();
            else
                url = Request.Url.AbsoluteUri + "?group=" + groupName.ToString();
            Response.Redirect(url);
        }

        protected void GroupList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}