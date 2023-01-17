using System.Collections;

List<int> list = new List<int>{ 137, 1000, -200 };
for (int i=0; i < list.Count; i++) { Console.WriteLine(list[i]); }

Console.WriteLine(" "); //formatting spacer

ArrayList arrayList = new ArrayList { true, "Forstbergs", 1000, .12f };
for (int i = 0; i < arrayList.Count; i++) { Console.WriteLine(arrayList[i]); }

// thoughts: it feels wrong to use for loops when foreach or while loops using the pointer would be cleaner.