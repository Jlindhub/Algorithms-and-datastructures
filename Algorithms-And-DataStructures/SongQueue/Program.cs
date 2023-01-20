using System;
using System.Collections;
using System.Collections.Generic;
using TurboCollections;



TurboLinkedQueue<string> SongQueue = new TurboLinkedQueue<string>();
bool isrunning = true;
while (isrunning)
{
    if(SongQueue.count>0) { Console.WriteLine($"now playing: {SongQueue.Peek()}"); }
    int state;
    Console.WriteLine("what would you like to do? \n (1): add song \n (2): skip \n (3): exit program.");
    
    try { state = Convert.ToInt32(Console.ReadLine()); }
    catch (Exception) { state = 42; }
        
    switch (state)
    {
        case 1:
            Console.WriteLine("please give me the song name.");
            SongQueue.Enqueue(Console.ReadLine());
            break;
        case 2:
            if (SongQueue.count <=0) { Console.WriteLine("there are no songs in the queue."); }
            else { SongQueue.Dequeue(); }
            break;
        case 3:
            SongQueue.Clear();
            Console.WriteLine("exiting program.");
            isrunning = false;
            break;
        default:
            Console.WriteLine("input not recognized. please try again.");
            break;
    }
}