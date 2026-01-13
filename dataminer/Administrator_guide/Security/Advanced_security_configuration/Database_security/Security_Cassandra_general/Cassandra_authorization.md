---
uid: Cassandra_authorization
---

# Cassandra authorization

> [!TIP]
> If you do not want the hassle of maintaining the DataMiner storage databases yourself, we recommend using [DataMiner Storage as a Service](xref:STaaS) instead.

## Enabling the CassandraAuthorizer

Implementing a Zero Trust architecture requires applying the principle of least privilege across your infrastructure. This is especially true for your databases. By default, DataMiner installs Cassandra with authorizer **AllowAllAuthorizer**, effectively granting all permissions to all roles. However, Cassandra also supports the **CassandraAuthorizer**, which allows more granular permission management.

To enable the *CassandraAuthorizer* in Cassandra:

1. Set the *authorizer* field to *CassandraAuthorizer* in your *cassandra.yaml* file (located in the Cassandra installation folder):

   `authorizer: CassandraAuthorizer`

1. Now **restart** the Cassandra service to enable the *CassandraAuthorizer*.

1. Grant your DataMiner database user full permissions on all keyspaces.

   > [!NOTE]
   > If you are still using a legacy "Cassandra Single" setup, with a Cassandra database per DMA, you only need to to grant access to the DataMiner keyspaces. You can do so by executing the following queries using your preferred query tool:
   >
   > - `GRANT CREATE ON ALL KEYSPACES TO <YOUR DATABASE USER/ROLE>;`
   > - `GRANT ALL ON KEYSPACE "SLDMADB" TO <YOUR DATABASE USER/ROLE>;`
   > - `GRANT ALL ON KEYSPACE "sldmadb_ticketing" TO <YOUR DATABASE USER/ROLE>;`
