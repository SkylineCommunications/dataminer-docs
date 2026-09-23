---
metadata_version: 1
uid: AutomationActionSleep
description: "Describe the DataMiner Automation development topic Sleep, including its purpose, behavior, implementation guidance, and relevant constraints."
---

# Sleep

Pauses the automation script for a particular period before it is allowed to continue.

```xml
<Exe id="2" type="sleep">
   <Timeout>1000</Timeout>
</Exe>
```

`Timeout` is specified in milliseconds for this action.
