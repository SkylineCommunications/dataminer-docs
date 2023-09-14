---
uid: Connector_help_Ateme_DR2100
---

# Ateme DR2100

The Ateme DR2100 is an integrated receiver for video distribution services.

## About

The **Ateme DR2100 SNMP** connector controls and monitors the video receiver.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.6.30                      |

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

#### SNMPv2 main connection

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMPv2 Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays information about the system, such as the **Description**, **Up Time**, **Name**, etc.

### Ateme DR2100 Device Pages

This section contains the following pages:

- **Input**: This page contains the **Input Table**, **TS Input Source Table** and **ASI Input Table**.
- **Output**: This page contains the **TS Output Table** and the **Output Source Table**.
- **Sensor**: This page displays the status of the **3V**, **5V** and **12V sensor** as well as the **temperature** sensor and the **fan**.
- **Relay**: This page displays the relay count and contains the **Relay Table**.
- **Hardware**: This page contains the **Model Table** and **Hardware Table**.
- **Digital Video Broadcasting (DVB)**: This page contains the **DVB-S2 In Table**, **DVB-S2 In Status Table** and a subpage with the **Advanced Features** **Table**.
- **Ancillary**: This page contains the **Ancillary Decoder**, **Line Conflict** and **Option Table**.
- **Video**: This page contains the **Video Table** and **Video Output Table** as well as subpages for the video **format** and video **overlay**.
- **Gen Lock**: This page contains the **Gen Lock**, **HD** Gen Lock and **SD** Gen Lock Tables.
- **Serial Digital Interface**: This page contains the **HD SDI**, **SD SDI** and **Audio SDI Tables**.
- **Service Information**: This page contains the **SI Program** and **SI Transport Stream** **Tables** as well as subpages for **SI Video**, **SI Audio** and **SI Subtitle**.
- **Service**: This page contains the **Selected Services** **Tables** as well as subpages for **Service Lock** **Tables** and **Service Audio** **Tables**.

### Ateme DR2100 Configuration Pages

This section contains the following pages:

- **TCP/IP**: This page contains all the settings regarding the **TCP/IP parameters**.
- **Update**: This page contains all the parameters necessary to **update** the current version.
- **Date Time**: This page contains information about the current date and time settings.
- **SNMP**: This page contains the read and write **community string** information for SNMPv2.
- **OEM**: This page contains the **OEM Table**.
- **Version**: This page contains the **Version Table**.
- **License**: This page contains the **License Table**.
- **Profile**: This page contains the **Profile Table**.

### Ateme DR2100 Alarm/Event Pages

This section contains the following pages:

- **Alarm**: This page contains the **Alarm Table** with the **name** of the alarm and its **current state**.
- **Event Log**: This page contains the **Event Log Table** with the events and their **transition** and **severity**.
- **System Log**: The System Log Table displays all the **IP addresses that receive system log data**.
- **System Events**: This page contains the **System Events**, System Events **Log Config**, **Trap Config** and **Relay Config** **Tables**.
- **System Conditions**: This page contains the **Conditions Table** which determines when alarms, relay, traps and logs are triggered. All of these can be manually enabled/disabled via the subpages.

### Web Interface Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
