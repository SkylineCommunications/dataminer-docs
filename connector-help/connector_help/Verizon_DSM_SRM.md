---
uid: Connector_help_Verizon_DSM_SRM
---

# Verizon DSM SRM

This connector will interface with the DataMiner SRM module in order to retrieve, add, update and delete pools and resources.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

As this is mainly a system connector, not much user interaction is needed. Below you can find the steps for the different functionalities in the connector.

### General

Clicking the **update** button will perform a **full update of the system**. It will:

- Get the latest **pools**.
- Get the latest **subscribers**.
- Get the latest **resources.**
- Get the latest **resource relations.**

### Pools

This page contains the **SRM Pool Overview** table. You can perform the following actions in this table:

- Add:

  1. Right-click anywhere within the table.
  1. Select **Add** in the context menu.
  1. Fill in the necessary information.
  1. Click OK.

- Edit:

  1. Right-click the entry you want to edit.
  1. Select **Edit** in the context menu.
  1. Fill in the necessary information.
  1. Click OK.

- Delete:

  1. Right-click the entry you want to delete.
  1. Select **Delete** in the context menu.

### Subscribers

This page contains the **SRM Subscriber Overview** table. You can perform the following actions in this table:

- Add

  1. Right-click anywhere within the table.
  1. Select **Add** in the context menu.
  1. Fill in the necessary information.
  1. Click OK.

- Edit.

  1. Right-click the entry you want to edit.
  1. Select **Edit** in the context menu.
  1. Fill in the necessary information.
  1. Click OK.

- Delete

  1. Right-click the entry you want to delete.
  1. Select **Delete** in the context menu.

### Resources

This page contains the **SRM Resource Type** table. You can perform the following actions in this table:

- Add

  1. Right-click anywhere within the table.
  1. Select **Add** in the context menu.
  1. Fill in the necessary information.
  1. Click OK.

- Edit.

  1. Right-click the entry you want to edit.
  1. Select **Edit** in the context menu.
  1. Fill in the necessary information.
  1. Click OK.

- Delete

  1. Right-click the entry you want to delete.
  1. Select **Delete** in the context menu.

### Add Resource

This page allows you to add resources to the **SRM Resource-Subscriber Relation** table via standalone parameters. To do so:

1. Fill in **all parameters.**
1. Click **Apply**.

   If you made a mistake in one of the fields, click **Reset** to replace the values with default values.

### Resource Relations

This page contains the **SRM Resource-Subscriber Relation** table. Only one action can be performed directly on this table:

- Delete:

  1. Right-click the entry you want to delete.
  1. Select **Delete** in the context menu.

### Configuration

#### Polling Configuration

The following functionalities are available in this section:

- **Update Status:** Toggle this button to control whether the system will be polled.
- **Processing Time**: Allows you to control how **frequently** the system will be polled.
- **Update**: Allows you to do a **manual poll** of the system.

#### Resource Options

The following functionalities are available in this section:

- **Auto Collect:** Allows you to toggle the automatic collecting of resources in the system on or off.
- **Auto Delete:** Allows you to toggle the automatic deletion of resources in the system on or off.
- **Auto Delete Delay**: Allows control of the delay of auto-deletion in the system based on the time stamp of resources.
- **Delete All**: Allows you to **delete all removed resources** in the system.

## Notes

The element that is running this connector should be linked to the **Verizon VSat Platform Manager** connector. For this purpose, enter the DMAID/ElementID in the **SRM Subscriber** parameter on the **Configuration** page in the **General tab.**
