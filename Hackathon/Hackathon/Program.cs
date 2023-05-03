namespace Hackathon
{
    internal class Program
    {
        class Data
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Date { get; set; }
        }
        class Details
        {
            List<Data> list;
            public int CustomerId = 1;
            string date= DateTime.UtcNow.ToString("MM-dd-yyyy");
            public Details()
            {
                list = new List<Data>()
                {
                    new Data { Id = CustomerId++, Title = "Meeting", Description = "At 9am",Date=date },
                    new Data { Id = CustomerId++, Title = "Class", Description = "At 11am",Date=date },
                };
            }
            public void AddData()
            {
                Console.WriteLine("Enter Title");
                string title = Console.ReadLine();
                Console.WriteLine("Enter Description");
                string description = Console.ReadLine();
                string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
                Console.WriteLine(date);
                int id = CustomerId++;
               // date= DateTime.UtcNow.ToString("MM-dd-yyyy");
                list.Add(new Data() { Id = id, Title = title, Description = description, Date=date });
                Console.WriteLine($"Customer Added and Customer Id is Generated Customer ID: {id}");
            }
            public Data GetData(int id)
            {
                foreach (Data c in list)
                {
                    if (c.Id == id)
                        return c;
                }
                return null;
            }
            public List<Data> GetAllData()
            {
                return list;

            }
            public bool DeleteData(int id)
            {
                foreach (Data c in list)
                {
                    if (c.Id == id)
                    {
                        list.Remove(c);
                        return true;
                    }
                }
                return false;
            }
            public void UpdateData(int id)
            {
                foreach (Data c in list)
                {
                    if (c.Id == id)
                    {
                        Console.WriteLine("Enter updated Note  Name");
                        c.Title = Console.ReadLine();
                        Console.WriteLine("Enter updated Note description");
                        c.Description = Console.ReadLine();
                        Console.WriteLine("Notes Details Updated Successfully");
                        c.Date= DateTime.UtcNow.ToString("MM-dd-yyyy");
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Details details = new Details();
            string res = "y";
            do
            {
                Console.WriteLine("1. Create Note");
                Console.WriteLine("2. View Note");
                Console.WriteLine("3. View All Notes");
                Console.WriteLine("4. Update Note");
                Console.WriteLine("5. Delete Note");
                Console.WriteLine("Enter Your choice: ");
                int choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            details.AddData();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter Notes Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            Data? c = details.GetData(id);
                            if (c == null)
                            {
                                Console.WriteLine("Customer not exists");
                            }
                            else
                            {

                                Console.WriteLine($"Customer Details of id-{c.Id} :");
                                Console.WriteLine($"id\tTitle\tDescription\t\tDate");
                                Console.WriteLine($"{c.Id}\t{c.Title}\t\t{c.Description}\t\t{c.Date}");

                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("id\ttitle\tdescription\t\tdate");
                            int count = 0;
                            foreach (var c in details.GetAllData())
                            {
                                Console.WriteLine($"{c.Id}\t{c.Title}\t\t{c.Description}\t\t{c.Date}");
                                 count= count+1;
                            }
                             Console.WriteLine($"Total Notes\t{count}"); 
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter Note Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            details.UpdateData(id);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter Note  Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            if (details.DeleteData(id))
                            {
                                Console.WriteLine("Notes Deleted Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Note not exist");
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Choice");
                            break;
                        }
                }
                Console.WriteLine("Do you wish to continue? [y/n] ");
                res = Console.ReadLine();
            } while (res.ToLower() == "y");



        }
    }

            
        
    
}