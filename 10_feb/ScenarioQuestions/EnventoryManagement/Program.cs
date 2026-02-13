
// Base product interface
public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
    Category Category { get; }
}

public enum Category { Electronics, Clothing, Books, Groceries }

// 1. Create a generic repository for products
public class ProductRepository<T> where T : class, IProduct
{
    private List<T> _products = new List<T>();
 
    // TODO: Implement method to add product with validation
    public void AddProduct(T product)
    {
        // Rule: Product ID must be unique
        if(_products.Any(p=> p.Id == product.Id)){
            throw new InvalidOperationException("Product Id is already present");
        }
        // Rule: Price must be positive
        if(product.Price <=0 )
            throw new ArgumentException("Product Price must be greater than zero");
        // Rule: Name cannot be null or empty
        if(string.IsNullOrEmpty(product.Name))
            throw new ArgumentException("Product Name cannt be null");
        // Add to collection if validation passes
        _products.Add(product);
 
    }
 
    // TODO: Create method to find products by predicate
    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        // Should return filtered products
       return _products.Where(predicate);
    }
 
    // TODO: Calculate total inventory value
    public decimal CalculateTotalValue()
    {
        // Return sum of all product prices
        decimal TotalValue=0;
        foreach(var item in _products){
            TotalValue +=item.Price;
        }
        return TotalValue;
    }
}

// 2. Specialized electronic product
public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;
    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}

// 3. Create a discounted product wrapper
public class DiscountedProduct<T> where T : IProduct
{
    private T _product;
    private decimal _discountPercentage;
 
    public DiscountedProduct(T product, decimal discountPercentage)
    {
        // TODO: Initialize with validation
        // Discount must be between 0 and 100
        if (product == null)
            throw new ArgumentNullException(nameof(product));
        if (discountPercentage < 0 || discountPercentage > 100)
            throw new ArgumentOutOfRangeException(nameof(discountPercentage));
 
        _discountPercentage = discountPercentage;
        _product = product;
 
 ?   }
 
    // TODO: Implement calculated price with discount
    public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);
 
    // TODO: Override ToString to show discount details
    public override string ToString()
    {
        return $"Product {_product.Name} has {_discountPercentage}% discount.";
    }

}

// 4. Inventory manager with constraints
public class InventoryManager
{
    // TODO: Create method that accepts any IProduct collection
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        // a) Print all product names and prices
        foreach(var item in products){
            Console.WriteLine("Product Name : " + item.Name + " Price : " + item.Price);
        }
        // b) Find the most expensive product
        decimal max = decimal.MinValue;
        T ExpProduct = default;
        foreach(var item in products){
            if(item.Price > max){
                max = item.Price;
                ExpProduct = item;
            }
        }
        // c) Group products by category
        Dictionary<Category,List<IProduct>> groupByCategoryProducts = new Dictionary<Category,List<IProduct>>();
        foreach(var item in products){
            if(!groupByCategoryProducts.ContainsKey(item.Category)){
                groupByCategoryProducts[item.Category] = new List<IProduct>();
            }
            groupByCategoryProducts[item.Category].Add(item);
        }
        // d) Apply 10% discount to Electronics over $500
        foreach(var item in products){
            if(item.Category == Category.Electronics && item.Price>500 ){
                var discounted = new DiscountedProduct<T>(item, 10);
                Console.WriteLine(discounted.DiscountedPrice);
            }
        }
        
    }
 
    // TODO: Implement bulk price update with delegate
    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
        where T : IProduct
    {
        if (products == null || priceAdjuster == null)
        return;

        foreach (var item in products)
        {
            try
            {
                decimal newPrice = priceAdjuster(item);

                Console.WriteLine(
                $"Product: {item.Name} | Old Price: {item.Price} | Adjusted Price: {newPrice}"
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Price update failed for {item.Name}: {ex.Message}");
            }
    }
    }
}


class Program
{
    static void Main()
    {
        var repo = new ProductRepository<ElectronicProduct>();

        // Sample products
        var products = new List<ElectronicProduct>
        {
            new ElectronicProduct { Id = 1, Name = "Laptop", Price = 800, Brand = "Dell", WarrantyMonths = 24 },
            new ElectronicProduct { Id = 2, Name = "Phone", Price = 600, Brand = "Samsung", WarrantyMonths = 12 },
            new ElectronicProduct { Id = 3, Name = "Headphones", Price = 150, Brand = "Sony", WarrantyMonths = 6 },
            new ElectronicProduct { Id = 4, Name = "Monitor", Price = 300, Brand = "LG", WarrantyMonths = 18 },
            new ElectronicProduct { Id = 5, Name = "TV", Price = 1200, Brand = "Samsung", WarrantyMonths = 24 }
        };

        // Add products to repository
        foreach (var p in products)
            repo.AddProduct(p);

        Console.WriteLine("---- Total Inventory Value ----");
        Console.WriteLine(repo.CalculateTotalValue());

        // Find products by brand
        Console.WriteLine("\n---- Samsung Products ----");
        var samsungProducts = repo.FindProducts(p => p.Brand == "Samsung");
        foreach (var p in samsungProducts)
            Console.WriteLine($"{p.Name} - {p.Price}");

        // Process inventory
        var manager = new InventoryManager();

        Console.WriteLine("\n---- Processing Products ----");
        manager.ProcessProducts(products);

        // Bulk price adjustment demo
        Console.WriteLine("\n---- Updated Prices (10% off Electronics) ----");
        manager.UpdatePrices(products, p =>
        {
            if (p.Category == Category.Electronics)
                return p.Price * 0.9m;

            return p.Price;
        });
    }
}

// 5. TEST SCENARIO: Your tasks:
// a) Implement all TODO methods with proper error handling
// b) Create a sample inventory with at least 5 products
// c) Demonstrate:
//    - Adding products with validation
//    - Finding products by brand (for electronics)
//    - Applying discounts
//    - Calculating total value before/after discount
//    - Handling a mixed collection of different product types