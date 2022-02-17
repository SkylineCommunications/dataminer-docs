---
uid: ConnectionsSerialSslTls
---

# SSL/TLS encryption

From DataMiner 10.0.3 (RN 23462) onwards, elements that request data from a device via a serial port of type TCP/IP support SSL/TLS encryption. This can be configured when creating or editing an element.

DataMiner currently supports all TLS versions up to TLS 1.3 (i.e. all TLS versions supported by OpenSSL 1.1.1). Elements acting as SSL/TLS client will negotiate the highest supported SSL/TLS version with the server. If the server supports TLS up to version 1.2, the element will use version 1.2.
