---
metadata_version: 1
uid: Protocol.InternalLicenses
description: "Learn how the InternalLicenses element groups settings that exclude elements based on the protocol from the element license count."
---

# InternalLicenses element

<!-- RN 27933 -->

Configures internal licensing.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[InternalLicense](xref:Protocol.InternalLicenses.InternalLicense)|[1, *]|Configures internal licensing of the specified type.|

## Remarks

Intended for internal use at Skyline Communications only.

## Example

```xml
<Protocol xmlns="http://www.skyline.be/protocol">
  <InternalLicenses>
     <InternalLicense type="solution" />
  </InternalLicenses>
```
