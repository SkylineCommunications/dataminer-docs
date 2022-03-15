---
uid: Database_security
---

# Securing the DataMiner databases

## Cassandra general database (default)

### Authentication

By default, DataMiner installs Cassandra with the PasswordAuthenticator enabled. Cassandra comes installed with a default *cassandra* user. When DataMiner installs Cassandra (e.g. during migration or installation), an extra superuser named *root* is created.

#### Configuring strong passwords for the default users

We highly recommend that you configure more secure passwords for the default user. Preferably, these passwords should be randomly generated and stored in a password vault.

You can do so by executing the following queries (using DevCenter, the DataMiner Cube Query Executor, or your preferred query tool):

`ALTER USER cassandra WITH PASSWORD '<NEW PASSWORD>'`

`ALTER USER root WITH PASSWORD '<NEW PASSWORD>'`

#### Creating a new superuser and removing the default user

We also recommend that you create a new superuser and disable the default *cassandra* user. To do so:

1. Log in with the *cassandra* user and execute the following query:

   `CREATE ROLE <new_super_user> WITH PASSWORD = "<STRONG PASSWORD>" AND SUPERUSER = true AND LOGIN = true;`

1. Switch to your *new_super_user* and execute the following query:

   `ALTER ROLE cassandra WITH SUPERUSER = false AND LOGIN = false;`

1. Applying the principle of separation of privileges, we recommend that you also create a dedicated user for DataMiner:

   `CREATE ROLE dataminer WITH PASSWORD '<STRONG PASSWORD>' AND LOGIN = true;`

1. Finally, set the new credentials in DataMiner Cube. For more information, see [Configuring the database settings in Cube](xref:Configuring_the_database_settings_in_Cube).

1. You may need to **restart DataMiner** for the changes to take effect.

> [!NOTE]
> You can also configure Cassandra to use an LDAP server for authentication. However, this is beyond the scope of this guide.

### Authorization

#### Enabling the *CassandraAuthorizer*

Implementing a Zero Trust architecture requires applying the principle of least privilege across your infrastructure. This is especially true for your databases. By default, DataMiner installs Cassandra with authorizer **AllowAllAuthorizer**, effectively granting all permissions to all roles. However, Cassandra also supports the **CassandraAuthorizer**, which allows more granular permission management.

To enable the *CassandraAuthorizer* in Cassandra:

1. Set the *authorizer* field to *CassandraAuthorizer* in your *cassandra.yaml* file (located in the Cassandra installation folder):

   `authorizer: CassandraAuthorizer`

1. Grant your DataMiner database user full permissions on the DataMiner keyspaces. You can do so by executing the following queries (using DevCenter, the DataMiner Cube Query Executor, or your preferred query tool):

   `GRANT CREATE ON ALL KEYSPACES TO <YOUR DATABASE USER/ROLE>;`

   `GRANT ALL ON KEYSPACE "SLDMADB" TO <YOUR DATABASE USER/ROLE>;`

   `GRANT ALL ON KEYSPACE "sldmadb_ticketing" TO <YOUR DATABASE USER/ROLE>;`

> [!NOTE]
> For Cassandra clusters, DataMiner requires **full permissions** on all keyspaces.

<!-- TODO encryption
### Client-Node Encryption

### Inter-Node Encryption

### Encryption at rest
-->
### Firewall ports

The following ports should be opened in the firewall, depending on your setup:

- **7000 or 7001**: Inter-node communication will go over port 7000 (or 7001 if TLS/SSL is enabled). This port should therefore be opened on the servers hosting Cassandra.

- **9042**: By default, Cassandra will communicate with clients over TCP port 9042. For DataMiner Systems with **single-node Cassandra systems, this port is not required** (unless DataMiner Failover is active).

### Updating Cassandra

We recommend that you periodically update your Cassandra database to ensure that all known vulnerabilities are fixed.

You can verify your version of Cassandra by executing the following query:

`SELECT cql_version FROM system.local;`

By default, DataMiner installs Cassandra 3.11. However, Cassandra 4.0 is also supported.

> [!NOTE]
> Cassandra 4.0 is no longer supported on Windows, which means that extra Linux servers will be required to host the Cassandra database.

### Updating Java

By default, DataMiner installs Cassandra with its own Java installation. This is typically located in *C:\Program Files\Cassandra\Java\bin*. DataMiner deploys Cassandra with **Java 1.8.0_91**.

To update the Java version:

1. Download the latest Java binaries from the official website.

1. Stop your DataMiner Agent.

1. Stop the *Cassandra* service.

1. Update the binaries in *C:\Program Files\Cassandra\Java*.

1. Start the *Cassandra* service.

1. Start your DataMiner Agent.

## Elasticsearch

<!-- TODO: enable authentication -->
<!-- TODO: enable TLS encryption -->

### Updating Elasticsearch

By default, DataMiner install Elasticsearch 6.8.23. For more information about how you can upgrade your Elasticsearch version, please refer to [upgrading elasticsearch](https://community.dataminer.services/documentation/upgrading-elasticsearch-from-one-minor-version-to-another/).

### Updating Java

By default, DataMiner installs Elasticsearch with its own Java installation. This is typically located in *C:\Program Files\Elasticsearch\Java\bin*. DataMiner deploys Elasticsearch with **Java 1.8.0_121**.

To update the Java version:

1. Download the latest Java binaries from the official website.

1. Stop your DataMiner Agent.

1. Stop the *elasticsearch-service-x64* service.

1. Update the binaries in *C:\Program Files\Elasticsearch\Java*.

1. Start the *elasticsearch-service-x64* service.

1. Start your DataMiner Agent.
