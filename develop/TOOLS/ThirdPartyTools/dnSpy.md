---
uid: dnSpy
---

# dnSpy

[dnSpy](https://github.com/dnSpy/dnSpy) is an open-source/freeware tool that can be very useful when you develop DataMiner Automation scripts and connectors. It allows you to debug any assembly, even when you do not have the matching code. It is especially handy to **debug Automation scripts or QActions on a remote system**, in case you cannot connect to the system via DIS. Assemblies can be compiled in release mode, but more information will be available when they are compiled in debug mode.

## How to use

To use this tool to debug Automation scripts or QActions on a remote system, follow the steps below:

1. Download [*dnSpy-netframework*](https://github.com/dnSpy/dnSpy/releases).

1. Copy the file to the remote system you want to debug, and unzip it.

1. Run *dnSpy-x86.exe* as administrator.

1. Select *Debug > Attach to Process*, and select the process you want to debug (e.g. *SLAutomation.exe*, *SLScripting.exe*).

1. Select *Debug > Windows > Modules*, and sort by timestamp in descending order to find the right module.
   This can be tricky, because every time you upload an Automation script or protocol, new assemblies are built, but the old ones remain in memory.

   > [!NOTE]
   > A module is only available after it has run at least once.

1. Use the *Assembly Explorer* on the left-hand side to navigate to the assembly/class/method you want to debug.

1. Add break points and let the code run.

1. Use the *Locals* window to inspect the content of variables.

   > [!NOTE]
   > Hovering over variables is not supported.

1. Detach from the process when you are done.

![dnSpy](~/develop/images/dnSpy.gif)
