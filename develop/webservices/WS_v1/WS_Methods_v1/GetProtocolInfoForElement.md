---
uid: GetProtocolInfoForElement
---

# GetProtocolInfoForElement

Use this method to retrieve protocol information for a particular element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| elementID  | Integer | The element ID.                                                                  |

## Output

| Item                             | Format       | Description                                         |
|----------------------------------|--------------|-----------------------------------------------------|
| GetProtocolInfoForElementResult  | ProtocolInfo | The protocol information for the specified element. |
