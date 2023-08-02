using static System.Console;


namespace minimaxttt;

static class Program
{
    public static void Main(string[] args)
    {
        int letterSpeed = 1;
        int spaceSpeed = 5;
        SWrite("welcome to tic-tac-toe. the computer will begin as the Xes, because i will it.");
        var node = Node.Initial;
        WriteLine(node);
        bool maximizing = true;
        while (!node.IsTerminal)//turn loop, basically
        {
            if (node.CurrentChar == 'O')
            {
               
                SWrite("please input a row. (1-2-3).");
                int playerRow = Convert.ToInt32(ReadLine());
                while (playerRow < 1 || playerRow > 3)
                {
                    SWrite("invalid input, please try again. 1-2-3.");
                    playerRow = Convert.ToInt32(ReadLine());
                }

                playerRow--; //to match 'field' variable
                SWrite("please select which box you want.");
                int playerBox = Convert.ToInt32(ReadLine());
                while (playerBox < 1 || playerBox > 3)
                {
                    SWrite("invalid input, please try again. 1-2-3.");
                    playerBox = Convert.ToInt32(ReadLine());
                }

                playerBox--; //to match 'field' variable
                if (OccupiedCheck(playerRow, playerBox))
                {
                    SWrite("position occupied, please try again.");
                }
                else
                {
                    node = node.CreateSuccessor(playerRow, playerBox);
                }
            }
            else
            {
                node = AiBrain.minimax(node, maximizing).Node;
            }

            WriteLine(node);
            maximizing = !maximizing;
        }

        if (node.Score == 0)
        {
            SWrite("the match has ended in a draw. good job player, it's the best you can do.");
        }
        else if (node.Score > 0) //means X(ai) wins.
        {
            SWrite("the Ai has won. as it should.");
            
        }
        else
        {
            SWrite("you have somehow done the impossible, or outright cheated. please contact the developer.");
        }
        SWrite("\ninput any key to terminate the program.");
        Console.ReadKey();
        return;
        
        bool OccupiedCheck(int posOne, int posTwo)
        {
            if (node.field[posOne,posTwo]== default)
            {
                return false;
            }
            return true;
        }

        //slow-write method. purely aesthetic.
        void SWrite(string text)
        {
            string[] splitForm = text.Split((' '));
            Task t = Task.Run(() =>
            {
                foreach (string part in splitForm)
                {
                    foreach (char letter in part)
                    {
                        Write(letter);
                        Thread.Sleep(letterSpeed);
                    }

                    Write(" ");
                    Thread.Sleep(spaceSpeed);
                }
            });
            t.Wait();
            Write("\n");
        }

    }
}