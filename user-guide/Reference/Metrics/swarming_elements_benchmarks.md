---
uid: swarming_elements_benchmarks
---

# Swarming elements benchmarks

## Benchmarks

| \# | Specification | Scope | Metric | Test Setup |
| -- | ------------- | ----- | ------ | -------- |
| 1 | Swarming 1 element | DMS | 0.591&nbsp;s | DaaS cluster. |
| 2 | Swarming 10 elements | DMS | 1.590&nbsp;s | DaaS cluster. |
| 3 | Swarming 100 elements | DMS | 9.670&nbsp;s | DaaS cluster. |
| 4 | Raw swarming time for 1 element | DMS | 0.154&nbsp;s | DaaS cluster.<br> Measured swarm action only, without time needed to start the element. |
| 5 | Failover switch 100 elements | DMS | 50&nbsp;s | Non-swarming system. Measured until Cube availability. Nothing else on the Failover Agent. |
| 6 | Swarming 100 elements (Failover-like switchover) | DMS | 10&nbsp;s | On-premises STaaS. Measured until all swarm actions were completed. Elements became available one by one. |
| 7 | Element startup (100 elements present) (non-swarming) | DMS | 4.862&nbsp;s | DaaS Cluster. Non-swarming system (loading element config from XML) |
| 8 | Element startup (100 elements present) | DMS | 5.256&nbsp;s | DaaS Cluster. Swarming system (loading element config from database) |
| 9 | Setting element property | DMS | 0.024&nbsp;s | Non-swarming, 10.5.2 |
| 10 | Setting element property | DMS | 0.025&nbsp;s | Swarming-enabled dedicated clustered storage setup, 10.5.2 |
| 11 | Setting element property | DMS | 0.070&nbsp;s | Swarming-enabled STaaS setup, 10.5.2 |

## General Notes

- Benchmarks were taken with simple elements that do not require much loading of element data/alarm events from the database on element startup. The measurements mainly show the time needed to swarm an element aside from the element startup.
- Measured per element, swarming multiple elements is faster, as multiple elements can be swarmed simultaneously.
- Measurements are for swarm actions towards one Agent. Parallel swarm actions to multiple targets will provide better timing.
