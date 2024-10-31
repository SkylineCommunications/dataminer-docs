---
uid: swarming_bookings_benchmarks
---

# Swarming bookings benchmarks

## Specifications of the test server

- Intel Xeon Silver 4110 CPU @ 2.10GHz
- 32 GB RAM
- Windows Server 2019 Standard
- DataMiner v10.5.1.0

## Benchmarks

| \# | Specification | Scope | Metric (Cassandra cluster) | Metric (STaaS) |
| -- | ------------- | ----- | ------ | ------- |
| 1 | Average time to swarm one booking | DMS | 0.093 s | 0,276 s |
| 2 | Time to swarm 500 bookings in bulk | DMS | 16,674 s | 30,298 s |
