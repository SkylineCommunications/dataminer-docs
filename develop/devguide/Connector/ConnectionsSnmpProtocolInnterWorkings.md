---
uid: ConnectionsSnmpProtocolInnterWorkings
---

# Protocol inner workings

## Altering a variable

The illustration below shows what happens when an SNMP set request is issued by a protocol that is successfully processed by the SNMP agent of the device (i.e., the ErrorStatus field contains the value 0, indicating "noError").

![DataMiner Agent inner workings – altering a variable via SNMP](~/develop/images/DMA_-_SNMP_Device_parameter_SetRequest.svg)

When a protocol issues an SNMP set request, this request is sent to the SLSNMPManager process. This is done by a blocking call, which adds the SNMP request to a queue. The call blocks until the SNMP request has been added to the queue. This queue is a priority queue where SetRequests always receive a higher priority than GetRequests.

After all other SetRequests that preceded this SetRequest in the queue have been handled, the SLSNMPManager process forwards the SetRequest to the SNMP Agent running on the device.

## How tables are processed internally

When a table enters SLProtocol, this is what happens:

1. Check if the row is a new row.
1. Check if cells have changed value.
1. Check if a QAction on row level needs to be triggered (2).

    - Within the QAction, sets on cells can be performed. These sets are forwarded immediately (3).

1. Check if rows have been deleted.
1. Forward all updates to the SLElement process (4).
1. Check if a QAction on table level needs to be triggered.
1. Forward updates to the SLElement process.

See the following diagram:

![How tables are processed internally](~/develop/images/ProcessingTables.svg)

## About SNMP tables

Watch out for pitfalls when creating displayColumn for an SNMP table. When you adjust the displayColumn values using a row=true QAction triggered by the table, the values set will initially not be used.

See [Dynamically retrieving a value](xref:ConnectionsSnmpDynamicallyRetrievingAVariable): the data from SLScripting will be overwritten when the complete table is retrieved.

To avoid pitfalls, either follow the procedure below or use naming ([naming](xref:Protocol.Params.Param.ArrayOptions-options#naming) option or [NamingFormat](xref:Protocol.Params.Param.ArrayOptions.NamingFormat)).

1. Use the NewRow method to set a flag (a parameter) that indicates that the values used for the displayColumn have changed. To avoid unnecessary sets, check if the flag is set before setting it. At the same time, store the keys of the changed rows in a second parameter.
1. Following the group that retrieves the table, add a trigger with a condition tag to check the flag. When the flag is set, do a "run actions" action to force the execution of a QAction that will set the displayColumn values. Only loop through the keys of the second parameter. Clear the flag at the end of the QAction.
