namespace ICSSoft.STORMNET.Web
{
    using System;

    /// <summary>
    /// Страница, отображаемая в случае ошибки 404.
    /// </summary>
    public partial class Error404 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.StatusCode = 404;
        }
    }
}