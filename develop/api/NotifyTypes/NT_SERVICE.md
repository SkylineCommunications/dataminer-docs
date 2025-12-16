---
uid: NT_SERVICE
---

# NT_SERVICE (75)

Creates or updates a service on a local DMA.

- Option 1: Create or update a service with the **full service ID**. This option is **preferred**, especially when services have been migrated or swarmed within the cluster or when they have been imported from an external system via a .dmimport package (DELT).

  ```csharp
  int serviceID = -1;
  // The DataMiner ID of the local Agent for a new service or the DataMiner ID configured in the service.xml file for a migrated service.
  uint dataminerID = 1;

  string serviceXml = "<Service version=\"2\" id=\"-1\" name=\"test remote service\" description=\"\" vdxfile=\"\" ignoreTimeouts=\"false\" isTemplate=\"false\" generatedFromTemplate=\"\" type=\"\" timestamp=\"635723913806993291\"><Element idx=\"0\" dmaid=\"1\" eid=\"21\" alias=\"\" group=\"-1\" notUsedCapped=\"\" includedCapped=\"\" service=\"false\" serviceElement=\"False\" includeTrigger=\"\" excludeTrigger=\"\" notUsedTrigger=\"\" state=\"\" description=\"\" templateOptions=\"\"></Element><Element idx=\"1\" dmaid=\"2\" eid=\"3\" alias=\"\" group=\"-1\" notUsedCapped=\"\" includedCapped=\"\" service=\"false\" serviceElement=\"False\" includeTrigger=\"\" excludeTrigger=\"\" notUsedTrigger=\"\" state=\"\" description=\"\" templateOptions=\"\"></Element><Triggers></Triggers></Service>";

  object result = protocol.NotifyDataMiner(75 /*NT_SERVICE*/ , new uint[] { (uint)serviceID, dataminerID }, serviceXml);

  if (result != null)
  {
      uint[] resultDetails = (uint[]) result;
      uint createdServiceID = resultDetails[0];

      ////...
  }
  ```

- Option 2: Create or update a service with only the **local service ID**.

  > [!CAUTION]
  > This method will not work when the hosting DataMiner ID of the service is different from the DataMiner ID of the service.

  ```csharp
  int serviceID = -1;

  string serviceXml = "<Service version=\"2\" id=\"-1\" name=\"test remote service\" description=\"\" vdxfile=\"\" ignoreTimeouts=\"false\" isTemplate=\"false\" generatedFromTemplate=\"\" type=\"\" timestamp=\"635723913806993291\"><Element idx=\"0\" dmaid=\"1\" eid=\"21\" alias=\"\" group=\"-1\" notUsedCapped=\"\" includedCapped=\"\" service=\"false\" serviceElement=\"False\" includeTrigger=\"\" excludeTrigger=\"\" notUsedTrigger=\"\" state=\"\" description=\"\" templateOptions=\"\"></Element><Element idx=\"1\" dmaid=\"2\" eid=\"3\" alias=\"\" group=\"-1\" notUsedCapped=\"\" includedCapped=\"\" service=\"false\" serviceElement=\"False\" includeTrigger=\"\" excludeTrigger=\"\" notUsedTrigger=\"\" state=\"\" description=\"\" templateOptions=\"\"></Element><Triggers></Triggers></Service>";

  object result = protocol.NotifyDataMiner(75 /*NT_SERVICE*/ , serviceID, serviceXml);

  if (result != null)
  {
      uint[] resultDetails = (uint[]) result;
      uint createdServiceID = resultDetails[0];

      ////...
  }
  ```

## Parameters

- Option 1:

  - serviceID (uint[]): Array containing the unique identifier of the service.

    - serviceID[0] (uint): The ID of the service to update. Set -1 in case a new service needs to be created.
    - serviceID[1] (uint): The local DataMiner ID in case of a new service, or the DataMiner ID configured in the *Service.xml* file for a migrated service.

  - serviceXml (string): The XML describing the service.

- Option 2:

  - serviceID (int): The ID of the service to update. Set -1 in case a new service needs to be created.
  - serviceXml (string): The XML describing the service.

## Return Value

- (uint[]): The first element of the array contains the service ID.

## Remarks

- This method call is only intended for the creation of a service on the local DMA. In case a service must be created on a remote DMA, the [NT_SERVICE_REMOTE (282)](xref:NT_SERVICE_REMOTE) call should be used.
