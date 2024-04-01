using Microsoft.EntityFrameworkCore;

namespace Games;

class Program()
{
    public static void Main()
    {
        int ans;
        Console.WriteLine("1 - Search game by name");
        Console.WriteLine("2 - Search game by studio");
        Console.WriteLine("3 - Search game by name and studio");
        Console.WriteLine("4 - Search game by genre");
        Console.WriteLine("5 - Search game by year");
        Console.WriteLine("6 - Search all single play games");
        Console.WriteLine("7 - Search all multi play games");
        Console.WriteLine("8 - Show most sold game");
        Console.WriteLine("9 - Show least sold game");
        Console.WriteLine("10 - Show top-3 most sold games");
        Console.WriteLine("11 - Show top-3 least sold games");
        Console.WriteLine("12 - Add a new game");
        Console.WriteLine("13 - Delete existing game");

        ans = Convert.ToInt32(Console.ReadLine());
        if (ans == 1)
        {
            SearchByName();
        }
        else if (ans == 2)
        {
            SearchByStudio();
        }
        else if (ans == 3)
        {
            SearchByNameAndStudio();
        }
        else if (ans == 4)
        {
            SearchByGenre();
        }
        else if (ans == 5)
        {
            SearchByYear();
        }
        else if (ans == 6)
        {
            SearchSinglePlay();
        }
        else if (ans == 7)
        {
            SearchMultiPlay();
        }
        else if (ans == 8)
        {
            ShowMostSoldGame();
        }
        else if (ans == 9)
        {
            ShowLeastSoldGame();
        }
        else if (ans == 10)
        {
            ShowTop3MostSoldGame();
        }
        else if (ans == 11)
        {
            ShowTop3LeastSoldGame();
        }
        else if (ans == 12)
        {
            AddGame();
        }
        else if (ans == 13)
        {
            DeleteGame();
        }
        else Console.WriteLine("Unknown command");
    }
    public static void SearchByName()
    {
        Console.WriteLine("Enter the name:");
        string n = Console.ReadLine();
        using var context = new GameDbContext();
        var games = context.Games;
        foreach (var game in games)
        {
            if (game.name == n)
            {
                Console.WriteLine($"Name: {game.name}, Studio: {game.studio}, Genre: {game.genre}, Year: {game.year}, Sold Copies: {game.sold}, Players: {game.players}");
            }
        }
    }
    public static void SearchByStudio()
    {
        Console.WriteLine("Enter the studio:");
        string s = Console.ReadLine();
        using var context = new GameDbContext();
        var games = context.Games;
        foreach (var game in games)
        {
            if (game.studio == s)
            {
                Console.WriteLine($"Name: {game.name}, Studio: {game.studio}, Genre: {game.genre}, Year: {game.year}, Sold Copies: {game.sold}, Players: {game.players}");
            }
        }
    }
    public static void SearchByNameAndStudio()
    {
        Console.WriteLine("Enter the name:");
        string n = Console.ReadLine();
        Console.WriteLine("Enter the studio:");
        string s = Console.ReadLine();
        using var context = new GameDbContext();
        var games = context.Games;
        foreach (var game in games)
        {
            if (game.name == n && game.studio == s)
            {
                Console.WriteLine($"Name: {game.name}, Studio: {game.studio}, Genre: {game.genre}, Year: {game.year}, Sold Copies: {game.sold}, Players: {game.players}");
            }
        }
    }
    public static void SearchByGenre()
    {
        Console.WriteLine("Enter the genre:");
        string g = Console.ReadLine();
        using var context = new GameDbContext();
        var games = context.Games;
        foreach (var game in games)
        {
            if (game.genre == g)
            {
                Console.WriteLine($"Name: {game.name}, Studio: {game.studio}, Genre: {game.genre}, Year: {game.year}, Sold Copies: {game.sold}, Players: {game.players}");
            }
        }
    }
    public static void SearchByYear()
    {
        Console.WriteLine("Enter the year:");
        int y = Convert.ToInt32(Console.ReadLine());
        using var context = new GameDbContext();
        var games = context.Games;
        foreach (var game in games)
        {
            if (game.year == y)
            {
                Console.WriteLine($"Name: {game.name}, Studio: {game.studio}, Genre: {game.genre}, Year: {game.year}, Sold Copies: {game.sold}, Players: {game.players}");
            }
        }
    }
    public static void SearchSinglePlay()
    {
        using var context = new GameDbContext();
        var games = context.Games;
        foreach (var game in games)
        {
            if (game.players == "Single play")
            {
                Console.WriteLine($"Name: {game.name}, Studio: {game.studio}, Genre: {game.genre}, Year: {game.year}, Sold Copies: {game.sold}, Players: {game.players}");
            }
        }
    }
    public static void SearchMultiPlay()
    {
        using var context = new GameDbContext();
        var games = context.Games;
        foreach (var game in games)
        {
            if (game.players == "Multi play")
            {
                Console.WriteLine($"Name: {game.name}, Studio: {game.studio}, Genre: {game.genre}, Year: {game.year}, Sold Copies: {game.sold}, Players: {game.players}");
            }
        }
    }
    public static void ShowMostSoldGame()
    {
        using var context = new GameDbContext();
        var games = context.Games;
        var current = context.Games.FirstOrDefault();
        foreach (var game in games)
        {
            if (game.sold > current.sold)
            {
                current = game;
            }
        }
        Console.WriteLine($"Name: {current.name}, Studio: {current.studio}, Genre: {current.genre}, Year: {current.year}, Sold Copies: {current.sold}, Players: {current.players}");
    }
    public static void ShowLeastSoldGame()
    {
        using var context = new GameDbContext();
        var games = context.Games;
        var current = context.Games.FirstOrDefault();
        foreach (var game in games)
        {
            if (game.sold < current.sold)
            {
                current = game;
            }
        }
        Console.WriteLine($"Name: {current.name}, Studio: {current.studio}, Genre: {current.genre}, Year: {current.year}, Sold Copies: {current.sold}, Players: {current.players}");
    }

    public static void ShowTop3MostSoldGame()
    {
        using var context = new GameDbContext();
        var games = context.Games;
        var current = context.Games.FirstOrDefault();
        var top2 = context.Games.FirstOrDefault();
        var top3 = context.Games.FirstOrDefault();
        foreach (var game in games)
        {
            if (game.sold > current.sold)
            {
                top3 = top2;
                top2 = current;
                current = game;
            }
            else if (game.sold > top2.sold)
            {
                top3 = top2;
                top2 = game;
            }
            else if (game.sold > top3.sold)
            {
                top3 = game;
            }
        }

        Console.WriteLine($"1. Name: {current.name}, Studio: {current.studio}, Genre: {current.genre}, Year: {current.year}, Sold Copies: {current.sold}, Players: {current.players}");
        Console.WriteLine($"2. Name: {top2.name}, Studio: {top2.studio}, Genre: {top2.genre}, Year: {top2.year}, Sold Copies: {top2.sold}, Players: {top2.players}");
        Console.WriteLine($"3. Name: {top3.name}, Studio: {top3.studio}, Genre: {top3.genre}, Year: {top3.year}, Sold Copies: {top3.sold}, Players: {top3.players}");
    }

    public static void ShowTop3LeastSoldGame()
    {
        using var context = new GameDbContext();
        var games = context.Games;
        var current = context.Games.FirstOrDefault();
        var top2 = context.Games.FirstOrDefault();
        var top3 = context.Games.FirstOrDefault();
        foreach (var game in games)
        {
            if (game.sold < current.sold)
            {
                top3 = top2;
                top2 = current;
                current = game;
            }
            else if (game.sold < top2.sold)
            {
                top3 = top2;
                top2 = game;
            }
            else if (game.sold < top3.sold)
            {
                top3 = game;
            }
        }
        Console.WriteLine($"1. Name: {current.name}, Studio: {current.studio}, Genre: {current.genre}, Year: {current.year}, Sold Copies: {current.sold}, Players: {current.players}");
        Console.WriteLine($"2. Name: {top2.name}, Studio: {top2.studio}, Genre: {top2.genre}, Year: {top2.year}, Sold Copies: {top2.sold}, Players: {top2.players}");
        Console.WriteLine($"3. Name: {top3.name}, Studio: {top3.studio}, Genre: {top3.genre}, Year: {top3.year}, Sold Copies: {top3.sold}, Players: {top3.players}");
    }

    public static void AddGame()
    {
        Console.WriteLine("Name: ");
        string n = Console.ReadLine();
        Console.WriteLine("Studio: ");
        string st = Console.ReadLine();
        Console.WriteLine("Genre: ");
        string g = Console.ReadLine();
        Console.WriteLine("Year: ");
        int y = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Sold copies: ");
        int so = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Playing type: ");
        string p = Console.ReadLine();
        using var context = new GameDbContext();
        var game = context.Games.FirstOrDefault();
        game.name = n;
        game.studio = st;
        game.genre = g;
        game.year = y;
        game.sold = so;
        game.players = p;
        context.Games.Add(game);
    }
    public static void DeleteGame()
    {
        Console.WriteLine("Name: ");
        string n = Console.ReadLine();
        Console.WriteLine("Studio: ");
        string st = Console.ReadLine();
        using var context = new GameDbContext();
        var current = context.Games.Where(na => na.name == n).Where(stu => stu.studio == st).FirstOrDefault();
        context.Games.Remove(current);
    }
}