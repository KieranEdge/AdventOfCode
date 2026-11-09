using AdventOfCode.Common.Interfaces;
namespace AdventOfCode2021.Days;

public class Day4:IDay
{
    public string Part1(string input)
    {
        // Accessing the information
        var bingoInformation = ReturnListsAndBoards(input);
        int[] numberOrder = bingoInformation.numberOrder;
        List<int[,]> listOfBoards = bingoInformation.listOfBoards;
        
        // Creating a boolean matrix for each board
        List<bool[,]> listOfBoardsBoolean = new List<bool[,]>();
        for (int i = 0; i < listOfBoards.Count; i++)
        {
            listOfBoardsBoolean.Add(BooleanBoardView());
        }
        
        // Iterating over the called balls and bingo boards
        int finalNumber = 0;
        int firstWinnerIndex = 0;
        foreach (int number in numberOrder)
        {
            // Setting the current number
            int currentNumber = number;
            
            // Iterating over the boards
            int currentBoard = 0;
            foreach (int[,] board in listOfBoards)
            {
                for (int row = 0; row < 5; row++)
                {
                    for (int col = 0; col < 5; col++)
                    {
                        if (board[row, col] == currentNumber)
                        {
                            listOfBoardsBoolean[currentBoard][row, col] = true;
                        }
                    }
                }

                currentBoard++;
            }
            
            // Checking for rows and columns
            foreach (bool[,] board in listOfBoardsBoolean)
            {
                if (IsColumnComplete(board) || IsRowComplete(board))
                {
                    finalNumber =  currentNumber;
                    firstWinnerIndex = currentBoard;
                    Console.WriteLine(finalNumber);
                    Console.WriteLine(firstWinnerIndex);
                    break;
                }
            }
        }

        return $"First number is {numberOrder[0]} and last number of the second card is {listOfBoards[1][4, 4]}";
    }

    public string Part2(string input)
    {
        throw new NotImplementedException();
    }
    
    public (int[] numberOrder, List<int[,]> listOfBoards)ReturnListsAndBoards(string path)
    {
        // Getting all of the data from the file
        string[] linesInFile = File.ReadAllLines(path);
        
        // Getting the first line and number order
        string numberOrderString = linesInFile[0];
        string[] numberOrderStringArray = numberOrderString.Split(',');
        int[] numberOrderIntArray = new int[numberOrderStringArray.Length];
        for (int i = 0; i < numberOrderStringArray.Length; i++)
        {
            numberOrderIntArray[i] = int.Parse(numberOrderStringArray[i]);
        }
        
        // Getting the boards from the file
        List<int[,]> listOfBingoBoards = new List<int[,]>();
        for (int i = 2; i < linesInFile.Length; i += 6)
        {
            int[,] bingoBoard = new int[5, 5];
            
            for (int j = 0; j < 5; j++)
            {
                string line = linesInFile[i + j];
                int[] numbersOnLine = BoardStringSplitter(line);

                int column = 0;

                foreach (int number in numbersOnLine)
                {
                    bingoBoard[j, column] = number;
                    column++;
                }
            }
            listOfBingoBoards.Add(bingoBoard);
        }
        
        return (numberOrderIntArray, listOfBingoBoards);
    }

    public int[] BoardStringSplitter(string input)
    {
        int[] boardLine = new int[5];
        string[] numbers = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        for(int i = 0; i < 5; i++)
        {
            boardLine[i] = int.Parse(numbers[i]);
        }
        return boardLine;
    }

    public bool[,] BooleanBoardView()
    {
        bool[,] booleanBoardView = new bool[5, 5];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                booleanBoardView[i, j] = false;
            }
        }
        return booleanBoardView;
    }
    
    public bool IsRowComplete(bool[,] board)
    {
        for (int i = 0; i < 5; i++)
        {
            bool rowComplete = true;

            for (int j = 0; j < 5; j++)
            {
                if (!board[i, j])
                {
                    rowComplete = false;
                    break;
                }
            }

            if (rowComplete)
            {
                return true;
            }
        }

        return false;
    }
    
    public bool IsColumnComplete(bool[,] board)
    {
        for (int i = 0; i < 5; i++)
        {
            bool columnComplete = true;

            for (int j = 0; j < 5; j++)
            {
                if (!board[j, i])
                {
                    columnComplete = false;
                    break;
                }
            }

            if (columnComplete)
            {
                return true;
            }
        }

        return false;
    }
}