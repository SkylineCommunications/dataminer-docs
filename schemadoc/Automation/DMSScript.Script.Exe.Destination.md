---
uid: DMSScript.Script.Exe.Destination
---

# Destination element

Specifies the destination

## Type

string

## Parent

[Exe](xref:DMSScript.Script.Exe)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[type](xref:DMSScript.Script.Exe.Destination-type)|string|Yes|Specifies the destination type.|
|[title](xref:DMSScript.Script.Exe.Destination-title)|[NonEmptyStringType](xref:Automation-NonEmptyStringType)||Specifies the title.|
|[cc](xref:DMSScript.Script.Exe.Destination-cc)|string||Specifies the carbon copy (CC) recipient(s).|
|[bcc](xref:DMSScript.Script.Exe.Destination-bcc)|string||Specifies the blind carbon copy (BCC) recipient(s).|

## Remarks

Used in script actions of type "notification" and "report".

## Examples

```xml
<Destination type="email" title="My title" cc="" bcc="">myaccount@mycompany.com;</Destination>
```
