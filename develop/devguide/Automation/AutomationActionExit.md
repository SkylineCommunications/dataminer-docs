---
metadata_version: 1
uid: AutomationActionExit
description: "Describe the DataMiner Automation development topic Exit, including its purpose, behavior, implementation guidance, and relevant constraints."
content_type: conceptual
applies_to:
  - DataMiner
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
