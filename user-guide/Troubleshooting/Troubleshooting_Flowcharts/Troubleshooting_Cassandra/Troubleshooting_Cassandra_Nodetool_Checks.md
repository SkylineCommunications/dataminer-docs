---
uid: Troubleshooting_Cassandra_Nodetool_Checks
---

# Troubleshooting - Cassandra: nodetool checks

## About the nodetool utility

The nodetool utility is a command line interface for managing a cluster of Cassandra nodes. It can be used to obtain relevant information about a Cassandra system, as well as to perform day-to-day maintenance operations. Some of the most important commands are listed in the flowchart below.

## Nodetool flowchart

<div class="mermaid">
flowchart LR
%% -------------------------------------------------------------------------
%% Cassandra flowchart - Nodetool Checks
%% -------------------------------------------------------------------------
%% -------------------------------------------------------------------------
%% Define styles
%% -------------------------------------------------------------------------
linkStyle default stroke:#cccccc
classDef classAction fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:1px;
classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:1px;
classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:1px;
classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:1px;
classDef classSolution fill:#58595b,stroke:#58595b,color:#ffffff,stroke-width:1px;
classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:1px;
%% -------------------------------------------------------------------------
%% flowchart structure
%% -------------------------------------------------------------------------
START([Nodetool checks])
Action_NodetoolStatus[Print cluster information,<br> state, load, IDs, etc.]
Action_NodetoolHelp[Display help information]
Action_NodetoolCompactionStats[Print statistics on compactions]
Action_NodetoolGCStats[Print garbage collection statistics]
Action_NodetoolInfo[Print node information,<br> uptime, load, etc.]
Action_NodetoolClearSnapshot[Remove a given snapshot from <br> the given keyspaces<br> OR all snapshots if no <br> snapshot name is specified]
ActionClick_NodetoolStatus[nodetool status]
ActionClick_NodetoolHelp[nodetool help]
ActionClick_NodetoolCompactionStats[nodetool compactionstats]
ActionClick_NodetoolGCStats[nodetool gcstats]
ActionClick_NodetoolInfo[nodetool info]
ActionClick_NodetoolClearSnapshot[nodetool clearsnapshot]
ActionClick_NodetoolCompactionStats[nodetool compactionstats]
ActionClick_DatastaxReference[Click here for Cassandra's <br> official documentation on <br> nodetool commands]
START --- ActionClick_DatastaxReference
ActionClick_DatastaxReference --- Action_NodetoolStatus --- ActionClick_NodetoolStatus
ActionClick_DatastaxReference --- Action_NodetoolHelp --- ActionClick_NodetoolHelp
ActionClick_DatastaxReference --- Action_NodetoolCompactionStats --- ActionClick_NodetoolCompactionStats
ActionClick_DatastaxReference --- Action_NodetoolGCStats --- ActionClick_NodetoolGCStats
ActionClick_DatastaxReference --- Action_NodetoolInfo --- ActionClick_NodetoolInfo
ActionClick_DatastaxReference --- Action_NodetoolClearSnapshot --- ActionClick_NodetoolClearSnapshot
HOME([Start page <br/> Troubleshooting - Cassandra])
%% -------------------------------------------------------------------------
%% Define hyperlinks %%
%% -------------------------------------------------------------------------
click HOME "https://docs.dataminer.services/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Cassandra/Troubleshooting_Cassandra.html"
click ActionClick_NodetoolStatus "https://docs.dataminer.services/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Cassandra/Troubleshooting_Cassandra_Nodetool_Status_Check.html"
click ActionClick_DatastaxReference "https://cassandra.apache.org/doc/latest/tools/nodetool/nodetool.html"
%% -------------------------------------------------------------------------
%% Apply styles to blocks
%% -------------------------------------------------------------------------
class Action_NodetoolStatus,Action_NodetoolHelp,Action_NodetoolCompactionStats,Action_NodetoolGCStats,Action_NodetoolInfo,Action_NodetoolCompactionStats,Action_NodetoolClearSnapshot,ActionClick_NodetoolHelp,ActionClick_NodetoolCompactionStats,ActionClick_NodetoolGCStats,ActionClick_NodetoolInfo,ActionClick_NodetoolClearSnapshot,ActionClick_NodetoolCompactionStats classAction;
class ActionClick_NodetoolStatus classActionClickable;
class ActionClick_DatastaxReference classExternalRef;
class START classTerminal;
</div>
