---
uid: ConnectionsHttpParsingHtml
---

# Parsing HTML

Different approaches are possible for the retrieval of information from HTML documents.

Depending on the use case, one method or the other might perform better. For example, in case a single value needs to be retrieved from a small HTML document, it is likely that the string-based method will outperform the other methods. However, as soon as multiple pieces of information need to be retrieved, the other methods may start to outperform the string-based methods. It is advised to execute some performance checking before you choose a specific approach.

## String-based

### IndexOf

Using the IndexOf method is the most basic way to obtain data from an HTML string. This is a text-based approach, regarding the HTML document as just a string.

#### Advantages

- Very high performance.
- Flexible approach since it ignores the structure of the HTML.

#### Disadvantages

- Bad code readability and maintainability. If there is a change in the data structure, this is the worst scenario for changes, especially if the code has not been reviewed in a long time.
- Very prone to exceptions (indexes have this inseparable disadvantage), so extra care should be taken when coding with this approach.
- Querying is hard to generalize, sometimes requiring several methods for different searches.

#### Recommendation

- Only use this approach when either one of the other approaches is not feasible, or in very simple scenarios (e.g., to fetch a single piece of information from an HTML document that is very static in nature).

### Regular expressions

Another possible approach to obtain information from an HTML document is via regular expressions. Like substrings, these are based on treating the HTML code as a string, and searching for specific matches.

#### Advantages

- Very high performance.
- Code readability is better than the substring approach, maintainability is also good.
- Less prone to exceptions, if coded properly.
- Flexible approach, since it ignores the structure of the HTML.

#### Disadvantages

- Querying, while better than the substring approach, is inflexible.

#### Recommendation

- Can be used when performance is important and the query is very simple or straightforward (e.g., to fetch a single piece of data from a whole HTML document that is static in nature, with rather static text).

## JavaScriptSerializer

This is an object-oriented approach to HTML parsing and querying.

### Advantages

- Performance is good, as serializing/deserializing objects is rather fast.
- Querying is very good, since it transforms an HTML string into a structured class, which can contain lists, dictionaries, and other very searchable groups of content. Using LINQ as a query tool is extremely powerful and should provide acceptable performance.
- Code maintainability and readability is very good, as everything should be properly structured in classes.

### Disadvantages

- Inflexible approach, as it requires the developer to typically have a very strict class definition. If the HTML changes frequently, it may have a tendency to break or not deserialize the HTML document properly.
- Sensitive to the lax structure of HTML. While HTML has a defined structure, it is very lax compared to XML or JSON, especially with the lack of tag closure enforcement. HTML code with unclosed tags is extremely common, and this approach cannot deal with this.
- Requires a lot more setup and code than any other approach.

### Recommendation

- Only really useful with XHTML, since XHTML has stricter syntax compared to HTML. Proper class structure should be considered, to allow text tags to be ignored, for example.

## HTML Agility Pack

The HTML Agility Pack (HAP) provides an object-oriented approach for reading/writing HTML documents. Instead of treating the HTML as a hard-coded class, it treats it as a tree structure.

> [!NOTE]
> HtmlAgilityPack.dll (1.6.4) is included in the *ProtocolScripts* folder by default.<!-- RN 16746 -->

### Advantages

- Good performance.
- Code readability and maintainability is good.
- Easy to query the HTML document, allowing both LINQ and XPath queries.
- Flexible approach, since it does not require fixed classes, while still allowing a structured approach.
- Resilient to the lax structure of HTML, provided the right options are active when loading the HTML document.

### Disadvantages

- Performance is worse than with string-based approaches. In cases where performance is very important, it is possible that a string-based approach should be used.
- Requires an external DLL, which may not be available in legacy DataMiner versions.

### Recommendation

- Whenever there is a need to query an HTML document for several pieces of data, this is the best possible approach. Performance will be sufficient for most cases, with a lot of powerful query tools, and the code is maintainable and easy to follow.

### HTML Agility Pack API

For information about how to use the HTML Agility pack, refer to the HTML Agility Pack API page: <http://html-agility-pack.net/api>.

For more information about XPath, refer to:

- <https://www.w3.org/TR/1999/REC-xpath-19991116/> (XML Path Language (XPath) Version 1.0)
- <https://www.w3schools.com/xml/xpath_intro.asp> (W3Schools XPath tutorial)
- <http://videlibri.sourceforge.net/cgi-bin/xidelcgi> (Online XPath Query Tester)

## Examples

- **Parsing HTML**

  The following snippet shows how to create an HtmlDocument instance from an HTML document string that is stored in a protocol parameter.

    ```csharp
    string html = protocol.GetParameter(id);
    HtmlDocument htmlTree = new HtmlDocument()
    { OptionFixNestedTags = true, OptionEmptyCollection = true };
    
    htmlTree.LoadHtml(html);
    ```

  The options provided on document creation are used as follows:

  - *OptionFixNestedTags*: If an error is detected when parsing LI, TR, TH, and TD tags, this option attempts to fix them enough for them to be loaded.
  - *OptionEmptyCollection*: When using the SelectNodes method, this option makes it return empty collections instead of null, when the select fails. Avoids issues with NullPointerException.

  Once loaded, the data can be queried.

- **Accessing individual nodes**

  It is possible to iterate over nodes directly, in two ways. First, it is possible to iterate over all nodes as if they are a normal collection, using something like the following code (assuming htmlTree is the HtmlDocument object with the HTML loaded):

    ```csharp
    foreach (HtmlNode item in hapDoc.DocumentNode.Descendants())
    {

    }
    ```

  This code will go through all the nodes present in the tree, without caring about their relation with one another, effectively ignoring the tree structure. If there is a need to list something or to go through all the nodes, this is the simplest code.

  Another way is to actually navigate the tree. For example:

    ```csharp
    htmlTree.DocumentNode.ChildNodes[2].ChildNodes[1].ChildNodes[3].Attributes[1].Value
    ```

  While this is not a practical approach, it can be used in case a specific node must be accessed, as long as the developer knows the structure.

- **XPath Queries**

  XPath is a W3C recommendation for addressing parts of an XML document. Since XML and HTML are similar in their tree-like structures, it becomes possible to use this query type. The queries are done based on the SelectSingleNode and the SelectNodes methods. The methods receive a query string, and return an HtmlNode or a collection of HtmlNodes, respectively. Depending on the goal of the query, one or the other might be preferred.

  Below you can find some examples of how to use XPath.

  - All TR elements containing a td tag

    ```csharp
    htmlTree.DocumentNode.SelectSingleNode("//tr[td]");
    ```

  - All TR elements with text "ok" and an input element with attribute "name"

    ```csharp
    htmlTree.DocumentNode.SelectSingleNode("//tr[td='OK' and td//input/@name]");
    ```

  - Obtain the vFlex version

    ```csharp
    htmlTree.DocumentNode.SelectSingleNode("//tbody[tr/td='Version Information']/tr[td[.='vFlex']]/td[2]");
    ```

  > [!NOTE]
  > More examples of XPath queries can be found on the following MSDN page: https://msdn.microsoft.com/en-us/library/ms256086(v=vs.110).aspx.

- **LINQ Queries**

  LINQ is part of the .NET FCL, and querying collections with it can yield very good results.

  - All TR elements related to the PSU status

    ```csharp
    IEnumerable<HtmlNode> itemList = from node in htmlTree.DocumentNode.Descendants()

    where node.Name.Equals("tr") && node.InnerText.Contains("PSU")

    select node;
    ```

  - All TR elements related to the module summary

    ```csharp
    IEnumerable<HtmlNode> itemList = from node in htmlTree.DocumentNode.Descendants()

    where node.Name == "tr" && (node.Descendants().Select(x => x.Name.Equals("input")).Contains(true))

    select node;
    ```

  - Obtain the status of the vFlex module

    ```csharp
    IEnumerable<HtmlNode> itemList = from node in htmlTree.DocumentNode.Descendants()
    
    where node.Name == "tr" && (node.Descendants().Select(x => x.Name.Equals("input") && x.Attributes.Select(y => y.Value.Equals("vFlex")).Contains(true)).Contains(true))
    
    select node;
    ```
