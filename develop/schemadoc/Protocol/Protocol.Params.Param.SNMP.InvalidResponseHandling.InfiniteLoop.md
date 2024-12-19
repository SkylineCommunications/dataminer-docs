---
uid: Protocol.Params.Param.SNMP.InvalidResponseHandling.InfiniteLoop
---

# InfiniteLoop element

<!-- RN 20419 -->

Specifies the response handling in case an infinite loop was detected while polling a table.

## Content type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|success|The SNMP response is accepted, and the table is updated.|
|&nbsp;&nbsp;Enumeration|timeout|The SNMP response is rejected, the table is not updated, and the timeout timer of the interface is triggered.|

## Parent

[InvalidResponseHandling](xref:Protocol.Params.Param.SNMP.InvalidResponseHandling)

## Remarks

This tag can only be used for table parameters.

SLSNMPManager has a safeguard mechanism to prevent polling endlessly in case polling a table results in an infinite loop.
When SLSNMPManager detects an infinite loop while polling a table, the response will be rejected by default.
To override this default behavior, `InfiniteLoop` can be configured. If you want SLSNMPManager to accept a response in case of an infinite loop, specify `<InfiniteLoop>success</InfiniteLoop>`.

> [!NOTE]
> Regardless of the InvalidResponseHandling setting, when an infinite loop is detected, a message will be logged in the element's log file (type ERROR, level 0).
> If the response is accepted, the following message is logged: `Detected an infinite loop when polling parameter with ID=<tableId>, InvalidResponseHandling was set to accept the data.`.
> If the response is rejected, the following message is logged: `Detected an infinite loop when polling parameter with ID=<tableId>, rejected the polled data.`

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
        <InfiniteLoop>success</InfiniteLoop>
        </InvalidResponseHandling>
    </SNMP>
</Param>
```
