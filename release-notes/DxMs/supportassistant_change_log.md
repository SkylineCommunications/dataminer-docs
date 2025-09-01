---
uid: supportassistant_change_log
---

# Support Assistant change log

#### 1 September 2025 - Fix - SupportAsistant 1.7.7 - CDMR reporting & usage offloading issues

An issue introduced in SupportAssistant 1.7.4 caused the CDMR reporting for proactive support and usage offloading to fail in case the server had no direct internet access instead of routing the request via the CloudGateway. This issue has been resolved and the affected versions have been unlisted.

#### 27 August 2025 - Enhancement - SupportAsistant 1.7.6 - General improvements

General improvements have been made.

#### 24 June 2025 - Enhancement - SupportAsistant 1.7.5 - Improved upgrade process

Improvements have been made to the startup and shutdown of the DxM, which improves the upgrade process.

#### 17 June 2025 - Enhancement - SupportAsistant 1.7.4 - Improved upgrade process

Improvements have been made to the shutdown of the DxM, which improves the upgrade process.

#### 1 April 2025 - Enhancement - SupportAsistant 1.7.3 - Dependencies updated [ID 42658]

Several dependencies have been updated.

#### 20 February 2025 - Fix - SupportAssistant 1.7.2 - Reports not uploaded when reports and notifications folder was missing [ID 42197]

Up to now, if the reports and notifications folder did not exist when Support Assistant started, new reports were never uploaded until the service was restarted. The folder will now be created to ensure that reports can be uploaded immediately.

#### 20 February 2025 - Enhancement - SupportAssistant 1.7.2 - Offloading of logs/metrics of the GQI DxM [ID 41893]

The files from the following folders will now also be added to the offloads zip package:

- `C:\ProgramData\Skyline Communications\DataMiner GQI\Metrics`
- `C:\ProgramData\Skyline Communications\DataMiner GQI\Logs`

#### 30 October 2024 - Enhancement - SupportAssistant 1.7.1 - Include SLAutomation_BAK.txt in file offloads [ID 41281]

From now on, the SLAutomation_BAK.txt file is also included in the file offloads.

#### 30 October 2024 - Enhancement - SupportAssistant 1.7.1 - Temporary file location changed [ID 41281]

From now on, the `%Temp%` folder will be used instead of `C:\Skyline_Data` for temporary files like remote log collection packages or file offloads for proactive support.

#### 30 October 2024 - Enhancement - SupportAssistant 1.7.1 - Dependencies updated [ID 41281]

Several dependencies have been updated.

#### 8 August 2024 - Enhancement - SupportAssistant 1.7.0 - Upgrade to .NET 8 [ID 40440]

DataMiner SupportAssistant has been upgraded to .NET 8. **Make sure .NET 8 is installed** before you upgrade to this version.

#### 25 July 2024 - Enhancement - SupportAssistant 1.6.10 - Dependencies updated & event handling improved [ID 40307]

Several dependencies have been updated. In combination with CloudGateway 2.13.15, events rejected by dataminer.services will no longer be retried and will be discarded.

#### 11 July 2024 - Enhancement - SupportAssistant 1.6.10 - Offloading of GQI and web logs/metrics [ID 39426]

The files from the following folders will now be added to the offloads zip package:

- `C:\Skyline DataMiner\Logging\GQI`
- `C:\Skyline DataMiner\Logging\GQI\Metrics`
- `C:\Skyline DataMiner\Logging\Web`
- `C:\Skyline DataMiner\Logging\Web\Client`

Files from these folders will end up in the zip file with the following file names:

- GQI_log\<TimeStamp>.txt
- GQI_metrics\<TimeStamp>.txt
- Web_web\<TimeStamp>.log
- Web_web.clientmetric\<TimeStamp>.log

#### 26 April 2024 - Fix - SupportAssistant 1.6.9 - Inconsistent cloud endpoint detection failures [ID 39514]

An issue has been resolved that could make features like Remote Log Collection and data offloads for proactive support inconsistently fail.

#### 13 March 2024 - Enhancement - SupportAssistant 1.6.8 - Dependencies updated [ID 39050]

Several dependencies have been updated.

#### 4 March 2024 - Enhancement - SupportAssistant 1.6.7 - Improved installer robustness [ID 38945]

The SupportAssistant installer has been updated to mitigate a Windows DLL redirection vulnerability and to improve its robustness.

#### 16 February 2024 - Enhancement - SupportAssistant 1.6.6 - Additional data offload for proactive monitoring [ID 38797]

From now on, the SLClient log file will be offloaded for proactive monitoring via CDMR.

#### 30 January 2024 - Enhancement - SupportAssistant 1.6.5 - Improved DxM status reporting [ID 38608]

The SupportAssistant DxM will now offload information about the used version of the log collector.

#### 16 January 2024 - Enhancement - SupportAssistant 1.6.4 - Improved DxM status reporting [ID 38448]

The SupportAssistant DxM will now periodically send a health check to the cloud to indicate that the DxM is running using correct identifiers.

#### 20 December 2023 - Enhancement - SupportAssistant 1.6.1 - Additional data offloaded for proactive monitoring [ID 38250]

From now onwards, additional data like soft-launch options, installed solutions, manager configurations, and BPA test results will also be offloaded for proactive monitoring via CDMR.

#### 20 December 2023 - New feature - SupportAssistant 1.6.0 - DxM status reporter added [ID 38174]

The SupportAssistant DxM will now periodically send a health check to the cloud to indicate that the DxM is running.

#### 17 November 2023 - Enhancement - SupportAssistant 1.5.3 - Potential memory leak [ID 37843]

When SupportAssistant 1.5.2 or older was installed, a memory and disk space leak could occur for systems that were not connected to dataminer.services or for systems with an invalid dataminer.services connection configuration or setup. This has now been resolved.

#### 8 November 2023 - Enhancement - SupportAssistant 1.5.2 [ID 37797]

Several dependencies have been updated.

#### 2 November 2023 - Fix - SupportAssistant 1.5.1 - Issue when hosting server of DataMiner CloudGateway had more than one NIC [ID 37770]

When SupportAssistant 1.5.1 or earlier was used, it could occur that remote log collection failed when uploading the package in case the CloudGateway module was installed on a server with more than one network interface (NIC). This has now been resolved.

Make sure to also install DataMiner CloudGateway 2.12.3 to make use of this fix.

#### 11 August 2023 - Enhancement - SupportAssistant 1.5.0 - Upgrade to .NET 6 [ID 37099]

DataMiner SupportAssistant has been upgraded to .NET 6, so that it no longer depends on .NET 5. **Make sure .NET 6 is installed** before you upgrade to this version.

#### 28 June 2023 - Enhancement - SupportAssistant 1.4.0 - Improved offloading of reports and notifications [ID 36726]

To improve the maintenance and support experience, offloading of reports and notifications generated by SLWatchDog to dataminer.services is now implemented in a different manner.

Because of this, you will need to upgrade to SupportAssistant 1.4.0 in order to keep this feature available, as the previous implementation (available since SupportAssistant 1.3.1) is now obsolete.

#### 15 May 2023 - Enhancement - SupportAssistant 1.3.3 - Connection improvements [ID 36419]

A retry mechanism has been implemented to fetch the cloud endpoint. If after the retries, still no cloud endpoint can be received, the module will fall back to trying to access dataminer.services directly. If this is not possible, the module will log the failed actions.

#### 3 May 2023 - Fix - SupportAssistant 1.3.2 - Fixed incorrect timeout for Remote Log Collection uploads [ID 36311]

An issue has been resolved where Remote Log Collection could incorrectly time out after 100 seconds of uploading.

#### 21 April 2023 - Enhancements - SupportAssistant 1.3.1 - General improvements and offloading of reports and notifications [ID 35482] [ID 35485] [ID 35492] [ID 35559] [ID 35756] [ID 36152] [ID 36201]

Changes have been implemented in DataMiner SupportAssistant to improve its general stability.

In addition, this DxM now takes care of offloading reports and notifications generated by SLWatchDog to dataminer.services to improve the maintenance and support experience.

You can disable the offloading of reports and notifications by overriding the entries from *FileWatcherOptions:Configs* in the app settings with an empty array. To do so, on each server where DataMiner SupportAssistant is installed, in the folder `C:\Program Files\Skyline Communications\DataMiner SupportAssistant`, create or adjust the override *appsettings.custom.json* with the following contents:

```json
{
   "FileWatcherOptions": {
      "Configs": []
   }
}
```

> [!NOTE]
>
> - At present, this feature runs in parallel with the old method of offloading via an SMTP server. This old method of offloading cannot yet be disabled.
> - For this feature to work, traffic must be allowed via port 5100 on the internal network, and DataMiner CloudGateway 2.10.0 or higher must be installed.

> [!IMPORTANT]
> If you disable offloading of reports and notifications via DataMiner SupportAssistant, Skyline will not be able to provide maintenance and support.

#### 24 January 2023 - Fix - SupportAssistant 1.2.1 - Log Collector continuously triggered after failing to generate files [ID 35457]

In some rare cases, if invalid arguments were passed to the Log Collector so that it could not generate files, it could occur that the Log Collector kept getting triggered by the SupportAssistant DxM. Now the SupportAssistant will stop after a specific number of attempts.

This fix is included in Cloud Pack 2.8.5.

#### 10 January 2023 - Enhancement - DataMiner SupportAssistant 1.2.0 - Various stability improvements [ID 35349]

Various general stability improvements have been implemented. In addition, eventing has been added to dataminer.services, so that the Skyline Support Team can follow up on the status of remote log collection.

This enhancement is included in Cloud Pack 2.8.4.

#### 19 December 2022 - Fix - SupportAssistant 1.1.1 - Log collection triggered too often [ID 35158]

A problem with the SupportAssistant could cause the Log Collector to be triggered again and again, which could make it use up a lot of disk space.

This fix is included in Cloud Pack 2.8.3.

#### 8 December 2022 - New feature - SupportAssistant 1.1.0 - Remote Log Collection [ID 34681] [ID 34875] [ID 34928] [ID 34934] [ID 34954] [ID 34992]

This feature also requires Cloud Gateway 2.10.0 or higher.

A new DataMiner Cloud Pack 2.8.2 has been released, which enables the [Remote Log Collection](xref:RemoteLogCollection) feature. The DataMiner Cloud Pack can be found on [DataMiner Dojo](https://community.dataminer.services/downloads/).

With remote log collection, the packages generated by the [Log Collector tool](xref:SLLogCollector) are automatically transferred to secure storage in the cloud. This gives the experts at Skyline Communications immediate access to these packages, so that they can collect DataMiner log and memory dump files independently, increasing efficiency of investigations.
