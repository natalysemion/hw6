using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Book
{
    // [JsonIgnore] - 2. Як необхідно змінити опис класів, щоб не серіалізувати
    //                в подальшому параметр PublishingHouseId ?
    public int PublishingHouseId { get; set; }
    // [JsonPropertyName("Name")] - 3. Як необхідно змінити опис класів, щоб серіалізований об’єкт
    //                                 містив параметр Title з назвою “Name” ?
    public string Title { get; set; }
    public PublishingHouse PublishingHouse { get; set; }
    Book(int publishingHouseId, string title, PublishingHouse publishingHouse)
    {
        PublishingHouseId = publishingHouseId;
        Title = title;
        PublishingHouse = publishingHouse;
    }
    public Book() { }
}

public class PublishingHouse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
    public PublishingHouse(int id, string name, string address)
    {
        Id = id;
        Name = name;
        Adress = address;
    }
    public PublishingHouse() { }
}

public class Program
{
    static async Task Main(string[] args)
    {
        string path = @"C:\Users\Nata\Desktop\hm6task.json"; 
        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            var books = await JsonSerializer.DeserializeAsync<List<Book>>(fs);
            foreach (var book in books)
            {
                Console.WriteLine($"{book.PublishingHouseId} - {book.Title} - {book.PublishingHouse.Id} - {book.PublishingHouse.Name} - {book.PublishingHouse.Adress}");
            }
        }
    }
}