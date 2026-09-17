---
metadata_version: 1
uid: AutomationActionSleep
description: "Describe the DataMiner Automation development topic Sleep, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# Sleep

Pauses the automation script for a particular period before it is allowed to continue.

```xml
<Exe id="2" type="sleep">
   <Timeout>1000</Timeout>
</Exe>
```

`Timeout` is specified in milliseconds for this action.
