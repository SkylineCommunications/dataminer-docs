---
metadata_version: 1
uid: Protocol.NoTimeouts.NoTimeout
description: "Reference the DataMiner connector protocol schema entry for NoTimeout element, including its documented structure, attributes, values, and constraints."
---

# NoTimeout element

Indicates that the specified error (response value) should not cause a timeout.

## Type

string

## Parent

[NoTimeouts](xref:Protocol.NoTimeouts)

## Remarks

Contains a value of type String (plain text or hexadecimal).

> [!NOTE]
> Although it is allowed to add multiple NoTimeout elements directly under the Protocol root element, grouping all NoTimeout elements in the NoTimeouts element is preferred.

## Examples

```xml
<NoTimeout>NO SUCH OBJECT</NoTimeout>
```
