---
uid: Connector_help_NBCU_Popup_Event_Manager_APP
---

# NBCU Popup Event Manager APP

The **NBCU Popup Event Manager** is the central component of the Peacock SLE (Single Live Events) solution, which collects event data from the **Popup Event Collector**. The Event Manager is also in charge of sending PIDs for monitoring to the **LEAP Collector** and activating SRM scripts to create bookings.

## About

### Version Info

| **Range**            | **Key Features**                                                            | **Based on** | **System Impact**                                             |
|----------------------|-----------------------------------------------------------------------------|--------------|---------------------------------------------------------------|
| 1.0.0.x              | Gets info from the Popup Event Collector. Sends PIDs to the LEAP Collector. | \-           | \-                                                            |
| 1.0.1.x \[SLC Main\] | Retrieves data from the LEM Collector.                                      | 1.0.0.x      | QActions involved in processing the received data could fail. |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

Elements using the NBCU Popup Event Collector and NBCU LEAP Collector connectors need to be set up.

Also, the **Popup Event Manager** should use the production version of the connector in order to get the info from the LEAP Collector.

In range 1.0.1.x, the element receives data from the **NBCU LEM Collector** connector. When you set up the element, you will need to specify the **Element IDs** in the **Collectors table** on the General page to configure the communication between the elements.

You will also need to configure the following information, depending on your setup:

- **Mapping** **table:** Information to connect **Touchstream**, **TAG**, and **Conviva** elements that are used to provision or deactivate events.
- **TAG Template:** Configure the values that are mandatory in the communication with the TAG element.

### Redundancy

There is no redundancy defined.

## How to use

Once you have configured everything mentioned under Initialization, you will be able to check the data retrieved by the connector.
