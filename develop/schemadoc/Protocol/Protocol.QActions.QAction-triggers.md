---
uid: Protocol.QActions.QAction-triggers
description: "Learn how the triggers attribute identifies parameters whose value changes cause a QAction to execute."
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

Multiple values have to be separated by semicolons (";").

When the [row](xref:Protocol.QActions.QAction-row) attribute of the QAction is set to `true`, the `triggers` attribute can only reference table-related parameters (a write column parameter, a read column parameter, or an SNMP table parameter). A QAction with `row="true"` cannot be used with single parameters.
