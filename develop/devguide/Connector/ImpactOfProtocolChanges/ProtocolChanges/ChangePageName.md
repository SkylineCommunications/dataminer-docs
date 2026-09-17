---
metadata_version: 1
uid: ChangePageName
description: "Describe the DataMiner connector development topic Change page name, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# Change page name

Changing the name of a page is considered a major change, and as such a major change is required in the version numbering.

## Impact

A page name can be used in Visio. A shape can be linked to an alarm state, and it can be used to display the entire page in a dashboard.

Visio files and dashboards will require configuration changes.

## Actions to be taken

Changes to a page name will be approved in the following case:

- The current page name is wrong (for example, the name of the page does not reflect the types of parameters it displays).

All other page name changes will generally be rejected.
