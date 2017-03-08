namespace LostFound
{
    using Analysis;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class FoundControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Compare_OnClick(object sender, EventArgs e)
        {
            string[] lost = new string[9] { TypeMessageFirst.Text, NameFirst.Text, AdressFirst.Text, DateFirst.Text, TypeFirst.Text, ColorFirst.Text, SizeFirst.Text, BreedFirst.Text, DescriptionFirst.Text };

            string[] found = new string[9] { TypeMessageSecond.Text, NameSecond.Text, AdressSecond.Text, DateSecond.Text, TypeSecond.Text, ColorSecond.Text, SizeSecond.Text, BreedSecond.Text, DescriptionSecond.Text };

            ClassComp testClassComp = new ClassComp();
            double resultCompare = testClassComp.Comparison(lost, found);
            string a = resultCompare.ToString("F");

            Result.Text = a;
        }
    }
}