---
uid: GetPagesForServiceElement
---

# GetPagesForServiceElement

Use this method to retrieve the Data Display pages of a specified element that is included in a specified service.

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
| GetPagesForServiceElementResult | Array of [DMAElementPage](xref:DMAElementPage) | All the Data Display pages of the specified element. |
