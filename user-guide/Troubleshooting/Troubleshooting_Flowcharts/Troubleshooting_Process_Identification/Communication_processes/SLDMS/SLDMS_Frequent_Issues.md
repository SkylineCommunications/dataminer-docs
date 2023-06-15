---
uid: Troubleshooting_SLDMS_Frequent_Issues
---

# SLDMS - frequent issues

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
START[Frequent issues]
FNS[File not syncing]
TSI[Time server issues]
CI[Connectivity issues]
SSP([SLDMS start page])
%% Connect blocks %%
START --- FNS
START --- TSI
START --- CI
%% Define hyperlinks %%
click SSP "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Communication_processes/Troubleshooting_SLDMS_exe.html" "Go to SLDMS Start Page"
click FNS "#option-1-file-not-syncing"
click TSI "#option-2-time-server-issues"
click CI "#option-3-connectivity-issues"
%% Apply styles to blocks %%
class START DarkBlue;
class FNS,TSI,CI,SSP LightBlue;

</div>

## Option 1: file not syncing

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
FNS[File not syncing]
Check{{Does a file <br/>need to be synced?}}
Y1{{Check SLDMS log file: <br/> is there a notification <br/>that the file has changed?}}
N1(["No issues."])
Y2["1. On the DMA with the most <br>recent file, go to System Center.<br>2. Go to Tools > Synchronization.<br/>3. Select the type 'file'.<br/>4. Enter the file path.<br/>5. Confirm the action."]
N2(["Check for <br>connectivity issues <br>between DMAs."])
C{{Has the file <br>been synchronized?}}
Y3["Verify on all DMAs <br/>in the cluster."]
N3(["Contact tech support;<br/>this might not work <br>every time."])
%% Connect blocks %%
FNS --- Check
Check --- |YES| Y1
Check --- |NO| N1
Y1 --- |YES| Y2
Y1 --- |NO| N2
Y2 --- C
C --- |YES| Y3
C --- |NO| N3
%% Apply styles to blocks %%
class START,FNS,N4,N3,N1,N2,CI3 DarkBlue;
class Check,C,TSI1,Y1,CI4,CI6,CI1 Blue;
class Y4,CI7,CI2 LightGray;
class Y3,Y2,CI9,CI5 DarkGray;
class R,SSP,CI8 LightBlue;
class CI,TSI Gray;
</div>

> [!TIP]
> For more information on syncing files, see [Overview of the files found in the root folder](xref:Overview_of_the_files_found_in_the_root_folder).

## Option 2: time server issues

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
TSI[Time server issues]
TSI1{{Do DMAs in the cluster <br/>have different times?}}
Y4["Sync issues <br>observed."]
N4(["No time <br>server issues."])
R(["Follow the instructions<br>in the DataMiner Help."])
%% Connect blocks %%
TSI --- TSI1
TSI1 --- |YES| Y4
TSI1 --- |NO| N4
Y4 --- R
%% Define hyperlinks %%
click R "/user-guide/Reference/faq/General_configuration.html#time-server" "DataMiner Help"
click TSI "#checking-for-time-server-issues"
%% Apply styles to blocks %%
class START,FNS,TSI,N4,N3,N1,N2,CI3 DarkBlue;
class Check,C,TSI1,Y1,CI4,CI6,CI1 Blue;
class Y4,CI7,CI2 LightGray;
class Y3,Y2,CI9,CI5 DarkGray;
class R,SSP,CI8 LightBlue;
class CI Gray;
</div>

## Option 3: connectivity issues

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
CI[Connectivity issues]
CI1{{In the SLNet/SLDMS/<br>SLDataMiner log file, <br>do you see lines like <br>'Failed to connect <br>to' or 'Failed to <br>forward clients to' ?}}
CI2[There are <br>connectivity issues.]
CI3([No connectivity issues.])
CI4{{Verify via ping/wireshark: <br>does the DMA have <br>network interruptions?}}
CI5[Resolve the <br>network issues.]
CI6{{Is the DMA <br>up and running ?}}
CI7[Check if the <br>DMA can communicate.]
CI8([Refer to <br>startup issues flowchart.])
CI9[Check for <br>process crashes or <br>deadlocks in the <br>SLDMS log file.]
%% Connect blocks %%
CI --- CI1
CI1 --- |YES| CI2
CI1 --- |NO| CI3
CI2 --- CI4
CI4 --- |YES| CI5
CI4 --- |NO| CI6
CI6 --- |YES| CI7
CI6 --- |NO| CI8
CI7 --- |POSSIBLE CAUSES| CI9
%% Define hyperlinks %%
click CI8 "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Startup_Issues.html"
click CI "#connectivity-issues"
%% Apply styles to blocks %%
class START,FNS,CI,TSI,N4,N3,N1,N2,CI3 DarkBlue;
class Check,C,TSI1,Y1,CI4,CI6,CI1 Blue;
class Y4,CI7,CI2 LightGray;
class Y3,Y2,CI9,CI5 DarkGray;
class R,SSP,CI8 LightBlue;
</div>

## Connectivity issues

In the flowchart, "Connectivity issues" refers to DMAs not being able to contact each other. SLDMS itself does not contact other DMAs; all inter-machine traffic goes through SLNet.

These issues could lead to other complications such as files not syncing or elements (and their alarms) that are missing in the Surveyor.

## Checking for time server issues

While there is no easy way to check this, one possible approach is to compare log files.

When you compare log files, you could for instance see that when files are synced, a server appears to get notifications from the future. This indicates that DMAs in the cluster are not set to the same time or time zone.
