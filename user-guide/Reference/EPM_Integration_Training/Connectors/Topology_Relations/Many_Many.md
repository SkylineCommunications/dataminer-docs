---
uid: connectorsTopologyRelationsManuMany
---
# Many to Many Relation

A many-to-many relation suggests that an item from a topology level A, can be connected to multiple items from another topology level B, and reciprocally, an item from topology level B can be linked to multiple items from topology level A.

Consider the Mesh Topology example, where a Spine can be associated with numerous Leafs, and conversely, a Leaf can connect to multiple Spines.

To map out the relations it is necessary to create a Relation table.

## Configuration

In the topology it is necesary to define the relation between the Spines and Leafs.
In the following code we can see that the Leaf (View table 25500) has a connection to the Spine (View Table 24500).

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

Additionally, in order to represent the many-to-many relations, a Relation table must be created. The following code displays the configuration for the table:

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
		<Subtext>This table displays the relations between the Spines and Leafs.</Subtext>
	</Information>
	<Display>...</Display>
	<Measurement>...</Measurement>
</Param>
```

Finally, the foreign key relations must be defined, where 26000 is the parameter ID of the Relations table, 25000 refers to the Leaf Local table and 24000 refers to the Spine Local table.

```xml
<Relations>
	<Relation path="25000;26000;24000"/>
</Relations>
```