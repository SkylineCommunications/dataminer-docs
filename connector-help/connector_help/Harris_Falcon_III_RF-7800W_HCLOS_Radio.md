---
uid: Connector_help_Harris_Falcon_III_RF-7800W_HCLOS_Radio
---

# Harris Falcon III RF-7800W

The **Harris RF-7800W High-Capacity Line-of-Sight (HCLOS) Radio** provides secure, dependable wireless broadband connectivity for both military and commercial applications.

## About

This connector is used to monitor the major parameters (inputs and outputs) of the device. The connector also contains an **overview of the active alarms**.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | V 5.00                      |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *Public*.
- **Set community string**: The community string used when setting values on the device, by default *Private*.

#### HTTP AntennaAlignment Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: *bypassproxy*

## Usage

### General

This page contains the **Web Interface** of the vendor, as well as the following general information:

- The **System** section contains general info on the system, such as the **System Name**, **System Details**, **System Location**, etc.
- The **Host** section displays the **Ethernet MAC Address**, **IP Address**, **IP Subnet Mask** and **Default Gateway Address** of the host.

### System Status

This page contains page buttons that provide access to the following subpages:

- **Wireless System:** Includes the **Current Tx Power**, **Channel Frequency**, **DFS Action** and **Radio Temperature** in degrees Celsius and Fahrenheit.
- **GPS**: Displays the GPS status and satellite coordinates info, as well as the **Satellite Table**.
- **Redundancy**: Displays the Redundancy Role, Peer IP, Timeout, etc.
- **External Power Amplifier**: Displays info related to Gain and Status.
- **Wireless Ethernet Statistics**: Includes the number of buffered and discarded packets (both Rx and Tx).
- **Ethernet Port Statistics**: Displays statistical info on the buffered and discarded packets at the Ethernet interface.
- **EIM:** Displays information on Enhanced Interference Mitigation, including **EIM Channel Change Status**, **Interference Detected** and **Relative Noise Floor**.
- **SW Upgrade Status**: Displays the firmware download status, the **TFTP Server Address** and the **Download TFTP Address Type**.

### Links Summary

This page displays the **Subscriber Links Summary** table. Polling for the table can be enabled or disabled with the option **Links Summary Table Polling**.

### Antenna Alignment

This page displays information regarding the antenna alignment, received via HTTP, namely **RSSI 1**, **RSSI 2**, **SNR 1** and **SNR 2**.

### Configuration - System

This page contains several different sections of configurable system settings:

- **System Identification**: Includes the **System Name**, **System Location** and **System Contact**.
- **SW Upgrade Config**: Includes TFTP info.
- **Basic Host Configuration**: Includes the **IP Address**, **Subnet Mask** and **Default Gateway Address** settings**.**
- **Advanced Host Configuration**: Includes the **Ethernet Port Mode**, **SNTP Server IP Address**, **Time Zone (GMT) \[Hh:mm\]**, **HTTP Access**, **Telnet Access** and **Telnet Port**.
- **Miscellaneous System Configuration**: Allows you to enable or disable the **GPS Antenna Power Supply** and set the **GPS Coordinates Format**.
- **Redundancy Config**: Contains the settings for Role, Peer IP and Timeout.

### Configuration - Wireless

This page allows you to change settings related to the wireless interface:

- **Basic Wireless Configuration**: Includes the **System Mode Configuration**, **Channel Size**, **New RF Operating Frequency**, **Tx Power**, **Antenna Alignment Buzzer**, and **Radio Mode** (which can be set to *Off*, *RF Port 1*, *RF Port 2* or *RF Port 1&2*).
- **Advanced Wireless Configuration**: Includes the **Maximum Distance** in km and miles, **DFS Action Config**, **Antenna Gain**, **External PA Present**, **Registration Period**, **Scheduling Cycle** and **ATPC Mode**.
- **Wireless Enhanced Interference Mitigation (EIM)**: Includes both **SC** and **SS Interference Detection.**
- **External Power Amplifier Config**

### Configuration - File Management

This page displays the **Active and Alternative Versions** of the firmware and allows you to to **activate the alternate** version.

### Broadcast/Multicast Configuration

This page displays the **Broadcast/Multicast configuration**.

### Prioritization (1.0.0.5 and above)

This page displays the configuration for **Prioritization Rules and Queue Policies** on Link and Broadcast and Multicast.

### Provisioning Subscriber Links

On this page, you can configure links displayed in the **Subscriber Links Configuration Table**.

Polling for this table can be enabled or disabled with the **Subscriber Link Table Polling** parameter. In the context menu of the table, a **Poll Table** option is also available.

### Roaming Stranded (1.0.0.5 and Above)

On this page, you can configure the **Roaming Stranded SC Check IP Address**, **IP Address Type** and **Status**.

### Trap

This page displays the **Event** **Trap Table** as well as the **Total Events**. The table displays all received traps related to the device, including BS Power Supply Status, BS Temperature Threshold, Password Change Failure, Firmware Config Failure, EEPROM Corrupted, Hardware Failure, DFS Event Trap, Modification in the Configuration of an ID, SW Upgrade Failed, SW Upgrade Success, GPS Number Used Satellites Low, GPS Number Used Satellites 12 h Low, PPS Not Available, etc.

Via the **Config page button**, you can configure automatic clearing of events from the Event Trap Table via the **Maximum Number Traps** parameter. You can also configure whether specific traps will be received using the **Trap Activation Table** and **Up/Down Link Trap Table**. Finally, this subpage also allows you to enable or disable **SNMP Authentication Failure Traps**.

### Web Interface

This page allows the access to the SNMP device web interface. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
