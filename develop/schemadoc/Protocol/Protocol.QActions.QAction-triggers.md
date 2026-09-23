---
metadata_version: 1
uid: Protocol.QActions.QAction-triggers
description: "Reference the DataMiner connector protocol schema entry for triggers attribute, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# triggers attribute

Specifies the IDs of the parameters that will cause the QAction to be executed each time their value changes.

> [!TIP]
> See also: [Change-based event handling](xref:InnerWorkingsChangeBasedEventHandling)

## Content Type

[TypeSemicolonSeparatedNumbers](xref:Protocol-TypeSemicolonSeparatedNumbers)

## Parent

[QAction](xref:Protocol.QActions.QAction)

## Remarks

Multiple values have to be separated by semicolons (”;”).
