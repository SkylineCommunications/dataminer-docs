---
metadata_version: 1
uid: Protocol.QActions.QAction-include
description: "Reference the DataMiner connector protocol schema entry for include attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
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

# include attribute

Specifies the name of the external script to be executed.

## Content Type

string

## Parent

[QAction](xref:Protocol.QActions.QAction)

## Remarks

Use a semicolon as separator when multiple scripts are specified. The specified scripts must be present in the ProtocolScripts folder. Only applicable in case encoding is set to either JScript or VBScript (note that these are [no longer supported](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement)).
