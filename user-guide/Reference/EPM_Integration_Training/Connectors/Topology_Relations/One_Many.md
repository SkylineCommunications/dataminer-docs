---
uid: connectorsTopologyRelationsOneMany
---
# One to Many Relation

A one-to-many relation indicates that an element from a higher topology level A can be linked with zero or more elements at a lower topology level B. This implies that an element from level B is exclusively associated with one element from level A.

In the subsequent sections, we explore the Customer Topology, where multiple devices are linked to a single Customer, and each device is exclusively associated with one Customer.

## Configuration

To configure the topology, cells for both the Device and Customer levels must be created, along with establishing the relationship between them. Note that the topology configuration refers to the View Tables, where 3500 and 2500 are parameter IDs of the respective tables of the Customer and Device.

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

Additionally, it is necessary to define a Foreign key relation between Customer and Device. This should be applied to the Local Tables (not the View Tables), where 2000 is the Device Table and 3000 is the Customer Table.

```xml
<Relations>
    <Relation path="2000;3000"/>
</Relations>
```