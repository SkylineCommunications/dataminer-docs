---
uid: ReplaceDisplayColumnByNaming
---

# Replace displayColumn by naming

Switching from using *displayColumn* to naming in a table is considered a major change.

The usage of *displayColumn* only makes the protocol incompatible with Cassandra if the *displaycolumn* value changes.

The *displayColumn* value is used for storing the trend (and alarm keys). When a display column is updated, this breaks the link to the trend/alarm history.

## Impact

Existing trend data is no longer accessible.

*DIS MCC*

| Full ID | Error message                     | Description                                                                                                                      |
|---------|-----------------------------------|----------------------------------------------------------------------------------------------------------------------------------|
| 2.15.1  | DisplayColumnChangedToNaming      | DisplayColumn attribute with column idx '{columnIdx}' on table '{tableId}' was changed into naming options: '{namingValue}'.     |
| 2.15.2  | DisplayColumnChangeToNamingFormat | DisplayColumn attribute with column idx '{columnIdx}' on table '{tableId}' was changed into NamingFormat: '{namingFormatValue}'. |

A request to replace *displayColumn* with naming to make the protocol Cassandra-compliant is usually approved.

## Workarounds

There is no workaround.
