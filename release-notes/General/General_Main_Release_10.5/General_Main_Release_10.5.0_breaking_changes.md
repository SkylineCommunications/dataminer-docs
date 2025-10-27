---
uid: General_Main_Release_10.5.0_breaking_changes
---

# General Main Release 10.5.0 – Breaking changes

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

#### Parameter latch states will now be reset after every DataMiner restart [ID 39495]

<!-- MR 10.5.0 - FR 10.4.9 -->

In order to increase overall performance when starting up elements, parameter latch states will no longer be persistent by default. They will be reset after every DataMiner restart.

If you want to have persistent parameter latch states, do the following:

1. Open the *MaintenanceSettings.xml* file.

1. In the `AlarmSettings` section, add the `PersistParameterLatchState` option, and set it to true.

   ```xml
   <AlarmSettings>
      ...
      <PersistParameterLatchState>true</PersistParameterLatchState>
      ...
   </AlarmSettings>
   ```

1. Restart the DataMiner Agent.

> [!IMPORTANT]
>
> - From now on, by default (or when the `PersistParameterLatchState` option is set to false in *MaintenanceSettings.xml*), parameter latch states will no longer be written to or fetched from the database. This means that, after every DataMiner restart, all parameter latch states will be reset.
> - Element, service and view latch states will remain persistent as before.

#### GQI - 'Get alarms' data source: Updated 'Alarm ID' and 'Root Alarm ID' columns [ID 40372]

<!-- MR 10.5.0 - FR 10.4.11 -->

In the *Get alarms* data source, the following columns have been updated:

| Column | Former contents | New contents |
|--------|-----------------|--------------|
| Alarm ID      | HostingDMAID/AlarmID     | DMAID/EID/RootAlarmID/AlarmID |
| Root Alarm ID | HostingDMAID/RootAlarmID | DMAID/EID/RootAlarmID         |

> [!NOTE]
> "DMAID" refers to the DataMiner ID of the DataMiner Agent where the element was originally created. "HostingDMAID" refers to the DataMiner ID of the DataMiner Agent currently hosting the element and managing its alarms. Most of the time, these two values will be the same, but they may differ, for example, when an element is exported from one Agent and imported onto another Agent. In this case, the element retains the original DMAID, but the HostingDMAID will reflect the new Agent's ID.

#### Automation: SubScriptOptions.SkipStartedInfoEvent will now by default be set to true [ID 40867]

<!-- MR 10.5.0 - FR 10.4.12 -->

If you have created an Automation script that launches subscripts, you can use the `SkipStartedInfoEvent` option to specify whether "Script started" information events should be generated for the subscripts or not.

Up to now, this `SkipStartedInfoEvent` option would by default be set to false. From now on, it will by default be set to true.

#### Elements: SSL/TLS certificates will now be validated by default for all newly created HTTP elements [ID 40877] [ID 41285]

<!-- MR 10.5.0 - FR 10.4.12 -->

In order to enhance secure connector communication, SSL/TLS certificates will now be validated by default for all newly created HTTP elements.

If you want to disable certificate validation for an element created after a 10.5.0/10.4.12 upgrade or enable certificate validation for a element created before a 10.5.0/10.4.12 upgrade, in DataMiner Cube, right-click the element in the Surveyor, select *Edit*, and either disable or enable the *Skip SSL/TLS certificate verification (insecure)* option.

When certificate validation is skipped, in case an HTTP connector polls an HTTPS endpoint:

- DataMiner will ignore invalid certificates in the following cases:

  - When the server certificate is expired.
  - When the server certificate is revoked.
  - When the common name of the server certificate does not match the server name to which DataMiner is sending the request.
  - When the certificate is issued by a Certificate Authority that is not trusted by the DataMiner Agent.
  - When the server certificate is signed by a weak signature.

- DataMiner will block communication in the following cases:

  - When the server is offering a non-server certificate.

> [!NOTE]
>
> - If you want the SSL/TLS certification validation to be skipped for all elements sharing the same *protocol.xml* file, you can set the `SkipCertificateVerification` element to true in the `PortSettings` element of the *protocol.xml* file.
> - If you want the SSL/TLS certification validation to be enabled when using multithreaded HTTP communication, set `requestSettings[6]` to false when building the HTTP request in a QAction. By default, this option is set to true, meaning that SSL/TLS certification validation will be skipped. For more information, see [Setting up multithreaded HTTP communication in a QAction](xref:AdvancedMultiThreadedTimersHttp).
> - For backward compatibility, the SSL/TLS certification validation will be skipped by default for all elements that were created before a 10.5.0/10.4.12 upgrade.

#### DataMiner Object Models: An exception will now be thrown when an issue occurs for any of the DomInstances that are created, updated, or deleted in bulk [ID 41546]

<!-- MR 10.5.0 - FR 10.5.2 -->

From now on, if an issue occurs for any of the `DomInstances` that are getting created, updated, or deleted in bulk (e.g. validation), a `BulkCrudFailedException<DomInstanceId>` will be thrown. The `Result` property in the exception can be used to check for which `DomInstances` the call succeeded or failed. For information on how to implement this flow, refer to the [Checking issues example](xref:DOM_BulkProcessing_Examples#checking-issues).

As an alternative, the `TryCreateOrUpdate` or `TryDelete` methods can be used. When the operation fails for one of the `DomInstances`, those calls will return false. The `result` output parameter will contain:

- The list of successfully processed items, as is the case for `CreateOrUpdate` and `Delete`.

- A list of `DomInstance` IDs that failed to be created, updated, or deleted.

- The trace data per `DomInstance` ID.

For each of these methods, the trace data of that call is still available and will contain the trace data for all processed `DomInstances`.

> [!IMPORTANT]
> In DataMiner versions prior to DataMiner Feature Release 10.5.0/10.5.2, when any validation issue occurs, no exception is thrown (even when `ThrowExceptionsOnErrorData` is true) when calling the `CreateOrUpdate` or `Delete` methods. Instead, the result of the call should be used to check for which `DomInstances` the call succeeded or failed.

> [!NOTE]
> When creating, updating or deleting a single `DomInstance`, you can now also use the `TryCreate`, `TryUpdate` and `TryDelete` methods as an alternative in order to avoid having to check for exceptions. These methods are also available for other objects that make use of the CRUD helper component.
