using PineappleSupermarket.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace PineappleSupermarket.Data
{
    public class ProductInitializer : DropCreateDatabaseAlways<ProductDbContext>
    { 
       protected override void Seed(ProductDbContext context)
        {
            base.Seed(context);

            var product = new List<Product>
      {
           new Product {
              Name = "Pavlova",
              ProductCategory = 1,
              Description = "Dessert of Australian and New Zealand origin consisting of a meringue shell topped with whipped cream and usually fruit.",
              Quantity = 5,
              UnitPrice = 177,
              Picture = getFileBytes ("\\Images\\product.jpg"),
              ImageMimeType = "image/jpeg"

           },

            new Product {
              Name = "Chocolate Biscuits",
              ProductCategory = 3,
              Description = "Two crisp baked cookies and a layer of smooth cream filling, together create a sandwich with a delicious full-flavoured taste.",
              Quantity = 258,
              UnitPrice = 258,
              Picture = getFileBytes ("\\Images\\product1.jpg"),
              ImageMimeType = "image/jpeg"

           }
      };
            product.ForEach(s => context.Products.Add(s));
            context.SaveChanges();

        }

            private byte[] getFileBytes(string path)
            {
                FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
                byte[] fileBytes;
                using (BinaryReader br = new BinaryReader(fileOnDisk))
                {
                    fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                }
                return fileBytes;
            }
        }
    }