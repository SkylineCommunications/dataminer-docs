---
metadata_version: 1
uid: AutomationActionLabel
description: "Describe the DataMiner Automation development topic Label, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# Label

Provides a label to enable transferring program control directly to the specified statement using a goto statement.

```xml
<Exe id="2" type="label">
   <Value>myLabel</Value>
</Exe>
```

- Value: The label.
