---
uid: Adding_and_deleting_elements
---

## Adding and deleting elements

In this section:

- [Adding an element](#adding-an-element)

- [Duplicating an element](#duplicating-an-element)

- [Deleting an element](#deleting-an-element)

### Adding an element

1. Right-click in the Surveyor, and select *New \> Element*.

    A card will open.

    > [!NOTE]
    > Alternatively, you can also create an element via the Protocols & Templates module, immediately assigning the appropriate protocol and templates. To do so, in the Protocols & Templates module, select a particular protocol, protocol version, alarm template and trend template, right-click in the *Elements* column and select *New element*.

2. In the *Edit* tab of the card, if you want the element to be a replica of an element on another DataMiner System, select the *Replicate* checkbox. To create a regular element, leave the box clear.

    See [Replicating elements](Replicating_elements.md) for more information.

3. Specify the following information:

    - **Name**: The name of the element.

        > [!NOTE]
        > - The name of the element can be changed at any time. The element is uniquely identified by its ID, which is a combination of the DMA ID of the DMA where the element is originally created and the ID of the element itself.
        > - If you change the element name, make sure the new name provides clear information to the DMS operators. See [Naming of elements, services, views, etc.](../../part_7/NamingConventions/NamingConventions.md#naming-of-elements-services-views-etc).

    - **Description**: A brief description of the element.

    - **DMA**: The DMA responsible for the polling.

    - **Protocol**: The name of the protocol via which the DMA will be communicating with the element.

        This selection box contains all DMS protocols available in the DMS. If you do not find the protocol you need, you will first have to add it. See [Protocols and Templates](../protocols/protocols.md#protocols-and-templates).

    - **Version**: The version of the protocol via which the DMA will be communicating with the element.

        This selection box lists all available versions of the protocol you selected in the *Protocol* box.

    - **Alarm template**: The name of the alarm template that contains the alarm thresholds to be used while monitoring the element.

        This selection box lists:

        - The option to add a new alarm template with *\<Add alarm template>*.

            If you select this option, you will be able to create an alarm template in the same way as in the Protocols & Templates module, but embedded within the element editor. For more information, see [Creating an alarm template](../protocols/Managing_alarm_templates.md#creating-an-alarm-template).

        - The default alarm template called *\<No Monitoring>*.

        - All alarm templates that have been associated with the protocol and protocol version you selected.

    - **Trend template**: The name of the trend template that determines which trend data will be stored in the database for the element.

        This selection box lists:

        - The option to add a new trend template with *\<Add trend template>*.

            If you select this option, you will be able to create a trend template in the same way as in the Protocols & Templates module, but embedded within the element editor. For more information, see [Creating a trend template](../protocols/Adding_and_deleting_trend_templates.md#creating-a-trend-template).

        - The default trend template called *\<No Trending>*.

        - All trend templates that have been associated with the protocol and protocol version you selected.

    > [!NOTE]
    > In some fields, a default value may be filled in. If you have deleted this default value, you can still see what it was by removing all data from the field. The default value will then be shown in the tooltip.

4. Depending on the protocol you have chosen, more connection settings may need to be specified:

    - For an **SNMPv1/v2** connection:

        - **SNMP version**: Allows you to select a different SNMP version than the version configured in the protocol. With an SNMPv1 type protocol, you can select SNMPv1, SNMPv2 or SNMPv3. With an SNMPv2 type protocol, you can select SNMPv2 or SNMPv3.

            > [!NOTE]
            > When you downgrade to a DataMiner version prior to 9.5.3, any element with an SNMPv1 protocol that has been set to SNMPv3 will need to be reconfigured with an SNMPv3 version of the protocol to work correctly.

        - **IP address/host**: The polling IP or URL of the destination.

        - **Network**: The network interface (NIC). If only one network interface is available on the DMA, it is automatically selected.

        - **Port number**: By default 161.

        - **Use credentials**: From DataMiner 9.5.5 onwards, if predefined credentials have been made available for your user account, you can select this checkbox to select a set of predefined SNMP credentials. See also: [Managing predefined sets of credentials for SNMP authentication](../../part_3/security/Managing_predefined_sets_of_credentials_for_SNMP_authentication.md).

        - **Get community string**: The community string used when reading values from the device. The default value, unless overridden in the protocol, is *public*.

        - **Set community string**: The community string used when setting values on the device. The default value, unless overridden in the protocol, is *private*.

    - For an **SNMPv3** connection:

        - **SNMP version**: Allows you to select a different SNMP version than the version configured in the protocol. With an SNMPv3 type protocol, you can select SNMPv2 or SNMPv3.

        - **IP address/host**: The polling IP or URL of the destination.

        - **Network**: The network interface (NIC). If only one network interface is available on the DMA, it is automatically selected.

        - **Port number**: By default 161.

        - **Use credentials**: From DataMiner 9.5.5 onwards, if predefined credentials have been made available for your user account, you can select this checkbox to select a set of predefined SNMP credentials. See also: [Managing predefined sets of credentials for SNMP authentication](../../part_3/security/Managing_predefined_sets_of_credentials_for_SNMP_authentication.md).

        - **Security level and protocol**: Select one of the following three levels in the drop-down list:

            - *noAuthNoPriv*: No authentication and no privacy, which is essentially the same as SNMPv2.

            - *authNoPriv*: Authentication without privacy. This means that authentication is required, but data is not encrypted. If this value is chosen, an encryption password is not necessary.

            - *authPriv*: Authentication with privacy. This means that both authentication is required and data is encrypted, so that both the authentication password and the encryption password must be filled in.

        - **User name**: Always needs to be specified, regardless of the selected security level and protocol.

        - **Authentication password**: Not required if *noAuthNoPriv* is selected.

        - **Encryption password**: Only required if *authPriv* is selected.

        - **Authentication algorithm**: Not available if *NoAuth_NoPriv* is selected. Up to DataMiner 9.6.11, either *HMAC-SHA* or *HMAC-MD5*. From DataMiner 9.6.12 onwards, you can choose between *MD5*, *SHA-1*, *SHA-224*, *SHA-256*, *SHA-384* and *SHA-512*.

        - **Encryption algorithm**: Only available if *Auth_Priv* is selected. Up to DataMiner 9.6.11, either *DES* or *AES128*. From DataMiner 9.6.12 onwards, you can choose between *AES-128*, *AES-192*, *AES-256* and *DES*.

        > [!NOTE]
        > The following combinations of authentication and encryption algorithm are not supported:
        > - MD5/SHA-1 and AES192
        > - MD5/SHA-1/SHA-224 and AES256
        >
        > We recommend to use SHA-512 and AES-256, since this is the most secure combination. As such, this is the combination that is selected by default.

    - For an **HTTP(S)** connection:

        - **IP address/host**: The polling IP or URL of the destination.

        - **IP port**: The IP port of the destination. This is not always required. <br>The default port for HTTPS communication is 443. If you specify a different port, also add the *https://* prefix in the IP address field.

        - **Bus address**: The bus address of the device. This is not always required. If the proxy server has to be bypassed, specify *bypassproxy*.

        - **Network**: The network interface (NIC). If only one network interface is available on the DMA, it is automatically selected.

    - For a **serial** connection:

        - **Baud rate**: The baudrate specified in the manual of the device, e.g. *9600*.

        - **Databits**: The databits specified in the manual of the device, e.g. *7*.

        - **Stopbits**: The stopbits specified in the manual of the device, e.g. *1*.

        - **Parity**: The parity specified in the manual of the device, e.g. *No*.

        - **Flow control**: The flow control specified in the manual of the device, e.g. *No*.

        - **Serial port**: The serial port of the DMA that should be used. If only one port is available, it is automatically selected.

    - For a **smart-serial** connection:

        - **IP address/host**: The polling IP or URL of the destination.

            - In a Failover setup, instead of specifying the local IP address, use 127.0.0.1.

            - If you specify “any” as the host address, DataMiner listens on all IP addresses on the specified port.

        - **IP port**: The IP port of the destination. This is not always required.

        - **Accepted IP address**: Available from DataMiner 9.6.13 onwards, if a smart-serial server port of type TCP is used. Allows you to specify one or more allowed IP addresses for the connection. The element will then only communicate with those IP addresses. This configuration makes it possible for several elements to listen on the same port but communicate exclusively with a different set of IPs.

            To add an additional accepted IP address, below the box, click *Add*.

            > [!NOTE]
            > This functionality is only available if *AllowedIPAddresses.Disabled* is set to “false” in the user settings of the smart-serial connection in the protocol.

        - **Bus address**: The bus address of the device. This is not always required.

        - **Network**: The network interface (NIC). If only one network interface is available on the DMA, it is automatically selected.

    - For a **TCP/IP** or **UDP/IP** connection:

        - **IP address/host**: The polling IP or URL of the destination.

        - **IP port**: The IP port of the destination. This is not always required.

        - **Bus address**: The bus address of the device. This is not always required.

        - **Network**: The network interface (NIC). If only one network interface is available on the DMA, it is automatically selected.

        - **SSL/TLS**: Select this checkbox to enable SSL/TLS encryption (for TCP/IP connections only).

            > [!NOTE]
            > - TLS elements and non-TLS elements sharing the same TCP/IP port is not supported.
            > - This feature is supported from DataMiner 10.0.2 onwards for smart-serial elements acting as server. However, note that the system must be configured to support this encryption. See [Enabling TLS encryption](../../part_3/security/Enabling_TLS_encryption.md).
            > - From DataMiner 10.0.3 onwards, this feature is also supported in case DataMiner acts as the serial client. No further configuration is required in this case.

    - For a **GPIB** connection, see [Configuring the GPIB settings of a spectrum analyzer element](../../part_4/SpectrumAnalysis/Configuring_the_GPIB_settings_of_a_spectrum_analyzer_element.md).

    - For a **WebSocket** connection (available from DataMiner 9.5.3 onwards):

        - **IP address/host**: The polling IP or URL of the destination.

        - **IP port**: The IP port of the destination. This is not always required.

        - **Bus address**: The bus address of the device. This is not always required. If the proxy server has to be bypassed, specify *bypassproxy*.

        - **Network**: The network interface (NIC). If only one network interface is available on the DMA, it is automatically selected.

5. If the protocol is configured to allow you to test the connections, optionally click the button *Test connection* below any connections you want to test.

    After you click the button, a message will display the results of the test.

    > [!NOTE]
    > Feature introduced in DataMiner 9.5.7. However, testing SNMPv3 connections is only possible from DataMiner 9.5.12 onwards.

6. Specify the timeout settings per connection:

    - **Timeout of a single command (ms)**: The period (in milliseconds) during which a DMA will wait for a response after sending a command to the element. This period must be between 10 and 120 000 ms. If there is no response within the specified period, the DMA will send the same command again.

        > [!NOTE]
        > In some cases, the protocol can be designed to make a DMA wait longer for a response when it has sent a particular command.

    - **Number of retries**: The total number of times a DMA is allowed to send the same command again in case it does not receive a response. This number must be between 0 and 10. If, after sending the command the indicated number of times, the DMA still has not received a response from the element, it will move on and continue with the next command to be executed.

    - **Include timeout**: The element will go into timeout state if this connection times out.

        > [!NOTE]
        > Clearing the selection from this checkbox can for example be of use for an element with multiple connections. If a particular connection should not influence the timeout state of the element, then clear the checkbox for that connection. If the checkbox is selected for all connections, the element will be in timeout as soon as one of the connections fails.

7. Specify the following advanced element settings if necessary:

    - **The element goes into timeout state when it is not responding for (sec)**: When the element fails to respond to commands for longer than the number of seconds specified in this setting, the DMA will put the element in a timeout state. The specified number must be between 0 and 120.

    - **Slow poll settings**: When an element is in a timeout state, the DMA can force it to go into so-called slow poll mode. While the element is in that special poll mode, the DMA will not send any commands to the element. Instead, it will just send a protocol-dependent ping command at regular intervals. As soon as the element responds to that ping command, the DMA will start polling the element the normal way again.

        Slow poll mode prevents daisy-chained elements from locking up as it keeps DMAs from continuously polling elements that are powered down, broken or disconnected.

        To enable slow polling in case of a timeout, select the *Slow poll settings* checkbox and specify the following two settings.

        | Setting             | Description                                                                                                                                                                                                                                                                                                                                                            |
        |-----------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
        | The element ... after | This setting determines when the element will go into slow poll mode:<br> -  after a fixed number of seconds (between 1 and 300), or<br> -  after having been put in a timeout state for a specific number of times (between 1 and 500). |
        | Ping interval         | The interval (in seconds) between two ping commands. This must be between 1 and 300 seconds.                                                                                                                                                                                                                                                                           |

        > [!WARNING]
        > Proceed with extreme caution when changing these settings. They can have a large impact on the communications between the DMA and the element and could, in the worst case, cause communication interruptions or failure.

        > [!NOTE]
        > Which ping command is used by DataMiner depends on the protocol configuration. For more information, refer to the information on ping groups in the [DataMiner Development Library](https://help.dataminer.services/development/).

    - **Enable SNMP agent**: Select this checkbox and specify the virtual IP address and subnet mask in order to be able to send SNMP Get and Set commands to the virtual IP address of the element.

        > [!TIP]
        > See also:
        > - [Enabling the virtual SNMP agent of an element](../../part_3/SNMP/Enabling_the_virtual_SNMP_agent_of_an_element.md)
        > - [Forcing a DataMiner Agent to work without virtual IP addresses](../../part_3/DataminerAgents/General_DMA_configuration.md#forcing-a-dataminer-agent-to-work-without-virtual-ip-addresses)

    - **Hidden**: Select this checkbox if you want the element to be hidden.

    - **Read-only**: Select this checkbox if you want the element to be read-only.

        If an element is read-only, its parameters cannot be updated.

    - **Element state**: Select the initial state of the element in this selection box. By default this will be set to “Active”.

8. Click *Next* and specify the view(s) to which you want to link the element.

9. Click *Next* and specify the value for any available custom properties if necessary.

10. Click *Create* to add the element.

    > [!NOTE]
    > If any required information is missing or incorrect, the *Create* button will be disabled, and the label of the field where information is missing or incorrect will be displayed in red.

> [!TIP]
> See also:
> [Locating devices in your system to add to your DMS](Locating_devices_in_your_system_to_add_to_your_DMS.md)

### Duplicating an element

To quickly add an element that is very similar to an existing element, you can duplicate that existing element:

1. Right-click the element in the Surveyor, and select *Duplicate*.

    A card appears, similar to when you create a new element, except that it already contains the information from the element you duplicated.

2. Make the necessary changes in the card, and click *Create*.

> [!NOTE]
> When you duplicate an SNMPv3 from another DMA, you will need to enter the SNMPv3 credentials again for the element to work.

### Deleting an element

1. Right-click the element in the Surveyor, and select *Delete*.

2. In the confirmation box, click *Yes*.

> [!NOTE]
> Some elements may be created by a different parent element. In that case, deleting these elements may not be possible, except by an Administrator, or via the parent element.
>
