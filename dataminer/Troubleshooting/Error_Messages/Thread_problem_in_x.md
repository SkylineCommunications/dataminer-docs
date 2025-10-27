---
uid: Thread_problem_in_x
---

# Thread problem in x: y

In an error message of this type:

- "x" is the DataMiner process in which the error occurred.
- "y" is the thread that encountered a problem.

Alternatively, if there is a problem affecting more than one thread, the following variation on this error message can appear, in which "z" is the number of threads that encountered a problem:

```txt
Thread problem in x: y [+ z pending]
```

The following error messages are possible:

- Thread problem in SLDataMiner: ActionThread
- Thread problem in SLDataMiner: AddressChangeThread
- Thread problem in SLDataMiner: AlarmLevelRegistration
- Thread problem in SLDataMiner: AlarmLevelUpdates
- [Thread problem in SLDataMiner: AlarmStackThread](#thread-problem-in-sldataminer-alarmstackthread)
- [Thread problem in SLDataMiner: DBCleaning](#thread-problem-in-sldataminer-dbcleaning)
- [Thread problem in SLDataMiner: DBForwarding](#thread-problem-in-sldataminer-dbforwarding)
- [Thread problem in SLDataMiner: DBThread](#thread-problem-in-sldataminer-dbthread)
- [Thread problem in SLDataMiner: ElementStackThread](#thread-problem-in-sldataminer-elementstackthread)
- Thread problem in SLDataMiner: ExecuteThread
- Thread problem in SLDataMiner: LDAPNotification thread
- Thread problem in SLDataMiner: MergeThread
- [Thread problem in SLDataMiner: MobileNotificationThread](#thread-problem-in-sldataminer-mobilenotificationthread)
- [Thread problem in SLDataMiner: MobileThread](#thread-problem-in-sldataminer-mobilethread)
- Thread problem in SLDataMiner: MonitorSchedule
- [Thread problem in SLDataMiner: OffloadDBThread](#thread-problem-in-sldataminer-offloaddbthread)
- [Thread problem in SLDataMiner: ReplicationDBThread](#thread-problem-in-sldataminer-replicationdbthread)
- [Thread problem in SLDataMiner: ServiceThread](#thread-problem-in-sldataminer-servicethread)
- [Thread problem in SLDataMiner: ServiceReplicationThread](#thread-problem-in-sldataminer-servicereplicationthread)
- Thread problem in SLDataMiner: SetTriggers

## Thread problem in SLDataMiner: AlarmStackThread

The *AlarmStackThread* processes alarm or information requests originating from different modules, and it forwards them to *SLElement*, which then creates the actual alarms. These are not alarms generated based on the settings in one of the alarm templates.

### Symptom

No more alarms are being generated.

### Possible cause

- SLElement has encountered a problem.
- An element lock is stuck.

### Resolution

Restart DataMiner.

## Thread problem in SLDataMiner: DBCleaning

The *DBCleaning* thread removes data that is no longer needed from the local database, e.g. old trending and alarm data.

### Symptom

- The database size is increasing.
- Disk I/O performance and free space are decreasing.
- Performance is decreasing with regard to trending, alarms, and backups.

### Possible cause

- There is a problem with the local database.
- There is an element-specific lock in DataMiner.
- One database table is taking more than the allowed amount of time.

### Resolution

- Check the database.
- Manually intervene to help with the cleanup.
- Check if the amount of trending is within reasonable bounds.

> [!NOTE]
> Restarting DataMiner will not help.

## Thread problem in SLDataMiner: DBForwarding

The *DBForwarding* thread pushes data saved in the system cache offload to the central database.

### Possible cause

There is a problem with the central database.

### Resolution

Check the database.

## Thread problem in SLDataMiner: DBThread

The *DBThread* thread processes plain SQL queries for the local database (insert, delete, and update only).

### Possible cause

- There is a problem with the local database.
- Queries take too long to finish.
- There might be an issue with a protocol.

### Resolution

- Check whether the database has any large tables.
- If there is an issue with a protocol, upload a new version of that protocol.

## Thread problem in SLDataMiner: ElementStackThread

The *ElementStackThread* is dynamically created for every element when needed, and it is removed when no more sets are pending. It forwards sets directly to the correct SLProtocol.

These sets can originate from DataMiner clients, SLSNMPManager, other elements, scripts (except for scripts with waits), element connections, etc. They can contain trap information, alarm level linking, SLA alarm forwarding, advanced naming changes (DCF), etc.

### Possible cause

- SLProtocol has encountered a problem.
- SLElement has encountered a problem.
- An element lock is stuck.

### Resolution

- Restart the element in question.
- Stop the SLScripting process.

## Thread problem in SLDataMiner: MobileNotificationThread

The *MobileNotificationThread* sends text message notifications to the *SLGSMGateway* process.

## Thread problem in SLDataMiner: MobileThread

When a *Mobile Gateway* address is defined, the *MobileThread* will create the *SLGSMGateway* process and keep it up to date.

## Thread problem in SLDataMiner: OffloadDBThread

The *OffloadDBThread* pushes data saved in the system cache offload "local" folder to the local database.

### Symptom

- History data is not up to date.
- Element data is not saved.
- Free disk space is decreasing, which could lead to a crash.
- Disk I/O performance is decreasing.
- The database is using too many CPU resources.
- The next startup could be very slow.

### Possible cause

- There is a problem with the local database.
- *SLDatabase.dll* is loaded but not registered.
- There is a configuration issue in *db.xml*.
- There are too many files in the offload folder.
- Actions take too long:

  - A database table is becoming too large.
  - Too many keys are being updated.

### Resolution

- Check the database.
- Clear the system cache.

  > [!CAUTION]
  > Note that information may get lost. Information regarding to alarms, properties, services, or correlation can be copied and pasted, but this is not advisable for trending or element data.

- Check any new trend templates.
- Check any new alarm templates.
- Check any recently installed protocols.

## Thread problem in SLDataMiner: ReplicationDBThread

The *ReplicationDBThread* pushes the local database data to the Failover DMA (both a query queue and a file-based offload).

### Resolution

- Check the database.
- Restart DataMiner, but only if it is not a connectivity issue.

  - First restart the offline Agent, and check whether that solves the problem.
  - If a query is slow, check on which DMA the issue occurs, and restart that DMA.

> [!CAUTION]
> Switching might cause more issues.

## Thread problem in SLDataMiner: ServiceThread

The *ServiceThread* handles all service logic, from service states to triggers.

### Possible cause

- SLElement has encountered a problem.
- SLDMS has encountered a problem.

## Thread problem in SLDataMiner: ServiceReplicationThread

The *ServiceReplicationThread* connects and subscribes on remote service states via *SLManagedScripting.dll/SLNet*. This thread is not responsible for processing the service states.

### Symptom

Replicated services are not up to date.

### Possible cause

- A thread resets Watchdog at the end.
- Connecting takes longer than 1 minute.
- A remote server may be down or there may be an issue with a firewall.

### Resolution

- Check whether a connection can be set up with the remote DMA.

> [!NOTE]
> Restarting the DMA will probably not solve the issue.
