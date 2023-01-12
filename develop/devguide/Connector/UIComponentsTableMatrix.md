---
uid: UIComponentsTableMatrix
---

# Matrix

A matrix is a special type of parameter typically used to represent routers and switches. This is based on two tables containing the inputs and outputs.
For this purpose, three parameters must be configured in the protocol:

- A table parameter for the inputs of the matrix.
- A table parameter for the outputs of the matrix.
- A dummy parameter, which contains the matrix mappings and determines where the matrix control is displayed.

> [!NOTE]
> If a matrix control is configured like this, the severity colors of the crosspoints depend on the alarm monitoring configured for the outputs tables in the alarm template. This is not configured with the matrix alarm level editor like for classic matrix controls. The crosspoint severity color will be the highest severity color for all monitored column parameters of the outputs table for the relevant row.

> [!NOTE]
> Introduced in DataMiner 10.3.1 (RN 34645, RN 34661, RN 34839, RN 34879, RN 34933)

![alt text](../../images/uimatrix.png "DataMiner Cube matrix")

In this section:

- [Matrix parameter](xref:UIComponentsTableMatrixParameter)
- [Matrix Inputs Table parameter](xref:UIComponentsTableMatrixInputsTableParameter)
- [Matrix Outputs Table parameter](xref:UIComponentsTableMatrixOutputsTableParameter)
- [Matrix Helper](xref:UIComponentsTableMatrixHelper)

## See also

DataMiner Protocol Markup Language:

- [Protocol.Params.Param.Type: matrix](xref:Protocol.Params.Param.Type#matrix)
- [Protocol.Params.Param.Matrix](xref:Protocol.Params.Param.Matrix)
- [Protocol.Params.Param.Measurement.Type: matrix](xref:Protocol.Params.Param.Measurement.Type#matrix)