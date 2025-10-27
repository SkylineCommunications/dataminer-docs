---
uid: Troubleshooting_SLPort_exe
---

# SLPort.exe

## About SLPort

SLPort controls all communication from and to devices connected to either a serial or an IP port.

**Communication types**: HTTP, Web Socket, serial, smart-serial, GPIB, SSH and OPC.

## SLPort troubleshooting flowchart

```mermaid
%%{init: { 'theme': 'base', 'themeVariables': { 'edgeLabelBackground':'#fff', 'fontFamily' : 'Segoe UI'}}}%%
flowchart TD
A[SLPort]:::Start
A----L{{"Are RTEs present in the system?"}}:::Decision
L----|No|U{{"Which functionality is broken?"}}:::Decision
U----M["HTTP"]:::InfoAccNoClick
M----|Query device API using an HTTP tool.|S
U----N["Serial"]:::InfoAccNoClick
N----|Query the device using Hercules.|S{{"Does the device respond as expected?"}}:::Decision
S----|No|T["Fix device communication."]:::Solution
S----|Yes|I
L---|Yes|F["RTE troubleshooting:<br/>- Verify RTE Count = 1.<br/>- Check memory/CPU usage of SLPort.<br/> - Run collector and include memory dump."]:::InfoAccNoClick
F---G["Check SLErrors and SLErrorsInProtocol."]:::InfoAccNoClick
G---H{{"Can you link the issues with a connector? "}}:::Decision
H---|Yes|K{{"Stop the element(s) using the connector. Has this solved the issue?"}}:::Decision
H---|No|J["\- Investigate the root cause of the leak/RTE/crash:<br/>\- Check information events.<br/>\- Check the Recycle Bin.<br/>\- Check Event Viewer."]:::InfoAccNoClick
J---I
K---|Yes|Log["\- Add or update the Portlog.txt file in the Skyline DataMiner folder.<br/>\- Add the IP of the affected devices to the Portlog.txt file."]:::InfoAccNoClick
Log---|After 5 min of logging into SLPort.txt|I
K---|No|I["Contact software team with the information and memory dump."]:::Solution
XX([Start page]):::InfoAccClick
click XX "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html" "Go to the start page"
linkStyle default stroke:#cccccc
classDef ExtRef fill:#9DDAF5,stroke:#000070,stroke-width:0px, color:#1E5179;
classDef Decision fill:#4BAEEA,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef Start fill:#1E5179,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef Solution fill:#58595B,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef InfoAccClick fill:#999999,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef InfoAccNoClick fill:#DDDDDD,stroke:#000070,stroke-width:0px, color:#1E5179;
```

> [!NOTE]
>
> - Multiple SLPort processes can run simultaneously. This can be configured in *DataMiner.xml*. (See [Setting the number of simultaneously running SLPort processes](xref:Configuration_of_DataMiner_processes#setting-the-number-of-simultaneously-running-slprotocol-processes) in the DataMiner Help).
> - Ensure that the device is **communicating as expected** and that all fields match the **expected data types and structure**.
