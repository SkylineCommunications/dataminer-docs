---
uid: failover_benchmarks
---

# Failover benchmarks

## Specifications of the test server

\-

## Benchmarks

| \# | Specification | Scope | Metric | Remarks | Configuration |
| -- | ------------- | ----- | ------ | ------- | ------------- |
| 1 | Switch frequency | DataMiner Failover | 1 switch every 15 minutes |||
| 2 | Failover switch time MySQL | DataMiner Failover | 848 s | Average over \>300 runs | MySQL Failover cluster |
| 3 | Failover switch time Cassandra | DataMiner Failover | 382 s | Average over \>600 runs | Cassandra Failover cluster |
