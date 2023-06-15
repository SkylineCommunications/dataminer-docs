---
uid: Troubleshooting_SLDMS_exe
---

# SLDMS.exe

## About SLDMS

SLDMS is responsible for automatic synchronization of files. It also performs caching to find which DMA hosts which element. It is also involved in licensing and the use of Active Directory. It works closely together with other processes such as SLDataMiner, SLNet, SLXml, and SLAutomation.

## SLDMS troubleshooting flowchart

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
%% Define blocks %%
StartPage([Start page])
LogCollector([Log collector <br>usage guide])
START[SLDMS]
Rte[RTE]
Leak[Memory leak]
Crash[Process crash]
OI([Other frequent issues])
%% Connect blocks %%
START --- Rte
START --- Leak
START --- Crash
START --- OI
%% Define hyperlinks %%
click StartPage "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html" "Go to Start Page"
click OI "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Communication_processes/SLDMS/SLDMS_Frequent_Issues.html" "Frequent Issues"
click LogCollector "/user-guide/Reference/DataMiner_Tools/SLLogCollector.html" "SLLogCollector"
click Rte "#option-1-rte-and-memory-leak"
click Leak "#option-1-rte-and-memory-leak"
click Crash "#option-2-process-crash"
%% Apply styles to blocks %%
class START,MinidumpNo,ProcessCrashed,N2,N1,Y2 DarkBlue;
class MinidumpYes,Sol1,Nt3 DarkGray;
class CrashdumpDetected,Minidump,D1,Ch1 Blue;
class StartPage,LogCollector,OI LightBlue;
class Rte,Leak,Crash,Y1,Ch,Nt1,Nt2 LightGray;
class Nt Gray;
</div>

### Option 1: RTE and memory leak

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
%% Define blocks %%
Nt[NotificationThread]
Rte[RTE]
Leak[Memory leak]
Ml[Memory leak]
Ch[1. Check Task Manager <br>for high memory.<br/>2. Check MS Platform element <br>for gradual increase in <br> memory over a <br>period of time.]
D1{{Are the conditions above met?}}
N1([No memory leak])
Y1[1. Find the time where <br> memory use started to grow.<br/>2. Check logging, info events,<br> Windows Event Viewer <br> around that time.<br/>3. Check for any NotifyThread, <br>SNMPThread RTEs.<br/>Try to single out a <br>driver or an element.<br/>4. Check for SLXml issues too.]
Sol1[As a solution, collect all logs <br/>and restart the DMA.]
Ch1{{Is the leak still present?}}
N2([Issue resolved])
Y2([Contact tech <br>support with the <br/> required logging <br>and memory dump.])
Nt1[In the Alarm Console<br/> or SLWatchdog2 log file.]
Nt2[Always a notification getting <br/>deadlocked or taking a long time.]
Nt3[Take logging and restart DMA.]
%% Connect blocks %%
Ml -..- Leak
Rte --- Nt
Leak --- Ch
Ch --- D1
D1 --- |YES| Y1
D1 --- |NO| N1
Y1 --- Sol1
Sol1 --- Ch1
Ch1 --- |YES| Y2
Ch1 --- |NO| N2
Nt --- |IDENTIFICATION| Nt1
Nt --- |CONSEQUENCE| Leak
Nt1 --- |CAUSE OF RTE| Nt2
Nt2 --- |SOLUTION| Nt3
%% Define hyperlinks %%
click Nt "#notificationthread-rte"
%% Apply styles to blocks %%
class Rte,Ml,START,MinidumpNo,ProcessCrashed,N2,N1,Y2 DarkBlue;
class MinidumpYes,Sol1,Nt3 DarkGray;
class CrashdumpDetected,Minidump,D1,Ch1 Blue;
class StartPage,LogCollector,OI LightBlue;
class Crash,Y1,Ch,Nt1,Nt2 LightGray;
class Nt,Leak Gray;
</div>

### Option 2: Process crash

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
%% Define blocks %%
CrashdumpDetected{{"Crash dump found <br> at issue time? <br/>  C:\Skyline DataMiner\Logging\CrashDump"}}
ProcessCrashed(["1. Save .high crashdump  + <br/>note timestamp. <br/>2. Check the ErrorLog.txt file <br/>for possible causes. <br/>3. Send crashdump + logging + <br/>conclusions to Create squads. "])
Minidump{{"Minidump found <br> at issue time? <br/>  C:\Skyline DataMiner\Logging\MiniDump"}}
MinidumpNo(["Contact tech <br> support with the <br/> required logging <br> and memory dump."])
MinidumpYes["Identify the cause <br> in the required log file: <br>SLWatchDog2,<br/>SLDataMiner, <br>SLDMS, etc."]
Crash[Process crash]
%% Connect blocks %%
Crash --- CrashdumpDetected
CrashdumpDetected --- |YES| ProcessCrashed
CrashdumpDetected --- |NO| Minidump
Minidump --- |YES| MinidumpYes
Minidump --- |NO| MinidumpNo
%% Apply styles to blocks %%
class START,Crash,MinidumpNo,ProcessCrashed,N2,N1,Y2 DarkBlue;
class MinidumpYes,Sol1,Nt3 DarkGray;
class CrashdumpDetected,Minidump,D1,Ch1 Blue;
class StartPage,LogCollector,OI LightBlue;
class Rte,Leak,Y1,Ch,Nt1,Nt2 LightGray;
class Nt Gray;
</div>

## Major changes to SLDMS

**Since 2020, there have been some major changes to SLDMS:**

- DataMiner 10.1.8 ([29189](xref:General_Feature_Release_10.1.8#failover-without-virtual-ip-address-id_29189-id_29911)): Failover without VIP

- DataMiner 10.1.6 (29119): Toolset upgrade

- DataMiner 10.1.6 ([28775](xref:General_Feature_Release_10.1.6#dmsxml-now-supports-using-hostnames-instead-of-ip-addresses-id_28775)): Allow hostnames in *DMS.xml*

- DataMiner 10.1.0/10.0.10 (26221): COM impersonation security update

## Information needed to ascertain cause of SLDMS issue

- Log files

- Timestamp of the incident

- Reproduction steps

- If RTE/crash/leak: memory dump

## Debugging the log file

Check the entries near the time of the issue, find a suspicious thread and follow it in the logging:

2021/06/16 10:18:24.328|SLDMS.exe 10.1.2123.558|24012|10828|CDMS::NotifyFunc|DBG|-1|** Creating Scheduler

\<datetime>            |\<process>              |\<pid>|\<tid>|\<message>

## RTEs

### NotificationThread RTE

- Once you find the root time of the RTE, you can check the SLDMS log file for more information pertaining to the cause of the RTE.

- SLDMS handles many sorts of notifications, and you may find which one it is in the log file.

- A notification is a request that a process can send to SLDMS to do something, e.g. in case a file has changed. Usually SLNet sends many notifications to SLDMS.

- A DMA restart is the only way to clear this RTE. If you want to resolve the RTE without restarting the DMA, you must have a memory dump.

- This RTE could result in a memory leak. The NotificationThread slows down, causing notifications to stack up and not get handled, which can result in the SLDMS process going out of memory (memory leak). You might see this in the log file as "No more threads can be created".

- There are also other RTEs associated with SLDMS, e.g. the ConnectionThread RTE, the SNMPThread RTE, etc. However, the NotificationThread RTE is the most frequently seen RTE.
