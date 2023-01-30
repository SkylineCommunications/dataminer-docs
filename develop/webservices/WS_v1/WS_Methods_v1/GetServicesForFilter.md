---
uid: GetServicesForFilter
---

# GetServicesForFilter

Use this method to retrieve the services matching a specific property filter. Available from DataMiner 10.0.12 onwards.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| genericFilter.propertyFilters | Array of [DMAPropertyFilter](xref:DMAPropertyFilter) | The property filters. |

## Output

| Item | Format | Description |
|--|--|--|
| GetServicesForFilterResult | Array of [DMAElement](xref:DMAElement) | The services matching the property filter. |
