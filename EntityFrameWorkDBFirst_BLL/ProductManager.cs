using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameWorkDBFirst_BLL.ViewModels;
using EntityFrameWorkDBFirst_DAL;

namespace EntityFrameWorkDBFirst_BLL
{
    public class ProductManager
    {
        NORTHWNDEntities myDBContext = new NORTHWNDEntities();
        public List<ProductViewModel> TumUrunleriGetir()
        {
            List<ProductViewModel> urunler = new List<ProductViewModel>();
            var data = myDBContext.Products.ToList();
            foreach (var item in data)
            {
                ProductViewModel p = new ProductViewModel()
                {
                    CategoryID=item.CategoryID,
                    ProductID=item.ProductID,
                    UnitPrice=item.UnitPrice,
                    UnitsInStock=item.UnitsInStock,
                    Discontinued=item.Discontinued,
                    UnitsOnOrder=item.UnitsOnOrder,
                    ReorderLevel=item.ReorderLevel,
                    SupplierID=item.SupplierID,
                    ProductName=item.ProductName,
                    QuantityPerUnit=item.QuantityPerUnit
                };
                //CategoryName
                //1.yol
                //p.CategoryName = item.Category.CategoryName;
                //2.yol
                p.CategoryName = myDBContext.Categories.FirstOrDefault(x => x.CategoryID == item.CategoryID)?.CategoryName;

                urunler.Add(p);
            }
            return urunler;
        }
        public bool YeniUrunEkle(ProductViewModel p)
        {
            bool sonuc = false;
            Product newProduct = new Product
            {
                ProductName = p.ProductName,
                Discontinued = p.Discontinued,
                CategoryID = p.CategoryID
            };

            myDBContext.Products.Add(newProduct);
            int affectedRows = myDBContext.SaveChanges();
            if (affectedRows > 0)
            {
                sonuc = true;
            }

            return sonuc;
        }
    }
}
