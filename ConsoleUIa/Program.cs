using System;
using BusinessLayer.Concretes;
using DataAccessLayer.Concrete.EntityFramework;

namespace ConsoleUIa
{
    public class Program
    {

        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EFProductDal());

            foreach (var product in productManager.GetByUnitPrice(50,100))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
