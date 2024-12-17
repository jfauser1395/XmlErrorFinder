// Get the directory path from the XMLHandler class where recursion is implemented
using XmlErrorFinder.Utilities;

try
{
    // First make sure the XMLFile is in the project's root directory and throw exception if it's missing
    string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "XMLFiles");
    if (!Directory.Exists(fullPath))
    {
        throw new DirectoryNotFoundException($"The directory '{fullPath}' does not exist.");
    }

    // Safe all xml files into the xmlFilePath string and throw exception if XMLFiles directory is empty
    string[] xmlFilePaths = Directory.GetFiles(fullPath);
    if (xmlFilePaths.Length == 0)
    {
        throw new InvalidOperationException(
            "No files found in the XMLFiles directory. Include a valid xml file into the XMLFiles Folder"
        );
    }

    // Make sure the xml file extension is being used
    var fileExtension = Path.GetExtension(xmlFilePaths[0]).ToLower();
    if (fileExtension != ".xml")
    {
        throw new InvalidDataException("Incorrect file extension. Please provide an XML file.");
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
    Console.WriteLine($"Error: {ex.Message}");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch (InvalidDataException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"This file was not found: '{ex.Message}'");
}
catch (IOException ex)
{
    Console.WriteLine($"This file could not be opened: '{ex.Message}'");
}
catch (Exception ex)
{
    Console.WriteLine($"An unexpected error occurred: '{ex.Message}'");
}
