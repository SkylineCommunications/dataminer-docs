---
lang: en
title: CISCO Manager
---

# CISCO Manager

With the CISCO Manager it is possible to configure and monitor CISCO
switches, for example the CISCO Catalyst 3750.  
Because multiple device types are supported, monitoring can be enabled
or disabled for a specific type.

## About

The CISCO Manager driver can retrieve information from different device
types. This makes it possible to limit the retrieval of parameter values
to what is needed or available on the device at hand.  
In addition to polling values, you can configure settings such as the
ping function as if doing so on the device itself.

### <span class="ms-rteStyle-Accent1">Version Info</span>

<table class="ms-rteTable-default" data-cellspacing="0" style="width: 60%;">
<colgroup>
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
</colgroup>
<tbody>
<tr class="odd ms-rteTableEvenRow-default">
<td class="ms-rteTableEvenCol-default" style="width: 15%"><strong>Range</strong></td>
<td class="ms-rteTableOddCol-default" style="width: 35%"><strong>Key Features</strong></td>
<td class="ms-rteTableEvenCol-default" style="width: 10%"><strong>Based on</strong></td>
<td class="ms-rteTableOddCol-default" style="width: 30%"><strong>System Impact</strong></td>
</tr>
<tr class="even ms-rteTableOddRow-default">
<td class="ms-rteTableEvenCol-default" style="width: 15%">2.1.0.x</td>
<td class="ms-rteTableOddCol-default" style="width: 35%">SNMPv1, display key Detailed Interface Info: "IF Custom Description"</td>
<td class="ms-rteTableEvenCol-default" style="width: 10%">-</td>
<td class="ms-rteTableOddCol-default" style="width: 30%">-</td>
</tr>
<tr class="odd ms-rteTableEvenRow-default">
<td class="ms-rteTableEvenCol-default" style="width: 15%">2.1.1.x</td>
<td class="ms-rteTableOddCol-default" style="width: 35%">SNMPv1, display key Detailed Interface Info: "IF Name:IF Custom Description"</td>
<td class="ms-rteTableEvenCol-default" style="width: 10%">-</td>
<td class="ms-rteTableOddCol-default" style="width: 30%">-</td>
</tr>
<tr class="even ms-rteTableOddRow-default">
<td class="ms-rteTableEvenCol-default" style="width: 15%">3.1.0.x</td>
<td class="ms-rteTableOddCol-default" style="width: 35%">SNMPv2, display key Detailed Interface Info: "IF Custom Description"</td>
<td class="ms-rteTableEvenCol-default" style="width: 10%">-</td>
<td class="ms-rteTableOddCol-default" style="width: 30%">-</td>
</tr>
<tr class="odd ms-rteTableEvenRow-default">
<td class="ms-rteTableEvenCol-default" style="width: 15%">3.1.1.x</td>
<td class="ms-rteTableOddCol-default" style="width: 35%">SNMPv2, display key Detailed Interface Info: "IF Name:IF Custom Description"</td>
<td class="ms-rteTableEvenCol-default" style="width: 10%">-</td>
<td class="ms-rteTableOddCol-default" style="width: 30%">-</td>
</tr>
<tr class="even ms-rteTableOddRow-default">
<td class="ms-rteTableEvenCol-default" style="width: 15%">4.1.1.x</td>
<td class="ms-rteTableOddCol-default" style="width: 35%">SNMPv3, display key Detailed Interface Info: "IF Name:IF Custom Description"</td>
<td class="ms-rteTableEvenCol-default" style="width: 10%">-</td>
<td class="ms-rteTableOddCol-default" style="width: 30%">-</td>
</tr>
<tr class="odd ms-rteTableEvenRow-default">
<td class="ms-rteTableEvenCol-default" style="width: 15%">5.1.1.x [Obsolete]</td>
<td class="ms-rteTableOddCol-default" style="width: 35%">SNMPv2: Uses naming. For the display key, the user can choose between "IF Name:IF Custom Description" or "IF Custom Description". For a new element, the default display key is "IF Name:IF Custom Description".</td>
<td class="ms-rteTableEvenCol-default" style="width: 10%">-</td>
<td class="ms-rteTableOddCol-default" style="width: 30%">It is possible to switch from a 3.x.x.x version to a 5.1.1.x version. The old display key format is automatically detected, but the PID of the tables Multicast Next Hop and Switch Info has changed, so keep this in mind when these tables are used in templates, Visual Overview, etc.</td>
</tr>
<tr class="even ms-rteTableOddRow-default">
<td class="ms-rteTableEvenCol-default" style="width: 15%">5.1.2.x [Obsolete]</td>
<td class="ms-rteTableOddCol-default" style="width: 35%">SNMPv2: Replaces 5.1.1.x. This range fixes the IF Utilization Range that was off with 100 since version 5.1.1.78.</td>
<td class="ms-rteTableEvenCol-default" style="width: 10%">5.1.1.83<br />
</td>
<td class="ms-rteTableOddCol-default" style="width: 30%">No element recreation needed; just be aware that trending/alarm monitoring on IF Utilization can show spikes between versions.</td>
</tr>
<tr class="odd ms-rteTableEvenRow-default">
<td class="ms-rteTableEvenCol-default" style="width: 15%">5.1.3.x [Obsolete]</td>
<td class="ms-rteTableOddCol-default" style="width: 35%">SNMPv2: replaces 5.1.2.x. This range adds a new HTTP interface. This interface is hidden and does not require that the element is recreated.</td>
<td class="ms-rteTableEvenCol-default" style="width: 10%">-</td>
<td class="ms-rteTableOddCol-default" style="width: 30%">-</td>
</tr>
<tr class="even ms-rteTableOddRow-default">
<td class="ms-rteTableEvenCol-default" style="width: 15%">5.1.4.x [Obsolete]</td>
<td class="ms-rteTableOddCol-default" style="width: 35%">Made Cassandra-compliant.</td>
<td class="ms-rteTableEvenCol-default" style="width: 10%">5.1.3.12</td>
<td class="ms-rteTableOddCol-default" style="width: 30%">-</td>
</tr>
<tr class="odd ms-rteTableEvenRow-default">
<td class="ms-rteTableEvenCol-default" style="width: 15%">5.1.5.x [Obsolete]</td>
<td class="ms-rteTableOddCol-default" style="width: 35%">- Improvements to IPSec logic.<br />
- Merge of all 5.1.X.X versions.</td>
<td class="ms-rteTableEvenCol-default" style="width: 10%">-</td>
<td class="ms-rteTableOddCol-default" style="width: 30%">-</td>
</tr>
<tr class="even ms-rteTableOddRow-default">
<td class="ms-rteTableEvenCol-default" style="width: 15%">5.1.6.x [SLC Main]</td>
<td class="ms-rteTableOddCol-default" style="width: 35%">Added extra connection for SysLog information.</td>
<td class="ms-rteTableEvenCol-default" style="width: 10%">5.1.5.1</td>
<td class="ms-rteTableOddCol-default" style="width: 30%">-</td>
</tr>
<tr class="odd ms-rteTableEvenRow-default">
<td class="ms-rteTableEvenCol-default" style="width: 15%">6.1.1.x</td>
<td class="ms-rteTableOddCol-default" style="width: 35%">SNMPv3 version of 5.1.1.x.</td>
<td class="ms-rteTableEvenCol-default" style="width: 10%">-</td>
<td class="ms-rteTableOddCol-default" style="width: 30%">-</td>
</tr>
<tr class="even ms-rteTableOddRow-default">
<td class="ms-rteTableEvenCol-default" style="width: 15%">7.0.0.x</td>
<td class="ms-rteTableOddCol-default" style="width: 35%">SNMP2: temporary branch created based on 5.1.1.x to change the Element Type into "Management System".</td>
<td class="ms-rteTableEvenCol-default" style="width: 10%">-</td>
<td class="ms-rteTableOddCol-default" style="width: 30%">If you move to this branch, you will need to recreate the element.</td>
</tr>
<tr class="odd ms-rteTableEvenRow-default">
<td class="ms-rteTableEvenCol-default" style="width: 15%">8.0.0.x</td>
<td class="ms-rteTableOddCol-default" style="width: 35%">Customer-specific range.<br />
<strong>Deprecated as of 2021.</strong></td>
<td class="ms-rteTableEvenCol-default" style="width: 10%">5.1.3.12</td>
<td class="ms-rteTableOddCol-default" style="width: 30%">-</td>
</tr>
</tbody>
</table>

###  

**The current preferred version range to use is the 3.1.1.x or 5.1.6.x.
Note that all history data will be lost when you switch between these
two ranges.**  
**The main version to use for new elements is 5.1.6.x.**

## Configuration

### <span class="ms-rteStyle-Accent1">Enabling SNMPv3</span>

As version range 4.1.1.x and 6.1.1.x use SNMPv3, extra settings are
needed for these. The following steps must be executed before data can
be retrieved.

In **System Display**, go to **Admin** \> **Elements**.

In the **Element List** header, click **Export**.

In the **Export** dialog box, select **All Element data** and **Save**
as CSV file.

Open the CSV file and specify the additional settings for the SNMPv3
elements in the columns:  

DataBits: contains the username

StopBits: contains the security level. Possible values:

-   0: NOAUTH_NOPRIV
-   1: AUTH_NOPRIV
-   2: AUTH_PRIV

Parity: contains the authentication type. Possible values:

-   0: NONE
-   1: MD5
-   2: SHA1

GetCommunity: contains the authentication password

FlowControl: contains the privacy type. Possible values:

-   0: NONE
-   1: DES
-   2: AES128

SetCommunity: contains the privacy password

**Save** the CSV file.

In the **Element List** header, click **Import**.

In the **Open dialog box**, select the CSV file and click **Open**.

Version range 2.1.x.x, 3.1.x.x and 5.1.x.x do not require any extra
settings.

### <span class="ms-rteStyle-Accent1">SNMP Polling</span>

As this driver supports different types of devices, all polling of
parameters is disabled by default. The needed parameter sections have to
be explicitly enabled.     
You can do so on the **General** page via the **SNMP Polling** page
button.

### <span class="ms-rteThemeForeColor-5-0">HTTP Polling</span>

Some tables are not accessible through SNMP, so an interface was added
in order to make some data available for display.

You cannot configure this interface during element creation;
however, **you** **must** **configure the device's HTTP interface in the
device CLI** in order for DataMiner to be able to access data via
HTTP.  
You also have to go to the **HTTP Polling** subpage of the **General**
page and set up the connection with CLI **username**, **password**,
**privilege** **level** and **operation** **mode**. The driver will
start polling HTTP data when the username and password are configured
and when any of the toggle buttons present on the HTTP Polling page are
set to "Enable".

### <span class="ms-rteStyle-Accent1">Enabling LITE mode</span>

You can enable LITE mode (only displaying part of the interface table)
on the **General** page via the **SNMP Polling** page button. 

## Usage

### <span class="ms-rteStyle-Accent1">General page</span>

On the General page, an overview of general device settings is
displayed, e.g. **Model**, **Software Description**, etc.

Multiple page buttons are also available that provide access to more
specific information:

-   **Memory Details**: When enabled, memory information will be shown
    in the table. Polling can be enabled or disabled.
-   **TCP/UDP Stats**: When enabled, TCP/UDP information will be shown.
    Extra information can be found via the **UDP** **Listener Info** and
    **TCP Connection Table** page buttons. Polling can be enabled or
    disabled.
-   **ICMP Stats**: When enabled***,*** ICMP information will be shown.
    Polling can be enabled or disabled.
-   **IP Stats**: When enabled, IP information will be shown. Polling
    can be enabled or disabled.
-   **Services**: Displays whether a service layer is active or not.
-   **VTP Info**: Displays VTP information. This can be loaded manually.
-   **MAC Addresses**: Displays the MAC addresses. This must be loaded
    manually.
-   **Copy config**: Allows you to define the CISCO Copy Configuration
    and start it.
-   **Ping**: Allows you to define items for which the ping operation
    will be performed. The ping can be enabled or disabled.
-   **Reset Counters**: Allows you to clear the interface counters of
    all ports or of specific ports.
-   **Enable Polling**: Allows you to enable or disable multiple and/or
    different sections of parameters that need to be polled.

In addition, buttons are available that allows you to perform a
**Redetect Config**, **Save Configuration** or **Reset Device**
operation.

### <span class="ms-rteStyle-Accent1">Detailed Interface Info page</span>

The Detailed Interface Info page displays the interface info.

The column **IF Counter Type** displays if the bitrates are calculated
with 32-bit or 64-bit counters. The bitrates are refreshed every 30s
with the 32-bit counters. This is also the maximum allowed timespan to
avoid a counter wraparound. With 64-bit, the bitrates are refreshed
every minute to avoid drops to 0 Mbps for devices with a very high load.

**XMPL RPC** is an option to retrieve data that is not available on the
CISCO device itself, e.g. **IF Speed** from a server. It will be
retrieved via calls to a customized platform.

Via **Measurement Configuration**, you can enable or disable the display
and calculation of the interface communication KPIs. Driver version
range 2.1.x.x uses subtables, which limits the polling (disabled rows
are not polled). Range 3.1.x.x uses "multiplegetbulk", because when some
cells were empty, the complete interface table was empty when polled
with range 2.1.x.x. Multiplegetbulk does not support subtables, so
disabled rows will still be polled.

In the **3.1.1.x** and **4.1.1.x** ranges, you can temporarily
activate the **high-resolution measuring** option, which triggers
polling, calculating and updating interface-related KPIs with a
frequency of **approximately 1 second**.  
You can enable this option and define the active time in the **MCT- High
Resolution Measuring** and **MCT- High Res Active Time** columns of the
**Measurement Configuration Table**, respectively.

More detailed information about the incoming and outgoing information
can be found on the **Detailed Information Info - Rx** and **Detailed
Information Info - Tx** pages.

The **History Data** page button (3.1.0.x, 5.1.1.x) leads to an overview
of the **Monthly traffic statistics.** These statistics are calculated
each month. More detailed info (per day/week or month) can be found in
the **Detailed Interface Info** table.

The **Alarm Settings** page displays the settings for Consecutive and
Non-Consecutive behavior on the Interface Utilization (%). With the
**Threshold** you can specify a baseline in percent. The **Period**
defines the amount of time that the threshold will be surpassed
(consecutive) or the sum of the amounts of time that the threshold is
surpassed (non-consecutive). The **Days** defines the number of days
this behavior is active before setting an alarm. The alarm is set on
**IF Util. Consecutive/Non-Consecutive** in the **Detailed Interface
Info** table. With the **Status Period Alarms** toggle button, you can
enable/disable this feature.

### <span class="ms-rteStyle-Accent1">Trunk Info page</span>

On the **Trunk Info** page you can have the trunk ports table polled
automatically by enabling **Get Trunk Data.** To request the table, just
click the **Load** button once. The columns **Trunk Allowed** and
**Trunk Pruning** will display the VLANs in the following formats:

-   *All:* All VLANs are included.
-   *None:* No VLANs are included.
-   A range, e.g. *2,5,100-200*: VLAN 2 and VLAN 5 and VLANs 100 to 200
    (including 200) are included.

There are several possibilities to change these columns (the explanation
below focuses on **Trunk Allowed**; however, **Trunk Pruning** is
similar):

-   Write the correct format in the **Trunk Allowed** column.
-   To add one VLAN to the current range (current VLANs will remain
    included), click the **Add Allowed Trunk** write parameter and fill
    in a VLAN.
-   To remove one VLAN from the current range, click the **Remove
    Allowed Trunk** write parameter and fill in a VLAN.
-   The page button **Modify Trunk** allows you to add a new entry to
    the trunk ports table or to edit an existing entry.

### <span class="ms-rteStyle-Accent1">Other pages</span>

The pages **PoE, ISDN, BGP, HSRP, LDP, OSPF, IGMP, IPSec, IPSLA, Vlan
Info, IP Routing Info, Fan - PS Info, Chassis, Hardware Status,
Temperature, Multicast, Multicast Next Hop, Ping Function** and **NBAR,
Netflow, SHDSL, XDSL** display their corresponding information and for
each the polling can be *Enabled* or *Disabled*.

In the **3.1.1.x** and **4.1.1.x** ranges, you can use the **Measurement
Configuration** functionality for **IP SLAs**.

### <span class="ms-rteStyle-Accent1">SCP ( From range 3.1.1.81 )</span>

SCP

-   **SCP Local Folder**: This parameter defines the path where the
    local folder should be created. This folder will contain the private
    keys and known host file.
-   **SCP Host**: This parameter defines the IP of the switch to connect
    to.
-   **SCP Port**: The port to be used for SCP connections.
-   **SCP Username**: The username used to login.
-   **SCP Password**: The password used to login.
-   **SCP Known Host File**: This parameter defines the name that should
    be given to the known host file, or the file that needs to be used.
    (If no file exists with the specified name, a new file with that
    name will be created.)
-   **Private Key File Name**: The name of the private key file to be
    used when authenticating the connection. **Note that to be able to
    use private key files, both the .ppk (used to connect with SCP) and
    .txt file (used to connect with Jsh) need to be present in the SCP
    Local Folder and have the same name.**

Download

-   **Download Directory**: This parameter defines the directory where
    the downloaded files will be stored.
-   **Configuration File**: This parameter defines the possible
    configuration file to be downloaded from the device/switch.
-   **Download Status**: The status of the download process.

The **SCP functionality is only supported from DataMiner v9.5.3.0 - 6487
onwards**, as this relies on the SLSsh.dll library. When the protocol is
run on an older DMA, the log files will indicate a problem
when DataMiner tries to build QAction 52000 and SCP will not work. This
does not affect the rest of the protocol.

### <span class="ms-rteStyle-Accent1">Voice-Dial (in 3.1.x.x range)</span>

This page contains tables used for the management and configuration of
voice telephony peers. In the 3.1.0.x range, it contains the **VoIP Peer
Config** page button, that displays the **VoIP Peer Configuration
Table**. In the 3.1.1.x range, the **VoIP Peer Configuration Table**
is displayed on the main **Voice-Dial** page.

## DataMiner Connectivity Framework

The 3.1.1.x, 4.1.1.x and 5.1.1.x driver range of the CISCO Manager
protocol supports the usage of DCF and can only be used on a DMA with
**8.5.4** as the minimum version.

Different DCF configurations can be set on the DCF Config page.

DCF can also be implemented through the DataMiner DCF user interface and
through DataMiner Third Party protocols (for instance a manager).

### <span class="ms-rteStyle-Accent1">Interfaces</span>

#### <span class="ms-rteStyle-IntenseQuote">Dynamic Interfaces</span>

Virtual dynamic interfaces:

-   VLAN Info: virtual interfaces are created for **VLAN** connections,
    type inout.

Physical dynamic interfaces:

-   DCF IF Table: physical interfaces are filtered from the **Detailed
    Interface Info** Table, type inout.

### <span class="ms-rteStyle-Accent1">Connections</span>

#### <span class="ms-rteStyle-IntenseQuote">Internal Connections</span>

On the DCF Config page, you can select 2 different sources for creating
internal connections:

VLAN

-   Start Topology: For each VLAN, a virtual IF is created in the DCF
    table. The IFs are connected with their corresponding VLAN(s).
-   Full Mesh: The IFs are connected directly to each other. This can
    generate a lot of connections if a VLAN contains multiple IFs
    (n(n-1)/2 connections).

Multicast

-   Connections are created based on the multicast flows from the
    **Multicast Next Hop** table.

Between interfaces, an internal connection is created with the following
properties (if enabled):

-   **VLAN** connection property of type **inout** with value **VLAN
    ID**.
-   **MC** connection property of type **inout** with value **Multicast
    IPs** (separated by ';').

## Notes

### <span class="ms-rteStyle-Accent1">CISCO Copy Configuration (Cisco IOS)</span>

The configuration is stored in two locations, RAM and NVRAM. The running
configuration is stored in RAM and is used during operation. Any
configuration changes are made to the running configuration and take
effect immediately. The startup configuration is stored in NVRAM and is
loaded into the device's running configuration when booting. If the
device loses power or is reloaded, changes to the running configuration
will be lost unless they are saved to the startup configuration. The
Cisco IOS is stored in FLASH memory. The IOS is the Operating System
controlling the device.

Load configuration

Network>RAM

-   Copy Config Protocol: TFTP
-   Copy Config Source File Type: Network File
-   Copy Config Destination File Type: Startup Config
-   Copy Config Server Address: The IP address of the server from which
    to copy the configuration file (e.g. 192.168.1.1)
-   Copy Config File Name: The file name (including the file path, if
    applicable) (e.g. cisco-cfg)

Network>NVRAM

-   Copy Config Protocol: TFTP
-   Copy Config Source File Type: Network File
-   Copy Config Destination File Type: Running Config
-   Copy Config Server Address: The IP address of the server from which
    to copy the configuration file (e.g. 192.168.1.1)
-   Copy Config File Name: The file name (including the file path, if
    applicable) (e.g. cisco-cfg)

RAM>NVRAM

-   Copy Config Protocol: NA
-   Copy Config Source File Type: Startup Config
-   Copy Config Destination File Type: Running Config
-   Copy Config Server Address: NA
-   Copy Config File Name: NA

Save configuration

NVRAM>RAM

-   Copy Config Protocol: NA
-   Copy Config Source File Type: Running Config
-   Copy Config Destination File Type: Startup Config
-   Copy Config Server Address: NA
-   Copy Config File Name: NA

Backup configuration

RAM>Network

-   Copy Config Protocol: TFTP
-   Copy Config Source File Type: Startup Config
-   Copy Config Destination File Type: Network File
-   Copy Config Server Address: The IP address of the server to which to
    copy the configuration file (e.g. 192.168.1.1)
-   Copy Config File Name: The file name (including the file path, if
    applicable) (e.g. cisco-cfg)

NVRAM>Network

-   Copy Config Protocol: TFTP
-   Copy Config Source File Type: Running Config
-   Copy Config Destination File Type: Network File
-   Copy Config Server Address: The IP address of the server to which to
    copy the configuration file (e.g. 192.168.1.1)
-   Copy Config File Name: The file name (including the file path, if
    applicable) (e.g. cisco-cfg)

Load IOS

Network>FLASH

-   Copy Config Protocol: TFTP
-   Copy Config Source File Type: Network File
-   Copy Config Destination File Type: IOS File
-   Copy Config Server Address: The IP address of the server from which
    to copy the IOS file (e.g. 192.168.1.1)
-   Copy Config File Name: The file name (including the file path, if
    applicable) (e.g. cisco-ios)

Backup IOS

FLASH>Network

-   Copy Config Protocol: TFTP
-   Copy Config Source File Type: IOS File
-   Copy Config Destination File Type: Network File
-   Copy Config Server Address: The IP address of the server to which to
    copy the IOS file (e.g. 192.168.1.1)
-   Copy Config File Name: The file name (including the file path, if
    applicable) (e.g. cisco-ios)

<div>

From version 5.1.6.x onwards, an extra connection is used to collect the
Syslog information.

</div>
