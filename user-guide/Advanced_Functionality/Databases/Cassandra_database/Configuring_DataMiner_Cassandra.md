---
uid: Configuring_DataMiner_Cassandra
---

# Configuring Cassandra in System Center

The Cassandra settings in System Center can be found under *System Center* > *Database*.

The following settings should be configured:

- *Type* => *Database per cluster*.

- *Database* => *CassandraCluster*

- *Name* => The prefix that the DataMiner system will use to create the keyspaces.

- *DB server* => The IP's of the nodes (comma seperated).

- *User* => User that will be used to login to Cassandra.

- *Password* => The password of the user that will be used to login to Cassandra.

> [!NOTE]
> The above can also be configured in the [Db.xml](xref:DB_xml) file.