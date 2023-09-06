---
uid: Connector_help_ORF_Indigo_API
---

# ORF Indigo API

The ORF Indigo API interacts with the Indigo frame booking system.

## About

The ORF Indigo API communicates via HTTP.

### Version Info

| **Range**           | **Key Features**     | **Based on** | **System Impact** |
|---------------------|----------------------|--------------|-------------------|
| 1.0.0.x\[SLC Main\] | Resource management. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v1                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: \[The polling IP or URL of the destination.\]
- **IP port**: \[The IP port of the destination.\]
- **Device address**: \[The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.\]

### Initialization

The username, password and client ID should be filled in on the **General** page.

### Redundancy

There is no redundancy defined.

## How to use

### Resources

You can specify what resource groups (pools) you are interested in and indicate if the resources should be synchronized with Indigo. These resources will then be added to the resource table.

### Bookings

The **Frame Bookings** table is an overview of the frame bookings that are available on the system. These are the parent bookings.

For each frame booking there will be one or more line bookingsavailable in the **Line Bookings** table.

### Examples

N/A

## Notes

N/A
