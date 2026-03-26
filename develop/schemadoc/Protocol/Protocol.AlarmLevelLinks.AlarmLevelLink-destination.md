---
uid: Protocol.AlarmLevelLinks.AlarmLevelLink-destination
---

# destination attribute

Specifies the column parameter ID where the result of the alarm level needs to be set.

## Content Type

string

## Parent

[AlarmLevelLink](xref:Protocol.AlarmLevelLinks.AlarmLevelLink)

## Remarks

The value that will be set is the numeric value of the alarm level.

| Alarm level | Description |
|-------------|-------------|
| 0           | Undefined   |
| 1           | Normal      |
| 2           | Warning     |
| 3           | Minor       |
| 4           | Major       |
| 5           | Critical    |
| 7           | Timeout     |
| 8           | Initial     |
| 9           | Masked      |
| 10          | Error       |
| 11          | Notice      |

To retrieve the alarm of a row, the destination needs to be linked to a row. For example, consider the following alarm level link defined in a manager protocol:

```xml
<AlarmLevelLink id="1" destination="2004:DISPLAY_NOLINK:2002" remoteElement="2003:200:202" />
```

Table 2000 is defined as follows:

```xml
<Param id="2000" trending="false">
   <Name>Service Overview</Name>
   <Description>Service Overview</Description>
   <Type>array</Type>
   <ArrayOptions index="0" options="">
      <NamingFormat>,2002</NamingFormat>
      <ColumnOption idx="0" pid="2001" type="retrieved" value="" options=""/><!--  Primary Key-->
      <ColumnOption idx="1" pid="2002" type="retrieved" value="" options=";save"/><!--  Display Key-->
      <ColumnOption idx="2" pid="2003" type="retrieved" options=";save"/><!--  Remote element ID -->
      <ColumnOption idx="3" pid="2004" type="retrieved" options=""/><!--  Alarm level -->
      <ColumnOption idx="4" pid="2005" type="retrieved" options=""/>
   </ArrayOptions>
  ...
</Param>
```

In this case, the destination consists of three parts:

1. Column parameter ID, where the received alarm level value will be forwarded to (2004 in the given example). The alarm level value will be set as the content of the corresponding cell.

   ![Alarm level linking to a regular column](~/develop/schemadoc/Protocol/images/AlarmLevelLinking1.svg)

   It is also possible to specify a column parameter ID that holds primary keys. In this case, the alarm level value will not be set as the cell value, but the alarm level of the primary key cell will correspond with the highest alarm level present in any of the other columns in the row and the linked columns.<!-- RN 10406 -->

   For example, consider a row in a table of an element where the highest alarm level of the columns in this row is "warning" (this is the so-called "instance alarm level"). Now suppose an alarm level link exists between another table column parameter of an external element and the primary key column of the given table. The severity of this alarm is the so-called "bubble up level". The severity of the PK cell (referred to as the "cell alarm level") will now be the most severe alarm level of the instance alarm level and the bubble up level.

   In the example below, the instance alarm level is "Major" (4) and the bubble up level is "Critical" (5). As a result, the cell alarm level is "Critical" (5), as this is the most severe alarm level.

   ![Alarm level linking to a primary key column](~/develop/schemadoc/Protocol/images/AlarmLevelLinking2.svg)

   As the name suggests, the "bubble up level" can be used for alarm bubble up (see [SeverityBubbleUp](xref:Protocol.SeverityBubbleUp)) to pass alarm severities between linked tables (e.g., used in CPE Managers).

1. Link option: The link option specifies how a source row is linked to a destination row. If you specify DISPLAY, the rows are linked based on the display key of the source row. If you specify PK, the rows are linked based on the PK of the row. So if, 2002 holds "BBC", you will link it using DISPLAY; if 2002 holds "1.3.5", you will link it using PK.

   For both of the options you can use the extension "_NOLINK". This means that you want to disconnect the source element from the destination. Suppose you have 2 probes aggregating alarm levels to a service overview manager (SOM). If you want an overview of BBC on all probes, you will need to disconnect the probe from BBC and then you specify "_NOLINK".

   Below you can find an example of a "where clause" to find the destination (in which 7105 is the remote element):

   |Link option|Description
   |--- |--- |
   |DISPLAY_NOLINK|VALUE=2002 === BBC|
   |PK_NOLINK|VALUE=2002 === 100|
   |DISPLAY|VALUE=2002 === BBC|
   |DISPLAY|VALUE=7105 == x/y|
   |PK|VALUE=2002 === 100|
   |PK|VALUE=7105 == x/y|

   > [!NOTE]
   > If you use "===", the exact match is checked. This means that `Service*===ServiceB` results in a false, the * is in this case not used as a wildcard but as a character.<!-- RN 4610 -->

1. The column parameter ID that contains the identifier (display key/primary key) in the table of the remote element that contains the alarm.
