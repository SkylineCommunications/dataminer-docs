---
uid: GetParameters
---

# GetParameters

Use this method to retrieve a number of element parameters by ID and name.

## Input

| Item       | Format          | Description                                                                      |
|------------|-----------------|----------------------------------------------------------------------------------|
| Connection | String          | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer         | The DataMiner Agent ID.                                                          |
| ElementID  | Integer         | The element ID.                                                                  |
| Parameters | Array of string | The IDs and names of the parameters to be retrieved.                             |

## Output

| Item                | Format                                                                               | Description                               |
|---------------------|--------------------------------------------------------------------------------------|-------------------------------------------|
| GetParametersResult | Array of DMAParameter (see [DMAParameter](xref:DMAParameter)) | The parameters for the specified element. |

