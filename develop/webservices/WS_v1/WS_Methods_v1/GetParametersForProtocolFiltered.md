---
uid: GetParametersForProtocolFiltered
---

# GetParametersForProtocolFiltered

Use this method to retrieve the parameters of a particular protocol that match a specified filter. Available from DataMiner 9.6.4 onwards.

## Input

| Item                 | Format  | Description                                                                      |
|----------------------|---------|----------------------------------------------------------------------------------|
| connection           | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| protocolName         | String  | The name of the protocol                                                         |
| protocolVersion      | String  | The protocol version                                                             |
| filter.IncludeHidden | Boolean | Determines whether protocol parameters without display positions are included.   |
| filter.IncludeView   | Boolean | Determines whether view tables are included                                      |
| filter.IncludeWrite  | Boolean | Determines whether write parameters are included.                                |
| filter.Index         | Integer | The point from which to start returning parameters.                              |
| filter.Count         | Integer | The number of parameters to be returned.                                         |

## Output

| Item | Format | Description |
|--|--|--|
| GetParametersForProtocolFilteredResult | Array of [DMAParameter](xref:DMAParameter) | The parameters of the specified protocol that match the specified filter. |
