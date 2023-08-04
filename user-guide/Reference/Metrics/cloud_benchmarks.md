---
uid: cloud_benchmarks
---

# dataMiner.services benchmarks

## Specifications of the test servers

### Metrics 1-3

- Intel(R) Core(TM) i7-8700 CPU @ 3.20GHz
- 12 cores
- 32GB RAM
- SSD
- Windows 10 Pro

### Metrics 4-5

- Intel(R) Core(TM) i5-6500 CPU @ 3.20GHz
- 4 cores
- 16GB RAM
- SSD
- Windows 10 Pro

## Benchmarks

| \# | Specification | Scope | Metric | Remarks |
| -- | ------------- | ----- | ------ | ------- |
| 1 |	Evaluation of API call through the Web Application Firewall (WAF), e.g. for a shared dashboard.<br>Evaluation of 50 simple static rules per request, with 200 threads running in parallel. | DMS | 730,000 evaluations/second ||
| 2 |	Evaluation of API call through the Web Application Firewall (WAF), e.g. for a shared dashboard.<br>Evaluation of 50 simple custom filter rules per request, with 200 threads running in parallel. |	DMS | 35,000 evaluations/second ||
| 3 | Evaluation of API call through the Web Application Firewall (WAF), e.g. for a shared dashboard.<br>Evaluation of 50 rules with simple custom filter with LINQ operation, with 200 threads running in parallel.<br>LINQ operation executed on a collection of 1,000 items. |	DMS |	644 evaluations/second ||
| 4 |	Time to create 10 shares with blank dashboards. |	DMS |	83 s | Test ran 4 times. The average time was taken from the results. |
| 5 | Time it takes for a single shared item to become available. |	DMS | 55,122 ms |	Test ran 4 times. The average time was taken from the results.<br>First-time share is roughly twice as slow compared to any subsequent share. |
