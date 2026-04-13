---
uid: WinDbg
---

# WinDbg

[WinDbg](https://learn.microsoft.com/en-us/windows-hardware/drivers/debugger/) is a tool for debugging that can be used for analyzing crash dumps, debugging live user mode and kernel mode code, and examining CPU registers and memory.

![WinDbg](~/develop/images/WinDbg.png)<br>*WinDbg*

## Commands

The following table contains an overview of some useful commands.

| Command                                                                    | Description                                                               |
|----------------------------------------------------------------------------|---------------------------------------------------------------------------|
| `k`                                                                        | Displays the stack frame of the given thread with related information.    |
| `r`                                                                        | Displays the registers.                                                   |
| `d`                                                                        | Displays the contents of memory in the specified range.                   |
| `u <address>`                                                              | Displays an assembly translation of the specified program code in memory. |
| `~<Id>s`                                                                   | Sets the current thread number in user mode.                              |

For more detailed information about these commands and an overview of more commands, refer to [Commands](https://learn.microsoft.com/en-us/windows-hardware/drivers/debuggercmds/commands).

## Meta-commands

The following table contains an overview of some useful meta-commands.

| Command                                                                    | Description                                                               |
|----------------------------------------------------------------------------|---------------------------------------------------------------------------|
| `.lastevent`                                                               | Displays the most recent exception or event that occurred.                |
| `.cls`                                                                     | Clears the Debugger Command window display.                               |
| `.ecxr`                                                                    | Displays the context record that is associated with the current exception.|
| `.load`, `.loadby`                                                         | Loads the specified extension DLL into the debugger.                      |

For an overview of more meta-commands, refer to [Meta-Commands](https://learn.microsoft.com/en-us/windows-hardware/drivers/debuggercmds/meta-commands).

## General extension commands

The following table contains an overview of some useful general extension commands.

| Command                                                                    | Description                                                               |
|----------------------------------------------------------------------------|---------------------------------------------------------------------------|
| `analyze [-v] [-hang]`                                                     | Analyzes exception data.                                                  |

For an overview of more commands, refer to [General Extension Commands](https://learn.microsoft.com/en-us/windows-hardware/drivers/debuggercmds/general-extensions).

## SOS debugger extension commands

The SOS debugger extension allows to retrieve information about the Common Language Runtime (CLR) environment.

The following table contains an overview of some useful commands for investigating managed memory and code of a dump using the SOS debugger extension.

> [!TIP]
> To obtain more information about how to use a command, type `!help <commandName>`. For example: `!help ClrStack`.

> [!NOTE]
> When a command from this table is executed in WinDbg, the command must be prefixed with `!`.

| Command                                                                    | Description                                                               |
|----------------------------------------------------------------------------|---------------------------------------------------------------------------|
| `ClrStack [-a] [-l] [-p] [-m]`                                             | Provides a stack trace of managed code only.                              |
| `DumpClass <EEClassAddress>`                                               | Displays information about the EEClass structure associated type.         |
| `DumpDomain`                                                               | Displays app domains info (e.g., all assemblies loaded in the app domain). |
| `DumpHeap [-stat] [-mt <>] [-type <>] [-strings] [-min] [-max]`            | Lists types and the space they take on the managed heap.                  |
| `DumpMD <MethodDescAddress>`                                               | Displays information about a MethodDesc structure at the specified address. |
| `DumpMT <MethodTableAddress>`                                              | Displays information about a method table at the specified address.       |
| `DumpObj <ObjAddress>`                                                     | Displays information about an object at the specified address.            |
| `DumpStack [-ee]`                                                          | Shows the (managed) call stack.                                           |
| `DumpStackObjects`                                                         | Displays all managed objects found within the bounds of the current stack.|
| `DumpVC <MethodTableAddress> <Address>`                                    | Displays information about the fields of a value class at the specified address. |
| `EEHeap -gc`                                                               | Displays information about process memory consumed by internal CLR data structures. |
| `EEStack`                                                                  | Runs the DumpStack command on all threads in the process.                 |
| `EEVersion`                                                                | Displays the CLR version.                                                 |
| `FinalizeQueue [-detail] [-allReady] [-short]`                             | Displays all objects registered for finalization.                         |
| `GCRoot <objectAddr> [-nostacks]`                                          | Checks how an object reference is reachable.                              |
| `Help <commandName>`                                                       | Displays detailed help information about the specified command.           |
| `IP2MD <Code address>`                                                     | Displays the MethodDesc structure at the specified address in code that has been JIT-compiled. |
| `Name2EE <module name> <type or method name>`                           | Displays the MethodTable structure and EEClass structure for the specified type or method in the specified module. |
| `ObjSize [<Object address>] [-aggregate] [-stat]`                   | Displays the size of the specified object.                                |
| `SaveModule <Base address> <Filename>`                                  | Writes an image, which is loaded in memory at the specified address, to the specified file.|
| `Threads [-live] [-special]`                                            | Shows all managed threads.                                                |
| `U  <MethodDesc address> \| <Code address>`                             | Displays an annotated disassembly of a specified managed method.          |
| `VerifyHeap`                                                                | Checks the garbage collector heap for signs of corruption and displays any errors found. |

For an overview of all commands, refer to [SOS.dll (SOS debugging extension)](https://learn.microsoft.com/en-us/dotnet/framework/tools/sos-dll-sos-debugging-extension).

## SOSEX debugger extension commands

The Son of Strike Extension (SOSEX), created by Steve Johnson, provides additional commands and features, such as deadlock detection and improved diagnostics for .NET applications.

This extension can be downloaded [here (32 bit)](http://www.stevestechspot.com/downloads/sosex_32.zip) or [here (64 bit)](http://www.stevestechspot.com/downloads/sosex_64.zip).

The following table gives an overview of these additional commands.

> [!NOTE]
>
> - When a command from this table is executed in WinDbg, the command must be prefixed with `!`.
> - This extension is not loaded by default in WinDbg. To load it, use `.load <filePathToSosexAssembly>`. Note that for analyzing a 32-bit process, the 32-bit version of the DLL should be loaded.

|Command  |Description  |
|---------|---------|
|`bhi [filename]`                                          | BuildHeapIndex - Builds an index file for heap objects.         |
|`chi`                                                     | ClearHeapIndex - Frees all resources used by the heap index and removes it from memory. |
|`dlk  [-d]`                                               | Displays deadlocks between SyncBlocks and/or ReaderWriterLocks.        |
|`dumpfd    <FieldAddr>`                                   | Dumps the properties of a FieldDef structure.         |
|`dumpgen   <GenNum> [-free] [-stat] [-type <TYPE_NAME>] [-nostrings] [-live] [-dead] [-short]` | Dumps the contents of the specified generation.         |
|`finq      [GenNum] [-stat]`                              | Displays objects in the finalization queue.         |
|`frq       [-stat]`                                       | Displays objects in the Freachable queue.         |
|`gcgen     <ObjectAddr>`                                  | Displays the GC generation of the specified object.        |
|`gch       [HandleType]... [-stat]`                       | Lists all GCHandles, optionally filtered by specified handle types.        |
|`help      [CommandName]`                                 | Displays details about the specified command        |
|`lhi       [filename]`                                    | LoadHeapIndex - Loads the heap index into memory.        |
|`mbc       <SOSEX breakpoint ID \| *>`                    | Clears the specified or all managed breakpoints. |
|`mbd       <SOSEX breakpoint ID \| *>`                    | Disables the specified or all managed breakpoints. |
|`mbe       <SOSEX breakpoint ID \| *>`                    | Enables the specified or all managed breakpoints. |
|`mbl       [SOSEX breakpoint ID]`                         | Prints the specified or all managed breakpoints. |
|`mbm       <Type/MethodFilter> [ILOffset] [Options]`      | Sets a managed breakpoint on methods matching the specified filter. |
|`mbp       <SourceFile> <nLineNum> [ColNum] [Options]`    | Sets a managed breakpoint at the specified source code location. |
|`mdso      [Options]`                                     | Dumps object references on the stack and in CPU registers in the current context. |
|`mdt       [TypeName \| VarName \| MT] [ADDR] [Options]`  | Displays the fields of an object or type, optionally recursively. |
|`mdv       [nFrameNum]`                                   | Displays arguments and locals for a managed frame. |
|`mfrag     [-stat] [-mt:<MT>]`                            | Reports free blocks, the type of object following the free block, and fragmentation statistics. |
|`mframe    [nFrameNum]`                                   | Displays or sets the current managed frame for the !mdt and !mdv commands. |
|`mk        [FrameCount] [-l] [-p] [-a]`                   | Prints a stack trace of managed and unmanaged frames. |
|`mln       [expression]`                                  | Displays the type of managed data located at the specified address or the current instruction pointer. |
|`mlocks    [-d]`                                          | Lists all managed lock objects and CriticalSections and their owning threads. |
|`mroot     <ObjectAddr> [-all]`                           | Displays GC roots for the specified object. |
|`mt`                                                      | Steps into the managed method at the current position. |
|`mu        [address] [-s] [-il] [-n]`                     | Displays a disassembly around the current instruction with interleaved source, IL, and asm code. |
|`muf       [MD Address \| Code Address] [-s] [-il] [-n]`  | Displays a disassembly with interleaved source, IL, and asm code. |
|`mwaits    [-d \| LockAddr]`                              | Lists all waiting threads and, if known, the locks they are waiting on. |
|`mx        <Filter String>`                               | Displays managed type/field/method names matching the specified filter string. |
|`rcw       [Object or SyncBlock Addr]`                    | Displays Runtime Callable Wrapper (RCW) COM interop data. |
|`refs      <ObjectAddr> [-target\|-source]`               | Displays all references from and to the specified object. |
|`rwlock    [ObjectAddr \| -d]`                            | Displays all RWLocks or, if provided a RWLock address, details of the specified lock. |
|`sosexhelp [CommandName]`                                 | Display this screen or details about the specified command. |
|`strings   [ModuleAddress] [Options]`                     | Searches the managed heap or a module for strings matching the specified criteria. |

## See also

- [WinDbg Overview](https://learn.microsoft.com/en-us/windows-hardware/drivers/debuggercmds/windbg-overview)
- [Thread syntax](https://learn.microsoft.com/en-us/windows-hardware/drivers/debuggercmds/thread-syntax)
- [Using Debugger Extensions](https://learn.microsoft.com/en-us/windows-hardware/drivers/debuggercmds/debugger-extensions)
