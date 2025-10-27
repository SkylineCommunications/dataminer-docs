---
uid: element_benchmarks
---

# Element benchmarks

## Specifications of the test server

- Intel Core i5-6500 CPU @ 3.20GHz
- 4 cores
- 16 GB RAM
- HDD
- Cassandra
- Windows 10 Enterprise

## Benchmarks

| \# | Specification | Scope | Metric | Configuration |
| -- | ------------- | ----- | ------ | ------------- |
| 1 | Time it takes to create 1 element | DMS | 211 ms | Clean DMA, no other data. |
| 2 | Average creation time per element when creating 50. | DMS | 450 ms | Clean DMA, no other data. |
| 3 | Average removal time per element when removing 50. | DMS | 360 ms | Clean DMA, no other data. |
