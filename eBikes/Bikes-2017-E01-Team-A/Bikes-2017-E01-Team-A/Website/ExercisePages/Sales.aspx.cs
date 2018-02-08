using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


#region Additional Namespaces
using eBikesSystem.BLL.Security;
using eBikes.Data.Entities;
using eBikes.UI;
using eBikesSystem.BLL;
using eBikes.Data.POCOs;
using eBikes.Data.Entities.Security;
using Microsoft.AspNet.Identity;
#endregion


public partial class Sales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
                Init_CartLists();
                Get_OrderSummaryDetails();
            

   }
    
    protected void Init_CartLists()
    {
        int cusid = GetCustID();
        //Empty the data source first
        GridViewEditCart.DataSource = null;
        GridViewConfirmCart.DataSource = null;

        if (cusid > 0)
        {
            //If customer logged on, set HiddenFieldCusID and hide "LabelToViewCart", "LabelToViewCart2" then bind lists
            HiddenFieldCartCusID.Value = cusid.ToString();
            LabelToViewCart.Visible = false;
            LabelToViewCart2.Visible = false;

            GridViewEditCart.DataBind();
            GridViewConfirmCart.DataBind();
        }
        else
        {
            LabelToViewCart.Visible = true;
            LabelToViewCart2.Visible = true;
        }
    }
    protected void Get_OrderSummaryDetails()
    {

        string couponCode = TextBoxDiscount.Text;

        int cusid = GetCustID();
        if (cusid > 0)
        {
            SalesController salesMgr = new SalesController();
            OrderSummary orderSumDetails = salesMgr.Get_OrderSummary(cusid, couponCode);
            if (orderSumDetails != null)
            {
                LabelSubTotal.Text = orderSumDetails.SubTotal.ToString();
                LabelGST.Text = orderSumDetails.GST.ToString();
                LabelDiscount.Text = orderSumDetails.Discount.ToString();
                LabelTotal.Text = orderSumDetails.Total.ToString();
            }

        }
    }
    protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
    {
        MessageUserControl.HandleDataBoundException(e);
    }
    protected void LinkButtonAllCat_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        HiddenFieldCatID.Value = btn.CommandArgument;
    }

    protected void GetCatItem_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "CatItemBtnClick")
        {
            HiddenFieldCatID.Value = e.CommandArgument.ToString();
        }
    }
    protected int GetCustID()
    {
        int custID = 0;
        if (Request.IsAuthenticated)
        {
            UserManager usrMgr = new UserManager();

            //Find the username
            string username = User.Identity.Name;
            //Grab the user object
            var usrObj = usrMgr.FindByName(username);
            //get id from user object
            custID = usrObj.CustomerID == null ? 0 : (int)usrObj.CustomerID;
        }
        else
        {
            MessageUserControl.ShowInfo("Login as a Customer!");
        }
        return custID;
    }

    protected void ButtonAddStkItm_Click(object sender, EventArgs e)
    {
        int custID = GetCustID();

        if (custID > 0)
        {
            Button btn = (Button)sender;

            //Get the row content of this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            //Did they actually enter a value into the textbox?
            if (string.IsNullOrEmpty((gvr.FindControl("TextBoxATCQuantity") as TextBox).Text))
            {
                MessageUserControl.ShowInfo("Please enter the quantity");
            }
            else
            {
                int qty = int.Parse((gvr.FindControl("TextBoxATCQuantity") as TextBox).Text);
                int stkid = int.Parse(btn.CommandArgument);
                //Is the quantity greater than 0?
                if (qty > 0)
                {
                    //Run the BLL method
                    MessageUserControl.TryRun(() =>
                    {
                        CartController cartmgr = new CartController();
                        cartmgr.AddShoppingCartItem(stkid, qty, custID);
                        GridViewEditCart.DataBind();
                        GridViewConfirmCart.DataBind();
                        MessageUserControl.ShowInfo("Added to Cart");
                    });
                }
                else
                {
                    MessageUserControl.ShowInfo("Your quantity must be greater than 0");
                }
            }
        }
        else
        {
            MessageUserControl.ShowInfo("You must be logged in as a customer to add things to your cart!");
        }


    }
    protected void ButtonUpdateSCI_Click(object sender, EventArgs e)
    {
        int custID = GetCustID();

        if (custID > 0)
        {
            Button btn = (Button)sender;

            //Get the row content of this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            //Did they actually enter a value into the textbox?
            if (string.IsNullOrEmpty((gvr.FindControl("TextBoxSCIQuantity") as TextBox).Text))
            {
                MessageUserControl.ShowInfo("Please enter the quantity");
            }
            else
            {
                int qty = int.Parse((gvr.FindControl("TextBoxSCIQuantity") as TextBox).Text);
                int sciID = int.Parse(btn.CommandArgument);
                //Is the quantity greater than 0?
                if (qty > 0)
                {
                    //Run the BLL method
                    MessageUserControl.TryRun(() =>
                    {
                        CartController cartmgr = new CartController();
                        cartmgr.UpdateShoppingCartItem(sciID, qty, custID);
                        GridViewEditCart.DataBind();
                        GridViewConfirmCart.DataBind();
                        MessageUserControl.ShowInfo("Quantity Changed!");
                    });
                }
                else
                {
                    MessageUserControl.ShowInfo("Your quantity must be greater than 0");
                }
            }
        }
        else
        {
            MessageUserControl.ShowInfo("You must be logged in as a customer!");
        }
    }
    protected void ButtonDeleteSCI_Click(object sender, EventArgs e)
    {
        int custID = GetCustID();
        Button btn = (Button)sender;
        int sciID = int.Parse(btn.CommandArgument);
        MessageUserControl.TryRun(() =>
        {
            CartController cartmgr = new CartController();
            cartmgr.DeleteShoppingCartItem(sciID, custID);
            GridViewEditCart.DataBind();
            GridViewConfirmCart.DataBind();
            MessageUserControl.ShowInfo("Item(s) removed from cart!");
        });
    }


    protected void ButtonApplyDiscount_Click(object sender, EventArgs e)
    {
        Get_OrderSummaryDetails();
    }







    protected void GridViewParts_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}