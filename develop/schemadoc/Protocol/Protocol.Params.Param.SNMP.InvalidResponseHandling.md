---
uid: Protocol.Params.Param.SNMP.InvalidResponseHandling
description: "Use the InvalidResponseHandling element in a DataMiner protocol to configure the response handling strategy for invalid SNMP responses."
---

# InvalidResponseHandling element

<!-- RN 20419 -->

Specifies the invalid response handling strategy.

## Parent

[SNMP](xref:Protocol.Params.Param.SNMP)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[InfiniteLoop](xref:Protocol.Params.Param.SNMP.InvalidResponseHandling.InfiniteLoop)||Specifies the response handling in case an infinite loop was detected while polling a table.|

## Examples

```xml
<Param ...>
    ...
    <ArrayOptions ...>
        ...
    </ArrayOptions>
    <SNMP>
        ...
        <InvalidResponseHandling>
        <InfiniteLoop>Success</InfiniteLoop>
        </InvalidResponseHandling>
    </SNMP>
</Param>
```
