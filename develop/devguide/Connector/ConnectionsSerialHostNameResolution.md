---
uid: ConnectionsSerialHostnameResolution
description: "Understand when DataMiner resolves hostnames for TCP- and UDP-oriented serial connections, and how the behavior differs between recent and legacy versions."
---

# Hostname resolution

In recent DataMiner version, the following behavior applies when a serial connection is configured with a hostname instead of an IP address:<!-- RN 33702 -->

- In case of a TCP-oriented serial connection (serial SSL/TLS, SSH and serial TCP), the hostname will be resolved upon every connect.
- In case of a UDP-oriented serial connection (serial UDP), the hostname will be resolved prior to every send.

In legacy DataMiner versions, the behavior was different. When a serial connection was configured with a hostname instead of an IP address, the hostname would be resolved when the port was initialized. When the hostname suddenly pointed to a different IP address, an element restart or a dynamic IP address change was needed for the serial connection to be aware of that change.
