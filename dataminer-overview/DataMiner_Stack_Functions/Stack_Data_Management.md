---
uid: Stack_Data_Management
---

# Data Management

***Easily manage, protect, and enrich your data flows.***

![stack.functions.categories](~/dataminer-overview/images/stack_data_management.png)

## Log file management

**Collecting, formatting, aggregating, and analyzing log data to optimize programs and applications.**

DataMiner collects and analyzes log files from various data sources (devices, servers, applications, etc.) in a central location. This allows for more efficient troubleshooting and faster resolution of issues. The log files can be automatically monitored for errors, warnings, or other predefined events, and alerts can be generated to notify operators when such events occur.

Using Elasticsearch indexing for log file management, this allows for efficient indexing, searching, and filtering of log files to quickly locate specific events.

## Backup

**Automatically make backups of your entire setup at the touch of the button.**

A **full backup** will create a copy of the entire setup to restore the entire DataMiner Agent, including all configurations, user accounts, scripts, and historical data. This type of backup is useful when migrating to a new server, restoring a complete setup, or setting up a disaster recovery solution.

A **partial backup**, on the other hand, allows you to select specific parts of the setup to back up. This type of backup is useful when making changes to a specific part of the setup and wanting to ensure a quick restore in case of issues.

Different types of partial backup are available in DataMiner, including:

- Configuration backup (with/without): All data necessary to restore the configuration of the DataMiner Agent. Does not include DataMiner files and logging.
- Element backup: All data necessary to restore one or more elements. Includes element data and element protocol. Use for test purposes only.
- Element migration: Back up all data necessary to migrate one or more elements or services from one DataMiner Agent to another. Includes configuration files, scripts, Visio drawings, user filters, views, etc.

Both full and partial backups can be scheduled to run automatically, and they can be stored locally or remotely for added security.

## Data storage

By default, DataMiner uses a Cassandra and Elasticsearch database. Other data storage solutions can be added optionally.

> [!TIP]
> For more information:
>
> - [Supported system data storage architectures](xref:Supported_system_data_storage_architectures) in the DataMiner User Guide
> - [About databases](xref:Databases_about) in the DataMiner User Guide

## Audit trailing

**Documenting the flow of transactions.**

DataMiner offers detailed, uniform, and fully consolidated audit trailing, easy to browse and search via the DataMiner Cube client UI, and providing insight in all activities in the operational ecosystem.

The administrator can see the changes made per user or per device/element, including which resources, which actions, etc.

> [!TIP]
> For more information:
>
> - [Security expert hub](https://community.dataminer.services/expert-hub-ict-security/)
> - [Security](xref:About_DMS_Security) in the DataMiner User Guide
> - [Experts & Insights - DataMiner Security](https://community.dataminer.services/video/experts-insights-dataminer-security/) (webinar/video) ![Video](~/user-guide/images/video_Duo.png)

## Single sign-on

**User authentication service that permits a user to use one set of login credentials.**

DataMiner security enables role-based and domain-based management. It provides the administrator with a simple tool to define in detail what each account or group is allowed to do or see, based on views (write, configure, visibility), permissions (access, add, edit, delete, import, properties, lock, unlock, pause, stop, etc.), and access levels. Administrators can create as many groups/profiles as they want.

DataMiner supports two principal schemes to manage the actual user accounts (i.e. username and password):

- Standalone: As with any other typical solution, DataMiner allows the administrator to create all user accounts (username/password) from scratch in the DataMiner System.
- Domain-integrated: Rather than adding all the user accounts separately in the DataMiner System, you can simply point DataMiner to an existing Windows domain.

> [!TIP]
> For more information:
>
> - [Managing Users](xref:Managing_users) in the DataMiner User Guide
