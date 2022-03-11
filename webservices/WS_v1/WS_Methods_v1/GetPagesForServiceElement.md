---
uid: GetPagesForServiceElement
---

# GetPagesForServiceElement

Use this method to retrieve the Data Display pages of a specified element that is included in a specified service.

## Input

| Item         | Format  | Description                                                                      |
|--------------|---------|----------------------------------------------------------------------------------|
| Connection   | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ServiceDmaID | Integer | The DataMiner Agent ID that is linked to the service.                            |
| ServiceID    | Integer | The service ID.                                                                  |
| ElementDmaID | Integer | The DataMiner Agent ID that is linked to the element.                            |
| ElementID    | Integer | The element ID.                                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetPagesForService­ElementResult | Array of [DMAElementPage](xref:DMAElementPage) | All the Data Display pages of the specified element. |
