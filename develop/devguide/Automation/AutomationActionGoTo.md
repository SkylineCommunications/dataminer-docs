---
metadata_version: 1
uid: AutomationActionGoTo
description: "Describe the DataMiner Automation development topic Go to, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# Go to

Unconditionally transfers control to the statement labeled by the specified identifier.

```xml
<Exe id="2" type="goto">
  <Value>label</Value>
</Exe>
```

- Value: The label.
