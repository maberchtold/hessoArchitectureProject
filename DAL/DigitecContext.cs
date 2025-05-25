using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DigitecContext : DbContext
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Item> Items { get; set; }

        public DigitecContext(DbContextOptions<DigitecContext> options) : base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DigitecDB")
            builder.UseSeeding((context, _) =>
                {
                    //Employees
                    var emp1 = new Employee() { Firstname = "Tom", Lastname = "Simon", Age = 40, YearsOfService = 10, StartDate = new DateTime(2013, 1, 1), Salary = 4500 };
                    var employee = context.Set<Employee>().FirstOrDefault(t => t.Firstname == "Tom" && t.Lastname == "Simon");
                    if (employee == null)
                    {
                        context.Set<Employee>().Add(emp1);
                        context.SaveChanges();
                    }

                    var emp2 = new Employee() { Firstname = "Anny", Lastname = "Bing", Age = 20, YearsOfService = 3, StartDate = new DateTime(2020, 1, 1), Salary = 2500 };
                    employee = context.Set<Employee>().FirstOrDefault(t => t.Firstname == "Anny" && t.Lastname == "Bing");
                    if (employee == null)
                    {
                        context.Set<Employee>().Add(emp2);
                        context.SaveChanges();
                    }

                    var emp3 = new Employee() { Firstname = "Tim", Lastname = "Burton", Age = 70, YearsOfService = 20, StartDate = new DateTime(2003, 1, 1), Salary = 10500 };
                    employee = context.Set<Employee>().FirstOrDefault(t => t.Firstname == "Tim" && t.Lastname == "Burton");
                    if (employee == null)
                    {
                        context.Set<Employee>().Add(emp3);
                        context.SaveChanges();
                    }

                    //Customers
                    var cust1 = new Customer() { Firstname = "Alain", Lastname = "Duc", ShoppingAddress = "Route Principale 10, 3960 Sierre" };
                    var customer = context.Set<Customer>().FirstOrDefault(c => c.Firstname == "Alain" && c.Lastname == "Duc");
                    if (customer == null)
                    {
                        context.Set<Customer>().Add(cust1);
                        context.SaveChanges();
                    }

                    var cust2 = new Customer() { Firstname = "Antoine", Lastname = "Widmer", ShoppingAddress = "Ruelle du Chateau 2, 1920 Martigny" };
                    customer = context.Set<Customer>().FirstOrDefault(c => c.Firstname == "Antoine" && c.Lastname == "Widmer");
                    if (customer == null)
                    {
                        context.Set<Customer>().Add(cust2);
                        context.SaveChanges();
                    }

                    var cust3 = new Customer() { Firstname = "John", Lastname = "Doe", ShoppingAddress = "Bahnhofstrasse 30, 3900 Brig" };
                    customer = context.Set<Customer>().FirstOrDefault(c => c.Firstname == "John" && c.Lastname == "Doe");
                    if (customer == null)
                    {
                        context.Set<Customer>().Add(cust3);
                        context.SaveChanges();
                    }

                    //Items
                    var item1 = new Item() { Name = "HIFI", Description = "blabla", Price = 89.9f, Employee = emp1 };
                    var item = context.Set<Item>().FirstOrDefault(i => i.Name == "HIFI" && i.Description == "blabla");
                    if (item == null)
                    {
                        context.Set<Item>().Add(item1);
                        context.SaveChanges();
                    }

                    var item2 = new Item() { Name = "HIFI1", Description = "blabla", Price = 189.9f, Employee = emp1 };
                    item = context.Set<Item>().FirstOrDefault(i => i.Name == "HIFI1" && i.Description == "blabla");
                    if (item == null)
                    {
                        context.Set<Item>().Add(item2);
                        context.SaveChanges();
                    }

                    var item3 = new Item() { Name = "HIFI2", Description = "blabla", Price = 79.9f, Employee = emp1 };
                    item = context.Set<Item>().FirstOrDefault(i => i.Name == "HIFI2" && i.Description == "blabla");
                    if (item == null)
                    {
                        context.Set<Item>().Add(item3);
                        context.SaveChanges();
                    }

                    var item4 = new Item() { Name = "HIFI3", Description = "blabla", Price = 19.9f, Employee = emp3 };
                    item = context.Set<Item>().FirstOrDefault(i => i.Name == "HIFI3" && i.Description == "blabla");
                    if (item == null)
                    {
                        context.Set<Item>().Add(item4);
                        context.SaveChanges();
                    }

                    //Carts
                    var cart11 = new Cart() { ShoppingDate = new DateTime(2023, 1, 15), Customer = cust1 };
                    var cart = context.Set<Cart>().FirstOrDefault(c => c.ShoppingDate == new DateTime(2023, 1, 15) && c.CustomerId == 1);
                    if (cart == null)
                    {
                        context.Set<Cart>().Add(cart11);
                        context.SaveChanges();
                    }

                    var cart12 = new Cart() { ShoppingDate = new DateTime(2023, 2, 5), Customer = cust1 };
                    cart = context.Set<Cart>().FirstOrDefault(c => c.ShoppingDate == new DateTime(2023, 2, 5) && c.CustomerId == 1);
                    if (cart == null)
                    {
                        context.Set<Cart>().Add(cart12);
                        context.SaveChanges();
                    }

                    var cart21 = new Cart() { ShoppingDate = new DateTime(2022, 1, 15), Customer = cust2 };
                    cart = context.Set<Cart>().FirstOrDefault(c => c.ShoppingDate == new DateTime(2022, 1, 15) && c.CustomerId == 2);
                    if (cart == null)
                    {
                        context.Set<Cart>().Add(cart21);
                        context.SaveChanges();
                    }

                    var cart22 = new Cart() { ShoppingDate = new DateTime(2023, 2, 25), Customer = cust2 };
                    cart = context.Set<Cart>().FirstOrDefault(c => c.ShoppingDate == new DateTime(2023, 2, 25) && c.CustomerId == 2);
                    if (cart == null)
                    {
                        context.Set<Cart>().Add(cart22);
                        context.SaveChanges();
                    }

                    var cart23 = new Cart() { ShoppingDate = new DateTime(2023, 3, 1), Customer = cust2 };
                    cart = context.Set<Cart>().FirstOrDefault(c => c.ShoppingDate == new DateTime(2023, 3, 1) && c.CustomerId == 2);
                    if (cart == null)
                    {
                        context.Set<Cart>().Add(cart23);
                        context.SaveChanges();
                    }

                    var cart31 = new Cart() { ShoppingDate = new DateTime(2023, 1, 1), Customer = cust3 };
                    cart = context.Set<Cart>().FirstOrDefault(c => c.ShoppingDate == new DateTime(2023, 1, 1) && c.CustomerId == 3);
                    if (cart == null)
                    {
                        context.Set<Cart>().Add(cart31);
                        context.SaveChanges();
                    }

                    //CartItems
                    var cartItem1 = new CartItem() { Cart = cart11, Item = item1, Quantity = 1 };
                    var cartItem = context.Set<CartItem>().FirstOrDefault(ci => ci.CartId == 1 && ci.ItemId == 1 && ci.Quantity == 1);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem1);
                        context.SaveChanges();
                    }

                    var cartItem2 = new CartItem() { Cart = cart11, Item = item2, Quantity = 1 };
                    cartItem = context.Set<CartItem>().FirstOrDefault(ci => ci.CartId == 1 && ci.ItemId == 2 && ci.Quantity == 1);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem2);
                        context.SaveChanges();
                    }

                    var cartItem3 = new CartItem() { Cart = cart11, Item = item3, Quantity = 1 };
                    cartItem = context.Set<CartItem>().FirstOrDefault(ci => ci.CartId == 1 && ci.ItemId == 3 && ci.Quantity == 1);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem3);
                        context.SaveChanges();
                    }

                    var cartItem4 = new CartItem() { Cart = cart11, Item = item4, Quantity = 1 };
                    cartItem = context.Set<CartItem>().FirstOrDefault(ci => ci.CartId == 1 && ci.ItemId == 4 && ci.Quantity == 1);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem4);
                        context.SaveChanges();
                    }

                    var cartItem5 = new CartItem() { Cart = cart12, Item = item2, Quantity = 2 };
                    cartItem = context.Set<CartItem>().FirstOrDefault(ci => ci.CartId == 2 && ci.ItemId == 2 && ci.Quantity == 2);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem5);
                        context.SaveChanges();
                    }

                    var cartItem6 = new CartItem() { Cart = cart21, Item = item1, Quantity = 2 };
                    cartItem = context.Set<CartItem>().FirstOrDefault(ci => ci.CartId == 3 && ci.ItemId == 1 && ci.Quantity == 2);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem6);
                        context.SaveChanges();
                    }

                    var cartItem7 = new CartItem() { Cart = cart21, Item = item4, Quantity = 3 };
                    cartItem = context.Set<CartItem>().FirstOrDefault(ci => ci.CartId == 3 && ci.ItemId == 4 && ci.Quantity == 3);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem7);
                        context.SaveChanges();
                    }

                    var cartItem8 = new CartItem() { Cart = cart22, Item = item1, Quantity = 1 };
                    cartItem = context.Set<CartItem>().FirstOrDefault(ci => ci.CartId == 4 && ci.ItemId == 1 && ci.Quantity == 1);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem8);
                        context.SaveChanges();
                    }

                    var cartItem9 = new CartItem() { Cart = cart23, Item = item3, Quantity = 4 };
                    cartItem = context.Set<CartItem>().FirstOrDefault(ci => ci.CartId == 5 && ci.ItemId == 3 && ci.Quantity == 4);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem9);
                        context.SaveChanges();
                    }

                    var cartItem10 = new CartItem() { Cart = cart31, Item = item3, Quantity = 4 };
                    cartItem = context.Set<CartItem>().FirstOrDefault(ci => ci.CartId == 6 && ci.ItemId == 3 && ci.Quantity == 4);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem10);
                        context.SaveChanges();
                    }
                })
                .UseAsyncSeeding(async (context, _, cancellationToken) =>
                {
                    //Employees
                    var emp1 = new Employee() { Firstname = "Tom", Lastname = "Simon", Age = 40, YearsOfService = 10, StartDate = new DateTime(2013, 1, 1), Salary = 4500 };
                    var employee = await context.Set<Employee>().FirstOrDefaultAsync(t => t.Firstname == "Tom" && t.Lastname == "Simon");
                    if (employee == null)
                    {
                        context.Set<Employee>().Add(emp1);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var emp2 = new Employee() { Firstname = "Anny", Lastname = "Bing", Age = 20, YearsOfService = 3, StartDate = new DateTime(2020, 1, 1), Salary = 2500 };
                    employee = await context.Set<Employee>().FirstOrDefaultAsync(t => t.Firstname == "Anny" && t.Lastname == "Bing", cancellationToken);
                    if (employee == null)
                    {
                        context.Set<Employee>().Add(emp2);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var emp3 = new Employee() { Firstname = "Tim", Lastname = "Burton", Age = 70, YearsOfService = 20, StartDate = new DateTime(2003, 1, 1), Salary = 10500 };
                    employee = await context.Set<Employee>().FirstOrDefaultAsync(t => t.Firstname == "Tim" && t.Lastname == "Burton", cancellationToken);
                    if (employee == null)
                    {
                        context.Set<Employee>().Add(emp3);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    //Customers
                    var cust1 = new Customer() { Firstname = "Alain", Lastname = "Duc", ShoppingAddress = "Route Principale 10, 3960 Sierre" };
                    var customer = await context.Set<Customer>().FirstOrDefaultAsync(c => c.Firstname == "Alain" && c.Lastname == "Duc", cancellationToken);
                    if (customer == null)
                    {
                        context.Set<Customer>().Add(cust1);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var cust2 = new Customer() { Firstname = "Antoine", Lastname = "Widmer", ShoppingAddress = "Ruelle du Chateau 2, 1920 Martigny" };
                    customer = await context.Set<Customer>().FirstOrDefaultAsync(c => c.Firstname == "Antoine" && c.Lastname == "Widmer", cancellationToken);
                    if (customer == null)
                    {
                        context.Set<Customer>().Add(cust2);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var cust3 = new Customer() { Firstname = "John", Lastname = "Doe", ShoppingAddress = "Bahnhofstrasse 30, 3900 Brig" };
                    customer = await context.Set<Customer>().FirstOrDefaultAsync(c => c.Firstname == "John" && c.Lastname == "Doe", cancellationToken);
                    if (customer == null)
                    {
                        context.Set<Customer>().Add(cust3);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    //Items
                    var item1 = new Item() { Name = "HIFI", Description = "blabla", Price = 89.9f, Employee = emp1 };
                    var item = await context.Set<Item>().FirstOrDefaultAsync(i => i.Name == "HIFI" && i.Description == "blabla", cancellationToken);
                    if (item == null)
                    {
                        context.Set<Item>().Add(item1);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var item2 = new Item() { Name = "HIFI1", Description = "blabla", Price = 189.9f, Employee = emp1 };
                    item = await context.Set<Item>().FirstOrDefaultAsync(i => i.Name == "HIFI1" && i.Description == "blabla", cancellationToken);
                    if (item == null)
                    {
                        context.Set<Item>().Add(item2);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var item3 = new Item() { Name = "HIFI2", Description = "blabla", Price = 79.9f, Employee = emp1 };
                    item = await context.Set<Item>().FirstOrDefaultAsync(i => i.Name == "HIFI2" && i.Description == "blabla", cancellationToken);
                    if (item == null)
                    {
                        context.Set<Item>().Add(item3);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var item4 = new Item() { Name = "HIFI3", Description = "blabla", Price = 19.9f, Employee = emp3 };
                    item = await context.Set<Item>().FirstOrDefaultAsync(i => i.Name == "HIFI3" && i.Description == "blabla", cancellationToken);
                    if (item == null)
                    {
                        context.Set<Item>().Add(item4);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    //Carts
                    var cart11 = new Cart() { ShoppingDate = new DateTime(2023, 1, 15), Customer = cust1 };
                    var cart = await context.Set<Cart>().FirstOrDefaultAsync(c => c.ShoppingDate == new DateTime(2023, 1, 15) && c.CustomerId == 1, cancellationToken);
                    if (cart == null)
                    {
                        context.Set<Cart>().Add(cart11);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var cart12 = new Cart() { ShoppingDate = new DateTime(2023, 2, 5), Customer = cust1 };
                    cart = await context.Set<Cart>().FirstOrDefaultAsync(c => c.ShoppingDate == new DateTime(2023, 2, 5) && c.CustomerId == 1, cancellationToken);
                    if (cart == null)
                    {
                        context.Set<Cart>().Add(cart12);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var cart21 = new Cart() { ShoppingDate = new DateTime(2022, 1, 15), Customer = cust2 };
                    cart = await context.Set<Cart>().FirstOrDefaultAsync(c => c.ShoppingDate == new DateTime(2022, 1, 15) && c.CustomerId == 2, cancellationToken);
                    if (cart == null)
                    {
                        context.Set<Cart>().Add(cart21);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var cart22 = new Cart() { ShoppingDate = new DateTime(2023, 2, 25), Customer = cust2 };
                    cart = await context.Set<Cart>().FirstOrDefaultAsync(c => c.ShoppingDate == new DateTime(2023, 2, 25) && c.CustomerId == 2, cancellationToken);
                    if (cart == null)
                    {
                        context.Set<Cart>().Add(cart22);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var cart23 = new Cart() { ShoppingDate = new DateTime(2023, 3, 1), Customer = cust2 };
                    cart = await context.Set<Cart>().FirstOrDefaultAsync(c => c.ShoppingDate == new DateTime(2023, 3, 1) && c.CustomerId == 2, cancellationToken);
                    if (cart == null)
                    {
                        context.Set<Cart>().Add(cart23);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var cart31 = new Cart() { ShoppingDate = new DateTime(2023, 1, 1), Customer = cust3 };
                    cart = await context.Set<Cart>().FirstOrDefaultAsync(c => c.ShoppingDate == new DateTime(2023, 1, 1) && c.CustomerId == 3, cancellationToken);
                    if (cart == null)
                    {
                        context.Set<Cart>().Add(cart31);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    //CartItems
                    var cartItem1 = new CartItem() { Cart = cart11, Item = item1, Quantity = 1 };
                    var cartItem = await context.Set<CartItem>().FirstOrDefaultAsync(ci => ci.CartId == 1 && ci.ItemId == 1 && ci.Quantity == 1, cancellationToken);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem1);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var cartItem2 = new CartItem() { Cart = cart11, Item = item2, Quantity = 1 };
                    cartItem = await context.Set<CartItem>().FirstOrDefaultAsync(ci => ci.CartId == 1 && ci.ItemId == 2 && ci.Quantity == 1, cancellationToken);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem2);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var cartItem3 = new CartItem() { Cart = cart11, Item = item3, Quantity = 1 };
                    cartItem = await context.Set<CartItem>().FirstOrDefaultAsync(ci => ci.CartId == 1 && ci.ItemId == 3 && ci.Quantity == 1, cancellationToken);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem3);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var cartItem4 = new CartItem() { Cart = cart11, Item = item4, Quantity = 1 };
                    cartItem = await context.Set<CartItem>().FirstOrDefaultAsync(ci => ci.CartId == 1 && ci.ItemId == 4 && ci.Quantity == 1, cancellationToken);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem4);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var cartItem5 = new CartItem() { Cart = cart12, Item = item2, Quantity = 2 };
                    cartItem = await context.Set<CartItem>().FirstOrDefaultAsync(ci => ci.CartId == 2 && ci.ItemId == 2 && ci.Quantity == 2, cancellationToken);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem5);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var cartItem6 = new CartItem() { Cart = cart21, Item = item1, Quantity = 2 };
                    cartItem = await context.Set<CartItem>().FirstOrDefaultAsync(ci => ci.CartId == 3 && ci.ItemId == 1 && ci.Quantity == 2, cancellationToken);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem6);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var cartItem7 = new CartItem() { Cart = cart21, Item = item4, Quantity = 3 };
                    cartItem = await context.Set<CartItem>().FirstOrDefaultAsync(ci => ci.CartId == 3 && ci.ItemId == 4 && ci.Quantity == 3, cancellationToken);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem7);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var cartItem8 = new CartItem() { Cart = cart22, Item = item1, Quantity = 1 };
                    cartItem = await context.Set<CartItem>().FirstOrDefaultAsync(ci => ci.CartId == 4 && ci.ItemId == 1 && ci.Quantity == 1, cancellationToken);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem8);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var cartItem9 = new CartItem() { Cart = cart23, Item = item3, Quantity = 4 };
                    cartItem = await context.Set<CartItem>().FirstOrDefaultAsync(ci => ci.CartId == 5 && ci.ItemId == 3 && ci.Quantity == 4, cancellationToken);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem9);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    var cartItem10 = new CartItem() { Cart = cart31, Item = item3, Quantity = 4 };
                    cartItem = await context.Set<CartItem>().FirstOrDefaultAsync(ci => ci.CartId == 6 && ci.ItemId == 3 && ci.Quantity == 4, cancellationToken);
                    if (cartItem == null)
                    {
                        context.Set<CartItem>().Add(cartItem10);
                        await context.SaveChangesAsync(cancellationToken);
                    }
                });
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many
            modelBuilder.Entity<Cart>()
                .HasMany(e => e.Items)
                .WithMany(e => e.Carts)
                .UsingEntity<CartItem>();
        }
    }
}
