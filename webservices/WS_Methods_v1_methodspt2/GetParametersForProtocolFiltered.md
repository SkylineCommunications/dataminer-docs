---
uid: GetParametersForProtocolFiltered
---

# GetParametersForProtocolFiltered

Use this method to retrieve the parameters of a particular protocol that match a specified filter. Available from DataMiner 9.6.4 onwards.

## Input

| Item                 | Format  | Description                                                                      |
|----------------------|---------|----------------------------------------------------------------------------------|
| Connection           | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| ProtocolName         | String  | The name of the protocol                                                         |
| ProtocolVersion      | String  | The protocol version                                                             |
| Filter.IncludeHidden | Boolean | Determines whether protocol parameters without display positions are included.   |
| Filter.IncludeView   | Boolean | Determines whether view tables are included                                      |
| Filter.IncludeWrite  | Boolean | Determines whether write parameters are included.                                |
| Filter.Index         | Integer | The point from which to start returning parameters.                              |
| Filter.Count         | Integer | The number of parameters to be returned.                                         |

## Output

| Item                                    | Format                                                                               | Description                                                               |
|-----------------------------------------|--------------------------------------------------------------------------------------|---------------------------------------------------------------------------|
| GetParametersFor­ProtocolFilteredResult | Array of DMAParameter (see [DMAParameter](xref:DMAParameter)) | The parameters of the specified protocol that match the specified filter. |

