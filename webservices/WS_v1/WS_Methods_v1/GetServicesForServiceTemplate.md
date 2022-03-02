---
uid: GetServicesForServiceTemplate
---

# GetServicesForServiceTemplate

Use this method to retrieve all the services attached to a specified service template.

## Input

| Item              | Format  | Description                                                                      |
|-------------------|---------|----------------------------------------------------------------------------------|
| Connection        | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID             | Integer | The DataMiner Agent ID.                                                          |
| ServiceTemplateID | Integer | The ID of the service template.                                                  |

## Output

| Item                                 | Format                                                                         | Description                                              |
|--------------------------------------|--------------------------------------------------------------------------------|----------------------------------------------------------|
| GetServicesForService­TemplateResult | Array of DMAElement (see [DMAElement](xref:DMAElement)) | The services attached to the specified service template. |

