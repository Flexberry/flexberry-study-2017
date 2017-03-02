using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    public string[] tempText =
        {
        "PMasalkin",
        "pashamasalkin@yandex.ru",
        "Масалкин",
        "Павел",
        "Алексеевич",
        "м",
        "1994",
        "Краснокамск",
        "Россия",
        "http:\\www.temp.ru"
        };

    public string[,] accaunts = new string[,]
    {
        { "ics.perm.ru", "www.google.ru", "www.yandex.ru", "www.mail.ru", "www.sto.ru" },
        { "PMasalkin11", "PMasalkin12", "PMasalkin13", "PMasalkin14", "PMasalkin15" }, 
        { "", "PMasalkin22", "", "PMasalkin24", "PMasalkin25" }, 
        { "PMasalkin31", "PMasalkin32", "PMasalkin33", "PMasalkin34", "" }, 
        { "PMasalkin41", "", "", "PMasalkin44", "PMasalkin45" }
    };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (firstTextBox.Text == string.Empty)
        {
            firstTextBox.Text = StringArrToString(tempText);
        }
        if (secondTextBox.Text == string.Empty)
        {
            secondTextBox.Text = StringArrToString(tempText);
        }

        Table1.CellSpacing = 0;
        Table1.CellSpacing = 0;
        Table1.BorderWidth = 2;
        Table1.GridLines = GridLines.Both;
        for (int i = 0; i < 5; i++)
        {
            TableRow row = new TableRow();
            for (int j = 0; j < 5; j++)
            {
                TableCell cell = new TableCell();
                cell.Text = accaunts[i,j];
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.Height = 26;
                cell.Width = 26;
                row.Cells.Add(cell);
            }
            Table1.Rows.Add(row);
        }
    }

    protected void compareButton_Click(object sender, EventArgs e)
    {
        anserLabel.Text = "Совпадение " + AccauntCompare.Compare.AccauntCompare(StringToArrString(firstTextBox.Text),
            StringToArrString(secondTextBox.Text)).ToString() + "%";
    }

    private string StringArrToString(string[] stringarr)
    {
        string text = string.Empty;
        for(int i =0; i< stringarr.Length; i++)
        {
            if (i != stringarr.Length - 1)
            {
                text += stringarr[i] + System.Environment.NewLine;
            }
            else
            {
                text += stringarr[i];
            }
        }
        return text;
    }

    private string[] StringToArrString(string stringarr)
    {
        string[] text;
        stringarr = stringarr.Replace(System.Environment.NewLine, "|");
        text = stringarr.Split('|');
        return text;
    }
}