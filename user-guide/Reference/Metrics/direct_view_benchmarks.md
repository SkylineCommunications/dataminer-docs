---
uid: direct_view_benchmarks
---

# Direct view benchmarks

## Specifications of the test server

- Intel Core i7-9700 CPU @ 3.00GHz
- 8 cores
- 32 GB RAM
- SSD
- Cassandra
- Windows 10 Pro

## Benchmarks

| \# | Specification | Scope | Metric | Remarks |
| -- | ------------- | ----- | ------ | ------- |
| 1 | Updates for 200 rows in source elements that have 1,000 rows on standalone agent | Direct Views | 26 s | Part of performance test for benchmarking direct views |
| 2 | Updates for 200 rows in source elements that have 10,000 rows on standalone agent | Direct Views | 88 s | Part of performance test for benchmarking direct views |
| 3 | Updates for 200 rows in source elements that have 25,000 rows on standalone agent | Direct Views | 240 s | Part of performance test for benchmarking direct views |
| 4 | Updates for 200 rows in source elements that have 50,000 rows on standalone agent | Direct Views | 610 s | Part of performance test for benchmarking direct views |
| 5 | Updates for 200 rows in source elements that have 1,000 rows across cluster | Direct Views | 58 s | Part of performance test for benchmarking direct views |
| 6 | Updates for 200 rows in source elements that have 10,000 rows across cluster | Direct Views | 330 s | Part of performance test for benchmarking direct views |
| 7 | Updates for 200 rows in source elements that have 25,000 rows across cluster | Direct Views | 960 s | Part of performance test for benchmarking direct views |
| 8 | Updates for 200 remotely linked rows on a direct view that has 1,000 rows on a standalone agent | Direct Views | 400 ms | Part of performance test for benchmarking direct views |
| 9 | Updates for 200 remotely linked rows on a direct view that has 10,000 rows on a standalone agent | Direct Views | 420 ms | Part of performance test for benchmarking direct views |
| 10 | Updates for 200 remotely linked rows on a direct view that has 25,000 rows on a standalone agent | Direct Views | 600 ms | Part of performance test for benchmarking direct views |
| 11 | Updates for 200 remotely linked rows on a direct view that has 50,000 rows on a standalone agent | Direct Views | 1.1 s | Part of performance test for benchmarking direct views |
| 12 | Updates for 200 rows in source elements with a filter on local data on a direct view that has 1,000 rows on a standalone agent | Direct Views | 2.2 s | Part of performance test for benchmarking direct views |
| 13 | Updates for 200 rows in source elements with a filter on local data on a direct view that has 10,000 rows on a standalone agent | Direct Views | 23.3 s | Part of performance test for benchmarking direct views |
| 14 | Updates for 200 rows in source elements with a filter on local data on a direct view that has 25,000 rows on a standalone agent | Direct Views | 64 s | Part of performance test for benchmarking direct views |
| 15 | Updates for 200 rows in source elements with a filter on local data on a direct view that has 50,000 rows on a standalone agent | Direct Views | 131 s | Part of performance test for benchmarking direct views |
| 16 | Updates for 200 rows in source elements with a filter on local data on a direct view that has 1,000 rows across cluster | Direct Views | 4.3 s | Part of performance test for benchmarking direct views |
| 17 | Updates for 200 rows in source elements with a filter on local data on a direct view that has 10,000 rows across cluster | Direct Views | 48 s | Part of performance test for benchmarking direct views |
| 18 | Updates for 200 rows in source elements with a filter on local data on a direct view that has 25,000 rows across cluster | Direct Views | 130 s | Part of performance test for benchmarking direct views |
