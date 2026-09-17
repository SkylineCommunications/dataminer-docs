---
metadata_version: 1
uid: AutomationActionAssignTemplate
description: "Describe the DataMiner Automation development topic Assign template, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# Assign template

Assigns an alarm or trend template to a dummy.

```xml
<Exe id="2" type="settemplate">
   <Protocol>1</Protocol>
   <Type>alarm</Type>
   <Value>Template1</Value>
</Exe>
<Exe id="2" type="settemplate">
   <Protocol>1</Protocol>
   <Type>alarm</Type>
   <Value ref="param1"></Value>
</Exe>
```

Required items:

- Protocol
- Type "alarm" for alarm template, "trending" for trend template
- Value for pre-determined template or Value@ref when determined by script parameter.
