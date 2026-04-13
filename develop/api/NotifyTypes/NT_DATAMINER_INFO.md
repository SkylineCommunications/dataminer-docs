---
uid: NT_DATAMINER_INFO
---

# NT_DATAMINER_INFO (107)

Gets DataMiner information.

```csharp
int dmaID = (int) protocol.NotifyDataMiner(107 /*NT_DATAMINER_INFO*/ , 31 /*DI_ID*/ , null);
string dmaName = (string)protocol.NotifyDataMiner(107 /*NT_DATAMINER_INFO*/ , 9 /*DI_ID*/ , null);

object[] result = (object[]) protocol.NotifyDataMiner(107 /*NT_DATAMINER_INFO*/ , 26 /*DI_GENERAL_INFORMATION */ , null);
```

## Parameters

- infoID (int): ID specifying what information should be returned.
  - 7: DI_IP_ADAPTERS: DMA IP
  - 9: Retrieves the DataMiner Agent name.
  - 26: DI_GENERAL_INFORMATION: Retrieves general information.
  - 31: Gets the DataMiner Agent ID of the local host.

## Return Value

Depends on the value of the infoID parameter:

### Return value for infoID 7

- result (string[]): 3 string values per adapter (i=0…n-1, where n=number of adapters):
  - result[i*3]: Description/name of first network interface.
  - result[i*3+1]: Main IP address for first network interface.
  - result[i*3+2]: Mask (or empty) for the IP address above.

### Return value for infoID 9

- dmaName (string): DataMiner Agent name.

### Return value for infoID 26

- result (object[]):
  - result[0] (int): DataMiner Agent ID.
  - result[1] (string): DataMiner Agent name.
  - result[2] (DateTime): Boot time (date value indicating the DataMiner startup time)
  - result[3] (string[]): Serial ports
  - result[4] (string[]): Information about network adapter 0…n.
    - string[3*n]: Name
    - string[3*n+1]: IP Address
    - string[3*n+2]: Subnet mask
  - result[5] (string[]): MAC addresses 0…n. Each entry is a MAC address in format AA-BB-CC-DD-EE-FF.
  - result[6] (string): Current IP address (string)
    - For a normal Agent or a Failover Agent that is offline: primary IP address of first NIC.
    - For a Failover Agent that is online: virtual IP address (first NIC).
  - result[7] (int[]): Version info (e.g., representing 10.2.5.6-1234)
    - 0 = Major (e.g., 10)
    - 1 = Minor  (e.g., 2)
    - 2 = Sub 1 (e.g., 5)
    - 3 = Sub 2 (e.g., 6)
    - 4 = Build number (if available)

### Return value for infoID 31

- dmaID (int): DataMiner Agent ID of the local host.
