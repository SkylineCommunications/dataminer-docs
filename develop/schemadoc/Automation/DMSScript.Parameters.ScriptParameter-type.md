---
metadata_version: 1
uid: DMSScript.Parameters.ScriptParameter-type
description: "Reference the type attribute for an automation script parameter and define the string value type expected by the script."
content_type: schema
applies_to:
  - DataMiner
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

## Usage and constraints

The `type` attribute describes the value presented to the automation script for the parameter. The current schema facet lists `string` as the supported value. At runtime, the `ScriptParam` value is supplied as a string.

Use the `values` attribute on the same `ScriptParameter` when the parameter gets its selectable values from a memory file. Keep the parameter ID and description aligned with the code that reads it.

## Expected result

DataMiner exposes the configured parameter to the script with the declared type and the value source defined by the parameter declaration.

## Failure and edge cases

Do not use a CLR type name in this attribute. If the script expects a parameter that is not declared, or if the referenced values file is unavailable, the script can receive an empty or unusable value.

## Example

```xml
<Parameters>
   <ScriptParameter id="1" type="string" values="TicketStates">
      <Description>State to apply</Description>
   </ScriptParameter>
</Parameters>
```

## Related concepts

- [ScriptParameter element](xref:DMSScript.Parameters.ScriptParameter)
- [Script parameter values](xref:DMSScript.Parameters.ScriptParameter)
- [Automation script development guide](xref:AutomationDevGuideIndex)

## Authoritative references

- [Parameters element](xref:DMSScript.Parameters)
- [Automation XML schema](xref:SchemaAutomationScript)
