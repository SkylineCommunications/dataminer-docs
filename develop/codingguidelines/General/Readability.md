---
uid: Readability
---

# Readability

- Do not prefix calls with *base* unless a local implementation exists ([SA1100](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1100)).

- There should be only one declaration per line.

- Code must not contain empty statements ([SA1106](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1106)).

- There should be only one statement per line ([SA1107](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1107)).

- Method parameter placement/indexer:

    - The opening parenthesis must be on the declaration line ([SA1110](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1110)).

    - The closing parenthesis must be on line of the last parameter ([SA1111](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1111)).

    - In case a method or indexer does not take any parameters, the closing parenthesis must be on the line of the opening parenthesis ([SA1112](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1112)).

    - A comma must be on the same line as the previous parameter ([SA1113](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1113)).

    - A parameter list must follow the declaration ([SA1114](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1114)).

    - A parameter must follow a comma ([SA1115](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1115)). Ensure that the parameter begins on the same line as the previous comma, or on the next line.

    - Split parameters must start on the line after the declaration ([SA1116](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1116)).

    - Parameters must all be on the same line or each on a separate line ([SA1117](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1117)).

    - A parameter must not span multiple lines ([SA1118](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1118)).

        It is preferred to write a method call in a single line. When this line becomes too long, you can either:

        - Introduce one or more temporary variables that hold the parameter values and pass those as parameters (this is the preferred option), or

        - Let every parameter start on a new line.

- Use String.Empty for empty strings ([SA1122](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1122)).

- The use of C# type aliases should be favored over the use of the predefined types in the System namespace (e.g., use string *sUserName* instead of String *sUserName*), except when calling static members (e.g., use *String.IsNullOrEmpty(sResponse)* instead of *string.IsNullOrEmpty(sResponse)*) ([SA1121](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1121)).

    > [!NOTE]
    > As StyleCop rule SA1121 also expects to use C# type aliases for static members, this rule has not been enabled in the StyleCop configuration file.

- Use shorthand notation for nullable types ([SA1125](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1125)).

- Query clauses:

    - A query clause must follow the previous clause ([SA1102](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1102)).

    - Query clauses must either each be on a separate line or all be on one line ([SA1103](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1103)).

    - A query clause must begin on a new line when previous clause spans multiple lines ([SA1104](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1104)).

    - Query clauses spanning multiple lines must begin on a new line ([SA1105](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1105)).

- Comments must contain text ([SA1120](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1120)).
