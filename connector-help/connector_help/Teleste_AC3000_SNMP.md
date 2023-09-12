---
uid: Connector_help_Teleste_AC3000_SNMP
---

Teleste AC3000 SNMP

This driver is the **SNMP** version of the Teleste AC3000 (serial driver).

## About

With this driver it is possible to monitor **Teleste AC3000** devices with **SNMP**.

### Ranges of the driver

| **Driver Range**     | **Description** | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |



## Installation and configuration

### Creation

The ****Teleste AC3000 SNMP**** is a **SNMP** driver. The **IP** needs to be configured during creation of the **element**.

#### SNMP CONNECTION:

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: \[The polling IP of the device.\]
- **Device address**: \[Indicate if required or not. If it is, specify default value and range.\]

SNMP Settings:

- **Port number**: \[The port of the connected device, by default *161*.\]
- **Get community string**: \[The community string used when reading values from the device
  (default value if not overridden in the driver: *public*).
  Note: If you have specified a default value in the driver, then specify that custom value.\]
- **Set community string**: \[The community string used when setting values on the device
  (default value if not overridden in the driver: *private*).
  Note: If you have specified a default value in the driver, then specify that custom value.\]

## Usage

### General Page

This page displays some general information of the device such as **Element Settings, Status Information**. The Element Settings section, displays some generic information related to the element such as **Name, Structure** etc.

### Module Page

In this page, we display tables with information regarding the modules. These tables include, **Module Table, Module Detail Table and Module Status Table** respectively.

### Event Log Page

In this page we display the **Event Log table** along with few other details related to the **Event** Logs.

### Forward Path Page

In this page we display the values referent to the Forward Path. In the **Forward Path Settings** section, the user will be able to make configure parameters such as **Band, Status, Type** etc. Similarly, routing related settings can be configured within the **Forward Path Routing** section. This page also contains **Level Detector** pagebutton. In this page we display the **Level Detector Table**.

### Return Path Page

Similar to the **Forward Path Page**, In this page we display the values referent to the Return Path. In the **Return Path Settings** section, the user will be able to make configure parameters such as **Band, Status, Amplifier Type** etc. Similarly, routing related settings can be configured within the **Return Path Routing** section. This page also contains **Level Control** and **Automatic Ingress Blocking** pagebuttons. In this page we display the **Level Control Table**.

### Transponder Page

In this page, we display **Receiver Settings** and **Transmitter Setiings**.

### Web Interface Page

In this page we display the web interface of the device.
