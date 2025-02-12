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

## Changes

### Enhancements

#### Enhanced performance when updating subscriptions and when checking events against the set of active subscriptions [ID 41822]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

Because of a number of enhancements, overall performance has increased when updating subscriptions and when checking events against the set of active subscriptions.

#### Security enhancements [ID 42104]

<!-- 42104: MR 10.5.0 [CU1] - FR 10.5.4 -->

A number of security enhancements have been made.

### Fixes

#### SLAnalytics: Memory leak due to an excessive number of messages being received following an alarm template update [ID 42047]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When an alarm template was updated, in some cases, the alarm focus manager could receive a excessive number of messages, causing SLAnalytics to leak memory.

#### Mobile Visual Overview: Problem with user context [ID 42061]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

Up to now, when no user context was needed in mobile visual overviews, an attempt would be made to reuse server-side cards among users. However, in some cases, this could cause problems, especially when handling popups or embedded visual overviews.

To make sure the user context is always correct and that it get passed correctly to popups, from now on, mobile visual overviews will always use a separate card for each user and create a new card whenever a user requests a new visual overview in a web app.

#### SLAnalytics - Behavioral anomaly detection: Problem when trying to retrieve incorrect INF values from the database [ID 42069]

<!-- MR 10.5.0 [CU1] - FR 10.5.4 -->

In some cases, INF (infinity) values would incorrectly get stored in the database. Attempts to retrieve those values would then result in the *Behavioral anomaly detection* feature not starting up.

#### Mobile Visual Overview: Child shapes would incorrectly remain clickable when hidden [ID 42090]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When a parent shape with a conditional show/hide setting was hidden, up to now, the clickable regions of its hidden child shapes would incorrectly remain active. In other words, users would incorrectly be able to still click child shapes after they had been hidden.
