---
uid: Connector_help_Huawei_iMaster_NCE
---

# Huawei iMaster NCE

The Huawei iMaster NCE provides centralized management, control, and analysis of global networks. It is mainly used in data center, enterprise campus, enterprise private line, and carrier network scenarios. It enables resource cloudification, full life cycle automation, and analytics-driven intelligent closed-loop management according to business and service intents. This protocol uses the northbound **REST API** of the iMaster NCE.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | REST API V100R019C10   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                    |
|-----------|---------------------|-------------------------|-----------------------|------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | [Huawei iMaster NCE - Network Element](xref:Connector_help_Huawei_iMaster_NCE_-_Network_Element) |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

To initialize the connector, go to the **Configuration** page of the element, fill in the **Username** and **Password** parameters, and click the **Authentication** button.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product. You also need to fill in the **Web Interface Address** parameter on the **Configuration** page.

## How to use

The **General** page displays a table containing all network elements managed by the iMaster NCE.

On the **Network Elements DVEs** subpage, you can **enable or disable a DVE** for each network element in the Network Elements DVEs Management table.

On the **Racks**, **Cards**, **Frames**, **Slots**, **Ports**, and **ONUs** pages, you can find tables with information related to these subjects.

The **Alarms** page shows a table listing all alarms. You can configure if cleared alarms should be displayed in this table or not. There are also two subpages:

- **Statistics:** Shows alarm statistics, such as the number of total critical/major/minor/warning alarms.
- **Shelf:** Contains the Shelved Alarms table.
