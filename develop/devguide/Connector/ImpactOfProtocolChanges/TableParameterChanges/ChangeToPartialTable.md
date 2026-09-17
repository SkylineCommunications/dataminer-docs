---
metadata_version: 1
uid: ChangeToPartialTable
description: "Describe the DataMiner connector development topic Change to partial table, including its purpose, behavior, implementation guidance, and relevant constra."
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

# Change to partial table

Changing a table to a [partial table](xref:Protocol.Params.Param.ArrayOptions-partial) is considered a major change.

## Impact

Existing custom reports may no longer work.

*GetTable* via automation scripts will only be able to retrieve the displayed content.

Alarm monitoring with [dynamic alarm thresholds](xref:Configuring_dynamic_alarm_thresholds) will no longer work.

*DIS MCC*

| Full ID | Error message  | Description                                            |
|---------|----------------|--------------------------------------------------------|
| 2.26.1  | EnabledPartial | Partial Table option was enabled on table '{paramId}'. |
