---
metadata_version: 1
uid: ChangeColumnOrder
description: "Describe the DataMiner connector development topic Change column order, including its purpose, behavior, implementation guidance, and relevant constraints."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Change column order

Changing the order (IDX) of the columns in a table is considered a major change only when the table information can be requested externally (other elements, web API, automation scripts, etc).

If the table is hidden (*RTDisplay* = false), it is not considered a major change.

## Impact

A shift in IDX will result in incorrect parsing of the data when the table information is requested by external sources.

> [!NOTE]
> When the column of type "displaykey" needs to be moved (for example to add new columns in front of it), then no major change is required (only when the display key column is already the last column IDX). The *displaykey* column is in this case only used to display the display key in Cube and should not cause issues.

## Workarounds

There is no workaround.
