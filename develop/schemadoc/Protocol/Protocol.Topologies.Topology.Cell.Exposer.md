---
uid: Protocol.Topologies.Topology.Cell.Exposer
---

# Exposer element

Exposes this cell to the EPM crawler.<!-- RN 21101, RN 21122, RN 21465, RN 21746 -->

## Parent

[Cell](xref:Protocol.Topologies.Topology.Cell)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[enabled](xref:Protocol.Topologies.Topology.Cell.Exposer-enabled)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)|Yes|Specifies whether the exposer is enabled.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[LinkedIds](xref:Protocol.Topologies.Topology.Cell.Exposer.LinkedIds)|[0, 1]|Specifies the linked tables.|

## Remarks

The CPECollectorHelper function "GetLinkedDMAObjectRefGroupsThroughTopology" allows client apps to retrieve table rows that are linked via topology. This function requires that, in the protocols of the EPM collector elements, the Topology.Cell tags map to names of table cells on the EPM elements that must be polled, and that each of those Topology.Cell tags also contains an Exposer tag.<!-- RN 21101 -->

For example:

```xml
<Topologies>
   <Topology>
      <Cell name="Amplifier" table="500">
         <Exposer enabled="true">
            <LinkedIds>
               <LinkedId columnPid="1001">1000</LinkedId>
            </LinkedIds>
         </Exposer>
      </Cell>
   </Topology>
</Topologies>
```

In the example above, the "Amplifier" cell has been exposed to the EPM crawler, which will retrieve the data. This means that table 500 can be searched using the above-mentioned function.

Also note that, inside the Exposer element, you can add linked tables. In the example, table 1000 is linked to table 500 using column parameter ID 1001.

> [!NOTE]
>
> - If a protocol contains at least one Protocol.Topologies.Topology.Cell element, two properties will be created on the DataMiner Agent: "System Type" and "System Name". Alarms generated in tables defined in Cell@table attributes will have their "System Type" property set to the value of the Cell@name attribute and their "System Name" property set to the row's display key.
>
>   - If an exposer is defined with a LinkedId, it will receive the same property values. The "System Name" property will be set to the display key of the table defined in Cell@table as resolved by the foreign key relations. If no link can be resolved, then the display key of the original row will be used.
>   - If a LinkedId element has a columnPid attribute containing a column parameter ID in the LinkedId table, then the alarm's "System Name" property will be set to the value found in the specified column.
>   - For a correct EPM configuration, from DataMiner 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5 onwards, it is important that the system type for each element manager protocol is unique, as it is the system type that will be used to trace EPM objects back to their respective front-end managers. If you for example have an "HFC" and an "IOT" element manager in your system, these cannot both have a "Location" cell. Instead, you can prefix this, e.g. "HFC_Location" and "IOT_Location", respectively.
>
> - If the topology contains view tables instead of physical tables, then the above-mentioned alarm properties will also be filled in. However, note that if view tables are used, secondary tables are currently not able to retrieve display keys of primary tables.
> - This feature will only works with Protocol.Topologies.Topology elements, not with legacy Protocol.Topology elements.
