---
uid: Protocol.TreeControls.TreeControl.ExtraTabs.Tab-type
---

# type attribute

Specifies the tab type.

## Content Type

string

## Parent

[Tab](xref:Protocol.TreeControls.TreeControl.ExtraTabs.Tab)

## Remarks

Contains one of the following types:

### chart

Example:

```xml
chart|Pie-Pie-...|2008-2009-...
```

### default

Can be used to rename the title of the first tab (with the child table). The default title is “Items”.

### parameters

Moves parameters from the main list to a new tab. Parameters from ExtraDetails can also be moved.

### relation

Displays an additional table with a different parent-child relationship than the one used in the tree.

Requires an explicit foreign key in the child table linking to this table.

### summary

Displays an additional table that aggregates all “grandchildren”

### web

Creates an embedded web browser that navigates to a specified URL.

The following placeholders can be used in the URL. Note that, to be able to access embedded webpages, the user needs to have write access on the element.

- [Polling Ip] is replaced by the Polling IP of the element.
- [id:123] is replaced by the value of the specified parameter. This can be:
  - a column in the table of the selected tree item.
  - a column in the table of one of the ancestors of the selected tree item.
  - a normal parameter of the element.
