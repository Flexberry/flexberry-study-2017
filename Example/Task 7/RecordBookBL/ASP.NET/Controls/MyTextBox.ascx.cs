namespace NewPlatform.RecordBookBL.Controls
{
    using System;

    public partial class MyTextBox : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Инициализация контрола, его скриптов и пр.
        }

        /// <summary>
        /// Значение элемента управления.
        /// </summary>
        public string TextValue
        {
            get { return MainTextBox.Text; }
            set { MainTextBox.Text = value; }
        }
    }
}