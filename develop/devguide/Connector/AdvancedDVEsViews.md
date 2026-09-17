---
metadata_version: 1
uid: AdvancedDVEsViews
description: "Describe the DataMiner connector development topic Views, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# Views

It is possible to specify the view to which each DVE in the table has to be added. In case an element should be included in multiple views, separate the different views by semicolons.

In the protocol, the DVE table column that will contain the view names has to have its options attribute set to "view".
