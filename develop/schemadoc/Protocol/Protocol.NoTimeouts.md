---
metadata_version: 1
uid: Protocol.NoTimeouts
description: "Learn how to use the NoTimeouts element to group response values that should not cause communication timeouts in a DataMiner connector protocol."
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
