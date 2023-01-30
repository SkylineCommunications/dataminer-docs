---
uid: ClassLibrary_Range_1.4
---

# Class Library Range 1.4

> [!NOTE]
> Range 1.4.x.x is supported as from DataMiner version 10.3.1

### 1.4.0.1

#### New TableMatrixHelper class [ID_35302]

The *TableMatrixHelper* class will read out the mappings and options of a table matrix dummy parameter and forward this information to the *MatrixHelper* class.

Page and tooltip support has been added to the existing inputs/outputs. Also, support for a lock override parameter has been added.

New override methods:

- *OnToolTipSetFromUI*
- *OnPageSetFromUI*
- *OnCrossPointsSetViaLockOverrideFromUI*
