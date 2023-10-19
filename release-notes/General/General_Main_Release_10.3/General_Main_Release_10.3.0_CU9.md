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

#### Service & Resource Management: Initialization of ResourceManager and SRMServiceStateManager will be retried up to 5 times [ID_37507]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When *ResourceManager* and *SRMServiceStateManager* fail to get initialized at DataMiner startup, the system will now retry up to 5 times to get those managers up and running.

#### SLAnalytics - Behavioral anomaly detection: Enhanced trend change detection [ID_37571]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

If, upon detection of a new trend, the trend returns to the old trend (i.e. the trend before the behavioral change) within the hour, the behavioral change will be labeled a level shift rather than a trend change.

### Fixes

#### Problem in different native processes when interacting with message broker calls [ID_37150]

<!-- MR 10.3.0 [CU9] - FR 10.3.11 -->

In some cases, an error could occur in different native processes when interacting with message broker calls.

#### NATSCustodian could incorrectly pick an offline DMA as NAS candidate [ID_37312]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

Up to now, when NATSCustodian had to pick a NAS candidate, in some cases, it could pick a DataMiner Agent that was offline, causing an error to occur when trying to copy the credentials.

From now on, it will only be possible to trigger a NATS configuration reset when all DataMiner Agents in the cluster are online/running.

#### Problem when requesting alarm monitoring information for an exported parameter [ID_37424]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

In some cases, incorrect data would be returned when requesting alarm monitoring information for a parameter exported as a standalone parameter to a DVE child element, especially when dynamic thresholds had been configured in the alarm template.

#### Updated dynamic IP address would incorrectly be applied to all connections of an element [ID_37445]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When a parameter that was used to store the dynamic IP address of an element connection was updated, the dynamic IP address would incorrectly be applied to all connections of that element when the element was restarted.

#### Duplicate PropertyChangeEvent objects would be created in the event cache [ID_37485]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

In some cases, incorrect duplicate PropertyChangeEvent objects would be created in the event cache.

The properties were correctly updated on the respective elements, but the DMAs that forwarded the requests would incorrectly generate additional, incorrect PropertyChangedEvents, which could lead to, for example, outdated property values being displayed in user interfaces.

#### SLAnalytics: Problem when simultaneously stopping the 'Alarm Focus' and 'Automatic Incident Tracking' features [ID_37496]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, when you stopped both *Alarm Focus* and *Automatic Incident Tracking* at the same time (e.g. via *System Center > System settings > analytics config* in DataMiner Cube), only *Alarm Focus* would actually be stopped. *Automatic Incident Tracking* would still be active, but in an incorrect state.

#### Service & Resource Management: Problem with resource capability exposers [ID_37503]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When a resource did not have both a minimum and maximum value for a particular range point, the resource capability exposers would not work correctly for that range point.

#### PropertyChangeEvents would not be removed from the SLNet event cache when an element was deleted [ID_37576]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When an element was deleted, `PropertyChangeEvent` instances for that element would incorrectly not get removed from the SLNet event cache.

#### SLAnalytics: Problem after losing connection with SLDataGateway [ID_37603]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When SLAnalytics lost connection with SLDataGateway, an exception would be thrown, causing SLAnalytics to become unresponsive.

#### DataMiner Object Models: DomManager would not initialize when it received its first call [ID_37604]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When the first call to a DomManager after a DMA (re)start was a call to create, update or delete a HistoryChange object, the call would fail and the DomManager would not initialize.
