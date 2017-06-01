namespace LostFound
{
    using Analysis;
    using System;

    public partial class FoundControl : System.Web.UI.UserControl
    {

        protected void Compare_OnClick(object sender, EventArgs e)
        {
            string[] lost = new string[9] { TypeMessageLost.Text, NameLost.Text, AdressLost.Text, DateLost.Text, TypeLost.Text, ColorLost.Text, SizeLost.Text, BreedLost.Text, DescriptionLost.Text };

            string[] found = new string[9] { TypeMessageFound.Text, NameFound.Text, AdressFound.Text, DateFound.Text, TypeFound.Text, ColorFound.Text, SizeFound.Text, BreedFound.Text, DescriptionFound.Text };

            double resultCompare = MessagesCompare.Compare(lost, found);
            string a = resultCompare.ToString("F");

            Result.Text = a;
        }
    }
}