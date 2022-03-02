---
uid: GetVisioPagesForElement
---

# GetVisioPagesForElement

Use this method to retrieve a list of the pages of the Visio file linked to a particular element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ElementID  | Integer | The element ID.                                                                  |

## Output

| Item                           | Format                                                                               | Description                                                  |
|--------------------------------|--------------------------------------------------------------------------------------|--------------------------------------------------------------|
| GetVisioPagesForEle­mentResult | Array of DMAVisioPage (see [DMAVisioPage](xref:DMAVisioPage)) | A list of the pages of the Visio file linked to the element. |

