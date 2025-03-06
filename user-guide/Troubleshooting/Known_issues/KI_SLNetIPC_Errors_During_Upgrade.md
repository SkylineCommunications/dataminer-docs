---
uid: KI_SLNetIPC_Errors_During_Upgrade
---

# Failed getting progress from http&#58;&#47;&#47;slnetipc&#58;8004&#47;UpgradeService: The remote name could not be resolved: 'slnetipc'

## Affected versions

From DataMiner 10.4.0 [CU0]/10.3.7 onwards.

## Cause

When connecting to a DataMiner agent via localhost/127.0.0.1 a special local connection called slnetIPC which utilizes IPC ([Inter-process communication](https://en.wikipedia.org/wiki/Inter-process_communication)). An edge case in the upgrade logic causes the monitor to incorrectly parse slnetIPC as a hostname causing the upgrade events to not come through.

![Example of the issue](~/user-guide/images/KI_SLNetIPC_Upgrade_Failure.png)

> [!NOTE]
> The upgrade that a was launched is still progressing in the background, it is only the monitoring of the event is impacted.

## Workaround

Connecting to the system using the local IP or hostname before launching the upgrade will prevent the issue from happening

If you already started the upgrade you can take the following steps:

- Disconnect from cube
- Reconnect using the local IP or hostname (avoid localhost or 127.0.0.1)
- If cube says ``DataMiner is busy upgrading. The connection will be established when finished. Please wait...``
  - Click ``Monitor``
- If you can still connect to the DataMiner agent
  - Go to ``System Center`` -> ``Agents``
  - Right-click the agent you launched the upgrade from
  - Select  ``Upgrades``
  - In the window right-click the package you used to launch the upgrade
  - Click  ``Attach`` 
![Attaching to a running upgrade](~/user-guide/images/KI_SLNetIPC_Upgrade_Re-Attach.png)

The monitor should now show all the events.

## Fix

No fix yet.

## Description

When launching an upgrade there would be no progress events, instead a notice would repeatedly appear with the following message:

```txt
Failed getting progress from http://slnetipc:8004//UpgradeService: The remote name could not be resolved: 'slnetipc'
```

![Example of the issue](~/user-guide/images/KI_SLNetIPC_Upgrade_Failure.png)

This happens when the upgrade was launched by a cube that was connected via localhost. This can be verified by clicking your account in the top right -> About. In the connection tab look for ``Connection String`` or ``Connection String (NR)``. If either or both says ``ipc://slnetipc/SLNetService``, this issue will occur.

![Connection string](~/user-guide/images/KI_SLNetIPC_Upgrade_Connection.png)
