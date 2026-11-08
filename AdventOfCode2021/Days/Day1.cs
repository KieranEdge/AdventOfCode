using AdventOfCode.Common.Interfaces;
using AdventOfCode.Common.DataReaders;

namespace AdventOfCode2021.Days;

public class Day1:IDay
{
    public string Part1(string input)
    {
        List<int> depthNumbers = TextFileToListOfInts.ReturnListOfIntsFromTextFile(input);
        int depthIncreases = 0;

        for (int i = 1; i < depthNumbers.Count; i++)
        {
            if (depthNumbers[i] > depthNumbers[i - 1])
            {
                depthIncreases++;
            }
        }
        return depthIncreases.ToString();
    }

    public string Part2(string input)
    {
        List<int> depthNumbers = TextFileToListOfInts.ReturnListOfIntsFromTextFile(input);
        List<int> threeMeasurementWindow = new List<int>();
        int depthIncreases = 0;

        // Handling the bulk of the windows
        for (int i = 2; i < depthNumbers.Count; i++)
        {
            threeMeasurementWindow.Add(depthNumbers[i] + depthNumbers[i - 1] + depthNumbers[i - 2]);
        }

        for (int i = 1; i < threeMeasurementWindow.Count; i++)
        {
            if (threeMeasurementWindow[i] > threeMeasurementWindow[i - 1])
            {
                depthIncreases++;
            }
        }
        
        return depthIncreases.ToString();
    }
}