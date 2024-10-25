---
uid: Protocol.Display-pageOptions
---

# pageOptions attribute

Used for EPM elements in order to disable the possibility to open the Data Display page of the element.

## Content Type

string

## Parent

[Display](xref:Protocol.Display)

## Remarks

Used for EPM elements in order to disable the possibility to open the Data Display page of the element. Otherwise, if the Data Display page is opened, the cross-driver table view is entirely constructed, which significantly increases the load on both the server and the client.

> [!NOTE]
> The Administrator user will still be able to load the Data Display page manually.

## Examples

```xml
<Display type="element manager" pageOptions="*;CPEOnly" />
```
