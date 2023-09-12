---
uid: Connector_help_KVM-TEC_Switching_Manager
---

# KVM-TEC Switching Manager

The **KVM Switching Manager** **software** is used to manage a KVM network. It allows up to 2000 endpoints as well as super-fast switching. A wide range of different sources (servers, operator workstations, PCs, surveillance cameras, video walls, etc.) can be connected. The entire system can be operated and controlled via a centralized management Network Environment.

This connector allows you to monitor the **users, groups, and extenders**.

## About

### Version Info

| **Range**            | **Key Features**                   | **Based on** | **System Impact** |
|----------------------|------------------------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | Initial version                    | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Improved Extender Info API polling | 1.0.0.4      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.0.1                  |
| 1.0.1.x   | 1.0.1                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

### Initialization

To be able to use the connector, specify the correct **Username** and **Password** on the **General** page. The Connection Status will change to *Connected* when the connection with the KVM Switching Manager has been established.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element consists of the following data pages:

- **General**: Allows you to connect to the KVM Switching Manager (see Initialization section above) and shows **version** and the **connection status** information.
- **General Settings**: Contains basic settings and information for the switch.
- **Network Interfaces**: Lists the network interfaces.
- **Extenders**: Lists all extenders. You can also see which **group** they are in. The **Extender Settings** subpage allows you to change the settings of an extender, as well as to view extender info and update status info.
- **Mouse, Glide and Switch**: Contains a table with the mouse glide switch configurations as well as a table listing the configured virtual monitors.
- **Roles:** Contains an overview of all users and user groups. The same information is available in table form on the **Users and Groups** subpage. On the **Roles Settings** subpage, you can add or remove a user from a group by first selecting the user in the Edit Username box, then selecting the group in the Edit Group box, and then clicking the relevant button. You can also delete a group.
