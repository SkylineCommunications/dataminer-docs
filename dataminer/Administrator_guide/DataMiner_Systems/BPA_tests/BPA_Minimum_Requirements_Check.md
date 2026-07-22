---
uid: BPA_Minimum_Requirements_Check
description: "Learn how the DataMiner Agent Minimum Requirements BPA test checks whether the hardware requirements are met and the time server settings are correct."
---

# DataMiner Agent Minimum Requirements

This BPA test is available by default. Prior to DataMiner 10.4.12/10.5.0 [CU10]<!--RN 40751-->, it is available under the name "Minimum Requirements Check".

This BPA test checks several requirements:

- It checks whether the following minimum hardware requirements are met or exceeded, via local WMI queries using .NET Libraries:

  - CPU cores (physical): 4
  - Disk size:

    - Main installation (C:\\): 128 GB
    - Cassandra installation (D:\\ or other): 600 GB

  - Disk usage: Less than 50% on Cassandra drive.
  - System memory: 16 GB

- From DataMiner 10.6.8/10.7.0 onwards<!-- RN 45631 -->, it checks the **time server settings**. In earlier DataMiner versions, this is checked by a separate [Check Time Server](xref:BPA_Check_Time_Server) BPA test.

  DataMiner relies on the server time to synchronize data, so the time of all DataMiner Agents in a cluster must be synchronized using an NTP server. The BPA test verifies that the NTP server settings are configured correctly and that all DataMiner Agents use the same NTP server to get their time, reporting issues if the configuration could lead to time drift across the DataMiner Agents.

> [!NOTE]
>
> - Prior to DataMiner 10.6.0 [CU0]/10.5.12, this BPA test requires a disk size of 300 GB for the main installation and 32 GB system memory.<!-- RN 43913 --> However, the requirements indicated on this page are sufficient for most systems.
> - From DataMiner 10.6.8/10.7.0 onwards<!-- RN 45631 -->, this BPA is only run once per cluster, aggregating results from all DataMiner nodes in the cluster.

> [!TIP]
> For more information on system requirements, see [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).

If you are using a [DaaS system](xref:Creating_a_DMS_in_the_cloud), your entire DataMiner setup is automatically configured for optimal performance. As such, this BPA test cannot be run on a DaaS system. From DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 onwards<!--RN 39929-->, this BPA test will by default have the status *Not applicable* on a DaaS system.

## Metadata

- Name: DataMiner Agent Minimum Requirements
- Description: Uses WMI queries to verify that the system meets the minimum requirements for DataMiner.
- Author: Skyline Communications
- Default schedule: Every hour

## Results

This BPA test reports on two categories of checks:

- *Minimum requirements*: CPU cores, disk size, disk usage, and system memory.
- *Time Server Settings*: The NTP server configuration of the DataMiner Agents in the cluster.

### Success

If the system meets or exceeds all minimum hardware requirements, the test will have the following result:

`Test succeeded: System meets all minimum requirements.`

For the time server settings, the detailed results contain the NTP server per Agent, for example:

`Agent {agentName} (id: {dma id}) uses time server '{NTP server name}'.`

Depending on the configuration, one of the following messages is shown:

- In case the cluster only consists of one Agent (this always succeeds):

  `All DataMiner Agents in the cluster use the same NTP server ([timeserver]).`

- If all DataMiner Agents are configured correctly and use the same NTP server:

  `All DataMiner Agents have the same NTP server configured ([timeserver]).`

- If multiple NTP servers have been detected, but they are peers of one another:

  `Multiple NTP servers have been detected, but they are peers of one another.`

- If multiple NTP servers have been detected that are not peers of one another, but the Agent clocks nevertheless agree within one second:

  `Multiple NTP servers detected that are not peers of one another, but agent clocks agree within 1 second (measured difference up to {X} seconds).`

  This message can be shown from DataMiner 10.6.9/10.7.0 onwards<!-- RN 45661 --> and was introduced to support hybrid clusters. The detailed results also list the measured clock offset per Agent, for example:

  `Clock offsets between agents (relative to the slowest clock): {agentName} (id: {dma id}) +0.000s (±0.000s); ...`

### Error

#### Errors related to minimum hardware requirements

`X of 5 minimum requirements were not met. See detailed result to obtain more information.`

One or more of the minimum requirements is not met.

The detailed JSON output of the BPA will contain the following possible messages, depending on which requirements are not met:

- CPU cores: `Failed CPU Check: X cores available, 4 are required.` or `Passed CPU Check: X cores available, 4 are required.` (where X is the number of physical cores in the system).

- Disk size (main): `Failed Main Installation Disk Size Check: Disk X has Y GB, 128 GB is required.` or `Passed Main Installation Disk Size Check: Disk X has Y GB, 128 GB is required.` (where X is the installed disk and Y is the total volume of the disk).

- Disk size (database): `Failed Database Disk Size Check: Disk X has Y GB, 600 GB is required.` or `Passed Database Disk Size Check: Disk X has Y GB, 600 GB is required.` (where X is the disk on which DataMiner is installed and Y is the total volume of the disk).

- Disk free space: `Failed Database Disk Free Space Check: Disk X has Y % Available Free Space. 50% or more is required.` or `Passed Database Disk Free Space Check: Disk X has Y % Available Free Space. 50% or more is required.` (where X is the disk on which Cassandra is installed, and Y is its free space).

- Memory: `Failed Memory Check: The system has X GB Total Visible Memory, 16 GB is required.` or `Passed Memory Check: The system has X GB Total Visible Memory, 16 GB is required.` (where X is the visible memory, as seen in the control panel).

#### Errors related to time server settings

For all time server errors:

- The outcome is `IssuesDetected`.
- The impact is `Synchronization of the DMS might be compromised`.
- The corrective action is `Make sure the NTP servers are correctly set up and synchronized`.

The following errors are possible:

- An unexpected exception occurred while retrieving the NTP server details (no results at all):

  - Result message: `Test was not executed: not all agents in the cluster could be reached.`
  - Detailed results: `Invoking the check cluster-wide did not return a result.`

- Not all Agents returned a successful response:

  - Result message: `Test was not executed: not all agents in the cluster could be reached.`
  - Detailed results:

    ```txt
    Could not retrieve the information of the following agents: 
    - [Agent x]: [Error]
    ...
    ```

- Not all NTP servers are reachable:

  - Result message: `Not all NTP servers are reachable.`
  - Detailed results: `Agent {agentName} (id: {dma id}) uses NTP server '{NTP server name}'. The Stratum of this server is 0. Stratum 0 indicates the configured NTP server cannot distribute time.` (one line for each Agent)

- No DMA has an NTP server configured:

  - Result message: `No agent in the cluster has an NTP server configured.`
  - Detailed results: `Agent {agentName} (id: {dma id}) uses NTP server: 'None'`

- From DataMiner 10.6.9/10.7.0 onwards<!-- RN 45661 -->, if multiple NTP servers are detected that are not peers of one another, and the measured clock difference between Agents exceeds 5 seconds:

  - Result message: `Multiple NTP servers detected that are not peers of one another, and agent clocks differ by up to {X} seconds, which exceeds the 5 second threshold.`
  - Detailed results: The per-Agent clock offsets, for example `Clock offsets between agents (relative to the slowest clock): {agentName} (id: {dma id}) +0.000s (±0.000s); ...`

### Warning

The following warnings related to the time server settings are possible:

- If the NTP server could not be retrieved from all DataMiner Agents:

  - Result message: `The NTP server could not be retrieved from all DataMiner Agents.`

- If multiple NTP servers are detected and they are not peers of one another:

  - From DataMiner 10.6.9/10.7.0 onwards<!-- RN 45661 -->, if the measured clock difference between Agents is more than 1 second but does not exceed 5 seconds:

    `Multiple NTP servers detected that are not peers of one another, and agent clocks differ by up to {X} seconds, which exceeds the 1 second threshold.`

  - From DataMiner 10.6.9/10.7.0 onwards<!-- RN 45661 -->, if the clock difference between Agents could not be measured (the Agents did not respond with their time):

    `Multiple NTP servers detected that are not peers of one another. The clock offset between agents could not be measured (the agents did not respond with their time).`

    In earlier DataMiner versions, this situation always results in the following warning: `Multiple NTP servers detected that are not peers of one another.`

### Not Executed

These are the messages that can appear when the test fails to execute for unexpected reasons, and cannot provide a conclusive report because of this:

`Could not execute test ([message])` (on unexpected exceptions).

In the message above, the exception message is included (e.g., "Access Denied"). The test result details contain the full exception text, if available.

## Limitations

- The BPA only checks if the minimum requirements to run a DataMiner Agent are met. It only checks if the system has the bare minimum to be able to operate, not if it has adequate resources for its load.
- The BPA uses standard WMI querying in order to retrieve information. This must be enabled and functional in order for the test to run.
