---
uid: DMAElementConfiguration
---

# DMAElementConfiguration

| Item | Format | Description |
|--|--|--|
| Name | String | The name of the element. A limit of at most 150 characters applies. |
| Description | String | The description of the element. |
| ProtocolName | String | The name of the element’s protocol. |
| ProtocolVersion | String | The version of the element’s protocol. |
| Type | String | The element type configured in the protocol (e.g. “Information Platform” in a Microsoft protocol). |
| AlarmTemplate | String | The alarm template used to monitor the element. |
| TrendTemplate | String | The trend template used to track the element’s trend data. |
| ForceAgent | String | Used in a Failover setup to always make an element run on a particular DMA. |
| IPAddress | String | The IP address of the device. |
| IPAddressMask | String | The subnet mask of the device. |
| CreateDVEs | Boolean | Indicates whether the element can create DVE child elements. |
| EnableSnmpAgent | Boolean | Indicates whether a virtual SNMP agent is enabled for the element. |
| EnableTelnet | Boolean | Indicates whether the element’s Telnet interface is enabled. |
| IsHidden | Boolean | Indicates whether the element is hidden. |
| IsReadOnly | Boolean | Indicates whether the element is a read-only element. |
| IsReplication | Boolean | Indicates whether the element is replicated. |
| KeepOnline | Boolean | Used in a Failover setup to indicate that the element needs to keep running even when the DMA is offline |
| SnmpReadCommunityString | String | The community string used to read values from the device. |
| SnmpWriteCommunityString | String | The community string used to set values on the device. |
| ReplicationInfo.Domain | String | The domain from where the element is replicated. Available from DataMiner 10.1.9 onwards. |
| ReplicationInfo.Host | String | The host from where the element is replicated. Available from DataMiner 10.1.9 onwards. |
| ReplicationInfo.Password | String | The password used to connect to the DMA from which the element is replicated. Available from DataMiner 10.1.9 onwards. |
| ReplicationInfo.DataMinerID | Integer | The DataMiner ID of the element that is replicated. Available from DataMiner 10.1.9 onwards. |
| ReplicationInfo.ElementID | Integer | The element ID of the element that is replicated. Available from DataMiner 10.1.9 onwards. |
| ReplicationInfo.User | String | The username used to connect to the DMA from which the element is replicated. Available from DataMiner 10.1.9 onwards. |
| TimeoutTime | Integer | The time after which an element goes into timeout (between 0 and 120,000 ms). |
| SlowPoll | Array | Array consisting of:<br> -  Base (string): “*TIME*”, “*NUMBER*” or “*NO*”<br> -  Value (integer): Depending on the Base configuration, this is a time value (between 1000 and 300,000 ms), the number of timeouts (between 1 and 500), or empty, respectively.<br> -  PingInterval (integer): Between 1000 and 300,000 ms. |
| State | String | The element state, which can be *Undefined*, *Active*, *Hidden*, *Paused*, *Stopped*, *Deleted*, *Error*, *Restart* or *Masked*. |
| Ports | Array | Array of [DMAElementBasePortInfo](xref:DMAElementBasePortInfo). |
