---
uid: Cassandra_authentication
---

# Cassandra authentication

By default, DataMiner installs Cassandra with the PasswordAuthenticator enabled. Cassandra comes installed with a default *cassandra* user. When DataMiner installs Cassandra (e.g. during migration or installation), an extra superuser named *root* is created.

## Configuring strong passwords for the default users

We highly recommend that you configure more secure passwords for the default user. Preferably, these passwords should be randomly generated and stored in a password vault.

You can do so by executing the following queries (using *cqlsh* in a Linux environment, DevCenter in Windows, Query Executor in DataMiner Cube, or your preferred query tool):

`ALTER ROLE cassandra WITH PASSWORD = '<NEW PASSWORD>';`

`ALTER ROLE root WITH PASSWORD = '<NEW PASSWORD>';`

> [!TIP]
> To easily change the password for the Cassandra database, execute the [change-cassandra-password-script](https://github.com/SkylineCommunications/change-db-password-scripts/blob/main/change-cassandra-password-script.xml) script. This will allow you to change the credentials without a DataMiner restart.

## Creating a new superuser and removing the default user

We also recommend that you create a new superuser and disable the default *cassandra* user. To do so:

1. Log in with the *cassandra* user and execute the following query:

   `CREATE ROLE <new_super_user> WITH PASSWORD = '<STRONG PASSWORD>' AND SUPERUSER = true AND LOGIN = true;`

1. Switch to your *new_super_user* and execute the following query:

   `ALTER ROLE cassandra WITH SUPERUSER = false AND LOGIN = false;`

1. Applying the principle of separation of privileges, we recommend that you also create a dedicated user for DataMiner:

   `CREATE ROLE dataminer WITH PASSWORD = '<STRONG PASSWORD>' AND LOGIN = true;`

1. Set the new credentials in DataMiner Cube. For more information, see [Configuring the database settings in Cube](xref:Configuring_the_database_settings_in_Cube).

1. Delete the *root* user from Cassandra:

   `DROP ROLE IF EXISTS root;`

1. **Restart DataMiner** for the changes to take effect.

> [!NOTE]
> You can also configure Cassandra to use an LDAP server for authentication. However, this is beyond the scope of this guide.
