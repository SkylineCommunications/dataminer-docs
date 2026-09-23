---
metadata_version: 1
uid: Protocol.NoTimeouts.NoTimeout
description: "Learn how to use the NoTimeout element to identify a response value that should not cause a communication timeout in a DataMiner connector protocol."
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
