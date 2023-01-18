using TurboCollections;

TurboLinkedStack<string> stringStack = new TurboLinkedStack<string>();
stringStack.Push($"you are at: Main Menu  \n (1) level {stringStack.Count()+1} \n (2): exit program \n (3) settings");
Console.WriteLine(stringStack.Peek());
int state = Convert.ToInt32(Console.ReadLine());
bool isRunning = true;
while(isRunning)
{

    switch (state)
    {
        case 1:
            stringStack.Push($"you are at:level {stringStack.Count()} \n your options are: \n (1)level {stringStack.Count()+1} \n (2) main menu \n (3) settings");
            Console.WriteLine(stringStack.Peek());

            state = Convert.ToInt32(Console.ReadLine());
            break;
        case 2:
            if(stringStack.Count() > 1)
            {

                stringStack.Clear();
                stringStack.Push($"you are at: Main Menu \n (1) level {stringStack.Count()+1} \n (2): exit program \n (3) settings");
                Console.WriteLine(stringStack.Peek());
                state = Convert.ToInt32(Console.ReadLine());
                break;
            }
            Console.WriteLine("exiting program.");
            stringStack.Clear();
            isRunning = false;
            break;
        case 3:
            stringStack.Push("you are at: Settings. input any key to go back.");
            Console.WriteLine(stringStack.Peek());
            Console.ReadKey();
            state = 2;
            break;
    }
    
}