using TurboCollections;
//set dressing and user interface in order to give values to algorithm:
Console.WriteLine("hello. i average numbers you give me.");
Console.WriteLine("what number of numbers would you like to average?");
int arraySize;
try { arraySize = Convert.ToInt32(Console.ReadLine()); }
catch (Exception) { Console.WriteLine("invalid input, defaulting to size 3."); arraySize = 3; }

var valuesToAverage = new int[arraySize];
for(var i=0; i<arraySize; i++)
{
    Console.WriteLine($"please input a number for slot {i} out of {arraySize}");
    int input;
    try { input = Convert.ToInt32(Console.ReadLine()); }
    catch (Exception) { Console.WriteLine($"invalid input, defaulting to {i}."); input = i; }
    valuesToAverage[i] = input;
}
//actual algorithm found in: averager.cs
Console.WriteLine($"the average is: {Averager.AveragingMachine(valuesToAverage)}");


