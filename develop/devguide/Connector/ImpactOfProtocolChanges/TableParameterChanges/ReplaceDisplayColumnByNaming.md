---
uid: ReplaceDisplayColumnByNaming
---

# Replace display column by naming

Replacing the display column by naming in a table is considered a major change.

The usage of *displayColumn* by itself does not make the driver incompatible with *Cassandra*. That is true if the *displaycolumn* value changes.

The *displaycolumn* value is used for storing the trend (and alarming keys), when a *displaycolumn* updates it breaks the link to the trending/alarm history.

## Impact

Existing trend data is no longer accessible.

*DIS MCC*

| Full ID | Error message | Description |
|---------|---------------|-------------|
| 2.15.1  | DisplayColumnChangedToNaming | DisplayColumn attribute with column idx '{columnIdx}' on table '{tableId}' was changed into naming options: '{namingValue}'. |
| 2.15.2  | DisplayColumnChangeToNamingFormat | DisplayColumn attribute with column idx '{columnIdx}' on table '{tableId}' was changed into NamingFormat: '{namingFormatValue}'. |

A request to replace the *displayColumn* by naming to make the driver 'Cassandra Compliant' is usually approved.

## Workarounds

There is no workaround.