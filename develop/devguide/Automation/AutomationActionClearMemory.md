---
metadata_version: 1
uid: AutomationActionClearMemory
description: "Describe the DataMiner Automation development topic Clear memory, including its purpose, behavior, implementation guidance, and relevant constraints."
content_type: conceptual
applies_to:
  - DataMiner
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
