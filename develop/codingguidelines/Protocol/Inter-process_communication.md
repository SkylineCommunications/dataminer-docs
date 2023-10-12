---
uid: Inter-process_communication
---

# Inter-process communication

The number of interactions between SLScripting, the process executing the QAction, and other processes should be limited to an absolute minimum, as these consume a considerable amount of resources. Also limit the number of interactions per second.

It can occur that a QAction needs to perform an operation that requires some time to complete (e.g. a DMS call). In case another call is needed to determine if the operation has finished, you must avoid continuously repeating the call that checks the operation status without leaving time between the calls (for example, by including a Thread.Sleep call in the loop).

Typically, QActions mainly interact with the SLProtocol process using an instance of the SLProtocol (or SLProtocolExt) class. As each protocol object call results in inter-process communication between the SLScripting and SLProtocol processes, consider the following:

- Use the GetParameters and SetParameters methods instead of multiple GetParameter and SetParameter method calls to get and set multiple parameters, respectively.

- The implementation with the best performance should be used when retrieving or updating tables. A QAction implementation that retrieves or sets column(s) is generally preferred over a QAction that triggers on every row of a table (row=true).

- Protocol calls inside a loop should be avoided as much as possible.

In order to improve readability (and type safety) of code in QActions, the following guidelines should be considered:

- In case a wrapper method is available for a NotifyProtocol call, the use of the wrapper method is favored.

- Usage of the SLProtocolExt interface is favored over the SLProtocol interface, as in many situations this allows you to write more readable code.

- With DataMiner versions prior to DataMiner 9.0, the use of the GetKeys method to retrieve the primary keys (NotifyProtocol.KeyType.Index) should be avoided, as up to DataMiner 9.0 the implementation to retrieve the primary keys is based on the SLElement process (an NT_GET_INDEXES call is executed, which retrieves both the primary keys and the display keys.). As it is possible that there is a delay in SLElement (e.g. due to a large number of calls that it is processing), it is possible that the returned data is not up to date.

    Since DataMiner 9.0, the implementation of the GetKeys method has been updated. Retrieving the primary keys no longer involves the SLElement process. However, note that obtaining the display keys (NotifyProtocol.KeyType.DisplayKey) is still based on SLElement.

> [!NOTE]
>
> - The implementation of the Keys property of the QActionTable class also makes use of the GetKeys method. Therefore, the use of the Keys property should also be avoided prior to DataMiner 9.0.
> - The ClearAllKeys() method still uses the NT_GET_INDEXES call, so for this reason the use of this method should be avoided.
