---
metadata_version: 1
uid: AutomationActionUi
description: "Use the UI action to present a response dialog from an automation script and distinguish dialog input from script control flow."
content_type: conceptual
applies_to:
  - DataMiner
---

# UI

Configures a dialog box asking for a user response.

## Audience and prerequisites

Use this action in an automation script that needs input from an interactive operator. Before configuring it, determine the dialog definition and the response handling required by the script.

<a id="automation-action-ui-scope"></a>

## Scope

The `Value` element contains the definition of the dialog shown to the operator. The action is for interactive input; it does not replace an `if` action or provide a general-purpose branching expression.

## Expected result

When the action executes, DataMiner presents the configured dialog and the script can continue with the response defined by that dialog.

<a id="automation-action-ui-failure-and-edge-cases"></a>

## Failure and edge cases

The value shown below is a placeholder, not a complete dialog definition. Replace it with the dialog content required by the script. An incomplete definition can prevent the expected controls or response from being available.

```xml
<Exe id="2" type="ui">
   <Value><![CDATA[...]]></Value>
</Exe>
```

## Related concepts

- [UIBlockType overview](xref:UIBlockTypesOverview)
- [Automation script actions](xref:AutomationActions)
- [If action](xref:AutomationActionIf)

## Authoritative references

- [Exe element](xref:DMSScript.Script.Exe)
- [Value element](xref:DMSScript.Script.Exe.Value)
