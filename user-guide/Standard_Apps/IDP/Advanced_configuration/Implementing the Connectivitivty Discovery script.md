---
uid: ConnectivityDiscoveryScript
---

# Implementing the Connectivity Discovery script

DataMiner IDP can be used to provision [DCF connections](xref:About_the_DataMiner_Connectivity_Framework) between [elements](xref:About_elements) in the managed inventory. However, before DCF connections can be provisioned, the topology needs to be discovered.

## About Connectivity Discovery scripts

A [CI Type](xref:CI_Types1) can be configured with a script that will be used to discover the connectivity for the element of this CI Type. This script will typically read element data (like information from LLDP or CDP tables) and pass this on to DataMiner IDP.

The script integrates with the connector and the element, and it will be executed for a specific element. For this reason, we strongly recommend that you limit the scope of the script to that single element. That means that it should not use information from neighboring equipment. In a multi-vendor environment, you would otherwise need to support a lot of connectors in a single script.

> [!TIP]
> An example script *IDP_Example_Custom_ConnectivityDiscovery* is available in the Automation module after IDP has been installed. You can duplicate this script to use it as a starting point.

## Unresolved connections

The Connectivity Discovery script needs to call certain C# methods to inform IDP of the neighborships discovered on the element. However, the information the element can provide will typically not be enough to provision DCF connections. That is why we call these **unresolved connections**: the detected neighborship does not have enough information for DCF connections to be provisioned.

There is only enough information when a connectivity discovery on another element leads to another unresolved connection that can be combined with the first. DataMiner IDP will automatically combine two unresolved connections into a **discovered connection**. A discovered connection contains enough information to be able to provision a DCF connection for it.

## Combining unresolved connections into discovered connections

A DCF connection exists between two DCF interfaces of two elements. As such, to provision a DCF connection, the following things need to be known:

- The source DMA and element ID
- The source DCF interface ID
- The destination DMA and element ID
- The destination DCF interface ID

At the same time, the custom script is linked to the CI Type and should only use the information available in the element itself.

A network protocol that allows the equipment to discover neighboring network equipment (like LLDP, CDP, etc.) will have:

- A unique way to identify equipment. The equipment will be given an identifier that no other equipment is using. We refer to this as the **Local Chassis ID**.
- A unique way to identify interfaces on the equipment. This can be different from the typical interface ID. We refer to this as a **Local Port ID**.
- The ability to see on which interfaces neighbors are detected. The neighbors are detected with their unique identifiers. From the perspective of local equipment, these are **Remote Chassis IDs**. The local port IDs of the neighbor are perceived as the **Remote Port IDs**.

If the equipment runs such a network protocol, the connector will have or will need to be extended with the information above. The custom script can then provide IDP with the following information regarding neighbors of the equipment:

- The DataMiner and element ID of the element.
- The unique identifier (i.e. the Local Chassis ID) of the equipment.
- For each neighbor of the equipment:

  - The DCF interface ID on which the neighbor is detected.
  - The local port ID on which the neighbor is connected.
  - The remote chassis ID of the neighbor.
  - The remote port ID. This is the port ID that uniquely identifies the interface on the neighbor.

Each neighborship becomes an **unresolved connection**.

The table below shows the result of a connectivity discovery activity on element 17/253 reporting two neighborships:

| DMA/EID | Local Chassis ID | Local Port ID | Local DCF ID | Remote Chassis ID | Remote Port ID |
|-- | -- | -- | -- | -- | -- |
|17/253|0B:04:49:D7:A5:BB|Ethernet2|100030|29:B3:20:09:44:FE|Ethernet33|
|17/253|0B:04:49:D7:A5:BB|Ethernet18|100014|38:ED:97:AC:FE:7C|Ethernet12|

Although IDP already knows the DMA ID, element ID, and DCF interface ID of the local element, it still needs to resolve the identifiers of the other end of the connection.

A connectivity discovery on the element 17/654 could for example occur and report two neighborships:

|DMA/EID|Local Chassis ID|Local Port ID|Local DCF ID|Remote Chassis ID|Remote Port ID|
|-- | -- | -- | -- | -- | -- |
|17/654|29:B3:20:09:44:FE|Ethernet33|100017|0B:04:49:D7:A5:BB|Ethernet2|
|17/654|0B:04:49:D7:A5:BB|Ethernet13|100007|37:CC:AA:B3:CC:D8|Ethernet21|

If you look carefully at both unresolved connections from 17/253 and 17/654, you will see that the Remote Chassis ID and Remote Port ID of the first neighborship of 17/654 match with the Local Chassis ID and Local Port ID of the first neighborship of 17/253. As these two values match, IDP will combine the unresolved connections into a **discovered connection**.

|Source DMA/EID|Source DCF ID|Destination DMA/EID|Destination DCF ID|
|--|--|--|--|
|17/253|100030|17/654|100017|

The discovered connection contains enough information to allow IDP to provision the DCF connection.

## Adding DCF interface properties

When the script informs IDP of the neighborships, the DCF interfaces can be extended with DCF interface properties if a name, type, and value for the properties is provided.

When DCF connections are provisioned, IDP will also provision these DCF interface properties.

Additionally, IDP automatically provisions the following DCF interface properties:

- **DataMiner IDP Port ID** : The local port ID, as supplied by the script.
- **DataMiner IDP Interface Type**: The type of the interface e.g. Ethernet. This also supplied by the script.

## Provisioning DCF connections

When all unresolved connections have been combined in discovered connections for an element, DataMiner IDP will automatically provision the discovered connections for the element.

In the IDP app, you can also manually provision the discovered connections of the elements from the tab *Connectivity* > *Discovery*.

When a discovered connection is provisioned:

- A new DCF connection will be created if no DCF connection exists between the given DCF interface of the source element and the given DCF interface of the destination element.
- The DCF connection will be updated when a DCF connection already exists.

  - A new DCF interface property will created when a property with the provided name and type does not exist. The value will be set to the provided value.
  - The value of an existing DCF interface property will be updated when a property with the provided name and type already exists.

DataMiner IDP will not remove any DCF connections or DCF interface properties.
