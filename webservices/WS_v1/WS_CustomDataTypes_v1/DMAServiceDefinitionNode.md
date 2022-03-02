---
uid: DMAServiceDefinitionNode
---

# DMAServiceDefinitionNode

| Item                   | Format                                          | Description                                                                                                 |
|------------------------|-------------------------------------------------|-------------------------------------------------------------------------------------------------------------|
| ID                     | String                                          | The service definition node ID.                                                                             |
| Label                  | String                                          | The service definition node description.                                                                    |
| Groups                 | Array of string                                 | The names of the groups containing the node.                                                                |
| Row                    | Integer                                         | The row in which the node is located.                                                                       |
| Column                 | Integer                                         | The column in which the node is located.                                                                    |
| Resource               | DMAResource (see [DMAResource](xref:DMAResource)) | The resource linked to the node.                                                                            |
| Image                  | String                                          | The image used for the node.                                                                                |
| Properties             | Array of DMASRMProp­erty                        | The properties of the node.                                                                                 |
| InterfaceConfiguration | Array of DMANodeInter­faceConfiguration         | The interface configuration of the node.                                                                    |
| FunctionDefinition     | DMAFunctionDefinition­Lite                      | the function definition linked to the node (see [DMAFunctionDefinitionLite](xref:DMAFunctionDefinitionLite)). |
