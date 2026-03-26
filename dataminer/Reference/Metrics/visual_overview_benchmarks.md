---
uid: visual_overview_benchmarks
---

# Visual Overview benchmarks

## Specifications of the test servers and clients

### Metric 1

- Intel Core i7-9700 CPU @ 3.00GHz
- 6 cores
- 32 GB RAM
- SSD
- Cassandra & Elasticsearch
- Windows 10 Pro

### Metric 2

Server:

- Intel Xeon CPU E5-2620 v4 @ 2.1GHz
- 8 cores
- 22 GB RAM
- SSD
- Cassandra (single node) & Elasticsearch
- Windows Server 2016 Standard

Client:

- Intel Core i5-4590 CPU @ 3.30GHz
- 4 cores
- 16 GB RAM
- Windows 10 Pro 20H2

### Metric 3

Server:

- Intel i7-10750H
- 12 cores
- 40 GB RAM
- SSD
- Windows 10

Client:

- Intel Core i5-4590 CPU @ 3.30GHz
- 4 cores
- 16 GB RAM
- Windows 10 Pro 20H2

## Benchmarks

| \# | Specification | Scope | Metric | Remarks | Configuration |
| -- | ------------- | ----- | ------ | ------- | ------------- |
| 1 | Loading history alarm states of shapes linked to an element/parameter | DMA | 2 s | Tested with 210 shapes that were all linked to an element/parameter. ||
| 2 | Sort 3,000 child shapes | DataMiner Cube | 7.16 s | No filtering was active. ||
| 3 | Children shape: Loading of child shapes | DataMiner Cube | 3,000 shapes in 14 s |  | 3,000 service children in a view, with no dynamic parts in any of the shape data except ChildrenSort (e.g., ChildrenFilter). |
