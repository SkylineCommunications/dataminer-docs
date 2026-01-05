---
uid: GetAnnotationsLinkForService
---

# GetAnnotationsLinkForService

**Obsolete**. This method is no longer available as of DataMiner 10.6.0/10.6.1.<!-- RN 44136 -->

Use this method to retrieve a link to open the annotations page of the specified service.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                              |
| serviceID  | Integer | The service ID.                                      |

## Output

| Item                               | Format | Description                                      |
|------------------------------------|--------|--------------------------------------------------|
| GetAnnotationsLinkForServiceResult | String | The link to the annotations page of the service. |
