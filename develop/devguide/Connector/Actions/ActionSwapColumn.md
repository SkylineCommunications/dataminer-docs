---
uid: LogicActionSwapColumn
---

# swap column

This action must be executed on protocol.

This action copies the data from a source column into a destination column, and then clears the source column.

## Attributes

### Type@options

Contains a fixed format: swap:tableID:sourceColumnID:destinationColumnID

## Examples

In the following example, in the table with parameter ID 2200, the contents of the column with parameter ID 17 will be copied into the column with parameter ID 20, and then the contents of the column with parameter ID 17 will be cleared:

```xml
<Action id="1">
   <On>protocol</On>
   <Type options="swap:2200:17:20">swap column</Type>
</Action>
```
