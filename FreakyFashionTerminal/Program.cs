using FreakyFashionTerminal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace FreakyFashionTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
            Meny:;
                Clear();
                WriteLine("1. Products");
                WriteLine("2. Categories");
                WriteLine("3. Orders");
                WriteLine("4. Exit");

                ConsoleKeyInfo keypress = Console.ReadKey(true);
                switch (keypress.Key)
                {
                    // start Product
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                    productMeny:
                        Clear();
                        WriteLine("1. List Products");
                        WriteLine("2. Add Product");
                        WriteLine("3. Delete Product");
                        keypress = Console.ReadKey(true);
                        switch (keypress.Key)
                        {

                            // start list Product

                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                            product:
                                Clear();
                                List<Product> products = Products.Get();
                                WriteLine("ID | Name");
                                WriteLine("-------------------------------------------------------------------------------------");
                                if (products.Count != 0)
                                {
                                    foreach (var product in products)
                                    {
                                        WriteLine(product.Id + "|" + product.Name);
                                    }
                                }
                                else
                                {
                                    WriteLine("products is null");
                                }
                                Write("(V)iew");
                                keypress = Console.ReadKey(true);
                                switch (keypress.Key)
                                {
                                    case ConsoleKey.V:
                                        Clear();
                                        WriteLine("ID | Name");
                                        WriteLine("-------------------------------------------------------------------------------------");
                                        if (products.Count != 0)
                                        {
                                            foreach (var _product in products)
                                            {
                                                WriteLine(_product.Id + "|" + _product.Name);
                                            }
                                        }
                                        else
                                        {
                                            WriteLine("products is null");
                                        }
                                        Write("View(ID) :");
                                        var num = Console.ReadLine();
                                        var id = Convert.ToInt32(num);
                                        Product product = Products.Get(id);
                                        if (product != null)
                                        {
                                            Clear();
                                            WriteLine("ID:" + product.Id);
                                            WriteLine("Name:" + product.Name);
                                            WriteLine("Description:" + product.Description);
                                            WriteLine("Price:" + product.Price);
                                        }
                                        else
                                        {
                                            Write("Product Not Found");
                                        }


                                        keypress = ReadKey(true);
                                        if (keypress.Key == ConsoleKey.Escape)
                                        {
                                            goto product;
                                        }
                                        break;

                                    case ConsoleKey.Escape:
                                        goto productMeny;



                                }


                                break;

                            case ConsoleKey.D2:

                            AddProduct:
                                Clear();
                                Write("Product Name :");
                                var ProductName = ReadLine();
                                Write("Product Description :");
                                var ProductDescription = ReadLine();
                                Write("Product Numebr :");
                                var ProductNumebr = ReadLine();
                                Write("Product Image :");
                                var ProductImage = ReadLine();
                                Write("Product Price :");
                                var ProductPrice = Int32.Parse(ReadLine());

                                var productUrlSlug = ProductName.Replace(" ", "-");
                                var NewProduct = new Product
                                {
                                    Name = ProductName,
                                    Description = ProductDescription,
                                    Price = ProductPrice,
                                    ImageUrl = ProductImage,
                                    ProductNumber = ProductNumebr,
                                    UrlSlug = productUrlSlug
                                };

                                WriteLine("Add Or Not: (Y or N) :");

                                var add = ReadKey(true);
                                switch (add.Key)
                                {
                                    case ConsoleKey.Y:
                                        if (NewProduct != null)
                                        {
                                            Products.Post(NewProduct);
                                            WriteLine("Product added");
                                            Thread.Sleep(2000);
                                            goto productMeny;


                                        }
                                        else
                                        {
                                            WriteLine("Product is null i cant added");
                                        }

                                        break;
                                    case ConsoleKey.N:
                                        goto AddProduct;

                                    case ConsoleKey.Escape:
                                        goto productMeny;

                                    default:
                                        break;
                                }
                                break;

                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                Clear();
                                List<Product> _products = Products.Get();
                                WriteLine("   ID               | Name");
                                WriteLine("-------------------------------------------------------------------------------------");
                                if (_products.Count != 0)
                                {
                                    foreach (var product in _products)
                                    {
                                        WriteLine("   " + product.Id + "               " + product.Name);
                                    }
                                }
                                else
                                {
                                    WriteLine("products is null");
                                }
                                Write("Enter Product  ID :");
                                var _id = Int32.Parse(ReadLine());
                                if (_products.Any(x => x.Id == _id))
                                {
                                    Clear();
                                    Products.Delete(_id);
                                    WriteLine("Product which has Id = " + _id + " has been deleted");
                                    Thread.Sleep(4000);
                                    goto productMeny;
                                }
                                else
                                {
                                    Clear();
                                    WriteLine("choose a Right Id");
                                    Thread.Sleep(2000);
                                    goto productMeny;
                                }

                            case ConsoleKey.Escape:
                                goto Meny;
                        }

                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                    Category:;
                        Clear();
                        List<Category> categories = Categories.Get();
                        WriteLine("ID | Name");
                        WriteLine("-------------------------------------------------------------------------------------");
                        if (categories.Count != 0)
                        {
                            foreach (var category in categories)
                            {
                                WriteLine(category.Id + "|" + category.Name);
                            }
                        }
                        else
                        {
                            WriteLine("Categories is null");
                        }
                        Write("(V)iew");
                        keypress = Console.ReadKey(true);
                        switch (keypress.Key)
                        {
                            case ConsoleKey.V:
                                Clear();
                                WriteLine("ID | Name");
                                WriteLine("-------------------------------------------------------------------------------------");
                                if (categories.Count != 0)
                                {
                                    foreach (var _category in categories)
                                    {
                                        WriteLine(_category.Id + "|" + _category.Name);
                                    }
                                }
                                else
                                {
                                    WriteLine("Categories is null");
                                }
                                Write("View(ID) :");
                                var num = Console.ReadLine();
                                var id = Convert.ToInt32(num);
                                Category category = Categories.Get(id);
                                if (category != null)
                                {
                                    Clear();
                                    WriteLine("ID:" + category.Id);
                                    WriteLine("Name:" + category.Name);
                                    WriteLine("Image URL:" + category.ImgUrl);
                                    Thread.Sleep(2000);
                                    goto Category;

                                }
                                else
                                {
                                    Clear();
                                    Write("Category Not Found");
                                    Thread.Sleep(2000);
                                    goto Category;
                                }

                            case ConsoleKey.Escape:
                                goto Meny;



                        }


                        break;


                    // order
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                    order:
                        Clear();
                        List<Order> orders = Orders.Get();
                        WriteLine("ID | Totalt Price");
                        WriteLine("-------------------------------------------------------------------------------------");
                        if (orders.Count != 0)
                        {
                            foreach (var order in orders)
                            {
                                WriteLine(order.Id + "|" + order.Totalt);
                            }
                        }
                        else
                        {
                            WriteLine("Orders is null");
                        }
                        Write("(V)iew");
                        keypress = Console.ReadKey(true);
                        switch (keypress.Key)
                        {
                            case ConsoleKey.V:
                                Clear();
                                WriteLine("ID | Totalt Price");
                                WriteLine("-------------------------------------------------------------------------------------");
                                if (orders.Count != 0)
                                {
                                    foreach (var _order in orders)
                                    {
                                        WriteLine(_order.Id + "|" + _order.Totalt);
                                    }
                                }
                                else
                                {
                                    WriteLine("orders is null");
                                }
                                Write("View(ID) :");
                                var num = Console.ReadLine();
                                var id = Convert.ToInt32(num);
                                Order order = Orders.Get(id);
                                if (order != null)
                                {
                                    Clear();
                                    WriteLine("ID:" + order.Id);
                                    WriteLine("Totalt Pric:" + order.Totalt);
                                    Thread.Sleep(2000);
                                    goto order;


                                }
                                else
                                {
                                    Clear();
                                    Write("Order Not Found");
                                    Thread.Sleep(2000);
                                    goto order;
                                }


                            case ConsoleKey.Escape:
                                goto Meny;

                        }


                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Clear();
                        Write("Good Bye...........");
                        Thread.Sleep(1000);
                        running = true;
                        break;

                }
                break;

            }
        }
    }



    class Products
    {
        readonly static HttpClient client = new HttpClient();

        public static List<Product> Get()
        {
            string endPoint = "https://localhost:5001/api/product";
            var Jsondata = client.GetAsync(endPoint).Result;
            if (Jsondata.IsSuccessStatusCode)
            {
                var data = Jsondata.Content.ReadAsStringAsync().Result;
                var Products = JsonConvert.DeserializeObject<List<Product>>(data);

                return Products;
            }
            return null;

        }
        public static Product Get(int id)
        {
            string endPoint = $"https://localhost:5001/api/product/{id}";
            var Jsondata = client.GetStringAsync(endPoint).GetAwaiter().GetResult();
            var Product = JsonConvert.DeserializeObject<Product>(Jsondata);
            return Product;
        }
        public static void Post(Product NewProduct)
        {
            string endPoint = "https://localhost:5001/api/product";
            var pro = JsonConvert.SerializeObject(NewProduct);
            var content = new StringContent(pro, Encoding.UTF8, "application/json");
            var result = client.PostAsync(endPoint, content).Result;

        }
        public static void Delete(int id)
        {
            string endPoint = $"https://localhost:5001/api/product/{id}";
            var result = client.DeleteAsync(endPoint).Result;

        }
        public static void Put(int id)
        {
            string endPoint = $"https://localhost:5001/api/product/{id}";
            var product = client.GetAsync(endPoint).GetAwaiter().GetResult();
            var jsonData = JsonConvert.SerializeObject(product);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "appplication/json");
            var result = client.PutAsync(endPoint, content).Result;

        }


    }

    class Categories
    {
        readonly static HttpClient client = new HttpClient();

        public static List<Category> Get()
        {
            string endPoint = "https://localhost:5001/api/category";
            var Jsondata = client.GetStringAsync(endPoint).GetAwaiter().GetResult();
            var Categories = JsonConvert.DeserializeObject<List<Category>>(Jsondata);
            return Categories;
        }
        public static Category Get(int id)
        {
            string endPoint = $"https://localhost:5001/api/Category/{id}";
            var Jsondata = client.GetStringAsync(endPoint).GetAwaiter().GetResult();
            var Category = JsonConvert.DeserializeObject<Category>(Jsondata);
            return Category;
        }

    }

    class Orders
    {
        readonly static HttpClient client = new HttpClient();

        public static List<Order> Get()
        {
            string endPoint = "https://localhost:5001/api/Order";
            var Jsondata = client.GetStringAsync(endPoint).GetAwaiter().GetResult();
            var orders = JsonConvert.DeserializeObject<List<Order>>(Jsondata);
            return orders;
        }
        public static Order Get(int id)
        {
            string endPoint = $"https://localhost:5001/api/Order/{id}";
            var Jsondata = client.GetStringAsync(endPoint).GetAwaiter().GetResult();
            var order = JsonConvert.DeserializeObject<Order>(Jsondata);
            return order;
        }

    }

}