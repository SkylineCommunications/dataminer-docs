---
uid: UIComponentsTableSettingRowTextColor
---

# Setting row text color

Since DataMiner version 7.5, it is possible to change the text color of table rows. To use this feature, the table must contain a column of type "discreet" and the discrete values of that column must specify a color in the options attribute. The value of that column will determine the text color for each row. The colors must be specified in hexadecimal format "#RRGGBB", e.g. "#EF71B2".

```xml
<Param id="100" trending="false">
  <Name>Table</Name>
  <Description>Table</Description>
  <Type>array</Type>
  <ArrayOptions index="0">
    <ColumnOption idx="0" pid="101" type="retrieved" options="" />
    <ColumnOption idx="1" pid="102" type="retrieved" options="" />
    <ColumnOption idx="2" pid="103" type="retrieved" options=";save;rowTextColoring" />
  </ArrayOptions>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
</Param>
<Param id="103" trending="false">
  <Name>RowColor</Name>
  <Description>RowColor</Description>
  <Type>read</Type>
  <Measurement>
    <Type>discreet</Type>
    <Discreets>
      <Discreet options="rowTextColor=#FF0000">
        <Display>Red</Display>
        <Value>0</Value>
      </Discreet>
      <Discreet options="rowTextColor=#0000FF">
        <Display>Blue</Display>
        <Value>2</Value>
      </Discreet>
    </Discreets>
  </Measurement>
</Param>
```
