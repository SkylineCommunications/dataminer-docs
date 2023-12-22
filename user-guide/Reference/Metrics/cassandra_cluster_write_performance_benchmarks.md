---
uid: cassandra_cluster_write_performance_benchmarks
---

# Cassandra (cluster) write performance benchmarks

## Specifications of the test server

- Intel(R) Core(TM) i7-6770HQ CPU @ 2.60GHz 
- 32GB RAM
- Cassandra (remote cluster)
- Elasticsearch (remote cluster)

## Benchmarks

| \# | Specification | Scope | Metric |
| -- | ------------- | ----- | ------ |
| 1 | Writing 10,000 alarms to Cassandra (cluster) | DMA | 98.02 s |
| 2 | Writing 10,000 real-time trend data points to Cassandra (cluster) | DMA | 22.91 s |
| 3 | Writing 10,000 average trend data points to Cassandra (cluster) | DMA | 34.97 s |
| 4 | Writing 10,000 Elementdata points to Cassandra (cluster) | DMA | 20.30 s |
