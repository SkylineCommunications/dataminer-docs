---
metadata_version: 1
uid: AutomationActionSleep
description: "Configure the Sleep action to pause an automation script for a specified number of milliseconds before script execution continues."
---

# Sleep

Pauses the automation script for a particular period before it is allowed to continue.

```xml
<Exe id="2" type="sleep">
   <Timeout>1000</Timeout>
</Exe>
```

`Timeout` is specified in milliseconds for this action.
