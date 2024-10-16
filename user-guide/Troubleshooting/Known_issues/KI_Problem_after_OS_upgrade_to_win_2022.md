---
uid: KI_Problem_after_OS_upgrade_to_win_2022
---

# Problem after upgrading Window OS to Windows Server 2022

## Affected versions

Systems that have just been upgraded to Windows Server 2022.

## Cause

After an upgrade to Windows Server 2022, the following issues can cause problems with DataMiner:

- Netlogon service is not enabled.
- IIS is not enabled and the default website is not set.

## Fix

- For the Netlogon issue, refer to the Microsoft article [Netlogon service does not keep settings](https://learn.microsoft.com/en-us/troubleshoot/windows-server/active-directory/netlogon-service-not-start-automatically)

- For the IIS issue:

  1. Enable IIS. See [How to Enable IIS on Windows Server](https://techcommunity.microsoft.com/t5/iis-support-blog/how-to-enable-iis-and-key-features-on-windows-server-a-step-by/ba-p/4229883).

  1. Configure the default website:

     1. Open *IIS Manager*.

     1. In the *Connections* pane on the left, expand the top node and *Sites* node until you see *Default Web Site*.

     1. Under *Actions* on the right, click *Basic Settings*.

     1. Make sure the settings are filled in as follows, and click *OK*.

        ![Default website configuration](~/user-guide/images/KI_IIS_default_website.png)

  1. Restart IIS.

## Description

After the server running a DMA is upgraded to Windows Server 2022, the DMA appears to be disconnected from the DataMiner System. In System Center, its status is indicated as *Disconnected* or *Unknown*.
