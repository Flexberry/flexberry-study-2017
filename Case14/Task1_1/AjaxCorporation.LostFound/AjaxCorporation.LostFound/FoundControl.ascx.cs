namespace AjaxCorporation.LostFound
{
    using AjaxCorporation.LostFound.MessagesAnalysis;
    using System;

    // Заполнение массива введенными пользователем значениями.
    public partial class FoundControl : System.Web.UI.UserControl
    {
        /// <summary>
        /// Формирование массивов и их последующее сопоставление
        /// для выяснения процента совпадений.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Compare_OnClick(object sender, EventArgs e)
        {
            try
            {
                // Наполение массивов.
                string[] lost = new string[9] { TypeMessageLost.Text, NameLost.Text, AdressLost.Text, DateLost.Text, TypeLost.Text, ColorLost.Text, SizeLost.Text, BreedLost.Text, DescriptionLost.Text };

                string[] found = new string[9] { TypeMessageFound.Text, NameFound.Text, AdressFound.Text, DateFound.Text, TypeFound.Text, ColorFound.Text, SizeFound.Text, BreedFound.Text, DescriptionFound.Text };

                // Проверка совпадений строк массива.
                double resultCompare = MessagesCompare.Compare(lost, found);

                // Вывод полученного процента совпадений.
                string resultCompareText = resultCompare.ToString("F");
                Result.Text = resultCompareText;
            }
            catch(Exception ex)
            {
                ExeptionBlock.Text = ex.Message;
            }
        }
    }
}