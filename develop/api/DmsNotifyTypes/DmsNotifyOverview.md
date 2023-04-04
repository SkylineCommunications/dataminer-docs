---
uid: SLDmsNotifyTypes
---

# DMS Notify Types

The following table contains an overview of all Notify types.

> [!WARNING]
>
> - The use of DMS Notify types is deprecated. Use the Skyline.DataMiner.Core.DataMinerSystem.Common NuGet package instead. For more information, refer to [Class library introduction](xref:ClassLibraryIntroduction).
> - The table below gives an overview of all the defined DMS Notify types. However, the Notify types for which no additional documentation is provided should not be used.

|ID  |Name  |Description  |
|---------|---------|---------|
|0     |DMS_UNDEF         |         |
|1     |DMS_ALARM         |         |
|2     |DMS_GET_INTERFACE         |         |
|3     |DMS_ELEMENT_STATE         |         |
|4     |DMS_SYSTEM_CHANGES         |         |
|5     |DMS_NEW_CONNECTION         |         |
|7     |DMS_RECEIVE_FILE_CHANGE         |         |
|8     |DMS_GET_INFO         |         |
|9     |DMS_SECURITY         |         |
|10     |DMS_SETTINGS         |         |
|12     |DMS_FILE_CHANGED_BY_DMA         |         |
|13     |DMS_GET_COUNT         |         |
|14     |DMS_GET_CLUSTER_INFO         |         |
|15     |DMS_SYNCHRONISED         |         |
|16     |DMS_SECURITY_NO_FORWARD         |         |
|18     |DMS_SYNC_INFO        |         |
|19     |DMS_SCHEDULED_TASKS_INFO         |         |
|20     |DMS_DMA_REGISTERED_IN_LOCATOR         |         |
|21     |DMS_CLIENT_NOTIFICATIONS         |         |
|22     |DMS_SYSTEM_UPTIME         |         |
|23     |DMS_GET_INFO_ALREADY_CONTACTED         |         |
|24     |DMS_GET_INFO_CHECK_CRC         |         |
|25     |DMS_GET_INFO_FILES         |         |
|26     |DMS_SET_LOGLEVELS         |         |
|27     |DMS_SET_LOGSIZE         |         |
|28     |<xref:DMS_SET_PARAMETER>          |Sets the value of a specified parameter.         |
|29     |DMS_GIVE_PARAMETERS         |         |
|30     |DMS_SECURITY_STORE_ONLY         |         |
|31     |DMS_NOTIFY         |         |
|32     |DMS_REMOVE_DMA         |         |
|33     |DMS_ELEMENT_RECEIVE         |         |
|34     |DMS_REMOTE_ELEMENT_STATE         |         |
|35     |DMS_GET_FILE_CHANGE_INFO         |         |
|36     |DMS_RENEW_CONNECTION         |         |
|37     |DMS_TAKE_BACKUP         |         |
|38     |DMS_DMA_REMOTE_BACKUP         |         |
|39     |DMS_IS_FULL_SYNC_BUSY         |         |
|40     |DMS_GET_LINKED_FILE         |         |
|41     |DMS_REVISION_NOW         |         |
|42     |DMS_GET_REDUNDANCY_INFO         |         |
|43     |DMS_SERVICES_STATUS         |         |
|44     |DMS_SERVICE_INFO         |         |
|45     |DMS_GET_PARAMETER         |         |
|46     |DMS_NEW_CONNECTION_DOT_NET         |         |
|47     |DMS_GET_COMBINATION         |         |
|48     |DMS_DOES_ELEMENT_EXIST         |         |
|49     |DMS_DELETE_SPECTRUM_DEVICE         |         |
|50     |DMS_GET_ZIPPED         |         |
|51     |DMS_PUT_ZIPPED         |         |
|52     |DMS_GET_FILE         |         |
|53     |DMS_NOTIFY_TO_ADD         |         |
|54     |DMS_PUT_FILE         |         |
|55     |DMS_GET_FILE_INFO         |         |
|56     |DMS_REGISTER_CLIENT         |         |
|57     |DMS_UNREGISTER_CLIENT         |         |
|58     |DMS_IS_MODULE_LICENSED         |         |
|59     |DMS_LOAD_REMOTE_REDUNDANCY         |         |
|60     |DMS_REDUNDANT_TRIGGER         |         |
|61     |DMS_SECURITY_INFO         |         |
|62     |DMS_SERVICE_TRIGGER        |         |
|63     |DMS_OPTIMIZE_TABLES         |         |
|64     |DMS_ADD_MULTIPLE_ELEMENTS         |         |
|65     |DMS_SAVE_FILE_REMOTE         |         |
|66     |DMS_REMOVE_FILE_CHANGE         |         |
|67     |<xref:DMS_GET_ELEMENT_NAME>          |Gets the name of the element given the element ID.         |
|68     |DMS_REGISTER_SLA         |         |
|69     |DMS_RESET_SLNET_POINTERS         |         |
|70     |DMS_NIC_INFO         |         |
|71     |DMS_RESET_MODULE         |         |
|72     |<xref:DMS_GET_ELEMENT_ID>          |Gets the ID of the element given the element name.         |
|73     |<xref:DMS_SNMP_NOTIFICATION>          |Sends an SNMP trap or inform message.         |
|74     |DMS_PARAMETER_DISTRIBUTION         |         |
|75     |DMS_DELETE_DISTRIBUTION_KEY         |         |
|76     |<xref:DMS_GET_ELEMENT_ID_FROM_IP>          |Gets the global element ID of (the) element(s) configured with the provided IP and bus address.         |
|77     |DMS_FORWARD_TO_DATAMINER         |         |
|78     |DMS_IP_ADDRESS_CHANGED         |         |
|79     |DMS_FAILOVER_SYNC         |         |
|80     |DMS_DRS_STATE_CHANGED         |         |
|81     |DMS_GET_FAILOVER_INFO         |         |
|82     |DMS_GET_FILE_CHANGE_INFO_INC_MILLIS         |         |
|83     |<xref:DMS_ELEMENT_ALARM_STATE>          |Gets the alarm state of an element.         |
|84     |DMS_NON_QUEUED_SNMP_NOTIFICATION         |         |
|85     |<xref:DMS_DIAG>          |Obtains additional information from a DMA or a DMS.         |
|86     |DMS_VERIFY_CLIENT_COOKIE         |         |
|87     |<xref:DMS_GET_VALUE>          |Retrieves details about a parameter (including the value).         |
|88     |DMS_REGISTER_AUTOMATIC_ELEMENT         |         |
|89     |DMS_NOTIFY_ANNOTATION_CONTENT         |         |
|90     |DMS_PROPERTY_UPDATE_AUTOMATIC_ELEMENT         |         |
|91     |<xref:DMS_GET_ELEMENT_STATE>          |Gets the element state.         |
|92     |DMS_REFRESH_LDAP         |         |
|93     |DMS_GET_FILE_CHANGE_INFO_ON_DISK         |         |
|94     |DMS_GET_INFO_ALL         |         |
|95     |DMS_GET_INFO_ONE         |         |
|96     |DMS_REQUEST_NEW_ELEMENT_IDS         |         |
|97     |DMS_SNMP_SEND_HISTORY_ALARMS         |         |
|98     |DMS_SET_ELEMENT_STATE         |         |
|99     |DMS_RECEIVE_FILE_CHANGE_QUERY         |         |
|100     |DMS_ASSIGN_NEW_ID_RANGE         |         |
|101     |DMS_RELOAD_LOCAL_RGS         |         |
|102     |<xref:DMS_GET_ELEMENTS_USING_PROTOCOL>          |Gets elements using the specified protocol.         |
|103     |DMS_GET_SPECIFIC_ELEMENT_INFO         |         |
|104     |DMS_WAIT_EMPTY_STACK         |         |
|105     |DMS_GET_DCP_CREDENTIALS         |         |
|106     |DMS_GET_CLUSTER_AGENTS_FOR_SYNC         |         |
|107     |DMS_COMPLETE_INIT         |         |
|108     |DMS_FIND_HOSTING_AGENT         |         |
|109     |DMS_INVALIDATE_HOSTING_AGENT_CACHE         |         |
|110     |DMS_AGENT_FOUND_REMOTE         |         |
|111     |DMS_GET_ENC_INFO         |         |
|112     |DMS_LOAD_DVES_BY_PARENT         |         |
|113     |DMS_NOTIFY_VERSION_INFO         |         |
|114     |DMS_SYNCHRONISE_ADDED_GROUP         |         |
|115     |DMS_GET_ELEMENT_PROTOCOL_VERSION         |         |
|116     |DMS_MULTIPLE_FILE_CHANGED_BY_DMA         |         |
|117     |DMS_DISTRIBUTE_TRAP         |         |
|118     |DMS_ISDOING_DOUBLECHECK         |         |
|119     |DMS_INIT_SLNET         |         |
|120     |DMS_RELOAD_FAILOVERINFO         |         |
|121     |DMS_SERVICE_TRIGGERS         |         |
|122     |DMS_GET_SYNC_STATUS         |         |
