---
uid: Connector_help_Arista_Routing_Manager
---

# Arista Routing Manager

This connector is used to aggregate routing data from Arista Manager elements. This aggregation is done using the Arista Routing Manager script. This script can be launched from Visual Overview or independently.

## About

### Version Info

| **Range** | **Key Features**                   | **Based on** | **System Impact** |
|-----------|------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version.                   | \-           | \-                |
| 1.0.1.x   | Changes to the Routing Info table. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                                                                          | **Exported Components** |
|-----------|---------------------|-------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \- AristaRoutingManagerScript: Automation script used to retrieve information from Arista Manager elements. - Arista Manager protocol (2.0.7.x): Contains routing information for this connector. | \-                      |
| 1.0.1.x   | No                  | Yes                     | Same as the previous range.                                                                                                                                                                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

In order to aggregate routing information through the linked Automation script, you need to define at least one channel in the **Channels** table. You can do so by right-clicking the table and selecting the relevant option in the context menu.

### Redundancy

Redundancy is not defined in the connector.

## How to Use

When you set up a new Arista Routing Manager element, first specify the channels in the **Channels** table.

Next, launch the **Arista Routing Manager Script** and provide an Arista Manager element and the key (=Group) of the row in the **IP Multicast Routing Table**.

If everything checks out, a dialog box will appear where you can specify the Channel (retrieved from the Channels table in the Arista Routing Manager element), the Flow and the Pair for the route. After you click OK, the Source value of the specified IP Multicast Routing Table row is used to retrieve routes from all Arista Manager elements on the DMA that have the same source. These routes will be added to the **Routing Info** table in the Arista Routing Manager. The **Multicasts** table will also be filled in based on this information.

When you remove a channel via the right-click menu, the linked multicasts and routes will be removed as well. Removing a multicast will only remove the linked routes.
