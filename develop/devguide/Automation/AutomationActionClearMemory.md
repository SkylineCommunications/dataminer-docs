---
metadata_version: 1
uid: AutomationActionClearMemory
description: "Configure the Clear memory action to erase the contents of a selected automation script memory file by using its reference."
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
