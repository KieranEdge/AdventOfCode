namespace AdventOfCode.Common.DataReaders;

/// <summary>
/// This class takes text files as inputs and outputs them to list values
/// </summary>
public class TextFileToListOfInts
{
    /// <summary>
    /// Takes a text file with rows of integers and returns a list of integers
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static List<int> ReturnListOfIntsFromTextFile(string path)
    {
        string[] listOfIntsAsStrings = File.ReadAllLines(path);
        List<int> listOfIntsFromTextFile = new List<int>();
        foreach (string str in listOfIntsAsStrings)
        {
            listOfIntsFromTextFile.Add(int.Parse(str));
        }
        return listOfIntsFromTextFile;
    }
}