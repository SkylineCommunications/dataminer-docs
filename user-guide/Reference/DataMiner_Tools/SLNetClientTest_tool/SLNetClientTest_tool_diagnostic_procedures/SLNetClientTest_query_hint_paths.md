---
uid: SLNetClientTest_query_hint_paths
---

# Querying the assembly resolution hint paths

To troubleshoot assembly resolution issues, from DataMiner 10.4.12/10.5.0 onwards<!--RN 41068-->, you can use the SLNetClientTest tool to query the hint paths used to look up QAction dependencies:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Diagnostics* menu, select *DMA* > *SLScripting AssemblyResolve HintPaths*.

1. Go to the *Output* tab to view the current list of hint paths used by the DataMiner AssemblyResolveHelper.

   If [multiple SLScripting processes are configured](xref:Configuration_of_DataMiner_processes), the output will show the hint paths for each process per process ID.

> [!NOTE]
> To help with the troubleshooting of assembly resolution issues, from DataMiner 10.4.12/10.5.0 onwards, an entry is also added in the *SLManagedScripting.txt* log file each time DataMiner has loaded or failed to load an assembly. This log entry will include both the requested version and the actual version of the assembly.
