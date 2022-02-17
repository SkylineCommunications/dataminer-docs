---
uid: Protocol.ElementType
---

# ElementType element

Specifies the type of device for which the protocol will be used.

## Type

string

## Parent

[Protocol](xref:Protocol)

## Remarks

The element type will be shown whenever an element is added or edited. It will also be shown in the list of elements on a view card.

When creating a device protocol based on a base protocol, ElementType specifies the element type that is specified in the Protocol@baseFor attribute of the base protocol. See [baseFor](xref:Protocol-baseFor).

## Examples

```xml
<ElementType>Modem</ElementType>
```
