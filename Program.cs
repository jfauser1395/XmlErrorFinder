using System.Xml;
using System.IO;


string[] xmlFiles = Directory.GetFiles("XMLFile", "*.xml");
Console.WriteLine(xmlFiles[0]);
/*
var fileExtension = Path.GetExtension(xmlFilePath).ToLower();
try
{
    if (fileExtension != ".xml")
    {
        throw new InvalidDataException("Incorrect file extension. Please provide an XML file.");
    }

    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xmlFilePath);

    Console.WriteLine("Finding broken attributes:");
    FindBrokenAttributes(doc.DocumentElement);

    static void FindBrokenAttributes(XmlNode node)
    {
        // Base case: if the node is null, return
        if (node == null)
            return;

        // Check attributes of the current node
        if (node.Attributes != null)
        {
            foreach (XmlAttribute attr in node.Attributes)
            {
                if (string.IsNullOrEmpty(attr.Value))
                {
                    Console.WriteLine($"Broken attribute found: {attr.Name} (Node: {node.Name})");
                }
            }
        }

        // Recursive case: process each child node
        foreach (XmlNode child in node.ChildNodes)
        {
            FindBrokenAttributes(child);
        }
    }
}
catch (InvalidDataException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch (FileNotFoundException e)
{
    Console.WriteLine($"This file was not found: '{e}'");
}
catch (DirectoryNotFoundException e)
{
    Console.WriteLine($"This Directory was not found: '{e}'");
}
catch (IOException e)
{
    Console.WriteLine($"This file could not be opened: '{e}'");
}*/