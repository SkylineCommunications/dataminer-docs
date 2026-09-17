---
metadata_version: 1
uid: Protocol.PortSettings.SkipCertificateVerification
description: "Reference the DataMiner connector protocol schema entry for SkipCertificateVerification element, including its documented structure, attributes, values, a."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: 10.4.12
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# SkipCertificateVerification element

Specifies settings related to the verification process of SSL/TLS certificates. Feature introduced in DataMiner 10.4.12 (RN 40877, RN 41285).

Only applicable for connections of type HTTP.

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[DefaultValue](xref:Protocol.PortSettings.SkipCertificateVerification.DefaultValue)|[0, 1]|Specifies whether the SSL/TLS certificate verification should be skipped by default.|
|&nbsp;&nbsp;[Disabled](xref:Protocol.PortSettings.SkipCertificateVerification.Disabled)|[0, 1]|Specifies whether the DataMiner user interface can be used to configure if the SSL/TLS certificate verification is skipped.|
