// Get the directory path from the XMLHandler class where recursion is implemented
using XmlErrorFinder.Utilities;

try
{
    // Ensure the XMLFiles directory exists and throw an exception if it's missing
    string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "XMLFiles");
    if (!Directory.Exists(fullPath))
    {
        throw new DirectoryNotFoundException($"The directory: '{fullPath}' does not exist.");
    }

    // Save all XML files into the xmlFilePaths string array and throw an exception if the XMLFiles folder is empty
    string[] xmlFilePaths = Directory.GetFiles(fullPath);
    if (xmlFilePaths.Length == 0)
    {
        throw new FileNotFoundException(
            "No files found in the XMLFiles directory. Include a valid XML file in the XMLFiles folder."
        );
    }

    // Declare file name and extension then check the extension validity
    string fileExtension = Path.GetExtension(xmlFilePaths[0]).ToLower();
    string fileName = Path.GetFileName(xmlFilePaths[0]);
    if (string.IsNullOrEmpty(fileExtension))
    {
        throw new InvalidDataException(
            $"File: '{fileName}' has no file extension. Please provide a valid XML file."
        );
    }
    else if (fileExtension != ".xml")
    {
        throw new InvalidDataException(
            $"File: '{fileName}' has an incorrect file extension: '{fileExtension}'. Please provide a valid XML file."
        );
    }

    //// XmlHandler class instantiation
    //XmlHandler xmlDoc = new(xmlFilePaths[0]);
    ////Passing the xml document into recursive function of the XmlHandler class
    //if (xmlDoc.DocumentElement != null)
    //{
    //    XmlHandler.FindBrokenAttributes(xmlDoc.DocumentElement);
    //}
}
catch (DirectoryNotFoundException ex)
{
    Console.WriteLine($"Error: '{ex.Message}'");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"Error: '{ex.Message}'");
}
catch (InvalidDataException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch (IOException ex)
{
    Console.WriteLine($"This file could not be opened: '{ex.Message}'");
}
catch (Exception ex)
{
    Console.WriteLine($"An unexpected error occurred: '{ex.Message}'");
}
