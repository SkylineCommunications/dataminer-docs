---
uid: DMAInputData
---

# DMAInputData

Represents an input data object, which can be:

- *DMAInputDataUserInput*: Indicates input specified by the user, with the following fields:

  - *AllowNAForEmptyValues* (bool): Determines whether N/A can be specified to indicate an empty value.

  - *RequireValidElementName* (bool): Determines whether a valid element name is required as input.

- *DMAInputDataFixedValue*: Indicates a fixed value that is used as input. Consists of one [DMASTString](xref:DMASTString).

- *DMAInputDataTableRowIndex*: Indicates a table row from which the input data will be retrieved.

  - *ParameterID* (int): The table parameter ID.

  - *FilterMask* (DMASTString): See [DMASTString](xref:DMASTString).

  - *TableRowParameter* (*DMAInputDataTableRowParameter*): The element containing the table row, which can be:

    - *DMAInputDataTableRowParameterFromChildElement*: A child element of the generated service, specified by *ChildID* (int).

    - *DMAInputDataTableRowParameterFromOtherElement*: A different DataMiner element, specified by *DataMinerID* (int) and *elementID* (int).
