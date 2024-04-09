---
uid: General_Main_Release_10.4.0_CU3
---

# General Main Release 10.4.0 CU3 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Enhanced performance when processing changes made to service properties [ID_39011]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when processing changes made to service properties.

#### NATS configuration files will now use plain JSON syntax [ID_39078]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

All NATS configuration files will now use plain JSON syntax.

#### GQI: The IGQIOnInit and IGQIOnDestroy interfaces can now also be used in custom operators [ID_39088]

<!-- MR 10.4.0 [CU3] - FR 10.4.5 -->

From now on, the `IGQIOnInit` and `IGQIOnDestroy` interfaces can also be used in custom operators.

For more information on these interfaces, see:

- [IGQIOnInit interface](xref:GQI_IGQIOnInit)
- [IGQIOnDestroy interface](xref:GQI_IGQIOnDestroy)

### Fixes

#### Automatic incident tracking: Incomplete or empty alarm groups after DataMiner startup [ID_38441]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.5 -->

After a DataMiner startup, in some cases, certain alarm groups would either be incomplete or empty due to missing remote base alarms.

#### Protocols: Parsing problem could lead to string values being processed incorrectly [ID_39314]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

When string parameters are parsed, both an ASCII version and a Unicode version of the string value should be returned. However, up to now, when a string parameter was a table column parameter, the `Interprete` type of the table would be used. As a result, string values would be processed incorrectly.

From now on, when a table cell is saved, the `Interprete` type of the column will be used to determine whether or not it has to be processed as a string.
