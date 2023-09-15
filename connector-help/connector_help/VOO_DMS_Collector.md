---
uid: Connector_help_VOO_DMS_Collector
---

# VOO DMS Collector

With the VOO DMS Collector connector it is possible to retrieve active alarms form other DMS clusters and forward these to defined DataMiner Elements.

## About

This connector collects all the active alarms that are provided by a defined cluster and forwards them to all DataMiner Elements that were provided by the DataMiner Element running the **VOO CPE Manager** protocol.

## Installation and configuration

Any cluster from which you wish to retrieve the active alarms needs a **DataMiner Agent** and a **SNMP Manager** configuration. For each cluster from which you want to retrieve the active alarms, a **DataMiner Element** needs to be configured on a DataMiner Agent. Below, the installation and configuration process is described in detail to receive the alarms from one cluster. In case of multiple cluster, you just need to repeat this process.

### Configuring the DataMiner Agent

On each cluster from which you want to retrieve the active alarms, you need to choose one **DataMiner Agent**. This is the DataMiner that will be used for the communication between different clusters. All active alarms from any DataMiner Agent on its cluster will be send through the DataMiner Agent that you've chosen. To configure this DataMiner Agent, in the *Skyline DataMiner* root folder (*C:\Skyline DataMiner*):

1. Open the *DataMiner.xml* file

1. Add the *\<SNMP port="461"/\>* tag to the file, so it is located between the *\<DataMiner id=".\>* and *\</DataMiner\>* tag.

1. Save the *DataMiner.xml* file

1. Restart the DataMiner

Now that we have configured the **SNMP Port** of the DataMiner Agent that will be used for the communication between clusters, we also need its **IP Address**. To retrieve the DataMiner agent's IP Address, in **System Display**:

1. In the **Menu**, go to *Admin* -\> *DataMiner Agents*

1. The IP Address of the DataMiner Agent can be found in the **DataMiner Configuration** pane (e.g. "*10.12.0.158*").

The configured SNMP Port and the IP Address of the DataMiner Agent will be used in the configuration of the **DataMiner Element** that will receive the cluster's active alarms, so make sure you remember them.

### Configuring the SNMP Manager

On the **DataMiner Agent** in the cluster that you have chosen for the communication between clusters, you need to configure a **SNMP Manager**. To configure the SNMP Manager, in **System Display**:

1. Go to the top menu and choose *Advanced* -\> *SNMP Managers.*

1. In the title bar of the SNMP Managers section, click *New*.

1. On the first page of the **New SNMP Manager Wizard**, click *Next*.

1. On the second page, specify the following properties, and click *Next*.

   - **Name**: The name of the SNMP manager (e.g. "*Core Snmp Manager*"). This name is needed for the configuration of the DataMiner Element that will receive the active alarms from the cluster. Make sure you remember it!

   - **IP Address**: The IP address of the SNMP manager, i.e. the address to which the SNMP traps will be sent. In this case this will be the IP Address of the DataMiner Agent of the other cluster on which the DataMiner Element is configured that will receive the active alarms.

   - **Community String**: The community string to be used in all SNMP traps toward the SNMP manager you are configuring (e.g. "*public*").

   - **SNMP Version**: Select the *Inform messages* option. By selecting this option, you also need to specify the following settings:

      - **Resend:** The period of time DataMiner will wait for an acknowledgement after sending an Inform.

      - **Resend max:** The maximum number of times DataMiner will send the same inform if it doesn't receive an acknowledgement. After a DMA has tried to send an Inform message for the specified maximum number of times, a timeout will occur, which will subsequently force the DMA to switch to a so-called 'ping mode'. As soon as the DMA receives its first acknowledgement from the SNMP manager, it will stop sending ping messages and send an Inform message for every active alarm in the DMS. Once that is done, it will resume 'normal mode'. In other words, every time it receives a new alarm, it will send an Inform message to the SNMP manager.

        > [!NOTE]
        >
        > - A so-called ping message is an alarm with parameter ID 64622 containing the value "PING".
        > - Select the *Send in chronological order* option if you want the inform messages to be sent in chronological order. If you select this option, each time an inform message is sent to a particular SNMP manager, the latter will have to reply with ACK before the next inform message is sent.

1. On the third page, specify the following properties, and click *Next*.

   - **Custom Trap Description:** The trap description that will appear in the default "trap description" binding.

   - **Resend all active alarms every:** If you want SNMP traps for active Alarms to be re-sent at regular intervals, select this option, and specify an interval.

   - **Send all traps via one DataMiner:** Select this option so that all SNMP traps towards the SNMP Manager are channeled through one particular DataMiner. Make sure you select the DataMiner Agent from the list on which you are configuring the SNMP Manager.

   - **Enable the forwarding of traps:** Select this option so that the sending of SNMP traps is activated.

   - **Use device specific OID:** Do NOT select this option.

   - **Support international characters (Unicode):** If the traps will contain international characters, select this option.

   - **Custom trap binding:** Click this button to open the *Custom Trap Bindings* dialog box and make sure you configure them as described:

     - Select the option *Use custom Trap Bindings with Oid*.

     - In the text field, insert the following: *1.1*

     - In the Trap Bindings table, make sure all trap binding are deleted. After this, add the following Trap Bindings so that they are ordered in the following :

       - Position 0 -\> *Element Id*

       - Position 1 -\> *Protocol name*

       - Position 2 -\> *laParameterName*

       - Position 3 -\> *Table index*

       - Position 4 -\> *laSeverity*

       - Position 5 -\> the property you need of the alarms (e.g., *ElementType*)

       - Position 6 -\> *laAlarmType*

       - Position *7 -\>* *laValue*

     - Click *OK* to apply the Custom Trap Bindings.

   - **Advanced:** Click this button to open the *Advanced* dialog box, which contains the following settings.

      - **Custom OID during resend:** In this box, enter the following OID that will be used when resending SNMP traps: *1.3.6.1.4.1.8813.1.1.2.3.2.1*

      - **Custom OID for the ping traps:** In this box, enter the following OID that will be used when sending so-called "ping traps" at the beginning and end of an SNMP manager synchronization/resend process: *1.3.6.1.4.1.8813.1.1.2.3.2.2*

      - **Send an extra starting ping trap during resend:** Select this option so that every resend cycle will start with a so-called "ping trap".

      - **Send an extra ending ping trap during resend:** Select this option so that every resend cycle will end with a so-called "ping trap".

      - Click *Close* to apply Advanced settings.

1. On the fourth page, select the necessary Alarm filters, and click *Next*. By selecting Alarm filters, you can tell DataMiner for which Alarms it should forward SNMP Traps toward the SNMP manager you are configuring.

1. On the fifth page, make sure the *Alarmstorm prevention* option is NOT selected, and click *Next*.

1. On the sixth and last page, click *Finish*.

**Note:** By default, DataMiner will forward SNMP Traps to all enabled SNMP managers (using a separate thread per SNMP manager). If, in the list, the check box in front of an SNMP manager is selected, this means that the SNMP manager is enabled.

### Configuring the Windows Firewall

The SNMP Port that was configured on the DataMiner Agent needs to be added to the Windows Firewall so that communication between clusters is possible. To enable the SNMP Port:

1. In Windows, go to *Windows Firewall* (Control Panel -\> Windows Firewall) and choose *Advanced settings*.

1. When right-clicking *Inbound Rules*, choose *New Rule*.

1. Configure the new rule as described:

   - **Rule Type:** *Port*

   - **Protocol and Ports:**

     - **TCP or UDP:** Select *UDP.*
     - **Specific local ports:** Enter the SNMP Port number that was configured (e.g. "*461*").
     - Click *Next*

   - **Action:** Make sure you select the correct connection that matches your system specified conditions (e.g., "*Allow the connection***"**) and click *Next***.**

   - **Profile:** Select the options that apply to your system conditions and click *Next*.

   - **Name:** Enter a name and/or description for the specified rule and click *Finish*.

### Configuring the DataMiner Element

After successfully having configured the DataMiner Agent on the cluster that will send the cluster's active alarms and its SNMP Manager, it's time to configure the **DataMiner Element** that will receive the SNMP traps and by so the active alarms.

When creating the DataMiner Element, you must specify the following properties:

- **Name:** The name, which must be unique, that will be given to the DataMiner Element you are configuring.

- **Protocol:** Select the *VOO DMS Collector* protocol.

- **Version:** Select the correct version of the protocol you want to apply to the DataMiner Element.

- **SNMP Connection:** This SNMP connection contains the settings which are needed for the communication between the DataMiner Element and the cluster from which you wish to receive the active alarms.

  - **IP address/host:** The IP address of the **DataMiner Agent** you selected on the cluster that's responsible for the communication between clusters (e.g. "*10.12.0.158*").

  - **Device address:** The name of the **SNMP Manager**, which is configured on the cluster's DataMiner Agent that's responsible for the communication between clusters (e.g. "*Core Snmp Manager*").

  - **More SNMP settings:** In the **Port number** text field, make sure you enter the SNMP Port number that you've configured on the cluster's DataMiner Agent which is responsible for the communication between clusters (e.g. "*461*").

## Usage

The DataMiner exists of different pages, which are describe below.

### Cluster Information

This page contains the following details.

- **IP Address:** The IP Address and SNMP Port of the cluster's DataMiner Agent which is configured for the sending of the active alarms towards the DataMiner Element.

- **SNMP Manager:** The name of the SNMP Manager configured on the related cluster's DataMiner Agent.

- **Resend Button:** When clicking this button, the resend operation of all the active alarms is triggered for the defined cluster.

- **Connection State**

  - **Valid:** There are no connection issues between clusters.

  - **Connection Lost**: A ping cycle is started until a valid connection is established.

- **Resend State**

  - **Retrieving Alarms:** The DataMiner Element is collecting the resend, active alarms from the related cluster.

  - **Complete:** The resend operation is finished and the DataMiner Element has collected all the active alarms from the related cluster. The alarms will be forwarded to all the DataMiner Elements which were provided by the DataMiner Element running the **VOO CPE Manager** protocol.

### CPE Information

This page provides a table containing all the DataMiner Elements that were provided by the DataMiner Element using the **VOO CPE Manager** protocol. All alarms that were collected, will be forwarded to every DataMiner Element that was provided.

## Trending

This connector is provided with the trending possibility so that the **Resend State** for the related cluster can be followed.
