using System;
using System.Collections;
using System.Collections.Generic;


List<int> intlist = new List<int>{ 137, 1000, -200 };

for (int i=0; i < intlist.Count; i++)
{
     Console.WriteLine(intlist[i]);
     
}

Console.WriteLine(" "); //formatting spacer

ArrayList arrayList = new ArrayList { true, "Forstbergs", 1000, .12f };
for (int i = 0; i < arrayList.Count; i++)
{
     Console.WriteLine(arrayList[i]);
}
/* thoughts:
it feels wrong to use for loops to utilize lists, when a foreach or a
 while loopor utilizing the pointer would be cleaner comparatively. */