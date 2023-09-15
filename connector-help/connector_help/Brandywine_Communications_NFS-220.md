---
uid: Connector_help_Brandywine_Communications_NFS-220
---

# Brandywine Communications NFS-220

The **Brandywine Communications NFS-220** connector monitors and controls the unit through **SNMP**.

## About

The connector polls relevant information from the device every 10 seconds, every 10 minutes or every hour.

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community** **string**: The community string used when reading values from the device. The default value is *public.*
- **Set community string**: The community string used when setting values on the device. The default value is **private.**

## Usage

This connector has several data display pages:

### General Page

This page displays the **Product Name, Serial Number, Version, Date, IP Address, Gateway Sub Net and DHCP**.

The page also has two buttons to **Save Device Config** to non volatile memory (will be remembered upon restart) and to do a **Soft Reset** of the device.

### Status Page

This page displays the alarms and faults of the device, as well as the number of **tracked satellites**, its **position** and **velocity.**

### Time Page

This page displays information regarding the configured **Timezone** on the left and the **Serial Baud Rate** on the right.

### Reference Page

This page displays configurable information regarding the output levels of the **10Mhz**, the **Delay** of the **1PPS**, the **PPS Width** among others.

### Web Interface Page

This page displays the **web interface** of the device. The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
