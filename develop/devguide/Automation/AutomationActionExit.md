---
uid: AutomationActionExit
---

# Exit

Terminates the Automation script without delay.

```xml
<Exe id="2" type="exit">
   <Message>Reason</Message>
   <ScriptSuccess>TRUE</ScriptSuccess>
</Exe>
```

- Message: The reason for termination.
- ScriptSuccess: Indicated whether the script execution was considered successful (true) or failure (false).
