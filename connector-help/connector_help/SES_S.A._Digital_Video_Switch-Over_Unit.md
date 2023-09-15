---
uid: Connector_help_SES_S.A._Digital_Video_Switch-Over_Unit
---

# SES S.A. Digital Video Switch-Over Unit

The **Digital Video Switch-Over Unit** connector was developed for a custom-made "digital video switch-over unit". This custom-made device acts as a redundancy switch-over unit for 1:1 redundant digital satellite receivers delivering a digital video signal. In this context, the device monitors alarm status from the connected prime and back-up receivers and, depending on the programmed logic, it will switch from the prime receiver to the back-up receiver (or vice-versa). The logic of the coax relays to perform the physical video switch is controlled by a MOXA IO Logic E2210V2 device. In this line, the **Digital Video Switch-Over Unit** connector uses monitors to subscribe to events from the Moxa ioLogik E2210 connector and to perform sets on the device when necessary.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial versions | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

Once the element has been created, select the **Moxa ioLogik E2210** protocol version and the corresponding element for monitoring on the **Settings** page.

### Redundancy

There is no redundancy defined.

## How to use

When the correct Protocol Version and Monitored Element have been selected on the Settings page, information about the element becomes available on both the Settings and General pages.

On the General page, you can then also switch between *Auto* and *Remote* mode. If the unit is set to *Remote* mode, you can set the Switch Position Relay to *Unit A* or *Unit B*.
