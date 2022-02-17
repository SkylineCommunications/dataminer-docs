---
uid: Protocol.Params.Param.ArrayOptions-displayColumn
---

# displayColumn attribute

Defines which column is used as an identifier for the user.

## Content Type

unsignedInt

## Parent

[ArrayOptions](xref:Protocol.Params.Param.ArrayOptions)

## Remarks

This column has to be of type “String”. It can be updated, and normally contains a readable key which identifies the row for the user.

> [!NOTE]
> For performance reasons, using either the "naming" option or the NamingFormat tag is favored over using the displayColumn attribute for new protocols.

## See also

- [Display keys](xref:UIComponentsTableDisplayKeys)
- [Protocol.Params.Param.ArrayOptions.NamingFormat](xref:Protocol.Params.Param.ArrayOptions.NamingFormat)
- [naming](xref:Protocol.Params.Param.ArrayOptions-options#naming)