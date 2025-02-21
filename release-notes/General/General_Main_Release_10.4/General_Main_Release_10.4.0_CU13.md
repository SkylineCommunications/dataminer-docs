---
uid: General_Main_Release_10.4.0_CU13
---

# General Main Release 10.4.0 CU13 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU13](xref:Cube_Main_Release_10.4.0_CU13).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU13](xref:Web_apps_Main_Release_10.4.0_CU13).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Enhanced performance when updating subscriptions and when checking events against the set of active subscriptions [ID 41822]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

Because of a number of enhancements, overall performance has increased when updating subscriptions and when checking events against the set of active subscriptions.

#### Security enhancements [ID 41913]

<!-- 41913: MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

A number of security enhancements have been made.

#### Service & Resource Management: Enhanced handling of locked files when activating or deactivating functions [ID 41978]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

A number of enhancements have been made to the ProtocolFunctionManager with regard to the handling of locked files when activating or deactivating functions.

### Fixes

#### Issue in SLNet could cause errors to be thrown in low-code apps [ID 40978]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.2 -->

Because of an issue in SLNet, after a restart of a DataMiner Agent, "not supported by the current server version" errors could get thrown in all low-code apps.

#### Cassandra: Problem with incorrect gc_grace_seconds values [ID 41939]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

On systems with a Cassandra or Cassandra Cluster database, a number of issues have been fixed with regard to the `gc_grace_seconds` setting:

- The `gc_grace_seconds` values will no longer be updated during a DataMiner restart.
- The `gc_grace_seconds` value for trend data will now by default be set to 0.
- The `gc_grace_seconds` value for logger tables will now by default be set to 4 hours (with TTL) or to 1 day (without TTL).

#### Problem when trying to update the protocol version of an element in error [ID 41962]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When you tried to update the protocol version of an element in error via DataMiner Cube, in some rare cases, a message would incorrectly appear, stating that it was not possible to update the element.

#### SLAnalytics: Memory leak due to an excessive number of messages being received following an alarm template update [ID 42047]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When an alarm template was updated, in some cases, the alarm focus manager could receive a excessive number of messages, causing SLAnalytics to leak memory.

#### DataMiner Taskbar Utility would incorrectly show a pop-up window when made to perform a DataMiner upgrade using the command prompt [ID 42135]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When you made SLTaskbarUtility perform a DataMiner upgrade using the command prompt, up to now, a pop-up window would appear when the DataMiner Agent was not running. As pop-up windows are only expected to appear when running in interactive mode, from now on, pop-up windows will no longer appear when you make SLTaskbarUtility perform actions using the command prompt.

#### Not possible to simultaneously update multiple TTL settings [ID 42139]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

In some cases, it would not be possible to simultaneously update multiple TTL settings.

#### Problem when SLASPConnection failed to connect to NATS [ID 42158]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When the SLASPConnection process failed to connect to NATS, in some cases, run-time errors could be thrown.

A number of enhancements have now been made to avoid run-time errors to be thrown when SLASPConnection process fails to connect to NATS.

#### SLNetClientTest tool: Problem when trying to connect to a DataMiner Agent using external authentication via SAML [ID 42341]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When, in the *SLNetClientTest* tool, you tried to connect to a DataMiner Agent using external authentication via SAML, the following error message would appear:

`Unable to load DLL 'WebView2Loader.dll': The specified module could not be found.`

The *WebView2Loader.dll* file will now been added to the DataMiner upgrade packages.

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
