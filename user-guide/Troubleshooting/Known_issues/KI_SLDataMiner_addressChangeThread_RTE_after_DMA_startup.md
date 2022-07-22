---
uid: KI_SLDataMiner_addressChangeThread_RTE_after_DMA_startup
---

# SLDataMiner addressChangeThread RTE after DMA startup

## Affected versions

All DataMiner versions

## Cause

SLSendGARP process

## Fix

Use [Npcap](https://nmap.org/npcap/).

## Issue description

When this issue occurs, in the Windows Task Manager, you can see that the SLSendGARP process is still running, even though this process should be destroyed immediately after an ARP request is sent. If you start up DataMiner again, a second SLSendGARP process is added in Task Manager.

During a Failover switch, DataMiner sends a [gratuitous ARP packet](xref:Gratuitous_ARP_messages) via the SLSendGARP process. Once the packet has been sent, the process is destroyed. However, it can happen that SLSendGARP is not destroyed because of an issue with the WinPcap driver when it is being accessed by multiple instances. This issue with WinPcap is resolved in Npcap.

## Workaround

Kill the SLSendGARP process and restart DataMiner. If it is not possible to kill the process, reboot the server.
