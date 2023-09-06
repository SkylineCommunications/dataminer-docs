---
uid: Connector_help_Telenet_BGP_Trap_Receiver
---

# Telenet BGP Trap Receiver

The Telenet BGP Trap Receiver is a solution designed for Telenet that receives BGP Event Alarm traps and displays a uniform view of those alarms based on additional information from Telenet's Network Inventory Management system.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

The driver uses two connections: SNMP to receive alarm traps and HTTP to perform REST API requests.

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *cpe_timos_bgp_trap*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### HTTP Extra Connection 1 Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *5002*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

Once the element has been created, you need to configure the following settings to be able to use it:

- SNMP trap configuration:

- On the **SNMP Trap Configuration**page, select the **IP Address Range** and the respective **IP Netmask** range and add an entry to the table.
  - Via the **Load CSV** page button, you can preload a range of values from a CSV file with the same structure as in the table. The file or files must be located in the following directory: *C:\Skyline DataMiner\Documents\Telenet BGP Trap Receiver.*

- REST API:

- To poll the information from the Network Inventory Management System, go to the **Network Inventory** page and click the **REST API** page button, and then define the **REST API Key**.
  - To load the information from the Network Inventory, click the **Load NIM**button located on the same **REST API** subpage.

### Redundancy

There is no redundancy defined.

## How to use

The driver only polls information per request of the user, i.e. whenever you click the button to retrieve information from Telenet's Network Inventory Management system. Apart from that, the driver also receives information via SNMP traps.

The element created with this driver consists of the data pages detailed below.

### BGP Events

This page displays every BGP event in the **BGP Event Table**. The following table functionalities are available:

- **Clear Selected** button: Clears every selected alarm in the table (in the **Selected** column).
- **Reset Selected** button: Resets the alarm selection in the table (in the **Selected** column) for clearance afterwards.
- **Clear All**: Clears all of the alarm events in the table.

You can also clear a specific row selection with the **Clear** button for that row.

### Network Inventory

In the **Network Inventory Management Table**, this page displays an inventory of network equipment from Telenet that is retrieved through an HTTP REST API.

You can clear every entry from the table using the **Clear All** button.

Via the **REST API** page button, you can configure the REST API and load the inventory.

### Trap Configuration

This page allows you to configure the trap receiver with the following parameters:

- **IP Range:** The IP address range (IPv4) that should be monitored by the trap receiver.
- **IP Netmask:** The IP netmask (from 24 to 32 bits) that should be used for the IP address in **IP Range**.
- **Add Entry:** Adds an entry to the **IP Address Range Table**.
- **Delete All**: Deletes every entry in the **IP Address Range Table**.

Finally, the **Load CSV** page button allows you to load a CSV file into the table, assuming that the file has the same structure as the table. The CSV file must be located in the following DataMiner folder: *C:\Skyline DataMiner\Documents\Telenet BGP Trap Receiver*.
