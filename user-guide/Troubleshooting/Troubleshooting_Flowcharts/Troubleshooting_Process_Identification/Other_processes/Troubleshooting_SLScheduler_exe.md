---
uid: Troubleshooting_SLScheduler_exe
---

# SLScheduler.exe

## About SLScheduler

SLScheduler is a helper process that is called upon when the Windows Task Scheduler orders that a scheduled task has to be performed.

## SLScheduler troubleshooting flowchart

<div class="mermaid">
flowchart TD
%% Define styles %%
%% Define styles %%
linkStyle default stroke:#cccccc
classDef LightBlue fill:#9DDAF5,stroke:#000070,stroke-width:0px, color:#1E5179;
classDef Blue fill:#4BAEEA,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkBlue fill:#1E5179,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkGray fill:#58595B,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef Gray fill:#999999,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef LightGray fill:#DDDDDD,stroke:#000070,stroke-width:0px, color:#1E5179;
%% Define blocks %%
Start[SLScheduler]
Home([Start page])
SLLogCollector([Log collector <br>usage guide])
Investigation([How to investigate])
RTE{{"Was there an RTE?"}}
RTE1[- Verify RTE count = 1.<br> - Check memory/CPU usage. <br> - Take high memory dump <br>or set up procdump.<br> - If RTE is still present, restart DMA.]
RTE2[Check SLScheduler.txt.]
RTE3[Verify which scheduled task was <br>executed at the time of the RTE.]
RTE4[Check Windows Task Scheduler: <br> - Verify that everything is OK in the Active Tasks. <br> - Verify when the task started to fail. <br> - Try to run it from the Task Scheduler.]
RTE5[Investigate the root cause of the leak/RTE/crash: <br> - Check information events. <br> - Check resources of other processes. <br> - Check the Recycle Bin. <br> - Check Event Viewer.]
ScheduledEvent{{"Did the <br>scheduled event run?"}}
Win[Windows Task Scheduler]
InfoEvents["Check information events."]
Errors{{"Are there any errors? "}}
Config["Check scheduled <br>task/event configuration."]
ErrorYes[Check the respective errors.]
End[Manually execute <br>the scheduled event.]
%% Connect blocks %%
Start ---- ScheduledEvent
Start --- RTE
ScheduledEvent --- |NO|InfoEvents
InfoEvents --- Errors
InfoEvents --- |NO|Win
RTE --- |YES|RTE1
RTE1 --- RTE2
RTE2 --- RTE3
RTE3 --- RTE4
RTE4 --- RTE5
Errors --- |NO|Config
Errors --- |YES|ErrorYes
Config --- End
ErrorYes --- End
%% Define hyperlinks %%
click Home "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
click SLLogCollector "/user-guide/Reference/DataMiner_Tools/SLLogCollector.html"
click Investigation "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Where_to_Start.html"
click Config "#scheduled-taskevent-configuration-checklist"
click ErrorYes "#check-the-respective-errors"
click Win "#windows-task-scheduler"
%% Apply styles to blocks %%
class Start DarkBlue;
class RTE1,RTE2,RTE3,RTE4,RTE5,InfoEvents,End LightGray;
class RTE,ScheduledEvent,Errors Blue;
class Home,SLLogCollector,Investigation LightBlue;
class Config,ErrorYes,Win Gray;
</div>

## Scheduled task/event configuration checklist

1. Is the task/event enabled?

1. Is the schedule configured correctly?

1. Are the items below configured correctly?

   - **Email**:

     - Check email configuration.

     - Check SMTP settings.

   - **Information**: Validate that the message is displayed correctly in the information events.

   - **Script**: Check if the script has been configured correctly.

   - **SMS**: Check the Mobile Gateway settings.

   - **Upload to FTP**: Check if the FTP path can be reached.

   - **Upload report to shared network path**: Check if the network path can be reached.

## Check the respective errors

- **Issue**: SLScheduler stuck

  **Plan of attack**: Restart SLScheduler. No DMA restart is required.

- **Issue**: Unable to generate report

  **Plan of attack**:

  - Check if a table parameter contains the ">" character.

  - Check if a report action includes a parameter with filter containing a "<" character.

- **Issue**: The operator or administrator has refused the request

  **Plan of attack**: Check *SLScheduler.txt* and *SLASPConnection.txt*.

- **Issue**: Failure to add scheduled task

  **Plan of attack**:

  - Follow Cube session, in SLClientTest tool, while adding scheduled task.

  - Check exceptions in Cube.

  - Check errors in Cube logging.

  - Pay special attention to the data, e.g. incorrect time format.

## Windows Task Scheduler

1. Check if the Scheduled Event triggered (Last Run Time).

1. Verify the Triggers, Actions and Conditions.

1. Verify that the Last Run instance was successful.

The following items related to DataMiner may be included in the Windows Task Scheduler:

- DataMiner backup

- DataMiner restore

- Cassandra backup

- Cassandra compaction

- Cassandra repair

- Elastic indexing backup
