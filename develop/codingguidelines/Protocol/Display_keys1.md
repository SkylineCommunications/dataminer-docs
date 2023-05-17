---
uid: Display_keys1
---

# Display keys

- In case the values in the primary key column are not user-friendly, another column or a combination of other columns must be used to construct a more user-friendly label that is also unique for every row. In case a combination of columns is used, an additional column must be added to the table that contains the result of this combination (see [NamingFormat](https://docs.dataminer.services/develop/schemadoc/Protocol/Protocol.Params.Param.ArrayOptions.NamingFormat.html), [Naming](https://docs.dataminer.services/develop/schemadoc/Protocol/Protocol.Params.Param.ArrayOptions-options.html#naming), [DisplayColumn](https://docs.dataminer.services/develop/schemadoc/Protocol/Protocol.Params.Param.ArrayOptions-displayColumn.html), [DisplayKey](https://docs.dataminer.services/develop/schemadoc/Protocol/Protocol.Params.Param.ArrayOptions.ColumnOption-type.html#displaykey) in the DataMiner Protocol Development Guide). A column of type "displaykey" must be the last column of the table.

- [NamingFormat](https://docs.dataminer.services/develop/schemadoc/Protocol/Protocol.Params.Param.ArrayOptions.NamingFormat.html) should be favored over using the displayColumn attribute. The implementation of displayColumn has an impact on trend data in the database, as the data is stored with a relation between the key and the value of displayColumn. Every time the displayColumn value changes, the database will be updated.

- Existing drivers that use displayColumn should not be changed to use [NamingFormat](https://docs.dataminer.services/develop/schemadoc/Protocol/Protocol.Params.Param.ArrayOptions.NamingFormat.html) (as this will result in loss of data) unless this change is required for a specific reason.

- If no Display Key is explicitely defined in the protocol, the Primary Key will be used as Display Key by default.

- On new implementations, the "\[IDX\]" suffix is not required anymore. However, on existing implementations, removing such "\[IDX\]" suffix is not recommended as it could have some impact on existing systems.
