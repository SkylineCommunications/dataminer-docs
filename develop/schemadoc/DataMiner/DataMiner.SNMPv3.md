---
uid: DataMiner.SNMPv3
---

# SNMPv3 element

Configures SNMPv3-related settings.

## Parents

[DataMiner](xref:DataMiner)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [generateNoticeOnIncorrectTrapReceived](xref:DataMiner.SNMPv3-generateNoticeOnIncorrectTrapReceived) | boolean |  | Specifies whether DataMiner will generate a notification if an SNMPv3 trap or inform message is received that cannot be processed. |
| [trapPort](xref:DataMiner.SNMPv3-trapPort) | integer |  | Specifies a custom SNMPv3 trap reception port. |

## Remarks

See:

- [Customizing the trap reception ports of a DMA](xref:Changing_SNMP_agent_ports#customizing-the-trap-reception-ports-of-a-dma)
- [Enabling notifications in case SNMPv3 traps cannot be processed](xref:Enabling_notifications_in_case_SNMPv3_traps_cannot_be_processed)
