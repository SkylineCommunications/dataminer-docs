---
uid: GetAnnotationsLinkForElement
---

# GetAnnotationsLinkForElement

Use this method to retrieve a link to open the annotations page of the specified element.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                              |
| elementID  | Integer | The element ID.                                      |

## Output

| Item                                | Format | Description                                      |
|-------------------------------------|--------|--------------------------------------------------|
| GetAnnotationsLinkForElementResult | String | The link to the annotations page of the element. |
