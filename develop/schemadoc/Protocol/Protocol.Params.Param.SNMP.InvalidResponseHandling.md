---
metadata_version: 1
uid: Protocol.Params.Param.SNMP.InvalidResponseHandling
description: "Reference the DataMiner connector protocol schema entry for InvalidResponseHandling element, including its documented structure, attributes, values, and c."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
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
