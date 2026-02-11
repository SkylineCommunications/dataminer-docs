---
uid: General_Feature_Release_10.6.4
---

# General Feature Release 10.6.4 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version:
>
> - Make sure **version 14.40.33816** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation. The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
>   - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
>   - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)
>
> - Make sure all DataMiner Agents in the cluster have been migrated to the BrokerGateway-managed NATS solution. For detailed information, see [Migrating to BrokerGateway](xref:BrokerGateway_Migration).
>
>   See also: [DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43856] [ID 43861] [ID 44035] [ID 44050] [ID 44062]](xref:General_Feature_Release_10.6.1#dataminer-systems-will-now-use-the-brokergateway-managed-nats-solution-by-default-id-43856-id-43861-id-44035-id-44050-id-44062)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.4](xref:Cube_Feature_Release_10.6.4).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.4](xref:Web_apps_Feature_Release_10.6.4).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### New BPA test: Detect unsupported connector versions [ID 44607]

<!-- MR 10.7.0 - FR 10.6.4 -->

From now on, a new BPA test named *Detect unsupported connector versions* will run every day to check for elements that are using connector versions that have been removed from the Catalog.

When a connector version is removed from the Catalog, this means that it is no longer supported by Skyline Communications. Using unsupported connector versions can lead to compatibility issues, lack of support, and potential security vulnerabilities. It is important to regularly check for unsupported connector versions and update them to supported versions to ensure optimal performance and security of the system.

## Changes

### Breaking changes

#### SNMP trap binding values will now only display plain ASCII characters [ID 44527]

<!-- MR 10.7.0 - FR 10.6.4 -->

When the system receives a trap binding value of type OctetString, that value will either be automatically converted into characters (e.g. 0x41 will become "A") or remain in a hexadecimal string format (e.g. when the value contains a byte that is not printable like 0x02, which is an STX control character).

Up to now, hexadecimal values above the ASCII range (i.e. values >= 0x7F) were considered printable characters, and were not converted into a hexadecimal string. This would cause issues with, for example, the Unicode control character 0x8C, which would be displayed as a question mark. In such cases, complex QAction code would then be required to have it converted back into a hexadecimal value.

Also, DataMiner is not aware of whether a binding value actually contains text (e.g. a MAC address consisting of octets) or, if the value contains text, how that text was encoded (e.g. Windows code page 1252, UTF-8, UTF-16, etc.).

From now on, hexadecimal values outside of the ASCII range will be considered non-printable characters, and will remain in hexadecimal string format.

This is a breaking change.

Up to now, text containing characters that were encoded in extended ASCII (i.e. Windows code page 1252) were converted from raw octets into string text. For example, the French word "hélicoptère" would be received correctly. From now on, that same word will be received as hexadecimal string "68e96c69636f7074e87265", and a QAction will need to convert it back into a string using the correct encoding.

### Enhancements

#### Security enhancements [ID 44579]

<!-- 44579: MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

A number of security enhancements have been made.

#### SLDataGateway: StorageTypeNotFoundException will now always mention the StorageType that could not be found [ID 44603]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When SLDataGateway throws a `StorageTypeNotFoundException`, from now on, the message will always mention the StorageType that could not be found.

#### An updated parameter value will no longer be written to the database if it is equal to the old value [ID 44609]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When a user or a QAction updated a parameter value, up to now, the new value would always be written to the database, even when the new value was equal to the old value.

From now on, when the new value is equal to the old value, the value will no longer be written to the database. If any triggers or QActions are configured to be executed following a parameter update, these will still be executed.

Also, write parameters will no longer be saved as this would cause unnecessary load.

#### Enhanced distribution of SNMPv3 traps [ID 44626]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When a DMA receives an SNMPv3 trap that it cannot process (e.g. because the SNMPv3 user is unknown), and trap distribution is enabled, from now on, the trap will be distributed to the other DMAs in the cluster in an attempt to have it processed by one of those other DMAs.

Also, in some cases, traps could be forwarded to the wrong elements because the SNMPv3 USM ID was not validated correctly.

#### SLLogCollector: Separate log file per instance [ID 44668]

<!-- MR 10.7.0 - FR 10.6.4 -->

Up to now, all SLLogCollector logging of all SLLogCollector instances would end up in the following files, stored in the `C:\ProgramData\Skyline\DataMiner\SL_LogCollector\Log` folder:

- `SL_LogCollector_fulllog.log`
- `SL_LogCollector_log.log`

From now on, each SLLogCollector instance will have its own dedicated log file named `log-[creation timestamp].txt`, stored in the `C:\ProgramData\Skyline Communications\SLLogCollector` folder.

Up to 10 log files will be kept on disk, and the log file of the current instance will be added to the SLLogCollector package.

### Fixes

#### Problem with SLNet when receiving a subscription with a large filter that contained wildcards [ID 44512]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When SLNet received a dynamic table subscription with a very large filter that contained wildcards, up to now, it would throw a stack overflow exception and stop working.

From now on, SLNet subscriptions will now be blocked when they contain a filter that exceeds 140,000 characters.

#### SLNetClientTest tool: External authentication would not work when the Microsoft Edge (WebView2) browser engine was installed on a per user basis [ID 44583]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When you connected to a DataMiner Agent, up to now, it would not be possible to use external authentication from a client computer on which the Microsoft Edge (WebView2) browser engine was installed on a per user basis.

> [!NOTE]
> When the Microsoft WebView2 browser engine is installed on a per user basis, it will be automatically updated each time you open Microsoft Edge.

> [!CAUTION]
> Always be extremely careful when using the *SLNetClientTest* tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Problem with SLDataMiner after sending an NT_READ_SAVED_PARAMETER_VALUE call [ID 44597]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU1] - FR 10.6.4 -->

When an NT_READ_SAVED_PARAMETER_VALUE call was sent to retrieve data from an element without a connector while that data was still present in SLDataGateway, up to now, SLDataMiner could stop working.

#### Alarm properties passed along by Correlation or SLAnalytics could get lost when an alarm was created [ID 44669]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

In some cases, alarm properties passed along by Correlation or SLAnalytics could get lost when an alarm was created.

#### API Gateway would incorrectly add multiple routes with the same basePath when multiple registration requests were received for the same route [ID 44676]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When multiple registration requests were received for the same route, in some cases, instead of updating the route, API Gateway would incorrectly add multiple routes with the same basePath. As a result, the proxy would not be able to route the HTTP request.
