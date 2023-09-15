---
uid: Connector_help_Sencore_SMD989
---

# Sencore SMD989

The **SMD-989** is a versatile DVB-S/S2/S2X/TurboPSK modulator platform capable of one or two channels of modulation per rack unit. The **SMD-989** comes standard with IP and ASI inputs to offer flexibility for future changes in network architecture or sourcing content from two different interfaces. The SMD also supports advanced DVB-S2 features such as 16APSK and 32APSK modulation as well as the carriage of multiple streams on a single RF carrier. It also supports the advanced modulator coding scheme turbo PSK and S2X.

## About

This **SNMP** connector is used to monitor and configure the **Sencore SMD-989** modulator.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3.2.1                       |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### System

This page contains system info parameters, including:

- **Unit 10 MHz Reference Clock**: Indicates whether the system is using an **external** or **internal** 10 Mhz reference clock.
- **Unit 10 MHz External Reference Clock Error**: Signals whether an error was encountered with the reference clock (possible values: *OK* or *Fail*).
- **Unit Mute on Settings Change**: If this is *Enabled*, the connector automatically mutes the output(s) on a modulation or output setting change. Output(s) are muted only on the bay where the change occurred. If this is *Disabled*, each output mute setting retains its configured value on a modulation or output setting change.

The page also contains page buttons to the **Network Settings**, **Clone Settings** and **License Settings** subpages.

#### Network Settings subpage

This subpage contains the following tables:

- **MPEG IP Table**: Displays the connector to use as **Default Gateway** (*Connector 1* or *Connector 2*), and allows you to enable or disable the **ICMP Response**.

- **MPEG IP NIC Table**: Includes the following parameters:

- **IP Address**: The IP address of the mpeg NIC.
  - **Subnet Mask**: The subnet mask of the mpeg NIC.
  - **Gateway**: The gateway of the mpeg NIC.
  - **MAC**: The MAC address of the mpeg NIC.
  - **Link Speed**: The link speed in **Mbps** of the mpeg NIC.
  - **Link Status**: The link status of the mpeg NIC (*Down*, *Half Duplex* or *Full Duplex*).
  - **Rx Rate**: The aggregated received bitrate in **Mbps**.
  - **IGMP**: Detected IGMP protocol version used in the network (*Version 1*, *Version 2* or *Version 3*).

#### Clone Settings subpage

This subpage contains the following parameters:

- **Cloning**: Allows you to enable or disable the clone settings.
- **Remote Unit Address**: The IP address of the unit to clone the settings from.
- **Public SNMP Community**: The SNMP community string used to access the remote unit.

#### License Settings subpage

This page contains the **Bay License Table**, which includes the following parameters:

- **Name**: The license option name.
- **Bay Assignment**: The licensing bay assignment (*Bay 1*, *Bay 2* or *Bay 1 / Bay 2*).

### Input

This page contains the following information parameters:

- **Primary Input**: The primary input source for the stream. Refer to the **Label** values from the **Input Table** (see below).
- **Backup Input**: The backup input source for the stream. Refer to the **Label** values from the **Input** **Table** (see below). However, note that input failover is not supported when the DVB-S2 multi-stream modes are used.
- **Failover Condition**: The condition that triggers failover of the stream input from the primary input source to the backup input source. However, note that input failover is not supported when the DVB-S2 multi-stream modes are used.
- **PRBS Status**: Allows you to enable or disable PRBS (pseudo-random binary sequence) as the modulator input.
- **Restore Condition**: Condition that triggers the stream input to switch back from the backup input source to the primary input source. However, note that input failover is not supported when the DVB-S2 multi-stream modes are used.

The possible values of the Failover Condition parameter depend on the value of the Restore Condition parameter, and vice versa.

- If the value of the **Restore Condition** parameter is not *Manual Only*, the **Failover Condition** parameter can be set to anything except *Manual Only*.
- If the value of the **Failover Condition** parameter is *Manual Only*, the only valid value of the **Restore Condition** parameter is *Manual Only*.
- If the value of the **Restore Condition** parameter is *On Primary TS Restored* or *On Backup TS Loss*, the only valid value for the **Failover Condition** parameter is *On Primary TS Loss*.
- Similarly, if the value of the **Restore Condition** parameter is *On Primary TS Analysis Restored* or *On Backup TS Analysis Failure*, the only valid value for the **Failover Condition** parameter is *On Primary TS Analysis Failure*.
- If the value of the **Failover Condition** parameter is *On Primary TS Loss*, then the valid values of the Restore Condition parameter are *On Primary TS Restored* and *On Backup TS Loss*.
- Similarly, if the value of the **Failover Condition** parameter is *On Primary TS Analysis* *Failure*, then the valid values of the **Restore Condition** parameter are *On Primary TS Analysis Restored* or *On Backup TS Analysis Failure*.

The page also displays the **Input Table**, which includes the following parameters:

- **Label**: Label of the input.
- **Bitrate**: The calculated bit rate of the stream in **Mbps**.
- **Status**: Allows you to determine whether or not the input is **enabled**.

Finally, the page also contains a page button to the **IP** **Settings** subpage.

#### IP Settings subpage

This page contains two tables.

The **MPEG IP Rx** table includes the following parameters:

- **IP Address**: The multicast destination group address.
- **Destination Port**: The multicast destination group port.
- **IGMP Mode**: The source filter list mode (Possible values: *Include* or *Exclude*).
- **Protocol**: The packet protocol (Possible values: *UDP* or *RTP*).
- **TS Packets per IP**: The number of transport stream packets per IP packet.
- **Buffer Size**: The receive buffer size in **KB** for the mpeg IP stream.
- **Buffer Delay**: The buffer latency in **ms**.
- **Routing Mode**: Allows you to configure the stream to use **unicast** or **multicast** routing.
- **SSRC Filter Mode**: Configures the enabled state of SSRC source filtering.
- **SSRC Filter Value**: Configures an SSRC value to use as a source filter.
- **Out Of Order Packets**: The number of out-of-order packets received in the stream.
- **Duplicate Packets**: The number of duplicate RTP packets received.
- **Lost Packets**: The number of missing packets according to the RTP sequence counter.
- **Corrected Packets**: The number of correctable FEC errors detected in the stream.
- **Uncorrected Packets**: The number of uncorrectable FEC errors detected in the stream.
- **FEC State**: Configures the **enabled** state of processing FEC data for the stream.
- **FEC Rows**: The number of rows detected in the FEC data for the IP stream.
- **FEC Columns**: The number of columns detected in the FEC data for the IP stream.
- **FEC Corrected per Period**: The number of correctable FEC errors per FEC period detected in the stream.
- **Connector**: The port used (*Port 1* or *Port 2*).
- **Buffer Mode**: Allows you to choose the size in **kB** or delay in **ms**.
- **Buffer Delay Target**: The receive buffer size in ms for the mpeg IP stream.
- **FEC Mode**: The current FEC mode (Possible values: *Disabled*, *Columns Rows*, *Columns* or *Not Present*).

The **MPEG IP IGMP** table includes the following parameters:

- **Address Type**: *IPv4*, *IPv6*, *IPv4-Z*, *IPv6-Z* or *DNS*.
- **IP Address**: The IGMP source filter address.
- **Row Status**: The row status for the IGMP source filter address (*Active*, *Not in Service*, *Not Ready*, *Create And Go*, *Create And Wait* or *Destroy*).

### Modulator

This page contains the following information parameters:

- **Symbol Rate**: Allows you to configure the modulation symbol rate in **Msymps**. Used only if the mod rate mode is set to symbol rate.
- **DVB-S2 Frame Size**: Allows you to select **normal** or **short** frames. Some combinations of stream mod type code rate and DVB-S2 frame size are invalid.
- **Modulation Mode**: Allows you to select the modulation mode (*DVB-S2 Single-CCM*, *DVB-S2 Multi-CCM*, *DVB-S2 Multi-VCM*, *DVB-S/DSNG*, *TurboPSK* or *DVB-S2X Single-CCM*).
- **Spectral Inversion**: Allows you to enable spectral inversion (Possible values: *Normal* or *Inverted*).
- **Filter Roll Off**: Allows you to select the roll-off value. The roll-off values in **%** **15**, **10**, and **5** are valid only in DVB-S2 Single-CCM or TurboPSK modulation mode.
- **DVB-S Type Code Rate**: The selected modulation scheme and code rate for DVB-S.
- **Rate Adaptation**: Allows you to enable or disable the S2 single stream rate adaptation.
- **DVB-S2 PL Scramble Code**: Allows you to set the physical layer scrambling code. A value of "0" resets it to the default broadcast value.

It also contains page buttons to the **Carried ID**, **PRBS** and **TS Analysis** subpages.

#### Carried ID subpage

This subpage contains the following parameters:

- **Global Unique ID**: The Global Unique Identification of the bay. Version 1 specifies this as the unit's MAC address, prepended with a CRC8.
- **Transmission Mode**: Allows you to enable or disable the transmission of the carrier ID.
- **Latitude Transmission**: Allows you to enable or disable the transmission of the latitude in the carrier ID.
- **Latitude**: The latitude of the unit, in .**0001 Decimal Degrees**, +XXX north / -XXX south.
- **Longitude Transmission**: Allows you to enable or disable the transmission of the longitude in the carrier ID.
- **Longitude**: The longitude of the unit, in .**0001 Decimal Degrees**, -XX west / +XX east.
- **Telephone Transmission**: Allows you to enable or disable the transmission of the telephone number in the carrier ID.
- **Telephone**: The contact telephone number to be transmitted. Use "x" as a delimiter between the number and the extension.
- **User Transmission**: Allows you to enable or disable the transmission of the user data in the carrier ID.
- **User**: User data to be transmitted. A message of up to 24 ASCII characters can be entered here.

#### PRBS subpage

On this subpage, you can set the **PRBS Mode**, i.e. the mode to use when PRBS (pseudo-random binary sequence) is enabled (Possible values: *PN 23 Normal* or *PN 23 Inverted*).

#### TS Analysis subpage

This subpage displays the **TS Analysis Table**, which contains the following parameters:

- **State**: Allows you to enable or disable the TS Analysis block. Only available in DVB-S/DSNG (Single) or DVB-S2 CCM (Single) modulation mode.
- **Sync Byte Threshold**: The sync byte threshold in errors/s with a range of 1 to 999.
- **PAT Error Threshold**: The PAT error threshold in ms with a range of 100 to 10000.
- **CC Error Threshold**: The CC error threshold in errors/s with a range of 1 to 999.
- **PMT Error Threshold**: The PMT error threshold in ms with a range of 100 to 10000.
- **ES PID Error Threshold**: The ES PID error threshold in ms with a range of 100 to 10000.
- **Null Packet Ratio Threshold**: The greatest percentage of null packets to total packets that will not trigger an error.

### Output

This page contains the following parameters:

- **Frequency**: Allows you to change the IF output frequency (**MHz**) with a range of 50 to 180.
- **Level**: Allows you to configure the IF output level. The range for the standard modulator is -30 to -5 **dBm**; the range for the high-power modulator is -20 to 5 dBm.
- **Tilt**: The amount of tilt applied across the active bandwidth in **dB**.
- **Mode**: Allows you to enable or disable the modulator's IF output signal.
- **IQ Calibration Finished**: Indicates when the calibration is finished.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Revision History

DATE VERSION AUTHOR COMMENTS

17/10/2018 1.0.0.1 RBL, Skyline Initial version
