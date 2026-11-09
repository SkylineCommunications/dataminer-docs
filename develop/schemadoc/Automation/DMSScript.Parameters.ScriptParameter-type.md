---
uid: DMSScript.Parameters.ScriptParameter-type
description: "Reference the type attribute for an automation script parameter and define the string value type expected by the script."
---

# type attribute

Specifies the parameter type.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|string|string|

## Parent

[ScriptParameter](xref:DMSScript.Parameters.ScriptParameter)

## Example

```xml
<Parameters>
   <ScriptParameter id="1" type="string" values="TicketStates">
      <Description>State to apply</Description>
   </ScriptParameter>
</Parameters>
```

## Remarks

- Do not use a CLR type name in this attribute. If the script expects a parameter that is not declared, or if the referenced values file is unavailable, the script can receive an empty or unusable value.

- The `type` attribute describes the value presented to the automation script for the parameter. The current schema facet lists `string` as the supported value. At runtime, the `ScriptParam` value is supplied as a string. Use the [values](xref:DMSScript.Parameters.ScriptParameter-values) attribute on the same `ScriptParameter` when the parameter gets its selectable values from a memory file. Keep the parameter ID and description aligned with the code that reads it.

## Related concepts

- [ScriptParameter element](xref:DMSScript.Parameters.ScriptParameter)
- [Script parameter values](xref:DMSScript.Parameters.ScriptParameter)
- [Automation script development guide](xref:AutomationDevGuideIndex)

## Authoritative references

- [Parameters element](xref:DMSScript.Parameters)
- [Automation XML schema](xref:SchemaAutomationScript)
