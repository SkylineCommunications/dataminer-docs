---
uid: Connector_help_Arris_AGB240
---

# Arris AGB240

The **Arris AGB240** is an ASI to Gigabit Ethernet bridge.

## About

This connector allows you to access various information on the device and configure device settings.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported Firmware Versions

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.2.6                       |

## Installation and configuration

### Creation

#### HTTP Request/Response connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: 8080 (necessary for AGB240 release 1.2.2 or greater).
- **Bus Address**: *bypassproxy*.

## Usage

### General

This page displays device statistics that are displayed upon successful login. It also displays the **Serial Number**, **Board MCN**, **Software Version** and other device information.

Eight buttons are available:

- **Login** page button: Opens a subpage with the **Username** and **Password** fields, as well as a **Session ID** that changes upon successful login.
- **Change Password** page button: Opens a subpage with the **Old Password** and **New Password** fields, as well as the **Change Password** button.
- **Import Config File** page button: Opens a subpage where you can select a configuration file and apply it to the device.
- **Export Config File** page button: Opens a subpage where you can export the current configuration of the device to a config.ini file in a specified folder.
- **Users** page button: Opens a subpage where you can view and configure users in the **Users** table and view or delete current user sessions in the **User Sessions** table.
- **Add User** page button: Opens a subpage where you can create a new user.
- **Reboot**: Sends a command to reboot the device.
- **Set Default Config** button: Sets the configuration of ALL parameters (including tables) back to the default values.

### Status

This page displays information regarding the status of the device. In the **Total Data Rates** section, the **Total ASI**, **Content Data,** and **Output** rates are displayed.

The page also contains the following tables:

- **Error Packet Counts and Port Overflow:** Displays various error counters as well as the port overflow status.
- **Network Link Status:** Displays status information for the ENET1, ENET2 and GIGE network links.
- **Event Logs**: Displays recent events.

At the bottom of the page, the **Clear Counters** button is available, which clears the counter values in the **Error Packet Counts and Port Overflow** table.

Below this, the **Save** page button opens a subpage where you can write existing status info to text files.

### System

This page contains various settings to configure the device:

- The **Ethernet Port Config Info** table allows you to configure Ethernet ports.
- There are several standalone parameters for **SNMP/DHCP** settings.
- There are several standalone parameters for **SNTP/Time** settings.
- In the **Radius Server Configuration** section, you can configure login methods, server settings, and server IPs/ports. You can also indicate whether the shared key should be hidden or shown.

### ASI

This page displays ASI port information such as the **ASI Processing Mode,** **ASI Monitor Port Setup** and **Total ASI Rate**. In the **ASI Port Config Table**, it displays information on the status of each ASI port.

### Web Interface

This page opens the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
