---
uid: Protocol.NoTimeouts
---

# NoTimeouts element

<!-- RN 8775 -->

Groups NoTimeout elements.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[NoTimeout](xref:Protocol.NoTimeouts.NoTimeout)|[0, *]|Indicates that the specified error (response value) should not cause a timeout.|

## Examples

```xml
<NoTimeouts>
   <NoTimeout>NO SUCH NAME</NoTimeout>
   <NoTimeout>NO SUCH OBJECT</NoTimeout>
   <NoTimeout>TIMEOUT</NoTimeout>
</NoTimeouts>
```
