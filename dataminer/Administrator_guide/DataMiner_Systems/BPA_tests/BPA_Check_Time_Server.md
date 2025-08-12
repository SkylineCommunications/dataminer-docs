---
uid: BPA_Check_Time_Server
---

# Check Time Server BPA

## Best Practice

DataMiner relies on the server time to synchronize data.
For this reason, the time of DataMiner Agents in a cluster must be synchronized using an NTP server.
This test will check if the NTP server settings are configured correctly and all the DataMiner Agents use the same NTP server to get their time.

## Meta data

* Name: Check Time Server
* Description: "BPA test to check NTP server settings of all DMAs in a cluster."
* Author: Skyline Communications
* Default schedule: Every day

## Results

### Success

For all successful responses the detailed results will contain the NTP server per agent, e.g.:

"Agent {agentName} (id: {dma id}) uses time server '{NTP server name}'."

1. The cluster only exists of one agent (this always succeeds):

"All agents in the cluster use the same NTP server ([timeserver]).""

2. If all DataMiner Agents are configured correctly and use the same NTP server:

"All DMAs use the same time server ([timeserver])."


### Error

For all errors:
- The outcome is 'IssuesDetected'.
- The impact is 'Synchronization of the DMS might be compromised'.
- The CorrectiveAction is 'Make sure the NTP servers are correctly set up and synchronized'.

1. An unexpected exception occurred while retrieving the NTP server details (no results at all):

ResultMessage: "Test was not executed: not all agents in the cluster could be reached."
Detailed results: "Invoking the check cluster-wide did not return a result."

2. Not all agents returned a successful response:

ResultMessage: "Test was not executed: not all agents in the cluster could be reached."
Detailed results: 
"Could not retrieve the information of the following agents: 
- [Agent x]: [Error]
...
"

3. Not all NTP servers are reachable:

ResultMessage: "Not all NTP servers are reachable.".
Detailed results:
"Agent {agentName} (id: {dma id}) uses NTP server '{NTP server name}'. The Stratum of this server is 0. Stratum 0 indicates the configured NTP server cannot distribute time."
(one line for each agent)


4. No DMA has an NTP server configured.
ResultMessage: "No agent in the cluster has an NTP server configured."
Detailed results:
"Agent {agentName} (id: {dma id}) uses NTP server: 'None'"


### Not Executed

These are the messages that can appear when the test fails to execute for unexpected reasons, and cannot provide a conclusive report because of this:

* "Could not execute test (*[message]*)" (on unexpected exceptions). 

In the message above, the exception message is included (e.g. "Access Denied"). The test result details contain the full exception text, if available.

## Limitations

* This BPA test can only be run in a DataMiner cluster.
* Offline failover agents are not checked.
