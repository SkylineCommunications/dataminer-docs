---
uid: GetParametersForElementFiltered
---

# GetParametersForElementFiltered

Use this method to retrieve the parameters of a particular element that match a specified filter. Available from DataMiner 9.6.7 onwards.

## Input

| Item                 | Format  | Description                                                                      |
|----------------------|---------|----------------------------------------------------------------------------------|
| connection           | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID                | Integer | The ID of the DMA where the element was originally created.                      |
| elementID            | Integer | The ID of the element.                                                           |
| filter.IncludeHidden | Boolean | Determines whether protocol parameters without display positions are included.   |
| filter.IncludeView   | Boolean | Determines whether view tables are included                                      |
| filter.IncludeWrite  | Boolean | Determines whether write parameters are included.                                |
| filter.Index         | Integer | The point from which to start returning parameters.                              |
| filter.Count         | Integer | The number of parameters to be returned.                                         |
| filter.OrderBy       | String  | The field(s) by which to order the parameters (separated by semicolons).         |

## Output

| Item | Format | Description |
|--|--|--|
| GetParametersForElementFilteredResult | Array of [DMAParameter](xref:DMAParameter) | The parameters of the specified element that match the specified filter. |
