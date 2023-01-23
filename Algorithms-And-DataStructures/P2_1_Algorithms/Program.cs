using TurboCollections;
//set dressing and user interface in order to give values to algorithms:
Console.Write("hello. (1)fibonacci Iterative, (2)fibonacci Recursive, (3)or number averaging?");
int program;
try { program = Convert.ToInt32(Console.ReadLine()); }
catch (Exception) { program = 42; }

switch (program)
{
    case 1:
        Console.WriteLine("please input desired fibonacci number.");
        int fibnum;
        try { fibnum = Convert.ToInt32(Console.ReadLine()); }
        catch (Exception) { Console.WriteLine("invalid parameter, defaulting to 10."); fibnum = 10; }
        Console.WriteLine(Fibonacci.Iterative(fibnum));
        break;
    case 2:
        Console.WriteLine("please input desired fibonacci number.");
        try { fibnum = Convert.ToInt32(Console.ReadLine()); }
        catch (Exception) { Console.WriteLine("invalid parameter, defaulting to 10."); fibnum = 10; }
        Console.WriteLine(Fibonacci.Recursive(fibnum));
        break;
    case 3:
        Console.WriteLine("what number of numbers would you like to average?");
        int arraySize;
        try { arraySize = Convert.ToInt32(Console.ReadLine()); }
        catch (Exception) { Console.WriteLine("invalid input, defaulting to size 3."); arraySize = 3; }

        var valuesToAverage = new int[arraySize];
        for(var i=0; i<arraySize; i++) {
            Console.WriteLine($"please input a number for slot {i} out of {arraySize}");
            int input;
            try { input = Convert.ToInt32(Console.ReadLine()); }
            catch (Exception) { Console.WriteLine($"invalid input, defaulting to {i}."); input = i; }
            valuesToAverage[i] = input;
            Console.WriteLine($"the average is: {Averager.AveragingMachine(valuesToAverage)}");
        }
        break;
}




