---
uid: GetParametersForElementFiltered
---

# GetParametersForElementFiltered

Use this method to retrieve the parameters of a particular element that match a specified filter. Available from DataMiner 9.6.7 onwards.

## Input

| Item                 | Format  | Description                                                                      |
|----------------------|---------|----------------------------------------------------------------------------------|
| Connection           | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID                | Integer | The ID of the DMA where the element was originally created.                      |
| ElementID            | Integer | The ID of the element.                                                           |
| Filter.IncludeHidden | Boolean | Determines whether protocol parameters without display positions are included.   |
| Filter.IncludeView   | Boolean | Determines whether view tables are included                                      |
| Filter.IncludeWrite  | Boolean | Determines whether write parameters are included.                                |
| Filter.Index         | Integer | The point from which to start returning parameters.                              |
| Filter.Count         | Integer | The number of parameters to be returned.                                         |
| Filter.OrderBy       | String  | The field(s) by which to order the parameters (separated by semicolons).         |

## Output

| Item | Format | Description |
|--|--|--|
| GetParametersFor­ElementFilteredResult | Array of [DMAParameter](xref:DMAParameter) | The parameters of the specified element that match the specified filter. |
