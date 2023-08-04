---
uid: Protocol-EnumMatrixMatrixOptionNameType
---

# EnumMatrixMatrixOptionNameType simple type

List of types that can be used in the matrix option name.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|matrixLayout|Indicates to position inputs or outputs at the top or on the left. Note: For table matrices, the only supported values are *InputTopOutputLeft* or *InputLeftOutputTop*.|
|&nbsp;&nbsp;Enumeration|pages|Indicates to enable auto-paging. Note: custom pages can be set via the page column on the table.|
|&nbsp;&nbsp;Enumeration|minimumConnectedInputsPerOutput|Indicates the minimum of connected inputs for an output. Note: 0 for no minimum.|
|&nbsp;&nbsp;Enumeration|maximumConnectedInputsPerOutput|Indicates the maximum of connected inputs for an output. Note: Always 1 for table matrices.|
|&nbsp;&nbsp;Enumeration|minimumConnectedOutputsPerInput|Indicates the minimum of connected outputs for an input. Note: 0 for no minimum.|
|&nbsp;&nbsp;Enumeration|maximumConnectedOutputsPerInput|Indicates the maximum of connected outputs for an input. Note: *auto* for no maximum.|
