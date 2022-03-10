---
uid: Protocol.InternalLicenses
---

# InternalLicenses element

Configures internal licensing.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[InternalLicense](xref:Protocol.InternalLicenses.InternalLicense)|[1, *]|Configures internal licensing of the specified type.|

## Remarks

Intended for internal use at Skyline Communications only.

*Feature introduced in DataMiner 10.0.13 (RN 27933).*

## Example

```xml
<Protocol xmlns="http://www.skyline.be/protocol">
  <InternalLicenses>
     <InternalLicense type="solution" />
  </InternalLicenses>
```
