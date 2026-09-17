---
metadata_version: 1
uid: AutomationActionClearMemory
description: "Describe the DataMiner Automation development topic Clear memory, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# Clear memory

Clears the content of the specified automation script memory file.

```xml
<Exe id="2" type="clearmemory">
   <Value ref="1"></Value>
</Exe>
```

Required items:

- Value@ref: The memory file to clear.
