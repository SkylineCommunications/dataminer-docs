---
uid: Troubleshooting_SLDataMiner_exe
---

# SLDataMiner.exe

## About SLDataMiner

SLDataMiner is the central process of a DataMiner Agent. It handles the starting and stopping of elements, services and redundancy groups, and handles the processes that communicate data from and to those items.

SLDataMiner is also responsible for the offloading of data, if an offload database is available.

## SLDataMiner troubleshooting flowchart

<div class="mermaid">
flowchart TD
%% Define styles %%
linkStyle default stroke:#cccccc
classDef LightBlue fill:#9DDAF5,stroke:#000070,stroke-width:0px, color:#1E5179;
classDef Blue fill:#4BAEEA,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkBlue fill:#1E5179,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkGray fill:#58595B,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef Gray fill:#999999,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef LightGray fill:#DDDDDD,stroke:#000070,stroke-width:0px, color:#1E5179;
Start[SLDataMiner problem]
StartPage([Start page])
RTE{{"Is there an RTE<br> or memory leak?"}}
Watchdog[Check SLWatchdog2.txt log to <br>see when the RTE started.]
Threads{{Which SLDataMiner <br>thread is affected?}}
ThreadsDB[DBThread<br/>ReplicationDBThread<br/>Database Cleaning Thread<br/>Database Forwarding<br/>Database Offload Thread<br/>DatagatewayElementData Thread]
Offload[- Check Offload DB folder <br> for new files.<br>- Confirm DB connection <br> is healthy.<br>- Check if there are <br> big tables that <br>might be slowing <br> down queries.]
CassandraTb([Cassandra troubleshooting])
ThreadsSecondary[ExecuteThread<br/>LDAP NotificationThread<br/>AlarmStackThread<br/>ActionThread<br/>RedundancyThread]
CheckLogs[- Check SLErrors and <br> SLDataMiner logs <br>around the time <br> of the RTE.<br>- Run SLLogCollector <br> and send the <br>package to the <br> software team.]
InfoEvents{{Check information events <br>around the time of the RTE.<br>Is there an action that might <br>have triggered the RTE?}}
Revert[Revert the action <br> and check if <br> the RTE goes away.]
LogCollector1[Run SLLogCollector <br> and send the <br>package to the <br> software team.]
MemoryLeak[Check the trending <br> on the Microsoft <br>element when the <br> memory leak started.]
LinkLeak{{Can you link an <br> event/action on <br>the DMA to when <br> the leak started?}}
ElementActive{{Was an element activated?}}
LogCollector2[Run SLLogCollector and select <br>SLDataMiner memory to be <br>collected now and when it <br>increases by at least 100 MB.]
StopElement[Stop the element and check<br/> if the issue is on the device.]
InfoEventsAlternative[Check information events <br> on the DMA to see <br> what else it could be.]
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
click StartPage "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
click CassandraTb "https://community.dataminer.services/troubleshooting-cassandra/"
%% Apply styles to blocks %%
class Start,Revert,LogCollector1,LogCollector2,CheckLogs,StopElement,InfoEventsAlternative DarkBlue; 
class Watchdog,ThreadsDB,Offload,ThreadsSecondary,MemoryLeak LightGray;
class RTE,Threads,InfoEvents,ElementActive,LinkLeak Blue;
class StartPage,CassandraTb LightBlue;
</div>

> [!NOTE]
>
> - SLDataMiner is the main process of a DMA. Any issues in this process will therefore explicitly affect the user interface, element communication, and general functionality of the system.
> - The SLDataMiner process is a 32-bit process so it does have a 4GB memory usage limit. It will crash if it reaches that limit.
> - If the file *OffloadData.SQLite3* starts to grow in the folder `C:\Skyline DataMiner\Offload\`, this generally points to an issue with the database connection, and a restart of SLDataMiner is required to begin offloading this file to the database.
