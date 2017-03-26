namespace NewPlatform.RecordBookBL.forms
{
    using System;
    using System.Data;
    using ICSSoft.STORMNET.Business;

    public partial class ExecuteQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ExecuteSqlQueryButton_OnClick(object sender, EventArgs e)
        {
            SQLDataService ds = (SQLDataService)DataServiceProvider.DataService;
            IDbConnection connection = ds.GetConnection();

            try
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "select count(*) from Преподаватель";
                var result = command.ExecuteScalar();
                QueryResultLabel.Text = result.ToString();
            }
            catch (Exception ex)
            {
                QueryResultLabel.Text = ex.ToString();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}