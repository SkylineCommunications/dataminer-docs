# Databases

### What do I do if Cassandra does not start up after a server restart?

If a DataMiner version prior to 9.0.0 CU9 is used, and Cassandra no longer starts up after a server has been restarted, this may be caused by a problem with the commit log.

In that case, you will find an error in the Cassandra log files like the following:

```txt
ERROR [main] 2016-04-25 08:25:51,422 JVMStabilityInspector.java:81 - Exiting due to error while processing commit log during initialization.                                                     
org.apache.cassandra.db.commitlog.CommitLogReplayer$CommitLogReplayException: Could not read commit log descriptor in file C:\PROGRA\~1\CASSAN\~1\data\commitlog\CommitLog-6-1459504472381.log
```

This issue is automatically resolved in DataMiner version 9.0.0 CU9. However, if you are using an older version of DataMiner, you can solve this problem as follows:

1. Open Registry Editor.

2. Go to *HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Apache Software Foundation\\Procrun 2.0\\cassandra\\Parameters\\Java*.

3. Right-click the *Options* value and select *Modify*.

4. In the Editor, scroll down, and add one additional line with the following Cassandra option:

    ```txt
    -Dcassandra.commitlog.ignorereplayerrors=true
    ```

5. Click *OK* to close the Editor and close the Registry Editor.

    The next time you (re)start Cassandra, this option will be taken into account, so that commit log errors will no longer cause Cassandra startup to fail.

|          |                                                                                                                                                                             |
|----------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Warning: | Be very careful when making changes in the registry. If you make any mistakes, this can cause serious issues. As such, we highly recommend to upgrade to 9.0.0 CU9 instead. |

### What happens if an offload database...

#### ... is activated?

Data from the DataMiner System will be offloaded from the moment of activation.

> [!NOTE]
> Data dating from before the activation will not be offloaded.

#### ... is deactivated for a couple of days?

There will be a gap in the data stored on that offload database.

#### ... cannot be reached for a while?

The offload files are stored for as long the offload database cannot be reached, and will be processed from the moment the connection has been established again.
