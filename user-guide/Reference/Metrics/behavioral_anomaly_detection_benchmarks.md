---
uid: behavioral_anomaly_detection_benchmarks
---

# Behavioral anomaly detection benchmarks

## Specifications of the test server

- Intel Core i7-8700
- 6 cores
- 16 GB RAM
- SSD
- Windows 10

## Benchmarks

| \# | Specification | Scope | Metric | Remarks | Configuration |
| -- | ------------- | ----- | ------ | ------- | ------------- |
| 1 | Maximum number of parameters per DMA on which Behavioral Anomaly Detection is active | DMA | 100,000 parameters | Hard limit of 100,000 parameters to avoid using more than 2 GB of RAM on the DMA. | Clean DMA, no other data. |
