using static System.Console;


namespace minimaxttt;

class Program
{
    public static void Main(string[] args)
    {
        //configure for different text speed in milliseconds.
        int letterspeed = 1;
        int spacespeed = 5;
        
        Random random = new Random();
        bool playerturn;
        bool gameactive;
        int coinflip = random.Next(0,2);
        int playerchoice;
        int turnsfordraw=0;
        
        char[,] field = new char[3, 3]; //note: this is the 'raw' field status.
        
        Swrite("Welcome to the tictactoe minimax in-progress. here's where i'll maybe do something.");
        Swrite("the player will be represented by x-es, the computer by o-s.");
        Swrite("Please select 0 or 1 for the binary flip to determine starting player.");
        playerchoice = Convert.ToInt32(ReadLine());
        while(playerchoice != 1 && playerchoice != 0)
        {
            Swrite("invalid input, please try again. 1 or 0.");
            playerchoice = Convert.ToInt32(ReadLine());
        }
        Swrite("and the result is... " + coinflip);
        if (coinflip == playerchoice) { playerturn=true; Swrite("seems you were right. the player will begin."); }
        else { playerturn = false; Swrite("seems you were wrong. how unfortunate. the computer will begin.");}


        playerturn = true; //debug statement to force player start
        gameactive = true;
        while (gameactive)
        {
            Swrite("current board state:");
            fielddraw();
            if (playerturn)
            {
                Swrite("please input a row. (1-2-3).");
                int playerrow = Convert.ToInt32(ReadLine());
                while (playerrow < 1 || playerrow > 3)
                {
                    Swrite("invalid input, please try again. 1-2-3.");
                    playerrow = Convert.ToInt32(ReadLine());
                }
                playerrow--; //to match 'field' variable
                Swrite("please select which box you want.");
                int playerbox = Convert.ToInt32(ReadLine());
                while (playerbox < 1 || playerbox > 3)
                {
                    Swrite("invalid input, please try again. 1-2-3.");
                    playerbox = Convert.ToInt32(ReadLine());
                }
                playerbox--;
                if (occupiedcheck(playerrow, playerbox))
                {
                    Swrite("position occupied, please try again.");
                }
                else
                {
                    field[playerrow, playerbox] = 'X';
                    playerturn = !playerturn; //end turn
                    turnsfordraw++;

                }
            }
            else
            { 
                Swrite("ai goes here..."); //todo: fix ai
                playerturn = !playerturn;
                turnsfordraw++;
            }
            
            Swrite("turn "+turnsfordraw+" ended. checking for wins and draws...");
            if (turnsfordraw >= 9)
            {
                gameactive = false;
                Swrite("it would seem the game is a draw. if this is incorrect, contact the developer.");
            }
            wincheck();
        }
        
        void fielddraw()
        {
            for (int i = 0; i < field.GetLength(1); i++)
            {
                WriteLine("row " + (i+1) + " " + field[i, 0] + " | " + field[i, 1] + " | " + field[i, 2]);
                if (i<2) //ensures that only 2 horizontals are drawn - without you get 3.
                {
                    WriteLine("      - + - + -");
                }
            }
        }
        bool occupiedcheck(int posone, int postwo)
        {
            if (field[posone, postwo] == '\0') { return false; }
            return true;
        }
        
        //slow-write method. purely aesthetic.
        void Swrite(string text) {
            string[] splitform = text.Split((' '));
            Task t = Task.Run(() =>
            {
                foreach (string part in splitform)
                {
                    foreach (char letter in part)
                    {
                        Write(letter);
                        Thread.Sleep(letterspeed);
                    }
                    Write(" ");
                    Thread.Sleep(spacespeed);
                }
            });
            t.Wait();
            Write("\n");
        }

        int Playerrowwincheck(int row)
        {
            int Xinrow = 0;
            int Oinrow = 0;
            for (int i = 0; i < 3; i++)
            {
                if (field[i, row] == 'X') { Xinrow++; }
                else if (field[i, row] == 'O') { Oinrow++; }
            }
            if (Xinrow == 3) { return 1; }
            if (Oinrow == 3) { return -1; }
            return 0;
        }

        int Playercolwincheck(int col)
        {
            int Xincol = 0;
            int Oincol = 0;
            for (int i = 0; i < 3; i++)
            {
                if (field[col, i] == 'X') { Xincol++; }
                else if (field[col, i] == 'O') { Oincol++; }
            }
            if (Xincol == 3) { return 1; }
            if (Oincol == 3) { return -1; }
            return 0;
        }

        int Playerdiagonalwincheck()
        {
            int xindiag = 0;
            int oindiag = 0;
            for (int i = 0; i < 3; i++) //left to right
            {
                if (field[i, i] == 'X') { xindiag++; }
                if (field[i, i] == 'O') { oindiag++; }
            }
            if (xindiag == 3) { return 1; }
            if (oindiag == 3) { return -1; }

            //reset counts
            xindiag = 0; 
            oindiag = 0;
            for (int i = 2; i > -1; i--)
            {
                if (field[i, 2 - i] == 'X')
                {
                    xindiag++;
                }

                if (field[i, 2 - i] == 'O')
                {
                    oindiag++;
                }
            }
            if (xindiag == 3) { return 1; }
            if (oindiag == 3) { return -1; }
            return 0;
        }

        void wincheck()
        {
            for (int i = 0; i < 3; i++)
            {
                if (Playerrowwincheck(i) == 1 || Playercolwincheck(i) == 1 || Playerdiagonalwincheck()==1)
                {
                    fielddraw();
                    Swrite("congratulations, human. you've won. that means i didn't write this ai properly.");
                    gameactive = false;
                }

                if (Playerrowwincheck(i) == -1 || Playercolwincheck(i) == -1 || Playerdiagonalwincheck() == -1)
                {
                    fielddraw();
                    Swrite("you lose. this means the ai works as it should.");
                    gameactive = false;
                }
            }
        }

    }
}