---
uid: Protocol.Params.Param-snapshot
---

# snapshot attribute

Specifies the offload of snapshots of a parameter to the offload database.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

This option is never set on a table, but on the columns that a snapshot should be taken from.

The behavior is the same as the trending attribute, but does not require a trending template. Also, the data will not be stored in the general database, but in the specified offload database. This is done via settings in the Db.xml file.

When this attribute is not present, the snapshot is set to false.

*Feature introduced in DataMiner 8.0.8.4 (RN 7123).*

## Examples

```xml
<Param id="100" snapshot="true">
```
