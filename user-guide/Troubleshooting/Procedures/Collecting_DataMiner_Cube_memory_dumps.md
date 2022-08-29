---
uid: Collecting_DataMiner_Cube_memory_dumps
---

# Collecting DataMiner Cube memory dumps

When something goes wrong in the DataMiner Cube client application, the more debug information is collected, the faster the root cause of the issue and a potential solution can be found. Memory dumps are a very valuable source of such debug information.

Below, you can find when and how to collect these memory dumps.

## When are memory dumps useful

Memory dumps can be useful with a wide range of problems, but especially in the following cases:

- Very high memory usage
- Crash because of OutOfMemoryException
- Complete crash of DataMiner Cube because of any exception
- Deadlock (UI frozen indefinitely or for a very long time)
- Performance issues (Cube is using 100% of one or more CPU cores for a long time)

## Tools

Below, you can find information about the principal tools you can use to collect DataMiner Cube memory dumps.

### ProcDump

ProcDump is a tool provided by Microsoft. It can be downloaded from <https://docs.microsoft.com/en-us/sysinternals/downloads/procdump>.

You can also run or copy it directly from a DataMiner Agent (`C:\Skyline DataMiner\Tools\Procdump`).

ProcDump is a very versatile tool and will suffice in almost all cases. Only when memory usage of Cube is very high, it is better to use the *Managed GC Aware Dump tool* instead (see below), or else to take multiple dumps one after another with ProcDump, as memory dumps taken during garbage collection are unusable.

To take a memory dump with ProcDump:

1. Open a command prompt (*cmd.exe*) in the folder containing *procdump.exe*.
1. Run `procdump -ma DataMinerCube.exe`

In the command above, replace *DataMinerCube.exe* with the name or ID of the process you want to take a memory dump from. For example, to take a memory dump of the DataMiner Cube browser app (XBAP), specify *PresentationHost.exe* instead.

This tool has several interesting options, which are explained in the example section below.

### Managed GC Aware Dump tool

This tool can take a memory dump, just like *ProcDump*, but is aware of garbage collection. It can be downloaded from <https://kb.sitecore.net/articles/284285>.

To take a memory dump with the Managed GC Aware Dump tool:

1. Open a command prompt (*cmd.exe*) in the folder containing the tool.
1. Run `ManagedGcAwareDump_x64.exe [Name or PID]` or `ManagedGcAwareDump_x86.exe [Name or PID]`, depending on the Cube version (which can be checked in the Task Manager).

To force garbage collection before the dump is created, you can add the option `/fgc`. This can reduce the size of the dump file.

## Examples

In the examples below, unless we explicitly state otherwise, *ProcDump* is used.

In all examples, a memory dump is taken of a process of the DataMiner Cube desktop application, of which only one instance is running on the client machine. In all cases, you can replace the name by *PresentationHost.exe* to make the example apply to the DataMiner Cube browser version (XBAP). Alternatively, you can replace the name by the process ID in case multiple instances with this name are running.

### Crash

- **Situation**: DataMiner Cube crashes.

- **What to do**: Run the following command before the crash happens:

    `procdump -ma -e DataMinerCube.exe`

- **Result**: A memory dump will be taken at the moment when Cube crashes.

### Crash due to a stack overflow

- **Situation**: DataMiner Cube crashes. *Procdump* displays an exception of type *C00000FD.STACK_OVERFLOW*, but does not make a memory dump.

- **What to do**: Run the following command before the crash happens:

    `procdump -ma -e 1 -f C00000FD.STACK_OVERFLOW DataMinerCube.exe`

- **Result**: A memory dump will be taken at the moment when the stack overflow happens (and Cube crashes).

### Exception

- **Situation**: An exception pop-up message is displayed, but DataMiner Cube does not crash.

- **What to do**: Run the following command before the exception happens:

    `procdump -ma -e 1 -f *NameOfException* DataMinerCube.exe`

- **Result**: A memory dump will be taken as soon as an exception occurs of which the name matches the specified name.

### Deadlock

- **Situation**: The DataMinerCube user interface freezes.

- **What to do**: Run the following command before the issue occurs:

    `procdump -ma -h DataMinerCube.exe`

- **Result**: A memory dump will be taken as soon as the UI is frozen for more than 5 seconds.

> [!NOTE]
> You can also take a memory dump during the freeze with the following command: `procdump -ma DataMinerCube.exe`

### OutOfMemoryException or high memory usage

- **Situation**: The memory usage of DataMiner Cube is very high, and pop-up messages mentioning an *OutOfMemoryException* appear.

- **What to do**: There are a few things to watch out for when taking a memory dump to investigate memory issues.

    - A memory dump after an *OutOfMemoryException* often provides little to no info, as a lot of memory is already cleaned up at that point.
    - When memory usage is high, the .NET garbage collector will often run. Memory dumps taken during garbage collection are unusable.
    - When there is a memory leak (i.e. memory usage keeps increasing), a comparison between two memory dumps of moments when memory usage should be but is not equal is more interesting than one single memory dump.

Because of these points, we recommend to **take multiple memory dumps** using the following commands:

- To take a memory dump when memory usage exceeds a specific amount of MB (in the case of this example 1200), with a maximum of a specific number of dumps (in this case 5), use the following command:

    `procdump -ma -m 1200 -n 5 DataMinerCube.exe`

    Use 1200 MB or less for 32-bit versions of Cube, and use at least 2000 MB for 64-bit versions of Cube.

- In case there is a huge increase in memory usage when a specific action is done, take a memory dump before and after this action is done with the following command:

    `procdump -ma DataMinerCube.exe`

- When there is a memory leak (for example, opening and closing cards keeps increasing memory usage), take a memory dump before the action and one after the action (for example, when all cards are closed again), with the following command:

    `procdump -ma DataMinerCube.exe`

To avoid taking a memory dump during garbage collection, you can either take multiple memory dumps, or use the *Managed GC Aware Dump tool* instead (see above).

## Tips & tricks

### Compressing memory dumps

Memory dumps often result in large files. However, most of the time, they can be compressed (i.e. zipped) to a fraction of their original size.

### More is better

A memory dump is a snapshot at a single point in time. Often, several snapshots (i.e. memory dumps) will provide a lot more info than just one. This, combined with the fact that memory dumps taken during garbage collecting are unusable, means that it is always better to take more than one memory dump.

### Ask us!

These are just general guidelines for taking memory dumps. If you are not sure about the best strategy to take memory dumps in a specific case, feel free to ask a question on [DataMiner Dojo](https://community.dataminer.services/questions/).
