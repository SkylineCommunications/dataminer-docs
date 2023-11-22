---
uid: Protocol.HTTP.Session-timeout
---

# timeout attribute

Specifies that DataMiner must use this timeout value instead of the default one.

> [!NOTE]
> For a [Connection](xref:Protocol.HTTP.Session.Connection) in this Session, you can override the timeout to be used via the [Connection@timeout](xref:Protocol.HTTP.Session.Connection-timeout) attribute.

## Content Type

unsignedInt

## Parent

[Session](xref:Protocol.HTTP.Session)

## Remarks

The timeout value must be expressed in ms.

*Feature introduced in DataMiner 9.0.2 (RN 12542).*

## Examples

```xml
<Session id="1" timeout="2000">
```
