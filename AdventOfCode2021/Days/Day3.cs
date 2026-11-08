using AdventOfCode.Common.Interfaces;
using AdventOfCode.Common.DataReaders;

namespace AdventOfCode2021.Days;

public class Day3:IDay
{
    public string Part1(string input)
    {
        char[,] binaryValues = ReturnBinaryArray(input);
        string gammaValue = "";
        string epsilonValue = "";

        // Iterating over the columns
        for (int i = 0; i < binaryValues.GetLength(1); i++)
        {
            int numberOf0s = 0;
            int numberOf1s = 0;
            
            // iterating over rows
            for (int j = 0; j < binaryValues.GetLength(0); j++)
            {
                if (binaryValues[j, i] == '0')
                {
                    numberOf0s++;
                }
                else if (binaryValues[j, i] == '1')
                {
                    numberOf1s++;
                }
            }

            if (numberOf0s > numberOf1s)
            {
                gammaValue = $"{gammaValue}{'0'}";
                epsilonValue = $"{epsilonValue}{'1'}";
            }
            else
            {
                gammaValue = $"{gammaValue}{'1'}";
                epsilonValue = $"{epsilonValue}{'0'}";
            }
        }
        
        int gammaValueAsInt = Convert.ToInt32(gammaValue, 2);
        int epsilonValueAsInt = Convert.ToInt32(epsilonValue, 2);
        
        return $"Gamma Value:{gammaValueAsInt} +  Epsilon Value: {epsilonValueAsInt}; therefore total factor = {gammaValueAsInt * epsilonValueAsInt}";
    }

    public string Part2(string input)
    {
        // Getting the list of binary strings and the list of characters
        List<string> binaryStrings = TextFileToListOfStrings.ReturnListOfStrings(input);
        char[,] binaryValues = ReturnBinaryArray(input);
        
        // Getting the initial list of all indices
        List<int> masterIndicesList = new List<int>();
        
        for (int i = 0; i < binaryStrings.Count; i++)
        {
            masterIndicesList.Add(i);
        }
        
        // Copying this for specific indices lists for oxygen and carbon
        List<int> oxygenIndicesList = new List<int>(masterIndicesList);
        List<int> co2IndicesList = new List<int>(masterIndicesList);
        

        // Iterative search over columns for oxygen value
        for (int i = 0; i < binaryValues.GetLength(1); i++)
        {
            List<int> indicesOf0 = new List<int>();
            List<int> indicesOf1 = new List<int>();
            int numberOf0s = 0;
            int numberOf1s = 0;
            
            foreach (int index in oxygenIndicesList)
            {
                if (binaryValues[index, i] == '0')
                {
                    indicesOf0.Add(index);
                    numberOf0s++;
                }
                else if (binaryValues[index, i] == '1')
                {
                    indicesOf1.Add(index);
                    numberOf1s++;
                }
            }

            if (numberOf0s > numberOf1s)
            {
                oxygenIndicesList = indicesOf0;
            }
            else
            {
                oxygenIndicesList = indicesOf1;
            }
        }
        
        // Iterative search over columns for CO2 value
        for (int i = 0; i < binaryValues.GetLength(1); i++)
        {
            List<int> indicesOf0 = new List<int>();
            List<int> indicesOf1 = new List<int>();
            int numberOf0s = 0;
            int numberOf1s = 0;
            
            foreach (int index in co2IndicesList)
            {
                if (binaryValues[index, i] == '0')
                {
                    indicesOf0.Add(index);
                    numberOf0s++;
                }
                else if (binaryValues[index, i] == '1')
                {
                    indicesOf1.Add(index);
                    numberOf1s++;
                }
            }

            if (numberOf0s <= numberOf1s && numberOf0s != 0)
            {
                co2IndicesList = indicesOf0;
            }
            else
            {
                co2IndicesList = indicesOf1;
            }
        }
        Console.WriteLine(oxygenIndicesList.Count);
        Console.WriteLine(co2IndicesList.Count);
        
        string oxygenBinary = binaryStrings[oxygenIndicesList[0]];
        string co2Binary = binaryStrings[co2IndicesList[0]];
        int oxygenValueAsInt = Convert.ToInt32(oxygenBinary, 2);
        int co2ValueAsInt = Convert.ToInt32(co2Binary, 2);
        

        return $"Oxygen binary: {oxygenValueAsInt}; Co2 binary: {co2ValueAsInt}. Therefore the final total is {oxygenValueAsInt * co2ValueAsInt}";
    }

    private char[,] ReturnBinaryArray(string path)
    {
        List<string> binaryStrings = TextFileToListOfStrings.ReturnListOfStrings(path);
        
        // Splitting this into a binary array
        char[,] binaryValues = new char[binaryStrings.Count, binaryStrings[0].Length];

        for (int i = 0; i < binaryStrings.Count; i++)
        {
            for (int j = 0; j < binaryStrings[i].Length; j++)
            {
                binaryValues[i, j] = binaryStrings[i][j];
            }
        }
        return binaryValues;
    }
}