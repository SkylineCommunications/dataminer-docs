---
uid: Troubleshooting_SLNet_Disconnects
---

# SLNet - disconnects

> [!NOTE]
> This page is currently still being developed. The content is not yet optimized and may not yet be fully accurate.

```mermaid
flowchart TD
%% -------------------------------------------------------------------------
%% SLNet flowchart - disconnects branch
%% -------------------------------------------------------------------------
%% -------------------------------------------------------------------------
%% Define styles
%% -------------------------------------------------------------------------
linkStyle default stroke:#cccccc
classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:1px;
classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:1px;
classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:1px;
classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:1px;
classDef classSolution fill:#58595b,stroke:#58595b,color:#ffffff,stroke-width:1px;
classDef classAction fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:1px;
%% -------------------------------------------------------------------------
%% flowchart blocks and flow
%% -------------------------------------------------------------------------
  Home([Start page])
  Start([DMA seems disconnected])
  Back([Back to SLNet troubleshooting])
  Start --- WhatSymtoms
  WhatSymtoms{{What is the symptom?}}
  WhatSymtoms --- |Agent is disconnected or connection is lost| IsAgentRunning
  WhatSymtoms --- |Callback timeouts| VerifyCallback
  WhatSymtoms --- |Cannot set up new connections|NoMoreConnections
  WhatSymtoms --- |Refused state message| RefusedState
  %% -----------------------------------------------------------------------
  %% branch: Agent disconnected or lost
  %% -----------------------------------------------------------------------
  IsAgentRunning{{Is the disconnected DMA running?}}
  IsAgentRunning --- |No| StartAgent
  IsAgentRunning --- |Yes| CheckCPUAndMem
  StartAgent[[Start the DMA.]]
  StartAgent --- Ending_3
  CheckCPUAndMem[[Check the CPU and memory resources.]]
  CheckCPUAndMem --- AreResourcesOk
  AreResourcesOk{{Does the disconnected DMA lack resources?}}
  AreResourcesOk --- |No| HasMobileGateway
  AreResourcesOk --- |Yes| LackResources
  LackResources[[Investigate and fix the cause for the lack of resources.]]
  LackResources --- IsIssueFixed_3
  IsIssueFixed_3{{Issue fixed?}}
  IsIssueFixed_3 --- |No| ContactTechsupport_3
  IsIssueFixed_3 --- |Yes| Ending_2
  HasMobileGateway{{Is Mobile Gateway activated on the DMA?}}
  HasMobileGateway --- |Yes| MoblieGatewayActivated
  HasMobileGateway --- |No| NotInSameDomain
  MoblieGatewayActivated{{Is it configured correctly?}}
  MoblieGatewayActivated --- |No| FixMobileGatewaySettings
  MoblieGatewayActivated --- |Yes| NotInSameDomain
  FixMobileGatewaySettings[[Fix the Mobile Gateway settings.]]
  FixMobileGatewaySettings --- IsIssueFixed_1
  IsIssueFixed_1{{Issue fixed?}}
  IsIssueFixed_1 --- |Yes| Ending_1
  IsIssueFixed_1 --- |No| NotInSameDomain
  NotInSameDomain{{Are the DMAs not in the same domain or is the Administrator password not the same accross the cluster?}}
  NotInSameDomain --- |Yes| CheckSLDMS
  NotInSameDomain --- |No| ContactTechsupport
  CheckSLDMS{{Does SLDMS.txt contain 'Authentication failed' messages?}}
  CheckSLDMS --- |Yes| ConfigureConnectionStrings
  CheckSLDMS --- |No| ContactTechsupport
  ConfigureConnectionStrings[[Configure the connection strings.]]
  ConfigureConnectionStrings --- IsIssueFixed_2
  IsIssueFixed_2{{Issue fixed?}}
  IsIssueFixed_2 --- |Yes| Ending_1
  IsIssueFixed_2 --- |No| ContactTechsupport
  %% -----------------------------------------------------------------------
  %% branch: Callback timeouts
  %% -----------------------------------------------------------------------
  VerifyCallback[Verify the callback timeout.]
  VerifyCallback---CallbackVerified
  CallbackVerified{{Are there callback errors in the information events?}}
  CallbackVerified---|No|ContactTechsupport_2
  CallbackVerified---|Yes|ResourcesCheck
  ResourcesCheck{{Is the memory or CPU usage high when the callback timeouts occur?}}
  ResourcesCheck---|Yes|LackResources
  ResourcesCheck---|No|DebugCallback
  DebugCallback[Investigate and fix the cause of the timeouts.]
  DebugCallback --- IsIssueFixed_3
  %% -----------------------------------------------------------------------
  %% branch: Cannot setup new connections
  %% -----------------------------------------------------------------------
  NoMoreConnections[[Check the connections.]]
  %% -----------------------------------------------------------------------
  %% branch: Refused state message
  %% -----------------------------------------------------------------------
  RefusedState[[Investigate the Refused DMA state.]]
%% -------------------------------------------------------------------------
%% Ending: Contact Techsupport
%% -------------------------------------------------------------------------
  ContactTechsupport([Describe the issue in detail and contact DataMiner Support.])
  ContactTechsupport_2([Describe the issue in detail and contact DataMiner Support.])
  ContactTechsupport_3([Describe the issue in detail and contact DataMiner Support.])
%% -------------------------------------------------------------------------
%% Ending: Issue fixed
%% -------------------------------------------------------------------------
  Ending_1([End])
  Ending_2([End])
  Ending_3([End])
%% -------------------------------------------------------------------------
%% Define hyperlinks %%
%% -------------------------------------------------------------------------
 click Home "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html" "Go to Start Page"
 click Back "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Communication_processes/Troubleshooting_SLNet_exe.html"
 click ConfigureConnectionStrings "/dataminer/Reference/MOPs/MOP_Implementing_connection_strings_in_a_DMS.html"
 click CheckCPUAndMem "#cpu-and-memory-resources"
 click LackResources "#cpu-and-memory-resources"
 click VerifyCallback "#about-callback-timeouts"
 click DebugCallback "#how-to-debug-a-callback-timeout-error"
 click RefusedState "/dataminer/Reference/DataMiner_Tools/SLNetClientTest_tool/SLNetClientTest_tool_advanced_procedures/SLNetClientTest_refused_dma_state.html"
 click NoMoreConnections "#cannot-set-up-new-connections"
 click StartAgent "/dataminer/Administrator_guide/DataMiner_Systems/Starting_or_stopping_DMAs/Starting_or_stopping_a_DMA_in_DataMiner_Cube.html"
 click FixMobileGatewaySettings "/dataminer/Functions/Mobile_Gateway/Configuring_Mobile_Gateway/Configuring_a_serial_cell_phone_modem.html"
%% -------------------------------------------------------------------------
%% Apply styles to blocks
%% -------------------------------------------------------------------------
class LackResources,DebugCallback,CheckCPUAndMem,FixMobileGatewaySettings,StartAgent,AGENTDISC,CALLBACK,NoMoreConnections,RefusedState,ConfigureConnectionStrings,VerifyCallback classActionClickable;
%%class LackResources classSolution
class AreResourcesOk,WhatSymtoms,IsAgentRunning,HasMobileGateway,MoblieGatewayActivated,IsIssueFixed_1,IsIssueFixed_3,IsIssueFixed_2,NotInSameDomain,CheckSLDMS,CallbackVerified,ResourcesCheck classDecision;
class Start,Ending_1,Ending_2,Ending_3,ContactTechsupport,ContactTechsupport_2,ContactTechsupport_3 classTerminal;
class Home,Back classExternalRef;
```

## CPU and memory resources

Check the total processor load of the DMA in the Windows Task Manager and/or in the Microsoft Platform element monitoring the DMA. If there is a sudden increase and if it keeps running high, verify if a specific process is consuming most of the CPU load. Note that this could be any process, other than SLNet itself.

When a DMA in a cluster has a high CPU load, it can occur that the DMA appears to be disconnected from its peers. This is because the SLNet calls will be processed more slowly than expected.

For the same reason, also do this check for the total memory usage and the total available memory of the DMA. A low amount of free memory indicates that the DMA is struggling to cope with incoming requests.

Most of the time, such spikes in the CPU load and memory usage are just temporary. If you wait a while, usually a couple of minutes, they should return to their baseline values. If this does not happen, further investigation is needed.

## Callback timeouts

### About callback timeouts

When a client connects to a DataMiner Agent via eventing, and it takes longer than a particular number of seconds (by default 30) to send a packet of events to that client over the callback connection, the server can throw out the client.

In that case, a "callback timeout (waited 30 s)" type error is generated. This mechanism also applies to connections between DataMiner Agents.

Possible reasons for such callback timeouts could be:

- An unreachable destination (e.g., client was stopped or firewall intervened).

- The packet of forwarded data is too large.

### How to verify a callback timeout error

Check the information events to see if users are getting disconnected.

- Look in the information events around the time when the issue was reported to have occurred.

- Look for the message "callback timeout(waited 30 s)". This may be accompanied by users getting disconnected.

### How to debug a callback timeout error

- Verify if the server was lacking free virtual memory around the time the issue occurred. Do the errors clear when the virtual memory or physical memory increases? Then the issue is caused by lack of resources.

- Are there any network communication issues between the DMAs? Check in Windows Event Viewer or check for communication errors in SLDMS. If there are communication issues between DMAs, fix them.

- If you cannot link the issue to a lack of resources or a network communication issue, enable [debugging of callback timeouts](xref:SLNetClientTest_tool_diagnostic_procedures). This will result in the creation of a dump file the next time a callback timeout is generated.

- Increasing the callback timeout is also an option, because some packets might take longer than the default 30s.

## Cannot set up new connections

> [!NOTE]
> Incomplete: This section requires more information.

- Use `netstat -noq` in command prompt to see how many TCP ports are occupied and by which processes.

- Use `telnet 8004` to verify if the connection is possible (if telnet is installed). The same can be done with putty.

- If no more connections can be done:

## Refused state message

The "Refused" state is a protection mechanism to prevent connections between faulty DMAs and a non-faulty DMA. This can happen when:

- A DMA has had too many connections in the last hours as defined in the MaxAgentConnectsPerHour setting.

- A DMA is dropping events because the threshold in the QueuedStackOverflow is exceeded.

When a DMA enters the "Refused" state, other DMAs will refuse connections with it for a period of time (by default 10 minutes). The cause of the refusal is only displayed on the faulty DMA.

The SLNetClientTest tool allows you to view and adjust the mentioned thresholds, and clear the Refused state in case the underlying issue has been resolved. For more information, refer to [Checking or modifying the settings related to a Refused DMA state](xref:SLNetClientTest_tool_diagnostic_procedures).
