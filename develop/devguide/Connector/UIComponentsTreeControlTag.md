---
uid: UIComponentsTreeControlTag
---

# TreeControl tag

The initial step to compose a tree control is to create tables that will represent the data and configure the linking on them (For more information on how to link tables, see Foreign keys and Relations).

The tree control itself is configured using the TreeControls.TreeControl tag.

Example:

```xml
<TreeControl parameterId="20000" readOnly="true">
  <Hierarchy>
    <Table id="10000"/>
    <Table id="11000" parent="10000" />
    <Table id="12000" parent="11000" />
  </Hierarchy>
  <OverrideDisplayColumns>10003,11005,12005</OverrideDisplayColumns>
  <OverrideIconColumns>12006</OverrideIconColumns>
  <HiddenColumns>10002</HiddenColumns>
  <ExtraTabs>
    <Tab tableId="10000" title="Items" type="default"/>
  </ExtraTabs>
</TreeControl>
```

The parameterId attribute refers to a regular parameter of type "read" as illustrated below, which is used to position the tree control (Interprete.Type should be set to "string" to retain backward compatibility with Element Display).

```xml
<Param id="20000">
  <Name>Overview</Name>
  <Description>Overview</Description>
  <Type>read</Type>
  <Interprete>
    <RawType>other</RawType>
    <Type>string</Type>
    <LengthType>next param</LengthType>
  </Interprete>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
</Param>
```

The Hierarchy child tag defines the relations between the (visible) tables. Rows from these tables will become items in the tree control. For more information on conditional branching, see Advanced hierarchy.

The HiddenColumns child tag can be used to hide table columns. The parameter will be hidden in both the details pane and tables in the tree control.

By default, the text in the tree control will be the display key of that row (or the primary key if no display key is defined). This value can be overridden by specifying a different column for a table using the OverrideDisplayColumns tag.

The ExtraTabs child tag can be used to display extra information about each tree item.

## See also

- [Protocol.TreeControls.TreeControl](xref:Protocol.TreeControls.TreeControl)
