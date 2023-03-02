---
uid: Troubleshooting_Cassandra
---

# Troubleshooting: Cassandra

## About Cassandra

The flowchart below is intended to be used for DataMiner Systems with Cassandra running on the server or on external Windows or Linux nodes.

As the Cassandra database is one of the main components of DataMiner, it is very important that you know how to check and get information from this database. This page contains information related to Cassandra administration and troubleshooting. For more information about this, please refer to the official supporting documentation available at [Cassandra Apache Documentation](https://cassandra.apache.org/doc/3.11/index.html).

## Initial checks

If you encounter an issue related to Cassandra, we recommend that you perform these initial checks and gather the data mentioned below to start the troubleshooting or investigation.

- Collect DataMiner logs running the [SLLogCollector tool](xref:SLLogCollector). You can also collect an SLDataGateway dump using this tool.

- In the *SLDataGateway.txt* and *SLDBConnections.txt* log files, check for errors and status information related to the communication between DataMiner and the Cassandra database. You can find these files on each DMA in the folder *C:\Skyline DataMiner\Logging*.

- Make a copy of the Cassandra logs folder *C:\Program Files\Cassandra\logs*. Check the Cassandra system and debug logs.

- In a command window or PowerShell window, execute "[*nodetool status*](xref:Troubleshooting_Cassandra_Nodetool_Status_Check)" (from the directory *C:\Program Files\Cassandra\bin*). In a Failover setup, execute this command on both Cassandra nodes of the Failover pair.

Check connectivity to Cassandra using DevCenter. On the DMA, go to `C:\Program Files\Cassandra\DevCenter\` and double-click *Run DevCenter*.

## Cassandra troubleshooting flowchart

<div class="mermaid">
flowchart TD
    bpa[Best Practice Analyser Cassandra]:::LightGray---|From DataMiner<br> 9.6.0.0 CU23 onwards|B( Run the Cassandra BPA test in <br>System Center on the Agents BPA tab.<br>It is available by default from DataMiner<br>10.1.4 onwards, or else on demand.):::Gray
    click B "https://docs.dataminer.services/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Cassandra/Troubleshooting_Cassandra_Best_Practice_Analyzer.html" "Best Practice Analyser Cassandra"
    box1---bpa
    box1[Check for any issues<br>observed in your system:]:::DarkBlue---box2{{Are there Cassandra health<br>alarms in Cube?}}:::Blue
    box2---|Yes|2[Check Cassandra health<br>from DataMiner Cube.]:::LightGray---3
    3{{Go to Alarm Console or Failover Status.}}:::Blue
    box2---|No|DiskCheck[Check on which drive database data is stored.<br> DRIVE:\ProgramData\Cassandra\SLDMADB <br>Check the drive size trend graph.]:::LightGray---Disk
    Disk{{Is available space on the drive decreasing?}}:::Blue
    click Disk "#option-2-is-available-space-on-the-drive-decreasing" "drive decreasing"
    click 3 "#option-1-go-to-alarm-console-or-failover-status" "alarm console or failover status"
    linkStyle default stroke:#cccccc
    classDef info fill:#11628F,stroke:#000070,stroke-width:0px, color:#FFF;
    classDef clickable fill:#ABDCFF,stroke:#00517E,stroke-width:0.25px, color:#00406D;
    classDef start fill:#FFE333,stroke:#00517E,stroke-width:0.25px, color:#000;
    classDef stop fill:#CCCCCC,stroke:#000070,stroke-width:0px, color:#000000;
    classDef LightBlue fill:#9DDAF5,stroke:#000070,stroke-width:0px, color:#1E5179;
    classDef Blue fill:#4BAEEA,stroke:#000070,stroke-width:0px, color:#FFFFFF;
    classDef DarkBlue fill:#1E5179,stroke:#000070,stroke-width:0px, color:#FFFFFF;
    classDef DarkGray fill:#58595B,stroke:#000070,stroke-width:0px, color:#FFFFFF;
    classDef Gray fill:#999999,stroke:#000070,stroke-width:0px, color:#FFFFFF;
    classDef LightGray fill:#DDDDDD,stroke:#000070,stroke-width:0px, color:#1E5179;
</div>

### Option 1: Go to Alarm Console or Failover Status

<div class="mermaid">
flowchart TD
    box1[Go to Alarm Console or Failover Status.]:::Blue
    box1---|Go to System Center > Agents > Failover > Status|5
    box1---|Open Alarm Console | 4_1_a1[Cassandra yellow or red <br>health alarm is present.]:::LightGray---7
    5[Cassandra health status <br>is yellow or red.]:::LightGray---7
    7[- Run nodetool status on the DMAs. <br>- Try to get connected to Cassandra nodes with DevCenter. <br>- Confirm which Cassandra node is unavailable. <Br>- Restart Cassandra service on unresponsive Cassandra nodes.<br>If Cassandra service cannot be stopped, end<br> prunsrv.exe - under Details - and restart Cassandra service.]:::Gray
    7---12{{Check if Cassandra health is green and <br>no Cassandra issues remain.}}:::Blue
    12---|Yes, issue is solved.|12y([Problem solved]):::DarkBlue
    12---|No, there are issues.|12n{{Is the SLDataGateway process leaking?<br>Check trending in Microsoft Platform element.}}:::Blue
    12n---|Yes|13[To SLDataGateway flowchart]:::Gray
    12n---|No|13z([Problem solved]):::DarkBlue
    click 13 "https://docs.dataminer.services/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Database_processes/Troubleshooting_SLDataGateway_exe.html" "SLDataGateway Flowchart"
    click 7 "https://docs.dataminer.services/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Cassandra/Troubleshooting_Cassandra_Nodetool_Checks.html" "nodetool"
    linkStyle default stroke:#cccccc
    classDef info fill:#11628F,stroke:#000070,stroke-width:0px, color:#FFF;
    classDef clickable fill:#ABDCFF,stroke:#00517E,stroke-width:0.25px, color:#00406D;
    classDef start fill:#FFE333,stroke:#00517E,stroke-width:0.25px, color:#000;
    classDef stop fill:#CCCCCC,stroke:#000070,stroke-width:0px, color:#000000;
    classDef LightBlue fill:#9DDAF5,stroke:#000070,stroke-width:0px, color:#1E5179;
    classDef Blue fill:#4BAEEA,stroke:#000070,stroke-width:0px, color:#FFFFFF;
    classDef DarkBlue fill:#1E5179,stroke:#000070,stroke-width:0px, color:#FFFFFF;
    classDef DarkGray fill:#58595B,stroke:#000070,stroke-width:0px, color:#FFFFFF;
    classDef Gray fill:#999999,stroke:#000070,stroke-width:0px, color:#FFFFFF;
    classDef LightGray fill:#DDDDDD,stroke:#000070,stroke-width:0px, color:#1E5179;
</div>

### Option 2: Is available space on the drive decreasing?

<div class="mermaid">
flowchart TD
    Disk{{Is available space on the drive decreasing?}}:::Blue
    Disk---|Yes|SchedT[Check Scheduled Tasks for <br>the status of repair and compaction tasks.]:::LightGray---nodeT[Run nodetool compactstats and <br> check if there are any pending tasks.]:::Gray---cassL[Check Cassandra debug.log <br> for Not Enough Disk compaction errors.]:::LightGray ---compErr{{Is compaction failing?}}:::Blue
    compErr---|No|endC([Check other possible <br> reasons of disk usage increase, <br> e.g. run WinDirStat tool.]):::DarkBlue
    compErr---|Yes|clean1[If there is not enough <br> space on the Cassandra  <br> drive, run cleanup.]:::LightGray---clean2[If there are Cassandra <br>  snapshots, run  <br> nodetool clearsnapshot.]:::Gray---clean3[Look for old logs, files  <br> or installers that can <br>  be deleted.]:::LightGray---clean4[Increase <br> Cassandra drive.]:::LightGray
    clean4---compDec{{Does repair/compaction <br> finish and is available space <br> being recovered?}}:::Blue
    compDec---|Yes|compPy([Problem solved]):::DarkBlue
    compDec---|No|compPn[Let repair/compaction run several times.]:::LightGray---compDec2{{After several repairs/compactions, <br> does drive space start to be recovered?}}:::Blue
    compDec2---|Yes|compP2y([Let scheduled maintenance task <br> run until DB size is back to normal.]):::DarkBlue
    compDec2---|No|compP2n[If compaction was failing<br>  for a long time, <br> there could be <br> too many undeletable <br> tombstones.]:::LightGray---compP3n([Truncate the affected tables.]):::DarkBlue
    Disk---|No|cassRest{{Is Cassandra service restarting or stopped?}}:::Blue
    cassRest---a2[Connection to Cassandra errors]:::LightGray---a3
    a3[Check the Cassandra.yaml file.<br>Click this box for more details.]:::Gray
    click a3 "https://docs.dataminer.services/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Cassandra/Troubleshooting_Cassandra.html#cassandrayaml-file" "Cassandra.yaml details"
    click nodeT "https://docs.dataminer.services/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Cassandra/Troubleshooting_Cassandra_Nodetool_Checks.html" "nodetool"
    click clean2 "https://docs.dataminer.services/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Cassandra/Troubleshooting_Cassandra_Nodetool_Checks.html" "nodetool"
    a3 ---  a8
    a8{{Are .yaml file parameters OK?}}:::Blue
    a8 --- |Yes|a101
    a8 --- |No|a10[Correct the wrong values.<br>Restart Cassandra service and<br>DataMiner.]:::LightGray
    a10 ---a101{{Did DataMiner start correctly?}}:::Blue
    a101 --- |Yes|a11([Problem solved]):::DarkBlue
    a101 ---- |No|a12([Look for more evidence <br>in collected logs.]):::DarkBlue
    classDef info fill:#11628F,stroke:#000070,stroke-width:0px, color:#FFF;
    classDef clickable fill:#ABDCFF,stroke:#00517E,stroke-width:0.25px, color:#00406D;
    classDef start fill:#FFE333,stroke:#00517E,stroke-width:0.25px, color:#000;
    classDef stop fill:#CCCCCC,stroke:#000070,stroke-width:0px, color:#000000;
    classDef LightBlue fill:#9DDAF5,stroke:#000070,stroke-width:0px, color:#1E5179;
    classDef Blue fill:#4BAEEA,stroke:#000070,stroke-width:0px, color:#FFFFFF;
    classDef DarkBlue fill:#1E5179,stroke:#000070,stroke-width:0px, color:#FFFFFF;
    classDef DarkGray fill:#58595B,stroke:#000070,stroke-width:0px, color:#FFFFFF;
    classDef Gray fill:#999999,stroke:#000070,stroke-width:0px, color:#FFFFFF;
    classDef LightGray fill:#DDDDDD,stroke:#000070,stroke-width:0px, color:#1E5179;
    linkStyle default stroke:#cccccc
</div>

## Cassandra.yaml file

The *Cassandra.yaml* file is the main configuration file for the Cassandra database. It can be found in the folder *C:\Program Files\Cassandra\Conf*.
These are the main parameters you should check in this file:

- **Cluster name**: Should be the same for all DMAs (*cluster_name: dms*).

- **Listen address**: The address or interface to bind to and tell other Cassandra nodes to connect to.

- **Seeds**: Cassandra nodes use this list of hosts to find each other and learn the topology of the ring.

- **RPC Address**: The address or interface to bind the Thrift RPC service and native transport server to.

- **Broadcast RPC Address**: The RPC address to broadcast to drivers and other Cassandra nodes.

- **Disk Optimization Strategy**: Performance could be improved by updating the strategy for optimizing disk reads. Possible values are:

  - *ssd* – for solid state disks (default)

  - *spinning* – for spinning disks

**For a Failover setup**: Each DMA (main or backup) has its own *distinct .yaml* file.

- *listen_address: [IP of the main or backup DMA]* (depending on the DMA)

- *seeds: [IP of the main DMA],[IP of the backup DMA]* (same for both DMAs)

- *rpc_address: 0.0.0.0* (same for both DMAs)

- *broadcast_rpc_address: [IP of the main or backup DMA]* (depending on the DMA)

**For a single DMA setup:**

- *listen_address: 127.0.0.1*

- *seeds: 127.0.0.1*

- *rpc_address: 0.0.0.0*

- *broadcast_rpc_address: 127.0.0.1*
