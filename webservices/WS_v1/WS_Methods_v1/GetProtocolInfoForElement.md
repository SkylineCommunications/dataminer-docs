---
uid: GetProtocolInfoForElement
---

# GetProtocolInfoForElement

Use this method to retrieve protocol information for a particular element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ElementID  | Integer | The element ID.                                                                  |

## Output

| Item                             | Format       | Description                                         |
|----------------------------------|--------------|-----------------------------------------------------|
| GetProtocolInfoFor­ElementResult | ProtocolInfo | The protocol information for the specified element. |

