---
metadata_version: 1
uid: ChangeToPartialTable
description: "Describe the DataMiner connector development topic Change to partial table, including its purpose, behavior, implementation guidance, and relevant constra."
content_type: conceptual
applies_to:
  - DataMiner
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
