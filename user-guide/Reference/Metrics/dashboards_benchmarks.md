---
uid: dashboards_benchmarks
---

# Dashboards benchmarks

## Specifications of the test server

- Intel Core i7-9700 CPU \@3.20 GHz
- 8 cores
- 32 GB RAM
- SSD
- Cassandra
- Windows 10 Enterprise

## Benchmarks

| \# | Specification | Scope | Metric | Remarks | Configuration |
| -- | ------------- | ----- | ------ | ------- | ------------- |
| 1 | Pivot table component: Number of indices | DMA | 7,500 |||
| 2 | Fetch and process alarms in the Alarm table component | DMA | 1 s | Time to initialize the component, fetch 100 alarms from the API and process them so the component is ready to use. | Dashboards web app with 1 alarm table component, filtered on an element with 10,000+ active alarms.<br>Alarm table setting \"Initial number of alarms to load\" set to 100. |
| 3 | Fetch and process alarms in the Alarm table component | DMA | 1.5 s | Time to initialize the component, fetch 500 alarms from the API and process them so the component is ready to use. | Dashboards web app with 1 alarm table component, filtered on an element with 10,000+ active alarms.<br>Alarm table setting \"Initial number of alarms to load\" set to 500. |
| 4 | Fetch and process alarms in the Alarm table component | DMA | 2 s | Time to initialize the component, fetch 1,000 alarms from the API and process them so the component is ready to use. | Dashboards web app with 1 alarm table component, filtered on an element with 10,000+ active alarms.<br>Alarm table setting \"Initial number of alarms to load\" set to 1,000. |
| 5 | Fetch and process alarms in the Alarm table component | DMA | 3 s | Time to initialize the component, fetch 2,000 alarms from the API and process them so the component is ready to use. | Dashboards web app with 1 alarm table component, filtered on an element with 10,000+ active alarms.<br>Alarm table setting \"Initial number of alarms to load\" set to 2,000. |
| 6 | Fetch and process alarms in the Alarm table component | DMA | 12 s | Time to initialize the component, fetch 5,000 alarms from the API and process them so the component is ready to use. | Dashboards web app with 1 alarm table component, filtered on an element with 10,000+ active alarms.<br>Alarm table setting \"Initial number of alarms to load\" set to 5,000. |
| 7 | Fetch and process alarms in the Alarm table component | DMA | 25 s | Time to initialize the component, fetch 10,000 alarms from the API and process them so the component is ready to use. | Dashboards web app with 1 alarm table component, filtered on an element with 10,000+ active alarms.<br>Alarm table setting \"Initial number of alarms to load\" set to 10,000. |
