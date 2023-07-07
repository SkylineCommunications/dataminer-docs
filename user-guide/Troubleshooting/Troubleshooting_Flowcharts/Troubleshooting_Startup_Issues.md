---
uid: Troubleshooting_Startup_Issues
---

# Troubleshooting - DataMiner startup issues

> [!NOTE]
> This page is currently still being developed. The content is not yet optimized and may not yet be fully accurate.

<div class="mermaid">
flowchart TD
%% Define styles %%
linkStyle default stroke:#cccccc
classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:0px;
classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:0px;
classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:0px;
classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:0px;
classDef classAction fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:0px;
classDef classSolution fill:#58595b,stroke:#58595b,color:#ffffff,stroke-width:0px;
%% Define blocks %%
   START([DMA startup issues])
   HOME([Start page])
   CHECK1{{Check: <br>1. SLDataminer.txt <br>2. SLWatchDog2.txt}}
   licensing([Licensing issue])
   nicpriority([NIC priority])
   dbOffloading([DB offloading])
   failingHeartbeats([Failing heartbeats])
   others([Other issues...])
%% Connect blocks %%
   START --- CHECK1
   CHECK1 --- licensing
   CHECK1 --- nicpriority
   CHECK1 --- dbOffloading
   CHECK1 --- failingHeartbeats
   CHECK1 --- others
%% Define hyperlinks %%
   click HOME "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
%% Apply styles to blocks %%
class START classTerminal;
class CHECK1 classDecision;
class HOME,licensing,nicpriority,dbOffloading,failingHeartbeats,others classExternalRef;
</div>
