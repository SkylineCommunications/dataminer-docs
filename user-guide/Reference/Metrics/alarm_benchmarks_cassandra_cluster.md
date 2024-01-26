---
uid: alarm_benchmarks_cassandra_cluster
---

# Alarm benchmarks for Cassandra Cluster setup

## Specifications of the test server and client

### Metrics

Server:

- Intel Core i7-6770HQ CPU @ 2.60GHz
- 32 GB RAM
- Cassandra (clustered - 3 nodes)
- Elasticsearch (clustered - 3 nodes)
- Windows 10 Pro

Client:

- Intel(R) Core(TM) i7-9700 CPU @ 3.00GHz
- 4 cores
- 32 GB RAM
- Windows 11 Enterprise

## Benchmarks

| \# | Specification | Scope | Metric (Cassandra) | Metric (Cassandra Cluster) | Remarks | Configuration |
| -- | ------------- | ----- | ------------------ | ------------------------- | ------- | ------------- |
| 1  | Retrieve all current alarms (21,823) | DMS | 17.81 s | 17.14 s | Includes the loading from the remote database and the processing in Cube. | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 2 | Retrieve current alarms on a specific service (20,000) | DMS | 17.33 s | 17.23 s | Includes the loading from the remote database and the processing in Cube. | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 3 | Retrieve current alarms on a specific view (20,000) | DMS | 17.41 s | 17.49 s | Includes the loading from the remote database and the processing in Cube. | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 4 | Retrieve current alarms on a specific element (2,000) | DMS | 2.85 s | 2.56 s | Includes the loading from the remote database and the processing in Cube. | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 5 | Retrieve all alarms of last 24h | DMS | 26.07 s | 35.78 s | Test retrieves all alarms of the last 24h (26,053). | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 6 | Retrieve all alarms of last 24h on a specific service | DMS | 0.06 s | 0.28 s |Test retrieves all service alarms of the last 24h (316). | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 7 | Retrieve all alarms of last 7 days on a specific service | DMS | 2.03 s | 4.33 s | Test retrieves all service alarms of the last week (6,316).| DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 8 | Retrieve all alarms of last 356 days on a specific service | DMS | 36.44 s | 75.89 s | Test retrieves all service alarms of the last year (200,000). | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 9 | Retrieve all alarms of last 24h on a specific view | DMS | 0.06 s | 0.23 s | Test retrieves all view alarms of the last 24h (309). | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 10 | Retrieve all alarms of last 7 days on a specific view | DMS | 1.75 s | 4.92 s | Test retrieves all view alarms of the last week (6,309). | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 11 | Retrieve all alarms of last 356 days on a specific view | DMS | 34.87 s | 78.49 s | Test retrieves all view alarms of the last year (200,000). | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 12 | Retrieve all alarms of last 24h on a specific element | DataMiner Cube | 0.07 s | 0.37 s | Test retrieves all element alarms of the last 24h (316). | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 13 | Retrieve all alarms of last 7 days on a specific element | DataMiner Cube | 2.31 s | 5.91 s | Test retrieves all element alarms of the last week (6,316). | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 14 | Retrieve all alarms of last 356 days on a specific element | DMA | 35.93 s | 73.06 s | Test retrieves all element alarms of the last year (200,000). | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 15 | Add the Severity Duration column on a busy system | DMS | 3.47 s | 3.52 s | Tested on a system with a large number of incoming alarms. | |

> [!NOTE]
> In a Cassandra Cluster setup, the alarms are stored in an OpenSearch or Elasticsearch database, which is not optimized for time-based queries. This is why time-based history alarm queries are returned a bit slower in this setup.
