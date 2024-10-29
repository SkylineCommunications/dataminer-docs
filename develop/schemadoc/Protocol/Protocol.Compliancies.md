---
uid: Protocol.Compliancies
---

# Compliancies element

<!-- RN 10642, 12011 -->

Specifies compliancy information.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[CassandraReady](xref:Protocol.Compliancies.CassandraReady)||Indicates whether the protocol is compatible with a Cassandra database.|
|&nbsp;&nbsp;[CassandraRequired](xref:Protocol.Compliancies.CassandraRequired)|[0, 1]|Specifies whether a Cassandra database is required to execute the protocol.|
|&nbsp;&nbsp;[MinimumRequiredVersion](xref:Protocol.Compliancies.MinimumRequiredVersion)|[0, 1]|Indicates the minimum DataMiner version that the connector is compatible with.|
|&nbsp;&nbsp;[MaximumSupportedVersion](xref:Protocol.Compliancies.MaximumSupportedVersion)|[0, 1]|Specifies the maximum DataMiner version this protocol supports.|

## Remarks

- If a protocol is configured with compliancy requirements, (e.g. because it requires Cassandra or a particular minimum DataMiner version), it will not be possible to upload this protocol if these requirements are not met.<!-- RN 21169 -->

- If a protocol is uploaded that requires a higher DataMiner version than the one currently installed in the system, the following error message will be logged:<!-- RN 24298 -->

  `DataMiner version is too low to use this protocol. Please check the protocol's Compliancies tag.`

## Examples

```xml
<Compliancies>
   <CassandraReady>true</CassandraReady>
   <CassandraRequired>true</CassandraRequired>
   <MinimumRequiredVersion>10.0.7.0 - 9247</MinimumRequiredVersion>
</Compliancies>
```
