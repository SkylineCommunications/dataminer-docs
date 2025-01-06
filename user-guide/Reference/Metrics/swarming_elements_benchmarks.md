---
uid: swarming_bookings_benchmarks
---

# Swarming bookings benchmarks

## Benchmarks

| \# | Specification | Scope | Metric | Test Setup |
| -- | ------------- | ----- | ------ | -------- |
| 1 | Swarming 1 element | DMS | 0.591 s | DaaS cluster. |
| 2 | Swarming 10 elements | DMS | 1.590  s | DaaS cluster. |
| 3 | Swarming 100 elements | DMS | 9.670 s | DaaS cluster. |
| 4 | Raw swarming time for 1 element | DMS | 0.154 s | DaaS cluster.<br /> Measured swarm action only, without time needed to start the element. |
| 5 | Failover switch 100 elements | DMS | 50 s | Non-swarming system. Measured until Cube availability. |
| 6 | Swarming 100 elements (Failover-like switchover) | DMS | 10 s | First element available after 2 seconds. |
| 7 | Agent startup with 100 elements present | DMS | 6.353 s | Loading from DB. |
| 8 | Agent startup with 100 elements present (non-Swarming) | DMS | 2.853 s | Non-swarming system (Loading from XML) |
| 9 | Setting element property | DMS | 0.024ms | Non-Swarming, 10.5.2 |
| 10 | Setting element property | DMS | 0.025ms | Swarming-enabled CassandraCluster config, 10.5.2 |
| 11 | Setting element property | DMS | 0.070ms | Swarming-enabled STaaS config, 10.5.2 |

## General Notes

- Benchmarks were taken with simple elements that do not require loading much element data/alarm events from the database on element startup. The measurements mainly show the time needed to swarm an element aside from the element startup.
- Measured per element, swarming multiple elements is faster as multiple elements can be swarmed simultaneously.
- Measurements are for swarm actions towards one agent.
