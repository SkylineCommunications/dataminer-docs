---
uid: KI_Downgrade_fails_VerifyNatsIsRunning_prerequisite
---

# Downgrade fails because of VerifyNatsIsRunning.dll prerequisite

## Affected versions

From DataMiner 10.4.0/10.4.3 onwards.

## Cause

From DataMiner 10.4.0/10.4.3 onwards, the *DataMinerMessageBroker.API* NuGet package is used instead of the deprecated *SLMessageBroker.dll* file, but the *VerifyNatsIsRunning.dll* prerequisite expects *SLMessageBroker.dll* to be present on the DMA.

## Fix

Open the upgrade package you want to downgrade to (like a zip archive) and remove *VerifyNatsIsRunning.dll* from the `\Update.zip\Prerequisites\` folder.

## Description

When you downgrade from DataMiner 10.4.0/10.4.3 or higher to a DataMiner version prior to 10.4.0/10.4.3, the *VerifyNatsIsRunning.dll* prerequisite fails, causing the downgrade to fail.
