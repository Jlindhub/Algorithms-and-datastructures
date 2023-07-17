using static System.Console;


namespace minimaxttt;

static class Program
{
    public static void Main(string[] args)
    {
        var node = Node.Initial;
        WriteLine(node);
        bool maximizing = true;
        while (!node.IsTerminal)//turn loop, basically
        {
            if (node.CurrentChar == 'O')
            {
                //todo: playerturnlogic
                //check for occupied
                //if not occupied continue, if occupied try again
                node = node.CreateSuccessor(0, 0);
            }
            else
            {
                node = AiBrain.minimax(node, maximizing).Node;
            }

            WriteLine(node);
            maximizing = !maximizing;
        }

        if(node.Score==0){}//draw here
        else if(node.Score>0){}//X win
        else {} //O win

        return;


        //configure for different text speed in milliseconds.
        int letterSpeed = 1;
        int spaceSpeed = 5;

        Random random = new Random();
        bool playerTurn;
        int coinFlip = random.Next(0, 2);
        int turnsForDraw = 0;

        char[,] field = new char[3, 3]; //note: this is the 'raw' field status.

        SWrite("Welcome to the tic-tac-toe minimax in-progress. here's where i'll maybe do something.");
        SWrite("the player will be represented by x-es, the computer by o-s.");
        SWrite("Please select 0 or 1 for the binary flip to determine starting player.");
        var playerChoice = Convert.ToInt32(ReadLine());
        while (playerChoice != 1 && playerChoice != 0)
        {
            SWrite("invalid input, please try again. 1 or 0.");
            playerChoice = Convert.ToInt32(ReadLine());
        }

        SWrite("and the result is... " + coinFlip);
        if (coinFlip == playerChoice)
        {
            playerTurn = true;
            SWrite("seems you were right. the player will begin.");
        }
        else
        {
            playerTurn = false;
            SWrite("seems you were wrong. how unfortunate. the computer will begin.");
        }


        playerTurn = true; //debug statement to force player start
        var gameActive = true;
        while (gameActive)
        {
            SWrite("current board state:");
            DrawField();
            if (playerTurn)
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

                playerBox--;
                if (OccupiedCheck(playerRow, playerBox))
                {
                    SWrite("position occupied, please try again.");
                }
                else
                {
                    field[playerRow, playerBox] = 'X';
                    playerTurn = !playerTurn; //end turn
                    turnsForDraw++;
                }
            }
            else
            {
                SWrite("ai goes here..."); //todo: fix ai
                playerTurn = !playerTurn;
                turnsForDraw++;
            }

            SWrite("turn " + turnsForDraw + " ended. checking for wins and draws...");
            if (turnsForDraw >= 9)
            {
                gameActive = false;
                SWrite("it would seem the game is a draw. if this is incorrect, contact the developer.");
            }

            WinCheck();
        }

        bool OccupiedCheck(int posOne, int posTwo)
        {
            if (field[posOne, posTwo] == '\0')
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

        void WinCheck()
        {
            for (int i = 0; i < 3; i++)
            {
                if (PlayerRowWinCheck(i) == 1 || PlayerColWinCheck(i) == 1 || PlayerDiagonalWinCheck() == 1)
                {
                    DrawField();
                    SWrite("congratulations, you've won. that means i didn't write this ai properly.");
                    gameActive = false;
                }

                if (PlayerRowWinCheck(i) == -1 || PlayerColWinCheck(i) == -1 || PlayerDiagonalWinCheck() == -1)
                {
                    DrawField();
                    SWrite("you lose. this means the ai works as it should.");
                    gameActive = false;
                }
            }
        }
    }
}