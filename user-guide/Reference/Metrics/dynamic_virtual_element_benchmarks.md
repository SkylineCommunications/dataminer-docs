---
uid: dynamic_virtual_element_benchmarks
---

# Dynamic virtual element benchmarks

## Specifications of the test server

- Intel Xeon E5-2620 v17
- 2 sockets
- 32GB RAM
- Windows Server 2012 R2

## Benchmarks

| \# | Specification | Scope | Metric | Remarks | Configuration |
| -- | ------------- | ----- | ------ | ------- | ------------- |
| 1 | Time to create 100 DVEs | DMA | 117 s | Create 100 DVEs from 1 main element | No other tests running. |
| 2 | Time to remove 100 DVEs | DMA | 48 s | Remove 100 DVEs from 1 main element | No other tests running. |
