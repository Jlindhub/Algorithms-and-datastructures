namespace minimaxttt;

public struct NodeScore
{
    public int Score;
    public Node Node;
}

public class Node
{
    public char[,] field;
    public static Node Initial => new Node() { field = new char[3, 3] };

    public bool IsTerminal
    {
        get
        {
            var score = Score;
            if (score != 0)
            {
                return true;
            }

            return IsDraw;
        }
    }

    private bool IsDraw
    {
        get
        {
            foreach (var cell in field)
            {
                if (cell == default)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public int Score
    {
        get
        {
            int score = 0;
            for (int i = 0; i < 3; i++)
            {
                score = PlayerRowWinCheck(i);
                if (score != 0)
                {
                    return score;
                }

                score = PlayerColWinCheck(i);
                if (score != 0)
                {
                    return score;
                }
            }

            return PlayerDiagonalWinCheck();
        }
    }

    public IEnumerable<Node> Successors
    {
        get
        {
            char currentChar = CurrentChar;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (field[x, y] == default)
                    {
                        var newField = field.Clone() as char[,];
                        newField[x, y] = currentChar;
                        yield return new Node()
                        {
                            field = newField
                        };
                    }
                }
            }
        }
    }

    public Node CreateSuccessor(int x, int y)
    {
        if (field[x, y] != default)
        {
            throw new Exception();
        }

        var newField = field.Clone() as char[,];
        newField[x, y] = CurrentChar;
        return new Node()
        {
            field = newField
        };
    }

    public char CurrentChar
    {
        get { return OccupiedCells % 2 == 0 ? 'X' : 'O'; }
    }

    public int OccupiedCells
    {
        get
        {
            int count = 0;
            foreach (var cell in field)
            {
                if (cell != default)
                {
                    count++;
                }
            }

            return count;
        }
    }

    int PlayerRowWinCheck(int row)
    {
        int xinRow = 0;
        int oinRow = 0;
        for (int i = 0; i < 3; i++)
        {
            if (field[i, row] == 'X')
            {
                xinRow++;
            }
            else if (field[i, row] == 'O')
            {
                oinRow++;
            }
        }

        if (xinRow == 3)
        {
            return int.MaxValue - 1;
        }

        if (oinRow == 3)
        {
            return int.MinValue + 1;
        }

        return 0;
    }

    int PlayerColWinCheck(int col)
    {
        int xinCol = 0;
        int oinCol = 0;
        for (int i = 0; i < 3; i++)
        {
            if (field[col, i] == 'X')
            {
                xinCol++;
            }
            else if (field[col, i] == 'O')
            {
                oinCol++;
            }
        }

        if (xinCol == 3)
        {
            return int.MaxValue - 1;
        }

        if (oinCol == 3)
        {
            return int.MinValue + 1;
        }

        return 0;
    }

    int PlayerDiagonalWinCheck()
    {
        int xinDiag = 0;
        int oinDiag = 0;
        for (int i = 0; i < 3; i++) //left to right
        {
            if (field[i, i] == 'X')
            {
                xinDiag++;
            }

            if (field[i, i] == 'O')
            {
                oinDiag++;
            }
        }

        if (xinDiag == 3)
        {
            return int.MaxValue - 1;
        }

        if (oinDiag == 3)
        {
            return Int32.MinValue + 1;
        }

        //reset counts
        xinDiag = 0;
        oinDiag = 0;
        for (int i = 2; i > -1; i--)
        {
            if (field[i, 2 - i] == 'X')
            {
                xinDiag++;
            }

            if (field[i, 2 - i] == 'O')
            {
                oinDiag++;
            }
        }

        if (xinDiag == 3)
        {
            return 1;
        }

        if (oinDiag == 3)
        {
            return -1;
        }

        return 0;
    }

    public override string ToString()
    {
        var output = "";
        for (int i = 0; i < field.GetLength(1); i++)
        {
            output += ("row " + (i + 1) + " " + field[i, 0] + " | " + field[i, 1] + " | " + field[i, 2] + "\n");
            if (i < 2) //ensures that only 2 horizontals are drawn - without you get 3.
            {
                output += ("      - + - + -\n");
            }
        }

        return output;
    }
}

static class AiBrain
{
    public static NodeScore minimax(Node node, bool maximizingPlayer)
    {
        if (node.IsTerminal)
        {
            return new NodeScore()
            {
                Score = node.Score,
                Node = node
            };
        }

        if (maximizingPlayer)
        {
            long accumulatedScore = 0;
            int numberOfScores = 0;
            NodeScore result = new NodeScore()
            {
                Score = int.MinValue,
                Node = null
            };
            foreach (var child in node.Successors)
            {
                NodeScore childResult = minimax(child, false);
                accumulatedScore += childResult.Score;
                numberOfScores++;
                if (childResult.Score > result.Score)
                {
                    result.Score = childResult.Score;
                    result.Node = child;
                }
            }

            if (result.Score == 0)
            {
                result.Score = (int)(accumulatedScore / numberOfScores);
            }

            return result;
        }
        else
        {
            long accumulatedScore = 0;
            int numberOfScores = 0;
            NodeScore result = new NodeScore()
            {
                Score = int.MaxValue,
                Node = null
            };
            foreach (var child in node.Successors)
            {
                NodeScore childResult = minimax(child, true);
                accumulatedScore += childResult.Score;
                numberOfScores++;
                if (childResult.Score < result.Score)
                {
                    result.Score = childResult.Score;
                    result.Node = child;
                }
            }

            if (result.Score == 0)
            {
                result.Score = (int)(accumulatedScore / numberOfScores);
            }

            return result;
        }
    }
}