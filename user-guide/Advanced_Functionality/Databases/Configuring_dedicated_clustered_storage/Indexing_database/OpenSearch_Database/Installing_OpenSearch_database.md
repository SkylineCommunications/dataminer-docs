---
uid: Installing_OpenSearch_database
---

# Installing an OpenSearch database

## Compatibility

Supported versions:

- OpenSearch 1.X
- OpenSearch 2.X

> [!NOTE]
> OpenSearch is only supported on Linux.

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

1. Follow [Step 2:(Optional) Test OpenSearch](https://opensearch.org/docs/latest/install-and-configure/install-opensearch/debian/#step-2-optional-test-opensearch) from the installation guide. Remember to also **query the plugins endpoint**.

1. Follow [Step 3: Set up OpenSearch in your environment](https://opensearch.org/docs/latest/install-and-configure/install-opensearch/debian/#step-3-set-up-opensearch-in-your-environment) and change the *JVM Heap Space*.

1. Set up a cluster as detailed under [Creating a cluster](https://opensearch.org/docs/latest/tuning-your-cluster/cluster/). Take the sections below into account when you do so.

#### OpenSearch.yml configuration

- For every node in your cluster, configure the *OpenSearch.yml* file as illustrated below (the example uses three nodes):

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
  ```

- If you want a node to be a **data node**, add the following configuration in *OpenSearch.yml*:

  ```yml
  node.roles: [ data, ingest ]
  ```

- If you want a node to be the **cluster manager node** (a.k.a. the master node), add the following configuration in *OpenSearch.yml*:

  ```yml
  node.roles: [ cluster_manager ]
  ```

##### Remove the demo certificates

Remove the demo certificates located in /etc/opensearch:

```bash
cd /etc/opensearch
```

```bash
sudo rm -f *pem
```

##### Configure users

Generate a new hash for the admin user using [Configure a user](https://opensearch.org/docs/latest/install-and-configure/install-opensearch/debian/#configure-a-user) section in the OpenSearch help. As the help indicated, remove all demo users except the *admin* user an replace the hash for admin with the generated hash.

#### TLS configuration

We highly recommend to use TLS, to have a layer of security between your nodes and your DataMiner client.

##### Generate p12 keystore and truststore p12 files and reference them in the OpenSearch.yml file

To configure TLS, instead of using .pem files, we recommend generating p12 keystore and truststore .p12 files.

1. Generate the certificates using the [Generate-TLS-Certificates](https://github.com/SkylineCommunications/generate-tls-certificates) script on GitHub. This script will generate a .p12 file for every node. The GitHub script will provide you with the keystore and truststore password. A rootCA.crt will also be generated by the GitHub script.
1. Create a folder *cert* in /etc/opensearch/, this folder needs read and write permissions on every node.
1. Place the corresponding .p12 file on each corresponding node(so name .p12 should match your node-name) in the /etc/opensearch/cert/ folder.
1. Reference to the location of the .p12 files with the keystore_filepath and truststore_filepath in the OpenSearch.yml file. See also the example in [Set up TLS in the OpenSearch.yml file](#set-up-tls-in-the-opensearchyml-file).
1. In OpenSearch.yml add the password to the keystore and truststore password fields, see [Set up TLS in the OpenSearch.yml file](#set-up-tls-in-the-opensearchyml-file).

##### Update the trusted root certificates with rootCA.crt

Navigate to the location where your rootCA.crt file that was generated, is stored and copy it using the following commands:

```bash
sudo cp rootCA.crt /usr/local/share/ca-certificates/
```

Next update the trusted root certificates:

```bash
sudo update-ca-certificates
```

You can verify the rootCA.crt using the following command, it should return the status OK.

```bash
openssl verify rootCA.crt
```

##### Install the rootCA.crt on the DataMiner server to build trust between DataMiner and OpenSearch

To connect the OpenSearch database to DataMiner, you can also install the rootCA.crt on Windows by double-clicking it.

1. On every Linux OpenSearch node follow: [Update the trusted root certificates with rootCA.crt](#update-the-trusted-root-certificates-with-rootcacrt).
1. Stop the DataMiner agent on the Windows Server.
1. Double-click the rootCA.crt file on the Windows Server.
1. Use *Local Machine* as *Store Location* when adding the certificate, and place the certificate in *Trusted Root Certification Authorities*.
1. Once the certificate has been imported, add the full https:// URL (including the port) in the <DBServer> tag of the <DataBase> tag of the DataMiner DB.xml file. Preferred is to use the IP of the node with the *cluster_manager* role.

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
   > The user and password provided should be defined in the /etc/opensearch/opensearch-security/internal_users.yml file.

1. Restart your DataMiner. Verify in the logfiles of SLSearch.txt, SLDataGateway.txt, SLDBConnection.txt in Skyline DataMiner/Logging folder if no errors occurred.

##### Set up TLS in the OpenSearch.yml file

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
node.max_local_storage_nodes: 3
indices.query.bool.max_clause_count: 2147483647
```

##### Restart OpenSearch

When you have finished the TLS configuration and set a different hash for the admin user, restart OpenSearch:

```bash
sudo systemctl restart opensearch
```

Check via the command line if data is returned:

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

To configure TLS, instead of using .pem certificates as recommended in the [OpenSearch documentation](https://opensearch.org/docs/latest/install-and-configure/install-dashboards/tls/), we recommend using .p12 files for trust and keystore. You can generate these using the [Generate TLS Certificates](https://github.com/SkylineCommunications/generate-tls-certificates) script maintained by the Skyline security team.

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
> See also: [OpenSearch Documenation](https://opensearch.org/docs/latest/)

## Connecting your DMS to an OpenSearch cluster

To configure the connection to an OpenSearch database, configure the settings as detailed in [Cassandra database](xref:Configuring_the_database_settings_in_Cube#cassandra-database).

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

### SLSearch.txt logging mentions OpenSearch version is not officially supported

If the SLSearch.txt log file mentions that the OpenSearch version is not officially supported, upgrade your DMS to DataMiner 10.3.6 or higher.
