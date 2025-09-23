---
uid: gqi_benchmarks
---

# GQI benchmarks

## Specifications of the test server

- Intel Core i7-6770HQ CPU @ 2.60GHz
- 4 cores
- 32 GB RAM
- SSD
- Cassandra
- Windows 10 Pro

## Benchmarks

| \# | Specification | Scope | Metric | Remarks | Configuration |
| -- | ------------- | ----- | ------ | ------- | ------------- |
| 1 | Execute initial extension query | GQI DxM + Web API | 2s | Time to execute the first query using a specific GQI extension. Includes the startup and initialization of the extension worker process. This metric also applies to the first query after a new version of the extension was installed or when the extension worker was [stopped because it was idle](xref:GQI_DxM#termination-of-idle-child-processes). | On a system with a single GQI extension library, fetch the first page of a query using a minimal ad hoc data source with a single column that returns a single row from memory. |
