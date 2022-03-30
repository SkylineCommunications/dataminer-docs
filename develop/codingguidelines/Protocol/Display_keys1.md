---
uid: Display_keys1
---

# Display keys

- In case the values in the primary key column are not user-friendly, another column or a combination of other columns must be used to construct a more user-friendly label that is also unique for every row. In case a combination of columns is used, an additional column must be added to the table that contains the result of this combination (see Naming, NamingFormat, DisplayColumn, DisplayKey in the DataMiner Protocol Development Guide). A column of type "displaykey" must be the last column of the table.

- Naming should be favored over using the displayColumn attribute. The implementation of displayColumn has an impact on trend data in the database, as the data is stored with a relation between the key and the value of displayColumn. Every time the displayColumn value changes, the database will be updated.

- Existing drivers that use displayColumn should not be changed to use naming (as this will result in loss of data) unless this change is required for a specific reason.
