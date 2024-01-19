---
uid: cassandra_write_performance_benchmarks
---

# Cassandra (single node) write performance benchmarks

## Specifications of the test server

- Intel Xeon Silver 4110 CPU @ 2.1GHz
- 16 GB RAM
- Cassandra (Single node)

## Benchmarks

| \# | Specification | Scope | Metric |
| -- | ------------- | ----- | ------ |
| 1 | Write 10,000 alarms to Cassandra (single node) | DMA | 189.66 s |
| 2 | Write 10,000 real-time trend data points to Cassandra (single node) | DMA | 48.62 s |
| 3 | Write 10,000 average trend data points to Cassandra (single node) | DMA | 54.86 s |
| 4 | Write 10,000 Elementdata points to Cassandra (single node) | DMA | 25.18 s |
