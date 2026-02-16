---
uid: Commenting
---

# Commenting

- Unless a comment is very short, comments should always start on a new line.

- A single line comment must be preceded by a blank line ([SA1515](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1515)) and must not be followed by a blank line ([SA1512](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1512)).

- A space should be inserted between the comment delimiter (i.e., "//") and the comment text ([SA1005](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1005)).

- For comments spanning multiple lines, the use of single-line syntax "//" is favored over using "/\* \*/".

- Creation of formatted comment boxes (e.g., through the use of asterisks) should be avoided.

- Comments should be indented at the same level as the code they describe.

- Single-line comments must not use XML documentation style slashes ([SA1626](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1626)). Comments beginning with three slashes are reserved for XML documentation headers.

- Block statements must not contain embedded comments ([SA1108](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1108)).

- When you comment out lines of code, begin the comment with four slashes to differentiate it from normal comments.

- A comment should begin with an uppercase letter and end with a period.

- Comments should not contain spelling mistakes.

- If meaningful variable and method names are used, the code should already be readable. Therefore, comments should only be added in case these will further clarify the code.
