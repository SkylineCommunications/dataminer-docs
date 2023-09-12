---
uid: Connector_help_British_Telecom_Blackout_Schedule
---

# British Telecom Blackout Schedule

The Blackout Scheduler activates blackout events on specific PSB channels where the content provider does not have broadcast rights.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

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

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

To be able to use this connector, you must first specify the **Log Information** on the **Configuration** page:

- **Log Information File Name (Path)**
- **Log Information File Size**

Then, you must specify the following AWS credentials on the **Configuration** page of the element:

- **Access Key**
- **Secret Key**
- **AWS Region**
- **Service Name**

## How to use

The element has the following data pages:

- **General**: Displays the Blackout Schedules retrieved from the Blackout DB hosted in AWS.
- **Actions:** Allows you to add the channels for which actions must be done. Those channels are present in the Blackout Actions table.
- **Configuration:** Allows you to configure the element to start retrieving data.
