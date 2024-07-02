---
uid: history_set_benchmarks
---

# History set benchmarks

## Specifications of the test servers

### Metrics 1-2

- Intel Xeon E5-2620 v4
- 2 sockets
- 32 GB RAM
- Windows Server 2012 R2

### Metrics 3-6

- Microsoft Windows Server 2016 Standard

## Benchmarks

| \# | Specification | Scope | Metric | Remarks | Configuration |
| -- | ------------- | ----- | ------ | ------- | ------------- |
| 1 | Fill array with 2.5 million history sets | DMA | 150 s | Fills table with 2.5 million history sets | No other tests running. |
| 2 | Flush data to database | DMA | 44.10 s | Flush the 2.5 million history sets to database | No other tests running. |
| 3 | Performing history SetRows on a table of 18 columns and 1,000 rows with 14 columns being updated for 10 seconds, expressed in cell updates per second. Does not check if buffers are growing, this is meant as a burst. | DMA | 9.500 cells/s |||
| 4 | Performing history SetColumns on a table of 18 columns and 1,000 rows with 14 columns being updated for 10 seconds, expressed in cell updates per second. Does not check if buffers are growing, this is meant as a burst. | DMA | 24.000 cells/s |||
| 5 | Performing history SetParametersIndexByKey on a table of 18 columns and 1,000 rows with 14 columns being updated for 10 seconds (with one call containing the entire table), expressed in cell updates per second. Does not check if buffers are growing, this is meant as a burst. | DMA | 3.000 cell/s |||
| 6 | Performing history FillArray on a table of 18 columns and 1,000 rows with 14 columns being updated for 10 seconds (with one call containing the entire table), expressed in cell updates per second. Does not check if buffers are growing, this is meant as a burst. | DMA | 24.000 cells/s |||
