---
metadata_version: 1
uid: AdvancedDataMinerMediationLayerBaseProtocolHierarchies
description: "Describe the DataMiner connector development topic Base protocol hierarchies, including its purpose, behavior, implementation guidance, and relevant const."
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

# Base protocol hierarchies

It is possible to create a base protocol that is based on another base protocol.

When you base a device protocol on a base protocol that is itself based on another base protocol, the parameters defined in both base protocols will be combined. This obviously means that you should take great care not to use any duplicate parameter IDs.

> [!NOTE]
> Parameters defined at a lower level override those defined at a higher level (lower level means more towards device protocol, so less generic).
