---
uid: Connector_help_Skyline_Resource_Discovery_Rules
---

# Skyline Resource Discovery Rules

This connector can be used to create rules based on tables of other elements in order to create resources with properties and capabilities.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                             | **Exported Components** |
|-----------|---------------------|-------------------------|-------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Automation script: SwitchingApp_GenerateResourcesByDiscoveryRules | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

## How to use

This connector should be used together with the Automation script **SwitchingApp_ResourcesProvisioningByDiscovery**.

At the top, you will find a button to create resources, the status of the script, and the last successful run of the script.

Note that when resources are created, an extra property will be added: "DiscoveryCreationReference". The value of this property will be \[the element name of the Resource Discovery Rules element\]/\[the GUID of the record responsible for the creation of the resources\]. This is used for the Remove Related Resources button in the Discovery table, which allows you to delete all the resources that were originally created by this rule.

In the **Discovery Table**, you can add rows via the right-click menu. You will need to specify the following information:

- **Name**: This is used to recognize the rows.
- **Admin State**: If this is disabled, this rule will not be taken into account when creating resources.
- **View ID**: Not used yet.
- **Driver Name**: The name of the connector that will be used to create resources.
- **Element Ref**: The name of the element that will be used to create resources.
- **Table ID**: The PID of the table that will be used to create resources.
- **Column ID Resource Name**: The PID of the column that will be used to create the new resource name, which will have the format "ELEMENT NAME -" + column content.
- **Filtering rule**: A filter to include or exclude indices. At present, only specific values are supported:
  *All* or *None*, or a semicolon-separated string used to only display certain input entries in the Source Input Table. Expected format: *A;C-E;G;K-W*.
- **Resource Pool**: The pool where the resources will be created. (If the pool does not exist, the script will create it).

Via the context menu of the **Properties** table, you can add properties to resources that will be created. You will need to specify the following information:

- **FK Discovery Rule**: The GUID of the rule that will provide the resources.
- **Name**: The property name.
- **Value**: The property value (dynamic input is not supported).

Via the context menu of the **Capabilities** tables, you can add capabilities to resources that will be created. You will need to specify the following information:

- **FK Discovery Rule**: The GUID of the rule that will provide the resources.
- **Name**: The capability name.
- **Value**: The capability value (dynamic input is not supported).

NOTE: **These capabilities need to exist** in the DMS. the script will not provision them automatically.
