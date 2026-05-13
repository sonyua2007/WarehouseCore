using System;
using System.Collections.Generic;
using WarehouseCore;
public class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        Warehouse myWarehouse = new Warehouse();

        Category elect = new Category(1, "Електроніка");
        Product iphone = new Product(101, "IPhone13", "Apple", 25000, 10);
        Product samsung = new Product(102, "Samsung Galaxy S23", "Samsung", 22500, 6);
        elect.AddProduct(iphone);
        elect.AddProduct(samsung);
        myWarehouse.AddCategory(elect);

        Category clothes = new Category(2, "Одяг");
        Product shirt = new Product(103, "Рубашка", "H&M", 1500, 46);
        Product skirt = new Product(104, "Спідниця", "Papaya", 900, 32);
        clothes.AddProduct(shirt);
        clothes.AddProduct(skirt);
        myWarehouse.AddCategory(clothes);

        Supplier germanSupplier = new Supplier(201, "Парам", "Пампам", "Apple Inc");
        Supplier ukrainianSupplier = new Supplier(202, "Пум", "Пурум", "H&M Inc");
        myWarehouse.AddSupplier(germanSupplier);
        myWarehouse.AddSupplier(ukrainianSupplier);

        Customer customer1 = new Customer(301, "Блаблабла", "Блеблебле", "Шевченка 3", "+380 95 123 4567");
        Customer customer2 = new Customer(302, "Мда", "Агага", "Воскресенка 15/2", "+380 12 34 5678");
        myWarehouse.AddCustomer(customer1);
        myWarehouse.AddCustomer(customer2);

        Console.WriteLine("--- Склад ---");
        foreach (Category cat in myWarehouse.Categories)
        {
            Console.WriteLine($"\n[Категорія]: {cat.Name} (ID: {cat.ID})");
            foreach (Product p in cat.Products)
            {
                Console.WriteLine($" - {p}");
            }
        }

        Console.WriteLine("\nПостачальники");
        foreach (Supplier s in myWarehouse.Suppliers)
        {
            Console.WriteLine($" - {s.GetDetails()}");
        }

        Console.WriteLine("\nЗамовники");
        foreach (Customer c in myWarehouse.Customers)
        {
            Console.WriteLine($" - {c.GetDetails()}");
        }

        ///<summary>
        ///пункт 1
        ///</summary>

        Console.WriteLine("\n--- 1.1 Додавання нової категорії ---");
        Category tempCategory = new Category(3, "Канцелярія");
        Product tempProduct = new Product(105, "Олівець", "NoName", 25, 4);
        tempCategory.AddProduct(tempProduct);
        myWarehouse.AddCategory(tempCategory);
        Console.WriteLine($"Категорію '{tempCategory.Name}' додано до складу.");
        Console.WriteLine("Товари");
        foreach (Product pro in tempCategory.Products)
        {
            Console.WriteLine($" - {pro.ToString()}");
        }

        Console.WriteLine("\n--- 1.3 Зміна даних категорії ---");
        Console.WriteLine($"Стара назва: {elect.Name}");
        elect.Name = "Преміум Електроніка";
        Console.WriteLine($"Нова назва: {elect.Name}");

        Console.WriteLine("\n--- 1.4 Перегляд конкретної категорії ---");
        Console.WriteLine($"Категорія ID: {clothes.ID}, Назва: {clothes.Name}, Кількість товарів: {clothes.Products.Count}");

        Console.WriteLine("\n--- 1.5 Перегляд списку всіх категорій ---");
        foreach (Category cat in myWarehouse.Categories)
        {
            Console.WriteLine($" - [{cat.ID}] {cat.Name} (Товарів: {cat.Products.Count})");
        }

        Console.WriteLine("\n--- 1.2 Видалення категорії ---");
        myWarehouse.RemoveCategory(tempCategory);
        Console.WriteLine($"Категорію '{tempCategory.Name}' було видалено зі складу.");

        Console.WriteLine("\nСписок категорій після видалення:");
        foreach (Category cat in myWarehouse.Categories)
        {
            Console.WriteLine($" - {cat.Name}");
        }

        ///<summary>
        ///пункт 2
        ///</summary>

        Console.WriteLine("\n--- 2.1 Додавання товару в категорію ---");
        Product newProduct = new Product(105, "AirPods Pro", "Apple", 10000, 15);
        elect.AddProduct(newProduct);
        Console.WriteLine($"Товар '{newProduct.Name}' успішно додано в категорію '{elect.Name}'.");
        Console.WriteLine("\nТовари категорії");
        foreach (Product p in elect.Products)
        {
            Console.WriteLine($" - {p}");
        }

        Console.WriteLine("\n--- 2.3 Зміна даних товару ---");
        Console.WriteLine($"До зміни: {shirt.Name}, Бренд: {shirt.Brand}, Ціна: {shirt.Price} грн");
        shirt.Name = "Сорочка";
        shirt.Price = 1650;
        Console.WriteLine($"Після зміни: {shirt.Name}, Бренд: {shirt.Brand}, Ціна: {shirt.Price} грн");

        Console.WriteLine("\n--- 2.4 Зміна кількості товару на складі ---");
        Console.WriteLine($"Залишок '{samsung.Name}' до постачання: {samsung.Quantity} шт.");
        samsung.Quantity += 20;
        Console.WriteLine($"Залишок '{samsung.Name}' після постачання: {samsung.Quantity} шт.");

        Console.WriteLine("\n--- 2.5 Перегляд даних конкретного товару ---");
        Console.WriteLine(iphone);

        Console.WriteLine("\n--- 2.2 Видалення товару з категорії ---");
        elect.RemoveProduct(newProduct);
        Console.WriteLine($"Товар '{newProduct.Name}' видалено з полиці '{elect.Name}'.");
        Console.WriteLine("\nТовари категорії після видалення");
        foreach (Product p in elect.Products)
        {
            Console.WriteLine($" - {p}");
        }

        Console.WriteLine("\n--- 2.6 Перегляд списку всіх товарів ---");
        List<Product> allProd = myWarehouse.GetAllProducts();
        foreach (Product p in allProd)
        {
            Console.WriteLine($" - {p}");
        }

        Console.WriteLine("\n--- 2.6.1 Сортування товарів за назвою ---");
        List<Product> sortedByName = ProductService.SortByName(myWarehouse.GetAllProducts());
        foreach (Product p in sortedByName)
        {
            Console.WriteLine($" - {p}");
        }

        Console.WriteLine("\n--- 2.6.2 Сортування товарів за брендом ---");
        List<Product> sortedByBrand = ProductService.SortByBrand(myWarehouse.GetAllProducts());
        foreach (Product p in sortedByBrand)
        {
            Console.WriteLine($" - {p}");
        }

        Console.WriteLine("\n--- 2.6.3 Сортування товарів за ціною ---");
        List<Product> sortedByPrice = ProductService.SortByPrice(myWarehouse.GetAllProducts());
        foreach (Product p in sortedByPrice)
        {
            Console.WriteLine($" - {p}");
        }

        ///<summary>
        ///пункт 3
        ///</summary>

        Console.WriteLine("\n--- 3.1 Додавання постачальника ---");
        Supplier tempSupplier = new Supplier(203, "Міме", "Мамому", "Music Inc");
        myWarehouse.AddSupplier(tempSupplier);
        Console.WriteLine($"Додано: {tempSupplier.GetDetails()}");

        Console.WriteLine("\n--- 3.3 Зміна даних постачальника ---");
        Console.WriteLine($"До: {germanSupplier.GetDetails()}");
        germanSupplier.CompanyName = "Apple & Banana";
        Console.WriteLine($"Після: {germanSupplier.GetDetails()}");

        Console.WriteLine("\n--- 3.4 Перегляд даних конкретного постачальника ---");
        Console.WriteLine(ukrainianSupplier.GetDetails());

        Console.WriteLine("\n--- 3.2 Видалення постачальника ---");
        myWarehouse.RemoveSupplier(tempSupplier);
        Console.WriteLine($"Постачальника '{tempSupplier.LastName}' успішно видалено з бази.");

        Console.WriteLine("\n--- 3.5 Список усіх активних постачальників ---");
        foreach (Supplier s in myWarehouse.Suppliers)
        {
            Console.WriteLine($" - {s.GetDetails()}");
        }

        Console.WriteLine("\n--- 3.5.1 Сортування постачальників за іменем ---");
        List<Supplier> suppliersByName = PartnerService.SortSuppliersByFirstName(myWarehouse.Suppliers);
        foreach (Supplier s in suppliersByName)
        {
            Console.WriteLine($" - {s.GetDetails()}");
        }

        Console.WriteLine("\n--- 3.5.2 Сортування постачальників за прізвищем ---");
        List<Supplier> suppliersByLastName = PartnerService.SortSuppliersByLastName(myWarehouse.Suppliers);
        foreach (Supplier s in suppliersByLastName)
        {
            Console.WriteLine($" - {s.GetDetails()}");
        }

        ///<summary>
        ///пункт 4
        ///</summary>

        string productQuery = "Galaxy";
        Console.WriteLine($"\n--- 4.1 Пошук серед товарів за словом '{productQuery}' ---");
        List<Product> foundProducts = ProductService.Search(myWarehouse.GetAllProducts(), productQuery);
        if (foundProducts.Count > 0)
        {
            foreach (Product p in foundProducts)
            {
                Console.WriteLine($"Знайдено: {p}");
            }
        }
        else
        {
            Console.WriteLine("Товарів за цим запитом не знайдено.");
        }

        string customerQuery = "Бла";
        Console.WriteLine($"\n--- 4.2 Пошук серед замовників за фрагментом '{customerQuery}' ---");
        List<Customer> foundCustomers = PartnerService.SearchCustomers(myWarehouse.Customers, customerQuery);
        if (foundCustomers.Count > 0)
        {
            foreach (Customer c in foundCustomers)
            {
                Console.WriteLine($"Знайдено замовника: {c.GetDetails()}");
            }
        }
        else
        {
            Console.WriteLine("Замовників за цим запитом не знайдено.");
        }
    }
}