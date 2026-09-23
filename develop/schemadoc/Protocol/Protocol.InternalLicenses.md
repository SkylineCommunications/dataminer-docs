---
metadata_version: 1
uid: Protocol.InternalLicenses
description: "Reference the DataMiner connector protocol schema entry for InternalLicenses element, including its documented structure, attributes, values, and constrai."
content_type: schema
applies_to:
  - DataMiner
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
