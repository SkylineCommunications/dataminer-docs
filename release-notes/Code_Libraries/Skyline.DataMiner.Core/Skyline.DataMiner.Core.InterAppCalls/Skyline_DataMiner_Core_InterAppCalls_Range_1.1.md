---
uid: Skyline_DataMiner_Core_InterAppCalls_Range_1.1
---

# Skyline DataMiner Core InterAppCalls Range 1.1

> [!NOTE]
> Range 1.1.x.x is supported as from **DataMiner 10.4.0**.

### 1.1.0.1

#### Refactor - InterApp performance improvement [ID 43493]

Performance of InterApp calls has been enhanced by using the GetElementReference method instead of GetElement (IDms). This results in reduced SLNet calls, improving the performance of InterApp calls.
