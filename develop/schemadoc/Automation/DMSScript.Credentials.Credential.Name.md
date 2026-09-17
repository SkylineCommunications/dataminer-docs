---
metadata_version: 1
uid: DMSScript.Credentials.Credential.Name
description: "Reference the DataMiner Automation script schema entry for Name element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaAutomationScript
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# Name element

Specifies the name of the credentials.

## Type

[NonEmptyStringType](xref:Automation-NonEmptyStringType)

## Parent

[Credential](xref:DMSScript.Credentials.Credential)

## Remarks

The name must be unique within the script. It is the name that is passed to `engine.GetCredential(string name)` in a C# code block. See [GetCredential](xref:Skyline.DataMiner.Automation.Engine.GetCredential*).
