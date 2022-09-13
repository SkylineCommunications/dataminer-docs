---
uid: ConnectionsSerialHostnameResolution
---

# Hostname resolution

Prior to DataMiner 10.2.9, when a serial connection was configured with a hostname instead of an IP address, the hostname would be resolved when the port was initialized. When the hostname suddenly pointed to a different IP address, an element restart or a dynamic IP address change was needed for the serial connection to be aware of that change.

From DataMiner 10.2.9 (RN 33702) onwards, this behavior has been changed:

- In case of a TCP-oriented serial connection (serial SSL/TLS, SSH and serial TCP), the hostname will be resolved upon every connect.
- In case of a UDP-oriented serial connection (serial UDP), the hostname will be resolved prior to every send.
