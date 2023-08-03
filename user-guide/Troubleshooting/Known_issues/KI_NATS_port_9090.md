---
uid: KI_NATS_port_9090
---

# Default NATS port is already in use

## Affected versions

From DataMiner 10.1.0/10.1.1 onwards

## Cause

[IP port 9090](xref:Configuring_the_IP_network_ports), which is used by default in a DataMiner System for NATS, is already being used by a third-party software, such as [the Keysight Agilent IO Libraries](xref:Installing_the_Keysight_Agilent_IO_Libraries).

## Fix

Manually configure a custom port for NATS. See [Investigating NATS issues](xref:Investigating_NATS_Issues#manually-configuring-a-custom-port-for-nats).

## Issue description

- DataMiner will not start.

- NAS is running.

- NATS is stopped.

- Several 2kB large log files can be found in the *C:\Skyline DataMiner\NATS\nats-account-server* folder.

  > [!NOTE]
  > The number of log files in this folder can increase rapidly (over 30,000 files in 12 hours).

  The log files contain the following entry:

  `listen tcp 0.0.0.0:9090: bind: Only one usage of each socket address (protocol/network address/port) is normally permitted.`
