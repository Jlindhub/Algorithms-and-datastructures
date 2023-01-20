using TurboCollections;

TurboLinkedQueue<string> songQueue = new TurboLinkedQueue<string>();
bool running = true;
while (running)
{
    if(songQueue.count>0) { Console.WriteLine($"now playing: {songQueue.Peek()}"); }
    int state;
    Console.WriteLine("what would you like to do? \n (1): add song \n (2): skip \n (3): exit program.");
    
    try { state = Convert.ToInt32(Console.ReadLine()); }
    catch (Exception) { state = 42; }
        
    switch (state)
    {
        case 1:
            Console.WriteLine("please give me the song name.");
            string input = Console.ReadLine() ?? string.Empty;
            if(!string.IsNullOrEmpty(input)){ songQueue.Enqueue(input); }
            else
            { 
                Console.WriteLine("no input detected. returning to menu. user presumed dead. \nclearing list to preserve user dignity.");
            }
            break;
        case 2:
            if (songQueue.count <=0) { Console.WriteLine("there are no songs in the queue."); }
            else { songQueue.Dequeue(); }
            break;
        case 3:
            songQueue.Clear();
            Console.WriteLine("exiting program.");
            running = false;
            break;
        default:
            Console.WriteLine("input not recognized. please try again.");
            break;
    }
}