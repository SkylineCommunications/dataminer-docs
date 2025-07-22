---
uid: Stack_Data_Management
---

# Data Management

***Easily manage, protect, and enrich your data flows.***

## Log file management

DataMiner collects and analyzes log files from various data sources (devices, servers, applications, etc.) in a central location. This allows for more efficient troubleshooting and faster resolution of issues. The log files can be automatically monitored for errors, warnings, or other predefined events, and alerts can be generated to notify operators when such events occur.

## Backup

Automatically make backups of your entire setup.

A **full backup** will create a copy of the entire setup to restore the entire DataMiner Agent, including all configurations, user accounts, scripts, and historical data. This type of backup is useful when migrating to a new server, restoring a complete setup, or setting up a disaster recovery solution.

A **partial backup**, on the other hand, allows you to select specific parts of the setup to back up. This type of backup is useful when you make changes to a specific part of the setup and want to ensure a quick restore in case of issues.

For information on the different types of backups and the different ways you can take a backup, refer to [Backing up a DataMiner Agent](xref:Backing_up_a_DataMiner_Agent).

Different types of partial backup are available in DataMiner, including:

- Configuration backup (with/without): All data necessary to restore the configuration of the DataMiner Agent. Does not include DataMiner files and logging.
- Element backup: All data necessary to restore one or more elements. Includes element data and element protocol. Use for test purposes only.
- Element migration: Back up all data necessary to migrate one or more elements or services from one DataMiner Agent to another. Includes configuration files, scripts, Visio drawings, user filters, views, etc.

Both full and partial backups can be scheduled to run automatically, and they can be stored locally or remotely for added security.

## Data storage

The recommended data storage setup for DataMiner is [Storage as a Service](xref:DM_selfhosted_and_StaaS). With this setup, Skyline Communications manages the storage for you, so you can save on infrastructure and IT maintenance costs. If this is really necessary, you can also choose to host the DataMiner storage databases yourself, though this is not recommended. In that case, a clustered Cassandra and OpenSearch setup will be required.

Other data storage solutions can be added optionally.

> [!TIP]
> For more information:
>
> - [About storage](xref:About_storage)
> - [Storage as a Service (STaaS)](xref:STaaS)

## Audit trailing

DataMiner offers detailed, uniform, and fully consolidated audit trailing, easy to browse and search via the DataMiner Cube client UI, and providing insight in all activities in the operational ecosystem.

The administrator can see the changes made per user or per device/element, including which resources, which actions, etc.

> [!TIP]
> For more information:
>
> - [Security](xref:About_DMS_Security)

## Single sign-on

DataMiner security enables role-based and domain-based management. It provides the administrator with a simple tool to define in detail what each account or group is allowed to do or see, based on views (write, configure, visibility), permissions (access, add, edit, delete, import, properties, lock, unlock, pause, stop, etc.), and access levels. Administrators can create as many groups/profiles as they want.

DataMiner supports two principal schemes to manage the actual user accounts (i.e. username and password):

- Standalone: As with any other typical solution, DataMiner allows the administrator to create all user accounts (username/password) from scratch in the DataMiner System.
- Domain-integrated: Rather than adding all the user accounts separately in the DataMiner System, you can simply point DataMiner to an existing Windows domain.

> [!TIP]
> For more detailed information, see [User management](xref:User_management).
