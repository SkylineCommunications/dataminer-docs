---
metadata_version: 1
uid: AutomationActionInformation
description: "Use the Information action to create a clear information event from an automation script and distinguish it from diagnostic logging."
---

# Information

Generates an information event.

## Audience and prerequisites

Use this action when you are authoring an automation script and need to communicate a result or status to operators. You should already know how to define an [automation script action](xref:AutomationActions) and assign each `Exe` element a unique ID.

## Scope

The action creates an information event with the text in the `Message` element. It is intended for operator-facing information, not for diagnostic details written to the automation log.

## Expected result

When the script reaches the action, DataMiner records an information event containing the configured message.

## Failure and edge cases

Keep the message concise and meaningful. If the script must write diagnostic details instead of an operator-facing event, use the [Log action](xref:AutomationActionLog).

```xml
<Exe id="2" type="information">
   <Message>This is a test</Message>
</Exe>
```

## Related concepts

- [Automation script actions](xref:AutomationActions)
- [Log action](xref:AutomationActionLog)
- [Exe element](xref:DMSScript.Script.Exe)

## Authoritative references

- [Message element](xref:DMSScript.Script.Exe.Message)
- [Automation XML schema](xref:SchemaAutomationScript)
