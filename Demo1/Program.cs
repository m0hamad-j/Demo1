Console.WriteLine("Choose an item to buy: [1 - 4]");

List<Item> items = new()
{
    new Item(1,"Cookie",12),
    new Item(2,"Biscuit",10),
    new Item(3, "Juice",5),
    new Item(4,"Cake",20),
};

var customer = "Ahmad";
DisplayItems();
var stringNumber = Console.ReadLine();
if (stringNumber == "e")
    Environment.Exit(0);

var validParse = int.TryParse(stringNumber, out var number);
while (!validParse || number > 4)
{
    Console.WriteLine($"{stringNumber} is not a valid number");
    await Task.Delay(1000);
    Console.Clear();
    DisplayItems();
    stringNumber = Console.ReadLine();
    validParse = int.TryParse(stringNumber, out number);
}

var selectedItem = items.FirstOrDefault(i => i.Id == number)!;
Console.WriteLine($"{customer} bought {selectedItem.Name} with price {selectedItem.Price}");
void DisplayItems()
{
    foreach (var item in items)
    {
        Console.WriteLine($"{item.Id}: {item.Name} with price {item.Price}");
    }
    Console.WriteLine($"e: exit");
}

class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public Item(int id, string name, int price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

}