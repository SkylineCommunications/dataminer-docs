---
uid: GetElement
---

# GetElement

Use this method to retrieve the data of a particular element.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                              |
| elementID  | Integer | The element ID.                                      |

## Output

| Item             | Format                        | Description                        |
|------------------|-------------------------------|------------------------------------|
| GetElementResult | [DMAElement](xref:DMAElement) | The data of the specified element. |
