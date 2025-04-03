---
uid: Resending_alarms_to_an_SNMP_manager
---

# Resending alarms to an SNMP manager

To resend a number of history alarms to a particular SNMP manager:

1. In DataMiner Cube, go to *Apps* > *System Center* \> *SNMP Forwarding*.

1. Right-click an SNMP manager in the list, and click *Resend.*

1. In the resend window:

   1. Specify a time range, and

   1. Select the DMA that has to send the alarms.

      If you do not specify a DMA, every DMA will search its own alarm history and send the alarms that (a) match the alarm filter of the SNMP manager in question and (b) have a timestamp that falls within the time frame specified in the wizard.     Every batch of resent alarms is enclosed in two special SNMP notifications:

   - An SNMP notification with value SNMP_HISTORY_START_X marks the start of the batch.

   - An SNMP notification with value SNMP_HISTORY_STOP_X marks the end of the batch.

     > [!NOTE]
     > In the above, X is the DataMiner ID of the DMA from which the notifications are sent.

   If SNMP trap rerouting is enabled for the SNMP manager in question, you will not be able to select the DMA that has to send the alarms. In that case, all SNMP notifications will be sent from the DMA of which the DMA ID is specified in the *sourceDMA* attribute of the SNMPManagers.SNMPManager tag of the *SNMP Managers.xml* file.

> [!NOTE]
>
> - Information events are created to help you track resend operations.
> - This feature will only work if the SNMP manager is enabled in DataMiner’s SNMP managers list.
> - You can also trigger this resend outside of DataMiner, by sending an SNMP Set to the DMA (with the DataMiner IP as target address) with OID 1.3.6.1.4.1.8813.1.1.1.1.4 and value set to the name of the SNMP manager. However, the following should be noted:
>   - This will resend all active alarms.
>   - Since this is an SNMP Set request, the write community string will need to be filled in correctly. This value is configured in *DataMiner.xml* and is set to “private” by default. If an SNMP Set request does not have the correct community string, an error will be returned. See [Configuring SNMP agent community strings](xref:Configuring_SNMP_agent_community_strings).
> - You cannot resend alarms to an SNMP manager that has the [*Enable tracking to avoid duplicate inform acknowledgments (ACKs)* option](xref:Configuring_an_SNMP_manager_in_DataMiner_Cube) enabled.
