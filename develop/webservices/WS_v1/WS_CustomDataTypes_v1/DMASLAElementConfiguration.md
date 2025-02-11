---
uid: DMASLAElementConfiguration
---

# DMASLAElementConfiguration

| Item | Format | Description |
|------|--------|-------------|
| Name            | String           | The name of the SLA element.<br>A limit of at most 150 characters applies. |
| Service         | Array of integer | Array consisting of the DataMinerID and service ID of the service monitored by the SLA. |
| Description     | String           | The description of the SLA. |
| ProtocolName    | String           | The name of the SLA protocol. |
| ProtocolVersion | String           | The version of the SLA protocol. |
| AlarmTemplate   | String           | The alarm template used to monitor the SLA element. |
| TrendTemplate   | String           | The trend template used to track the SLA element’s trend data. |
| ForceAgent      | String           | Used in a Failover setup to always make the SLA element run on a particular DMA. |
| IsHidden        | Boolean          | Indicates whether the SLA element is hidden. |
| IsReadOnly      | Boolean          | Indicates whether the SLA element is a read-only element. |
| IsReplicationActive | Boolean      | Indicates whether the SLA element is replicated. |
| State           | String           | The element state, which can be *Undefined*, *Active*, *Hidden*, *Paused*, *Stopped*, *Deleted*, *Error*, *Restart* or *Masked*. |
