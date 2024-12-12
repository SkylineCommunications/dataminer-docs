---
uid: Protocol.Params.Param.SNMP.InvalidResponseHandling.InfiniteLoop
---

# InfiniteLoop element

<!-- RN 20419 -->

Specifies the response handling in case an infinite loop was detected when polling a table.

## Content type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|success|The SNMP response is accepted, and the table is updated.|
|&nbsp;&nbsp;Enumeration|timeout|The SNMP response is rejected, the table is not updated, and the timeout timer of the interface is triggered.|

## Parent

[InvalidResponseHandling](xref:Protocol.Params.Param.SNMP.InvalidResponseHandling)

## Remarks

When SLSNMPManager detects an infinite loop, the response will be rejected by default. To override this default behavior, *InfiniteLoop* can be configured. If you want SLSNMPManager to accept a response in case of an infinite loop, set *InfiniteLoop* to "Success". This tag can only be used for table parameters.

> [!NOTE]
> Regardless of the InvalidResponseHandling setting, when an infinite loop is detected, a message will be logged in the element's log file (type ERROR, level 0).

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
