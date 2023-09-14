---
uid: Connector_help_Asentria_SiteBoss_220
---

# Asentria SiteBoss 220

The **Asentria SiteBoss 220** connector is an SNMP connector that is used to monitor **Assentria SiteBoss 220** appliance that is a device for monitoring in remote equipment locations.

The device supports remote environmental monitoring such as temperature, humidity, water, smoke, entry, motion, and airflow within remote locations through the use of a variety of external sensors. It delivers alarms either by SNMP Traps or by polling of **Assentria SiteBoss 220's** MIB.

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

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The port of the connection device, by default *161.*

SNMP Settings:

- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *private*.

### Initialization

No extra configurations are needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General Page

On this page, you can find general system configurable informations like **Serial Number, Version, Build, Site Name, Product Name.**

On this page you can also find Date configurable informations like **Device Date, Device Time** and the option if you want to enable the **Adjust for Daylight Savings.**

### Events Page

On this page you can find **Event Sensor Points** table that organizes 4 basic attributes of points. A point is a particular sensor on an EventSensor (e.g., temperature, humidity, contact closure 2, relay 5, etc.). The 4 point attributes are its name, whether it's in its event state, the point's value as a number and its value as a string.

On this page you can also find all the sensors configuration pages regarding **Temperature**, **Humidity**, **Analog Input** and **Relay.**

#### Temperature Configuration Sub-Page

On this sub-page you can find the **Event Sensor Temperature Configuration,** this table organizes 3 basic attributes of temperature sensor points. The 3 point attributes organizes in this table are:
1. The configuration item (e.g., enable, name, etc.).
2. The Event Sensor on which this point resides.
3. The Point Number (always 1 for temperature sensors).

#### Humidity Configuration Sub-Page

On this sub-page you can find the **Event Sensor Humidity Configuration,** this table organizes 3 basic attributes of humidity points. The 3 point attributes organizes in this table are:
1. The configuration item (e.g., enable, name, etc.).
2. The Event Sensor on which this point resides.
3. The Point Number (always 1 for humidity sensors).

#### Analog Input Configuration Sub-Page

On this sub-page you can find the **Event Sensor Analog Input Configuration Table,** this table organizes 3 basic of analog input points. The 3 point attributes organizes in this table are:
1. The configuration item (e.g., enable, name, etc.).
2. The Event Sensor on which this point resides.
3. The Point Number.

#### Relay Configuration Sub-Page

On this sub-page you can find the **Event Sensor Relay Configuration Table,** this table organizes 3 basic of Relay points. The 3 point attributes organizes in this table are:
1. The configuration item (e.g., enable, name, etc.).
2. The Event Sensor on which this point resides.
3. The Point Number.

### Networking Page

On this page you can find all the information regarding network information like **IP Address, Subnet Mask,** **Router Address, SNMP Read Community** string**, SNMP Write Community** string and **SNMP Trap Community** string**.**

### Alerts Page

On this page you have configurable Alert Settings.

This page is divided in General Alert Settings that contains the **System Alert Actions** that defines the actions that occur when the system needs to alert the user, if the **PowerUp Alert** is enabled or not, if the **Return to Normal Alerts** are or not enabled and the **Individual Alert Repeat Frequency** in minutes**.**

This page also contains **Email Alerts** configuration where you can configure the **Email Server**, the **Email Domain**, if **SMTP Authentication** is enabled, the **Email Authentication Username,** the **Email Authentication Password.** You can also check wich Email adrresses are configured checking the **Email Addresses table.**

Also in this page we have **SNMP Alerts** configuration where you can check wich **SNMP Servers** are configured**.**

### Traps Page

On this you can find **Traps table** with the received traps from the device (e.g. PowerUp Trap, Contact Trap, Temperature Trap, Humidity Trap and Test Trap).

### Web Interface Page

On this page, you can access the web interface. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
