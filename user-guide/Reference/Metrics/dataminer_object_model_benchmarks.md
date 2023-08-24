---
uid: dataminer_object_model_benchmarks
---

# DataMiner Object Model benchmarks

## Specifications of the test server

- Intel Core i7-8700 CPU \@3.20 GHz - 6 cores
- 32GB RAM
- SSD
- Windows 10 Pro
- Cassandra & Elasticsearch

## Benchmarks

| \# | Specification | Scope | Metric | Remarks | Configuration |
| -- | ------------- | ----- | ------ | ------- | ------------- |
| 1 | Create DomManager + Init DomInstance storage | DMS | 3,098 ms || Clean DMA, no other data |
| 2	| Init DomDefinition storage | DMS | 4,334 ms || Clean DMA, no other data |
| 3 | Init DomTemplate storage | DMS | 2,432 ms || Clean DMA, no other data |
| 4	| Init SectionDefinition storage | DMS | 2,373 ms || Clean DMA, no other data |
| 5 | Creation time of 1000 DOM instances	| DMS |	144,593 ms | Each DomInstance has an id and 50 fields (10 sections x 5 fields) and each field contains a string of 256 characters |	Clean DMA, no other data |
| 6 | Creation time of 1000 DOM Definitions |	DMS | 81,500 ms | Each DomDefinition has an id, name and 10 sectiondefinitionlinks | ±1000 DomInstances present |
| 7 |	Creation Time of 1000 DOM Templates |	DMS | 75,185 ms | Each DomTemplate has an id, name and DomInstance (id + 50 fields each containing a string of 256 characters) | ±1000 DomInstances and DomDefinitions present |
| 8 |	Creation Time of 1000 SectionDefinitions | DMS | 66,286 ms | Each SectionDefinition had an id, name and 5 fields | ±1000 DomInstances, DomDefinitions and DomTemplates present |
| 9 | Updating 1000 DomInstances | DMS | 152,020 ms	| Each DomInstance has an id and 50 fields (10 sections x 5 fields) and each field contains a string of 256 characters | ±1000 DomInstances, DomDefinitions, DomTemplates and SectionDefinitions present |
| 10 | Updating 1000 DomDefinitions |	DMS | 65,434 ms | Each DomDefinition has an id, name and 10 sectiondefinitionlinks | ±1000 DomInstances, DomDefinitions, DomTemplates and SectionDefinitions present |
| 11 | Updating 1000 DomTemplates |	DMS | 91,372 ms	| Each DomTemplate has an id, name and DomInstance (id + 50 fields each containing a string of 256 characters) | ±1000 DomInstances, DomDefinitions, DomTemplates and SectionDefinitions present |
| 12 | Updating 1000 Sectiondefinitions |	DMS | 82,720 ms	| Each SectionDefinition had an id, name and 5 fields |	±1000 DomInstances, DomDefinitions, DomTemplates and SectionDefinitions present |
| 13 | Reading 1000 DomInstances | DMS | 4,141 ms | Each DomInstance has an id and 50 fields (10 sections x 5 fields) and each field contains a string of 256 characters | ±1000 DomInstances, DomDefinitions, DomTemplates and SectionDefinitions present |
| 14 | Reading 1000 DomDefinitions | DMS | 523 ms | Each DomDefinition has an id, name and 10 sectiondefinitionlinks | ±1000 DomInstances, DomDefinitions, DomTemplates and SectionDefinitions present |
| 15 | Reading 1000 DomTemplates | DMS | 3,978 ms |	Each DomTemplate has an id, name and DomInstance (id + 50 fields each containing a string of 256 characters) | ±1000 DomInstances, DomDefinitions, DomTemplates and SectionDefinitions present |
| 16 | Reading 1000 Sectiondefinitions | DMS | 550 ms |	Each SectionDefinition had an id, name and 5 fields |	±1000 DomInstances, DomDefinitions, DomTemplates and SectionDefinitions present |
| 17 | Reading 1000 DomInstances paged | DMS | 5,083 ms | Each DomInstance has an id and 50 fields (10 sections x 5 fields) and each field contains a string of 256 characters | ±1000 DomInstances, DomDefinitions, DomTemplates and SectionDefinitions present |
| 18 | Reading 1000 DomDefinitions paged | DMS | 644 ms | Each DomDefinition has an id, name and 10 sectiondefinitionlinks | ±1000 DomInstances, DomDefinitions, DomTemplates and SectionDefinitions present |
| 19 | Reading 1000 DomTemplates paged | DMS | 5,342 ms |	Each DomTemplate has an id, name and DomInstance (id + 50 fields each containing a string of 256 characters) | ±1000 DomInstances, DomDefinitions, DomTemplates and SectionDefinitions present |
| 20 | Reading 1000 Sectiondefinitions paged | DMS | 580 ms |	Each SectionDefinition had an id, name and 5 fields |	±1000 DomInstances, DomDefinitions, DomTemplates and SectionDefinitions present |
| 21 | Delete 1000 DomInstances |	DMS |	148,209 ms | Each DomInstance has an id and 50 fields (10 sections x 5 fields) and each field contains a string of 256 characters |	±1000 DomInstances, DomDefinitions, DomTemplates and SectionDefinitions present |
| 22 | Delete 1000 DomDefinitions |	DMS | 54,955 ms | Each DomDefinition has an id, name and 10 sectiondefinitionlinks | ±1000 DomDefinitions, DomTemplates and SectionDefinitions present |
| 23 | Delete 1000 DomTemplates | DMS | 42,336 ms	| Each DomTemplate has an id, name and DomInstance (id + 50 fields each containing a string of 256 characters) | ±1000 DomTemplates and SectionDefinitions present |
| 24 | Delete 1000 SectionDefinitions | DMS | 68,367 ms | Each SectionDefinition had an id, name and 5 fields |	±1000 SectionDefinitions present |

## Load Test

### Specifications

- Intel i7-12700 (12 core / 20 threads)
- 32GB DDR5 RAM (4800 MT/s)
- SSD (NVMe) (850K Write IOPS)
- Windows 11 Pro (10.0.22621 Build 22621)
- Elasticsearch version 6.8.23 (8GB allocated memory)
- DataMiner version 10.3.9

### Summary

A load test was performed using DOM models representing 'transport stream' data. DOM definitions representing 'service', 'PID', and 'transport stream' were created, each containing around 20 fields. Using realistic data, 5,000,000 DOM instances were sequentially created, with a fairly constant average creation time of approximately 90 ms. The Elasticsearch index size reached about 45GB. Query performance using a GQI query in a low-code app remained consistently smooth compared to a system with significantly less DOM instances.
