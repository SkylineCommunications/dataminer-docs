---
uid: Configuring_an_SNMP_manager_in_DataMiner_Cube
---

# Configuring an SNMP manager in DataMiner Cube

1. In DataMiner Cube, go to *Apps* > *System Center* \> *SNMP Forwarding*.

1. To configure a new SNMP manager, at the bottom of the page, click the *New* button.

   A new SNMP manager is added to the *SNMP managers* list, and in the pane on the right, five tabs with configuration options become available.

   If the SNMP manager you want to configure already exists, simply select it in the *SNMP managers* list.

1. In the *general* tab, specify the following properties, and click *Next*.

   - **Name**: The name of the SNMP manager (e.g. “HP OpenView”, “IBM Tivoli Netcool”, etc.).

   - **IP address**: The IP address of the SNMP manager, i.e. the address to which the SNMP notifications will be sent.

   - **Get community string**: The community string to be used in all SNMP notifications toward the SNMP manager you are configuring.

   - **Custom notification description**: The notification description that will appear in the default “trap description” binding.

   - **SNMP version**: The SNMP version: *SNMPv1*, *SNMPv2* (default), or *SNMPv3*.

   - **Notification type**: By default, this is set to *Trap*. If you want the receiver of the notifications to acknowledge every SNMP packet sent by DataMiner, select *Inform messages*. However, note that this is not supported for SNMPv1.

   - **Send all notifications via one DMA**: If you want all SNMP notifications toward the SNMP manager to be channeled through one particular DataMiner Agent, select this option, and select a DataMiner Agent from the list.

   - **Port number**: The destination port of the SNMP manager. By default, this is set to 162.

1. For *SNMPv3* only, an extra section will become available at the bottom of the *general* tab. In this section, specify the username, and the authentication and encryption password if necessary. In the expandable *Advanced* section, specify the following further options:

   - **Security level and protocol**: Select one of the following three levels in the drop-down list:

     - *NoAuth_NoPriv*: No authentication and no privacy, which is essentially the same as SNMPv2.

     - *Auth_NoPriv*: Authentication without privacy. This means that authentication is required, but data is not encrypted. If this value is chosen, an encryption password is not necessary.

     - *Auth_Priv*: Authentication with privacy. This means that both authentication is required and data is encrypted, so that both the authentication password and the encryption password must be filled in.

   - **Context name**: The name that identifies the specific context. This field can be left empty.

   - **Context engine ID**: A hexadecimal string of maximum 64 characters. If left empty, DataMiner will automatically generate an ID.

   - **Authoritative engine ID**: A hexadecimal string of maximum 64 characters. If left empty, DataMiner will automatically generate an ID.

   - **Authentication algorithm**: Not available if *NoAuth_NoPriv* is selected. Up to DataMiner 9.6.11, either *HMAC-SHA* or *HMAC-MD5*. From DataMiner 9.6.12 onwards, you can choose between *MD5*, *SHA-1*28, *SHA-224*, *SHA-256*, *SHA-384* and *SHA-512*.

   - **Encryption algorithm**: Only available if *Auth_Priv* is selected. Up to DataMiner 9.6.11, either *DES* or *AES128*. From DataMiner 9.6.12 onwards, you can choose between *AES-128*, *AES-192*, *AES-256* and *DES*.

   > [!NOTE]
   > The following combinations of authentication and encryption algorithm are not supported:
   >
   > - MD5/SHA128 and AES192
   > - MD5/SHA128/SHA224 and AES256
   >
   > We recommend that you use SHA-512 and AES-256, since this is the most secure combination.

1. Prior to DataMiner 10.0.0 CU11/10.1.3 only: In the *General* section of the *notification* tab, make sure *Support international characters (Unicode)* is selected if the notifications will contain international characters.

1. From DataMiner 10.0.0 CU11/10.1.3 onwards: At the top of the *notification* tab, select a different encoding type if necessary.

1. In the *OID* section of the *notification* tab, specify the following options, depending on the SNMP version selected in the *general* tab:

   - For SNMPv1:

     - **Use device-specific OID**: If you select this option, the enterprise OID of the notification will be different for every type of element (depending on the protocol).

     - **Use 1.3.6.1.4.1.8813.pid (parameter ID)**: Select this option to send notifications containing the Skyline OID, using the parameter ID as notification-specific ID.

   - For SNMPv2 and SNMPv3:

     - **Default (1.3.6.1.4.1.8813.0.3)**: Select this option to use the default OID.

     - **Use device-specific OID**: If you select this option, the enterprise OID of the notification will be different for every type of element (depending on the protocol).

     - **Use custom bindings with OID: ...**: Select this option to use custom bindings.

     - **Custom bindings**: To configure custom bindings, use the *Add*, *Delete*, *Up* and *Down* buttons in this section.

   > [!NOTE]
   >
   > - Custom bindings cannot be used if you use the default OID.
   > - For more information on custom bindings, see [Custom DataMiner notification](xref:Custom_DataMiner_notification).
   > - If custom bindings are used, it is possible to export a MIB file for the SNMP manager. From DataMiner 10.0.10 onwards, click the *Generate MIB file* button below the custom bindings to do so. In DataMiner 10.0.9, use the SLNetClientTest tool to do so (see [Generating SMIv2 MIB files](xref:SLNetClientTest_generating_mib_files)).

1. In the *resend* tab, specify the following options:

   - Regardless of the notification type:

     - **Resend all active alarms every ...**: If you want SNMP notifications for active alarms to be resent at regular intervals, select this option, and specify an interval. The default interval is 30 seconds.

     - **Custom OID during resend**: In this box, you can enter a custom OID to be used when resending notifications to an SNMP manager.

     - **Custom OID for the ping notifications**: In this box, you can enter a custom OID to be used when sending ping notifications at the beginning and/or at the end of an SNMP manager synchronization/resend process.

     - **Send an extra starting ping notification during resend**: Select this option if every resend cycle has to start with a ping notification.

     - **Send an extra ending ping notification during resend**: Select this option if every resend cycle has to end with a ping notification.

     > [!NOTE]
     > You may need to expand the *Advanced* section to see some of these options.

   - In addition, for notification type “Inform messages” only:

     - **Retry every ...**:** The period of time DataMiner will wait for an acknowledgment after sending an inform message.

     - **Max retries**: The maximum number of times DataMiner will send the same inform if it does not receive an acknowledgment. After a DMA has tried to send an inform message for the specified maximum number of times, a timeout will occur. This will force the DMA to switch to ping mode. As soon as the DMA receives its first acknowledgment from the SNMP manager, it will stop sending ping messages and send an inform message for every active alarm in the DMS. Once that is done, it will resume its normal mode.

     - **Send in chronological order**: Select this option to have inform messages sent in chronological order. In that case, each time an inform message is sent to a particular SNMP manager, the latter will have to reply with ACK before the next inform message is sent.

1. Click *Next* to go the *filter* tab, and specify any alarm filters if necessary. These alarm filters will limit the alarms for which SNMP notifications will be forwarded to the SNMP manager you are configuring.

   - To add one or more existing filters from the DMS:

     1. Click *Add filter* and select *Saved filters*.

     1. Click *\<Click to select>* to select an existing filter.

     1. If necessary, click *Is* and select one of the other options in order to determine how the filter should be applied.

     1. If necessary, click *Add filter* again to add more filters, combined with logical operators.

   - To create a new filter, which can then be added in the same way as an existing filter:

     1. Click *New filter*.

     1. In the *Name* box, enter a name for the alarm filter.

     1. In the *Type* drop-down list, select whether the alarm filter should be *Public*, so any users are able to update it, or *Protected*.

     1. Optionally, add a description for the filter in the *Description* box.

     1. Click *Select a filter*, and select what you want to filter on, e.g. Alarm type, Service impact, etc.

     1. Select a logical operator, and then click *\<Click to select>* to select one or more values to combine it with.

     1. If necessary, click *Is* and select one of the other options in order to determine how the filter should be applied.

     1. If necessary, click *Add filter* again to add more filters, combined with logical operators.

     1. When the filter is fully configured, click *OK*.

   > [!NOTE]
   > To check whether a filter has been configured correctly, it can be useful to also create a new alarm tab in the Alarm Console using the same filter. This way you can check if it indeed filters out the correct alarms. See [Manually applying an alarm filter in an Alarm Console tab](xref:ApplyingAlarmFiltersInTheAlarmConsole#manually-applying-an-alarm-filter-in-an-alarm-console-tab).

   > [!TIP]
   > See also: [Alarm filters](xref:Alarm_filters)

1. Click *Next* to go the *alarm storm* tab, and specify the necessary options for alarm storm prevention:

   - **Enable alarm storm prevention**: Select this option to activate alarm storm prevention. In that case, when a large number of alarms occur immediately after one another, only two notifications are sent to the SNMP manager: “AlarmStorm started”, with the highest severity of the occurring alarms, and “AlarmStorm stopped”, with severity Normal. Prior to DataMiner 10.0.8, these alarms must occur on the same parameter.

   - **Group alarms with the same parameter name**: Available from DataMiner 10.0.8 onwards. If this option is selected, alarm storm prevention happens based on the number of alarms occurring per parameter; otherwise, it happens based on the number of alarms across parameters. By default, this option is selected.

   - **Minimum number of alarms to lead to an alarm storm**: The minimum number of alarms that must occur on the parameter before the alarm storm starts. This value must be between 5 and 1000.

   - **Maximum time range in which these alarms must be generated**: The time range in which the minimum number of alarms must occur on the parameter. The time range must be between 1 second and 1 hour.

   - **Minimum time range with no alarms to indicate that the alarm storm has stopped**: The time range without alarms after which the alarm storm stops. The time range must be between 1 second and 1 hour.

1. If you want to enable the SNMP manager, go back to the *general* tab and select *Enable the forwarding of SNMP notifications.*

1. Click the *Save* button in the lower right corner.
