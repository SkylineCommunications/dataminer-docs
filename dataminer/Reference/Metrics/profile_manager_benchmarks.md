---
uid: profile_manager_benchmarks
---

# Profile manager benchmarks

## Specifications of the test server

- Intel Xeon Silver 4210
- 8 cores (16TH) VM
- 32 GB RAM
- SSD (NVMe)
- Windows Server 2019 Standard

## Benchmarks

| \# | Specification | Scope | Metric | Remarks | Configuration |
| -- | ------------- | ----- | ------ | ------- | ------------- |
| 1 | Bulk create 500 parameters | DMS | 3.230 ms | - Test with predefined XML<br>- Parameters, wide range of different configuration<br>- Definitions with 1-15 parameters, 0-1 scripts, Instances with 1-10 parameter values | Clean DMA, no other data |
| 2 | Bulk create 500 definitions | DMS | 3.165 ms | - Test with predefined XML<br>- Parameters, wide range of different configuration<br>- Definitions with 1-15 parameters, 0-1 scripts, Instances with 1-10 parameter values | Clean DMA, no other data |
| 3 | Bulk create 500 instances | DMS | 3.168 ms | - Test with predefined XML<br>- Parameters, wide range of different configuration<br>- Definitions with 1-15 parameters, 0-1 scripts, Instances with 1-10 parameter values | Clean DMA, no other data |
| 4 | Create 478 parameters  | DMS | 7.944 ms | - Test with predefined XML<br>- Parameters, wide range of different configuration<br>- Definitions with 1-15 parameters, 0-1 scripts, Instances with 1-10 parameter values | Clean DMA, no other data |
| 5 | Create 98 definitions | DMS | 1.851 ms | - Test with predefined XML<br>- Parameters, wide range of different configuration<br>- Definitions with 1-15 parameters, 0-1 scripts, Instances with 1-10 parameter values | Clean DMA, no other data |
| 6 | Create 228 instances | DMS | 6.645 ms | - Test with predefined XML<br>- Parameters, wide range of different configuration<br>- Definitions with 1-15 parameters, 0-1 scripts, Instances with 1-10 parameter values | Clean DMA, no other data |
| 7 | Calling GenerateRequiredCapas on profileInstance - Full CustomCache | DMS | 26.48 ms || * 200 profile instances<br>- Name<br>- 200 parameter values<br>- 1 parent<br>Resulting in a tree of 200 instances<br>* 200 parameters<br>- Name<br>- Type: Number<br>- Decimals: 3<br>- Categories: Capability/Capacity (50/50)<br>- DefaultCapabilityUsageValue: 2.5<br>- DefaultCapacityUsageValue: 3.5m |
| 8 | Calling GenerateRequiredCapas on profileInstance - Empty CustomCache | DMS | 2,125.88 ms || * 200 profile instances<br>- Name<br>- 200 parameter values<br>- 1 parent<br>Resulting in a tree of 200 instances<br>* 200 parameters<br>- Name<br>- Type: Number<br>- Decimals: 3<br>- Categories: Capability/Capacity (50/50)<br>- DefaultCapabilityUsageValue: 2.5<br>- DefaultCapacityUsageValue: 3.5m |
| 9 | Calling GenerateRequiredCapas on profileInstance - Without CustomCache | DMS | 2,117.73 ms |  | * 200 profile instances<br>- Name<br>- 200 parameter values<br>- 1 parent<br>Resulting in a tree of 200 instances<br>* 200 parameters<br>- Name<br>- Type: Number<br>- Decimals: 3<br>- Categories: Capability/Capacity (50/50)<br>- DefaultCapabilityUsageValue: 2.5<br>- DefaultCapacityUsageValue: 3.5m |
