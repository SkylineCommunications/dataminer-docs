---
uid: Script_Runners
---

# Script Runners

From DataMiner 10.6.10/10.7.0 <!-- RN 45557 --> onwards, automation scripts can be grouped by solution and executed in a *Script Runner*. A Script Runner is a separate `SLAutomation.ScriptRunner` process that runs the scripts of a single solution outside of the main DataMiner SLAutomation process.

By grouping scripts per solution, the execution of a solution's scripts is isolated from the scripts of other solutions. The main benefit is that DLL dependencies are handled per solution: the dependencies loaded by a script in one solution cannot influence or conflict with the dependencies of a script in another solution.

## Configuring a script to execute in a Runner

A script is executed in a Runner when the [`SolutionId`](xref:DMSScript.SolutionId) tag is defined in its script XML. This tag contains a free-form name that identifies the solution.

All scripts that share the same [`SolutionId`](xref:DMSScript.SolutionId) value are grouped together and executed in the same Script Runner. Scripts without a [`SolutionId`](xref:DMSScript.SolutionId) keep running in the DataMiner SLAutomation process as before.

## Number of Runners in a system

Under normal circumstances, only one Runner is active per solution, and all scripts of that solution are executed in it.

Multiple Runners can be active for the same solution only temporarily, when a Runner is invalidated. When a solution is updated, its existing Runner is invalidated:

- The invalidated Runner finishes the executions that are still running in it.
- Any new script execution for that solution is started in a new Runner.

This way, new or changed DLL dependencies in the updated solution do not conflict with the dependencies that were already loaded in the previous Runner. Once an invalidated Runner has finished all its work, it is shut down.

A Runner that has been idle for more than one hour is automatically stopped. When a script of the solution is executed again afterwards, a new Runner is started for it.

The following maximum limits apply:

- A maximum of 50 Runners can be active at the same time across the entire system.
- A maximum of 10 Runners can be active at the same time for a single solution.

> [!NOTE]
>
> - A script executed in a Runner can run for a maximum of 12 hours. When a script exceeds this duration, its execution is stopped.
> - Scripts executed in a Runner do not have the `C:\Skyline DataMiner\Files` hint path added by default. If your script references DLLs located in that folder, you must explicitly add the hint path in the script. However, avoid referencing DLLs from this folder or adding the hint path, as this can lead to conflicts with dependencies from DataMiner.
