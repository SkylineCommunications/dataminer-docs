---
uid: Connector_help_UPCOM_Technologies_UC-IRD+
---

# UPCOM Technologies UC-IRD+

This connector uses SNMP to communicate with the UC-IRD+ Integrated Receiver Decoder (IRD). The connector provides all of the SNMP information that is available through the device's web interface.

## About

The connector uses the **SNMP** protocol to poll the IRD for information and to configure the IRD. The layout of the connector mirrors that of the IRD's web interface. Each page of the web interface has a corresponding page in DataMiner's data display. However, there is one additional page in the connector, the **Trap** page, which contains a table with all the received traps.

By default, any trap received from OID \*.19 (signal off) creates an alarm. This alarm is cleared again when a trap is received from OID \*.20 (signal on) on the same channel (ASI-1, ASI-2, CI, IP or Tuner).
Note: The IRD must be configured to send traps to the DataMiner Agent.

There is also a web interface page. However, to use this page, the client must have access to the IP address of the IRD.

### Version Info

| **Range** | **Description**                                                                                                                                                  | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                                                                                                  | No                  | Yes                     |
| 1.0.1.x          | Renamed "BISS Program Table" to "Program Table". Possible impact on external items using this table (alarm templates, trending, Visio files, Automation scripts) | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 51PR00A2                    |
| 1.0.1.x          | 51PR00A2                    |

## Installation and configuration

### Creation

#### Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The default value is *public*.
- **Set community string**: The default value is *private*.

## Usage

### Status

This page displays basic information about the **DVB-S2 Tuner Input**, the **ASI Input** and the **Video Output**.

### Tuner

This page contains the configuration settings for the **DVB-S2 Tuner**.

### Common Interface

This page contains the source selector for the **CI input**. It also displays the card information for **slot 1** and **slot 2**. If no cards are inserted, then *"No Module"* will appear for the slot status.

### BISS

This page contains the configuration settings for **BISS** (Basic Interoperable Scrambling System).

Note that the mode first has to be selected before the **Mode** options below have any impact. The **Mode 1 Key** must be 12 characters. The **Mode E ID** must be 14 characters*.* The **Mode E Key** must be 16 characters. **Mode 0** means BISS is turned off.

### TS over IP

This page contains the configuration settings for the **Transport Stream over IP**. At the bottom of the page, two page buttons are displayed, **DVB Config** and **IPTV Config**. These open subpages containing the configuration that is effective if the **Mode** setting has been set to *DVB* or *IPTV* respectively.

### Output

This page contains the configuration options for the **ASI Outputs**. You can select the source for the **ASI-1** and **ASI-2** outputs.

### Decoder

This page contains the configuration options for the output of the UC-IRD+. It includes **Program options**, **Video options**, **Audio options** and **SDI options**.

### System

This page contains the configuration options for the overall system as well as basic system information. It includes **optional functions**, **versions** and **network management**. The **Device Reboot** button can be used to reboot the UC-IRD+. The **Factory Default** button will return the UC-IRD+ to its factory default settings.

### Traps

This page contains a table of all the traps received from the UC-IRD+. By default, only the last 100 traps are saved, and older traps are cleared.

Click the **Auto Clear** button to change the **Auto Clear settings**. You can set traps to be cleared automatically after X days by changing the **Auto Clear Method** to *Max Duration* on the **Auto Clear** subpage. Choosing *Both* enables both the **Traps Max Duration** and the **Traps Max Number** values.

### Web Interface

This page contains an embedded web browser directed to the IP address of the UC-IRD+. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
