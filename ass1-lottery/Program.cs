Welcome.Introduction();
string userName = Welcome.GetName();
int[] userNumbers = NumberSelection.UserSelection();
int[] randomNumbers = NumberSelection.RandomSelection();

Console.WriteLine("Your Numbers:");
foreach (int number in userNumbers)
{
    Console.Write("{0} ", number);
}

Console.WriteLine("");
Console.WriteLine("\nLottery Numbers:");
foreach (int number in randomNumbers)
{
    Console.Write("{0} ", number);
}
Console.WriteLine("");

NumberValidation.BinaryCompare(userNumbers, randomNumbers);
NumberValidation.Display(userNumbers.Length);

static class Welcome
{
    public static void Introduction()
    {
        Console.WriteLine("**********************************");
        Console.WriteLine("*** Welcome to Jake's Lottery! ***");
        Console.WriteLine("**********************************");
        Console.WriteLine("***** Jacob Oliver (J093209) *****");
        Console.WriteLine("**********************************\n");
    }

    public static string GetName()
    {
        string userName = "";

        while (userName.Length <= 0)
        {
            Console.Write("Enter your name: ");
            userName = Console.ReadLine();

            if (userName.Length >= 1)
            {
                Console.WriteLine("...Hi {0}, welcome to my lottery program!\n", userName);
                return userName;
            }
            else
            {
                Console.WriteLine("No name entered. Please try again.\n");
            }
        }
        return userName;
    }
}

class NumberSelection
{
    static int rangeMin = 10; // Set lowest value that the program can select from.
    static int rangeMax = 20; // Set highest value that the program can select from.
    static int entries = 5; // The amount of numbers to be selected by user & program.
    public static int[] userNumbers = new int[entries];
    public static int[] randomNumbers = new int[entries];

    public static int[] UserSelection()
    {
        Console.WriteLine("LOTTERY GUIDELINES:");
        Console.WriteLine("- Select numbers between and including {0} and {1}.", rangeMin, rangeMax);
        Console.WriteLine("- You will be able to select {0} numbers in total.\n", entries);

        for (int i = 0; i < entries; i++)
        {
            string userInput = "";
            bool validInput = false;

            while (validInput == false)
            {
                Console.Write("Entry {0}: ", i + 1);
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int userNumber))
                {
                    if (userNumber >= rangeMin && userNumber <= rangeMax)
                    {
                        if (NumberValidation.IsDuplicate(userNumber, userNumbers) == false)
                        {
                            userNumbers[i] = userNumber;
                            Console.WriteLine("Entry accepted!\n");
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Error: Duplicate entered. Please try again.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: The chosen number must between (and including) {0} and {1}\n", rangeMin, rangeMax);
                    }
                }
                else
                {
                    Console.WriteLine("Error: Invalid input, only numbers accepted. Please try again.\n");
                }
            }
        }
        return userNumbers;
    }

    public static int[] RandomSelection()
    {
        Random rnd = new Random();

        for (int i = 0; i < entries; i++)
        {
            int randomNumber = 0;
            bool isUnique = false;

            while (isUnique == false)
            {
                randomNumber = rnd.Next(rangeMin, rangeMax + 1);
                if (NumberValidation.IsDuplicate(randomNumber, randomNumbers) == false)
                {
                    isUnique = true;
                }
            }
            randomNumbers[i] = randomNumber;
        }
        return randomNumbers;
    }
}

static class NumberValidation
{
    static int correctCount = 0;
    public static bool IsDuplicate(int enteredNumber, int[] numbers)
    {
        foreach (int number in numbers)
        {
            if (number == enteredNumber)
            {
                return true;
            }
        }
        return false;
    }

    public static int BinaryCompare(int[] userNumbers, int[] randomNumbers)
    {
        Array.Sort(userNumbers);
        Array.Sort(randomNumbers);

        foreach (int userNum in userNumbers)
        {
            int low = 0;
            int high = randomNumbers.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (randomNumbers[mid] == userNum)
                {
                    correctCount++;
                    break;
                }
                if (randomNumbers[mid] > userNum)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
        }
        return correctCount;
    }

    public static void Display(int entries)
    {
        if (correctCount == entries)
        {
            Console.WriteLine("Congratulations, you won!");
        }
        else
        {
            Console.WriteLine("\nSorry, no winnings! You got {0} out of {1} correct\n", correctCount, entries);
            Console.WriteLine("THANKS FOR PLAYING! :)");
        }
    }
}
