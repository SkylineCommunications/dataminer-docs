---
metadata_version: 1
uid: DMSScript.Credentials.Credential-id
description: "Reference the DataMiner Automation script schema entry for id attribute, including its documented structure, attributes, values, and constraints."
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

# id attribute

Specifies the unique ID of the credentials.

## Content Type

positiveInteger

## Parent

[Credential](xref:DMSScript.Credentials.Credential)

## Remarks

This is the ID that is passed to `engine.GetCredential(int id)` in a C# code block. See [GetCredential](xref:Skyline.DataMiner.Automation.Engine.GetCredential*).
