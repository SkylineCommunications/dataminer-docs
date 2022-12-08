---
uid: SLNetClientTest_Checking_whether_protocol_buffer_serialization_is_enabled
---

# Checking whether protocol buffer serialization is enabled

From DataMiner 9.6.4 (RN 20495) onwards, the SLNetClientTest tool allows you to check whether a client connection is using protocol buffer serialization. To do so:

1. Go to *Diagnostics* > *Connection Details*, and select a client connection.

2. Using the filter box at the bottom of the window, check whether the text contains the following string:

    `ProtoBuf: disabled/enabled (version)`

    Example: `ProtoBuf: Enabled (version: 9.6.1846.504)`
