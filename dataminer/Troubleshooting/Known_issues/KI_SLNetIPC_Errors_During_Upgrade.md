---
uid: KI_SLNetIPC_Errors_During_Upgrade
---

# 'Failed getting progress' notices during upgrade

## Affected versions

From DataMiner 10.4.0 [CU0]/10.3.7 onwards.

## Cause

When you connect to a DataMiner Agent via localhost or 127.0.0.1, a special local connection called slnetIPC is used, which utilizes IPC ([Inter-process communication](https://en.wikipedia.org/wiki/Inter-process_communication)). An edge case in the upgrade logic causes the monitor to incorrectly parse slnetIPC as a hostname, causing the upgrade events to not come through.

![Example of the issue](~/dataminer/images/KI_SLNetIPC_Upgrade_Failure.png)

> [!NOTE]
> The upgrade that was launched will still be progressing in the background. It is only the monitoring of the event that is affected.

## Workaround

To keep this issue from happening, connect to the system using the local IP or hostname instead of localhost or 127.0.0.1.

If you have already started an upgrade and encounter this issue, you can take the following steps:

1. Close DataMiner Cube.

1. Reconnect using the local IP or hostname (avoid using localhost or 127.0.0.1).

1. If you are unable to connect but you see the message *DataMiner is busy upgrading. The connection will be established when finished. Please wait...*, click *Monitor*.

1. If you are able to connect to the DataMiner Agent:

   1. Go to *System Center* > *Agents*.
   1. Right-click the Agent you launched the upgrade from, and select *Upgrades*.
   1. In the pop-up window, right-click the package you used to launch the upgrade and select *Attach*.

      ![Attaching to a running upgrade](~/dataminer/images/KI_SLNetIPC_Upgrade_Re-Attach.png)

The monitor should now show all the events.

## Fix

Install DataMiner 10.4.0 [CU14], 10.5.0 [CU2], or 10.5.5.<!-- RN 42114 -->

## Description

During a DataMiner upgrade, no progress events are shown, but instead the following message is repeatedly shown:

```txt
Failed getting progress from http://slnetipc:8004//UpgradeService: The remote name could not be resolved: 'slnetipc'
```

![Example of the issue](~/dataminer/images/KI_SLNetIPC_Upgrade_Failure.png)

This happens when the upgrade is launched in a DataMiner Cube session connected via localhost. You can verify this in Cube by clicking the user icon in the top-right corner and selecting *About*. In the *connection* tab of the *About* window, look for `Connection String` or `Connection String (NR)`. If either or both says ``ipc://slnetipc/SLNetService``, this issue will occur.

![Connection string](~/dataminer/images/KI_SLNetIPC_Upgrade_Connection.png)
