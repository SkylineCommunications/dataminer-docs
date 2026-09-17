---
metadata_version: 1
uid: InnerWorkingsInternalStorage
description: "Describe the DataMiner connector development topic Internal storage, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# Internal storage

A numeric parameter (i.e., a parameter having RawType set to either "numeric text", "signed number" or "unsigned number") that is not initialized will return different values depending on whether it is a cell in a table or single parameter.

- Cell: a null reference is returned (e.g., object cellValue = protocol.GetParameterIndexByKey(1000, "124", 4);).
- Standalone parameter: the value 0 is returned (e.g., object value = protocol.GetParameter(100);). To determine if a standalone parameter is uninitialized, the IsEmpty method can be used (e.g., bool isEmpty = protocol.IsEmpty(100);)
