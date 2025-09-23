---
uid: SLNetClientTest_accessing_script_execution_metrics
---

# Accessing script execution metrics

From DataMiner 10.4.11/10.5.0 onwards<!--RN 40687-->, the DataMiner Automation process generates the following script execution metrics:

- Total number of executed scripts (including scripts that could not be started)

- Total number of failed scripts

- Duration of each script

- Time at which each script was started

- Users who started the scripts

- Result of each script (success of failure)

To view these metrics:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, select *Automation*.

   The *Maintain Automation* window will open.

1. For information about each script execution, go to the *Scripts Statistics* tab and select *Load/Refresh Scripts Statistics* in the lower-left corner.

   ![Scripts Statistics](~/dataminer/images/ScriptsStatistics.jpg)

1. For general information about script executions, go to the *Automation Statistics* tab and select *Load/Refresh Automation Statistics* in the lower-left corner.

   ![Automation Statistics](~/dataminer/images/AutomationStatistics.jpg)

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
