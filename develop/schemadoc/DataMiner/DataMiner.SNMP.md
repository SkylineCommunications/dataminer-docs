---
uid: DataMiner.SNMP
---

# SNMP element

Configures SNMP-related settings.

## Parents

[DataMiner](xref:DataMiner)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [enableDataMinerAgentPolling](xref:DataMiner.SNMP-enableDataMinerAgentPolling) | boolean |  | Specifies whether the DataMiner SNMP agent functionality is enabled. |
| [informCacheSize](xref:DataMiner.SNMP-informCacheSize) | int |  | Specifies the number of inform messages that are cached per SNMP entity by DataMiner. |
| [port](xref:DataMiner.SNMP-port) | integer |  | Specifies the port to be used when DataMiner acts as an SNMP agent. |
| [readCommunity](xref:DataMiner.SNMP-readCommunity) | string |  | Specifies the read community to be used by the SNMP agents of the DataMiner Agent. |
| [writeCommunity](xref:DataMiner.SNMP-writeCommunity) | string |  | Specifies the write community to be used by the SNMP agents of the DataMiner Agent. |

## Remarks

See:

- [Changing SNMP agent ports](xref:Changing_SNMP_agent_ports)
- [Configuring SNMP agent community strings](xref:Configuring_SNMP_agent_community_strings)
- [Enabling DataMiner SNMP agent functionality](xref:Enabling_DataMiner_SNMP_agent_functionality)
- [Adjusting the SNMP inform message cache size](xref:Adjusting_the_SNMP_inform_message_cache_size)
