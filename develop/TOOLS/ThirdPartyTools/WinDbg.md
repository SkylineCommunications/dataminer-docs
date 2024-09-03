---
uid: WinDbg
---

# WinDbg

[WinDbg](https://learn.microsoft.com/en-us/windows-hardware/drivers/debugger/) is a tool for debugging that can be used for analyzing crash dumps, debugging live user-mode and kernel-mode code, and examine CPU registers and memory.

![WinDbg](~/develop/images/WinDbg.png)<br>*WinDbg*

## Useful commands

The following table contains an overview of some useful commands for investigating a dump.

|Command  |Description  |
|---------|---------|
|.lastevent     |The .lastevent command displays the most recent exception or event that occurred.         |
|!threads \[-live\] \[-special\]     |Show all managed threads         |
|!dumpstack \[-ee\]     |Show (managed) call stack         |
|!analyze \[-v\] \[-hang\]     |Analyze exception data         |
|!eeheap -gc     |Show managed heap size         |
|!dumpheap \[-stat\] \[-mt <>\] \[-type <>\] \[-strings\] \[-min\] \[-max\]     |Lists types and the space they take on the managed heap.         |
|!gcgen \<objectAddr>\     |Displays the GC generation of the specified object.         |
|!gcroot \<objectAddr\> \[-nostacks\]     |Find how an object reference is reachable.        |
|!dumpdomain     |Display app-domains info (e.g. all assemblies loaded in the AppDomain)         |
