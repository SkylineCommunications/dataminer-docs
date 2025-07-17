---
uid: alarm_focus_benchmarks
---

# Alarm focus benchmarks

## Specifications of the test server

- Intel Xeon E5-2620 v4
- 2 sockets
- 16 GB RAM
- Cassandra
- Windows Server 2012 R2

## Benchmarks

| \# | Specification | Scope | Metric | Remarks | Configuration |
| -- | ------------- | ----- | ------ | ------- | ------------- |
| 1 | Calculate focus events for 2,000 alarms on new parameters | DMA | 69 s | The alarms are created on parameters that did not have alarms before. Therefore, this represents the worst case scenario, as the database record for focus data is not cached. | No other tests running. |
