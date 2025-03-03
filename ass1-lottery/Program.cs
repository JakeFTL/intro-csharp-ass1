Welcome.Introduction();
string userName = Welcome.GetName();
static class Welcome
{
    public static void Introduction()
    {
        Console.WriteLine("********************************");
        Console.WriteLine("** Welcome to Jake's Lottery! **");
        Console.WriteLine("********************************");
        Console.WriteLine("**** Jacob Oliver (J093209) ****");
        Console.WriteLine("********************************");
    }

    public static string GetName()
    {
        string userName = "";

        while (userName.Length <= 0)
        {
            Console.Write("\nEnter your name: ");
            userName = Console.ReadLine();

            if (userName.Length >= 1)
            {
                Console.WriteLine("\nHi {0}, welcome to my lottery program!", userName);
                return userName;
            }
            else
            {
                Console.WriteLine("No name entered. Please try again.");
            }
        }
        return userName;
    }
}

