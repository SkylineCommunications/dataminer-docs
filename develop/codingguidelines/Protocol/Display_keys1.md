---
uid: Display_keys1
---

# Display keys

- In case the values in the primary key column are not user-friendly, another column or a combination of other columns must be used to construct a more user-friendly label that is also unique for every row. In case a combination of columns is used, an additional column must be added to the table that contains the result of this combination (see [NamingFormat](xref:Protocol.Params.Param.ArrayOptions.NamingFormat), [Naming](xref:Protocol.Params.Param.ArrayOptions-options#naming), [DisplayColumn](xref:Protocol.Params.Param.ArrayOptions-displayColumn), and [DisplayKey](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-type#displaykey)). A column of type "displaykey" must be the last column of the table.

- [NamingFormat](xref:Protocol.Params.Param.ArrayOptions.NamingFormat) should be favored over using the *displayColumn* attribute. The implementation of *displayColumn* has an impact on trend data in the database, as the data is stored with a relation between the key and the value of display column. Every time the display column value changes, the database will be updated.

- Existing protocols that use *displayColumn* should not be changed to use [NamingFormat](xref:Protocol.Params.Param.ArrayOptions.NamingFormat) (as this will result in loss of data) unless this change is required for a specific reason.

- By default, if no display key is explicitly defined in the protocol, the primary key will be used as the display key.

- In new implementations, the "\[IDX\]" suffix is no longer required. However, in existing implementations, removing this "\[IDX\]" suffix is not recommended, as this could have an impact on existing systems.
