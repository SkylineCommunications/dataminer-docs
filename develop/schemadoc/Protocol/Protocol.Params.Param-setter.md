---
metadata_version: 1
uid: Protocol.Params.Param-setter
description: "Reference the DataMiner connector protocol schema entry for setter attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# setter attribute

Specifies whether the value of the write parameter will be copied to the corresponding read parameter (without the need to add a trigger or an action).

Refer to [Parameter change events](xref:LogicParameters#parameter-change-events) for more information on when the set is executed in relation to other operations. For example, if a read-write parameter combination uses the setter=true option, a trigger goes off when the value of the write parameter changes, and the write parameter also triggers a QAction, the order of execution is the following:

1. The regular triggers on the write parameter are executed. Actions executed by these triggers will not yet see the read parameter value adapted to the new write parameter value. The read parameter will still have the old value at this point.
1. The setter is executed, which results in the value being copied to the read parameter.
1. The QActions on the write parameter are executed. The read parameter will have the same value as the write parameter at this point.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

Default value: false.

> [!NOTE]
>
> - If the button is part of a table and no corresponding read parameter is present, the write parameter may execute its triggers or actions a second time.

## Examples

```xml
<Param id="1" setter="true">
```
