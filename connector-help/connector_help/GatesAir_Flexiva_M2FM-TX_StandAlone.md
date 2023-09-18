---
uid: Connector_help_GatesAir_Flexiva_M2FM-TX_StandAlone
---

# GatesAir Flexiva M2FM-TX StandAlone

The **GatesAir Flexiva M2FM-TX StandAlone** is a standalone FM transmission system.

## About

This connector is used to monitor the GatesAir Flexiva M2FM-TX StandAlone. The connector has a page with general information, a system page with two pop-up pages for the configuration of the traps, a drive chain page, a power page and an output page. The connector uses **SNMP** to retrieve and configure the data.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 0299                        |

## Installation and configuration

### Creation

#### Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*

## Usage

### General Page

This page displays basic SNMP information, such as **System Description**, **System Object ID**, **System Uptime**, **System Contact**, **System Name** and **System Location**.

### System Page

This page displays basic **System Information** about the transmitter, i.e. the **Device Name**, **Model Number** and measured **Transmitter Temperature**.

In the **Transmitter Controls** section, you can increase or decrease the transmitter power by first setting **Transmitter Control** to *Total Power Raise* or *Total Power Lower* respectively, and entering a value in mW for **Transmitter Control Value**. Also in this section, the **Transmitter Frequency** can be set.

The **Base Alarms** section and **IRT Alarms and Control** section display a variety of alarms. Each section also contains a **Trap Control** button that allows the individual configuration of traps or alarms.

The **Fast Polling Control** button displays the **Fast Polling Status** parameter. If this is set to *Polling Active,* polling occurs every 10 seconds. If it is set to *Polling Inactive,* polling occurs every 60 seconds.

The **Version Information** button shows the **Mib Revision** and **Software Revision** of the transmitter.

### Drive Chain Page

This page displays alarms related to the drive chain. In addition, some controls are available, such as the **Exciter Switch**, the **Exciter Switch Mode**, the **IPA Switch** and the **IPA Switch Mode**.

### Power Page

This page displays alarms and measurements for both the **Power Amplifier** and the **Power Supply**.

### Output Page

This page displays alarms and measurements for the transmitter output. It also includes more detailed power measurements of the output including the **Forward Power**, **Reflected Power**, **Reflection Factor** and **VSWR** (Voltage Standing Wave Ratio).

### Web Interface Page

On this page, you can view the web interface of the device. However, the client machine has to be able to access the device. Otherwise, it will not be possible to open the web interface.
