---
uid: ID_Diagnostic_Procedures
---

# Diagnostic procedures

## Troubleshooting

In case of a problem with the indexing database, these are the steps to localize the problem.

### Confirm that the indexing database is up and running

Cluster health status can be requested via the API call `GET /_cluster/health`. This query can be sent to the database node via a query tool, or by opening the URL <http://node_address:9200/_cluster/health?pretty> (or `https:` instead of `http:` if TLS is enabled).

An example output is shown below:

![example output](~/user-guide/images/Example_Output.png)

The most important parameters in this message are:

- `status`: the expected status is `green`. `yellow` means the cluster is impacted but all data is still available by means of redundancy mechanisms. `red` means the cluster is impacted and some data cannot be retrieved.

- `number_of_nodes`: if the user knows how many nodes are normally in the cluster, this parameter allows to check if any nodes are offline.

- `unassigned_shards`: The expected value is 0. The count of shards higher than 0 indicates that some data is partially unavailable.

If the health status is not retrieved, it means that the database node at the given address is not running.

Further steps:

- If the health status is `green` and all nodes are present, see [Check if DataMiner can connect to the database](#check-if-dataminer-can-connect-to-the-indexing-database).

- If all nodes are present, but some shards are unassigned, see [Shard allocation and disk usage](#shard-allocation-and-disk-usage).

- If some nodes are missing, check [network connectivity to the missing nodes](#connectivity-checks).

- If the network connection is in order, but the database node does not respond, [collect database logs and report issue to TechSupport](xref:ID_Still_Experiencing_Issues).

### Check if DataMiner can connect to the indexing database

#### Watchdog reports

Watchdog reports are generated every hour and contain the most important agent status parameters. The most recent report can be found in the folder `C:\Skyline DataMiner\logging\WatchDog\Reports\Pending Reports` with the naming format `[timestamp]_Report_[extra_timestamps].xml`. Information on the indexing database status is logged in the element `<Search>…</Search>` as shown below:

`<Search timespan="188" unit="ms" state="active" version="2.18.0" type="elastic" health="GREEN">`

If the state and the health information is missing in the report, or the Search tag is missing completely, it means that DataMiner is unable to connect to the indexing database.

#### Log files

The dedicated log file for the indexing database communication is `C:\Skyline DataMiner\logging\SLSearch.txt`. Critical errors, such as failure to connect to the database, are logged with the tag `|ERR|`. See example below:

![Log files example](~/user-guide/images/Log_Files.png)

Usually, the error message provides sufficient information to understand the cause of connection loss. Common examples are:

- Incorrect credentials.

- Mismatching communication protocol: HTTPS enabled on one side but not on the other.

- Invalid TLS certificate.

- Index is in read-only mode (due to insufficient disk space).

- Network failure.

Note that many of these common cases have root causes outside DataMiner and should be resolved by the network or database administrator.

## Shard allocation and disk usage

Simply explained, database tables (indices) are subdivided into shards that are then evenly distributed in the cluster. Presence of unallocated shards in the cluster stats means that some data is not available or cannot be written to the cluster.

More information on the current shard allocation state can be retrieved by running the API call `GET /_cluster/allocation/explain` or by opening the URL <http(s)://node_address:9200/_cluster/allocation/explain?pretty>. Below are some common cases.

### One or more nodes are offline

The indexing Cluster will try to reallocate shards to other nodes. If there are not enough nodes left in the cluster, the cluster state will change to:

- Yellow: all primary shards are available, but some replica shards cannot be allocated. From the user’s perspective, all data is still available by means of the replication mechanism.

- Red: some primary shards are not available, i.e. at least part of the data is completely unavailable.

To resolve: recover the offline nodes.

### Insufficient disk space

When available disk space on a node goes below a certain threshold (the setting `cluster.routing.allocation.disk.watermark.flood_stage`), Cluster Manager blocks writing to any index that has shards on the node that is running out of disk space. This state causes cluster health to change to `red`.

To resolve: Increase disk space on the affected node, or free up disk space by deleting some indices. Once there is sufficient disk space, it may be required to send the API call `PUT /my_index/_settings { "index.blocks.read_only_allow_delete": null }` to revert the read-only mode.

### Replication factor higher than the number of nodes

The default replication factor for new indices is 3 (primary + 2 replica shards). In a single-node cluster, no other node will be found to store replica shards, therefore, cluster status will be `yellow` unless the replication factor is corrected for every index.

To resolve: set replication factors to correspond with the cluster composition.

## Connectivity checks

Ensuring the health of your indexing database network is vital for maintaining optimal performance and reliability. To achieve this, aim to maintain a latency of less than 50ms. If you suspect an issue with the indexing database, such as an alarm in DataMiner's alarm console indicating that the database is unavailable, follow the procedure below to identify the problem.

1. Test if the indexing DB is available and listening on the expected port.

   > [!NOTE]
   > 9200 is the default client port for OpenSearch/Elasticsearch. If a non-standard port is configured, use the respective port number to check connectivity.

   - From a Windows server: run the command in PowerShell: `tnc -p 9200 [node_address]`

   - From a Linux server: run the command in terminal: `nmap -p 9200 [node_address]`

   If the test succeeds, the indexing DB is listening on the specified port. Skip to Step 4.

   If the test fails, there may be an issue with communication or the database itself. Proceed to the next step.

1. Use the ping command to test connectivity between the DMS server and the indexing DB server.

   - If the ping fails: there is no network connectivity, or the DB server is not running. Make sure the server is up and running and review your network configuration with the assistance of your IT team.

   - If the ping succeeds: network connectivity is intact, but communication on the expected port may still be blocked. Proceed to Step 3.

1. Collaborate with your IT team to review the firewall settings on the indexing database server. Verify that no rules are blocking communication on the required port (e.g., 9200 for OpenSearch/Elasticsearch).

   1. Use the following commands to assess the firewall state for Ubuntu TLS:

      - `sudo ufw status`: Displays whether the firewall is active and lists current rules.

      - `sudo ufw status | grep PORT_NUMBER`: Confirms if the port is listed as `ALLOW`, indicating it is open.

      > [!NOTE]
      > Red Hat-based operating systems use `firewalld` instead of `ufw`. It is managed using the command `firewall-cmd`.

   1. If rules are blocking traffic, update the firewall configuration to allow the required communication. You can use the following command to open a specified port for a particular IP address: `sudo ufw allow from SPECIFIC_IP to any port PORT_NUMBER`

   1. If the firewall is not blocking communication, proceed to the next step.

1. Validate SSL/TLS Certificates (if encryption is enabled)

   If SSL/TLS encryption is used for secure communication, verify that the SSL/TLS certificates are valid and trusted:

   - Via browser: open the URL `https://node_address:9200/` . You should get a warning if the certificate of the database node is not valid.

   - In DataMiner logging: Invalid or untrusted certificates will cause errors `System.Security.Authentication.AuthenticationException`: The remote certificate is invalid according to the validation procedure” in *SLSearch.txt* and *SLDBConnection.txt*.

   > [!TIP]
   > You can find more information regarding SSL/TLS Certification in the following links:
   >
   > - [Securing the Elasticsearch database](xref:Security_Elasticsearch)
   > - [Securing the OpenSearch database](xref:Security_OpenSearch#tls-encryption)
