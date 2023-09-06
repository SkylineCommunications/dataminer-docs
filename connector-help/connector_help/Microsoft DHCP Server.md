---
uid: Connector_help_Microsoft_DHCP_Server
---

# Microsoft DHCP Server

This connector allows you to extract data from a DHCP server through PowerShell commands.

## About

### Version Info

| **Range**            | **Key Features**                                                                             | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version:- Added Commands Configuration Table- Added Scopes Table- Added Leases Table | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**   |
|-----------|--------------------------|
| 1.0.0.x   | PowerShell 5.1 or higher |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

When you have created an element with this connector, configure the following parameters on the **Configurations** page:

- **PowerShell User Name** and **PowerShell Password**: The username and password of an account with permissions to execute the commands.
- **DHCP Server**: The target DHCP hostname to be used in the commands.

If this is not or not correctly configured, the element will not be able to display any data.

### Redundancy

There is no redundancy defined.

## How to use

This connector connects to the host's PowerShell and executes predefined PowerShell commands to display data.

On the **Configurations** page, several parameters need to be configured for the connector to be able to fetch data (see "Initialization" section above). This same page also contains a **Commands Configuration** Table where you can configure the **Refresh Period** (time interval between each command call of the same type) and you can force the execution of a call by clicking the **Update** button.

The currently implemented commands are:

- *Get-DhcpServerv4Scope -ComputerName \<****DHCP Server****\>* Default period: 1 hour. This command is used to fill in the **Scopes**Table
- *Get-DhcpServerv4Lease -ComputerName* *\<****DHCP Server****\>* *-ScopeId \<Scope ID\>*Default period: 1 hour. This command is used to fill in the **Leases** Table.

All the information about **Scopes** and **Leases** is displayed on the **General** page.
