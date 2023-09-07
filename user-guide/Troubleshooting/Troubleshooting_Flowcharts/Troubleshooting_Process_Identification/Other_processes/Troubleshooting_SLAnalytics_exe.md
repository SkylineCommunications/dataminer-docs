---
uid: Troubleshooting_SLAnalytics_exe
---

# SLAnalytics.exe

## About SLAnalytics

This process was introduced in DataMiner 9.0 and only starts on a DMA that uses a **Cassandra database**. The process supports advanced artificial intelligence functions in DataMiner, such as trend forecasting, anomaly detection and alarm focus calculation.

At present most of the communication for SLAnalytics happens via the **SLNet** process. This means that requests and responses from users or other processes go via SLNet, through the IPC connection, to SLAnalytics.

Another process connected to SLAnalytics is **SLDataGateway**. This connection is solely used for receiving all parameter changes of the DataMiner Agent. This is a COM connection.

## SLAnalytics troubleshooting

If SLAnalytics issues are suspected, proceed with the following checks:

1. Increase the **SLAnalytics log level**:

   1. Go to *System Center > Logging > DataMiner > [your DMA] > SLAnalytics*.

   1. Change the log level to 5 or 6 for all three logging categories. For more information, see [DataMiner logging](xref:DataMiner_logging).

1. Check if **new information is logged** in the SLAnalytics log file after the log level change.

1. Run the **SLLogCollector** tool, with the Include memory dump and SLAnalytics boxes selected. For more information, see [SLLogCollector](xref:SLLogCollector).

1. Check if there is an issue with the **Cassandra database**. The database should be up, running and operational. Refer to the [Cassandra troubleshooting flowchart](https://community.dataminer.services/troubleshooting-cassandra/) and [SLDataGateway troubleshooting flowchart](xref:Troubleshooting_SLDataGateway_exe).

1. Check if there is an issue with the **SLNet process**. The process should be up, running and operational. Refer to the [SLNet troubleshooting flowchart](xref:Troubleshooting_SLNet_exe).

1. SLAnalytics can affect your DMA resources consumption, especially the DMA CPU usage. Check the trend graph representing the **SLAnalytics CPU usage** in the Microsoft element for your DMA. If there is an observable impact that affects the DMA, check and increase the CPU power.
