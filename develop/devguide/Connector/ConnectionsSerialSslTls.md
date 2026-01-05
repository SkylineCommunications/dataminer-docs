---
uid: ConnectionsSerialSslTls
---

# SSL/TLS encryption

Elements that request data from a device via a serial port of type TCP/IP support SSL/TLS encryption. This can be configured when creating or editing an element.<!-- RN 23462 -->

DataMiner currently supports all TLS versions up to TLS 1.3 (i.e. all TLS versions supported by OpenSSL 1.1.1). Elements acting as SSL/TLS client will negotiate the highest supported SSL/TLS version with the server. If the server supports TLS up to version 1.2, the element will use version 1.2.

To enhance secure connector communication, SSL/TLS certificates are validated by default for all HTTP elements created after upgrading to DataMiner 10.4.12/10.5.0<!--RN 40877-->. You can disable this default setting or enable it for elements created before a 10.4.12/10.5.0 upgrade in the HTTP(S) connection settings while creating or editing an element in DataMiner Cube.

## See also

- [Enabling TLS encryption for serial communication](xref:Enabling_TLS_encryption)
- For more information about SSL/TLS certification validation, see [HTTP(S) connections](xref:HTTPS_Connection).
