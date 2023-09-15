---
uid: Connector_help_NetInsight_Nimbra
---

# NetInsight Nimbra

The **NetInsight Nimbra** connector allows the monitoring of Nimbra nodes.

With this connector, you can monitor and control the different interfaces of a node, and the current and previous configurations of the device. You can also monitor the TTPs, the channels going through the nodes, and the services starting from them.

Typically, this connector is used together with the **NetInsight Nimbra Application Manager** for the monitoring and controlling of the services between different Nimbra nodes.

## About

### Version Info

| **Range**            | **Corresponding** **NetInsight Nimbra Application Manager** **Range** | **Description**                                                                                                                                                                                               | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\] | \-                                                                    | Initial version.                                                                                                                                                                                              | No                  | Yes                     |
| 1.0.1.x \[Obsolete\] | \-                                                                    | New MIBs.                                                                                                                                                                                                     | No                  | Yes                     |
| 2.0.0.x \[Obsolete\] | \-                                                                    | Branch version based on 1.0.1.x.                                                                                                                                                                              | No                  | Yes                     |
| 3.0.0.x \[Obsolete\] | 1.0.0.x \[Obsolete\]                                                  | Branch version based on 2.0.0.x.                                                                                                                                                                              | No                  | Yes                     |
| 3.0.1.x \[Obsolete\] | 1.0.1.x \[Obsolete\]                                                  | Based on 3.0.0.x. All bit rates in Mbps for consistency.                                                                                                                                                      | No                  | Yes                     |
| 4.0.0.x \[Obsolete\] | 2.0.0.x \[Obsolete\]                                                  | Based on 3.0.1.x. Uses DCF.                                                                                                                                                                                   | Yes                 | Yes                     |
| 4.1.0.x \[Obsolete\] | 2.0.1.x \[Obsolete\]                                                  | Based on 4.0.0.x. Improved number of rows retrieved with each SNMP call. Version change required because some devices are unable to handle the bigger load.                                                   | Yes                 | Yes                     |
| 4.1.1.x              | 2.0.2.x \[SLC Main\]                                                  | Based on 4.1.0.x. Improved interface for third-party applications (e.g. SRM) **with breaking changes**. Validation on requests is no longer polling-based but is pushed to the manager from the node element. | Yes                 | Yes                     |
| 4.1.2.x \[SLC Main\] | 2.0.2.x \[SLC Main\]                                                  | Based on 4.1.1.x. Removed HTTP connection (obsolete). Removed page with HTTP parameters.                                                                                                                      | Yes                 | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Gx 4.6-Gx 4.7          |
| 1.0.1.x   | Gx 4.6-Gx 4.7          |
| 2.0.0.x   | Gx 4.6-Gx 4.7          |
| 3.0.0.x   | Gx 4.6-Gx 4.7          |
| 3.0.1.x   | Gx 4.6-Gx 4.7          |
| 4.0.0.x   | Gx 4.6-Gx 4.7          |
| 4.1.0.x   | Gx 4.6-Gx 5.6          |
| 4.1.1.x   | Gx 4.6-Gx 5.6          |
| 4.1.2.x   | Gx 4.6-Gx 6.2.0.3      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device (e.g. *192.168.1.6*).
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device (e.g. *161*).
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use:

The element created with this connector consists of the following data pages:

- **General Status**: Displays general information such as the System Name, Node Route Metric or Current Timing Source.
- **General Alarms**: Contains the Chassis Alarms table.
- **General Configuration and Backup**: Provides information such as the Number of Configurations, Backup Operation or Backup Description.
- **ITS Interfaces**: Displays the ITS Interface Last Changed parameter and contains the ITS Interfaces Table.
- **ITS-in Services Configuration**: Displays the ITS in Last Changed parameter and contains the ITS-in Services Configuration Table.
- **ITS-out Services Configuration**: Displays the ITS out Last Changed parameter and contains the ITS-out TTP Table.
- **ITS JPEG 2000**: Displays the ITS JPEG 2000 table and contains a parameter that can be used to activate or deactivate polling.
- **ITS Alarm Status**: Displays the ITS In Alarm Status and ITS Out Alarm Status tables.
- **AIF Performance Monitoring**: Contains the AIF - Access Interfaces Monitoring table and allows you to activate or deactivate AIF Polling.
- **DCH Performance Monitoring**: Contains the DCH ƒ?" DTM Channels Monitoring table and allows you to activate or deactivate DCH Polling.
- **DTM Interfaces and Links**: Displays the DTM Link Last Changed parameter and contains the DTM Interfaces and DTM Links tables.
- **DTM Tx/Rx Statistics**: These pages display the DTM Interfaces - Tx and DTM Interfaces - Rx tables, respectively.
- **DTM DPP-IP Interfaces**: Displays the DTM DPP-IP Last Changed parameter and contains the DPP-IP Interfaces table.
- **DTM Alarms**: Displays the DTM Interfaces Alarm Status table.
- **DTM TIF Performance Monitoring**: Displays the TIF ƒ?" Trunk Interfaces Monitoring table and allows you to activate or deactivate DTM TIF Polling.
- **Eth Device and Interface**: Displays the Eth Devices Table and the Eth Interfaces and Alarms Table.
- **Eth-Ets Table**: Displays the Eth-Ets Group Last Change parameter and the Eth-Ets Table.
- **Eth-Ets RSTP and Queue Configuration**: Displays the Eth-Ets Group Last Change parameter, the Eth-Ets RSTP Table and the Eth-Ets If Queue Table.
- **Ets Services and Connection Configuration**: Displays the Eth-Ets Group Last Change parameter, the Ets Services and Alarms Table and the Ets T Connection Table.
- **VLAN Table**: Displays the Eth-Ets Group Last Change parameter and the Eth If VlanSets Table.
- **Forward Function**: Displays the Forwarding Group Last Change parameter, the Forward Function Table and the Forward RTSP Table.
- **Originating TTP Configuration**: Displays the Originating Configuration Last Change parameter and the Originating TTP Configuration Table.
- **Originating TTP Destination Configuration**: Displays the Originating TTP Destination Configuration Table.
- **Originating TTP Connection**: Displays the Originating Connection Last Change parameter and the Originating TTP Connection Table.
- **Originating TTP Channels Connection**: Displays the Originating Connection Last Change parameter and the Originating TTP Channels Connection Table.
- **Originating TTP Statistics**: Displays the Originating TTP Statistics Table.
- **Terminating TTP Connection**: Displays the Terminating Connection Last Change parameter and the Terminating TTP Connection Table.
- **Terminating TTP Channels Connection**: Displays the Terminating Connection Last Change parameter and the Terminating TTP Channels Connection Table.
- **Terminating TTP Statistics Table**: Displays the Terminating TTP Statistics Table.
- **Source Route Configuration**: Displays the Source Route Last Change parameter, the Source Route Table and the Source Route Hop Table.
- **Node Channels Table**: Displays the Node Channels Table.
- **Alarm**: Contains the Alarm Table and allows you to enable or disable alarm polling.
- **Embedded Web Server**: Provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
