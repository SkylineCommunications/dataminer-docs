---
metadata_version: 1
uid: ConnectionsSerialSocketBuffer
description: "Describe the DataMiner connector development topic Socket buffer, including its purpose, behavior, implementation guidance, and relevant constraints."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# Socket buffer

In a protocol with a serial interface, if a command is being sent, DataMiner typically waits for the configured timeout or stops reading when it knows all data is received (e.g., configured trailer).

If data comes in after the configured timeout, this will not be made available to the protocol as a response but will nonetheless still be available in the socket buffer for the next readout.

This means that when e.g., a retry occurs, and the same response comes in again after the configured timeout, we will read out the response of the command that was sent out the first time. This also means that on another different command, there could still be data in the socket buffer of a previous command.

As this is not desired, a change in behavior has been implemented in DataMiner 10.0.10 (RN 26513): Just before every command that is being sent out, the data that is available in the socket will now be flushed.
