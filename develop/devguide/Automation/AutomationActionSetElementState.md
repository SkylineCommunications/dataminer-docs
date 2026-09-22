---
metadata_version: 1
uid: AutomationActionSetElementState
description: "Describe the DataMiner Automation development topic Set element state, including its purpose, behavior, implementation guidance, and relevant constraints."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Set element state

Sets the state of a dummy in an automation script.

```xml
<Exe id="2" type="changestate">
   <Protocol>1</Protocol>
  <Type>restart</Type>
</Exe>
```

Possible values for Type:

- start
- stop
- restart
- pause
- mask
- unmask
