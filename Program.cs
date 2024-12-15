using System.Xml;


string fullPath = Path.Combine(Directory.GetCurrentDirectory(),"XMLFiles");
string[] xmlFilePath = Directory.GetFiles(fullPath);
var fileExtension = Path.GetExtension(xmlFilePath[0]).ToLower();
XmlDocument doc = new XmlDocument();
doc.Load(xmlFilePath[0]);

try
{
    if (doc.DocumentElement != null)
    {

        Console.WriteLine("Finding broken attributes:");
        XmlHandler.FindBrokenAttributes(doc.DocumentElement);
    }
    else
    {
        Console.WriteLine("The XML file has no document element.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
