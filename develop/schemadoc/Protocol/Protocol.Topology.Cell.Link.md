---
uid: Protocol.Topology.Cell.Link
---

# Link element

Specifies how a cell in an EPM (formerly known as CPE) topology is linked to another cell in that topology, using foreign key relations (which can also be inside the same table).

## Parent

[Cell](xref:Protocol.Topology.Cell)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[dest](xref:Protocol.Topology.Cell.Link-dest)|unsignedInt|Yes|(EPM) In this attribute, specify the ID of the parameter column if you want to make a topology with foreign key relations inside a table.|
|[source](xref:Protocol.Topology.Cell.Link-source)|unsignedInt|Yes|*TBD*|

## Examples

In the following example, 2003 and 2004 are foreign keys inside and outside the table (one of each). The table definitions need to specify the foreignKey relationship:

```xml
<Topology>
  <Cell name="Countries" table="3000"></Cell>
  <Cell name="Headends" table="2000">
     <Link source="1" dest="2003"/>
     <Link source="1" dest="2004"/>
  </Cell>
  <Cell name="Customer" table="1000">
     <Link source="1" dest="2001"/>
  </Cell>
  <Cell name="STB" table="1100">
     <Link source="1" dest="1001"/>
  </Cell>
</Topology>
<ColumnOption idx="0" pid="2001" type="index" value="" options=""/>
<ColumnOption idx="1" pid="2002" type="custom" value="" options=";save"/>
<ColumnOption idx="2" pid="2003" type="custom" value="" options=";save;foreignKey=3000"/>
<ColumnOption idx="3" pid="2004" type="custom" value="" options=";save;foreignKey=2000"/>
```
