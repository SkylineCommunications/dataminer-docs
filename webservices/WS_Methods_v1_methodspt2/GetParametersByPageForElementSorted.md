---
uid: GetParametersByPageForElementSorted
---

# GetParametersByPageForElementSorted

Use this method to retrieve a specific number of parameters on a particular Data Display page of an element.

> [!NOTE]
> Using this method, you can e.g. request parameter data in batches in order to minimize loading time.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ElementID  | Integer | The element ID.                                                                  |
| PageName   | String  | The name of the Data Display page.                                               |
| Index      | Integer | The point from which to start returning parameters.                              |
| Count      | Integer | The number of parameters to be returned.                                         |
| OrderBy    | String  | The field(s) by which to order the parameters (separated by semicolons).         |

## Output

| Item                                       | Format                                                                               | Description                                              |
|--------------------------------------------|--------------------------------------------------------------------------------------|----------------------------------------------------------|
| GetParametersByPage­ForElementSortedResult | Array of DMAParameter (see [DMAParameter](xref:DMAParameter)) | The requested number of parameters, sorted as specified. |

