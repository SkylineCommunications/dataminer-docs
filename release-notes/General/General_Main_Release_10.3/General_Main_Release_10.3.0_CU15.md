---
uid: General_Main_Release_10.3.0_CU15
---

# General Main Release 10.3.0 CU15 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Enhanced performance when processing changes made to service properties [ID_39011]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when processing changes made to service properties.

#### Enhanced performance when logging on to cloud-connected DataMiner Agents or DaaS systems with an older version of a DataMiner Cube client [ID_39211]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

Performance has increased when logging on to cloud-connected DataMiner Agents or DaaS systems with an older version of a DataMiner Cube client.

### Fixes

#### Automatic incident tracking: Incomplete or empty alarm groups after DataMiner startup [ID_38441]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

After a DataMiner startup, in some cases, certain alarm groups would either be incomplete or empty due to missing remote base alarms.

#### Protocols: Parsing problem could lead to string values being processed incorrectly [ID_39314]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

When string parameters are parsed, both an ASCII version and a Unicode version of the string value should be returned. However, up to now, when a string parameter was a table column parameter, the `Interprete` type of the table would be used. As a result, string values would be processed incorrectly.

From now on, when a table cell is saved, the `Interprete` type of the column will be used to determine whether or not it has to be processed as a string.
