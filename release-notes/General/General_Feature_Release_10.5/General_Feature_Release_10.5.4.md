---
uid: General_Feature_Release_10.5.4
---

# General Feature Release 10.5.4 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version, make sure **version 14.40.33816** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.
>
> The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
> - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
> - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.4](xref:Cube_Feature_Release_10.5.4).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.4](xref:Web_apps_Feature_Release_10.5.4).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### Elements can now be configured to run in isolation mode [ID 41757]

<!-- MR 10.6.0 - FR 10.5.4 -->

Up to now, the *ProcessOptions* section of the *DataMiner.xml* file allowed you to configure that an element had to run in its own SLProtocol and SLScripting processes, and in a *protocol.xml* file, the *RunInSeparateInstance* tag allowed you to do the same. However, it was only possible to configure this for all elements using a particular protocol.

From now on, the new *Run in isolation mode* feature will allow you to also configure this for one single element.

As creating additional SLProtocol processes has an impact on the resource usage of a DataMiner Agent, a hard limit of 50 SLProtocol processes has been introduced. If, when an element starts, an attempt to create a new SLProtocol process fails because 50 processes are already running, the element will be hosted by an existing SLProtocol process and its matching SLScripting process, regardless of how the *Run in isolation mode* was configured.

From those 50 SLProtocol processes, 10 processes will be reserved for elements that are not running in isolation mode. This means, that only 40 elements will be able to run in isolation mode at any given time. However, the notice that will appear each time an attempt is made to start an additional element in isolation mode will mention the 50-element limit.

Reducing the number of SLProtocol processes in the *DataMiner.xml* file will reduce the number of reserved processes. However, increasing the number of SLProtocol processes to above 50 will keep the reserved number of SLProtocol processes to 50 (i.e. the maximum number of SLProtocol processes).

For example, if 15 SLProtocol processes are configured in the *DataMiner.xml* file, and 45 elements are configured to run in isolation mode, then:

- 10 SLProtocol processes will be used for elements that are not running in isolation mode,
- 35 SLProtocol processes will be used to host an element in isolation mode, and
- the remaining 5 SLProtocol processes will be used for elements running either in isolation mode or not, depending on which elements starts first.

This means, that some elements will not be able to run in isolation mode, and some SLProtocol processes will not be able to host elements that are not running in isolation mode. In each of those cases, an alarm will be generated.

In the DataMiner.xml file, it is possible to configure a separate SLProtocol process for every protocol that is being used. This setting will also comply with the above-mentioned hard limit of 50 SLProtocol processes. As this type of configuration is intended for testing/debugging purposes only, an alarm will be generated when such a configuration is active to avoid that this setting would remain active once the investigation is done.

For more information on how to configure elements to run in isolation mode in DataMiner Cube, see [Elements can now be configured to run in isolation mode [ID 41758]](xref:Cube_Feature_Release_10.5.4#elements-can-now-be-configured-to-run-in-isolation-mode-id-41758).

#### Information events of type 'script started' will no longer be generated when an Automation script is triggered by the Scheduler app [ID 41970]

<!-- MR 10.6.0 - FR 10.5.4 -->

From now on, by default, information events of type "script started" will no longer be generated when an Automation script is triggered by the Scheduler app.

In other words, when an Automation script is triggered by the Scheduler app, the SKIP_STARTED_INFO_EVENT:TRUE option will automatically be added to the `ExecuteScriptMessage`. See also [Release note 33666](xref:General_Main_Release_10.3.0_new_features_1#added-the-option-to-skip-the-script-started-information-event-id-33666).

If you do want such information events to be generated, you can add the `SkipInformationEvents` option to the *MaintenanceSettings.xml* file and set it to false:

```xml
<MaintenanceSettings xmlns="http://www.skyline.be/config/maintenancesettings">
    ...
    <SLNet>
        ...
        <SkipInformationEvents>false</SkipInformationEvents>
        ...
    </SLNet>
    ...
</MaintenanceSettings>
```

## Changes

### Enhancements

#### Enhanced performance when updating subscriptions and when checking events against the set of active subscriptions [ID 41822]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

Because of a number of enhancements, overall performance has increased when updating subscriptions and when checking events against the set of active subscriptions.

#### Credentials library is now fully aware of all supported SNMPv3 authentication and encryption algorithms [ID 41923]

<!-- MR 10.6.0 - FR 10.5.4 -->
<!-- Reverted by RN 42136 and reinstated by RN 42153 -->

Up to now, the credentials library would only be aware of a subset of all SNMPv3 authentication and encryption algorithms.

Because of a number of enhancements, it will now be fully aware of all supported algorithms.

#### Service & Resource Management: Enhanced handling of locked files when activating or deactivating functions [ID 41978]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

A number of enhancements have been made to the ProtocolFunctionManager with regard to the handling of locked files when activating or deactivating functions.

#### Suggestion events created by Relational anomaly detection for a group of parameters will now be grouped into a single incident [ID 41983]

<!-- MR 10.6.0 - FR 10.5.4 -->

When Relational anomaly detection (RAD) detects that a group of parameters deviates from its normal behavior, it will create a suggestion event for each of the parameters in that group. These suggestion events will now be grouped into a single incident so that it is shown on a single line in the Alarm Console.

When you clear such an incident, all its base alarms (i.e. the suggestion events created by Relational anomaly detection) will also be cleared.

#### NATS: NatsCustodianResetNatsRequest will now be blocked when the NATSForceManualConfig option is enabled [ID 42074]

<!-- MR 10.5.0 [CU1] - FR 10.5.4 -->

When the `NATSForceManualConfig` option is enabled in the *MaintenanceSettings.xml* file, the `NatsCustodianResetNatsRequest` message will now be blocked. Instead of performing a NATS reset, it will now return an error with the following message:

`Resetting NATS is blocked while the system is running a Manual Config. See https://docs.dataminer.services/user-guide/Reference/DataMiner_Tools/SLNetClientTest_tool/SLNetClientTest_tool_advanced_procedures/SLNetClientTest_disabling_automatic_nats_config.html for more information.`

> [!NOTE]
> The `NatsCustodianResetNatsRequest` message will also be blocked when BrokerGateway is being used.

#### Security enhancements [ID 41425] [ID 42104]

<!-- 41425: MR 10.6.0 - FR 10.5.4 -->
<!-- 42104: MR 10.5.0 [CU1] - FR 10.5.4 -->

A number of security enhancements have been made.

#### Disabling an SLAnalytics feature will now clear all open alarms and suggestion events associated with that feature [ID 42096]

<!-- MR 10.6.0 - FR 10.5.4 -->

When, in DataMiner Cube, you go to *System Center > System settings > Analytics config*, and you explicitly disable one of the following SLAnalytics features, all open alarms and suggestion events associated with that feature will now automatically be cleared:

- Behavioral anomaly detection
- Pattern matching
- Proactive cap detection
- Relational anomaly detection

### Fixes

#### DataMiner Object Models: No longer possible to query DOM after initializing a Cassandra Cluster migration [ID 40993]

<!-- MR 10.6.0 - FR 10.5.4 -->

After a Cassandra Cluster migration had been initialized, it would no longer be possible to query DOM.

#### Mobile Visual Overview: Problem when the same mobile visual overview was requested by multiple users of the same user group [ID 41881]

<!-- MR 10.6.0 - FR 10.5.4 -->

When multiple users of the same user group requested the same mobile visual overview, in some rare cases, a separate DataMiner Cube instance would incorrectly be created on the DataMiner Agent for each of those users, potentially causing the creation of one Cube instance to block the creation of another Cube instance.

#### Problem when trying to update the protocol version of an element in error [ID 41962]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When you tried to update the protocol version of an element in error via DataMiner Cube, in some rare cases, a message would incorrectly appear, stating that it was not possible to update the element.

#### SLAnalytics: Memory leak due to an excessive number of messages being received following an alarm template update [ID 42047]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When an alarm template was updated, in some cases, the alarm focus manager could receive a excessive number of messages, causing SLAnalytics to leak memory.

#### Mobile Visual Overview: Problem with user context [ID 42061]

<!-- MR 10.6.0 [CU0] - FR 10.5.4 -->

Up to now, when no user context was needed in mobile visual overviews, an attempt would be made to reuse server-side cards among users. However, in some cases, this could cause problems, especially when handling popups or embedded visual overviews.

To make sure the user context is always correct and that it get passed correctly to popups, from now on, mobile visual overviews will always use a separate card for each user and create a new card whenever a user requests a new visual overview in a web app.

#### SLAnalytics - Behavioral anomaly detection: Problem when trying to retrieve incorrect INF values from the database [ID 42069]

<!-- MR 10.5.0 [CU1] - FR 10.5.4 -->

In some cases, INF (infinity) values would incorrectly get stored in the database. Attempts to retrieve those values would then result in the *Behavioral anomaly detection* feature not starting up.

#### Mobile Visual Overview: Child shapes would incorrectly remain clickable when hidden [ID 42090]

<!-- MR 10.6.0 [CU0] - FR 10.5.4 -->

When a parent shape with a conditional show/hide setting was hidden, up to now, the clickable regions of its hidden child shapes would incorrectly remain active. In other words, users would incorrectly be able to still click child shapes after they had been hidden.
