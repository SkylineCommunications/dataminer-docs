---
uid: NT_SERVICE_REMOTE
---

# NT_SERVICE_REMOTE (282)

Creates or updates a service on a remote DMA.

```csharp
int dmaID = 346;
int serviceID = -1;

string serviceXml = "<Service version=\"2\" dmaid=\""+dmaID+"\" id=\""+serviceID+"\" name=\"test remote service\" description=\"\" vdxfile=\"\" ignoreTimeouts=\"false\" isTemplate=\"false\" generatedFromTemplate=\"\" type=\"\" timestamp=\"635723913806993291\"><Element idx=\"0\" dmaid=\"1\" eid=\"21\" alias=\"\" group=\"-1\" notUsedCapped=\"\" includedCapped=\"\" service=\"false\" serviceElement=\"False\" includeTrigger=\"\" excludeTrigger=\"\" notUsedTrigger=\"\" state=\"\" description=\"\" templateOptions=\"\"></Element><Element idx=\"1\" dmaid=\"2\" eid=\"3\" alias=\"\" group=\"-1\" notUsedCapped=\"\" includedCapped=\"\" service=\"false\" serviceElement=\"False\" includeTrigger=\"\" excludeTrigger=\"\" notUsedTrigger=\"\" state=\"\" description=\"\" templateOptions=\"\"></Element><Triggers></Triggers></Service>";

object result = protocol.NotifyDataMiner(75 /*NT_SERVICE*/ , serviceID, serviceXml);

if (result != null)
{
    uint[] resultDetails = (uint[])result;
    uint createdServiceID = resultDetails[0];

     ////...
}
```

## Parameters

- serviceID (int): ID of the service to update. Set -1 in case a new service needs to be created.
- serviceXml (string): The XML describing the service.

## Return Value

- (uint[]): The first element of the array contains the ID of the service.<!-- RN 10304 -->
