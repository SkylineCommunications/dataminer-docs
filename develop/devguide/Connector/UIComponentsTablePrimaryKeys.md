---
uid: UIComponentsTablePrimaryKeys
---

# Primary keys

A table must always contain a column that has a unique value for every row in the table and which is used to refer to a row unambiguously. This is typically referred to as the primary key. The index attribute of the ArrayOptions tag defines the column index of the column that holds the primary keys.

Please keep the following guidelines in mind for primary keys:

- The first column of a table should hold the primary keys (index = 0).
- The column that holds the primary keys must be of type "string".
- The primary key does not have to be user-friendly and should be as small as possible.
- A primary key must not have leading or trailing whitespace.
- Semicolons (`;`), question marks (`?`) and asterisks (`*`) must be avoided in primary keys as these characters have a special meaning in the dynamic table filter syntax and could therefore cause table filter queries to be interpreted incorrectly. (Refer to the [Dynamic Table Filter Syntax](xref:Dynamic_table_filter_syntax).)
