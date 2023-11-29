---
uid: Data_Aggregator_troubleshooting
---

# Troubleshooting

Check the DataAggregator Log Files for Errors

Be sure to inspect the DataAggregator log files for any potential errors. By default, the log file for Data Aggregator is located in: `C:\ProgramData\Skyline Communications\DataMiner DataAggregator\Logs`.

## The DataMiner DataAggregator process is not starting up

When the DataMiner DataAggregator service fails to start, a common reason is invalid JSON syntax in the settings configuration. The settings can be found in `C:\Program Files\Skyline Communications\DataMiner DataAggregator`. In that case, an event will be logged in the `Event Viewer`.

1. Navigate to Event Viewer: Open the `Event Viewer` and search for errors registered by the `DataMiner DataAggregator.exe` application. The event's content will provide detailed information about the encountered issue.

1. Identify Issue: Look for indications within the event that suggest the issue. For example, an `invalid escapable character within a JSON string`, in following screenshot.
![Event Viewer](~/user-guide/images/DataAggregatorEventViewer.png)