---
metadata_version: 1
uid: DMSScript.SolutionId
description: "Reference the DataMiner Automation script schema entry for SolutionId element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaAutomationScript
lifecycle: active
applies_to:
  - DataMiner
version: 10.6.9
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# SolutionId element

Specifies the solution that the automation script belongs to.

## Type

String

## Parent

[DMSScript](xref:DMSScript)

## Remarks

The value is a free-form name that identifies the solution. All scripts that share the same `SolutionId` value are grouped together and executed in the same [script runner](xref:Script_Runners), which isolates their execution and DLL dependencies from the scripts of other solutions.

When this element is omitted, the script is executed in the DataMiner Automation process instead of in a script runner.

> [!NOTE]
> This element is available from DataMiner 10.6.9/10.7.0 <!-- RN 45557 --> onwards.
