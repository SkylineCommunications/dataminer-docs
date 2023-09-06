---
uid: Connector_help_OneWeb_Antenna_Controller
---

# OneWeb Antenna Controller

The **OneWeb Antenna Controller** is a manager connector used to control all the satellite access points in the OneWeb network.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

## How to Use

The **General** page displays the full topology of the OneWeb system: all the **Ground Stations** and the **Satellite Access Points** are displayed in tables. The topology is automatically updated every hour. You can also refresh it manually with the **Retrieve Topology** button.

To retrieve the topology, the connector detects all the views under a root view. You can set the name of that root view using the parameter **Sites View**. By default, the value of that parameter is set to *Sites*.

Every view under the root view corresponds to a ground station. The latitude and longitude of the ground station are extracted from the view properties **yPos** and **xPos**. Every view under a ground station view corresponds to a satellite access point.
