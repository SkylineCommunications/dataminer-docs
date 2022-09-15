---
uid: GetParametersByPageForServiceElement
---

# GetParametersByPageForServiceElement

Use this method to retrieve the data of all the parameters on a particular Data Display page of an element.

## Input

| Item         | Format  | Description                                                                      |
|--------------|---------|----------------------------------------------------------------------------------|
| connection   | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| serviceDmaID | Integer | The DataMiner Agent ID that is linked to the service.                            |
| serviceID    | Integer | The service ID.                                                                  |
| elementDmaID | Integer | The DataMiner Agent ID that is linked to the element.                            |
| elementID    | Integer | The element ID.                                                                  |
| pageName     | String  | The name of the element page.                                                    |

## Output

| Item | Format | Description |
|--|--|--|
| GetParametersByPageForServiceElementResult | Array of [DMAParameter](xref:DMAParameter) | The data of all the parameters on the specified element page. |
