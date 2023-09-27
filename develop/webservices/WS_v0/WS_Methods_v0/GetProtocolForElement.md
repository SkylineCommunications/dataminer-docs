---
uid: GetProtocolForElement
---

# GetProtocolForElement

Use this method to request all information regarding the protocol of a specific element.

## Input

| Item        | Format | Description                                   |
|-------------|--------|-----------------------------------------------|
| connection  | String | The connection ID. See [Connect](xref:Connect). |
| elementName | String | The element name.                             |

## Output

| Item                         | Format       | Description                                                      |
|------------------------------|--------------|------------------------------------------------------------------|
| GetProtocolForElementResult | ProtocolInfo | All information regarding the protocol of the specified element. |
