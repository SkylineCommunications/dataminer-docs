---
uid: Data_Aggregator_troubleshooting
---

# Troubleshooting

If you encounter any issues, first check the Data Aggregator log files for errors. By default, you can find these in the folder `C:\ProgramData\Skyline Communications\DataMiner DataAggregator\Logs`.

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
