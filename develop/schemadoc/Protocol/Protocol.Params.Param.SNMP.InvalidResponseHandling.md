---
metadata_version: 1
uid: Protocol.Params.Param.SNMP.InvalidResponseHandling
description: "Learn how the InvalidResponseHandling element sets the SNMP response strategy for an infinite table polling loop in a DataMiner connector protocol."
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
