---
uid: connectorsTopologyRelationsRecursive
---
# Recusrive Relation

A recursive relationship implies that an item within a topology level A can be linked to another item within the same level A.

In the following example we have the Chain Topology, here we encounter a scenario where a Source is connected to an Amplifier. This Amplifier can then be connected to any number of subsequent amplifiers in a sequence, with only the final one being linked to the Splitter.

To represent this recursive relation, it is essential to create a Relation Table. Within this table, the relations are mapped out by defining the source entity (an amplifier) and the destination entity (the connected amplifier).

## Configuration

In the topology it is necesary to define the recursive relation between the amplifiers. In the following code we can see that the amplifier has a connection to the Source Table (View Table 2500) and to itself (View Table 21500)

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

Additionally in order to represent the recursive relations, a Relation table must be created. The following code displays the configuration for the Relation table:

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

Finally, the foreign key relations must be defined, where 23000 is the table parameter ID of the Relations Amplifier table and 21000 refers to the Amplifier Local table.

```xml
<Relations>
    <Relation path="21000;23000;21000" />
</Relations>
```
