---
uid: General_Main_Release_10.3.0_CU15
---

# General Main Release 10.3.0 CU15

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.3.0 CU15](xref:Cube_Main_Release_10.3.0_CU15).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.3.0 CU15](xref:Web_apps_Main_Release_10.3.0_CU15).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### 'Database Security' BPA test has been replaced by the 'Security Advisory' BPA test [ID 38632]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.5 -->

The *Database Security* BPA test has been replaced by the *Security Advisory* BPA test, which will run a collection of checks to see if the system is configured as securely as possible.

For more information on this new BPA test, see [Security Advisory](xref:BPA_Security_Advisory).

#### Enhanced performance when processing changes made to service properties [ID 39011]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when processing changes made to service properties.

#### Enhanced performance when logging on to cloud-connected DataMiner Agents or DaaS systems with an older version of a DataMiner Cube client [ID 39211]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

Performance has increased when logging on to cloud-connected DataMiner Agents or DaaS systems with an older version of a DataMiner Cube client.

#### DataMiner Cube clients using a gRPC connection are now able to better detect a disconnection [ID 39308]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements, Cube clients connected to a DataMiner Agent via a gRPC connection will now be able to better detect when they have been disconnected.

### Fixes

#### Automatic incident tracking: Incomplete or empty alarm groups after DataMiner startup [ID 38441]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

After a DataMiner startup, in some cases, certain alarm groups would either be incomplete or empty due to missing remote base alarms.

#### Protocols: Parsing problem could lead to string values being processed incorrectly [ID 39314]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

When string parameters are parsed, both an ASCII version and a Unicode version of the string value should be returned. However, up to now, when a string parameter was a table column parameter, the `Interprete` type of the table would be used. As a result, string values would be processed incorrectly.

From now on, when a table cell is saved, the `Interprete` type of the column will be used to determine whether or not it has to be processed as a string.

#### Service & Resource Management: Problems caused by a failed midnight synchronization of the Resource Manager [ID 39420]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

If the midnight synchronization of the Resource Manager fails, it is retried up to 5 times. Up to now, when a synchronization retry was triggered, the internal caches of the Resource Manager would incorrectly be loaded twice. This could lead to, for example, bookings not being starting.

#### SLAutomation: Problem when clearing the internal parameter cache [ID 39441]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

In some cases, an error could occur in SLAutomation when its internal parameter cache was being cleared.

#### Security: Problem when granting a user group access to multiple elements in the same view [ID 39449]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 -->

When you tried to grant a user group access to multiple elements in the same view, only the first of the elements you selected would be added.

#### Caches would not get disposed correctly when the Resource Manager was reinitialized [ID 39493]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.6 [CU0] -->

When the Resource Manager was reinitialized, the caches would not be disposed correctly, causing SLNet to leak memory.
