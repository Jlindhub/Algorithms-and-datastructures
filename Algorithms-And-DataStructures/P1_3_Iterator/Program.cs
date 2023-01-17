using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Channels;
using TurboCollections;


List<int> list = new List<int>{1,1,2,3,5};
IEnumerable enumerable = list;
IEnumerator enumerator = enumerable.GetEnumerator();
while (enumerator.MoveNext())
{
    Console.WriteLine(enumerator.Current);
}
Console.WriteLine("all together they equal " + list.Sum());
TRYAGAIN:
Console.WriteLine("please select: 1: yield return or 2: List function. ");
string input = Console.ReadLine();
int selector = Convert.ToInt32(input);
Console.WriteLine("please insert number for odd number function, or 0 for int max.");
int targetNumber = Convert.ToInt32(Console.ReadLine());
if (targetNumber == 0) { targetNumber = int.MaxValue;}
switch (selector)
{
    case 1:
        Console.WriteLine("yield return selected with target number "+ targetNumber +", running:");
        foreach (var number in TurboMaths.GetOddNumbersUntil(targetNumber))
        { Console.WriteLine(number); }
        break;
    
    case 2:
        Console.WriteLine("list function selected with target number "+ targetNumber +", running:");
        foreach (var number in TurboMaths.GetOddNumbersUntilList(targetNumber))
        { Console.WriteLine(number); }
        break;
    
    default: Console.WriteLine("you have entered an incorrect value in the selector. please try again.");
        goto TRYAGAIN;
}
