---
uid: trend_benchmarks
---

# Trending benchmarks

## Specifications of the test server and client

### Metrics

Server:

- Intel Core i7-6770HQ CPU @ 2.60GHz
- 32 GB RAM
- Cassandra (clustered - 3 nodes)
- Windows 10 Pro

Client:

- Intel(R) Core(TM) i7-9700 CPU @ 3.00GHz
- 4 cores
- 32 GB RAM
- Windows 11 Enterprise

## Benchmarks

| \# | Specification | Scope | Metric (Cassandra) | Metric (Cassandra Cluster) | Remarks | Configuration |
| -- | ------------- | ----- | ------------------ | ------------------------- | ------- | ------------- |
| 1  | Retrieve last 24 hours trending (average data) | DMS | 0.11 s | 0.41 s | Random data was created by making history sets for one year. 56 average data points returned. | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 2 | Retrieve last 24 hours trending (real-time data) | DMS | 0.08 s | 0.10 s | Random data was created by making history sets for one year. 100 real-time data points returned. | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 3 | Retrieve last week trending (average data) | DMS | 0.10 s | 0.41 s | Random data was created by making history sets for one year. 1,117 average data points returned. | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 4 | Retrieve last week trending (real-time data) | DMS | 0.07 s | 0.12 s | Random data was created by making history sets for one year. 100 real-time data points returned. | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 5 | Retrieve last year trending (average data) | DMS | 2.51 s | 1.92 s | Random data was created by making history sets for one year. 57,508 average data points returned. | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 6 | Retrieve last year trending (real-time data) | DMS | 0.09 s | 0.15 s | Random data was created by making history sets for one year. 100 real-time data points returned. | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 7 | Click the trend graph icon on a Microsoft Platform Element (Total Processor Load) | DMS | 0.38 s | 0.45 s | Data is accumulated over a day of running. Default window shows 24 hours of data (16,692 real-time data points). | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
