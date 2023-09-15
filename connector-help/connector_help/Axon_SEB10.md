---
uid: Connector_help_Axon_SEB10
---

# Axon SEB10

The **Axon SEB10** is a digital audio embedder. The connector monitors and controls the device via **SNMP**.

## About

The connector polls the device every 30 seconds for fast-varying information and every 10 minutes for slow-varying information.

### Creation

The connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.
- **Device Address:** A logical index, between *0* and *17*.

**SNMP Settings:**

- **Port number**: The port number used to poll the device, by default *161.*
- **Get community** **string**: The community string used to read from the device. The default value is *public*.
- **Set community string**: The community string used to write on the device. The default value is *private*.

## Usage

This connector has four pages: **Main View, General Info, Settings** and **Events**.

### Main View Page

The left column of this page displays the following information:

- The **EDH status**
- The **FPGA status**
- The **SDI Input status**
- The **Audio Channels A1-A4** and **B1-B4 statuses**

In the column on the right, the following information can be found:

- The **card name**
- The **user label**
- The **card's description**
- The **software/hardware revision**
- The **product code**
- The **serial number**
- The **card's ID**

### General Info Page

Some parameters on this page are the same as on the Main View page. In addition, you can also configure the **user label,** view the groups that already in use (**Group in Use**) by the incoming SDI channel, and view whether the embedded audio has errors (**Group Insert**).

### Settings Page

On this page, you can configure several aspects of the SEB10.

In the left column, the following settings are available:

- The **embedded audio mode**
- The **channel groups** used by **Embedder A/B**
- The **input audio channels** used by **Embedder A for Emb.A1/2** and **Emb.A3/4**
- The **input audio channels** used by **Embedder B for Emb.B1/2** and **Emb.B3/4**
- The **gain** for **channels A1** and **A2**

in the right column, the following settings are available:

- The **gain** for **channels A3 and A4**
- The **channel phases** for **A1-A4**
- The **source status**
- **EDH Generator/Detection**

### Events Page

On this page, you can **set the alarm priority** for the following:

- **Announcements**
- **Input**
- **EDH Status**
- **Group Insert**

## Notes

Version 1.1.1.1 is based on version 1.1.0.7, with additional DCF functionality.
