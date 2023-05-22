---
uid: Display_keys1
---

# Display keys

- In case the values in the primary key column are not user-friendly, another column or a combination of other columns must be used to construct a more user-friendly label that is also unique for every row. In case a combination of columns is used, an additional column must be added to the table that contains the result of this combination (see [NamingFormat](xref:Protocol.Params.Param.ArrayOptions.NamingFormat), [Naming](xref:Protocol.Params.Param.ArrayOptions-options#naming), [DisplayColumn](xref:Protocol.Params.Param.ArrayOptions-displayColumn), and [DisplayKey](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-type#displaykey)). A column of type "displaykey" must be the last column of the table.

- [NamingFormat](xref:Protocol.Params.Param.ArrayOptions.NamingFormat) should be favored over using the *displayColumn* attribute. The implementation of *displayColumn* has an impact on trend data in the database, as the data is stored with a relation between the key and the value of display column. Every time the display column value changes, the database will be updated.

- Existing protocols that use *displayColumn* should not be changed to use [NamingFormat](xref:Protocol.Params.Param.ArrayOptions.NamingFormat) (as this will result in loss of data) unless this change is required for a specific reason.

- If no Display Key is explicitely defined in the protocol, the Primary Key will be used as Display Key by default.

- On new implementations, the "\[IDX\]" suffix is not required anymore. However, on existing implementations, removing such "\[IDX\]" suffix is not recommended as it could have some impact on existing systems.
