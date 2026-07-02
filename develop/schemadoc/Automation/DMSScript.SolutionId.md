---
uid: DMSScript.SolutionId
---

# SolutionId element

Specifies the solution that the automation script belongs to.

## Type

string

## Parent

[DMSScript](xref:DMSScript)

## Remarks

The value is a free-form name that identifies the solution. All scripts that share the same *SolutionId* value are grouped together and executed in the same [Script Runner](xref:Script_Runners), which isolates their execution and DLL dependencies from the scripts of other solutions.

When this element is omitted, the script is executed in the DataMiner Automation process instead of in a Script Runner.

> [!NOTE]
> This element is available from DataMiner 10.6.10/10.7.0 <!-- RN 45557 --> onwards.
