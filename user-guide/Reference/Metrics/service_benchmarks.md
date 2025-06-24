---
uid: service_benchmarks
---

# Service benchmarks

## Specifications of the test server

If the scope in the table below refers to a DMA or DMS, then these are the specifications of each DMA:

- Intel Xeon E3-1220 v3 @ 3.10 GHz
- 10 GB RAM
- Windows Server 2012 R2
- DataMiner v10.1.12

## Benchmarks

| \# | Specification | Scope | Metric | Remarks | Configuration |
| -- | ------------- | ----- | ------ | ------- | ------------- |
| 1 | Creating a service with 1 element | DMA | 839 ms | Element contained<br>- 100 single parameters<br>- 1 table with 10 columns with 500 rows<br>- 1 table with 5 columns with 1000 rows<br>- 1 table with 20 columns with 19 rows | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 2 | Creating a service with 10 elements | DMA | 840.42 ms | Every element contained<br>- 100 single parameters<br>- 1 table with 10 columns with 500 rows<br>- 1 table with 5 columns with 1000 rows<br>- 1 table with 20 columns with 19 rows | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 3 | Creating a service with 100 elements | DMA | 985.48 ms | Every element contained<br>- 100 single parameters<br>- 1 table with 10 columns with 500 rows<br>- 1 table with 5 columns with 1000 rows<br>- 1 table with 20 columns with 19 rows | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 4 | Creating a service with 1000 elements | DMA | 1226.56 ms | Every element contained<br>- 100 single parameters<br>- 1 table with 10 columns with 500 rows<br>- 1 table with 5 columns with 1000 rows<br>- 1 table with 20 columns with 19 rows | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 5 | Deleting a service with 1 element | DMA | 811 ms | Every element contained<br>- 100 single parameters<br>- 1 table with 10 columns with 500 rows<br>- 1 table with 5 columns with 1000 rows<br>- 1 table with 20 columns with 19 rows | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 6 | Deleting a service with 10 elements | DMA | 812.21 ms | Every element contained<br>- 100 single parameters<br>- 1 table with 10 columns with 500 rows<br>- 1 table with 5 columns with 1000 rows<br>- 1 table with 20 columns with 19 rows | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 7 | Deleting a service with 100 elements | DMA | 865.27 ms | Every element contained<br>- 100 single parameters<br>- 1 table with 10 columns with 500 rows<br>- 1 table with 5 columns with 1000 rows<br>- 1 table with 20 columns with 19 rows | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 8 | Deleting a service with 1000 elements | DMA | 873.59 ms | Every element contained<br>- 100 single parameters<br>- 1 table with 10 columns with 500 rows<br>- 1 table with 5 columns with 1000 rows<br>- 1 table with 20 columns with 19 rows | DMA only contains the elements, services, DVE elements and views needed for this test. No other data on it. Also, no other tests are running. |
| 9 | Editing a service with 20 partially included elements | Cube | < 3.0 sec | Every element contained 200 table parameters.<br>Each table contained 13 columns with 2000 rows | This performance test has been created to verify and validate enhancements implemented in [DataMiner Cube 10.5.8](xref:Cube_Feature_Release_10.5.8#services-enhanced-performance-when-editing-services-id-43122), which affect the way table column parameters for partial elements are processed and handled during service editing. |
