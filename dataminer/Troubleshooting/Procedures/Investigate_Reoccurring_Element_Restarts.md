---
uid: Investigate_Reoccurring_Element_Restarts
---

# Investigating reoccurring element restarts due to process crashes

Starting from DataMiner 10.6.3/10.7.0 all elements hosted in an SLScripting process that crashed will be restarted **if DataMiner is not explicitly configured to only use 1 SLScripting process**.
Similarly, starting from DataMiner 10.4.12/10.5.0 all elements hosted in a SLProtocol that crashed will automatically be restarted.
This allows automated recovery of a process crash, without leaving the elements in a possible incorrect state.
However, due to this mechanism it is possible that 1 faulty element causes all other elements in the same process to be restarted frequently.
The following steps help pinpoint which element is causing the restarts.

1. Open the [Elements in protocol logging](xref:Element_in_Protocol_logging).
2. Scroll to the bottom, and find the entries for the elements that are being restarted repeatedly due to process crashes. These are indicated by the `SLScriptingCrashRestart`/`SLProtocolCrashRestart` values in the restart reason column (if everything is OK, `NormalStart` would be shown instead).
The log output will look like this:
```
2026/01/12 12:22:21|911/3127|<MyElementName1>|<MySLProtocolPid>|<MyProtocolName1>|Production|1.0.0.1|<MySLScriptingPid>|SLProtocolCrashRestart|1|0|2
2026/01/12 12:22:21|911/3117|<MyElementName2>|<MySLProtocolPid>|<MyProtocolName2>|Production|1.0.0.1|<MySLScriptingPid>|SLScriptingCrashRestart|1|0|2
2026/01/12 12:22:21|911/3114|<MyElementName3>|<MySLProtocolPid>|<MyProtocolName3>|Production|1.0.0.1|<MySLScriptingPid>|SLScriptingCrashRestart|1|0|2
```
3. Every element that has the same `<MySLScriptingPid>`/`<MySLProtocolPid>` value and non-`NormalStart` startup reason, will have been restarted due to the same process crash. For each of these entries, find the element in Cube and enable [isolation mode](https://docs.dataminer.services/release-notes/Cube/Cube_Feature_Release_10.5/Cube_10.5.4.html#elements-can-now-be-configured-to-run-in-isolation-mode-id-41758). Enabling isolation mode ensures that each element runs in its own dedicated SLProtocol and SLScripting process. As a result, if a crash occurs again, only the element responsible causing the crash will restart, preventing any impact on the other elements.
4. Once all elements have been put into isolation mode, wait until a new crash happens. Open the [Elements in protocol logging](xref:Element_in_Protocol_logging), and check which elements have new crash restart entries. These are the problematic elements. Troubleshoot these elements and their protocols yourself or reach out to [DataMiner Support](xref:Contacting_tech_support) to help identify what is causing the process crashes.
5. For all non-problematic elements, disable the isolation mode to reduce the load on the system.
