---
uid: Protocol.Params.Param.SNMP.InvalidResponseHandling
---

# InvalidResponseHandling element

Specifies the invalid response handling strategy.

## Parent

[SNMP](xref:Protocol.Params.Param.SNMP)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[InfiniteLoop](xref:Protocol.Params.Param.SNMP.InvalidResponseHandling.InfiniteLoop)||Specifies the response handling in case an infinite loop was detected when polling a table.|

## Remarks

*Feature introduced in DataMiner 9.6.3 (RN 20419).*

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
