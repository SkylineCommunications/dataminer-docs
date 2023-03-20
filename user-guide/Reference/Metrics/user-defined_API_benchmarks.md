---
uid: user-defined_API_benchmarks
---

# User-defined API benchmarks

## Specifications of the test VM server

- Intel Core i7-12700
- 8 cores
- 32GB RAM
- HDD
- Windows 10

## Specifications of the test client

- Intel Core i7-12700
- 12 cores
- 32GB DDR-5 RAM
- SSD
- Windows 11

## Benchmarks

| \# | Specification | Scope | Metric | Configuration |
| -- | ------------- | ----- | ------ | ------------- |
| 1 | Time for the client to retrieve 2500 API tokens and 2500 API definitions from the server | DMA | 2s - 2.5s | Clean DMA without other data |
| 2 | Time for the client to show 2500 API tokens and 2500 API definitions in DataMiner Cube (including the time to retrieve these from the server) | Cube | 3s - 3.5s | Clean DMA without other data |
