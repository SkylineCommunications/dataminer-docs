---
uid: VSAT_metrics
---

# EPM VSAT metrics

The metrics provided below are given as a guide to help dimension EPM VSAT deployments.

All specifications are provided based on the assumption that DMAs are running on servers that comply with the [DataMiner compute requirements](xref:DataMiner_Compute_Requirements) and the recommended [data storage architecture](xref:Supported_system_data_storage_architectures).

## Limits

The limits provided below override any similar, general DataMiner [limits](xref:dataminer_metrics#limits) under the scope of the EPM VSAT solution.  

| \# | Specification | Scope | Metric | Remarks |
| -- | ------------- | ----- | ------- | ------- |
| 1 | Number of VSAT remotes | DMA | 5,000 ||
| 2 | Number of trended parameters | VSAT Remote | 20 ||
| 3 | Performance parameters polling rate | Element | 5 minutes | When the data point resolution is lower than the polling rate, DataMiner will perform [history sets](xref:history_set_benchmarks) to ensure all data is properly retrieved. |
| 4 | Performance parameters data point resolution | VSAT Remote | 20 seconds ||
