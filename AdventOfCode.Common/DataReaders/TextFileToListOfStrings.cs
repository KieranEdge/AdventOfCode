namespace AdventOfCode.Common.DataReaders;

/// <summary>
/// Class which takes all rows of a text file and returns a list of strings
/// </summary>
public class TextFileToListOfStrings
{
    /// <summary>
    /// Function to take the text file input and return a list of strings
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static List<string> ReturnListOfStrings(string path)
    {
        string[] stringArray = File.ReadAllLines(path);
        return stringArray.ToList();
    }
    
}