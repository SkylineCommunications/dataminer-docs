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

> [!CAUTION]
> Depending on how the display key is defined, there is an important difference in the way trend data is stored in the trend data database table. If the *displayColumn* attribute is used, the **display key** is used in the trend data table. In case either the [naming](xref:Protocol.Params.Param.ArrayOptions-options#naming) option or [NamingFormat](xref:Protocol.Params.Param.ArrayOptions.NamingFormat) is used, the **primary key** is used in the trend data table.
>
> You should therefore never change existing protocols to start using *naming* instead of the *displayColumn* attribute, as this would result in the trend history becoming unavailable (even though it would still be present in the database).

## See also

- [Display keys](xref:UIComponentsTableDisplayKeys)
- [Protocol.Params.Param.ArrayOptions.NamingFormat](xref:Protocol.Params.Param.ArrayOptions.NamingFormat)
- [naming](xref:Protocol.Params.Param.ArrayOptions-options#naming)
