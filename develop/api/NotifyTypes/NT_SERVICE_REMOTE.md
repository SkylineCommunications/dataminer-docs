---
uid: NT_SERVICE_REMOTE
---

# NT_SERVICE_REMOTE (282)

Creates or updates a service on a remote DMA.

- Option 1: Create or update a service with the **full service ID**. This option is **preferred**, especially when services have been migrated or swarmed within the cluster or when they have been imported from an external system via a .dmimport package (DELT).

  ```csharp
  int dmaID = 346;
  int serviceID = -1;
  int targetDmaID = 123;

  string serviceXml = "<Service version=\"2\" dmaid=\""+dmaID+"\" id=\""+serviceID+"\" name=\"test remote service\" description=\"\" vdxfile=\"\" ignoreTimeouts=\"false\" isTemplate=\"false\" generatedFromTemplate=\"\" type=\"\" timestamp=\"635723913806993291\"><Element idx=\"0\" dmaid=\"1\" eid=\"21\" alias=\"\" group=\"-1\" notUsedCapped=\"\" includedCapped=\"\" service=\"false\" serviceElement=\"False\" includeTrigger=\"\" excludeTrigger=\"\" notUsedTrigger=\"\" state=\"\" description=\"\" templateOptions=\"\"></Element><Element idx=\"1\" dmaid=\"2\" eid=\"3\" alias=\"\" group=\"-1\" notUsedCapped=\"\" includedCapped=\"\" service=\"false\" serviceElement=\"False\" includeTrigger=\"\" excludeTrigger=\"\" notUsedTrigger=\"\" state=\"\" description=\"\" templateOptions=\"\"></Element><Triggers></Triggers></Service>";

  object result = protocol.NotifyDataMiner(282 /*NT_SERVICE_REMOTE*/ , new object[] { targetDmaID, new uint[] { serviceID, dmaID} }, serviceXml);

  if (result != null)
  {
      uint[] resultDetails = (uint[])result;
      uint createdServiceID = resultDetails[0];

       ////...
  }
  ```

- Option 2: Create or update a service with only the **local service ID**.

  > [!CAUTION]
  > This method will not work to update services when the hosting DataMiner ID of the service is different from the DataMiner ID of the service.

  ```csharp
  int dmaID = 346;
  int serviceID = -1;
  int targetDmaID = 123;

  string serviceXml = "<Service version=\"2\" dmaid=\""+dmaID+"\" id=\""+serviceID+"\" name=\"test remote service\" description=\"\" vdxfile=\"\" ignoreTimeouts=\"false\" isTemplate=\"false\" generatedFromTemplate=\"\" type=\"\" timestamp=\"635723913806993291\"><Element idx=\"0\" dmaid=\"1\" eid=\"21\" alias=\"\" group=\"-1\" notUsedCapped=\"\" includedCapped=\"\" service=\"false\" serviceElement=\"False\" includeTrigger=\"\" excludeTrigger=\"\" notUsedTrigger=\"\" state=\"\" description=\"\" templateOptions=\"\"></Element><Element idx=\"1\" dmaid=\"2\" eid=\"3\" alias=\"\" group=\"-1\" notUsedCapped=\"\" includedCapped=\"\" service=\"false\" serviceElement=\"False\" includeTrigger=\"\" excludeTrigger=\"\" notUsedTrigger=\"\" state=\"\" description=\"\" templateOptions=\"\"></Element><Triggers></Triggers></Service>";

  object result = protocol.NotifyDataMiner(282 /*NT_SERVICE_REMOTE*/ , new object[] { targetDmaID, new uint[] { serviceID, dmaID} }, serviceXml);

  if (result != null)
  {
      uint[] resultDetails = (uint[])result;
      uint createdServiceID = resultDetails[0];

       ////...
  }
  ```

## Parameters

- Option 1:

  - serviceTarget (object[]): An array containing the target DMA and the targeted service ID.

    - serviceTarget[0] (int): The target DataMiner ID that should execute the request.
    - serviceTarget[1] (uint[]): An array containing the full service ID. See also [NT_SERVICE](xref:NT_SERVICE) option 1.

      - serviceID[0] (uint): The ID of the service to update. Set -1 in case a new service needs to be created.
      - serviceID[1] (uint): The local DataMiner ID in case of a new service, or the DataMiner ID configured in the *Service.xml* file for a migrated service.

  - serviceXml (string): The XML describing the service.

- Option 2:

  - serviceTarget (object[]): An array containing the target DMA and the targeted service ID.

    - serviceTarget[0] (int): The target DataMiner ID that should execute the request.
    - serviceTarget[1] (int): The ID of the service to update. Set -1 in case a new service needs to be created. See also [NT_SERVICE](xref:NT_SERVICE) option 2.

  - serviceXml (string): The XML describing the service.

## Return Value

- (uint[]): The first element of the array contains the ID of the service.<!-- RN 10304 --> This ID can be combined with the provided *dmaID* when using option 1 or the local DataMiner ID when using option 2 to represent the **full Service ID** which is a unique ID across the DMS.
