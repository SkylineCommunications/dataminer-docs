---
uid: General_Feature_Release_10.3.12
---

# General Feature Release 10.3.12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.12](xref:Cube_Feature_Release_10.3.12).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.12](xref:Web_apps_Feature_Release_10.3.12).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been added to this section yet.*

## New features

#### Configuration of behavioral anomaly alarms [ID_36857] [ID_36976] [ID_37124] [ID_37246] [ID_37250] [ID_37334] [37434]

<!-- MR 10.4.0 - FR 10.3.12 -->

The DataMiner software now supports a more extensive configuration of behavioral anomaly alarms.

From now on, you will be able to choose between the following types of anomaly monitoring:

- Smart anomaly monitoring (i.e. anomaly monitoring as it existed before)
- Customized anomaly monitoring

Customized anomaly monitoring will enable you to do the following:

- Set absolute or relative thresholds on the jump sizes of the change points of type *Level Shift* or *Outlier*.
- Enable or disable monitoring for each of the two possible directions of a behavioral change for level shifts, trend changes, variance changes and outliers. This will allow you, for example, to configure different alarm monitoring behaviors for downward level shifts and upward level shifts.

For more information on how to configure anomaly monitoring in DataMiner Cube, see RN37148 and RN37171.

Summary of server-side changes:

- The behavioral anomaly configuration can be requested by sending a *GetAlarmTemplateMessage*. The *GetAlarmTemplateResponseMessage* will then return the behavioral anomaly configuration in a new *AnomalyConfiguration* field.

  If you enable behavioral anomaly monitoring, the *AnomalyConfiguration* field will contain information on which change point types are being monitored and how. If no behavioral anomaly monitoring has been configured, this field will remain empty.

  The legacy anomaly monitoring fields *LevelShiftMonitor*, *TrendMonitor*, *VarianceMonitor* and *FlatlineMonitor* in the *GetAlarmTemplateResponseMessage* have been marked as obsolete. If, in existing alarm templates, at least one of those legacy fields was enabled, the *AnomalyConfiguration* field will be filled with values consistent with the old settings.  

- The  anomaly configuration information for a parameter is no longer available in the *ParameterAlarmInfo* of each parameter. This means that the anomaly monitoring information can no longer be retrieved by means of a *GetElementProtocolMessage*.

  The legacy anomaly monitoring fields *LevelShiftMonitor*, *TrendMonitor*, *VarianceMonitor* and *FlatlineMonitor* in the *ParameterAlarmInfo* have been marked as obsolete and will no longer be taken into account by SLAnalytics.

- When upgrading to this DataMiner version, existing alarm template XML files will not be changed.

  When you update an existing alarm template or creating a new one, a new `<AnomalyConfig>` element will be added into the body of the `<Alarm>` element if, and only if, behavioral anomaly monitoring is enabled and an extended anomaly configuration has been set via the *AnomalyConfiguration* field of the *GetAlarmTemplateResponse* or the template parameters.

  The existing attributes of the `<Monitored>` element (i.e. *varianceMonitor*, *trendMonitor*, *levelShiftMonitor* and *flatLineMonitor*) have not been changed or removed to ensure compatibility of the new alarm template XML files with older DataMiner versions.

- When you set up a customized behavioral anomaly monitoring containing relative or absolute thresholds, this setup will be lost when you downgrade to an older server version that does not support this extended anomaly configuration (i.e. DataMiner version 10.3.11 or older). A fallback to the legacy "smart anomaly monitoring" will happen for all the change point types that had some kind of anomaly monitoring enabled.

- The internal SLAnalytics alarm template monitoring mechanism now also takes into account alarm template group information. As a result, SLAnalytics modules making use of this mechanism will get notified about changes to group entries and can react to these changes.

- A behavioral change point of type "flatline" shown in the trend graph will now always receive the correct alarm color when an anomaly alarm was created for it. In other words, if a critical behavioral anomaly alarm was created for the behavioral change of type "flatline", the change point bar shown in the trend graph will receive the red color.

## Changes

### Enhancements

#### Service & Resource Management: Enhanced performance when editing/deleting profile parameters [ID_37097]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Because of a number of enhancements, overall performance has increased when editing or deleting profile parameters of type *Capability* or *Capacity*, especially on systems with a large number of future bookings.

#### Enhanced performance when offloading data in case the database is down [ID_37365]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Because of a number of enhancements, overall performance has increased when offloading data in case the database is down.

#### SLAnalytics - Proactive cap detection: Enhanced verification of forecasted alarms [ID_37368]

<!-- MR 10.4.0 - FR 10.3.12 -->

A number of enhancements have been made with regard to the verification of forecasted alarms generated by the proactive cap detection feature.

#### SLAnalytics - Trend predictions: Flatline periods will no longer be included in the prediction model training data [ID_37432]

<!-- MR 10.4.0 - FR 10.3.12 -->

When a parameter has anomalous flatline periods in its trend data history that are breaking the normal trend data patterns, from now on, those flatline periods will no longer be included into the training data of the prediction model. As a result, a more accurate prediction can be expected on this kind of behavior.

#### Storage as a Service: Enhanced performance of DOM and SRM queries [ID_37495]

<!-- MR 10.4.0 - FR 10.3.12 -->

Because of a number of enhancements, overall performance of DOM and SRM queries has increased.

#### Security enhancements [ID_37540]

<!-- 37540: MR 10.4.0 - FR 10.3.12 -->

A number of security enhancements have been made.

#### Storage as a Service: Enhanced error handling [ID_37554]

<!-- MR 10.4.0 - FR 10.3.12 -->

A number of enhancements have been made with regard to error handling.

### Fixes

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
