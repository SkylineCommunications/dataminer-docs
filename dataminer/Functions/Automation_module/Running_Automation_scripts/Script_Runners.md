---
uid: Script_Runners
---

# Script runners

From DataMiner 10.6.9/10.7.0 <!-- RN 45557 --> onwards, automation scripts can be grouped by solution and executed in a so-called script runner. A script runner is a separate `SLAutomation.ScriptRunner` process that runs the scripts of a single solution outside of the main DataMiner SLAutomation process.

By grouping scripts per solution, the execution of a solution's scripts is isolated from the scripts of other solutions. The main benefit of this is that DLL dependencies are handled per solution: the dependencies loaded by a script in one solution cannot influence or conflict with the dependencies of a script in another solution.

## Configuring a script to execute in a runner

A script is executed in a runner when the [SolutionId](xref:DMSScript.SolutionId) tag is defined in its script XML. This tag contains a free-form name that identifies the solution.

All scripts that share the same `SolutionId` value are grouped together and executed in the same script runner. Scripts without a `SolutionId` keep running in the DataMiner SLAutomation process like before.

> [!NOTE]
> The recommended way to develop automation scripts is as a Visual Studio solution. In that case, do not set the `SolutionId` tag manually. Instead, add a `DataMinerSolutionId` property to the `.csproj` or `.props` file of the scripts that should run in the same runner. The `SolutionId` tag is then set automatically in the resulting automation script XML. For more information, see [Getting started with automation script development](xref:GettingStartedWithAutomationScriptDevelopment).

## Number of runners in a system

Under normal circumstances, only one runner is active per solution, and all scripts of that solution are executed in it.

Multiple runners can be active for the same solution only temporarily, when a runner is invalidated. When a solution is updated, its existing runner is invalidated:

- The invalidated runner finishes the executions that are still running in it.
- Any new script execution for that solution is started in a new runner.

This way, new or changed DLL dependencies in the updated solution do not conflict with the dependencies that were already loaded in the previous runner. Once an invalidated runner has finished all its work, it is shut down.

A runner that has been idle for more than one hour is automatically stopped. When a script of the solution is executed again afterwards, a new runner is started for it.

The following maximum limits apply:

- A maximum of 50 runners can be active at the same time across the entire system.
- A maximum of 10 runners can be active at the same time for a single solution.

> [!NOTE]
>
> - A script executed in a runner can run for a maximum of 12 hours. When a script exceeds this duration, its execution is stopped.
> - Scripts executed in a runner do not have the `C:\Skyline DataMiner\Files` hint path added by default. If your script references DLLs located in that folder, you must explicitly add the hint path in the script. However, avoid referencing DLLs from this folder or adding the hint path, as this can lead to conflicts with dependencies from DataMiner.
