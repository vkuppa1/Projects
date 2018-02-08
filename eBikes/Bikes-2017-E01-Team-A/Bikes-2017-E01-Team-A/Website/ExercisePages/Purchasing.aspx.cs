using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eBikesSystem.BLL;
using eBikes.Data.POCOs;

#region Additional Namespaces
using eBikesSystem.BLL.Security;
using eBikes.Data.Entities;
using eBikes.Data.Entities.Security;
#endregion


public partial class Purchasing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsAuthenticated)
        {
            Response.Redirect("~/Account/Login.aspx");
        }
        else
        {
            if (!User.IsInRole(SecurityRoles.Purchasing))
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

    }
    protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
    {
        MessageUserControl.HandleDataBoundException(e);
    }
}
