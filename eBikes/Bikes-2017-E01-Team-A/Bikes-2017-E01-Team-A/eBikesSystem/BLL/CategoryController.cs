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
    public class CategoryController
    {
        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<CategoryAndPartsQTY> Category_ListAll()
        {
            using (var context = new eBikesContext())
            {
                var result = from x in context.Categories
                             select new CategoryAndPartsQTY
                             {
                                 CategoryID = x.CategoryID,
                                 CategoryName = x.Description,
                                 qtyOfParts = x.Parts.Count(),
                             };

                return result.ToList();
            }
        } //EOM

        //Get Parts and their price based on the CategoryID
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Part> Part_ListBy(int categoryID)
        {
            using (var context = new eBikesContext())
            {
                if (categoryID == -1)
                {
                    return context.Parts.ToList();
                }
                else
                {
                    var partsbycat = from x in context.Parts
                                      where x.CategoryID == categoryID
                                      select x;
                    return partsbycat.ToList();
                }

            }
        }

    }//End of Class
}
