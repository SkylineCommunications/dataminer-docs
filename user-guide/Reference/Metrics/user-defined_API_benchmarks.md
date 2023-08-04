---
uid: user-defined_API_benchmarks
---

# User-Defined APIs benchmarks

## Specifications of the test VM server

- Intel Core Xeon E5-2620 v4
- 8 cores (16 threads)
- 32GB RAM
- HDD (RAID)
- Windows 10

## Specifications of the test client

- Intel Core i7-12700
- 12 cores (20 threads)
- 32GB RAM
- SSD (NVMe)
- Windows 11

## Benchmarks

| \# | Specification | Scope | Metric | Configuration | Comments |
| -- | ------------- | ----- | ------ | ------------- | -------- |
| 1 | Time for the client to retrieve 2500 API tokens and 2500 API definitions from the server | DMA | 2s - 2.5s | Clean DMA without other data | |
| 2 | Time for the client to show 2500 API tokens and 2500 API definitions in DataMiner Cube (including the time to retrieve these from the server) | Cube | 3s - 3.5s | Clean DMA without other data | |
| 3 | Request duration, up to 40 requests per second | DMS | Average: 45ms<br/>p(90): 60ms<br/>p(95): 67ms | Script that receives 100 bytes and immediately returns it | With a trivial script, the endpoint is the bottleneck, so the number of Agents in the cluster has no impact. For scripts with a longer run time, the number of Agents in the cluster will have a big impact, as the load will be spread over these Agents. |
| 4 | Max request rate | DMS | 120 requests per second, with a request duration of 350 ms | Script that receives 100 bytes and immediately returns it | Starting from 50 requests per second, the average response time increases. The maximum is reached around 120 requests per second, at a request duration of 350 ms. |
