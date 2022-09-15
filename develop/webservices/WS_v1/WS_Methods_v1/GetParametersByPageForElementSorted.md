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
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| elementID  | Integer | The element ID.                                                                  |
| pageName   | String  | The name of the Data Display page.                                               |
| index      | Integer | The point from which to start returning parameters.                              |
| count      | Integer | The number of parameters to be returned.                                         |
| orderBy    | String  | The field(s) by which to order the parameters (separated by semicolons).         |

## Output

| Item | Format | Description |
|--|--|--|
| GetParametersByPageForElementSortedResult | Array of [DMAParameter](xref:DMAParameter) | The requested number of parameters, sorted as specified. |
