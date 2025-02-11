---
uid: DMS_GET_ELEMENT_ID_FROM_IP
---

# DMS_GET_ELEMENT_ID_FROM_IP (76)

> [!WARNING]
> The use of DMS Notify types has been deprecated. Use types from the [Class Library](xref:ClassLibraryIntroduction) instead.

Gets the global element ID of (the) element(s) configured with the provided IP and bus address.

```csharp
string ip = "127.0.0.2";
string bus = "20.0F";
int type = 76;
int subType = 0;

string[] ipBus = new string[] { ip, bus };
object result = new object();

DMS dms = new DMS();
dms.Notify(type/*DMS_GET_ELEMENT_ID_FROM_IP*/ , subType, ipBus, null, out result);

string globalElementID = (string)result;
```

## Parameters

- type (int): Specifies the notify type. To perform a DMS_GET_ELEMENT_ID_FROM_IP call, set this to 76.
- subType (int): Specifies the sub type. Not applicable for DMS_GET_ELEMENT_ID_FROM_IP calls. Set this to 0.
- ipBus (string[]):

  - ip: IP address
  - bus: bus address

- result (object): global element ID(s) (DMA ID/element ID) as string.

## Remarks

- To get all the elements using a specific IP but ignore the bus address, provide a null reference for the bus variable.
- In case the result contains more than one global element ID, these will be separated by a semicolon (`;`).
- In case no element was found on the DMS with the provided settings, an empty string will be returned.
