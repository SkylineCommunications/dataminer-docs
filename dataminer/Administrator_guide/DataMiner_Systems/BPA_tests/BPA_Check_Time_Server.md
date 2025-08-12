---
uid: BPA_Check_Time_Server
---

# Check Time Server

DataMiner relies on the server time to synchronize data. For this reason, the time of DataMiner Agents in a cluster must be synchronized using an NTP server.

This test will check if the NTP server settings are configured correctly and all the DataMiner Agents use the same NTP server to get their time.

## Metadata

- Name: Check Time Server
- Description: BPA test to check NTP server settings of all DMAs in a cluster.
- Author: Skyline Communications
- Default schedule: Every day

## Results

### Success

- For all successful responses, the detailed results will contain the NTP server per Agent, for example:

  `Agent {agentName} (id: {dma id}) uses time server '{NTP server name}'.`

- In case the cluster only consists of one Agent (this always succeeds):

  `All agents in the cluster use the same NTP server ([timeserver]).`

- If all DataMiner Agents are configured correctly and use the same NTP server:

  `All DMAs use the same time server ([timeserver]).`

### Error

For all errors:

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

  - Result message: `Not all NTP servers are reachable.`.
  - Detailed results: `Agent {agentName} (id: {dma id}) uses NTP server '{NTP server name}'. The Stratum of this server is 0. Stratum 0 indicates the configured NTP server cannot distribute time.` (one line for each Agent)

- No DMA has an NTP server configured.

  - Result message: `No agent in the cluster has an NTP server configured.`
  - Detailed results: `Agent {agentName} (id: {dma id}) uses NTP server: 'None'`

### Not Executed

When the test fails to execute for unexpected reasons and cannot provide a conclusive report because of this, the following message will be shown:

`Could not execute test (*[message]*)`

In the message above, the exception message is included (e.g. `Access Denied`). The test result details contain the full exception text, if available.

## Limitations

- This BPA test can only be run in a DataMiner cluster.
- Offline Failover Agents are not checked.
