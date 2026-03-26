---
uid: parameter_set_benchmarks
---

# Parameter set benchmarks

## Specifications of the test server

- HDD
- Microsoft Windows Server 2016 Standard

## Benchmarks

| \# | Specification | Scope | Metric |
| -- | ------------- | ----- | ------ |
| 1 | Performing 100 SetParameter calls in an automation script (without subscribing) | Automation | 7 s |
| 2 | Performing a SetParameter call and waiting for the ParameterChangeEventMessage in an automation script (average of 100 iterations) | Automation | 0.16 s |
| 3 | Performing SetRows on a table of 18 columns and 1,000 rows with 14 columns being updated for 10 seconds, expressed in cell updates per second. Does not check if buffers are growing, this is meant as a burst. | DMA | 10,000 cells/s |
| 4 | Performing SetColumns on a table of 18 columns and 1,000 rows with 14 columns being updated for 10 seconds, expressed in cell updates per second. Does not check if buffers are growing, this is meant as a burst. | DMA | 25,000 cells/s |
| 5 | Performing SetParametersIndexByKey on a table of 18 columns and 1,000 rows with 14 columns being updated for 10 seconds (with one call containing the entire table), expressed in cell updates per second. Does not check if buffers are growing, this is meant as a burst. | DMA | 3,500 cell/s |
| 6 | Performing FillArray on a table of 18 columns and 1,000 rows with 14 columns being updated for 10 seconds (with one call containing the entire table), expressed in cell updates per second. Does not check if buffers are growing, this is meant as a burst. | DMA | 25,000 cells/s |
