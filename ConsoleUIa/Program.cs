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

            CategoryManager categoryManager =new CategoryManager(new EFCategoryDal());

            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
                
            }
        }
    }
}
