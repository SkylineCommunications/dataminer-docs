---
uid: Data_Aggregator_troubleshooting
---

# Troubleshooting

Check DataAggregator Log Files for Errors

Ensure to inspect the DataAggregator log files for any potential errors. By default, the log file for Data Aggregator is located in: `C:\ProgramData\Skyline Communications\DataMiner DataAggregator\Logs`.

## The DataMiner DataAggregator process is not starting up

When encountering issues with the DataMiner DataAggregator process failing to start, one common reason is an invalid JSON format within the settings. This is often reflected in an event logged in the `Event Viewer`.

1. Navigate to Event Viewer: Open the `Event Viewer` and search for errors registered by the `DataMiner DataAggregator.exe` application. The event's content will provide detailed information about the encountered issue.

1. Identify Issue: Look for indications within the event that suggest the issue. For example, an `invalid escapable character within a JSON string`, in following screenshot.
![Event Viewer](~/user-guide/images/DataAggregatorEventViewer.png)