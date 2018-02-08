using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel; //ODS
using eBikes.Data.Entities;
using eBikes.Data.POCOs;
using eBikesSystem.DAL;
using System.Transactions;
#endregion

namespace eBikesSystem.BLL
{
    [DataObject]
    public class SalesController
    {

        public Coupon Get_Coupon(string Code)
        {
            //Yeah I am gonna do coupon in the sales controller
            using (var context = new eBikesContext())
            {
                Coupon existingCoupon = (from x in context.Coupons
                                         where x.CouponIDValue.Equals(Code)
                                         select x).FirstOrDefault();

                return existingCoupon;
            }
        }//eom

        public OrderSummary Get_OrderSummary(int cusID, string couponCode)
        {
            

            using (var context = new eBikesContext())
            {
                //find the user's shopping cart
                int ShoppingCartID;
                ShoppingCart existingCart = (from x in context.ShoppingCarts
                                             where x.OnlineCustomerID == cusID
                                             select x).FirstOrDefault();


                if (existingCart == null)
                {
                    return null;
                }
                else
                {
                    //determine discount first
                    int discount = 0;
                    Coupon existingCoupon = Get_Coupon(couponCode);
                    if (existingCoupon != null)
                    {
                        discount = existingCoupon.CouponDiscount;
                    }

                    ShoppingCartID = existingCart.ShoppingCartID;
                    decimal subtotal = 0;
                    List<string> dscnItms = new List<string>();
                    List<int> dscnItmsID = new List<int>();
                    List<string> outParts = new List<string>();
                    List<int> outPartID = new List<int>();
                    //Get the list of SCI to loop through
                    List<ShoppingCartItem> listOfSCI = (from x in context.ShoppingCartItems
                                                        where x.ShoppingCartID == ShoppingCartID
                                                        select x).ToList();
                    foreach (var item in listOfSCI)
                    {
                        if (item.Part.QuantityOnHand == 0 || item.Part.Discontinued)
                        {
                            if (item.Part.Discontinued)
                            {
                                dscnItms.Add(item.Part.Description);
                                dscnItmsID.Add(item.Part.PartID);
                            }
                            else if (item.Part.QuantityOnHand == 0)
                            {
                                outParts.Add(item.Part.Description);
                                outPartID.Add(item.Part.PartID);
                            }
                        }
                        else
                        {
                            subtotal += item.Quantity * item.Part.SellingPrice;
                        }

                    }
                    decimal gst = Decimal.Multiply(subtotal, (decimal)0.05);
                    decimal total = subtotal + gst - discount;

                    OrderSummary newOrderSummary = new OrderSummary();
                    newOrderSummary.SubTotal = subtotal;
                    newOrderSummary.GST = gst;
                    newOrderSummary.Discount = discount;
                    newOrderSummary.Total = total;
                    newOrderSummary.DiscountinuedItems = dscnItms;
                    newOrderSummary.DiscountinuedItemsID = dscnItmsID;
                    newOrderSummary.OutOfParts = outParts;
                    newOrderSummary.OutOfPartsID = outPartID;

                    return newOrderSummary;
                }

            }

        }//EOM

        public int Create_Sales(int cusID, string ptype, decimal subtotal, decimal total, string couponCode, bool All = false)
        {
            //Create a Sales Table first
            //The create each individual sales detail

            using (var context = new eBikesContext())
            {
                //find the user's shopping cart
                int ShoppingCartID;
                ShoppingCart existingCart = (from x in context.ShoppingCarts
                                             where x.OnlineCustomerID == cusID
                                             select x).FirstOrDefault();

                if (existingCart != null)
                {
                    //Are there SCIs?
                    ShoppingCartID = existingCart.ShoppingCartID;
                    List<ShoppingCartItem> listOfSCI = (from x in context.ShoppingCartItems
                                                        where x.ShoppingCartID == ShoppingCartID
                                                        select x).ToList();
                    if (listOfSCI.Count == 0)
                    {
                        return 0;
                    }
                    else
                    {

                        //create the sales table
                        int salesID;
                        Sale existingSale = new Sale();
                        existingSale.SaleDate = DateTime.Now;
                        existingSale.UserName = context.OnlineCustomers.Find(cusID).UserName;
                        existingSale.PaymentType = ptype;
                        existingSale.SubTotal = subtotal;
                        existingSale.TaxAmount = Decimal.Multiply(subtotal, (decimal)0.05);
                        Coupon existingCoupon = Get_Coupon(couponCode);
                        if (existingCoupon != null)
                        {
                            existingSale.CouponID = existingCoupon.CouponID;
                        }
                        context.Sales.Add(existingSale);
                        salesID = existingSale.SaleID;

                        //Loop through each SCI and create sales details
                        if (All)
                        {
                            foreach (var item in listOfSCI)
                            {
                                SaleDetail existingSDetail = new SaleDetail();
                                existingSDetail.SaleID = salesID;
                                existingSDetail.PartID = item.PartID;
                                existingSDetail.SellingPrice = item.Part.SellingPrice;
                                existingSDetail.Quantity = item.Quantity;
                                existingSDetail.Backordered = false;
                                if (item.Part.QuantityOnHand == 0)
                                {
                                    existingSDetail.Backordered = true;
                                }
                                context.SaleDetails.Add(existingSDetail);
                            }
                        }
                        else
                        {
                            foreach (var item in listOfSCI)
                            {
                                if (item.Part.QuantityOnHand >= item.Quantity)
                                {
                                    SaleDetail existingSDetail = new SaleDetail();
                                    existingSDetail.SaleID = salesID;
                                    existingSDetail.PartID = item.PartID;
                                    existingSDetail.SellingPrice = item.Part.SellingPrice;
                                    existingSDetail.Quantity = item.Quantity;
                                    existingSDetail.Backordered = false;
                                    context.SaleDetails.Add(existingSDetail);
                                }
                            }
                        }

                        context.SaveChanges();

                        return 1;
                    }

                }
                else
                {
                    return 0;
                }

            }
        }//EOM


    }
}

