---
metadata_version: 1
uid: AutomationActionScript
description: "Use the Script action to run a named automation script, pass its supported parameters, and diagnose deployment or parameter errors."
---

# Script

The `Script` element identifies the automation script to run. Each `Param` element supplies a value or execution option supported by that script. The action does not copy the target script into the calling script.

```xml
<Exe id="2" type="script">
   <Script>Attach to Ticket</Script>
   <Param type="DEFER">FALSE</Param>
   <Param type="CHECKSETS">TRUE</Param>
   <Param type="OPTIONS">11</Param>
</Exe>
```

> [!TIP]
> If the target script is missing, its name does not match, or a supplied parameter is invalid, the action cannot run the intended script. Keep the target script deployed and validate parameter values when the calling script changes.

## Related concepts

- [Automation script actions](xref:AutomationActions)
- [Script element](xref:DMSScript.Script.Exe.Script)
- [Param element](xref:DMSScript.Script.Exe.Param)

## Authoritative references

- [Getting started with automation script development](xref:GettingStartedWithAutomationScriptDevelopment)
- [Exe element](xref:DMSScript.Script.Exe)
