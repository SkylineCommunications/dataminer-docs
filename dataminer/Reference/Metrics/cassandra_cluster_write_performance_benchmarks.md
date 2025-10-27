---
uid: cassandra_cluster_write_performance_benchmarks
---

# Cassandra (cluster) write performance benchmarks

## Specifications of the test server (Cassandra single node)

- Intel Xeon Silver 4110 CPU @ 2.1GHz
- 16 GB RAM
- Cassandra (Single node)

## Specifications of the test server (Cassandra Cluster)

- Intel(R) Core(TM) i7-6770HQ CPU @ 2.60GHz
- 32 GB RAM
- Cassandra (remote cluster)
- Elasticsearch (remote cluster)

## Benchmarks

| \# | Specification                                         | Scope | Metric (Cassandra Single-Node) | Metric (Cassandra Cluster) |
|----|-------------------------------------------------------|-------|--------------------------------|----------------------------|
| 1  | Write 10,000 alarms to Cassandra                      | DMA   | 189.66 s                       | 98.02 s                    |
| 2  | Write 10,000 real-time trend data points to Cassandra | DMA   | 48.62 s                        | 22.91 s                    |
| 3  | Write 10,000 average trend data points to Cassandra   | DMA   | 54.86 s                        | 34.97 s                    |
| 4  | Write 10,000 Elementdata points to Cassandra          | DMA   | 25.18 s                        | 20.30 s                    |
