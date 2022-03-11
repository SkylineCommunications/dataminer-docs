---
uid: Database_security
---

# Securing the DataMiner databases

## Cassandra (default)

### Authentication

By default, DataMiner installs Cassandra with the PasswordAuthenticator enabled. Cassandra comes installed with a default *cassandra* user. When DataMiner installed Cassandra (e.g. during migration or installation), an extra superuser named *root* is created.

We highly recommend configuring more **secure passwords** for the default users, preferably randomly generated and stored in a password vault. This can be done by executing the following queries (either through DevCenter, the DataMiner Cube Query Executor, or your preferred query tool):

`ALTER USER cassandra WITH PASSWORD '<NEW PASSWORD>'`

`ALTER USER root WITH PASSWORD '<NEW PASSWORD>'`

It's a best practice to create a new superuser and **disable** the default cassandra user. To do this, log in with the cassandra user and execute the following query:

`CREATE ROLE <new_super_user> WITH PASSWORD = "<STRONG PASSWORD>" AND SUPERUSER = true AND LOGIN = true;`

Now switch to your *new_super_user* and execute:

`ALTER ROLE cassandra WITH SUPERUSER = false AND LOGIN = false;`

Applying the principle of separation of privileges, it's recommended to create a dedicated user for DataMiner:

`CREATE ROLE dataminer WITH PASSWORD '<STRONG PASSWORD>' AND LOGIN = true;`

Finally, set the new credentials in DataMiner Cube, for more information see Configuring Database Settings. It's possible that you need to **restart your DataMiner system** for the changes to take effect.

It's also possible to configure Cassandra to use an LDAP server for authentication however, this is beyond the scope of this guide.

### Authorization

Implementing a Zero Trust architecture requires applying the principle of least privilege across your infrastructure. This is especially true for your databases. By default, DataMiner installs Cassandra with authorizer: **AllowAllAuthorizer**, effectively granting all permissions to all roles. Cassandra also has support for the **CassandraAuthorizer**, which allows more granular permission management.

You can enable the *CassandraAuthorizer* by setting the authorizer in your *cassandra.yaml* file:

`authorizer: CassandraAuthorizer`

After enabling authorization, we need to grant the *dataminer* role permission on the DataMiner keyspaces.

`GRANT CREATE ON ALL KEYSPACES TO dataminer;`

`GRANT ALL ON KEYSPACE "SLDMADB" TO dataminer;`

`GRANT ALL ON KEYSPACE "sldmadb_ticketing" TO dataminer;`

For Cassandra clusters, DataMiner requires **full permissions** on all keyspaces.

<!-- TODO encryption
### Client-Node Encryption

### Inter-Node Encryption

### Encryption at rest
-->
### Firewall

By default, Cassandra will communicate with clients over TCP port **9042**. For DataMiner systems with single node Cassandra systems, it is not required to open this port in the firewall (unless DataMiner failover is active). Inter-node communication will go over port **7000** (7001 if TLS/SSL is enabled) and should be opened on the servers hosting Cassandra.

### Updates

As with any piece of software, it's recommended to periodically update your Cassandra to ensure all known vulnerabilities are fixed.

You can verify your version of Cassandra by executing the following query:

`SELECT cql_version FROM system.local;`

By default, DataMiner installs Cassandra 3.11. However, Cassandra 4.0 is also supported. Do note that Cassandra 4.0 is no longer supported on Windows, and will require extra (Linux) servers to host the Cassandra database.

### Java version

By default, DataMiner installs Cassandra with its own Java installation. This is typically located in *C:\Program Files\Cassandra\Java\bin*. DataMiner deploys Cassandra with **Java 1.8.0_91**.

To update the Java installation:

1. Download the latest Java binaries from the official website
2. Stop your DataMiner
3. Stop the Cassandra service
4. Update the binaries in *C:\Program Files\Cassandra\Java*
5. Stop the Cassandra service
6. Start your DataMiner

<!-- TODO 
## MySQL
## Elasticsearch
-->