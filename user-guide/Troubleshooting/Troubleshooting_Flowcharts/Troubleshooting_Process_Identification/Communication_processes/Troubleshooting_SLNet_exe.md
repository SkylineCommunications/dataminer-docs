---
uid: Troubleshooting_SLNet_exe
---

# SLNet.exe

## About SLNet

SLNet controls all communication among DataMiner Agents, and between DataMiner Agents and their clients, including:

- Message handling and dispatching of messages coming from Cube or other sources

- Communication between DMAs in the cluster

- Correlation engine

- Filtering for alarm forwarding

- Failover switchover detection

- Caches trending data queries

## SLNet troubleshooting flowchart

<div class="mermaid">
flowchart TD
%% -------------------------------------------------------------------------
%% SLNet flowchart - main page
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
%% flowchart structure
%% -------------------------------------------------------------------------
  HOME([Start page])
  START([SLNet problem <br />suspected])
  MODULES{{Which symptom?}}
    CORR[[Correlation engine<br/>issues]]
    STARTUP[[DMA startup<br/>issues]]
    DISC[[DMA disconnect<br/>issues]]
%% FAILOVER case to be defined later (uncomment next line):
%% FAILOVER[[Failover<br/>issues]]
    THREAD[[Thread<br/>issues]]
    OTHER[[Follow generic<br/>investigation path]]
     START --- MODULES
	 MODULES --- |Startup| STARTUP
	 MODULES --- |Correlation| CORR
%% FAILOVER case to be defined later (uncomment next line):
%% MODULES --- |Failover|FAILOVER
   MODULES --- |Disconnects| DISC
	 MODULES --- |RTEs| THREAD
   MODULES --- |Other| OTHER
%% -------------------------------------------------------------------------	
%% all blocks terminating at a common End?
%% -------------------------------------------------------------------------
%%    ENDING([End])
%%	  OTHER --- ENDING
%%    STARTUP --- ENDING
%%    DISC --- ENDING
%%    FAILOVER --- ENDING
%%    CORR --- ENDING
%% 	  THREAD --- ENDING
%% -------------------------------------------------------------------------
%% Define hyperlinks %%
%% -------------------------------------------------------------------------
click HOME "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
click STARTUP "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Communication_processes/SLNet/Troubleshooting_SLNet_Startup.html"
click CORR "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Communication_processes/SLNet/Troubleshooting_SLNet_Correlation_Engine.html"
click DISC "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Communication_processes/SLNet/Troubleshooting_SLNet_Disconnects.html" "Go to disconnect cases"
click THREAD "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Communication_processes/SLNet/Troubleshooting_SLNet_RTEs.html"
click OTHER "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
%% -------------------------------------------------------------------------
%% Apply styles to blocks
%% -------------------------------------------------------------------------
class OTHER,CORR,THREAD,FAILOVER,DISC,STARTUP classActionClickable;
class MODULES classDecision;
class START classTerminal;
class HOME classExternalRef;
</div>

### Configuring SLNet settings

Many of the settings for the SLNet process can be tweaked and fine-tuned. For more information, see [Configuring SLNet settings in MaintenanceSettings.xml](xref:Configuration_of_DataMiner_processes#configuring-slnet-settings-in-maintenancesettingsxml).
