---
uid: Connector_help_Huawei_UPS_AC
---

# Huawei UPS AC

This driver can be used to monitor and configure Huawei UPS AC devices.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | -Displays relevant information about the outputs, inputs, bypass and parallel systems. -Displays active alarms. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V100R003C01SPC411      |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the following data pages:

- **General**: Displays general information about the device such as the **Number of Devices**, **Number of Parallel Systems**, **Environment Temperature** and **Humidity**.
- **Input** and **Output**: These two pages display information regarding the inputs and outputs, such as the **Voltages**, **Currents** and **Frequency**.
- **Bypass**: Displays information about the bypass, including the **Voltages** and **Frequency**.
- **Battery**: Displays the Battery table, which contains information such as the **Voltage**, **Current**, **Capacity** and **Temperature** of the batteries.
  Via a page button, you can also access the **Battery Scheduled Test** subpage, where you can configure the discharge tests. You can adjust the **Time Limit**, **Time Interval**, **Discharge Rate** and **Maximum Discharge Rate** of the tests.
- **Parallel System**: Contains information about the parallel systems, such as the **Active Power**, **Apparent Power** and **Load Factor**.
- **Alarms**: Contains the Active Alarms table.
- **Control**: Displays the Control table, where you can configure the **Power On Settings**, **Power Off Settings**, **Battery Manual Boost Charge**, **Battery** **Manual Float Charge**, **Battery Shallow Test**, etc.
