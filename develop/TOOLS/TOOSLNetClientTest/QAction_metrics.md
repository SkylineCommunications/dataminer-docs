---
uid: QAction_metrics
---

# QAction metrics

From DataMiner 7.5.3 (RN 4998) onwards, it is possible to get an overview, either at the end of a QAction or on demand, of the following metrics:

- CPU usage

- Number of SLProtocol iterations

- Number of Get/Set parameters/rows

- Elapsed time

By default, the QAction metrics are disabled. To enable monitoring, you have to enable the feature. To do so, in the ClientTestTool, select *Advanced* > *Options* > *SLNet Options*. You can then add features using a comma-separated list in 'ExtraSupportedFeatureKeys':

- QACTIONMETRICS_ALL: Enables monitoring on all QActions of all elements of the DMA.

    > [!CAUTION]
    > It is not advised to use this option on a production DMA.

- QACTIONMETRICS_ELEMENT\_\[dmaID\]:\[elementID\]: Enables monitoring of all QActions of the specified element.

![](~/develop/images/SLNet_Options_Window.png)<br>
*SLNet Options window*

To request the metrics, select *Diagnostics* > *DMA*, and then select *QAction Metrics (QAction)*, *QAction Metrics (Element)* or *QAction Metrics (Protocol)* from the menu.

For example, requesting the QAction metrics for a specific elements returns the following result:

```txt
QActionMetricsType: Element; Num Of Metrics: 5

ProtocolName: Newtec NOP1760
ProtocolVersion: 1.0.0.1
DataMinerID: 346
ElementID: 125
QActionID: 2
QAction executed 100 times since: 09/05/2018 09:29:00
ProtocolNotifies Avg: 0; Min: 0; Max: 0
DataMinerNotifies Avg: 0; Min: 0; Max: 0
ParameterGets Avg: 1; Min: 1; Max: 1
ParameterSets Avg: 1; Min: 1; Max: 1
RowGets Avg: 0; Min: 0; Max: 0
RowSets Avg: 0; Min: 0; Max: 0
ExecutionTime Avg: 3,56302ms; Min: 2,9873ms; Max: 5,0202ms
CPUUsage Avg: 95,2380952380952 of SLScripting: (23,0424859550562); Min: 0 of SLScripting: (0); Max: 100 of SLScripting: (100)

ProtocolName: Newtec NOP1760
ProtocolVersion: 1.0.0.1
DataMinerID: 346
ElementID: 125
QActionID: 3
QAction executed 1 times since: 09/05/2018 09:33:02
ProtocolNotifies Avg: 1; Min: 1; Max: 1
DataMinerNotifies Avg: 0; Min: 0; Max: 0
ParameterGets Avg: 0; Min: 0; Max: 0
ParameterSets Avg: 1; Min: 1; Max: 1
RowGets Avg: 0; Min: 0; Max: 0
RowSets Avg: 0; Min: 0; Max: 0
ExecutionTime Avg: 5,9893ms; Min: 5,9893ms; Max: 5,9893ms
CPUUsage Avg: 0 of SLScripting: (0); Min: 0 of SLScripting: (0); Max: 0 of SLScripting: (0)

ProtocolName: Newtec NOP1760
ProtocolVersion: 1.0.0.1
DataMinerID: 346
ElementID: 125
QActionID: 7
QAction executed 15 times since: 09/05/2018 09:28:59
ProtocolNotifies Avg: 0; Min: 0; Max: 0
DataMinerNotifies Avg: 0; Min: 0; Max: 0
ParameterGets Avg: 1; Min: 1; Max: 1
ParameterSets Avg: 1; Min: 1; Max: 1
RowGets Avg: 0; Min: 0; Max: 0
RowSets Avg: 0; Min: 0; Max: 0
ExecutionTime Avg: 4,20377333333333ms; Min: 2,9889ms; Max: 17,0242ms
CPUUsage Avg: 100 of SLScripting: (31,0019841269841); Min: 0 of SLScripting: (0); Max: 100 of SLScripting: (22,9452778985209)

ProtocolName: Newtec NOP1760
ProtocolVersion: 1.0.0.1
DataMinerID: 346
ElementID: 125
QActionID: 900012
QAction executed 1 times since: 09/05/2018 10:47:19
ProtocolNotifies Avg: 2; Min: 2; Max: 2
DataMinerNotifies Avg: 0; Min: 0; Max: 0
ParameterGets Avg: 0; Min: 0; Max: 0
ParameterSets Avg: 0; Min: 0; Max: 0
RowGets Avg: 0; Min: 0; Max: 0
RowSets Avg: 0; Min: 0; Max: 0
ExecutionTime Avg: 17,0119ms; Min: 17,0119ms; Max: 17,0119ms
CPUUsage Avg: 100 of SLScripting: (22,9779411764706); Min: 100 of SLScripting: (22,9618678689623); Max: 100 of SLScripting: (22,9618678689623)

ProtocolName: Newtec NOP1760
ProtocolVersion: 1.0.0.1
DataMinerID: 346
ElementID: 125
QActionID: 900011
QAction executed 1 times since: 09/05/2018 10:47:19
ProtocolNotifies Avg: 1; Min: 1; Max: 1
DataMinerNotifies Avg: 0; Min: 0; Max: 0
ParameterGets Avg: 0; Min: 0; Max: 0
ParameterSets Avg: 1; Min: 1; Max: 1
RowGets Avg: 0; Min: 0; Max: 0
RowSets Avg: 0; Min: 0; Max: 0
ExecutionTime Avg: 5,0046ms; Min: 5,0046ms; Max: 5,0046ms
CPUUsage Avg: 0 of SLScripting: (0); Min: 0 of SLScripting: (0); Max: 0 of SLScripting: (0)
```

The line "*CPUUsage Avg: X of SLScripting: (Y);*" means that on average, the QAction thread took X% of the SLScripting process (while it was running), and during that period the SLScripting process was using Y% of the CPU.

Remember that the CPU usage being high could mean that a QAction executed so fast that it never had thread changes. This does not necessarily mean that it used too much CPU; it could also mean that it was the only QAction running on the DMA at that moment and so it took 100% of SLScripting.

To reset the metrics, select *Diagnostics* > *DMA*, and then select *Reset QAction Metrics (QAction)*, *Reset QAction Metrics (Element)* or *Reset QAction Metrics (Protocol)* from the menu. *Feature introduced in DataMiner 8.5.1 (RN 8345)*.

> [!NOTE]
> It is also possible to request or reset the QAction metrics using a Notify type 226 (NT_DIAG) call. See [NT_DIAG (226)](xref:NT_DIAG).
