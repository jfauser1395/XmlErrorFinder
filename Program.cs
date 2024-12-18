using AngleSharp;
using AngleSharp.Dom;
using XmlErrorFinder.Utilities;

try
{

    /*################################################################################################################################
      ###################################################### File validation block ###################################################
      ################################################################################################################################*/

    // Ensure the XMLFiles directory exists and throw an exception if it's missing                                                  
    string DirPath = Path.Combine(Directory.GetCurrentDirectory(), "XMLFiles");
    if (!Directory.Exists(DirPath))
    {
        throw new DirectoryNotFoundException($"The directory: '{DirPath}' does not exist.");
    }

    // Save all XML files into the xmlFilePaths string array and throw an exception if the XMLFiles folder is empty
    string[] xmlFilePaths = Directory.GetFiles(DirPath);
    if (xmlFilePaths.Length == 0)
    {
        throw new FileNotFoundException(
            "No files found in the XMLFiles directory. Include a valid XML file in the XMLFiles folder."
        );
    }

    // Declare file name and extension then check the extension validity
    string FirstFileExtension = Path.GetExtension(xmlFilePaths[0]).ToLower();
    string FirstFileName = Path.GetFileName(xmlFilePaths[0]);
    if (string.IsNullOrEmpty(FirstFileExtension))
    {
        throw new InvalidDataException(
            $"File: '{FirstFileName}' has no file extension. Please provide a valid XML file."
        );
    }
    else if (FirstFileExtension != ".xml")
    {
        throw new InvalidDataException(
            $"File: '{FirstFileName}' has an incorrect file extension: '{FirstFileExtension}'. Please provide a valid XML file."
        );
    }

    /*################################################################################################################################
      ####################################################### Xml file processing ####################################################
      ################################################################################################################################*/

    // Read the content of the first XML file asynchronously
    // This reads the entire file into a string variable 'xmlContent'
    string xmlContent = await File.ReadAllTextAsync(xmlFilePaths[0]);

    // Create a new browsing context using AngleSharp with XML configuration
    // 'BrowsingContext' provides an environment to parse and manipulate the document
    var context = BrowsingContext.New(Configuration.Default.WithXml());

    // Parse the XML content into a DOM-like structure using the browsing context
    // The 'OpenAsync' method processes the XML content and returns a document object
    IDocument document = await context.OpenAsync(req => req.Content(xmlContent));

    // Check if the document has a root element (DocumentElement)
    // This ensures that the document was parsed successfully and contains a valid XML structure
    if (document.DocumentElement != null)
    {
        // Process the root element and its children recursively using a custom method 'ProcessNode'
        // This method is assumed to be defined in the 'XmlHandler' class, handling the traversal and processing of the XML nodes
        XmlHandler.FindBrokenAttributes(document.DocumentElement);
    }

    /*################################################################################################################################
      ####################################################### Exception handling #####################################################
      ################################################################################################################################*/

}
catch (DirectoryNotFoundException ex)
{
    Console.WriteLine($"Directory error: {ex.Message}");
    // Additional handling for directory issues if needed
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"File error: {ex.Message}");
    // Additional handling for file issues if needed
}
catch (InvalidDataException ex)
{
    Console.WriteLine($"Data error: {ex.Message}");
    // Additional handling for data issues if needed
}
catch (Exception ex)
{
    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
    // Handle unexpected exceptions
}
