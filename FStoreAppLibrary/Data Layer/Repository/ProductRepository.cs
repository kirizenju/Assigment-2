using FStoreAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FStoreAppLibrary.Data_Layer.Repository
{
    public class ProductRepository : IProductRepository
    {
        public bool DeleteProduct(int productId) => ProductDBContext.Instance.Delete(productId);

        public Product GetProductById(int productId) => ProductDBContext.Instance.GetProductById(productId);

        public List<Product> GetProducts() => ProductDBContext.Instance.GetProducts();

        public bool InsertProduct(Product product) => ProductDBContext.Instance.Insert(product);

        public bool UpdateProduct(Product product) => ProductDBContext.Instance.Update(product);

        public List<Product> Searching(string searchBy, string keyword) => ProductDBContext.Instance.SearchProducts(searchBy, keyword);
    }
}
