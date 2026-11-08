using AdventOfCode.Common.Interfaces;
using AdventOfCode.Common.DataReaders;

namespace AdventOfCode2021.Days;

public class Day2:IDay
{
    public string Part1(string input)
    {
        List<string> dataLines = TextFileToListOfStrings.ReturnListOfStrings(input);
        List<string> directionsList = new List<string>();
        List<int> distanceList = new List<int>();
        
        foreach (string line in dataLines)
        {
            directionsList.Add(line.Split(' ')[0]);
            distanceList.Add(int.Parse(line.Split(' ')[1]));
        }
        
        int horizontal = 0;
        int vertical = 0;

        for (int i = 0; i < directionsList.Count; i++)
        {
            if (directionsList[i] == "forward")
            {
                horizontal += distanceList[i];
            }
            else if (directionsList[i] == "down")
            {
                vertical += distanceList[i];
            }
            else if (directionsList[i] == "up")
            {
                vertical -= distanceList[i];
            }
        }
        
        return (horizontal * vertical).ToString();
        
    }

    public string Part2(string input)
    {
        List<string> dataLines = TextFileToListOfStrings.ReturnListOfStrings(input);
        List<string> directionsList = new List<string>();
        List<int> distanceList = new List<int>();
        
        foreach (string line in dataLines)
        {
            directionsList.Add(line.Split(' ')[0]);
            distanceList.Add(int.Parse(line.Split(' ')[1]));
        }
        
        int horizontal = 0;
        int vertical = 0;
        int aim = 0;

        for (int i = 0; i < directionsList.Count; i++)
        {
            if (directionsList[i] == "forward")
            {
                horizontal += distanceList[i];
                vertical += distanceList[i] * aim;
            }
            else if (directionsList[i] == "down")
            {
                aim += distanceList[i];
            }
            else if (directionsList[i] == "up")
            {
                aim -= distanceList[i];
            }
        }
        
        return (horizontal * vertical).ToString();
        
    }
}