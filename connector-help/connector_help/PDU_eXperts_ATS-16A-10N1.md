---
uid: Connector_help_PDU_eXperts_ATS-16A-10N1
---

# PDU eXperts ATS-16A-10N1

The **PDU eXperts ATS-16A-10N1** connector monitors and controls the Power Switch unit of the same name through **SNMP**.

## About

The connector polls relevant information from the device every 10 seconds or every hour.

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string used when reading values from the device. The default value is *public.*
- **Set community string**: The community string used when setting values on the device. The default value is *private.*

## Usage

This connector has several data display pages:

### General Page

This page displays general information about the system:

- **Device ID** and **Firmware Version**
- **System Up Time** and **Services**
- **System Contact**, **Name** and **Location**
- **Temperature** and **Humidity** of the device and their respective **Thresholds**

### Status Page

This page displays the **Model** **Name**, **Model** **Number**, **Input A and B Status** **and** **Name** and **ATS Primary Input,** as well as the **Voltage, Total** **Current** with **Overload and Warning Thresholds**, **Electricity Carbon Emission Rate, Active Power, Power Factor, Apparent Power, Main Energy** and **Accumulated Energy.**

There is one button on the page, **Reset Accu Energy**, which clears the value from the **Accumulated Energy** parameter.
