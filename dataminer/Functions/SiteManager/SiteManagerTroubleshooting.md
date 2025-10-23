---
uid: SiteManagerTroubleshooting
---

# Site Manager troubleshooting

## FAQ

### I have created an element that connects to a data source on a remote site but the element goes into error state

This means that the tunnel could not be set up. This could be because of several reasons:

- The provided IP address or hostname does not match that of an exposed data source on the specified site as specified during [on-premises setup](xref:SiteManagerGettingStarted#on-premises-setup).
- When the data source was exposed during [on-premises setup](xref:SiteManagerGettingStarted#on-premises-setup), only one of the two required zrok commands were executed.
- The SiteManager DxM is not running.
- The zrok Agent service is not running.
- The zrok controller is not running.

### I have created an element that connects to a data source on a remote site but the element goes into timeout

As the element is not in error state, this means that the tunnel was set up but the communication is timing out.

Opening [Stream Viewer](xref:Connecting_to_an_element_using_Stream_Viewer) may provide more information regarding the cause of the timeout.

### When trying to expose a data source, I get the message `[ERROR] unable to load environment; did you 'zrok enable'?`

If you are using a command prompt to expose the data source, make sure to first execute the following command: `set USERPROFILE=c:\Windows\System32\config\systemprofile`.

If you are using a Powershell shell, execute the following command first: `$env:USERPROFILE = "C:\Windows\System32\config\systemprofile"`.

## Logging

### Site Manager DxM log file

The Site Manager log file logs all tunnel creation and teardown activity. If an element is in error state, the log file can provide more information about the root cause.

To open the Site Manager log file in Cube, navigate to *Apps* > *System Center* > *Logging* > *Site Manager (DxM)*.

This log file is also included in a Log Collector package.

### SLDataMiner log file

In DataMiner, the SLDataMiner process is responsible for communication with the SiteManager DxM.

In case issues occur, the SLDataMiner log file could provide useful information regarding the cause of the issue.

### zrok Agent log file

The zrok Agent log file is included in a Log Collector package.

On the on-premises machine, the zrok Agent log file can be found in the following location: `C:\Windows\System32\config\systemprofile\.zrok`.
