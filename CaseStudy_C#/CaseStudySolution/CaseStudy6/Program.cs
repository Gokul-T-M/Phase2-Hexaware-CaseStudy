namespace CaseStudy6
{
    using System;

    class Program
    {
        static void Main()
        {
            MyPlayList playlist = new MyPlayList();

            while (true)
            {
                Console.WriteLine("\nEnter 1: To Add Song");
                Console.WriteLine("Enter 2: To Remove Song by Id");
                Console.WriteLine("Enter 3: Get Song By Id");
                Console.WriteLine("Enter 4: Get Song by Name");
                Console.WriteLine("Enter 5: Get All Songs from Playlist");
                Console.WriteLine("Enter 6: Exit");
                Console.Write("Your Choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Song ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Song Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Song Genre: ");
                        string genre = Console.ReadLine();
                        playlist.Add(new Song(id, name, genre));
                        break;

                    case 2:
                        Console.Write("Enter Song ID to Remove: ");
                        int removeId = Convert.ToInt32(Console.ReadLine());
                        playlist.Remove(removeId);
                        break;

                    case 3:
                        Console.Write("Enter Song ID to Search: ");
                        int searchId = Convert.ToInt32(Console.ReadLine());
                        var songById = playlist.GetSongById(searchId);
                        if (songById != null)
                            Console.WriteLine($"Found: ID={songById.SongId}, Name={songById.SongName}, Genre={songById.SongGenre}");
                        else
                            Console.WriteLine("Song not found.");
                        break;

                    case 4:
                        Console.Write("Enter Song Name to Search: ");
                        string searchName = Console.ReadLine();
                        var songByName = playlist.GetSongByName(searchName);
                        if (songByName != null)
                            Console.WriteLine($"Found: ID={songByName.SongId}, Name={songByName.SongName}, Genre={songByName.SongGenre}");
                        else
                            Console.WriteLine("Song not found.");
                        break;

                    case 5:
                        Console.WriteLine("\nAll Songs in Playlist:");
                        foreach (var s in playlist.GetAllSongs())
                        {
                            Console.WriteLine($"ID: {s.SongId}, Name: {s.SongName}, Genre: {s.SongGenre}");
                        }
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }
    }

}
