// Import necessary namespaces
using System.Xml;

// Declare namespace for future references
namespace XmlErrorFinder.Utilities
{
    // XmlHandler extends the XmlDocument class
    public class XmlHandler : XmlDocument
    {
        // Constructor that accepts the full file path as a parameter and loads the XML content
        public XmlHandler(string fullFilePath)
        {
            Load(fullFilePath); // Load the XML content from the file path
        }

        // Method to find and report broken attributes within an XML node and its children
        public static void FindBrokenAttributes(XmlNode node)
        {
            // Check for possible null value of the given node
            if (node == null)
            {
                Console.WriteLine("The node is null.");
                return;
            }

            // Check attributes of the current node
            if (node.Attributes != null)
            {
                CheckAttributes(node, 0);
            }

            // Process each child node recursively
            ProcessChildNodes(node, 0);
        }

        // Method to check attributes of a given node
        private static void CheckAttributes(XmlNode node, int index)
        {
            // check for possible null value of the given attribute
            if (node.Attributes == null)
            {
                Console.WriteLine("Attributes are null");
                return;
            }

            // Base case: if all attributes are checked, return
            if (index >= node.Attributes.Count)
            {
                return;
            }

            // Check if the current attribute is broken (null or empty)
            XmlAttribute attr = node.Attributes[index];
            if (string.IsNullOrEmpty(attr.Value))
            {
                Console.WriteLine($"Broken attribute: {attr.Name} on Node: {node.Name}");
            }

            // Recursive call to check the next attribute
            CheckAttributes(node, index + 1);
        }

        // Method to process each child node of a given node recursively
        private static void ProcessChildNodes(XmlNode node, int index)
        {
            // Base case: if all child nodes are processed, return
            if (index >= node.ChildNodes.Count)
            {
                return;
            }

            // Process the current child node
            XmlNode? child = node.ChildNodes[index];
            if (child != null)
            {
                FindBrokenAttributes(child);
            }

            // Recursive call to process the next child node
            ProcessChildNodes(node, index + 1);
        }
    }
}
