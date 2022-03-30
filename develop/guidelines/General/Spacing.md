---
uid: Spacing
---

# Spacing

- A semicolon should always be followed by a single space, unless it is the last character on the line. A semicolon should never be preceded by any whitespace, unless it is the first character on the line ([SA1002](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1002)).

- Preprocessor keywords must not be preceded by space ([SA1006](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1006)).

- Operator keyword must be followed by a space ([SA1007](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1007)).

- Member access symbols must be spaced correctly ([SA1019](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1019)). A member access symbol should not have whitespace on either side, unless it is the first character on the line.

- Increment/decrement symbols must be spaced correctly ([SA1020](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1020)). There should be no whitespace between the increment or decrement symbol and the item that is being incremented or decremented.

- Positive/negative signs must be spaced correctly ([SA1022](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1022), [SA1021](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1021)). A positive/negative sign should always be preceded by a single space, unless it comes after an opening square bracket or a parenthesis, or is the first character on the line. A positive/negative sign should never be followed by whitespace, and should never be the last character on a line.

- Colons must be spaced correctly ([SA1024](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1024)).

    - A colon appearing within an element declaration must always have a single space on either side, unless it is the first or last character on the line.

    - When the colon comes at the end of a label or case statement, it must always be followed by whitespace or be the last character on the line, but should never be preceded by whitespace.

    - When a colon is used within a conditional statement, it must always contain a single space on either side, unless the colon is the first or last character on the line.

- Code must not contain multiple whitespace characters in a row ([SA1025](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1025)).

- Within an implicitly typed new array allocation, there should not be any space between the new keyword and the opening array bracket ([SA1026](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1026)).

- Do not split null conditional operators ([SA1029](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1029)). The null conditional symbol ('?.' or '?\[') should not be separated by a new row, space or comment.
