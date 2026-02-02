---
uid: Investigate_Reoccurring_Element_Restarts
---

# Investigating reoccurring element restarts due to process crashes

From DataMiner 10.6.3/10.7.0 onwards<!-- 42306/44420 -->, all elements hosted in an SLScripting process that crashes will be restarted **unless DataMiner is explicitly configured to only use one SLScripting process**. Similarly, starting from DataMiner 10.4.12/10.5.0, all elements hosted in an SLProtocol process that crashes will automatically be restarted. This allows automated recovery of a process crash, without leaving the elements in a possible incorrect state.

However, because of this mechanism, it is possible that one faulty element causes all other elements in the same process to be restarted frequently.

To pinpoint which element is causing the restarts, follow the steps below.

1. Open the [Elements in protocol logging](xref:Element_in_Protocol_logging).

1. Scroll to the bottom and find the entries for the elements that are being restarted repeatedly because of process crashes.

   These are indicated by the `SLScriptingCrashRestart`/`SLProtocolCrashRestart` values in the restart reason column (if everything is OK, `NormalStart` is shown instead).

   The log output will look like this:

   ```txt
   2026/01/12 12:22:21|911/3127|<MyElementName1>|<MySLProtocolPid>|<MyProtocolName1>|Production|1.0.0.1|<MySLScriptingPid>|SLProtocolCrashRestart|1|0|2
   2026/01/12 12:22:21|911/3117|<MyElementName2>|<MySLProtocolPid>|<MyProtocolName2>|Production|1.0.0.1|<MySLScriptingPid>|SLScriptingCrashRestart|1|0|2
   2026/01/12 12:22:21|911/3114|<MyElementName3>|<MySLProtocolPid>|<MyProtocolName3>|Production|1.0.0.1|<MySLScriptingPid>|SLScriptingCrashRestart|1|0|2
   ```

   Elements that have been restarted because of the same process crash will all have same `<MySLScriptingPid>`/`<MySLProtocolPid>` value and will not have the `NormalStart` startup reason.

1. For each of these entries, find the element in Cube and [enable isolation mode](xref:Adding_elements#adding-elements-in-isolation-mode).

   Enabling isolation mode ensures that each element runs in its own dedicated SLProtocol and SLScripting process. As a result, if a crash occurs again, only the element responsible causing the crash will restart, preventing any impact on the other elements.

1. Once all elements have been put into isolation mode, wait until a new crash happens, and then open the [Elements in protocol logging](xref:Element_in_Protocol_logging) to check which elements have new crash restart entries.

   These elements are the cause of the problem.

1. Troubleshoot the problem elements and their protocols yourself or reach out to [DataMiner Support](xref:Contacting_tech_support) to help identify what is causing the process crashes.

1. For all non-problematic elements, disable isolation mode to reduce the load on the system.
