---
uid: General_Main_Release_10.5.0_CU8
---

# General Main Release 10.5.0 CU8 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU8](xref:Cube_Main_Release_10.5.0_CU8).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU8](xref:Web_apps_Main_Release_10.5.0_CU8).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### STaaS: Enhanced exception logging [ID 43626]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

A number of enhancements have been made with regard to the logging of exception messages on STaaS systems.

#### DxMs upgraded [ID 43642]

<!-- RN 43642: MR 10.5.0 [CU8] - FR 10.5.11 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner SupportAssistant 1.7.7

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

### Fixes

#### Protocols: Problems with pollingRate attribute [ID 43418]

<!-- MR 10.5.0 [CU8] - FR 10.5.11 -->

A number of issues have been fixed with regard to the `pollingRate` attribute, which allows you to slow down polling for specific SNMP columns in a table by specifying a minimum interval (in milliseconds) between polling.

- Using `pollingRate` would not work when the element was using the production version of the protocol or when the `partialSNMP` option was specified in the table options.

- Up to now, the decision to poll a column was taken by SLSNMPManager, which relied on the *Polling.xml* file that was stored alongside the *Protocol.xml* file. From now on, SLProtocol will determine which columns will be polled independently of the *Polling.xml* file.

> [!NOTE]
> The StreamViewer will now indicate more clearly which columns were polled. When some columns were polled while others were skipped, the message `[PollingRate polled column PIDs xxx,yyy]` will be shown. Also, when the timer was faster than the polling rate, the message `No column reached the PollingRate interval.` will be shown, and no Get operation will be executed.

#### Problem when trying to update the log levels of an element that was not hosted on the local DataMiner Agent [ID 43582]

<!-- MR 10.5.0 [CU8] - FR 10.5.11 -->

When you tried to update the log levels of an element that was not hosted on the local DataMiner Agent, up to now, the update request would incorrectly be ignored and would not be forwarded to the DataMiner Agent hosting the element.

From now on, the update request will correctly be forwarded to the DataMiner Agent hosting the element where it will be processed accordingly.

#### Visual Overview in web apps: Problem when reading the load balancing configuration [ID 43660]

<!-- MR 10.4.0 [CU20]/10.5.0 [CU8] - FR 10.5.11 -->

In some cases, it would not be possible to read the load balancing configuration for visual overviews in web apps. As a result, the visual overview module would not be able to start up when load balancing was enabled.
