using System.Xml;

public class XmlHandler
{
    public static void FindBrokenAttributes(XmlNode node)
    {
        // Base case: if the node is null, return
        if (node == null)
        {
            Console.WriteLine("There are no nodes in this XML file.");
            return;
        }

        // Check attributes of the current node
        if (node.Attributes != null)
        {
            CheckAttributes(node, 0);
        }

        // Recursive case: process each child node
        ProcessChildNodes(node, 0);
    }

    private static void CheckAttributes(XmlNode node, int index)
    {
        // Base case: if all attributes are checked, return
        if (index >= node.Attributes.Count)
        {
            return;
        }

        // Check if the current attribute is broken
        XmlAttribute attr = node.Attributes[index];
        if (string.IsNullOrEmpty(attr.Value))
        {
            Console.WriteLine($"Broken attribute found: {attr.Name} (Node: {node.Name})");
        }

        // Recursive call to check the next attribute
        CheckAttributes(node, index + 1);
    }

    private static void ProcessChildNodes(XmlNode node, int index)
    {
        // Base case: if all child nodes are processed, return
        if (index >= node.ChildNodes.Count)
        {
            return;
        }

        // Process the current child node
        XmlNode child = node.ChildNodes[index];
        FindBrokenAttributes(child);

        // Recursive call to process the next child node
        ProcessChildNodes(node, index + 1);
    }
}

