---
uid: ConnectionsSerialIntroduction
---

# Introduction

When communicating with a serial device, a DataMiner Agent will send commands to the device and the latter will reply with a response for each command.

> [!NOTE]
>
> - Devices supporting serial communication often implement a proprietary, vendor-specific serial communication protocol. However, public standardized protocols are also possible (e.g. Modbus).
> - Serial devices cannot send unsolicited messages to a DataMiner Agent; devices only send responses to commands sent by DataMiner.

The communication will occur over TCP/IP, UDP, or, less commonly, over a serial cable.

> [!NOTE]
> It is possible to create a serial simulation using an element stream or DataMiner simulation file as input for our [*Skyline Serial Simulator* protocol](https://catalog.dataminer.services/result/driver/3588).

DataMiner supports serial communication, allowing protocols to define one or more connections of type "serial". DataMiner runs a process called "SLPort", which takes care of all communication to and from devices connected to either a serial port or an IP port.
