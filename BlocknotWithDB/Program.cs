global using static BlocknotWithDB.Utils;
using BlocknotWithDB.Data;

namespace BlocknotWithDB
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Blocknot blocknot = new Blocknot();

            BlocknotDbContext dbContext = new BlocknotDbContext(blocknot);

            DisplayMenu();

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Try again.");
            }

            MenuItems selectedItem = Enum.IsDefined(typeof(MenuItems), choice) 
                ? (MenuItems)choice 
                : MenuItems.Undefined;

            switch (selectedItem)
            {
                case MenuItems.AddRecord:
                    Console.Write("Enter name: ");
                    string? name = Console.ReadLine();

                    Console.Write("Enter surname: ");
                    string? surname = Console.ReadLine();

                    Console.Write("Enter phone: ");
                    string? phone = Console.ReadLine();

                    Record record = new Record()
                    {
                        Name = name ?? "Unknown",
                        Surname = surname,
                        Phone = phone
                    };

                    blocknot.Add(record);

                    await dbContext.SaveChangesAsync();    

                    break;
                case MenuItems.RemoveRecord:
                    break;
                case MenuItems.ShowRecords:
                    break;
                case MenuItems.FindRecord:
                    break;
                case MenuItems.Exit:
                    break;
                default:
                    break;
            }

        }
    }
}