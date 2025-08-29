---
uid: SiteManagerTroubleshooting
---

# Site Manager troubleshooting

## Troubleshooting FAQ

### I created an element that connects to a data source on a remote site but the element goes into error state

This means that the tunnel could not be set up. This could be because of several reasons:

- The provided IP address or host does not match that of an exposed data source on the specified site
- When exposing the data source, only one of two required zrok commands were executed. Make sure to execute both zrok commands as explained in [On-premises setup](xref:SiteManagerGettingStarted#on-premises-setup)
- The Site Manager DxM is not running
- The zrok Agent service is not running
- The zrok controller is not running

### I created an element that connects to a data source on a remote site but the element goes into timeout

As the element is not in error state, this means the tunnel was set up but the communication is timing out.
Opening the Stream Viewer might provide more information regarding the cause of the timeout.

### When trying to expose a data source, I get the following message `[ERROR] unable to load environment; did you 'zrok enable'?`

When in a command prompt, make sure to first execute the following command `set USERPROFILE=c:\Windows\System32\config\systemprofile`.
If you are in a Powershell shell, execute the following command: `$env:USERPROFILE = "C:\Windows\System32\config\systemprofile"`.

## Troubleshooting procedure

### DaaS

#### Site Manager DxM log file

The Site Manager log file logs all tunnel creation and teardown activity.
If an element is in error state, the log file can provide more information about the root cause.
To open the Site Manager log file in Cube, navigate to *Apps* > *System Center* > *Logging* > *Site Manager (DxM)*.
This log file is also included in a Log Collector package.

#### SLDataMiner log file

In DataMiner, the SLDataMiner process is responsible for communicating with the Site Manager DxM.
In case issues occur, the SLDataMiner log file could provide useful information regarding the cause of the issue.

#### zrok agent log file

The zrok agent log file is included in a Log Collector package.

### On-premises

#### zrok agent log file

The zrok agent log file can be found in the following location: `C:\Windows\System32\config\systemprofile\.zrok`.
