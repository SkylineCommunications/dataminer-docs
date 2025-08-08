---
uid: Troubleshooting_SLDataMiner_exe
---

# SLDataMiner.exe

## About SLDataMiner

SLDataMiner is the central process of a DataMiner Agent. It handles the starting and stopping of elements, services and redundancy groups, and handles the processes that communicate data from and to those items.

SLDataMiner is also responsible for the offloading of data, if an offload database is available.

## SLDataMiner troubleshooting flowchart

```mermaid
flowchart TD
%% Define styles %%
linkStyle default stroke:#cccccc
classDef LightBlue fill:#9DDAF5,stroke:#000070,stroke-width:0px, color:#1E5179;
classDef Blue fill:#4BAEEA,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkBlue fill:#1E5179,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkGray fill:#58595B,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef Gray fill:#999999,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef LightGray fill:#DDDDDD,stroke:#000070,stroke-width:0px, color:#1E5179;
%% Define blocks %%
Start["SLDataMiner problem"]
StartPage([" Start page "])
RTE{{"Is there an RTE or memory leak?"}}
Watchdog[" Check SLWatchdog2.txt log to see when the RTE started. "]
Threads{{" Which SLDataMiner thread is affected?" }}
ThreadsDB[" DBThread<br/>ReplicationDBThread<br/>Database Cleaning Thread<br/>Database Forwarding<br/>Database Offload Thread<br/>DatagatewayElementData Thread "]
Offload[" \- Check Offload DB folder for new files.<br>\- Confirm DB connection is healthy.<br>\- Check if there are big tables that might be slowing down queries. "]
CassandraTb([" Cassandra troubleshooting "])
ThreadsSecondary[" ExecuteThread<br/>LDAP NotificationThread<br/>AlarmStackThread<br/>ActionThread<br/>RedundancyThread "]
CheckLogs[" \- Check SLErrors and SLDataMiner logs around the time of the RTE.<br>\- Run SLLogCollector and send the package to the software team. "]
InfoEvents{{" Check information events around the time of the RTE. Is there an action that might have triggered the RTE?"}}
Revert[" Revert the action and check if the RTE goes away. "]
LogCollector1[" Run SLLogCollector and send the package to the software team. "]
MemoryLeak[" Check the trending on the Microsoft element when the memory leak started. "]
LinkLeak{{" Can you link an event/action on the DMA to when the leak started? "}}
ElementActive{{" Was an element activated? "}}
LogCollector2[" Run SLLogCollector and select SLDataMiner memory to be collected now and when it increases by at least 100 MB. "]
StopElement[" Stop the element and check if the issue is on the device. "]
InfoEventsAlternative[" Check information events on the DMA to see what else it could be. "]
%% Connect blocks %%
Start ---- RTE
RTE ---|RTE|Watchdog
Watchdog ----- Threads ---- ThreadsDB ---- Offload ---- CassandraTb
Threads ---- ThreadsSecondary ---- CheckLogs
Watchdog ---- InfoEvents
InfoEvents ----|YES|Revert
InfoEvents ----|NO|LogCollector1
RTE ---|Memory leak|MemoryLeak ---- LinkLeak -----|YES|ElementActive ----|YES|StopElement
LinkLeak ----|NO|LogCollector2
ElementActive ----|NO|InfoEventsAlternative
%% Define hyperlinks %%
click StartPage "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
click CassandraTb "https://community.dataminer.services/troubleshooting-cassandra/"
%% Apply styles to blocks %%
class Start,Revert,LogCollector1,LogCollector2,CheckLogs,StopElement,InfoEventsAlternative DarkBlue; 
class Watchdog,ThreadsDB,Offload,ThreadsSecondary,MemoryLeak LightGray;
class RTE,Threads,InfoEvents,ElementActive,LinkLeak Blue;
class StartPage,CassandraTb LightBlue;
```

> [!NOTE]
>
> - SLDataMiner is the main process of a DMA. Any issues in this process will therefore explicitly affect the user interface, element communication, and general functionality of the system.
> - The SLDataMiner process is a 32-bit process so it does have a 4GB memory usage limit. It will crash if it reaches that limit.
> - If the file *OffloadData.SQLite3* starts to grow in the folder `C:\Skyline DataMiner\Offload\`, this generally points to an issue with the database connection, and a restart of SLDataMiner is required to begin offloading this file to the database.
