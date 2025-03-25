List<decimal> typedNumbers = new List<decimal>();
decimal result = 0;
int typedOption = 1;
bool running = true;

Console.WriteLine("This is the best calculator");

while (running)
{
    DisplayHeader();

    try
    {
        typedOption = Convert.ToInt32(Console.ReadLine());

        if (typedOption == 5)
        {
            running = false;
            continue;
        }

        typedNumbers.Clear();
        Console.WriteLine("Please Type the first number");
        typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.WriteLine("Please Type the second number");
        typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));

        int wantToContinue = 0;
        while (wantToContinue != 2)
        {
            Console.WriteLine("Do you want to continue inserting numbers? 1. Yes, 2. No");
            wantToContinue = Convert.ToInt32(Console.ReadLine());
            if (wantToContinue == 1)
            {
                Console.WriteLine("Please Type another number");
                typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));
            }
        }

        switch (typedOption)
        {
            case 1:
                result = AddList(typedNumbers);
                break;
            case 2:
                result = SubtractList(typedNumbers);
                break;
            case 3:
                result = MultiplyList(typedNumbers);
                break;
            case 4:
                result = DivideList(typedNumbers);
                break;
            default:
                Console.WriteLine("Invalid option. Please select a valid operation.");
                continue;
        }

        Console.WriteLine($"The Result of the operation is: {result}");
    }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine($"You cannot divide by zero: {ex.Message}");
    }
    catch (FormatException ex)
    {
        Console.WriteLine($"Invalid input, please enter a number: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
    finally
    {
        Console.WriteLine("Closing DB Connection");
    }
}


static decimal AddList(List<decimal> numbers)
{
    decimal result = 0;
    foreach (decimal number in numbers)
    {
        result += number;
    }
    return result;
}

static decimal SubtractList(List<decimal> numbers)
{
    decimal result = numbers[0];
    for (int i = 1; i < numbers.Count; i++)
    {
        result -= numbers[i];
    }
    return result;
}

static decimal MultiplyList(List<decimal> numbers)
{
    decimal result = 1;
    foreach (decimal number in numbers)
    {
        result *= number;
    }
    return result;
}

static decimal DivideList(List<decimal> numbers)
{
    decimal result = numbers[0];
    for (int i = 1; i < numbers.Count; i++)
    {
        if (numbers[i] == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        result /= numbers[i];
    }
    return result;
}

static void DisplayHeader()
{
    Console.WriteLine("Please Type the option number that you want");
    Console.WriteLine("---------------------------------------");
    Console.WriteLine("1. Sum, \n2. Subtract, \n3. Multiplication, \n4. Division, \n5. Exit");
}


