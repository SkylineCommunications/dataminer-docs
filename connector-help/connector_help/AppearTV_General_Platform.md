---
uid: Connector_help_AppearTV_General_Platform
---

# AppearTV General Platform

The **AppearTV General Platform** connector is used to monitor and control an AppearTV chassis that can contain several modules of different types.

## About

This connector contains an overview of the configuration data and status data for the implemented cards. It also contains an overview of the active alarms.

SOAP calls are used to retrieve the device information. SNMP traps are used to collect alarm changes.

### Version Info

The current range of the connector is 4.4.1.x. Other ranges are not updated.

| Range | Description | DCF Integration | Cassandra Compliant |
|--|--|--|--|
| 1.0.0.x | Initial version. | No | No |
| 2.0.0.x | Connector displays the info for all cards in the chassis (and not the info of the MMI only). | No | No |
| 3.0.0.x | This connector version only supports IP Input and IP Output cards. | No | No |
| 4.0.0.x | A DVE is created for each detected module. | No | No |
| 4.1.0.x | SNMP connection added to collect SNMP traps. | No | No |
| 4.2.0.x | Serial connection replaced by HTTP connection. | No | No |
| 4.3.0.x | Removal of communicationOptions="redundantPolling". | No | No |
| 4.4.0.x \[Obsolete\] | Review of the connector (optimization of QActions, removal of unused parameters, ...) NOTE: The update from 4.4.0.102 to 4.4.0.103 involves a key change that may affect Visio drawings, Automation scripts, etc. The 4.4.1.x version range should be used instead of 4.4.0.103 and onwards. | No | No |
| 4.4.1.x \[SLC Main\] | Based on 4.4.0.107. The Input Redundancy Table (PID 18400) key was reverted to be as it was in the 4.4.0.102 version. | No | No |
| 5.0.0.x \[Obsolete - Spin-Off\] | Implementation of the class library features - requires DataMiner 9.6.3.0 - 8092. The 5.0.0.x-range is a spin-off based on version 4.4.1.12, because of the increased minimum DataMiner version. Development should still happen in the 4.4.1.x-range. A new spin-off version in the 5.0.0.x-range can be made when needed afterwards. | No | No |
| 5.0.1.x \[Obsolete\] | Merged 5.0.0.x branch with 4.4.x branch. | No | No |
| 5.0.2.x | Displayed column order of Outputs Service Configuration table changed. | No | No |

### Product Info

Range 4.4.0.x is compatible with AppearTV firmware version 3.x. The latest tested version is 3.30.

Newer firmware versions in the range 3.x are likely to work as well, since the API is backwards compatible.

## Installation and configuration

### Creation

An AppearTV chassis must have at least one MMI controller card (in slot 0). An MMI card has two connections: one HTTP interface to send SOAP calls and one SNMP interface to collect traps.

The chassis can also contain an optional second MMI controller card (in slot 17). Hence, an AppearTV element has four connections (two HTTP and two SNMP). If only one MMI card is present, the IP addresses of the second MMI must be set to *0.0.0.0.*

The element should be configured as follows (for the first IP address, use the IP of the Main Controller card):

#### SNMP CONNECTION

- **IP address**: The IP address of the first controller.
- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

#### SNMP CONNECTION 2

- **IP address**: The IP of the second controller, if available. If there is no second controller, *0.0.0.0* should be filled in.
- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

#### HTTP CONNECTION

- **IP address**: The IP address of the first controller.
- **Port number**: The IP port of the destination, *80*.
- **Bus address**: If the proxy server has to be bypassed, enter the keyword *ByPassProxy*.

#### HTTP CONNECTION 2

- **IP address**: The IP of the second controller, if available. If there is no second controller, *0.0.0.0* should be filled in.
- **Port number**: The IP port of the destination, *80*.
- **Bus address**: If the proxy server has to be bypassed, enter the keyword *ByPassProxy*.

### Configuration

If authentication is enabled on the web interface of the device, the **User Name** and **Password** can be set via the **Credentials** page button on the **General** page.

## Usage

This connector consists of several data pages:

- The **General page** contains the **Module List** table, which shows an overview of the implemented modules (cards) in the chassis. Via the **Credentials** page button, you can set the **User Name** and **Password**.
- The **Alarms page** shows an overview of the active alarms.
- On the **Import/Export page**, you can export a configuration to a file and restore a configuration from a file.
- For each card type, there is a separate page that shows the **Configuration and Status data** for the corresponding card(s).
- The **Admin page** contains the Admin Configuration data.
- The **License page** shows an overview of the installed licenses.

If the option **Advanced element settings - Enable DVE child creation** (Edit) is enabled, DVEs will be created for each module in the Module List table.

**SNMP traps** are implemented in the connector to update the **Alarms table**. However, every 30 seconds, a SOAP request to get the actual alarm data is carried out to update the Alarms table in case a trap is lost.

To have "Not available" rows automatically removed from the tables, enable the option **Autom. remove NA rows** on the General page.

## Notes

### Important remarks

- **If the status for a row is disabled in the configuration table, there will be no corresponding row in the status table.**

  If there is no status data for a certain module (i.e. the status table is empty), check in the configuration table of that module if the status parameter for the corresponding row has been set to enabled.

- **When the element has just been restarted, it is possible that the settings are carried out with a delay.**

  After a restart, first all queries are performed (configuration queries, status queries, alarm queries). Once all configuration queries have been executed, there is less communication with the device: only status queries (every 60s), alarm queries (every 30s) and the last update time check (every 30s) are performed. This means that then the settings should be done faster.

- **SOAP polling alarms** are always logged in *C:\Skyline DataMiner\Logging\AppearTV\\element name\]\\History\alarmsHistory\_\[yyyyMMdd\].txt.*

- **Trap alarms** are always logged in *C:\Skyline DataMiner\Logging\AppearTV\\element name\]\\History\trapsHistory\_\[yyyyMMdd\].txt.*

- Old history log files in *C:\Skyline DataMiner\Logging\AppearTV\\element name\]\\History* are removed automatically when they are older than one week.

- **SOAP responses** are only logged in *C:\Skyline DataMiner\Logging\AppearTV\\element name\]\\SOAP Responses\get\[\].xml* if the parameter **Log SOAP Responses** is **Enabled** on the General page. The number after the underscore in the name of the command refers to the controller card (1: main controller card, 2: backup controller card), e.g. *getService\_**1**.xml*.

- **SOAP set commands** are always logged in *C:\Skyline DataMiner\Logging\AppearTV\\element name\]\\SOAP SetCommands\set\[\].xml*.

### Implemented modules

#### Input Modules

- **INPUT ASI**:

  \*SC/3ASI-MMI, \*DC/3ASI-MMI

- **INPUT COFDM**:

  \*SC/4COFDM-MMI, \*DC/4COFDM-MMI

- **INPUT IP**:
  \*SC/GBIPIN-MMI, \*DC/GBIPIN-MMI

- **INPUT DVB-S/S2**:

  \*SC/4DVBS-MMI \*MC/4DVBSS2-MMI, \*DC/4DVBS-MMI \*DC/4DVBSS2-MMI

- **INPUT QAM, INPUT DVB-C-IN**:

  \*SC/4QAM-MMI, \*DC/4QAM-MMI

- **INPUT ENCODER**:

  Not specified

- **INPUT IPSWITCH**:

  Not specified

- **INPUT DVB T2**

- **INPUT ISDB-T**

#### Output Modules

- **OUTPUT IP**:

  \*SC/GBIPOUT, \*DC/GBIPOUT

- **OUTPUT ASI**:

  \*SC/4ASIOUTMX, \*DC/4ASIOUTMX

- **OUTPUT QAM**:

  \*SC/16QAMOUTMX, \*DC/16QAMOUTMX

- **OUTPUT DVBS2OUT**:

  Not specified

- **OUTPUT QAMOUT-A**

- **OUTPUT COFDMOUT-CABLE**

- **OUTPUT IPSWITCH**

- **OUTPUT RADIO**

- **OUTPUT ADM**

- **DECODER, ADM**:

  \*SC/ADMSDISD \*SC/ADMSDISDOSDM

  \*SC/ADMSDIHD \*SC/ADMSDIHDOSDM

  \*DC/ADMSDISD \*DC/ADMSDISDOSDM

  \*DC/ADMSDIHD \*DC/ADMSDIHDOSDM

  \*SC/ADMSDIAUDSD \*SC/ADMSDIAUDSDOSDM

  \*SC/ADMSDIAUDHD \*SC/ADMSDIAUDHDOSDM

  \*DC/ADMSDIAUDSD \*DC/ADMSDIAUDSDOSDM

  \*DC/ADMSDIAUDHD \*DC/ADMSDIAUDHDOSDM

- **RADIO**:

  \*DC/8FMR

- **SCRAMBLER**:

  \*DVB Scrambler with SCS, SC/DVBMCSXX

  \*AES Scrambler with SCS, SC/AESMCSXX

- **EPG**:

  \*SC/EPG

- **TRANSCODER**:

  Not specified

- **BULKDSCR-LATENS**:

  \*SC/BDESC25, \*SC/BDESC50, \*SC/BDESC100,

  \*SC/BDESC150, \*SC/BDESC200, \*SC/BDESC250

- **DESCRAMBLER**:

  \*SC/2C1

- **AUDIOLEVEL**:

  \*SC/AUDLEV25, \*SC/AUDLEV75

  \*SC/AUDLEV150, \*SC/AUDLEV250

- **DECODER, DESCRAMBLER**

- **IP-T2GW**

- **AUDIO ENCODER**
