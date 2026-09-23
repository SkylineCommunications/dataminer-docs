---
metadata_version: 1
uid: AdvancedDataMinerMediationLayerBaseProtocolHierarchies
description: "Describe the DataMiner connector development topic Base protocol hierarchies, including its purpose, behavior, implementation guidance, and relevant const."
content_type: conceptual
applies_to:
  - DataMiner
---

# Base protocol hierarchies

It is possible to create a base protocol that is based on another base protocol.

When you base a device protocol on a base protocol that is itself based on another base protocol, the parameters defined in both base protocols will be combined. This obviously means that you should take great care not to use any duplicate parameter IDs.

> [!NOTE]
> Parameters defined at a lower level override those defined at a higher level (lower level means more towards device protocol, so less generic).
