using Microsoft.AspNetCore.Http.HttpResults;
using System.Xml.Linq;
using WebApplicationDemo.Models;
namespace WebApplicationDemo.Data
{
    public class ProductRepositoryImpl : IProductRepository
    {
        //    List<Product> productList = new List<Product> {
        //        new Product{ ProductId=1,ProductName="Soccer Ball" , ProductCode ="SOB-BAL",Price=2000, Category="Soccer" ,ImageUrl=@"assets/images/socccerball.jpeg", Description="There are many variations of passages of Lorem Ipsum available",StarRating=4.5},
        //        new Product{ ProductId=2,ProductName="Kayak" , Price=10000,ProductCode ="WAT-KAK" ,Category="Water Sports" ,ImageUrl=@"assets/images/kayak.jpeg", Description="There are many variations of passages of Lorem Ipsum available",StarRating=3.7},
        //        new Product{ ProductId=3,ProductName="Life Jacket" , Price=800,ProductCode ="WAT-LJK" ,Category="Water Sports", ImageUrl=@"assets/images/lifeJacket.jpeg", Description="There are many variations of passages of Lorem Ipsum available",StarRating=2.5},
        //        new Product{ ProductId=4,ProductName="Chess Board" , Price=200,ProductCode ="CHS-BOD", Category="Indoor Games",ImageUrl=@"assets/images/chessboard.jpeg", Description="There are many variations of passages of Lorem Ipsum available",StarRating=4.3},
        //        new Product{ ProductId=5,ProductName="Carrom Coins" ,ProductCode ="CAR-COIN" ,Price=700, Category="Soccer",ImageUrl=@"assets/images/socccerball.jpeg", Description="There are many variations of passages of Lorem Ipsum available",StarRating=3.5},
        //    };

        //    public Task<List<Product>> GetProducts()
        //    {
        //        return Task.Run(()=> productList);
        //    }

        //    public Task<Product?> GetProductById(int id) {
        //        Task<Product?> p = Task.Run(() => productList.SingleOrDefault(x => x.ProductId == id));
        //        if (p != null)
        //        {
        //            return p;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }


        //    public Task<List<Product?>> GetProductsByName(string name)
        //    {
        //        Task<List<Product?>> p = Task.Run(() => productList.Where(x=>x.ProductName.ToLower().Contains(name.ToLower())).ToList());
        //        if (p != null)
        //        {
        //            return p;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }

        //    public async Task<Product?> UpdateProductPrice(int id, double newPrice)
        //    {
        //        Product product = null;
        //        product = await GetProductById(id);
        //        if (product != null) 
        //        {
        //            product.Price = newPrice;
        //        }
        //        return product;
        //    }

        //    public async Task<bool> CreateProduct(Product product)
        //    {
        //        Product p = null;
        //        p = await GetProductById(product.ProductId);
        //        if(p != null || product == null)
        //        {
        //            return await Task.FromResult(false);
        //        }
        //        else
        //        {
        //            productList.Add(product);

        //            return await Task.FromResult(true);
        //        }
        //    }

        //    public async Task<bool> DeleteProduct(int id)
        //    {
        //        Product p = null;
        //        p = await GetProductById(id);
        //        if (p == null)
        //        {
        //            return await Task.FromResult(false);
        //        }
        //        else
        //        {
        //            productList.Remove(p);

        //            return await Task.FromResult(true);
        //        }
        //    }

        //    public Task<List<Product?>> GetProductsByRating(double rating)
        //    {
        //        Task<List<Product?>> p = Task.Run(() => productList.Where(x => x.StarRating>=rating).ToList());
        //        return p;
        //    }

        //    public Task<List<Product?>> GetProductsByPriceRange(double min, double max)
        //    {
        //        Task<List<Product?>> p = Task.Run(() => productList.Where(x =>  x.Price >=min && max >=x.Price ).ToList());
        //        return p;
        //    }

        //    public Task<List<Product?>> GetProductsByCategory(string category)
        //    {
        //        Task<List<Product?>> p = Task.Run(() => productList.Where(x => x.Category.ToLower().Contains(category.ToLower())).ToList());
        //        if (p != null)
        //        {
        //            return p;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }

        //    public Task<Product?> GetProductByProductCode(string code)
        //    {
        //        Task<Product?> p = Task.Run(() => productList.FirstOrDefault(x => x.ProductCode==code));
        //        if (p != null)
        //        {
        //            return p;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}
        Task<bool> IProductRepository.CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        Task<bool> IProductRepository.DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        Task<Product?> IProductRepository.GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        Task<Product?> IProductRepository.GetProductByProductCode(string code)
        {
            throw new NotImplementedException();
        }

        Task<List<Product>> IProductRepository.GetProducts()
        {
            throw new NotImplementedException();
        }

        Task<List<Product?>> IProductRepository.GetProductsByCategory(string category)
        {
            throw new NotImplementedException();
        }

        Task<List<Product?>> IProductRepository.GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        Task<List<Product?>> IProductRepository.GetProductsByPriceRange(double min, double max)
        {
            throw new NotImplementedException();
        }

        Task<List<Product?>> IProductRepository.GetProductsByRating(double rating)
        {
            throw new NotImplementedException();
        }

        Task<Product?> IProductRepository.UpdateProductPrice(int id, double newPrice)
        {
            throw new NotImplementedException();
        }
    }
}
