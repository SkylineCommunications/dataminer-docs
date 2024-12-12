---
uid: Protocol.AlarmLevelLinks.AlarmLevelLink-remoteElement
---

# remoteElement attribute

Use this attribute when you want to retrieve the alarm state of a different element.

## Content Type

[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)

## Parent

[AlarmLevelLink](xref:Protocol.AlarmLevelLinks.AlarmLevelLink)

## Remarks

In this attribute, specify

- the column parameter ID that contains the DataMiner Agent ID and element ID, and
- the alarm severity that needs to be retrieved
  - column parameter ID that contains the identifier (display/primary key in the table of the remote element that contains the alarm), or
  - -1 (general element alarm state).

In the following example, table 7100 contains a column (7105) with the DmaID/ElementID of the element. The -1 indicates that the general (most severe) state of the element is returned. The result is set in column parameter 7104:

```xml
<AlarmLevelLink id="1" remoteElement="7105:-1" destination="7104"/>
```

In order to aggregate the alarms into multiple linked tables, the relations need to be added. The foreign keys will be filled in automatically.

In the following example:

- Table 100 contains a column 103 with the DmaID/ElementID
- The remote elements have a table 96 with a readable description in column 106, this will be used as identifier.
- The alarms state per row in table 96 will be set in the table containing column 154, the retrieved identifier will be set in column 152 of the same table.
- A second table will contain the alarm levels per row in table 96 and per defined element in column 103. The primary keys will be entered in the columns that have a foreignKey option.

```xml
<AlarmLevelLink id="2" remoteElement="103:96:106" destination="154:PK_NOLINK:152"/>
<AlarmLevelLink id="3" remoteElement="103:96:106" destination="204:PK:152" />
```
