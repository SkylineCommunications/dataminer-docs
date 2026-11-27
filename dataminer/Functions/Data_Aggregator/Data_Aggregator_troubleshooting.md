---
uid: Data_Aggregator_troubleshooting
description: "Troubleshoot Data Aggregator startup and GQI query migration issues using configuration and installer log files."
---

# Troubleshooting

If you encounter any issues, first check the Data Aggregator log files for errors. By default, you can find these in the folder `C:\ProgramData\Skyline Communications\DataMiner DataAggregator\Logs`.

## Installation, upgrade, or repair fails during GQI query migration

From Data Aggregator 3.4.0 onwards, installation, upgrade, or repair can fail if Windows Installer rollback is disabled, migration folder permissions are unsafe, or an earlier migration is incomplete.<!-- RN 47072+47201 -->

Check `%ProgramData%\Skyline Communications\DataMiner DataAggregator\Migrations\Migration.log` for the specific error. Administrator permissions are required. If the migration log could not be created, check the Windows Installer log instead.

If an earlier migration is incomplete, do not delete the *Pending* folder or [migration backups](xref:Data_Aggregator_Migrators#automatic-migration-from-data-aggregator-340-onwards) to bypass the check. Recovery refuses to overwrite externally changed files or use corrupt backups. Contact <support@dataminer.services> if recovery is blocked.

## The DataMiner DataAggregator process is not starting up

When the DataMiner DataAggregator service fails to start, this is often because of invalid JSON syntax in the settings configuration.

You can find these settings in the folder `C:\Program Files\Skyline Communications\DataMiner DataAggregator`.

To check whether invalid JSON syntax is the cause of the issue, check the Windows Event Viewer:

1. Open the *Event Viewer* application in Windows.

1. In the sidebar on the left, navigate to *Windows Logs* > *Application*.

1. Search for errors registered by the `DataMiner DataAggregator.exe` application.

1. Check the information about the error events for details that explain the issue.

   This can for example be an `invalid escapable character within a JSON string`:

   ![Event Viewer](~/dataminer/images/DataAggregatorEventViewer.png)
