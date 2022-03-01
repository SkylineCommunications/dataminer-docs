---
uid: GetParametersByPageForServiceElement
---

# GetParametersByPageForServiceElement

Use this method to retrieve the data of all the parameters on a particular Data Display page of an element.

## Input

| Item         | Format  | Description                                                                      |
|--------------|---------|----------------------------------------------------------------------------------|
| Connection   | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| ServiceDmaID | Integer | The DataMiner Agent ID that is linked to the service.                            |
| ServiceID    | Integer | The service ID.                                                                  |
| ElementDmaID | Integer | The DataMiner Agent ID that is linked to the element.                            |
| ElementID    | Integer | The element ID.                                                                  |
| PageName     | String  | The name of the element page.                                                    |

## Output

| Item                                        | Format                                                                               | Description                                                   |
|---------------------------------------------|--------------------------------------------------------------------------------------|---------------------------------------------------------------|
| GetParametersByPage­ForServiceElementResult | Array of DMAParameter (see [DMAParameter](xref:DMAParameter)) | The data of all the parameters on the specified element page. |

