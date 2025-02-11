---
uid: user-defined_API_benchmarks
---

# User-Defined APIs benchmarks

> [!NOTE]
> Keep in mind that when the API script executes heavy actions that put a load on the system, the expected throughput and latency of the API triggers may be much lower. Also, consider the existing load on the DMS, which could already impact the API call time.

## [From DataMiner 10.4.9/10.5.0 onwards](#tab/tabid-1)

<!--RN 39701-->

### Specifications of the test VM server

- Intel Core Xeon E5-2620 v4
- 8 cores (16 threads)
- 32 GB RAM
- HDD (RAID)
- Windows server 2016

### Specifications of the test client

- Intel Core i7-10700
- 8 cores (16 threads)
- 32 GB RAM
- SSD (NVMe)
- Windows 11

### Benchmarks

| \# | Specification | Scope | Metric | Configuration | Comments |
| -- | ------------- | ----- | ------ | ------------- | -------- |
| 1 | Time for the client to retrieve 2500 API tokens and 2500 API definitions from the server | DMA | 0.6s | Clean DMA without other data | |
| 2 | Time for the client to show 2500 API tokens and 2500 API definitions in DataMiner Cube (including the time to retrieve these from the server) | Cube | 1s - 1.5s  | Clean DMA without other data | |
| 3 | Request duration, up to 40 requests per second | DMS | Average: 13ms<br/>p(90): 15ms<br/>p(95): 21ms | Script that receives 100 bytes and immediately returns it | With a trivial script, the endpoint is the bottleneck, so the number of Agents in the cluster has no impact. For scripts with a longer run time, a larger number of Agents in the cluster will have a big positive impact and increase the maximum throughput, as the load will be spread over all these Agents. |
| 4 | Max request rate | DMS | 80 requests per second, with a request duration of 13 ms | Script that receives 100 bytes and immediately returns it | Up to 80 requests per second, the average response time remains 13 ms. Beyond 80 requests per second, the average response time increases. |

## [Prior to DataMiner 10.4.9/10.5.0](#tab/tabid-2)

### Specifications of the test VM server

- Intel Core Xeon E5-2620 v4
- 8 cores (16 threads)
- 32 GB RAM
- HDD (RAID)
- Windows server 2016

### Specifications of the test client

- Intel Core i7-12700
- 12 cores (20 threads)
- 32 GB RAM
- SSD (NVMe)
- Windows 11

### Benchmarks

| \# | Specification | Scope | Metric | Configuration | Comments |
| -- | ------------- | ----- | ------ | ------------- | -------- |
| 1 | Time for the client to retrieve 2500 API tokens and 2500 API definitions from the server | DMA | 2s - 2.5s | Clean DMA without other data | |
| 2 | Time for the client to show 2500 API tokens and 2500 API definitions in DataMiner Cube (including the time to retrieve these from the server) | Cube | 3s - 3.5s | Clean DMA without other data | |
| 3 | Request duration, up to 40 requests per second | DMS | Average: 45ms<br/>p(90): 60ms<br/>p(95): 67ms | Script that receives 100 bytes and immediately returns it | With a trivial script, the endpoint is the bottleneck, so the number of Agents in the cluster has no impact. For scripts with a longer run time, the number of Agents in the cluster will have a big impact, as the load will be spread over these Agents. |
| 4 | Max request rate | DMS | 50 requests per second, with a request duration of 45 ms | Script that receives 100 bytes and immediately returns it | Up to 50 requests per second, the average response time remains 45 ms. Beyond 50 requests per second, the average response time increases. |

***
