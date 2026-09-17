---
metadata_version: 1
uid: DMSScript.Credentials.Credential
description: "Reference the DataMiner Automation script schema entry for Credential element, including its documented structure, attributes, values, and constraints."
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

# Credential element

Defines a set of credentials from the [Credentials Library](xref:Credentials_Library) that the script is linked to.

## Parent

[Credentials](xref:DMSScript.Credentials)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:DMSScript.Credentials.Credential-id)|positiveInteger|Yes|Specifies the unique ID of the credentials.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Name](xref:DMSScript.Credentials.Credential.Name)||Specifies the name of the credentials.|
|&nbsp;&nbsp;[CredentialId](xref:DMSScript.Credentials.Credential.CredentialId)||Specifies the ID of the linked credentials in the [Credentials Library](xref:Credentials_Library).|
|&nbsp;&nbsp;[Type](xref:DMSScript.Credentials.Credential.Type)||Specifies the type of the credentials.|
