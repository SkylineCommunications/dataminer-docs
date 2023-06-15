---
uid: Troubleshooting_Elasticsearch
---

# Troubleshooting: Elasticsearch

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
Start[Elasticsearch]
TaskManager([In the Task Manager, go to Services. <br>Is the status of elasticsearch-service-x64 <br> set to Running?])
RightClick([Open the elasticsearch-service-x64 context menu <br>and select Start. <br>Is the status set to Running now?])
Guide([elasticsearch-service-x64 has stopped working])
Investigation([How to investigate])
OK([Elasticsearch is working properly])
HOME([Start page])
%% Connect blocks %%
Start --- TaskManager
TaskManager --- |Yes| OK
TaskManager --- |No| RightClick
RightClick --- |Yes| OK
RightClick --- |No| Guide
%% Define hyperlinks %%
click HOME "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
click Investigation "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Where_to_Start.html"
click Cassandra "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Cassandra/Troubleshooting_Cassandra.html"
click Guide "#elasticsearch-service-x64-has-stopped-working"
%% Apply styles to blocks %%
class Start,OK,Guide DarkBlue;
class RightClick Gray;
class TaskManager LightBlue;
class Folder,Restart,Investigation,Start,HOME LightBlue;
</div>

## Elasticsearch-service-x64 has stopped working

If *elasticsearch-service-x64* is set to *Stopped* in *Task Manager > Services*:

1. Go to `C:\Program Files\Elasticsearch\logs` and search for `ERROR:Temporary file directory [C:\Windows\TEMP\elasticsearch]` in the most recent Elasticsearch log files.

   ![ERROR](~/user-guide/images/Elasticsearch_Error.png)

1. If you found this error message in the Elasticsearch logs:

   1. Verify whether the `C:\Windows\Temp\elasticsearch` folder exists.

   1. If it does not exist, manually add a folder called `elasticsearch` to the *Temp* folder.

1. In the Task Manager, the status of *elasticsearch-service-x64* should have automatically reverted to *Started*. If this is not the case, right-click *elasticsearch-service-x64* and select *start*.

1. Restart your DMA.
