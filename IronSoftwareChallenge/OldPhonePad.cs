namespace IronSoftwareChallenge;

/// <summary>
/// Class <c>OldPhonePad</c> converts the input on an old phone into a human readable message
/// </summary>
/// <param name="input"></param>
public class OldPhonePad(string input)
{
    private readonly string input = input;
    public string[] inputParts = [];
    private readonly Dictionary<string, char> inputMapping = new() {
        {"0", ' '}, {"1", '&'}, {"11", '\''}, {"111", '('}, {"2", 'a'}, {"22", 'b'}, {"222", 'c'},
        {"3", 'd'}, {"33", 'e'}, {"333", 'f'}, {"4", 'g'}, {"44", 'h'}, {"444", 'i'},
        {"5", 'j'}, {"55", 'k'}, {"555", 'l'}, {"6", 'm'}, {"66", 'n'}, {"666", 'o'},
        {"7", 'p'}, {"77", 'q'}, {"777", 'r'}, {"7777", 's'}, {"8", 't'}, {"88", 'u'}, {"888", 'v'},
        {"9", 'w'}, {"99", 'x'}, {"999", 'y'}, {"9999", 'z'}, {"#", '#'}, {"*", '*'}
    };

    /// <summary>
    /// Method <c>ConvertInput</c> converts the input into the `old phone pad` into the human readable message
    /// </summary>
    /// <returns>The corresponding message based on input</returns>
    /// <exception cref="ArgumentException"></exception>
    public string ConvertInput()
    {
        char[] inputChars = input.ToCharArray();

        // ensure the input ends in a # character
        if (inputChars.Last() != '#')
        {
            throw new ArgumentException("Invalid input. Messages must end with a # symbol.");
        }

        inputParts = BuildInputParts(inputChars);

        return BuildOutputString();
    }
    /// <summary>
    /// Method <c>BuildOutputString</c> uses the <c>inputMapping</c> property to generate the final message string
    /// </summary>
    /// <returns>The fully converted message, from numeric keypad input to a human readable string</returns>
    private string BuildOutputString()
    {
        string output = string.Empty;
        // build the string by mapping input parts to their associated characters
        foreach (string s in inputParts)
        {
            char charFromMapping = inputMapping[s];
            output += charFromMapping;
        }

        return output;
    }

    /// <summary>
    /// Method <c>BuildInputParts</c> splits the user inputted string up into its constituent character representations
    /// </summary>
    /// <param name="inputChars">char array of the input string</param>
    /// <returns>string array containing the individual character representations e.g. ["22", "3", "444"]</returns>
    private static string[] BuildInputParts(char[] inputChars)
    {
        List<string> inputPartsList = [];
        string currentPattern = string.Empty;

        foreach (var ic in inputChars)
        {
            // This is the start of a new pattern 
            if (currentPattern.Length == 0)
            {
                currentPattern += ic;
            }
            // if the current pattern is made of the same symbols as the current input char, append it to the pattern
            else if (ic == currentPattern[0])
            {
                currentPattern += ic;
            }
            // the current input char is different to the current pattern, i.e. a different letter
            else
            {
                inputPartsList.Add(currentPattern);
                // do not assign spaces to the current pattern as they are irrelevant
                if (ic == ' ')
                {
                    currentPattern = string.Empty;
                }
                else
                {
                    currentPattern = ic.ToString();
                }
            }
        }

        return [.. inputPartsList];
    }
}
