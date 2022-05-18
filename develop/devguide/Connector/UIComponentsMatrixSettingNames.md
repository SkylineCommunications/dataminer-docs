---
uid: UIComponentsMatrixSettingNames
---

# Setting input/output names via a table

It is possible to let users dynamically change the names of matrix inputs/outputs by implementing a table that uses the option "discreetDestination". The table contains two columns, one holding the input/output number and one holding the input/output name. The column holding the names of the inputs/outputs acts as the display key.

```xml
<Param id="400" trending="false">
...
  <Type>array</Type>
  <ArrayOptions index="0" displayColumn="1" options="discreetDestination=ports.xml">
      <!-- ID -->
     <ColumnOption idx="0" pid="401" type="retrieved" value="" options=";save"/>
      <!-- Name -->
     <ColumnOption idx="1" pid="402" type="retrieved" value="" options=";save"/>
  </ArrayOptions>
  ...
</Param>
```

> [!NOTE]
> The display key must be specified using the displayColumn attribute. Using NamingFormat or the naming option is currently not supported.

The discreetDestination option defines the XML file that will contain the table data. The name of the file is typically "ports.xml", but another name can be used. Each time the table is updated, the changes will be forwarded to the associated XML file.

> [!NOTE]
> The XML file is stored in the folder C:\Skyline DataMiner\Elements\\[Element Name]\

The XML file will contain the following, where the content of Value tags corresponds with the primary key column of the table and the content of Display tags corresponds with the column holding the display keys.

```xml
<Discreets>
  <Discreet>
     <Display>Input 1</Display>
     <Value>1</Value>
  </Discreet>
  <Discreet>
     <Display>Input 2</Display>
     <Value>2</Value>
  </Discreet>
  ...
</Discreets>
```

The matrix parameter must also refer to this file in order to use the information mentioned in the file. This is done via the link attribute of the Measurement.Type tag:

```xml
<Param id="100">
  <Name>basicMatrix</Name>
  <Description>Basic Matrix</Description>
  <Type options="…">array</Type>
  <Interprete>…</Interprete>
  <Display>
     <RTDisplay>true</RTDisplay>
     <Positions>…</Positions>
  </Display>
  <Measurement>
     <Type link="ports.xml" options="matrix=16,16,0,1,0,16;tab=lines:20,filter:false">matrix</Type>
     <Discreets>…</Discreets>
  </Measurement>
</Param>
```
