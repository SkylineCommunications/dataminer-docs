---
uid: General_Main_Release_10.3.0_CU9
---

# General Main Release 10.3.0 CU9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Service & Resource Management: Enhanced performance when editing/deleting profile parameters [ID_37097]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Because of a number of enhancements, overall performance has increased when editing or deleting profile parameters of type *Capability* or *Capacity*, especially on systems with a large number of future bookings.

#### Security enhancements [ID_37267]

<!-- RN 37267: MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.11 -->

A number of security enhancements have been made.

#### Enhanced performance when offloading data in case the database is down [ID_37365]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Because of a number of enhancements, overall performance has increased when offloading data in case the database is down.

### Fixes

#### Problem in different native processes when interacting with message broker calls [ID_37150]

<!-- MR 10.3.0 [CU9] - FR 10.3.11 -->

In some cases, an error could occur in different native processes when interacting with message broker calls.

#### Problem when requesting alarm monitoring information for an exported parameter [ID_37424]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

In some cases, incorrect data would be returned when requesting alarm monitoring information for a parameter exported as a standalone parameter to a DVE child element, especially when dynamic thresholds had been configured in the alarm template.
