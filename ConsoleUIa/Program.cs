using System;
using BusinessLayer.Concretes;
using DataAccessLayer.Concrete.EntityFramework;

namespace ConsoleUIa
{
    public class Program
    {

        static void Main(string[] args)
        {
            
            ProductTest();
            //CategoryTest();

        }
        private static void CategoryTest()
        {


            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());

            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);

            }
        }
        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());

            var result = productManager.GetProductDetails();

            if (result.Success == true )
            {
                foreach (var product in result.Data) 
                {
                    Console.WriteLine(product.CategoryName);

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
          
        }

       
    }
}
