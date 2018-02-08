using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using Website;

#region Additional Namespaces
using eBikesSystem.BLL.Security;
using eBikes.Data.Entities.Security;
#endregion

public partial class Account_Register : Page
{
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        var manager = new UserManager();
        var user = new ApplicationUser() { UserName = UserName.Text };
        IdentityResult result = manager.Create(user, Password.Text);
        if (result.Succeeded)
        {
            manager.AddUserToRole(user, SecurityRoles.RegisteredUsers);
            IdentityHelper.SignIn(manager, user, isPersistent: false);
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }
        else
        {
            ErrorMessage.Text = result.Errors.FirstOrDefault();
        }
    }
}