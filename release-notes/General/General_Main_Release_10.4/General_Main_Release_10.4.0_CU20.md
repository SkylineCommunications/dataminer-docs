---
uid: General_Main_Release_10.4.0_CU20
---

# General Main Release 10.4.0 CU20

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU20](xref:Cube_Main_Release_10.4.0_CU20).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU20](xref:Web_apps_Main_Release_10.4.0_CU20).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Element replication: Replication buffer will now be read in chunks [ID 43281]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

Up to now, when the connection to a replicated element was restored, the entire replication buffer would be read into memory at once. From now on, the replication buffer will be read in chunks.

#### DataMiner Object Models: Enhanced performance when filtering on FieldValues in memory via FilterElements [ID 43568]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When filtering on FieldValues in memory via FilterElements, the DomInstanceExposers.FieldValues exposer will no longer generate a JsonSerializableDictionary. Instead, it will now use a standard dictionary. This will enhance overall in-memory filtering performance.

#### STaaS: Enhanced exception logging [ID 43626]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

A number of enhancements have been made with regard to the logging of exception messages on STaaS systems.

#### CPE: Enhanced performance [ID 43654]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

Because of a number of enhancements in the aggregation module, overall performance has increased.

#### DataMiner upgrade: All but the Web.config file will be removed from the 'C:\\Skyline DataMiner\\Webpages\\API' folder when downgrading to an older version [ID 43687]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

From now on, when a DataMiner Agent is downgraded to an older version, the entire `C:\Skyline DataMiner\Webpages\API` folder will be cleared. Only the `Web.config` file will be kept.

### Fixes

#### Problem when loading initial parameter data for remote elements [ID 43339] [ID 43552]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

In some cases, client applications like DataMiner Cube would fail to load initial parameter data for remote elements.

#### Protocols: Problems with pollingRate attribute [ID 43418]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

A number of issues have been fixed with regard to the `pollingRate` attribute, which allows you to slow down polling for specific SNMP columns in a table by specifying a minimum interval (in milliseconds) between polling.

- Using `pollingRate` would not work when the element was using the production version of the protocol or when the `partialSNMP` option was specified in the table options.

- Up to now, the decision to poll a column was taken by SLSNMPManager, which relied on the *Polling.xml* file that was stored alongside the *Protocol.xml* file. From now on, SLProtocol will determine which columns will be polled independently of the *Polling.xml* file.

> [!NOTE]
> Stream Viewer will now indicate more clearly which columns were polled. When some columns were polled while others were skipped, the message `[PollingRate polled column PIDs xxx,yyy]` will be shown. Also, when the timer was faster than the polling rate, the message `No column reached the PollingRate interval.` will be shown, and no Get operation will be executed.

#### Alarm indicating a runtime error would incorrectly say "-1 pending" when all threads cleared simultaneously [ID 43508]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When multiple threads of the same process have a runtime error, the associated alarm will say "+X pending", indicating the number of threads that are stuck.

Up to now, when all threads cleared simultaneously, in some cases, the alarm would incorrectly say "-1 pending".

#### Cassandra Cluster Migrator tool: Problem when reverse lookup of IP addresses returned hostnames other than those configured in the SSL certificate [ID 43520]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When you tried to migrate a Cassandra Cluster with SSL/TLS enabled, up to now, the Cassandra Cluster Migration tool would not be able to initialize when a reverse lookup of IP addresses returned hostnames other than those configured in the SSL certificate.

This issue can be prevented by manually checking if the IP address is one of the SANs (Subject Alternative Names) of the SSL certificate.

#### SLNet could return incorrect data to the client application when processing a cell subscription filter [ID 43600]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When processing a cell subscription filter, in some cases, SLNet could return incorrect data to the client application.

#### Restarting a replicated element could cause SLProtocol to leak memory [ID 43613]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When you restarted a replicated element that was in the process of starting up, in some cases, the resources in memory would incorrectly not get cleaned up, causing SLProtocol to leak memory.

#### Production version of DVE child elements would incorrectly be reset when you uploaded an updated copy of the DVE protocol version [ID 43640]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When you uploaded an updated copy of a DVE protocol version that had already been uploaded before, up to now, the production version of the DVE child elements that were using that protocol would incorrectly be reset.

#### STaaS: Data missing from heatmaps and alarm state pie charts [ID 43689]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When, in a client application connected to a system using STaaS, you viewed a heatmap or an alarm state pie chart, in some cases, an incorrect time zone conversion would cause those charts to not include all available data.

#### Problem when importing a DELT package containing average trend data into a Cassandra Cluster or STaaS database [ID 43768]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

Up to now, after you had imported a DELT package containing average trend data into a Cassandra Cluster or STaaS database, that database would contain invalid trend data.

#### SLWatchdog would incorrectly remove the threads table entries of all SLProtocol processes when one SLProtocol process disappeared [ID 43780]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 [CU0] -->

Since DataMiner version 10.5.0/10.4.12, the DataMiner Agent is no longer restarted when an SLProtocol process disappears. Instead, a new SLProtocol process is started and all elements that were hosted by the process that disappeared are now be hosted by the newly created process.

However, up to now, when an SLProtocol process disappeared, SLWatchdog would remove all entries in its threads table that matched the name of the process (e.g. "SLProtocol"). This would result in all entries of the other SLProtocol processes to be removed as well.

From now on, SLWatchdog will only remove the threads table entries that match the name as well as the ID of the process.
