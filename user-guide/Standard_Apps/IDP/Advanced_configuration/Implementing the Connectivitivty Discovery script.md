---
uid: ConnectivityDiscoveryScript
---

# Implementing the Connectivity Discovery script

DataMiner IDP can be used to provision DCF connections between the elements in the managed inventory. But before DCF connections can be provisioned, the topology needs to be discovered.

## Introduction

A CI Type can be configured with a script that will be used to discover the connectivity for the element of this CI Type. This script will typically read element data (like information from LLDP or CDP tables) and pass this on to DataMiner IDP.

This script integrates with the connector and the element (the digital twin of the equipment). The script will be executed for a specific element and that is why it is strongly advised to limit the scope of the script to that single element. That is, it should not use information from neighboring equipment. In a multi-vendor environment, otherwise you would need to support a lot of connectors in a single script. 

> [!TIP]
> An example script IDP_Example_Custom_ConnectivityDiscovery is available in the Automation module after IDP has been installed. This script can be duplicated and can be used as a starting point.

## Unresolved connections

This script needs to call certain C# methods to inform IDP of the neighborships discovered on the element.  However, the information the element can provide, will typically not be enough to provision DCF connections. That is why we call these **unresolved connections**: the detected neighborship doesn’t have enough information for DCF connections to be provisioned. 

There is only enough information when a connectivity discovery on another element leads to another unresolved connection which can be combined with the first. DataMiner IDP will automatically combine two unresolved connections into a **discovered connection**. A discovered connection contains enough information to be able to provision a DCF connection for it. 

## How unresolved connections are combined to discovered connections

Let us first take a step back and look at the desired outcome: what we want to achieve is to provision DCF connections. 

A DCF connection exists between two DCF interfaces of two elements. So, to provision a DCF connection it’s required to know

1. The source DMA and Element ID
1. The source DCF Interface ID
1. The destination DMA and Element ID
1. The destination DCF Interface ID

At the same time, the custom script is linked to the CI Type and should only use the information available in the element itself. 

A network protocol that allows the equipment to discover their neighboring network equipment (like LLDP, CDP…) will have

1. a unique way to identify equipment. That is: the equipment will be given an identifier which no other equipment is using. We refer to this as the **Local Chassis ID**.
1. a unique way to identify interfaces on the equipment. This can be different than the typical interface ID. We refer to this as a **Local Port ID**.
1. the ability to see on which interfaces neighbors are detected.
1. the neighbors are detected with their unique identifiers. From the perspective of local equipment, these are **Remote Chassis IDs**.

If the equipment runs such network protocol, the connector will have (or needs to be extended with) the above information. When this is done, the custom script can provide IDP with the following information regarding neighbors of the equipment:

1. the DataMiner and Element ID (of the element)
1. the unique identifier (the Local Chassis ID) of the equipment
1. for each neighbor of the equipment
    1. The DCF interface ID on which the neighbor is detected. 
    1. The local port ID on which the neighbor is connected
    1. The remote chassis ID of the neighbor
 
Each neighborship becomes an **unresolved connection**.
 
In the below, a connectivity discovery activity on element (17/253) has reported two neighborships.

| DMA/EID | Local Chassis ID | Local Port ID | Local DCF ID | Remote Chassis ID | Remote Port ID |
|-- | -- | -- | -- | -- | -- |
|17/253|0B:04:49:D7:A5:BB|Ethernet2|100030|29:B3:20:09:44:FE|Ethernet33|
|17/253|0B:04:49:D7:A5:BB|Ethernet18|100014|38:ED:97:AC:FE:7C|Ethernet12|

Although IDP already knows the DMA ID, Element ID and DCF Interface ID of the local element, it still needs to resolve the identifiers of the other end of the connection.

Let’s say that a connectivity discovery on the element (17/654) occurs and reports two neighborships. 

|DMA/EID|Local Chassis ID|Local Port ID|Local DCF ID|Remote Chassis ID|Remote Port ID|
|-- | -- | -- | -- | -- | -- |
|17/654|29:B3:20:09:44:FE|Ethernet33|100017|0B:04:49:D7:A5:BB|Ethernet2|
|17/654|0B:04:49:D7:A5:BB|Ethernet13|100007|37:CC:AA:B3:CC:D8|Ethernet21|

If you look carefully at both unresolved connections from 17/253 and 17/654, you’ll see that the Remote Chassid ID and Remote Port ID of the first neighborship of 17/654 match with the Local Chassis ID and Local Port ID of the first neighborship of 17/253. As these two values match IDP will combine the unresolved connections into a **discovered connection**.

|Source DMA/EID|Source DCF ID|Destination DMA/EID|Destination DCF ID|
|--|--|--|--|
|17/253|100030|17/654|100017|

The discovered connection contains enough information to let IDP provision the DCF connection. 

##	Enriching with DCF Interface properties

When the script informs IDP of the neighborships, the DCF Interfaces can be extended with DCF interface properties by supplying a name, type, and value for the property. 

When DCF connections are provisioned, IDP will also provision these DCF Interface properties.

Additionally, IDP automatically provisions the following DCF interface properties: 

- **DataMiner IDP Port ID** : the local port ID, as supplied by the script 
- **DataMiner IDP Interface Type**: the type of the interface e.g. Internet. This also supplied by the script)

## How DCF connections are provisioned

When all unresolved connections have been combined in discovered connections for an element, then DataMiner IDP will automatically provision the discovered connections for the element.

A user can also manually provision the discovered connections of the elements from the tab Connectivity > Discovery.  

When provisioning a discovered connection, then

- A new DCF connection will be created if no DCF connection exists between the given DCF interface of the source element and the given DCF interface of the destination element.
- The DCF connection will be updated when a DCF connection exist 
    - A new DCF Interface properties will created when a property with the provided name and type does not exist. The value will be set to the provided value.
    - The value of an existing DCF Interface Property value will be updated when a property with the provided name and type exists. 

DataMiner IDP will not remove any DCF connections and DCF interface properties.

