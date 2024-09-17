---
uid: Cube_Feature_Release_10.4.11
---

# DataMiner Cube Feature Release 10.4.11 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.4.11](xref:General_Feature_Release_10.4.11).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### System Center - Logging: Additional log files available in DataMiner tab [ID 40676]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

In the *Logging* section of *System Center*, a number of additional log files can now be consulted in the *DataMiner* tab:

- App Package Installer
- Cluster Transition Manager
- Database Migration
- SAML
- Spectrum Manager
- UI Provider

### Fixes

#### Services: Alarm color of a service card page would be incorrect when the service contained a partially included table of an element [ID 40597]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When you opened the card of a service that contained only part of a table of an element, in some cases, the alarm color of the card page would  incorrectly reflect the alarm state of the entire table instead of the consolidated alarm state of the included rows.

#### Alarm Console: Problem when requesting history information events [ID 40646]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When you dragged an element onto the Alarm Console and requested the information events of e.g. the last hour, up to now, Cube would send two requests to the server: one to return the alarms and another to return the information events. Unfortunately, the request to return the alarms would always fail, causing the request to return the information events to not get executed. As a result, no information events would appear in the Alarm Console.

From now on, in the above-mentioned situation, only a request to return the information events will be sent to the server.

#### Problem when clearing an alarm after opening a visual overview containing AlarmSummary shapes [ID 40669]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

After you had opened a visual overview containing AlarmSummary shapes while being connected to a DataMiner Agent running version 10.4.9, in some cases, DataMiner Cube could stop working due to an error occurring when an alarm was cleared.

#### Visual Overview: Spectrum measurement point linked to a card variable would incorrectly not be loaded [ID 40681]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When, in an embedded Spectrum Analysis component, you used an inline preset with a measurement point linked to a card variable, that measurement point would incorrectly not be loaded.
