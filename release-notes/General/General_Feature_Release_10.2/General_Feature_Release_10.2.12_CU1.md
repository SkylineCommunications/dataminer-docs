---
uid: General_Feature_Release_10.2.12_CU1
---

# General Feature Release 10.2.12 CU1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.2.12](xref:Cube_Feature_Release_10.2.12).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Fixes

#### Low-Code Apps: Drop-down box containing an 'execute component' action would incorrectly be empty [ID_34953]

<!-- MR 10.3.0 - FR 10.2.12 [CU1] -->

When an *execute component* action had been configured, in some cases, when you tried to update that action, the drop-down box containing the action would incorrectly be empty.

#### Dashboards app & low-Code Apps: Manually sorted GQI table would no longer feed row values [ID_34969]

<!-- MR 10.3.0 - FR 10.2.12 [CU1] -->

When you had manually changed the sorting order of a GQI table by clicking a column header, in some cases, the table would no longer feed the selected row values.
