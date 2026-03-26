---
uid: Protocol.TreeControls.TreeControl.Hierarchy.Table-condition
---

# condition attribute

Specifies a condition.

## Content Type

string

## Parent

[Table](xref:Protocol.TreeControls.TreeControl.Hierarchy.Table)

## Remarks

When using a more advanced hierarchy, the table links can be defined using Table tags. In the hierarchy, the path attribute must be omitted or empty.

If, in this attribute, you specify a condition, this Table tag will only be applied when the specified column parameter contains the specified value.

Format: columnPid:value or columnPid:value;filter:fk=fkColumnPid

Where:

- **columnPid**: Table column parameter ID.
- **value**: Value to match. Note that this is the raw value. For example, if this represents a discrete "1 -> Enabled", you should specify "1", not "Enabled".
- **fkColumnPid**: Table column parameter ID used for the subscription filter "fk=fkColumnPid == d", where d is the primary key of the row matching the columnPid:value condition for which relations get resolved.

The optional `filter:fk=fkColumnPid` part serves as an explicit subscription filter, to be used if there are multiple relations to the same table and the auto-detection mechanism cannot figure it out. If this is not specified, the following auto-detection behavior is applicable:

- If there is a foreignkey column defined, this will be used with a value filter: "value=2005 == xyz"
- If there is no foreignkey column, we assume there is an indirect relation defined, and an fk filter is used: "fk=1001 == xyz"

If you are adding support for a tree control parameter and creating your own M:N relation table with 2 explicit foreign key columns to 2 different tables, you will typically not need to specify this filter. For more information related to M:N relations, refer to the M:N relations.

Example:

```xml
<Hierarchy>
  <Table id="200" parent="100" condition="102:People"/>
  ...
```
