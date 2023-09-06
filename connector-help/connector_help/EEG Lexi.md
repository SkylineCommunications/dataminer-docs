---
uid: Connector_help_EEG_Lexi
---

# EEG Lexi

The EEG Lexi is a cloud-hosted automatic captioning service. It supports connections from any EEG encoder like HD492, EN537, Alta, or Falcon.

The connector monitors the instances, engines, models, and custom models. Among others, it allows you to create or delete instances as well as switch their state.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                                                                              | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version                                                                                                                                                                                                                               | \-           | \-                |
| 1.0.1.x              | \- Added Recent Session Instances Table to the Instances page. - Adjustments to sets on the Instances table. - Reworked License Status functionality of the Languages table. - Added columns to Instances, Topic Model, and Languages tables. | 1.0.0.4      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | 10.0.10.0 - 9454       |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

When the element has been created, also configure the parameters on the **General** page, under **Credentials**.

- **Username**: The username used to log in to EEG Lexi.
- **Password**: The password used to log in to EEG Lexi.

### Redundancy

There is no redundancy defined.

## How to use

When the element has been created and the correct credentials have been filled in on the General page, it will automatically begin to poll the information of the engines, models, base models, and instances.

On the Instances page, you can perform the following actions:

- **Switch State:** Click this button for an instance to change the current state of the instance (On/Off).

- Right-click menu options:

- **Add:** Opens a window where you can specify the basic parameters to create a new instance.
  - **Delete:** Allows you to delete an instance.
