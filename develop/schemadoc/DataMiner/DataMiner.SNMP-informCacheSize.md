---
uid: DataMiner.SNMP-informCacheSize
---

# informCacheSize attribute

Specifies the number of inform messages that are cached per SNMP entity by DataMiner. Default value: 20.

> [!NOTE]
>
> - If you set *informCacheSize* to 0, the cache will be disabled.
> - Only inform messages are stored in this cache, not traps.
> - When an inform message is discarded, this is logged in *SLSNMPManager.txt* on information level 3.

## Content Type

integer

## Parents

[SNMP](xref:DataMiner.SNMP)

## Remarks

To handle situations where inform messages are sent out again while they have already been acknowledged by DataMiner, DataMiner will by default keep track of the latest 20 unique inform message IDs per SNMP entity in a cache, so that it can check whether an incoming inform message has already been processed, and discard it if this is the case.

## Example

```xml
<DataMiner>
   ...
   <SNMP informCacheSize="25" />
   ...
</DataMiner>
```
