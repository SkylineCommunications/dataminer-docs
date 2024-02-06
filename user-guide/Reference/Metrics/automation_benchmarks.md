---
uid: automation_benchmarks
---

# Automation benchmarks

## Specifications of the test server

- Intel Xeon Silver 4210
- 8 cores (16TH) VM
- 32 GB RAM
- SSD (NVMe)
- Windows Server 2019 Standard

## Benchmarks

| \# | Specification | Scope | Metric | Remarks | Configuration |
| -- | ------------- | ----- | ------ | ------- | ------------- |
| 1 | Save normal script | DMS | 14 ms | Script with one C# code block (not a library), only containing an engine.GenerateInformation call. |Clean DMA, no other data. |
| 2 | Save script with library | DMS | 62 ms | Script with one C# code block (marked as library), containing one class with one method. | Clean DMA, no other data. |
| 3 | Save script with library 1x recompile | DMS | 90 ms | - Script with one C# code block (marked as library), containing one class with one method.<br>- Script with one C# code block (marked as library), containing one class with one method using the first library. | Clean DMA, no other data. |
| 4 | Save script with library 2x recompile | DMS | 164 ms | - Script with one C# code block (marked as library), containing one class with one method.<br>- Script with one C# code block (marked as library), containing one class with one method using the first library.<br>- Script with one C# code block (not a library), only containing an engine.GenerateInformation call and using the previous library. | Clean DMA, no other data. |
| 5 | Save script with library 50x recompile | DMS | 2,126 ms | - Script with one C# code block (marked as library), containing one class with one method.<br>- Script with one C# code block (marked as library), containing one class with one method using the first library.<br>- 50 scripts, each with one C# code block (not a library), only containing an engine.GenerateInformation call and using the previous library. | Clean DMA, no other data. |
