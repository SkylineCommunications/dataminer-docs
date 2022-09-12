---
uid: General_Feature_Release_10.2.9_CU1
---

# General Feature Release 10.2.9 CU1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.2.9](xref:Cube_Feature_Release_10.2.9).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Fixes

#### SNMP polling issues in case protocol contained wildcards in parameter OIDs [ID_34343]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 [CU1] -->

In some specific cases, wildcards in the parameter OIDs in a protocol caused polling to return no data. This only occurred when a parameter with a wildcard OID referred to another parameter that was not displayed.

#### ElementStateEventMessage would incorrectly be sent every time a command timed out on an element that was already in a timeout state [ID_34345]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 [CU1] -->
<!-- Not added to 10.3.0 -->

In some cases, it could occur that an ElementStateEventMessage was sent every time a command timed out on an element that was already in a timeout state, while this message should only be sent once when the element is put in a timeout state.

#### Smart-serial connection would no longer send commands [ID_34355]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 [CU1] -->
<!-- Not added to 10.3.0 -->

In some cases, a smart-serial connection would no longer send any commands because it incorrectly considered the *ConnectTimeoutTime* setting to be equal to zero.

Moreover, when an element was edited, the *ConnectTimeoutTime* setting would incorrectly be set to zero in the *Element.xml* file.
