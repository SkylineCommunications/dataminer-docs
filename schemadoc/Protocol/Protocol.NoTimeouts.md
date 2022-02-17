---
uid: Protocol.NoTimeouts
---

# NoTimeouts element

Groups NoTimeout elements.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[NoTimeout](xref:Protocol.NoTimeouts.NoTimeout)|[0, *]|Indicates that the specified error (response value) should not cause a timeout.|

## Remarks

*Feature introduced in DataMiner 8.5.3 (RN 8775).*

## Examples

```xml
<NoTimeouts>
	<NoTimeout>NO SUCH NAME</NoTimeout>
	<NoTimeout>NO SUCH OBJECT</NoTimeout>
	<NoTimeout>TIMEOUT</NoTimeout>
</NoTimeouts>
```
