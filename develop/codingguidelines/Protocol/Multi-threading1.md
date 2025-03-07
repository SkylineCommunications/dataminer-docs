---
uid: Multi-threading1
---

# Multi-threading

In some situations, parallel programming can be considered to optimize performance and decrease execution time. The .NET Framework 4 (and above) provides extensive support for parallel programming. Consider the following when implementing multi-threading in a protocol:

  - Verify that the parallel implementation is in fact running faster through performance measurements, especially when using locks.

  - Exploiting parallel programming makes available CPU resources for other processes decrease. Therefore, we must avoid that the SLScripting process consumes all CPU resources, as otherwise all other DataMiner processes will slow down or freeze, which can cause a DataMiner crash.

  - Since DataMiner version [10.2.9](xref:General_Feature_Release_10.2.9#qactions-are-now-idisposable-and-the-slprotocol-object-remains-available-outside-of-the-run-scope-id-33965), SLProtocol methods can be invoked in threads that outlive the QAction. Despite this, it is important to keep the following considerations in mind when creating such threads:

    - The SLWatchDog process will not notice if items are stuck (no RTE notice).

    - Investigating issues related to threads outlasting QActions is very difficult.

    - An unhandled exception in a thread that outlasts the QAction that initiated it causes the SLScripting process to crash.

    - Implement IDisposable in the QAction for proper cleanup when the element is stopping.

  - DataMiner takes care of locking when performing calls to update local or remote parameters. However, a QAction may contain critical sections of code. In this case, locks must be provided to ensure that a thread does not enter the critical section while another thread is in it. For example, suppose a row is retrieved from a table and the QAction implements logic to update some cells of the row. At a later point, a call is made to update the table with the new row values. In this case, it is important to provide a lock around the code to prevent the row being removed in the meantime. This data retrieval, manipulation and update sequence is a common scenario where locking is required.
