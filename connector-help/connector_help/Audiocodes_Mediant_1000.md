---
uid: Connector_help_Audiocodes_Mediant_1000
---

# Audiocodes Mediant 1000

The AudioCodes Mediant 1000 Enterprise Session Border Controller (E-SBC) and Media Gateway is designed to provide a complete connectivity solution for small-to-medium sized enterprises.

## About

This is an SNMP-based protocol for Audiocodes Mediant 1000 telephone gateways.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 7.20A.150.004               |

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

### Alarms

This page contains the **Active Alarms Table**, which displays all active alarms on the device.

### General

This page displays general device parameters such as the **System Description** and **System Uptime.**

### Application Settings

This page contains general settings for the device, such as **NTP** and **Daylight Saving Time**.

### Interfaces

This page contains the **Interfaces Table**, which contains information such as the **incoming**/**outgoing** packets, **errors**, **discards**, **bitrate**, and both **in** and **out utilization**.

### Performance

This page contains **IP to Tel** and **Tel to IP** call statistics. There is also a **Reset Frequency** parameter, which can be used to reset all parameters on the page based on the selection (*Manual*, *Daily* or *Monthly*).

### Tel to IP Routing

This page contains the **Tel to IP Routing Table**, where you can modify the **Route** **Name**, **Destination** **Phone**, **Destination** **IP**, **Transport** **Type**, etc.

### IP to Tel Routing

This page contains the **IP to Tel Routing** **Table**, where you can modify the **Route Name**, **Source IP Address**, **Destination Phone**, **Phone Prefix**, etc.

### SRDs

This page contains the **SRD** **Table**, which can be used to monitor and edit the **Name**, **Max** **Number** **of** **Registered** **Users**, **Media** **Anchoring**, etc.

### Proxy Sets

This page contains both the **Proxy Sets Table** and **Proxy** **IP** **Table**.

In the Proxy IP Table, you can edit the **Proxy** **Set** **ID** to assign the **IP** corresponding to that row to a Proxy Sets row by matching the primary key of that table.

### IP Groups

This page contains the **IP** **Groups Table**, which contains information for each IP group, such as the **name**, the **SRD**, the **Proxy** **Set** it is linked to, the **Type**, and a few other options that can be edited.

### Trunks

This page contains various tables related to the **trunks** **settings**, **configuration** and **status**.

### Trunk Groups

This page contains the **Trunk** **Groups** **Table**, where you can edit the **From** and **To** **Trunk**, the **Starting** and **Last** **Channel**, the **Phone** **Number** and the **Module** of each row.

### Trunks Group Settings

This page contains the **Trunks** **Group** **Settings Table**, which can be used to manage the **Channel** **Select** **Mode**, **Registration** **Mode**, **Serving** **IP** **Group** and **Gateway** **Name**.

### Web Interface

this page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
