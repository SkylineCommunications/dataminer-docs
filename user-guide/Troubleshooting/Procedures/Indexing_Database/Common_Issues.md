---
uid: ID_Common_Issues
---

# Common issues

Below, we have listed some [common issues related to the configuration of the OpenSearch database](#known-opensearch-related-issues).

Additionally, we recommend checking the [known issues overview](xref:Known_issues) to see if the issue you are experiencing is a known software issue that is already documented. For resolved issues, you will find details on the affected software versions and their resolution status. For unresolved issues, potential mitigation steps or workarounds may be available.

## Known OpenSearch-related issues

Search the OpenSearch logging for exceptions: `/var/log/opensearch/[cluster.name].log`

You can find the cluster name in `/etc/opensearch/opensearch.yml`.

> [!TIP]
> For more information, see [Logs](https://opensearch.org/docs/latest/monitoring-your-cluster/logs/).

### Remote certificate invalid

```text
System.Net.Http.HttpRequestException: An error occurred while sending the request. ---> System.Net.WebException: The underlying connection was closed: Could not establish trust relationship for the SSL/TLS secure channel. ---> System.Security.Authentication.AuthenticationException: The remote certificate is invalid according to the validation procedure.
```

If you encounter the exception above in the SLDBConnection logging, add the rootCA.crt in the  *Trusted Root Certification Authorities* store.

### Multiple DNS names for IP

In case multiple DNS names point to a single IP address, set the option below to false in the *opensearch.yml* file:

```yaml
plugins.security.ssl.transport.resolve_hostname: false
```

> [!TIP]
> See also: [(Advanced) Hostname verification and DNS lookup](https://opensearch.org/docs/1.2/security-plugin/configuration/tls/#advanced-hostname-verification-and-dns-lookup).

### Transport client authentication is no longer support exception in OpenSearch logging

```text
Caused by: org.opensearch.OpenSearchException: Transport client authentication no longer supported.
```

If you encounter the exception above in the OpenSearch logging, make sure *plugins.security.nodes_dn:* matches the certificates subject.

### Cluster not formed

It is possible that a cluster is not formed. In that case, in the `\var\log\opensearch\` folder of the cluster manager and data nodes, in the log file with the name of your cluster, you will see the following exceptions:

- **Cluster manager**:

  ```text
  [2023-06-14T06:26:40,436][WARN ][o.o.c.c.Coordinator      ] [doj-search2] failed to validate incoming join request from node [{DataNodeName}{8Wm1nzzBSuOxGFIPWvXgng}{h3V9SJq2R8e9tMA5pdk6zg}{166.206.186.147}{166.206.186.147:9300}{di}{shard_indexing_pressure_enabled=true}]
  org.opensearch.transport.RemoteTransportException: [DataNodeName][166.206.186.147:9300][internal:cluster/coordination/join/validate]
  Caused by: org.opensearch.cluster.coordination.CoordinationStateRejectedException: join validation on cluster state with a different cluster uuid tNh7sXJeQjuf-RTTfFt7qg than local cluster uuid qVI2q9lMSy-Ot7O9v68d_A, rejecting
          at org.opensearch.cluster.coordination.JoinHelper.lambda$new$4(JoinHelper.java:219) ~[opensearch-2.8.0.jar:2.8.0]
          at org.opensearch.indexmanagement.rollup.interceptor.RollupInterceptor$interceptHandler$1.messageReceived(RollupInterceptor.kt:113) ~[?:?]
          at org.opensearch.performanceanalyzer.transport.PerformanceAnalyzerTransportRequestHandler.messageReceived(PerformanceAnalyzerTransportRequestHandler.java:43) ~[?:?]
          at org.opensearch.transport.RequestHandlerRegistry.processMessageReceived(RequestHandlerRegistry.java:106) ~[opensearch-2.8.0.jar:2.8.0]
          at org.opensearch.transport.InboundHandler$RequestHandler.doRun(InboundHandler.java:453) ~[opensearch-2.8.0.jar:2.8.0]
          at org.opensearch.common.util.concurrent.ThreadContext$ContextPreservingAbstractRunnable.doRun(ThreadContext.java:806) ~[opensearch-2.8.0.jar:2.8.0]
          at org.opensearch.common.util.concurrent.AbstractRunnable.run(AbstractRunnable.java:52) ~[opensearch-2.8.0.jar:2.8.0]
          at java.util.concurrent.ThreadPoolExecutor.runWorker(ThreadPoolExecutor.java:1136) [?:?]
          at java.util.concurrent.ThreadPoolExecutor$Worker.run(ThreadPoolExecutor.java:635) [?:?]
          at java.lang.Thread.run(Thread.java:833) [?:?]
  ```

- **Data nodes**:

  ```text
  [2023-06-14T06:27:59,485][INFO ][o.o.c.c.JoinHelper       ] [DataNodeName] failed to join {ClusterManagerName}{QZ-VFeWyTaavSk20IBx8xA}{HrSHPY-tQNaR7NzeA625UQ}{166.206.186.146}{166.206.186.146:9300}{dimr}{shard_indexing_pressure_enabled=true} with JoinRequest{sourceNode={doj-search3}{8Wm1nzzBSuOxGFIPWvXgng}{h3V9SJq2R8e9tMA5pdk6zg}{166.206.186.147}{166.206.186.47:9300}{di}{shard_indexing_pressure_enabled=true}, minimumTerm=6, optionalJoin=Optional[Join{term=6, lastAcceptedTerm=1, lastAcceptedVersion=19, sourceNode={DataNodeName}{8Wm1nzzBSuOxGFIPWvXgng}{h3V9SJq2R8e9tMA5pdk6zg}{166.206.186.147}{166.206.186.147:9300}{di}{shard_indexing_pressure_enabled=true}, targetNode={ClusterManagerName}{QZ-VFeWyTaavSk20IBx8xA}{HrSHPY-tQNaR7NzeA625UQ}{166.206.186.146}{166.206.186.146:9300}{dimr}{shard_indexing_pressure_enabled=true}}]}
  org.opensearch.transport.RemoteTransportException: [ClusterManagerName][166.206.186.146:9300][internal:cluster/coordination/join]
  Caused by: java.lang.IllegalStateException: failure when sending a validation request to node
          at org.opensearch.cluster.coordination.Coordinator$2.onFailure(Coordinator.java:635) ~[opensearch-2.8.0.jar:2.8.0]
          at org.opensearch.action.ActionListenerResponseHandler.handleException(ActionListenerResponseHandler.java:74) ~[opensearch-2.8.0.jar:2.8.0]
          at org.opensearch.transport.TransportService$ContextRestoreResponseHandler.handleException(TransportService.java:1482) ~[opensearch-2.8.0.jar:2.8.0]
          at org.opensearch.transport.InboundHandler.lambda$handleException$3(InboundHandler.java:420) ~[opensearch-2.8.0.jar:2.8.0]
          at org.opensearch.common.util.concurrent.ThreadContext$ContextPreservingRunnable.run(ThreadContext.java:747) ~[opensearch-2.8.0.jar:2.8.0]
          at java.util.concurrent.ThreadPoolExecutor.runWorker(ThreadPoolExecutor.java:1136) ~[?:?]
          at java.util.concurrent.ThreadPoolExecutor$Worker.run(ThreadPoolExecutor.java:635) ~[?:?]
          at java.lang.Thread.run(Thread.java:833) [?:?]
  Caused by: org.opensearch.transport.RemoteTransportException: [DataNodeName][166.206.186.147:9300][internal:cluster/coordination/join/validate]
  Caused by: org.opensearch.cluster.coordination.CoordinationStateRejectedException: join validation on cluster state with a different cluster uuid tNh7sXJeQjuf-RTTfFt7qg than local cluster uuid qVI2q9lMSy-Ot7O9v68d_A, rejecting
          at org.opensearch.cluster.coordination.JoinHelper.lambda$new$4(JoinHelper.java:219) ~[opensearch-2.8.0.jar:2.8.0]
          at org.opensearch.indexmanagement.rollup.interceptor.RollupInterceptor$interceptHandler$1.messageReceived(RollupInterceptor.kt:113) ~[?:?]
          at org.opensearch.performanceanalyzer.transport.PerformanceAnalyzerTransportRequestHandler.messageReceived(PerformanceAnalyzerTransportRequestHandler.java:43) ~[?:?]
          at org.opensearch.transport.RequestHandlerRegistry.processMessageReceived(RequestHandlerRegistry.java:106) ~[opensearch-2.8.0.jar:2.8.0]
          at org.opensearch.transport.InboundHandler$RequestHandler.doRun(InboundHandler.java:453) ~[opensearch-2.8.0.jar:2.8.0]
          at org.opensearch.common.util.concurrent.ThreadContext$ContextPreservingAbstractRunnable.doRun(ThreadContext.java:806) ~[opensearch-2.8.0.jar:2.8.0]
          at org.opensearch.common.util.concurrent.AbstractRunnable.run(AbstractRunnable.java:52) ~[opensearch-2.8.0.jar:2.8.0]
          at java.util.concurrent.ThreadPoolExecutor.runWorker(ThreadPoolExecutor.java:1136) ~[?:?]
          at java.util.concurrent.ThreadPoolExecutor$Worker.run(ThreadPoolExecutor.java:635) ~[?:?]
          at java.lang.Thread.run(Thread.java:833) ~[?:?]
  ```

To fix this issue:

1. Stop OpenSearch on the cluster manager and data nodes.

1. Check the *cluster.initial_master_nodes* and *discovery.seed_hosts* on all nodes for any differences.

1. Go to the data folder specified in the *opensearch.yml* file and delete the folder called *nodes* along with every file in it by using the following command:

   ```bash
   sudo rm -rf nodes
   ```

1. Restart OpenSearch on the cluster manager first and then on the data nodes.

> [!IMPORTANT]
> Deleting the nodes folder will result in loss of data. You should only do so with a new installation of OpenSearch.

### OpenSearch logging mentions unknown setting [node.voting only]

When [node.voting only] was configured for your tiebreaker in *opensearch.yml*, this will not work because this is not supported by OpenSearch. When OpenSearch was forked from Elasticsearch, this functionality was blocked.

If you use tiebreakers, configure them to use the master-eligible role in *opensearch.yml*.

### SLSearch.txt logging mentions OpenSearch version is not officially supported

If the *SLSearch.txt* log file mentions that the OpenSearch version is not officially supported, you can resolve this by upgrading your DMS to DataMiner 10.3.6 or higher.

However, note that this has no functional impact, as the DMA will run fine even if you have not upgraded yet.

### OpenSearch service going into timeout

It can occur that you get an OpenSearch service timeout when executing one of the following commands:

```bash
sudo systemctl start opensearch
```

```bash
sudo systemctl restart opensearch
```

For example:

```txt
opensearch.service: start operation timed out. Terminating.
opensearch.service: Failed with result 'timeout'.
Failed to start OpenSearch.
opensearch.service: Consumed 57.702s CPU time.
```

To resolve this, you may need to increase the start timeout for systemd (see [systemd](https://systemd.io/)):

1. Open the configuration using Nano editor.

   ```bash
   sudo nano /usr/lib/systemd/system/opensearch.service
   ```

1. Increase the value of *TimeoutStartSec* to a higher value, for example 300.

   ```txt
   TimeoutStartSec=300
   ```

1. Enable the OpenSearch service again:

   ```bash
   sudo /bin/systemctl enable opensearch.service
   ```

1. Start the OpenSearch service again:

   ```bash
   sudo systemctl start opensearch
   ```

1. Execute the following command to verify that OpenSearch keeps running correctly:

   ```bash
   sudo systemctl status opensearch
   ```

### Error when executing securitadmin.sh

```text
ERR: An unexpected SSLHandshakeException occurred: Received fatal alert: certificate_unknown
```

When OpenSearch shows this generic error, check the OpenSearch logging (refer to the top of this page for details) to see if you can find a root cause.

If you used your own certificates, make sure that your admin certificate is signed by the same rootCA as your node certificates. You can validate this with following command:

```bash
openssl verify -verbose -CAfile [Path To Your RootCA] [Path To Your Admin Certificate]
```

## Elasticsearch/OpenSearch does not start up after an upgrade or disk cleanup (on Windows)

If Elasticsearch or OpenSearch are installed on a Windows system, after an operating system upgrade (e.g. upgrade from Windows Server 2019 to 2022), it can occur that the Elasticsearch or OpenSearch service no longer starts up. This same problem can also occur after automated disk cleanup.

This issue occurs because the Elasticsearch and OpenSearch service by default depend on a **temporary folder** that typically gets cleaned up during an upgrade or disk cleanup, i.e. the *appdata/local/temp* folder of the user who installed the service.

To solve this issue, manually **recreate this folder** after the OS upgrade or disk cleanup.
