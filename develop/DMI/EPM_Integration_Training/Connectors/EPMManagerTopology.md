---
uid: EPMManagerTopology
---

# Topology configuration

In the EPM Manager connector, the [Topologies](xref:Protocol.Topologies) tag defines each of the different topologies.

## Cell and Link tags

Within each [Topology](xref:Protocol.Topologies.Topology) tag, you will find [Cell](xref:Protocol.Topologies.Topology.Cell) tags. These represent the cells in the EPM topology. They allow you to define the levels visible in a topology and the connections between them.

For example:

```xml
<Topologies>
   <Topology>
      <Cell name="Network" table="9500"></Cell>
      <Cell name="Region" table="8500">
         <Link source="1" dest="9501"/>
      </Cell>
      <Cell name="Sub-Region" table="7500">
         <Link source="1" dest="8501"/>
      </Cell>
      <Cell name="Hub" table="6500">
         <Link source="1" dest="7501"/>
      </Cell>
      <Cell name="Station" table="5500">
         <Link source="1" dest="6501"/>
      </Cell>
      <Cell name="Device" table="2500">
         <Link source="1" dest="5501"/>
      </Cell>
   </Topology>
</Topologies>
```

The [Cell](xref:Protocol.Topologies.Topology.Cell) tag is used to define the levels present in the topologies and to associate each level with a specific entity table.

| Attribute | Description                                                                             |
|-----------|-----------------------------------------------------------------------------------------|
| `name`    | Defines the name of the level.                                                          |
| `table`   | Defines the table linked to the level. The tables should be the respective view tables. |

The [Link](xref:Protocol.Topologies.Topology.Cell.Link) tag is used to define the connections of each cell (i.e. topology level).

| Attribute | Description                                                                      |
|-----------|----------------------------------------------------------------------------------|
| `source`  | An ID used to identify the source.                                               |
| `dest`    | Parameter ID used to define the connection. Must be the index of the view table. |

## Topology relations

In a topology, it is possible to define three types of relations:

- [One-to-many](#one-to-many-relations)
- [Many-to-many](#many-to-many-relations)
- [Recursive](#recursive-relations)

### One-to-many relations

A one-to-many relation indicates that an element from a higher topology level A can be linked with zero or more elements at a lower topology level B. This implies that an element from level B is exclusively associated with one element from level A.

As an example, you could consider the customer topology, where multiple devices are linked to a single customer, and each device is exclusively associated with one customer.

To configure this topology, cells for both the *Device* and *Customer* levels must be created, and the relationship between them must be established. The topology configuration refers to the view tables. In this example, 3500 and 2500 are parameter IDs of the respective tables for the customer and device.

```xml
<Topologies>
    <Topology>
        <Cell name="Customer" table="3500"></Cell>
        <Cell name="Device" table="2500">
            <Link source="1" dest="3501"/>
        </Cell>
    </Topology>
</Topologies>
```

A foreign key relation also has to be defined between customer and device. This should be applied to the local tables (not the view tables). In this example, 2000 is the Device Table, and 3000 is the Customer Table:

```xml
<Relations>
    <Relation path="2000;3000"/>
</Relations>
```

> [!TIP]
> See also: [Relations](xref:UIComponentsTableRelations)

### Many-to-many relations

A many-to-many relation suggests that an item from topology level A can be connected to multiple items from another topology level B, and conversely, an item from topology level B can be linked to multiple items from topology level A.

As an example, you could consider the mesh topology, where a spine can be associated with numerous leaves, and conversely, a leaf can connect to multiple spines.

In the topology, the relation between the spines and leaves must be defined. In the following code, you can see that the leaf (view table 25500) has a connection to the spine (view table 24500):

```xml
<Topologies>
    <Topology>
        <Cell name="Spine" table="24500"/>
        <Cell name="Leaf" table="25500">
            <Link source="1" dest="24501"/>
        </Cell>

    </Topology>
</Topologies>
```

Additionally, to map out the relations, a Relation table must be created. The following code displays the configuration for the table:

```xml
<Param id="26000">
   <Name>relationSpineLeafOverview</Name>
   <Description>Relations Spine Leaf Overview Table</Description>
   <Type>array</Type>
   <ArrayOptions index="0" options=";volatile;naming=/26002" partial="true:200">
      <ColumnOption idx="0" pid="26001" type="retrieved" options="" /><!-- Index of the row -->
      <ColumnOption idx="1" pid="26002" type="retrieved" options="" /><!-- Name of the relation -->
      <ColumnOption idx="2" pid="26003" type="retrieved" options=";foreignKey=24000" /><!-- Spine ID (Foreign Key to the Spine Local table) -->
      <ColumnOption idx="3" pid="26004" type="retrieved" options="" /> <!-- Name of the Spine-->
      <ColumnOption idx="4" pid="26005" type="retrieved" options=";foreignKey=25000" /><!-- Leaf ID (Foreign Key to the Leaf Local table) -->
      <ColumnOption idx="5" pid="26006" type="retrieved" options="" /> <!-- Name of the Leaf-->
   </ArrayOptions>
   <Information>
      <Subtext>This table displays the relations between the Spines and Leaves.</Subtext>
   </Information>
   <Display>...</Display>
   <Measurement>...</Measurement>
</Param>
```

Finally, the foreign key relations must also be defined. In this example, 26000 is the parameter ID of the Relations table, 25000 refers to the Leaf Local table, and 24000 refers to the Spine Local table.

```xml
<Relations>
   <Relation path="25000;26000;24000"/>
</Relations>
```

> [!TIP]
> See also: [Relations](xref:UIComponentsTableRelations)

### Recursive relations

A recursive relationship implies that an item within a topology level A can be linked to another item on the same level A.

As an example of this, consider a chain topology where a source is connected to an amplifier. This amplifier can then be connected to any number of subsequent amplifiers in a sequence, with only the final one being linked to the splitter.

In the topology, the recursive relation between the amplifiers must be defined. In the following code, you can see that the amplifier has a connection to the Source Table (view table 2500) and to itself (view table 21500):

```xml
<Topologies>
    <Topology>
        <Cell name="Source" table="20500"></Cell>
        <Cell name="Amplifier" table="21500">
            <Link source="1" dest="21506" />
            <Link source="1" dest="20501" />
        </Cell>
    </Topology>
</Topologies>
```

Next, to represent the recursive relation, it is essential to create a Relation Table. Within this table, the relations are mapped out by defining the source entity (an amplifier) and the destination entity (the connected amplifier). The following code displays the configuration for the Relation table:

```xml
<Param id="23000">
    <Name>relationAmplifierOverview</Name>
    <Description>Relations Amplifier Overview Table</Description>
    <Type>array</Type>
    <ArrayOptions index="0" options=";volatile;naming=/23002" partial="true:200">
        <ColumnOption idx="0" pid="23001" type="retrieved" options="" /> <!-- Index of the row -->
        <ColumnOption idx="1" pid="23002" type="retrieved" options="" /> <!-- Name of the relation [Source/Destination] -->
        <ColumnOption idx="2" pid="23003" type="retrieved" options=";foreignKey=21000" />  <!-- Source Amplifier ID (Foreign Key to the Amplifier Local table) -->
        <ColumnOption idx="3" pid="23004" type="retrieved" options="" /> <!-- Source Amplifier Name -->
        <ColumnOption idx="4" pid="23005" type="retrieved" options="" /> <!-- Destination Amplifier ID -->
        <ColumnOption idx="5" pid="23006" type="retrieved" options="" /> <!-- Destination Amplifier Name -->
    </ArrayOptions>
    <Information>
        <Subtext>This table contains the relations between the amplifiers.</Subtext>
    </Information>
    <Display>...</Display>
    <Measurement>...</Measurement>
</Param>
```

Finally, the foreign key relations must also be defined. In this example, 23000 is the table parameter ID of the Relations Amplifier table, and 21000 refers to the Amplifier Local table.

```xml
<Relations>
    <Relation path="21000;23000;21000" />
</Relations>
```

> [!TIP]
> See also: [Relations](xref:UIComponentsTableRelations)
