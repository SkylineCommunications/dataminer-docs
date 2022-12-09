---
uid: KI_SLNet_issue_SPI_obfuscation
---

# SLNet issues due to SPI obfuscation

## Affected versions

- DataMiner 10.2.0 [CU3] up to 10.2.0 [CU5]
- DataMiner 10.2.6 up to 10.2.8

## Cause

In order to improve security, the identity of users was obfuscated for SPIs. However, the mechanism that kept the obfuscated identity in sync throughout the DMS could in some cases cause a deadlock in SLNet, which lead to various SLNet issues.

## Fix

Install DataMiner 10.2.0 [CU6] or 10.2.9.

## Issue description

Multiple different issues related to SLNet could occur: it could be impossible to connect to a DMA, the Cube connection could be erratic, there could be timeouts between DMAs, etc. In the SLNet logging, the following lines were displayed:

```txt
at Skyline.DataMiner.Net.Authentication.ObfuscationItemIdUtil.DelayedObfuscatedItemIdManager`1.WaitForInit()
at Skyline.DataMiner.Net.Authentication.ObfuscationItemIdUtil.DelayedObfuscatedItemIdManager`1.GetAllObfuscatedItems()
at Skyline.DataMiner.Net.Authentication.ObfuscationItemIdUtil.ObfuscatedItemIdManagerMessageHandler.Handle[T](IConnectionInfo connInfo, IObfuscatedItemIdManager`1 manager, GetAllObfuscatedItemIdsRequest`1 request)
```
