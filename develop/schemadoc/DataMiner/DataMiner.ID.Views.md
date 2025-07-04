---
uid: DataMiner.ID.Views
---

# Views element

Specifies information about view IDs.

## Parents

[ID](xref:DataMiner.ID)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [current](xref:DataMiner.ID.Views-current) | string |  | Specifies the current view ID. |
| [currentOwn](xref:DataMiner.ID.Views-currentOwn) | string |  | Specifies the current own view ID. |

## Example

```xml
<DataMiner>
  ...
  <ID>
    <Views current="20004" currentOwn="2320001"/>
  </ID>
</DataMiner>
```
