---
uid: Installing_OpenSearch_database
---

# Installing an OpenSearch database

## Compatibility

Supported versions:

- OpenSearch 1.X
- OpenSearch 2.X

> [!NOTE]
> OpenSearch is supported on Windows from OpenSearch 2.4 onwards.

## Setting up the OpenSearch cluster

See the [official documentation](https://opensearch.org/docs/latest/) on how to set up your OpenSearch cluster. The configuration is almost identical to that of an Elasticsearch cluster.

> [!IMPORTANT]
>
> - On production systems, the *JVM Heap Space* must be set to a value larger than the default. To configure this setting, see [Important settings](https://opensearch.org/docs/latest/install-and-configure/install-opensearch/index/#important-settings).
> - The `indices.query.bool.max_clause_count` setting should be set to "2147483647" (i.e. the maximum integer value).

> [!NOTE]
> It is also possible to [set up OpenSearch Dashboards](#setting-up-opensearch-dashboards), which is the equivalent of Kibana for Elasticsearch. However, this is optional and not required for DataMiner to function.

### Example configuration

Below you can find an example of how to set up an OpenSearch cluster on premises on a Ubuntu system, in accordance with the [Debian installation guide](https://opensearch.org/docs/latest/install-and-configure/install-opensearch/debian/).

#### Main steps

These are the main steps of the setup:

1. Install OpenSearch as detailed under [Install OpenSearch from an APT repository](https://opensearch.org/docs/latest/install-and-configure/install-opensearch/debian/#install-opensearch-from-an-apt-repository).

1. Follow [Step 2: (Optional) Test OpenSearch](https://opensearch.org/docs/latest/install-and-configure/install-opensearch/debian/#step-2-optional-test-opensearch) from the installation guide. Remember to also **query the plugins endpoint**.

1. Follow [Step 3: Set up OpenSearch in your environment](https://opensearch.org/docs/latest/install-and-configure/install-opensearch/debian/#step-3-set-up-opensearch-in-your-environment) and change the *JVM Heap Space*.

1. Set up a cluster as detailed under [Creating a cluster](https://opensearch.org/docs/latest/tuning-your-cluster/cluster/). Take the sections below into account when you do so.

#### OpenSearch.yml configuration

- For every node in your cluster, configure the *OpenSearch.yml* file as illustrated in the example below (the example uses three nodes):

  ```yml
  # Use a descriptive name for your cluster:
  #
  cluster.name: NameOfYourCluster
  cluster.initial_master_nodes: ["opensearchnode1"]
  #
  # ------------------------------------ Node ------------------------------------
  #
  # Use a descriptive name for the node(node.name can be anything you desire, but we recommend hostname of node):
  #
  # Make the node.name reflect the name of your node
  node.name: opensearchnode1
  #
  # ----------------------------------- Paths ------------------------------------
  #
  # Path to directory where to store the data (separate multiple locations by comma):
  #
  path.data: /var/lib/opensearch
  #
  # Path to log files:
  #
  path.logs: /var/log/opensearch
  # ---------------------------------- Network -----------------------------------
  #
  # Set the bind address to a specific IP (IPv4 or IPv6), best is to use the real-ip of the node:
  #
  network.host: 166.206.186.146
  
  network.publish_host: 166.206.186.146
  #
  # Set a custom port for HTTP:
  #
  http.port: 9200
  #
  # For more information, consult the network module documentation.
  #
  # --------------------------------- Discovery ----------------------------------
  #
  # Pass an initial list of hosts to perform discovery when this node is started:
  # The default list of hosts is ["127.0.0.1", "[::1]"]
  #
  discovery.seed_hosts: ["166.206.186.146","166.206.186.147","166.206.186.148"]
  
  discovery.type: zen
  
  node.max_local_storage_nodes: 3
  indices.query.bool.max_clause_count: 2147483647

  ```

- If you want a node to be a **data node**, add the following configuration in *OpenSearch.yml*:

  ```yml
  node.roles: [ data, ingest ]
  ```

- If you want a node to be the **cluster manager node** (a.k.a. the master node), add the following configuration in *OpenSearch.yml*:

  ```yml
  node.roles: [ cluster_manager ]
  ```

#### User configuration

Generate a new hash for the admin user as detailed under [Configure a user](https://opensearch.org/docs/latest/install-and-configure/install-opensearch/debian/#configure-a-user) in the OpenSearch documentation.

You will need to remove all demo users except the *admin* user and replace the hash for the admin user with the generated hash.

#### TLS configuration

We highly recommend that you configure TLS in order to have a layer of security between your nodes and your DataMiner client. To do so:

1. [Remove the demo certificates](#remove-the-demo-certificates) that came with the default installation.

1. [Generate p12 keystore and truststore p12 files](#generate-p12-keystore-and-truststore-p12-files).

1. [Update the trusted root certificates with rootCA.crt](#update-the-trusted-root-certificates-with-rootcacrt).

1. [Install the rootCA.crt on the DataMiner server](#install-the-rootcacrt-on-the-dataminer-server).

1. [Set up TLS in the OpenSearch.yml file](#set-up-tls-in-the-opensearchyml-file).

1. [Restart OpenSearch](#restart-opensearch).

##### Remove the demo certificates

By default OpenSearch comes with .pem files with demo certificates. For security reasons, it is best to remove these demo certificates.

You can remove the demo certificates located in `\etc\opensearch`:

```bash
cd /etc/opensearch
```

```bash
sudo rm -f *pem
```

##### Generate p12 keystore and truststore p12 files

To configure TLS, instead of using .pem files, we recommend generating p12 keystore and truststore .p12 files. You will then need to reference these in the *OpenSearch.yml* file:

1. Generate the certificates using the [Generate-TLS-Certificates](https://github.com/SkylineCommunications/generate-tls-certificates) script on GitHub.

   This script will generate a .p12 file for every node. The GitHub script will provide you with the keystore and truststore password. A rootCA.crt will also be generated by the GitHub script.

1. Create a *cert* subfolder in the `\etc\opensearch\` folder. Make sure this folder has read and write permissions on every node.

1. Place the correct .p12 file in the `\etc\opensearch\cert\` folder on each corresponding node (making sure the .p12 name matches the node name).

1. Update the OpenSearch.yml file so that *keystore_filepath* and *truststore_filepath* refer to the location of the .p12 files. (For an example, see [Set up TLS in the OpenSearch.yml file](#set-up-tls-in-the-opensearchyml-file).)

1. Add the password to the keystore and truststore password fields in *OpenSearch.yml*. (For an example, see [Set up TLS in the OpenSearch.yml file](#set-up-tls-in-the-opensearchyml-file).)

##### Update the trusted root certificates with rootCA.crt

1. Navigate to the location where the generated *rootCA.crt* file is stored, and copy it using the following command:

   ```bash
   sudo cp rootCA.crt /usr/local/share/ca-certificates/
   ```

1. On every Linux OpenSearch node, update the trusted root certificates:
  
   ```bash
   sudo update-ca-certificates
   ```

1. Verify the *rootCA.crt* using the following command. It should return the status OK.

   ```bash
   openssl verify rootCA.crt
   ```

##### Install the rootCA.crt on the DataMiner server

To build trust between DataMiner and OpenSearch, so that DataMiner can connect to the OpenSearch database, install the rootCA.crt on the DataMiner server:

1. Stop the DataMiner Agent.

1. Double-click the *rootCA.crt* file on the DataMiner server.

1. Use *Local Machine* as *Store Location* when adding the certificate, and place the certificate in *Trusted Root Certification Authorities*.

1. Once the certificate has been imported, add the full HTTPS URL (including the port) in the *DataBase.DBServer* tag of the *DB.xml* file. Using the IP of the node with the *cluster_manager* role is preferable.

   For example:

     ```xml
    <DataBase active="True" type="Elasticsearch" search="true">
    <DBServer>https://166.206.186.146:9200</DBServer>
    <UID>UserNameToConnectToOpenSearch</UID>
    <PWD>PasswordOfTheUserNameToConnectToOpenSearch</PWD>
    <ConnectString></ConnectString>
    <IntegratedSecurity>False</IntegratedSecurity>
    </DataBase>
     ```

   >[!IMPORTANT]
   > The user and password provided should be defined in the `\etc\opensearch\opensearch-security\internal_users.yml` file.

1. Restart the DataMiner Agent.

1. Check in the *SLSearch.txt*, *SLDataGateway.txt*, and *SLDBConnection.txt* log files (in the folder `C:\Skyline DataMiner\Logging`) whether any errors have occurred.

##### Set up TLS in the OpenSearch.yml file

Configure the *OpenSearch.yml* file as illustrated in the example below.

```yml
plugins.security.disabled: false

#Transport layer TLS
plugins.security.ssl.transport.keystore_type: PKCS12
plugins.security.ssl.transport.keystore_filepath: /etc/opensearch/cert/FQDNOfYourNode-node-keystore.p12
plugins.security.ssl.transport.keystore_password: ReplaceMeByGeneratedPasswordByGithubScript
plugins.security.ssl.transport.truststore_type: PKCS12
plugins.security.ssl.transport.truststore_filepath: /etc/opensearch/cert/FQDNOfYourNode-node-keystore.p12
plugins.security.ssl.transport.truststore_password: ReplaceMeByGeneratedPasswordByGithubScript

#REST Layer TLS
plugins.security.ssl.http.enabled: true
plugins.security.ssl.http.keystore_type: PKCS12
plugins.security.ssl.http.keystore_filepath: /etc/opensearch/cert/FQDNOfYourNode-node-keystore.p12
plugins.security.ssl.http.keystore_password: ReplaceMeByGeneratedPasswordByGithubScript
plugins.security.ssl.http.truststore_type: PKCS12
plugins.security.ssl.http.truststore_filepath: /etc/opensearch/cert/FQDNOfYourNode-node-keystore.p12
plugins.security.ssl.http.truststore_password: ReplaceMeByGeneratedPasswordByGithubScript

plugins.security.allow_default_init_securityindex: true
plugins.security.nodes_dn:
  - 'CN=FQDNOpenSearchNode1,OU=NameOfYourCluster,O=OpenSearch,C=BE'
  - 'CN=FQDNOpenSearchNode2,OU=NameOfYourCluster,O=OpenSearch,C=BE'
  - 'CN=FQDNOpenSearchNode3,OU=NameOfYourCluster,O=OpenSearch,C=BE'
plugins.security.audit.type: internal_opensearch
plugins.security.enable_snapshot_restore_privilege: true
plugins.security.check_snapshot_restore_write_privileges: true
plugins.security.restapi.roles_enabled: ["all_access", "security_rest_api_access"]
plugins.security.system_indices.enabled: true
plugins.security.system_indices.indices: [".plugins-ml-model", ".plugins-ml-task", ".opendistro-alerting-config", ".opendistro-alerting-alert*", ".opendistro-anomaly-results*", ".opendistro-anomaly-detector*", ".opendistro-anomaly-checkpoints", ".opendistro-anomaly-detection-state", ".opendistro-reports-*", ".opensearch-notifications-*", ".opensearch-notebooks", ".opensearch-observability", ".opendistro-asynchronous-search-response*", ".replication-metadata-store",".opendistro-anomaly-detection-state", ".opendistro-reports-*", ".opensearch-notifications-*", ".opensearch-notebooks", ".opensearch-observability", ".opendistro-asynchronous-search-response*", ".replication-metadata-store"]
```

##### Restart OpenSearch

1. When you have finished the TLS configuration and [set a different hash for the admin user](#user-configuration), restart OpenSearch. You can use the following command for this:

   ```bash
   sudo systemctl restart opensearch
   ```

1. Check via the command line if data is returned:

   ```curl
   curl https://166.206.186.146:9200 -u admin:yournewpassword --ssl-no-revoke
   ```

   This should return the following:

   ```text
   {
     "name" : "my-elasticsearch-node",
     "cluster_name" : "NameOfYourCluster",
     "cluster_uuid" : "7kj65asfjuu9a1vcf6e345asd65dfg",
     "version" : {
       "distribution" : "opensearch",
       "number" : "2.6.0",
       "build_type" : "deb",
       "build_hash" : "abcdef1234567890",
       "build_date" : "2021-03-18T06:04:15.345676Z",
       "build_snapshot" : false,
       "lucene_version" : "9.5.0",
       "minimum_wire_compatibility_version" : "7.10.0",
       "minimum_index_compatibility_version" : "7.0.0"
     },
     "tagline" : "The OpenSearch Project: https://opensearch.org/"
   }
   ```

#### Setting up OpenSearch Dashboards

Optionally, you can set up OpenSearch Dashboards, which is the equivalent of Kibana for Elasticsearch. To do so, follow the instructions under [Installing OpenSearch Dashboards (Debian)](https://opensearch.org/docs/latest/install-and-configure/install-dashboards/debian/).

You can for example install this on a Ubuntu Server from an APT repository or using .deb-packages. You will then be able to connect to your server using `http(s)://ipaddress:5601`(example: http(s)://166.206.186.146:5601).

To configure TLS, instead of using .pem certificates as recommended in the [OpenSearch documentation](https://opensearch.org/docs/latest/install-and-configure/install-dashboards/tls/), we recommend using .p12 files for trust and keystore. You can generate these using the [Generate-TLS-Certificates](https://github.com/SkylineCommunications/generate-tls-certificates) script maintained by the Skyline security team.

To configure OpenSearch Dashboards to use .p12 files, add the following to `/etc/opensearch-dashboards/opensearch_dashboards.yml`:

```yaml
# OpenSearch Dashboards is served by a back end server. This setting specifies the port to use.
server.port: 5601

# Specifies the address to which the OpenSearch Dashboards server will bind. IP addresses and host names are both valid values.
# The default is 'localhost', which usually means remote machines will not be able to connect.
# To allow connections from remote users, set this parameter to a non-loopback address. Example: 166.206.186.146
server.host: 166.206.186.146

# The URLs of the OpenSearch instances to use for all your queries.
# Can be one ipAddress in case of a single node, but can also be multiple in case of an cluster, below is an example for a cluster consisting of three nodes
opensearch.hosts: ["https://166.206.186.146:9200","https://166.206.186.147:9200","https://166.206.186.148:9200"]

# This setting is for communication between OpenSearch Dashboards and the web browser. Set to true for HTTPS, false for HTTP.
server.ssl.enabled: true

# In below example, we created a cert folder in /etc/opensearch and copied the .p12 files over that were generated with the generate-tls-certificates scripts.
server.ssl.keystore.path: "/etc/opensearch/cert/FQDN-node-keystore.p12"
server.ssl.keystore.password: "KeyStorePasswordComesHere"

# This setting is for communication between OpenSearch and OpenSearch Dashboards. Valid values are full, certificate, or none. We recommend full if you enable TLS, which enables hostname verification. certificate just checks the certificate, not the hostname, and none performs no checks (suitable for HTTP). Default is full.
opensearch.ssl.verificationMode: certificate

# If opensearch.ssl.verificationMode is full or certificate, specify the full path to one or more CA certificates that comprise a trusted chain for your OpenSearch cluster. For example, you might need to include a root CA and an intermediate CA if you used the intermediate CA to issue your admin, client, and node certificates.

# Below is an example of the rootCA.crt certificate that was generated using the generate-tls-certificates from the Skyline public GitHub repository. See also "Update the trusted root certificates with rootCA.crt" topic further up in this help file.
opensearch.ssl.certificateAuthorities: ["/usr/local/share/ca-certificates/rootCA.crt"]


# If your OpenSearch is protected with basic authentication(using the /etc/opensearch/opensearch-security/internal_users.yml), these settings provide the username and password that the OpenSearch Dashboards server uses to connect to OpenSearch.
# More information can be found here: https://opensearch.org/docs/latest/install-and-configure/install-opensearch/debian/#configure-a-user and https://opensearch.org/docs/latest/security/authentication-backends/authc-index/#authentication-flow
opensearch.username: userName
opensearch.password: pwd
```

> [!TIP]
> See also: [OpenSearch Documentation](https://opensearch.org/docs/latest/)

## Connecting your DMS to an OpenSearch cluster

To configure the connection to an OpenSearch database, configure the settings as detailed under [Cassandra database](xref:Configuring_the_database_settings_in_Cube#cassandra-database).

> [!IMPORTANT]
> An OpenSearch database requires a separate Cassandra cluster or Amazon Keyspaces.

## Troubleshooting

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

### SLSearch.txt logging mentions OpenSearch version is not officially supported

If the *SLSearch.txt* log file mentions that the OpenSearch version is not officially supported, you can resolve this by upgrading your DMS to DataMiner 10.3.6 or higher.

However, note that this has no functional impact, as the DMA will run fine even if you have not upgraded yet.
