---
uid: Primary_keys1
---

# Primary keys

- A table always contains a column where each row has a unique value identifying the row, i.e. the column containing the primary keys. This must be the first column in the table.

- In the DataMiner MySQL database, the first 100 bytes of a row key must be unique. Otherwise, unexpected behavior can occur, e.g. some rows will be visible in a table but not stored in the database. UTF-8-character encoding is used by default, which encodes a character in as many bytes as required, with a maximum of 4. Characters from the ASCII character set are encoded using a single byte, so the first 100 characters must be unique. In a worst-case scenario, all characters take up 4 bytes, meaning that the first 25 characters must be unique.

- Numeric keys are more efficient than long non-numeric keys. In order to improve performance, the use of an auto increment key should be considered instead of long non-numeric keys, if applicable.

- Backslashes are not allowed in the primary keys because MySQL does not allow these.

- Leading and trailing spaces should be avoided in primary keys (as well as in display keys).
