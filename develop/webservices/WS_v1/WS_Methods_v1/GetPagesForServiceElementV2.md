---
uid: GetPagesForServiceElementV2
---

# GetPagesForServiceElementV2

Use this method to retrieve the Data Display pages of a specified element that is included in a specified service, as well as the alarm cache status.

Available from DataMiner 10.0.7 onwards.

## Input

| Item         | Format  | Description                                                                      |
|--------------|---------|----------------------------------------------------------------------------------|
| connection   | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| serviceDmaID | Integer | The DataMiner Agent ID that is linked to the service.                            |
| serviceID    | Integer | The service ID.                                                                  |
| elementDmaID | Integer | The DataMiner Agent ID that is linked to the element.                            |
| elementID    | Integer | The element ID.                                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetPagesForServiceElementV2Result | Array of [DMAElementPage](xref:DMAElementPage) | All the Data Display pages of the specified element, as well as the alarm cache status. |
