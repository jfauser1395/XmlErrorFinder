using AngleSharp.Dom;



namespace XmlErrorFinder.Utilities
{
    public class XmlHandler
    {

        //Method to find and report broken attributes within an XML node and its children
        public static void FindBrokenAttributes(INode node)
        {
            // Check attributes of the current node
            CheckAttributes(node, 0);


            // Process each child node recursively
            ProcessChildNodes(node, 0);
        }


        // Method to check attributes of a given node
        private static void CheckAttributes(INode node, int index)
        {
            // verify node is an element
            if (node is IElement element)
            {
                // Base case: if all attributes are checked, return
                if (index >= element.Attributes.Length)
                {
                    return;
                }

                IAttr? attribute = element.Attributes[index];
                if (attribute != null)
                {
                    Console.WriteLine(
                        $"Attribute '{attribute.Name}' has value '{attribute.Value}' in element '{element.TagName}'"
                    );
                }

                // Recursive call to check the next attribute
                CheckAttributes(node, index + 1);
            }
        }

        // Method to process each child node of a given node recursively
        private static void ProcessChildNodes(INode node, int index)
        {
            // Base case: if all child nodes are processed, return
            if (index >= node.ChildNodes.Length)
            {
                return;
            }

            // Process the current child node
            INode? child = node.ChildNodes[index];
            if (child != null)
            {
                FindBrokenAttributes(child);
            }

            // Recursive call to process the next child node
            ProcessChildNodes(node, index + 1);
        }
    }
}
