---
uid: Layout
---

# Layout

In order to improve readability, consider the following layout guidelines:

- Allman bracing style should be used, e.g., the curly brace associated with a control statement must be placed on the next line and must be indented to the same level as the control statement. Statements within the braces are indented to the next level ([SA1500](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1500), [SA1501](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1501), [SA1502](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1502)).

    ```txt
    if (slKeysToDelete.Count > 0) { protocol.DeleteRow(16000, slKeysToDelete.ToArray()); }
    ```

- In general, curly braces should never be considered optional ([SA1503](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1503)). For statements where curly braces are optional, these may only be omitted if the statement is written on a single line.

    > [!NOTE]
    > This rule is not enabled in the StyleCop configuration file.

- The accessors within a property, indexer or event must either all be written on a single line or all be written on multiple lines ([SA1504](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1504)).

- Opening curly braces must not be preceded or followed by a blank line ([SA1509](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1509), [SA1505](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1505)) and closing curly braces must not be preceded by a blank line ([SA1508](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1508)). Closing curly braces must be followed by a blank line, unless the next line is a closing curly brace ([SA1513](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1513)).

- An XML documentation header above an element must not be followed by a blank line ([SA1506](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1506)) and must be preceded by a blank line ([SA1514](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1514)).

- Code must not contain multiple blank lines in a row ([SA1507](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1507)).

- Chained statement blocks must not be preceded by a blank line ([SA1510](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1510)).

- The while footer of a do-while statement must not be separated from the statement by a blank line ([SA1511](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1511)).

- Adjacent C# elements must be separated by a blank line ([SA1516](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1516)), e.g., a blank line should be provided between property definitions and method definitions.

- Code must not contain blank lines at the start and end of the file ([SA1517](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1517), [SA1518](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1518)).
