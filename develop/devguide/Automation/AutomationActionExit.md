---
metadata_version: 1
uid: AutomationActionExit
description: "Configure the Exit action to stop an automation script immediately, record a reason, and mark the execution as successful or failed."
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
