---
uid: SchedulerDataStorage
---

# Scheduler data storage

Scheduled tasks can be stored in either XML or database storage, which is supported from 10.6.3/10.7.0 onwards. 
When using a database storage, the following options are supported:

- Cassandra cluster
- Cloud storage

## Configuring the storage type

The storage type is specified in the Scheduler configuration file located at `C:\Skyline DataMiner\Scheduler\Config.xml`.
Example configuration: 

```xml
<Scheduler>
  <Storage>database</Storage>
</Scheduler>
```

- Set the Storage value to either `Xml` or `Database`.
- If the configuration file is missing, scheduled tasks default to XML storage. 

## Migrating existing XML data

If you have scheduled tasks stored in XML, this data can be migrated to database storage, see [Migrating scheduled tasks to database](xref:SchedulerMigrationToDatabase).