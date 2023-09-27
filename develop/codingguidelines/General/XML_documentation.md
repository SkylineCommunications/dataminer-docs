---
uid: XML_documentation
---

# XML documentation

> [!NOTE]
> For more information about XML documentation, refer to:
>
> - [Document your code with XML comments](https://docs.microsoft.com/en-us/dotnet/csharp/codedoc)
> - [How to: Insert XML comments for documentation generation](https://docs.microsoft.com/en-us/visualstudio/ide/reference/generate-xml-documentation-comments?view=vs-2019)
> - [XML documentation comments (C# Programming Guide)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/xml-documentation-comments)

- When useful, (partial) elements should be documented ([SA1600](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1600), [SA1601](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1601)).

    > [!NOTE]
    > These rules are not enabled in the StyleCop configuration file. However, for manager protocols or protocols implementing complex functionality, elements should be documented when useful (e.g. shared QActions).

- Documentation must contain valid XML ([SA1603](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1603)).

- (Partial) element documentation must have a summary ([SA1604](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1604), [SA1605](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1605)).

- (Partial) element documentation must have summary text ([SA1606](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1606), [SA1607](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1607)) that differs from the default summary text ([SA1608](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1608)).

- Documentation lines must begin with a single space ([SA1004](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1004)).

- Element parameters

    - Element parameters must be documented ([SA1611](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1611)).

    - Element parameter documentation must match element parameters ([SA1612](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1612)).

    - Element parameter documentation must declare the parameter name ([SA1613](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1613)).

    - Element parameter documentation must have text ([SA1614](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1614)).

- The element return value must be documented ([SA1615](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1615), [SA1616](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1616)).

- A void return type must not be documented ([SA1617](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1617)).

- Generic type parameters

    - Generic type parameters must be documented ([SA1618](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1618), [SA1619](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1619)).

    - Generic type parameter documentation must match the type parameters ([SA1620](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1620)).

    - Generic type parameter documentation must declare a parameter name ([SA1621](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1621)).

    - Generic type parameter documentation must have text ([SA1622](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1622)).

- Property summary documentation must match accessors ([SA1623](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1623)). The property's summary text must begin with wording describing the types of accessors exposed within the property. If the property contains only a get accessor, the summary must begin with the word "Gets". If the property contains only a set accessor, the summary must begin with the word "Sets". If the property exposes both a get and set accessor, the summary text must begin with "Gets or sets".

    If the property returns a Boolean value, an additional rule is applied. The summary text for Boolean properties must contain the words "Gets a value indicating whether", "Sets a value indicating whether", or "Gets or sets a value indicating whether".

- Property summary documentation must omit set accessors with restricted access ([SA1624](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1624)). When an accessor within the property is given an access level that is more limited than the access level of the property, this accessor should be omitted from the summary documentation.

- Element documentation must not be copied and pasted ([SA1625](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1625)).

- Documentation text:

    - Documentation text must begin with an uppercase letter and end with a period ([SA1628](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1628), [SA1629](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1629)).

    - Documentation text must contain whitespace ([SA1630](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1630)).

    - Documentation text must meet the character percentage ([SA1631](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1631)). This rule is calculated by counting the number of alphabetic characters and numbers within the documentation text, and comparing it against the number of symbols and other non-alphabetic characters.

    - Documentation text must meet the minimum character length ([SA1632](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1632)).

- Constructor summary text must begin with "Initializes a new instance of the {class name} class." ([SA1642](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1642)).

- Destructor summary text must begin with "Finalizes an instance of the {class name} class." ([SA1643](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1643)).

- The documentation header must not contain blank lines ([SA1644](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1644)).

- An included Documentation XPath must contain a valid path ([SA1646](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1646)).

- An include node must contain a valid path ([SA1647](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1647)).

- \<inheritdoc> must be used with inheriting class ([SA1648](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1648)).
