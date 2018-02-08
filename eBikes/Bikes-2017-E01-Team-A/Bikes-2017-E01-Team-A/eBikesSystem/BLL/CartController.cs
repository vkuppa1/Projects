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


/*
 *THis controller will manage the working of the cart.
 *  
 */

namespace eBikesSystem.BLL
{
    [DataObject]
    public class CartController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SCICostTotal> List_SCI(int cusID)
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
                    //No Shopping cart return empty SCI list
                    var parts = Enumerable.Empty<SCICostTotal>().ToList<SCICostTotal>();
                    return parts;
                }
                else
                {
                    ShoppingCartID = existingCart.ShoppingCartID;
                    //list the shopping cart items based 
                    var parts = (from x in context.ShoppingCartItems
                                  where x.ShoppingCartID == ShoppingCartID
                                  select new SCICostTotal
                                  {
                                      sciID = x.ShoppingCartItemID,
                                      Product = x.Part.Description,
                                      Quantity = x.Quantity,
                                      Price = x.Part.SellingPrice,
                                      Total = x.Quantity * x.Part.SellingPrice,
                                  }).ToList();

                    return parts;
                }

            }
        }

        public void AddShoppingCartItem(int prtID, int qty, int cusID)
        {
            using (var context = new eBikesContext())
            {
                //Find existing shopping cart, then create new SCI to that existing shopping cart

                int ShoppingCartID;

                //If shopping cart for user exists use that one else create a new one
                ShoppingCart existingCart = (from x in context.ShoppingCarts
                                             where x.OnlineCustomerID == cusID
                                             select x).FirstOrDefault();

                if (existingCart == null)
                {
                    //create new shopping cart
                    existingCart = new ShoppingCart();
                    existingCart.OnlineCustomerID = cusID;
                    existingCart.CreatedOn = DateTime.Now;
                    existingCart.UpdatedOn = DateTime.Now;
                    existingCart = context.ShoppingCarts.Add(existingCart);
                    //add SCI - no need to update cart time
                    ShoppingCartID = existingCart.ShoppingCartID;
                    ShoppingCartItem existingSCI = new ShoppingCartItem();
                    existingSCI.ShoppingCartID = ShoppingCartID;
                    existingSCI.PartID = prtID;     
                    existingSCI.Quantity = qty;
                    context.ShoppingCartItems.Add(existingSCI);
                }
                else
                {
                    ShoppingCartID = existingCart.ShoppingCartID;
                    //If item already exists in the customer's cart add qty to it else insert it
                    ShoppingCartItem existingSCI = (from x in context.ShoppingCartItems
                                                    where x.PartID == prtID
                                                    && x.ShoppingCartID == ShoppingCartID
                                                    select x).FirstOrDefault();
                    if (existingSCI == null)
                    {
                        //create the SCI - also update cart time
                        existingSCI = new ShoppingCartItem();
                        existingSCI.ShoppingCartID = ShoppingCartID;
                        existingSCI.PartID = prtID;
                        existingSCI.Quantity = qty;
                        context.ShoppingCartItems.Add(existingSCI);
                        existingCart.UpdatedOn = DateTime.Now;
                        context.Entry(existingCart).Property(y => y.UpdatedOn).IsModified = true;
                    }
                    else
                    {
                        //update the quantity - also update cart time
                        existingSCI.Quantity += qty;
                        existingCart.UpdatedOn = DateTime.Now;
                        context.Entry(existingSCI).Property(y => y.Quantity).IsModified = true;
                        context.Entry(existingCart).Property(y => y.UpdatedOn).IsModified = true;
                    }
                }

                context.SaveChanges();
            }
        }//EOM

        public void UpdateShoppingCartItem(int prtID, int qty, int cusID)
        {
            using (var context = new eBikesContext())
            {
                //find the user's shopping cart
                ShoppingCart existingCart = (from x in context.ShoppingCarts
                                             where x.OnlineCustomerID == cusID
                                             select x).FirstOrDefault();
                if (existingCart != null)
                {
                    ShoppingCartItem existingSCI = context.ShoppingCartItems.Find(prtID);
                    existingSCI.Quantity = qty;
                    existingCart.UpdatedOn = DateTime.Now;
                    context.Entry(existingSCI).Property(y => y.Quantity).IsModified = true;
                    context.Entry(existingCart).Property(y => y.UpdatedOn).IsModified = true;
                }

                context.SaveChanges();
            }
        }//EOM

        public void DeleteShoppingCartItem(int prtID, int cusID)
        {
            using (var context = new eBikesContext())
            {
                //find the user's shopping cart
                ShoppingCart existingCart = (from x in context.ShoppingCarts
                                             where x.OnlineCustomerID == cusID
                                             select x).FirstOrDefault();
                if (existingCart != null)
                {
                    var existingSCI = context.ShoppingCartItems.Find(prtID);
                    context.ShoppingCartItems.Remove(existingSCI);
                    existingCart.UpdatedOn = DateTime.Now;
                    context.Entry(existingCart).Property(y => y.UpdatedOn).IsModified = true;
                }
                context.SaveChanges();
            }
        }

    }//EOC
}
