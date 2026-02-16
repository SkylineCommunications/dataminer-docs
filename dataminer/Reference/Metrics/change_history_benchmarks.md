---
uid: change_history_benchmarks
---

# Change history metrics

## Specifications of the test server

- Intel Xeon Silver 4210
- 8 cores (16TH) VM
- 32 GB RAM
- SSD (NVMe)
- Windows Server 2019 Standard

## Benchmarks

| \# | Specification | Scope | Metric | Remarks | Configuration |
| -- | ------------- | ----- | ------ | ------- | ------------- |
| 1 | Filter based on HistoryChange.Time | DMS | 25.82 ms | The metric indicates the average hit time, i.e., "total time to filter" divided by "the number of items returned". | 100 bookings, 5000 basic resources, 15 resources per booking, 3000 history changes in total.<br>Each booking is created with:<br>- 15 resources (ID, Name, MaxConcurrency 1000, Capacity 1000, Capability 5).<br>- A script event "Script: RandomWord + \|\|reservationid=%reservationinstanceid%".<br>- 40 properties with random word. |
| 2 | Filter based on HistoryChange.ID | DMS | 22.63 ms | The metric indicates the average hit time, i.e., "total time to filter" divided by "the number of items returned". | 100 bookings, 5000 resources, 15 resources per booking, 3000 history changes in total.<br>Each booking is created with:<br>- 15 resources (ID, Name, MaxConcurrency 1000, Capacity 1000, Capability 5).<br>- A script event "Script: RandomWord + \|\|reservationid=%reservationinstanceid%".<br>- 40 properties with random word. |
| 3 | Filter based on HistoryChange.DmaId | DMS | 23.07 ms | The metric indicates the average hit time, i.e., "total time to filter" divided by "the number of items returned". | 100 bookings, 5000 resources, 15 resources per booking, 3000 history changes in total.<br>Each booking is created with:<br>- 15 resources (ID, Name, MaxConcurrency 1000, Capacity 1000, Capability 5).<br>- A script event "Script: RandomWord + \|\|reservationid=%reservationinstanceid%".<br>- 40 properties with random word. |
| 4 | Filter based on HistoryChange.FullUsername | DMS | 21.68 ms | The metric indicates the average hit time, i.e., "total time to filter" divided by "the number of items returned". | 100 bookings, 5000 resources, 15 resources per booking, 3000 history changes in total.<br>Each booking is created with:<br>- 15 resources (ID, Name, MaxConcurrency 1000, Capacity 1000, Capability 5).<br>- A script event "Script: RandomWord + \|\|reservationid=%reservationinstanceid%".<br>- 40 properties with random word. |
| 5 | Filter based on HistoryChange.SubjectId | DMS | 13.31 ms | Each booking is created with<br>- 15 resources (ID, Name, MaxConcurrency 1000, Capacity 1000, Capability 5).<br>- A script event "Script: RandomWord + \|\|reservationid=%reservationinstanceid%".<br>- 40 properties with random word. | 100 bookings, 5000 resources, 15 resources per booking, 3000 history changes in total.<br>Each booking is created with:<br>- 15 resources (ID, Name, MaxConcurrency 1000, Capacity 1000, Capability 5).<br>- A script event "Script: RandomWord + \|\|reservationid=%reservationinstanceid%".<br>- 40 properties with random word. |
| 6 | Filter based on HistoryChange.RelatedSubjectIDs | DMS | 14.74 ms | The metric indicates the average hit time, i.e., "total time to filter" divided by "the number of items returned". | 100 bookings, 5000 resources, 15 resources per booking, 3000 history changes in total.<br>Each booking is created with:<br>- 15 resources (ID, Name, MaxConcurrency 1000, Capacity 1000, Capability 5).<br>- A script event "Script: RandomWord + \|\|reservationid=%reservationinstanceid%".<br>- 40 properties with random word. |
