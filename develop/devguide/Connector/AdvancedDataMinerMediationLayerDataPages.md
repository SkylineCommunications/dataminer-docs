---
metadata_version: 1
uid: AdvancedDataMinerMediationLayerDataPages
description: "Describe the DataMiner connector development topic Data pages, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# Data pages

The page order, the default page, and the option *DisplayWideColmunPages* are retrieved from the mediation protocol instead of the protocol assigned to the element.<!-- RN 19166 -->

**Webpages** of the device protocol are not added by default. To add such a page, define it in the mediation protocol. **Only the name** of the webpage needs to be defined (not the # + arguments). The arguments containing the URL data will be retrieved from the protocol assigned to the element.
