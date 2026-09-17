---
metadata_version: 1
uid: ConnectionsSerialSerialSingle
description: "Describe the DataMiner connector development topic Serial single, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# Serial single

When creating a serial connection towards a device, DataMiner combines all the connections (when there are multiple connections for the same device). This might not be desired behavior since a device sometimes allows multiple clients to be connected on the device. In this case, this behavior can be disabled by setting the protocol type to “serial single”.

## See also

DataMiner Protocol Markup Language:

- [Protocol.Type](xref:Protocol.Type)
