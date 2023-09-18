---
uid: Connector_help_SA_DCM
---

# SA DCM

This connector monitors a Cisco DCM (D9900) device.

## About

The Cisco D9900 family, also known as DCM (Digital Content Manager), can be monitored by the SA DCM connector. This device was originally developed by Scientific Atlanta (hence "*SA* DCM"), which was later acquisitioned by Cisco.

This connector is now considered **obsolete**. Please use the fully revised connector "Cisco DCM" instead.

The Cisco DCM connector range has the following advantages over the SA DCM connector:

- It is considered the main priority and is actively maintained.
- It has been completely revised and has a faster polling mechanism.
- More parameters are available.
- There is more control on polling. (For each parameter type you can individually set what is polled and at what speed.)
- It has support for automatic distribution and synchronization of configuration parameters.

Note that the two connectors are not compatible.

### Version Info

| **Range** | **Key Features**                                                                                     | **Based on** | **System Impact**                                                          |
|-----------|------------------------------------------------------------------------------------------------------|--------------|----------------------------------------------------------------------------|
| 1.0.0.x   | Initial SNMP connector. Obsolete.                                                                    | \-           | \-                                                                         |
| 2.0.0.x   | IIOP used instead of SNMP.                                                                           | \-           | \-                                                                         |
| 2.0.1.x   | Sub-branch of the 2.0.0.x range with a reduced parameter set. Also known as "SA DCM Lite". Obsolete. | 2.0.0.1      | **-**                                                                      |
| 2.0.2.x   | Fixed issue in the DCM Alarm Tables.                                                                 | 2.0.0.49     | The display key format has changed for the Input & Output DCM Alarm Tables |
| 3.0.0.x   | Range created specifically for customer Vodafone New Zealand.                                        | 2.0.0.20     | \-                                                                         |

### Product Info

| **Range** | **Supported Firmware**                                                                                                                                     |
|-----------|------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | \-                                                                                                                                                         |
| 2.0.0.x   | Before connector version 2.0.0.51, only firmware versions below 16.10 are supported. Connector version 2.0.0.52 adds support for firmware 16.10 and above. |
| 2.0.1.x   | \-                                                                                                                                                         |
| 2.0.2.x   | Firmware version below 16.10                                                                                                                               |
| 3.0.0.x   | \-                                                                                                                                                         |

## Configuration

### Prerequisites

For this connector, Visual C++ 2008 (or 2010) Redistributional must be installed. To verify whether this program has been installed, go to: Control Panel \> Programs and Features.
If the program has not been installed yet, you can download it from microsoft.com.

### Installation

The SA DCM connector is more than just an XML protocol file. It comes with multiple libraries that need to be installed first. For this reason, it is often delivered as a ".dmupgrade" or ".dmprotocol" package. The delivery method may differ depending on the range and version of the connector. Eventually only ".dmprotocol" upgrade files will be distributed automatically from the Update Center. However, until this is possible, follow the procedure below.

To install the DataMiner package:

1. Copy the upgrade package to one of the DMAs and double-click it.

   This will start the upgrade procedure.

1. Do not modify the standard upgrade settings.

1. Upload the protocol or, if available, install the protocol package.

   All required files should now be installed and ready for use.

Note: The .dmupgrade package does not install the XML protocol itself, only the extra DLLs. The Protocol.xml file will be delivered along with the package and can be installed in the same way as any other protocol.

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol connection and requires the following input during element creation:

**SNMP Connection:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.

### Initialization (2.x.x.x ranges only)

Before you use the connector, some extra configuration may be required to get the connection up and running.

Follow the procedures below to find and resolve any problems. Always test the connection before moving to the next procedure.

#### Connection test

To test the connection:

1. Restart the element.

1. Open the element card.

1. On the **Overview** page, check if there are icons in the tree view.

   - If yes -\> Test succeeded.

   - If no -\> Test failed.

If the test failed, continue with the next procedure.

#### Verifying the IP address

To verify the IP address:

1. Open the element wizard and check the **IP address/host** under *SNMP CONNECTION*.

Test the connection again before you continue.

#### Verifying the IIOP credentials

Depending on the firmware version of the device, you may need to enable and configure IIOP settings to ensure that the DCM will allow external communication.
Older versions (V8) have IIOP automatically enabled and use "guest" as username and password. However, for newer versions (V10, V12) it must be enabled, and the latest versions (V14, V15) may need different settings on several pages.

To verify the IIOP credentials:

1. Go to the webpage of the DCM device and log on as Administrator.
1. Open the page **Security** and select the tab **OS Accounts**. A list should appear with available OS accounts.
1. Make a new user account or edit an existing one. We recommend that you use the username *guest* and password *guest* and make sure the option **IIOP** is enabled.
1. Go to the element card and open the **IIOP** page. You can find this page by clicking the corresponding page button on the **connector Settings** page.
1. If you have an OS account with the username and password *guest*, you can set **IIOP Use Credentials** to *No*; otherwise set this parameter to *Yes* and fill in the username and password.

Note: Keep in mind that the password is sent to the DCM in plain text, so a simple Wireshark capture can easily reveal the password (by filtering on IP and port 5003 and searching for logon). Also, the username and password must be the same for all elements on the same DMA.

Test the connection again before you continue.

#### Verifying the DLLs

The connector requires several DLLs in order to function properly.
Check if all files mentioned below are in the correct location in the system.

- In the folder "*C:\Skyline DataMiner\Files*":

  - omniORB416_vc10_rt.dll

  - omnithread34_vc10_rt.dll

  - SLDCM Full 2.0.0.X .dll

    or

    SLDCM L 1.0.0.X .dll

  In the above, "X" can be found on [catalog.dataminer.services](https://catalog.dataminer.services/).

  Not all records specify all required DLLs; usually they contain only the DLLs that have a version number. If even these are not mentioned, there were no changes to the DLLs. If so, you should look for the previous version of the connector until you find a record mentioning the DLL names. However, you should only look for versions in the same range.

The newest version may also need the following files:

- In the folder "*C:\Skyline DataMiner\ProtocolScripts*":

  - IIOPChannel.dll

  - SL_API_CISCO_D9900_IIOP.NET.dll

If a file is missing, run the upgrade package again and verify if the DLLs are present.
If the problem persists, contact Skyline in order to obtain the required DLLs.

#### Verifying network traffic

The communication with the device uses port 5003. This port can be blocked by a firewall between the DMA and the device. To check if this is the case, open Wireshark and filter on traffic from/to the IP address of the DCM and port 5003. There should be traffic in both directions. If packets are sent to the DCM, but none return, this indicates a firewall problem. In that case, contact the network administrator to have that port opened.

Test the connection again before you continue.

#### Verifying the prerequisites

Verify if the prerequisites are installed: Visual C++ 2008 (or 2010) Redistributional. If not, install them (see "Prerequisites" section above).

#### Verify the log file

If you have tried all the previous steps and there is still no data in the DCM, check the log file. It is possible that the reason for the problem is clearly indicated in the log file. Usually it can be found somewhere at the end and is repeated several times. If there are no errors or it is not clear how to fix the errors, contact your Skyline Communications Technical Account Manager and send them the log file.

The log file can be found in "*C:\Skyline DataMiner\Logging\\ElementName\].txt*".
You can also find it in Cube:

1. In the **Surveyor**, click **Start \>** **Apps** \> **Logging**. This will open a new card.
1. Select **Elements** and select the name of the element in the list.

## Usage

### General

This page contains device information parameters such as **System Name**, **Serial Number**, and **Software Version**. There is also a table, **Module Info**, which lists all detected parts on the controller and cards with their version info.

There is also a page button, **IIOP Login**, that leads to a window where you can configure the **IIOP** **Login Name** and **IIOP Password**. These are used to log on to an OS account. Note that this OS account is not the same account used to access the web interface. Also, make sure that the OS account in question has IIOP enabled. (See the Initialization section above.)

### General (2.0.1.x)

This page contains all parameters described in the General section above, with one extra table, **GbE IP Port Settings**. This table contains the **IP**, **MAC**, and **SubNet** for all Ethernet ports on the GbE cards plugged into the main chassis.

Polling of this table is by default disabled, but you can enable this with the parameter **GbE IP Port Settings - Polling**. You can also see the date and time when the table was last updated with the parameter **GbE IP Port Settings - Last Update**.

In this version, the page also contains two other important parameters:

- **IIOP Network Error Detected:**

  - *Yes* means that there is no communication with the device at all. This can be because a firewall blocks all traffic, the IP address is wrong, the device is offline, or the Ethernet cable is unplugged.

  - *No* means that there is an IIOP-enabled device at the specified end point. If the device does not seem to work, and there is no network error, the problem is usually caused by wrong credentials.

- **Action After Network Error:**

  Network errors are typically not solved quickly and require manual interaction to fix the problem. This means that continuing the normal poll cycle can cause an avoidable, unnecessary use of resources. Especially in older versions, a network error could severely affect the polling of other elements. For instance, because of bad locking policies, all elements could wait for the timeout of an element during logon, which could take 20 seconds. This would entail that all other elements would not poll during those 20 seconds. In more recent versions, all communication to the device is **asynchronous**, so that this problem cannot occur.

  - *None* is the default value. This means that the device will keep polling as usual.

  - *Reduce Polling* is an alternative where only the alarms are polled until the network problem is solved.

  - *Ping* is the most effective choice: polling will stop temporarily, until a successful ping message is returned. However, the main problem with this option is that the connector will never recover if ping messages are blocked by a firewall. So before you enable this option, make sure to test if ping messages do work.

### Transrater (2.0.1.x)

This page contains a table displaying the transrater settings.

It contains the columns **On ID**, **Group Name, Type**, **Input Service Bitrate**, **Output Service Bitrate**, and **Compression**.

### TS Backup

This page contains an overview table with the backup settings on transport stream level.

Available fields are **Input TS ID**, **Revertive**, **Main - Backup Delay**, **Backup - Main Delay**, and the **Active TS**.

### Service Backup

This page contains two tables. The first table lists information about the main services. The table below lists the information of merged services.

Available fields are: **Active Service ID**, **Revertive** indicator, **Main - Backup Delay**, and **Backup - Main Delay**, and information about the main and backup transport stream and service, such as **Board, IP Address, UDP Port** and **TS ID** for the transport stream, and **SID** and **Name** for the service.

### Inputs Overview

This page contains a tree control with an overview of input TS and input service.

### Outputs Overview

This page contains a tree control with an overview of output TS and output service.

### Stream Packet Counters (2.0.1.x)

This page contains packet counters for input transport streams.

Packet counters can be retrieved for all packet types in case:

- no error correction is configured,
- FEC protection is enabled,
- Single Port Hitless Merge is enabled, or
- Hitless Merge over Separate Ports is enabled.

In general, the **Missing Packets before Error Correction** counters are only increased for streams of which stream-specific settings have a non-zero threshold value (limited to **at most** **32** main TS per port pair).
If no error correction is configured, only the **Valid Packet** counters and the **Missing Packets after Error Correction** counters are increased. The **Fixed Packet** counters are only increased if FEC protection is used.

Note:

- This requires firmware release 11.10.
- This can be enabled/disabled and manually refreshed with the parameter **Stream Packet Counters - Polling**.

### DCM Alarms (2.0.1.x)

This page contains a list of active alarms on the device.

Available columns are **Key** (= Description), **Generation Time**, **Alarm Level**, and **Alarm Type**.

### Digital Program Insertion

This page contains a table listing the settings for DPI.

Available columns are **Output** **Channel Name**, **Mode**, **PMT Mode**, **Insertion Channel Service** and **License**, **Status**, **Last Error**, and **Next Splice**.

There is also a page button, **DPI Splicing,** at the bottom of the page, which opens a window where you can select a service and switch to either the *Primary* or the *Insertion* stream. Click the **Splice** button to apply the change.

### IGMP

On this page, a table lists the following information about IGMP:

- **Key:** Formatted as "*Board \[board\], Port \[port\]*"; both board and port are one-based.

- **Multicast Group:** A multicast IP address.

- **Leave Allowed**

- **Filter Type:**

  - *Include*: An Include source list contains the IP addresses from which multi-cast reception is allowed.

  - *Exclude*: An Exclude source list contains the IP addresses from which multi-cast reception is not allowed.

    > [!NOTE]
    > In an **IGMPv2** environment, the **Filter** parameter must be set to ***Exclude***.

- **Filter List:** A list containing comma-separated filter items.

Polling of this information can be enabled/disabled using the parameter **IGMP V3 Table - Polling** below the table. The last update can be found above the table in the **Last Update** parameter.

### Web Interface

The native interface for the device. The client machine has to be able to access the device. If not, it will not be possible to open the web interface.

## Notes

This connector uses a non-standard communication protocol to interact with the device. As a result, the stream viewer will not contain any traffic even if everything works correctly. The best way to verify the communication is to open the log file after setting the **Info Logging Level** to *Level 1*. With these settings, the connector will log each start and end as well as potential errors in the log file.

All IIOP communication happens on port 5003, regardless of the port configured in the element wizard.
The SNMP interface is only used in case there is a timeout when Slow Poll is activated. At this point, the connector may poll the "System Name" only to verify the connection status. (This parameter is not displayed in the UI.)

Because of limitations of the communication framework, it is **not possible to poll the same IP address from multiple elements on the same DMA**. Doing so can in the worst case **result in runtime errors and require a restart** of the main software to recover. If this happens, all elements using the omni orb framework may be affected by this problem (including Cisco DCM elements and Cisco D9036 elements.) You may be able to work around this by using traffic redirection with third-party software.
