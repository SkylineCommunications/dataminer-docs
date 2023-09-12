---
uid: Connector_help_Black_Box_Boxilla
---

# Black Box Boxilla

This connector can be used to monitor and configure the Black Box Boxilla. This is a centralized KVM/AV manager that connects and manages several signal extension solutions, enabling centralized secure remote access to an unlimited number of endpoints (computers and virtual machines) from one single access point.

## About

### Version Info

| **Range**            | **Key Features**        | **Based on** | **System Impact** |
|----------------------|-------------------------|--------------|-------------------|
| 1.0.0.x \[OBSOLETE\] | POC. Pings the device.  | \-           | \-                |
| 2.0.0.x \[SLC Main\] | Initial implementation. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 2.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use - Range 2.0.0.x

The following pages are available:

- **General**: Includes general parameters such as HTTP Request Status, Authentication Status, User, and Connection Password.
- **Connections**: Includes the **Data Port Control** table as well as controls such as **Reboot**, **Trap Port Select**, **System Mode**, and various monitoring controls.
- **Users**: Includes the **Users table** and the page button to the **Create User** page, where you can create a user.
- **Devices**: Includes the Devices table.
- **Active Connections**: Includes the Active Connections table.
- **Zones**: Includes the Zones table and a page button to the **Create Zone** page where you can create a zone
