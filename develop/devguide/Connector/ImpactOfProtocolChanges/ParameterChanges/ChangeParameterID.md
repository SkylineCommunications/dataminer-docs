---
metadata_version: 1
uid: ChangeParameterID
description: "Describe the DataMiner connector development topic Change parameter ID, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# Change parameter ID

Changing the ID of a parameter is considered a major change. However, this is only the case for externally available parameters (*RTDisplay* = true).

The parameter cannot be reused in future versions. If it is reused, the entries in the database can have a different meaning.

## Impact

All references are gone.

Parameter cannot be reused in future versions.

## Workarounds

There is no workaround.
