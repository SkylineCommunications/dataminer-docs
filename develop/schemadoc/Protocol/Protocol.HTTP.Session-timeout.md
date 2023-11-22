---
uid: Protocol.HTTP.Session-timeout
---

# timeout attribute

Specifies that DataMiner must use this timeout value instead of the default one (or the one specified in the Connection tag) when executing this connection of this session.

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
