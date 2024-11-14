---
uid: Protocol.PortSettings.SkipCertificateVerification
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
