---
uid: DMS_DIAG
---

# DMS_DIAG (85)

> [!WARNING]
> The use of DMS Notify types is deprecated. Use types from [Class library](xref:ClassLibraryIntroduction) instead.

Obtains additional information from a DMA or a DMS.

```csharp
int type = 85;
int subType = 0;

string command = "DMSCONFIG";
object result = new object();

DMS dms = new DMS();
dms.Notify(type /*DMS_DIAG*/ , subType, command, null, out result);
```

## Parameters:

- type (int): Specifies the notify type. To perform a DMS_DIAG call, set this to 85.
- subType (int): Specifies the sub type. Not applicable for DMS_DIAG calls. Set this to 0.
- command (string):
- result (object): The resulting object will be a string array where each entry contains a string formatted as follows (Item denoted between brackets indicate fields):
  
  ```bash
     Quick DMA Info: [n] entries
    
     [IP address] => id [DMAID] ([DMANAME]) [LOADED]
        [x] notifications
        [y] elements
        [z] services
        [n] redundancy groups
    
    [a] notifications, [b] stored notifications
    [c] other obj notifications
    Addresses to check: [IP address]
    Addresses to remove:
    
    
    [d] clusters
   ```
