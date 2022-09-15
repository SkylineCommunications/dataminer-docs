---
uid: Protocol.TreeControls.TreeControl.ExtraDetails.LinkedDetails
---

# LinkedDetails element

Defines additional tree item information to be displayed in the details section of the tree control layout.

## Parent

[ExtraDetails](xref:Protocol.TreeControls.TreeControl.ExtraDetails)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[detailsTableId](xref:Protocol.TreeControls.TreeControl.ExtraDetails.LinkedDetails-detailsTableId)|[TypeParamId](xref:Protocol-TypeParamId)||Specifies the parameter ID of the table containing the additional information.|
|[discreetColumnId](xref:Protocol.TreeControls.TreeControl.ExtraDetails.LinkedDetails-discreetColumnId)|[TypeParamId](xref:Protocol-TypeParamId)||Specifies a column in the main table.|
|[value](xref:Protocol.TreeControls.TreeControl.ExtraDetails.LinkedDetails-value)|string||Specifies one of the possible discrete values.|

## Remarks

When looking at the details of a row from a table that the column specified in the discreetColumnId attribute belongs to, you can show extra parameters from table specified in the detailsTableId attribute, under the condition that the parameter specified in the discreetColumnId attribute has the value specified in the value attribute.

## Examples

For example, suppose a protocol defines a table (with ID 200) listing the servers on the network. Column parameter 204 is a discrete that indicates the role(s) of the server: { Mail, Web, Mail+Web }.

Table 1100 contains a foreign key to table 200 and has more information about the mail configuration. Table 1200 contains a foreign key to table 200 and has more information about the web configuration.

When looking at the details of a server, additional information can be shown depending on its role(s):

```xml
<LinkedDetails discreetColumnId="204" value="1" detailsTableId="1100" /><!-- mail -->
<LinkedDetails discreetColumnId="204" value="2" detailsTableId="1200" /><!-- web -->
<LinkedDetails discreetColumnId="204" value="3" detailsTableId="1100" /><!-- mail+web -->
<LinkedDetails discreetColumnId="204" value="3" detailsTableId="1200" /><!-- mail+web -->
```

All columns from tables 1100 and/or 1200 should be added after the ones from 200.

In case some columns should not be shown, these can be hidden using the HiddenColumns tag. See Protocol.TreeControls.TreeControl.[HiddenColumns](xref:Protocol.TreeControls.TreeControl.HiddenColumns).
