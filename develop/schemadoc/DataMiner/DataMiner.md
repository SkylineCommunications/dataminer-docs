---
uid: DataMiner
---

# DataMiner element

Configures the DataMiner Agent.

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [disableElementIP](xref:DataMiner-disableElementIP) | boolean |  | When set to “true”, after a restart of the DataMiner Agent, it will no longer be possible to assign a virtual IP address to an element. Moreover, the virtual IP addresses of all existing elements will be disabled. See [Forcing a DataMiner Agent to work without virtual IP addresses](xref:Forcing_a_DMA_to_work_without_virtual_IPs).|
| [elementid](xref:DataMiner-elementid) | integer |  | Specifies the ID of the most recently added element. |
| [id](xref:DataMiner-id) | integer | Yes | Specifies the DataMiner Agent ID. See [Changing the DataMiner ID of a DMA](xref:Changing_the_DMA_ID).|
| [initializeRemoteServices](xref:DataMiner-initializeRemoteServices) | boolean |  |  |
| [licenseNotice](xref:DataMiner-licenseNotice) | string |  | Automatically generated attribute. Contains information about which license notices have been generated for this DMA. |
| [protocolVisioLnk](xref:DataMiner-protocolVisioLnk) | integer |  | When set to "1", this tag indicates that DataMiner has attempted to create all the Visio.lnk files that indicate the current Visio file for a protocol. This is used for troubleshooting purposes. |
| [readElementData](xref:DataMiner-readElementData) | boolean |  | Automatically generated attribute, indicating that previously configured element data that was saved in DataMiner.xml has been moved to the element data database tables. |
| [readProperties](xref:DataMiner-readProperties) | boolean |  | Automatically generated attribute. Deprecated. |
| [safeMode](xref:DataMiner-safeMode) | boolean |  | If set to `true`, elements will not be started using multiple threads. |
| [storeLastPollTimes](xref:DataMiner-storeLastPollTimes) | boolean |  |  |
| [useAgentBinding](xref:DataMiner-useAgentBinding) | string |  |  |

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| All |  |  |
| &#160;&#160;[AlarmSocket](xref:DataMiner.AlarmSocket) | [0, 1] | Specifies that alarm events should be forwarded via a particular TCP/IP socket. See [Configuring the TCP-IP socket settings](xref:Configuring_the_TCP-IP_socket_settings#configuring-the-tcp-ip-socket-settings).|
| &#160;&#160;[ClearableAlarmStormProtection](xref:DataMiner.ClearableAlarmStormProtection) | [0, 1] | Configures alarm storm protection for clearable alarms: |
| &#160;&#160;[Colors](xref:DataMiner.Colors) | [0, 1] | Specifies the colors assigned to each of the alarm levels. See [Changing the default alarm colors](xref:Changing_the_default_alarm_colors).|
| &#160;&#160;[Crowd](xref:DataMiner.Crowd) | [0, 1] | Configures the use of an Atlassian Crowd server. |
| &#160;&#160;[DaaS](xref:DataMiner.DaaS) | [0, 1] | Configures DaaS related settings. |
| &#160;&#160;[DataMinerGuid](xref:DataMiner.DataMinerGuid) | [0, 1] | Specifies the DataMiner GUID. |
| &#160;&#160;[DMA](xref:DataMiner.DMA) | [0, 1] | Specifies information about this DataMiner Agent. |
| &#160;&#160;[ExternalAuthentication](xref:DataMiner.ExternalAuthentication) | [0, 1] | Configures external authentication. |
| &#160;&#160;[ID](xref:DataMiner.ID) | [0, 1] | Specifies information about the ID ranges to be used for e.g. view creation. This information allows multiple DataMiner Agents to create views at the same time, without creating conflicts. |
| &#160;&#160;[IP](xref:DataMiner.IP) | [0, 1] | Configures IP related settings. |
| &#160;&#160;[LDAP](xref:DataMiner.LDAP) | [0, 1] | Contains the LDAP configuration. See [Configuring LDAP settings](xref:Configuring_LDAP_settings).|
| &#160;&#160;[Logging](xref:DataMiner.Logging) | [0, 1] | Specifies the logging level for Info logging, Debug logging, and Error logging. See [Consulting the DataMiner logs in DataMiner Cube](xref:Consulting_the_DataMiner_logs_in_DataMiner_Cube).|
| &#160;&#160;[MobileGateway](xref:DataMiner.MobileGateway) | [0, 1] | Specifies the mobile gateway. |
| &#160;&#160;[NetworkAdapters](xref:DataMiner.NetworkAdapters) | [0, 1] | Overrides the order of the network adapters on a DataMiner Agent. This can be useful to prevent issues in case the order in Windows changes for some reason (e.g. because there is a new network adapter). |
| &#160;&#160;[PollSocket](xref:DataMiner.PollSocket) | [0, 1] | Configures the DataMiner Agent to forward information about elements and parameters when it receives a request on a particular TCP/IP socket. See [Configuring the TCP-IP socket settings](xref:Configuring_the_TCP-IP_socket_settings#configuring-the-tcp-ip-socket-settings). |
| &#160;&#160;[ProcessOptions](xref:DataMiner.ProcessOptions) | [0, 1] | Configures the DataMiner processes. See [Configuration of DataMiner processes](xref:Configuration_of_DataMiner_processes)|
| &#160;&#160;[QOS](xref:DataMiner.QOS) | [0, 1] | Configures the DiffServ marker on network traffic from SLPort to polled devices. |
| &#160;&#160;[SMTP](xref:DataMiner.SMTP) | [0, 1] | Configures outgoing mail. See [Configuring outgoing email](xref:Configuring_outgoing_email).|
| &#160;&#160;[SNMP](xref:DataMiner.SNMP) | [0, 1] | Configures SNMP related settings. |
| &#160;&#160;[SnmpTrapDistribution](xref:DataMiner.SnmpTrapDistribution) | [0, 1] | When set to `false`, SNMP trap distribution is disabled within the DMS. |
| &#160;&#160;[SNMPv1](xref:DataMiner.SNMPv1) | [0, 1] | Configures SNMPv1 related settings. |
| &#160;&#160;[SNMPv2](xref:DataMiner.SNMPv2) | [0, 1] | Configures SNMPv2c related settings. |
| &#160;&#160;[SNMPv3](xref:DataMiner.SNMPv3) | [0, 1] | Configures SNMPv3 related settings. |
| &#160;&#160;[Telnet](xref:DataMiner.Telnet) | [0, 1] | Obsolete. Configures Telnet. |
| &#160;&#160;[WarningThreshold](xref:DataMiner.WarningThreshold) | [0, 1] | Configures when messages are generated that indicate a DMA is approaching the limit of its element license. By default, warning messages are generated. |
