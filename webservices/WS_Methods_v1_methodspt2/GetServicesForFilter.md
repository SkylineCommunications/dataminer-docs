---
uid: GetServicesForFilter
---

# GetServicesForFilter

Use this method to retrieve the services matching a specific property filter. Available from DataMiner 10.0.12 onwards.

## Input

| Item                              | Format                     | Description                                                                                  |
|-----------------------------------|----------------------------|----------------------------------------------------------------------------------------------|
| Connection                        | String                     | The connection ID. See [ConnectApp](xref:ConnectApp) .             |
| GenericFilter.<br>PropertyFilters | Array of DMAPropertyFilter | The property filters. See [DMAPropertyFilter](xref:DMAPropertyFilter) |

## Output

| Item                        | Format                                                                         | Description                                |
|-----------------------------|--------------------------------------------------------------------------------|--------------------------------------------|
| GetServicesForFilter­Result | Array of DMAElement (see [DMAElement](xref:DMAElement)) | The services matching the property filter. |

