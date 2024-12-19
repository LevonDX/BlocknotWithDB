global using static BlocknotWithDB.Utils;
using BlocknotWithDB.Data;

namespace BlocknotWithDB
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Blocknot blocknot = new Blocknot();

            IBlocknotRepo blocknotRepository = new BlocknotRepoEF(blocknot);

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

                    await blocknotRepository.SaveChangesAsync();    

                    break;
                case MenuItems.RemoveRecord:
                    break;
                case MenuItems.ShowRecords:
                    break;
                case MenuItems.FindRecord:
                    Console.Write("Enter name: ");
                    string? recordName = Console.ReadLine();

                    if(recordName is null)
                    {
                        Console.WriteLine("Invalid input. Try again.");
                        break;
                    }

                    Record? foundRecord = blocknotRepository.GetRecordByNameAsync(recordName);

                    break;
                case MenuItems.Exit:
                    break;
                default:
                    break;
            }

        }
    }
}