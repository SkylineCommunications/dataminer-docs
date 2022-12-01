---
uid: SLNetClientTest_Requesting_QAction_metrics
---

# Requesting QAction metrics

You can request the following QAction metrics, either at the end of a QAction or on demand:

- CPU usage
- Number of SLProtocol iterations
- Number of Get/Set parameters/rows
- Elapsed time

## Enabling QAction metrics monitoring

By default, QAction metrics monitoring is disabled. To enable QAction metrics monitoring, do the following:

1. In the SLNetClientTest tool, select *Advanced* > *Options* > *SLNet Options*.

1. In `ExtraSupportedFeatureKeys`, add values like the following one for every element of which you want to monitor the QActions, separated by commas:

    `QACTIONMETRICS_ELEMENT_[DataMinerID]:[ElementID]`

> [!CAUTION]
> Alternatively, you can also add `QACTIONMETRICS_ALL` to `ExtraSupportedFeatureKeys` to monitor all QActions of all elements on the DataMiner Agent in question. However, it is not advised to do so on production systems.

## Requesting QAction metrics

To request the QAction metrics, go to *Diagnostics* > *DMA*, and then select one of the following commands:

- *QAction Metrics (QAction)*
- *QAction Metrics (Element)*
- *QAction Metrics (Protocol)*

For example, when you request the QAction metrics for a specific element, the following information will be returned:

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

In the example above, the line `CPUUsage Avg: X of SLScripting: (Y);` means that, on average, the QAction thread took X percent of the SLScripting process (while it was running) and, during that period, the SLScripting process was using Y percent of the CPU.

Remember that high CPU usage could mean that a QAction was executed so fast that it never had thread changes. This does not necessarily mean that it used too much CPU. It could also mean that it was the only QAction running on the DataMiner Agent at that moment and that it took 100 percent of SLScripting.

## Resetting QAction metrics

To reset the QAction metrics, go to *Diagnostics* > *DMA*, and then select one of the following commands:

- *Reset QAction Metrics (QAction)*
- *Reset QAction Metrics (Element)*
- *Reset QAction Metrics (Protocol)*

## Requesting or resetting QAction metrics by means of an NT_DIAG call

It is also possible to request or reset QAction metrics by means of a Notify type 226 (NT_DIAG) call. For more information, see [NT_DIAG (226)](xref:NT_DIAG).
