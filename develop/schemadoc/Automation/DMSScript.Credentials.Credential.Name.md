---
metadata_version: 1
uid: DMSScript.Credentials.Credential.Name
description: "Use the Credential Name element as the unique script-level name passed to GetCredential when retrieving linked credentials."
---

# Name element

Specifies the name of the credentials.

## Type

[NonEmptyStringType](xref:Automation-NonEmptyStringType)

## Parent

[Credential](xref:DMSScript.Credentials.Credential)

## Remarks

The name must be unique within the script. It is the name that is passed to `engine.GetCredential(string name)` in a C# code block. See [GetCredential](xref:Skyline.DataMiner.Automation.Engine.GetCredential*).
