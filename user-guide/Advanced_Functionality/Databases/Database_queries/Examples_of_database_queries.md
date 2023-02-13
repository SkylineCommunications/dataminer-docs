---
uid: Examples_of_database_queries
---

# Examples of database queries

## MSSQL database queries

If the offload database is an MSSQL database, then every DMA instructed to offload (some of) its data will copy that data to its local, publicly shared *C:\\Skyline DataMiner\\System Cache\\Offload* folder.

On the offload database, a query like the following one will then be run to insert that “offloaded” data into the offload database:

```txt
BULK INSERT ALARM FROM '\\DataMiner-1\Offload\alarm\file.dat' WITH (FIELDTERMINATOR = '\t', ROWTERMINATOR = '\n')
```

> [!NOTE]
> On MSSQL, only users who are a member of the sysadmin and bulkadmin fixed server role can execute BULK INSERT statements.

## Oracle database queries

If the offload database is an Oracle database, then every DMA instructed to offload (some of) its data, will log on to a shared folder on the server hosting the offload database, where it will place files containing the data to be offloaded.

On the offload database, a query like the following one will then be run to insert the contents of those files into the database:

```txt
CREATE OR REPLACE DIRECTORY ext AS
    'C:\Documents and Settings\All Users\Documents\DataminerOffload\';
    // Path to be defined in db.xml: RemoteFileShare@localPath
    CREATE TABLE load ORGANIZATION EXTERNAL
    (type oracle_loader default directory ext access parameters
    (records delimited by newline nologfile fields terminated by X'09'
    missing field values are null reject rows with all null fields
    ("ID" CHAR(5), "VALUE" CHAR(200))) LOCATION ('filename.dat') );
    // Creation of an external table pointing to the data file that
    // was placed in the shared folder by a DMA
INSERT INTO table (SELECT * FROM load);
    // Copy data from the data file to the database
DROP load;
```
