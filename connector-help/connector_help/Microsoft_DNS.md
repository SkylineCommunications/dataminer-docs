---
uid: Connector_help_Microsoft_DNS
---

# Microsoft DNS

This connector allows you to extract data from a DNS server through PowerShell commands.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                   | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version: - Added Commands Configuration Table - Added A Records and feature to add A Record commands from context menu - Added PTR Records | \-           | \-                |

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
- **Default DNS Server**: The target DNS hostname to be used in the commands.
- **Default Zone Name**: The target zone name to be used in the commands.

If this is not or not correctly configured, the element will not be able to display any data.

### Redundancy

There is no redundancy defined.

## How to use

This connector connects to the host's PowerShell and executes predefined PowerShell commands to display data.

On the **Configurations** page, several parameters need to be configured for the connector to be able to fetch data (see "Initialization" section above). This same page also contains a **Commands Configuration** Table where you can configure the **Refresh Period** (time interval between each command call of the same type) and you can force the execution of a call by clicking the **Update** button.

The currently implemented commands are:

- *Get-DnsServerResourceRecord -ComputerName \<***Default*** **DNS Server**\> -ZoneName \<**Default** **Zone Name**\> -RRType "A"
  *Default period: 1 hour. This command is used to fill in the **A Records** Table.
- *Get-DnsServerResourceRecord -ComputerName *\<***Default*** **DNS Server**\>* -ZoneName *\<**Default** **Zone Name**\>* -RRType "PTR"
  *Default period: 1hour. This command is used to fill in the **PTR Records** Table.

All the information about **A Records** and **PTR Records** is displayed on the **General** page.

### A Records Custom commands

The right-click menu of the **A Records** table provides access to the following actions:

- **Add A Records Command**: Specify the DNS Server and Zone Name and click OK to add a command to the **Commands Configuration** Table.
- **Delete A Records Command**: Specify the command that should be deleted and click OK to delete a command from the **Commands Configuration** Table.

You can also delete a command from the **Commands Configuration** table directly by selecting the command, right-clicking, and selecting Delete Command. Note that only custom commands can be deleted.
