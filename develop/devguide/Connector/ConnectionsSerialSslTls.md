---
metadata_version: 1
uid: ConnectionsSerialSslTls
description: "Describe the DataMiner connector development topic SSL/TLS encryption, including its purpose, behavior, implementation guidance, and relevant constraints."
---

# SSL/TLS encryption

Elements that request data from a device via a serial port of type TCP/IP support SSL/TLS encryption. This can be configured when creating or editing an element.<!-- RN 23462 -->

DataMiner currently supports all TLS versions up to TLS 1.3 (i.e., all TLS versions supported by OpenSSL 1.1.1). Elements acting as SSL/TLS client will negotiate the highest supported SSL/TLS version with the server. If the server supports TLS up to version 1.2, the element will use version 1.2.

> [!IMPORTANT]
> SSL/TLS connections do not yet support IPv6 destinations. Use an IPv4 destination.

## Enabling/disabling SSL/TLS certificate verification

To enhance secure connector communication, SSL/TLS certificates are validated by default for all HTTP elements created using DataMiner 10.4.12/10.5.0 or higher<!--RN 40877-->.

To enable this setting for elements created prior to DataMiner 10.4.12/10.5.0, edit the elements, and clear the option *Skip SSL/TLS certificate verification (insecure)* in the settings for the HTTP(S) connection.

To disable the default SSL/TLS certificate verification for a specific element, select that same option in the element editor.

## See also

- [DataMiner hardening guide - TLS versions](xref:DataMiner_hardening_guide#tls-versions)
- [Enabling TLS encryption for serial communication](xref:Enabling_TLS_encryption)
- For more information about SSL/TLS certification validation, see [HTTP(S) connections](xref:HTTPS_Connection).
