---
uid: NT_SERVICE_SET_VDX
---

# NT_SERVICE_SET_VDX (232)

Sets a Visio file on a service.

```csharp
string serviceId = "400/200";
string serviceVdx = "Visio|1";

protocol.NotifyDataMiner(232 /*NT_SERVICE_SET_VDX*/ , serviceID, serviceVdx);
```

## Parameters

- serviceId (string): ID of the service, formatted as follows: "[DMA ID]/[Service ID]" (e.g., "400/200").
- serviceVdx (string): format: VDX name|pageNumber.

  > [!NOTE]
  > To set a .vsdx file, include the extension. For example, “Visio.vsdx|1”.

## Return Value

- uint[]: Array containing the ID(s) of the services.
