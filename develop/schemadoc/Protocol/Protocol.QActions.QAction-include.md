---
metadata_version: 1
uid: Protocol.QActions.QAction-include
description: "Reference the DataMiner connector protocol schema entry for include attribute, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# include attribute

Specifies the name of the external script to be executed.

## Content Type

string

## Parent

[QAction](xref:Protocol.QActions.QAction)

## Remarks

Use a semicolon as separator when multiple scripts are specified. The specified scripts must be present in the ProtocolScripts folder. Only applicable in case encoding is set to either JScript or VBScript (note that these are [no longer supported](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement)).
