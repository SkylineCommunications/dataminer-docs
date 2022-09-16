---
uid: SLNetClientTest_creating_dump_for_process
---

# Creating a dump file for a particular process

With the SLNetClientTest tool, you can create a dump file for a process, i.e. a snapshot of that process at a particular time. To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, select *Request dump*, and select the process for which you want to create a dump file. You can also select *(other)*, and enter the PID for which you want to create a dump file.

1. In the *Select Dump Level* window, indicate what information should be included in the dump file, and click *OK*.

   A file with the extension .dmp will be saved in the folder *C:\\Skyline Dataminer\\logging\\CrashDump*.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
