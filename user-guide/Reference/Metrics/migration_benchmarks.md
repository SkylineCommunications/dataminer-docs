---
uid: migration_benchmarks
---

# Migration benchmarks

## Specifications of the test server

Server:

- Intel Core i7-6770HQ CPU @ 2.60GHz
- 32 GB RAM
- Cassandra (clustered - 3 nodes)
- OpenSearch (clustered - 3 nodes)
- Windows 10 Pro

Client:

- Intel(R) Core(TM) i7-9700 CPU @ 3.00GHz
- 4 cores
- 32 GB RAM
- Windows 11 Enterprise

## Benchmarks

| \# | Specification | Scope | Metric | Increase | Configuration |
| -- | ------------- | ----- | ------ | -------- | ------------- |
| 1 | The time it takes to migrate 20 GB of data from a local MySql database to a remote Cassandra cluster. | DMS | 14h 42m | | The DMA contains 20 elements, each having generated part of the data. The DataMiner Agent was running during the migration. |
| 2 | The time it takes to migrate 20 GB of data from a local Cassandra database to a remote Cassandra cluster. | DMS | 13h 51m | | The DMA contains 20 elements, each having generated part of the data. The DataMiner Agent was running during the migration. |
| 3 | Create 1,000 alarms while the migration is running  | DMS | 5.81 s | This is an increase of 26.58 % compared to before the migration was started. | |
| 4 | Write 1,000 trend points while the migration is running  | DMS | 8.70 s | This is an increase of 11.68 % compared to before the migration was started. | |
| 5 | Set 100,000 parameters while the migration is running  | DMS | 23.14 s | This is an increase of 20.14 % compared to before the migration was started. | |
| 6 | Retrieve last 24 hours of alarms while the migration is running  | DMS | 15.39 s | This is an increase of 25.14 % compared to before the migration was started. | Test retrieves all alarms of the last 24h (28,053). |
| 7 | Retrieve last 24 hours of trending (real-time data) while the migration is running  | DMS | 140 ms | This is an increase of 23.62 % compared to before the migration was started. | Test retrieves all real-time data points of the last 24h (100). |
| 8 | Create a new element while the migration is running  | DMS | 270 ms | This is an increase of 8.34 % compared to before the migration was started. | |
| 9 | Create table rows on an element while the migration is running  | DMS | 32,54 s | This is an increase of 14.28 % compared to before the migration was started. | The element has 4 tables with 10,000 rows each. |
| 10 | Restart an element while the migration is running  | DMS | 24,12 s | This is an increase of 27.27 % compared to before the migration was started. | The element has 4 tables with 10,000 rows each. |
