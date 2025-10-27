---
uid: mobile_gateway_benchmarks
---

# Mobile Gateway benchmarks

## Specifications of the test server

- Intel Xeon Silver 4210
- 8 cores (16TH) VM
- 32 GB RAM
- SSD (NVMe)
- Windows Server 2019 Standard

## Benchmarks

| \# | Specification | Scope | Metric | Configuration |
| -- | ------------- | ----- | ------ | ------------- |
| 1 | The time it takes until all text messages have arrived at their destination, after an alarm is generated that triggers a text message to be sent to each user of a group (10 in total). | DMS | 23.61 s | The DMA contains 1 element, 1 group with 10 users, and an alert on the group to send text messages when an alarm occurs on the element. |
| 2 | The times it takes until all "SMS Sent" information events have been generated, after an alarm is generated that triggers a text message to be sent to each user of a group (10 in total). | DMS | 8.55 s | The DMA contains 1 element, 1 group with 10 users, and an alert on the group to send text messages when an alarm occurs on the element. |
