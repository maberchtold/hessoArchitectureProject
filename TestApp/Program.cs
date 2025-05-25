using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new DigitecContext();
            var created = context.Database.EnsureCreated();
            
            // Test basic queries
            //testBasicQueries();

            // Exercise 1
            //displayCustomerByCustomerId();
            //displayCustomerByLastname();
            //displayAllCustomers();
            //displayGroupItemsByEmployeeId();
            //displayOrderByShoppingDateDescending();

            // Exercise 2
            //displayItemsWithRelationships();

            // Exercise 3
            //displayCustomersWhoOrderedHIFIItem();
            //exercise3aByHand();
            //displayCustomerShoppingAddress();
            //exercise3bByHand();

            // Exercise 4
            //displayAveragePriceOfCart();
            //exercise4ByHand();

            Console.WriteLine("Done!");
        }
        private static void testBasicQueries()
        {
            using var context = new DigitecContext();

            // Get Tim Burton Employee
            var employee = context.Employees.FirstOrDefault(e => e.Firstname == "Tim" && e.Lastname == "Burton");
            Console.WriteLine($"Employee found : EmployeeId = {employee.EmployeeId}, Firstname = {employee.Firstname}, Lastname = {employee.Lastname}");

            // Update Tim Burton Employee
            employee.Firstname = "Tom";
            context.SaveChanges();            
            // Get Employee by his EmployeeId (new query)
            employee = context.Employees.Find(employee.EmployeeId);
            Console.WriteLine($"Employee found : EmployeeId = {employee.EmployeeId}, Firstname = {employee.Firstname}, Lastname = {employee.Lastname}");
            
            // Delete Employee
            context.Employees.Remove(employee);
            context.SaveChanges();
            // Try to get Employee by his EmployeeId
            employee = context.Employees.Find(employee.EmployeeId);
            if (employee == null)
            {
                Console.WriteLine($"Employee not found");
            }
        }
        private static void displayCustomerByCustomerId()
        {
            using var context = new DigitecContext();
            // Get customer by CustomerId
            var customer = context.Customers.Find(2);
            Console.WriteLine($"ID: {customer.CustomerId} Firstname: {customer.Firstname} Lastname: {customer.Firstname}");
        }

        private static void displayCustomerByLastname()
        {
            using var context = new DigitecContext();
            // Get customer by Lastname
            var customer = context.Customers.FirstOrDefault(c => c.Firstname == "Alain");
            if (customer == null)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                Console.WriteLine($"ID: {customer.CustomerId} Firstname: {customer.Firstname}");
            }
        }

        private static void displayAllCustomers()
        {
            using var context = new DigitecContext();
            // Get all customers with Lastname starting wih letter D
            var customers = context.Customers.Where(c => c.Lastname.StartsWith("D")).ToList();
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.CustomerId} Firstname: {customer.Firstname} Lastname: {customer.Firstname}");
            }
        }

        private static void displayGroupItemsByEmployeeId()
        {
            using var context = new DigitecContext();
            // Group items by EmployeeId
            var groups = context.Items.GroupBy(g => g.EmployeeId).ToList();
            foreach (var group in groups)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine($"ID: {item.ItemId} Name:{item.Name}");
                }
            }
        }
        private static void displayOrderByShoppingDateDescending()
        {
            using var context = new DigitecContext();
            // Display all carts for a customer ordered by shopping data descendant
            var carts = context.Carts.Where(c => c.CustomerId == 2).OrderByDescending(c => c.ShoppingDate);

            foreach (var cart in carts)
            {
                Console.WriteLine($"ID: {cart.CartId} ShoppingDate: {cart.ShoppingDate}");
            }
        }

        private static void displayItemsWithRelationships()
        {
            using var context = new DigitecContext();
            // Get all items inculding relationship to Employee
            var items = context.Items.Include(i => i.Employee).ToList();
            // Display items and employees info
            foreach (var item in items)
            {
                Console.WriteLine($"Name: {item.Name} Price: {item.Price} Firstname: {item.Employee.Firstname} Lastname: {item.Employee.Lastname}");
            }
        }

        private static void displayCustomersWhoOrderedHIFIItem()
        {
            using var context = new DigitecContext();
            // Get customers who ordered HIFI item 
            var customers = context.CartItems
                .Include(ci => ci.Cart).ThenInclude(c => c.Customer)
                .Where(ci => ci.Item.Name == "HIFI")
                .Select(ci => ci.Cart.Customer)
                .Distinct()
                .ToList();

            // Display customers
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.CustomerId} Firstname: {customer.Firstname} Lastname: {customer.Lastname} ShoppingAddress:{customer.ShoppingAddress}");
            }
        }

        private static void displayCustomerShoppingAddress()
        {
            using var context = new DigitecContext();
            // Get customers who ordered HIFI item, group by Cart and calculate sum of quantity, then calculate MAX 
            var result = context.CartItems
                .Include(ci => ci.Cart).ThenInclude(c => c.Customer)
                .Where(ci => ci.Item.Name == "HIFI")
                .GroupBy(ci => ci.Cart.Customer)
                .Select(ci => new
                {
                    Address = ci.Key.ShoppingAddress,
                    Total = ci.Sum(c => c.Quantity)
                })
                .ToList()
                .MaxBy(g => g.Total);

            // Display address
            Console.WriteLine($"ShoppingAddress: { result.Address }");
        }

        private static void displayAveragePriceOfCart()
        {
            using var context = new DigitecContext();
            // Get all carts, group by carts and calculate sum of Price*Quantity, then calcualte Average
            var cartAverage = context.CartItems
                .GroupBy(c => c.Cart)
                .Select(ci => new
                {
                    Calculated = ci.Sum(c => c.Item.Price * c.Quantity)
                })
                .Average(g => g.Calculated);

            // Display address
            Console.WriteLine($"Average price of cart: {cartAverage}");
        }

        private static void exercise3aByHand()
        {
            using var context = new DigitecContext();
            
            // Get all CartItems where Item's name was HIFI
            var cartItems = context.CartItems
                .Include(c => c.Cart).ThenInclude(cu => cu.Customer)
                .Where(i => i.Item.Name == "HIFI")
                .ToList();

            // Create a result list of Customers 
            var customers = new List<Customer>();

            // Loop over all CartItems
            foreach (var cartItem in cartItems)
            {
                // Get CustomerId related to that cartItem
                var id = cartItem.Cart.CustomerId;
                
                // If no Customer in result list has this CustomerId, then add customer in result list
                if (customers.Any(c => c.CustomerId == id) == false)
                {
                    customers.Add(cartItem.Cart.Customer);
                }
            }

            // Display customers
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.CustomerId} Firstname: {customer.Firstname} Lastname: {customer.Lastname} ShoppingAddress:{customer.ShoppingAddress}");
            }
        }

        private static void exercise3bByHand()
        {
            using var context = new DigitecContext();

            // Get all CartItems where Item's name was HIFI
            var cartItems = context.CartItems
                .Include(c => c.Cart).ThenInclude(cu => cu.Customer)
                .Where(i => i.Item.Name == "HIFI")
                .ToList();

            // Create two lists to store customers and their quantities
            var customers = new List<Customer>();
            var quantities = new List<int>();

            // Loop over all CartItems
            foreach (var cartItem in cartItems)
            {
                // Get CustomerId related to that cartItem
                var id = cartItem.Cart.CustomerId;

                // Get index of customer in the list of customers
                var index = customers.IndexOf(cartItem.Cart.Customer);

                // If customer is not in the list of customers
                if (index == -1)
                {
                    // Add customer in the list of customers
                    customers.Add(cartItem.Cart.Customer);
                    // Add quantity in the list of quantities
                    quantities.Add(cartItem.Quantity);
                }
                else
                {
                    // Update quantity in list
                    quantities[index] += cartItem.Quantity;
                }                
            }

            // Find max quantity
            var maxQuantity = quantities.Max();
            // Find index of max quantity
            var indexQuantity = quantities.IndexOf(maxQuantity);
            // Get Customer by index
            var customer = customers.ElementAt(indexQuantity);

            // Display address
            Console.WriteLine($"ShoppingAddress: {customer.ShoppingAddress}");
        }

        private static void exercise4ByHand()
        {
            using var context = new DigitecContext();

            // Get carts with relationships
            var carts = context.Carts.Include(c => c.CartItems).ThenInclude(i => i.Item).ToList();

            float totalprice = 0.0f;
            // Loop over all carts
            foreach (var cart in carts)
            {
                float price = 0;
                // Get Items in cart
                var cartItems = cart.CartItems.ToList();
                // Loop over all items
                foreach (var cartItem in cartItems)
                {
                    // Calculate price of cart
                    price += cartItem.Quantity * cartItem.Item.Price;
                }
                // Sum price
                totalprice += price;
            }

            // Calculate average price
            Console.WriteLine("Average price of a cart " + totalprice / carts.Count);
        }

    }
}