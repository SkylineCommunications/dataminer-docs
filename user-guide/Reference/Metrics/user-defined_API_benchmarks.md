---
uid: user-defined_API_benchmarks
---

# User-defined API benchmarks

## Specifications of the test VM server 1

- Intel Core i7-12700
- 8 cores
- 32GB RAM
- HDD
- Windows 10

## Specifications of the test client PC 1

- Intel Core i7-12700
- 12 cores
- 32GB DDR-5 RAM
- SSD
- Windows 11

## Benchmarks

| \# | Specification | Scope | Metric | Configuration |
| -- | ------------- | ----- | ------ | ------------- |
| 1 | Server call duration of 2500 API tokens and 2500 API definitions from server 1 to client 1 | DMA | 2s - 2.5s | Clean DMA, no other data |
| 2 | Load testing of 2500 API tokens and 2500 API definitions in DataMiner Cube of client 1 | Cube | 3s - 3.5s | Clean DMA, no other data |
