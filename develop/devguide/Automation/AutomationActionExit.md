---
metadata_version: 1
uid: AutomationActionExit
description: "Describe the DataMiner Automation development topic Exit, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# Exit

Terminates the automation script without delay.

```xml
<Exe id="2" type="exit">
   <Message>Reason</Message>
   <ScriptSuccess>TRUE</ScriptSuccess>
</Exe>
```

- Message: The reason for termination.
- ScriptSuccess: Indicated whether the script execution was considered successful (true) or failure (false).
