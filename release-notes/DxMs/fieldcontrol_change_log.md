---
uid: fieldcontrol_change_log
---

# Field Control change log

#### 24 June 2025 - Enhancement - FieldControl 2.11.4 - Improved upgrade process

Improvements have been made to the startup and shutdown of the DxM, which improves the upgrade process.

#### 17 June 2025 - Enhancement - FieldControl 2.11.3 - Improved upgrade process

Improvements have been made to the shutdown of the DxM, which improves the upgrade process.

#### 1 April 2025 - Fix - TCP port Leak [ID 42656]

A potential TCP port leak has been fixed.

In addition, several dependencies have been updated.

#### 30 October 2024 - Enhancement - FieldControl 2.11.1 - Dependencies updated [ID 41280]

Several dependencies have been updated.

#### 8 August 2024 - Enhancement - FieldControl 2.11.0 - Upgrade to .NET 8 [ID 40436]

DataMiner FieldControl has been upgraded to .NET 8. **Make sure .NET 8 is installed** before you upgrade to this version.

#### 25 July 2024 - Enhancement - FieldControl 2.10.7 - Dependencies updated [ID 40314]

Several dependencies have been updated.

#### 29 March 2024 - Enhancement - FieldControl 2.10.6 - Added the possibility to locally disable the Bot features through the app settings [ID 39113]

It is now possible to locally disable the *Bot* feature in the *App settings* file of the FieldControl DxM. 

To do so, set *Bot:IsDisabled* to *true* in the app settings. On each server where DataMiner FieldControl is installed, navigate to `C:\Program Files\Skyline Communications\DataMiner FieldControl` and create or modify *appsettings.custom.json* with the following configuration:

```json
{
   "Bot": {
      "IsDisabled": true
   }
}
```

#### 13 March 2024 - Enhancement - FieldControl 2.10.5 - Dependencies updated [ID 39049]

Several dependencies have been updated.

#### 4 March 2024 - Enhancement - FieldControl 2.10.4 - Improved installer robustness [ID 38946]

The FieldControl installer has been updated to mitigate a Windows DLL redirection vulnerability and to improve its robustness.

#### 16 January 2024 - Enhancement - FieldControl 2.10.3 - Improved DxM status reporting [ID 38451]

The FieldControl DxM will now periodically send a health check to the cloud to indicate that the DxM is running using correct identifiers.

#### 20 December 2023 - New feature - FieldControl 2.10.0 - DxM status reporter added [ID 38116]

The FieldControl DxM will now periodically send a health check to the cloud to indicate that the DxM is running.

#### 8 November 2023 - Enhancement - FieldControl 2.9.1 [ID 37800]

Several dependencies have been updated.

#### 11 August 2023 - Enhancement - FieldControl 2.9.0 - Upgrade to .NET 6 [ID 37109]

DataMiner FieldControl has been upgraded to .NET 6, so that it no longer depends on .NET 5. **Make sure .NET 6 is installed** before you upgrade to this version.

#### 19 April 2023 - Enhancements -  FieldControl 2.8.3 - General improvements [ID 36162]

Changes have been implemented in DataMiner FieldControl to improve its general stability.

#### 9 December 2022 - Enhancement - FieldControl 2.8.2 - Dependencies updated [ID 35140]

Several dependencies were updated. This includes security-related improvements.

This enhancement is included in Cloud Pack 2.8.3.

#### 9 September 2022 - Fix - FieldControl 2.8.1 - Teams bot not working [ID 34374]

In some cases, it could occur that the DataMiner Teams bot stopped working correctly and responded to commands with an error message.

With FieldControl 2.8.1 (included in Cloud Pack version 2.8.2), this issue will no longer occur.
