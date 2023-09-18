---
uid: Connector_help_NEC_iPasolink_200
---

# NEC iPasolink 200

With this connector, you can gather and view information from the device **NEC iPasolink 200**, as well as configure the device.

## About

This connector uses an SNMP connection to monitor the **NEC iPasolink 200** device.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.64.8.30*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information about the device, such as the **System Description**, **Up Time**, **Software Version**, **System Temperature**, etc.

### General Settings Page

On this page, you can configure general parameters of the device, such as the **Contact** and **Location.**

### User Management Page

On this page, you can configure the users and groups of the device.

The users "*User*", "*Config*" and "*Admin*", and the groups "*OPERATOR*", "*CONFIG*" and "*ADMIN*" cannot be deleted or edited.

### Service Status Page

On this page you can configure the services provided by the device:

- **NTP**
- **FTP**
- **SFTP**
- **HTTP**
- **HTTPs**

### DHCP Setting Page

On this page, you can configure the DHCP settings of the device.

### SNMP Setting Page

On this page, you can configure the SNMP settings of the device.

### IP Access Control Setting Page

On this page, you can configure the access control settings of the device.

To add a rule, either input or forwarding, right-click the relevant table and select **Add Entry.** A pop-up window will appear where you can fill in the desired setting and then press Ok to add the rule.

### AUX Setting Page

On this page, you can configure the AUX settings of the device.

### Port Settings Page

On this page, you can configure the Port settings of the device.

### STP Settings Page

On this page, you can configure the STP settings of the device.

### Bridge Settings Page

On this page, you can configure the Bridge settings of the device.

### PRIP Settings Page

On this page, you can configure the PRIP settings of the device.

### Summary Status Page

This page displays the main alarms of the device. You can for instance find the **Total Alarm Summary** and **Main Board Alarm** here.

### Modem Status Page

This page displays the status of the Modems present on the device.

### Port Status Page

This page displays the status of the Ports present on the device.

### Metering Page

This page displays the metering parameters of the device, such as the **Fan Speed** and **Tx Power Value.**

### Web Interface Page

This page displays the device's web interface. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
