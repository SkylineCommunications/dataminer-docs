---
uid: alarm_benchmarks
---

# Alarm benchmarks

## Specifications of the test servers and clients

### Metrics 1-11 & 15

- Intel Xeon E5-2620 v4
- 2 sockets
- 16 GB RAM
- MySQL
- Windows Server 2012 R2

### Metric 12

Server:

- Intel Xeon CPU E5-2620 v4 @ 2.1GHz
- 8 cores
- 22GB RAM
- SSD
- Cassandra (single node) + Elasticsearch
- Windows Server 2016 Standard

Client:

- Intel Core i5-4590 CPU @ 3.30GHz
- 4 cores
- 16GB RAM
- Windows 10 Pro 20H2

### Metric 13

Server:

- Intel Core i7-9700 CPU @ 3.00GHz
- 6 cores
- 32GB RAM
- SSD
- Cassandra
- Windows Server 2016 Standard

Client:

- Intel Core i5-4590 CPU @ 3.30GHz
- 4 cores
- 16GB RAM
- Windows 10 Enterprise

### Metric 16 & 17

Client:

- Intel(R) Core(TM) i7-9700 CPU @ 3.00GHz
- 4 cores
- 32GB RAM
- Windows 11 Enterprise

## Benchmarks

| \# | Specification | Scope | Metric | Remarks | Configuration |
| -- | ------------- | ----- | ------ | ------- | ------------- |
| 1  | Retrieve current alarms on services (2,000) | DMS | 2.28 s | Test creates 2,000 service alarms and checks the time to retrieve these. | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 2 | Retrieve current alarms on views (28,622) | DMS | 4.28 s | Test retrieves all current view alarms (28,622) | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 3 | Retrieve current alarms on elements (20,000) | DMS | 16.46 s | Test retrieves all current element alarms (20,000) | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 4 | Retrieve all alarms of last 24h | DMS | 27.11 s | Test retrieves all alarms of the last 24h (28,622) | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 5 | Retrieve all service alarms of last 24h | DMS | 2.24 s | Test retrieves all service alarms of the last 24h (2,000) | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 6 | Retrieve all view alarms of last 24h | DMS | 27.96 s | Test retrieves all view alarms of the last 24h (28,622) | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 7 | Retrieve all element alarms of last 24h | DMS | 17.22 s | Test retrieves all element alarms of the last 24h (20,000) | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 8 | Retrieve all alarms of last hour | DMS | 26.95 s | Test retrieves all alarms of the last hour (28,622) | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 9 | Retrieve all service alarms of last hour | DMS | 2.13 s | Test retrieves all service alarms of the last hour (2,000) | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 10 | Retrieve all view alarms of last hour | DMS | 25.87 s | Test retrieves all view alarms of the last hour (28,622) | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 11 | Retrieve all element alarms of last hour | DMS | 16.07 s | Test retrieves all element alarms of the last hour (20,000) | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 12 | Time needed for DataMiner Cube to handle 10,000 incoming information events | DataMiner Cube | 18.4 s | No other load or incoming alarms ||
| 13 | Adding the Severity Duration column on a busy system | DataMiner Cube | 2 s | Tested on a system with a large amount of incoming alarms ||
| 14 | Create 1,000 alarms using addrow operations | DMA | 2.8 s | Waiting for alarm events after creating 1,000 rows | Clean DMA. |
| 15 | Retrieve all current alarms (28,622) | DMS | 26.48 s | Test creates 28,622 alarms spread over elements, services, DVE element, etc., and measures the time it takes to retrieve them. | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 16 | Retrieve all alarms of last 24h | DMS | 1 m | The DMS used Cassandra and the time includes the loading from the server and the processing in Cube. | The DMS had about 5000 active alarms and an update each second. |
| 17 | Retrieve all alarms of last 24h | DMS | 2 m 30 s | The DMS used Cassandra Cluster and the time includes the loading from the server and the processing in Cube. | The DMS had about 3000 active alarms and an update each second. |
