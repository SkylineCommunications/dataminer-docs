---
uid: Connector_help_TR_Electronic_GmbH_AV_Switch
---

# TR Electronic GmbH AV Switch

This connector implements the TR Electronic GmbH Remote Control Protocol, which allows you to monitor and control Audio/Video Switch cards.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V1.31.283              |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection - Infrastructure Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (fixed value: *10050*).

#### Serial Serial Connection - Remote Control Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *5554*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The connector can have multiple slots associated with it. You can find the slot overview information on the **Slots** page.

Depending on the slot availability, the connector loads the associated polling calls to the **Polling Configuration** table on the **Configuration** page. There you can define a period for each call or even disable the call.

If a slot is no longer available, the information about the slot is automatically removed from all the other tables that contain the information related to that specific slot.

### Configuring parameters

When you configure a parameter, the **Lock Status** in the **Embedder Controls** table must be set to *Remote Access Locked*.

If the Lock Status is set to something else, the connector will automatically set it to *Remote Access Locked* when a set needs to be performed. After a change is made to a parameter, the Lock Status will be set to *Disabled.* This forces the change to be saved on device's SD card.

Note that when a change is applied, a **transition time** may be required for the change to take place on the device.
If a change is applied and **nothing changes** after the configured polling period time, this means that the device did not accept the change because of an **invalid configuration**.
