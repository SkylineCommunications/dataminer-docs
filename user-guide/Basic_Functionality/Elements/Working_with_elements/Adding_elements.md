---
uid: Adding_elements
---

# Adding elements

1. Right-click in the Surveyor, and select *New \> Element*.

   A card will open.

   > [!NOTE]
   > Alternatively, you can also create an element via the Protocols & Templates module, immediately assigning the appropriate protocol and templates. To do so, in the Protocols & Templates module, select a particular protocol, protocol version, alarm template and trend template, right-click in the *Elements* column and select *New element*.

1. In the *Edit* tab of the card, if you want the element to be a replica of an element on another DataMiner System, select the *Replicate* checkbox. To create a regular element, leave the box clear.

   See [Replicating elements](xref:Replicating_elements) for more information.

1. Specify the following information:

   - **Name**: The name of the element.

     > [!NOTE]
     >
     > - The name of the element can be changed at any time. The element is uniquely identified by its ID, which is a combination of the DMA ID of the DMA where the element is originally created and the ID of the element itself.
     > - If you change the element name, make sure the new name provides clear information to the DMS operators. See [Naming of elements, services, views, etc.](xref:NamingConventions#naming-of-elements-services-views-etc).

   - **Description**: A brief description of the element.

   - **DMA**: The DMA responsible for the polling.

   - **Protocol**: The name of the protocol via which the DMA will be communicating with the element.

     This selection box contains all DMS protocols available in the DMS. If you do not find the protocol you need, you will first have to add it. See [Protocols and Templates](xref:protocols#protocols-and-templates).

   - **Version**: The version of the protocol via which the DMA will be communicating with the element.

     This selection box lists all available versions of the protocol you selected in the *Protocol* box.

   - **Alarm template**: The name of the alarm template that contains the alarm thresholds to be used while monitoring the element.

     This selection box lists:

     - The option to add a new alarm template with *\<Add alarm template>*.

       If you select this option, you will be able to create an alarm template in the same way as in the Protocols & Templates module, but embedded within the element editor. For more information, see [Creating an alarm template](xref:Creating_an_alarm_template).

     - The default alarm template called *\<No Monitoring>*.

     - All alarm templates that have been associated with the protocol and protocol version you selected.

   - **Trend template**: The name of the trend template that determines which trend data will be stored in the database for the element.

     This selection box lists:

     - The option to add a new trend template with *\<Add trend template>*.

       If you select this option, you will be able to create a trend template in the same way as in the Protocols & Templates module, but embedded within the element editor. For more information, see [Creating a trend template](xref:Adding_and_deleting_trend_templates#creating-a-trend-template).

     - The default trend template called *\<No Trending>*.

     - All trend templates that have been associated with the protocol and protocol version you selected.

   > [!NOTE]
   > In some fields, a default value may be filled in. If you have deleted this default value, you can still see what it was by removing all data from the field. The default value will then be shown in the tooltip.

1. Depending on the protocol you have chosen, more connection settings may need to be specified:

   - For an **SNMPv1/v2** connection, see [SNMPv1/v2 connection](xref:SNMPv1v2_Connection).

   - For an **SNMPv3** connection, see [SNMPv3 connection](xref:SNMPv3_Connection).

   - For an **HTTP(S)** connection, see [HTTP(S) connection](xref:HTTPS_Connection).

   - For a **serial** connection, see [Serial connection](xref:Serial_Connection).

   - For a **smart-serial** connection, see [Smart-serial connection](xref:Smart_Serial_Connection).

   - For a **TCP/IP** or **UDP/IP** connection, see [TCP/IP and UDP/IP connections](xref:TCPIP_UDPIP_Connection).

   - For a **GPIB** connection, see [GPIB connections](xref:GPIB_Connection).

     > [!TIP]
     > See also: [Installation and configuration of a spectrum analyzer](xref:Installation_and_configuration_of_a_spectrum_analyzer)

   - For a **WebSocket** connection (available from DataMiner 9.5.3 onwards), see [WebSocket connection](xref:WebSocket_Connection).

1. If the protocol is configured to allow you to test the connections, optionally click the button *Test connection* below any connections you want to test.

   After you click the button, a message will display the results of the test.

   > [!NOTE]
   > Feature introduced in DataMiner 9.5.7. However, testing SNMPv3 connections is only possible from DataMiner 9.5.12 onwards.

1. Specify the timeout settings per connection:

   - **Timeout of a single command (ms)**: The period (in milliseconds) during which a DMA will wait for a response after sending a command to the element. This period must be between 10 and 120 000 ms. If there is no response within the specified period, the DMA will send the same command again.

     > [!NOTE]
     > In some cases, the protocol can be designed to make a DMA wait longer for a response when it has sent a particular command.

   - **Number of retries**: The total number of times a DMA is allowed to send the same command again in case it does not receive a response. This number must be between 0 and 10. If, after sending the command the indicated number of times, the DMA still has not received a response from the element, it will move on and continue with the next command to be executed.

   - **Include timeout**: The element will go into timeout state if this connection times out.

     > [!NOTE]
     >
     > - Clearing the selection from this checkbox can for example be of use for an element with multiple connections. If a particular connection should not influence the timeout state of the element, then clear the checkbox for that connection. If the checkbox is selected for all connections, the element will be in timeout as soon as one of the connections fails.
     > - Prior to DataMiner 10.2.9/10.3.0, the maximum timeout value for this setting is 2 minutes (i.e. 120 seconds). From DataMiner 10.2.9/10.3.0 onwards, the maximum value is extended to 24 hours.

1. Specify the following advanced element settings if necessary:

   - **The element goes into timeout state when it is not responding for (sec)**: When the element fails to respond to commands for longer than the number of seconds specified in this setting, the DMA will put the element in a timeout state. The specified number must be between 0 and 120.

   - **Slow poll settings**: When an element is in a timeout state, the DMA can force it to go into so-called slow poll mode. While the element is in that special poll mode, the DMA will not send any commands to the element. Instead, it will just send a protocol-dependent ping command at regular intervals. As soon as the element responds to that ping command, the DMA will start polling the element the normal way again.

     Slow poll mode prevents daisy-chained elements from locking up as it keeps DMAs from continuously polling elements that are powered down, broken or disconnected.

     To enable slow polling in case of a timeout, select the *Slow poll settings* checkbox and specify the following two settings.

     - **The element ... after**: This setting determines when the element will go into slow poll mode:

       - after a fixed number of seconds (between 1 and 300), or
       - after having been put in a timeout state for a specific number of times (between 1 and 500).

     - **Ping interval**: The interval (in seconds) between two ping commands. This must be between 1 and 300 seconds.

     > [!WARNING]
     > Proceed with extreme caution when changing these settings. They can have a large impact on the communication between the DMA and the element and could, in the worst case, cause communication interruptions or failure.

     > [!NOTE]
     > Which ping command is used by DataMiner depends on the protocol configuration. See [Ping group](xref:ConnectionsPingGroup).

   - **Enable SNMP agent**: Select this checkbox and specify the virtual IP address and subnet mask in order to be able to send SNMP Get and Set commands to the virtual IP address of the element.

     > [!TIP]
     > See also:
     >
     > - [Enabling the virtual SNMP agent of an element](xref:Enabling_the_virtual_SNMP_agent_of_an_element)
     > - [Forcing a DataMiner Agent to work without virtual IP addresses](xref:Forcing_a_DMA_to_work_without_virtual_IPs)

   - **Hidden**: Select this checkbox if you want the element to be hidden.

   - **Read-only**: Select this checkbox if you want the element to be read-only.

     If an element is read-only, its parameters cannot be updated.

   - **Element state**: Select the initial state of the element in this selection box. By default this will be set to “Active”.

1. Click *Next* and specify the view(s) to which you want to link the element.

1. Click *Next* and specify the value for any available custom properties if necessary.

1. Click *Create* to add the element.

   > [!NOTE]
   > If any required information is missing or incorrect, the *Create* button will be disabled, and the label of the field where information is missing or incorrect will be displayed in red.

> [!TIP]
> See also: [Locating devices in your system to add to your DMS](xref:Locating_devices_in_your_system_to_add_to_your_DMS)
