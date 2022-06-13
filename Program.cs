using System.Text;

// Function to compress String - take inputString as a parameter.
string compressString(string inputString)
{
    //CharArray is new array being used to take input as a string and convert it to characters.
    char[] charArray = inputString.ToCharArray();

    // initaialed stringbuilder
    StringBuilder stringCompressed = new StringBuilder();

    //Iterate through all the characters .
    for (int i = 0; i < charArray.Length; i++)
    {
        int counter = 0;
        char compare = charArray[i];
        //checks for if the next character is equals to previous one 
        while (i < charArray.Length - 1 && charArray[i + 1] == compare)
        {
            counter++;
            i++;
        }
        //once counter is greater than 1 add the character to the stringBulider with the counter(occurence)
        if (counter >= 1)
        {
            stringCompressed.Append($"{charArray[i]}{counter + 1}");
        }
        //just return the character to the stringbulider
        else
        {
            stringCompressed.Append(charArray[i]);
        }
    }
    //returning characters by converting them back to string . 
    return stringCompressed.ToString();
}

// Function to Decompress String - take inputString as a parameter.
string decompressString(string inputString)
{
    //creating an empty string to populate 
    string resultString = "";
    //Iterate through all characters in inputString and replace all the numbers with the numbers characters it follows  
    for (int i = 0; i < inputString.Length; i++)
    {
        
        if (inputString[i] >= '0' && inputString[i] <= '9')//Note: Here '9' represents the maximum limit of character it can replace for each instance 
        {
            int counter = Int32.Parse(inputString[i].ToString());

            for (int number = 0; number < counter - 1; number++)
            {
                resultString = resultString + inputString[i - 1];
            }
        }
        else
        {
            resultString = resultString + inputString[i];
        }
    }
    return resultString;
}

string compressStringInput = "HHHHHEEEEELLLLLLOOOOO";
string decompressStringInput = "H5E5L6O9";

Console.WriteLine($"Input for compress String : {(compressStringInput)}");
Console.WriteLine($"Result Compressed : {compressString(compressStringInput)}");


Console.WriteLine($"\nInput for decompress String : {(decompressStringInput)}");
Console.WriteLine($"Result Decompressed : {decompressString(decompressStringInput)}");