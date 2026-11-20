---
uid: Verify_No_Legacy_Reports_Dashboards
description: "Learn about the Verify No Legacy Reports Dashboards prerequisite check and how to resolve it before upgrading DataMiner."
---

# Verify No Legacy Reports Dashboards

From DataMiner 10.4.0/10.4.1 onwards<!--RN 37922-->, the *VerifyNoLegacyReportsDashboards* prerequisite check is included in upgrade packages.

Select the tab for the DataMiner version you are upgrading to.

## [Before DataMiner 10.7.x](#tab/legacy-content-check)

This prerequisite checks for existing legacy reports and dashboards. From DataMiner 10.5.0/10.4.8 onwards<!-- RN 39964 -->, this check is skipped if the **currently installed DataMiner version** is 10.4.0 or higher.

**If the check fails**, there are still legacy reports or dashboards on your system:

- If you no longer need the legacy modules, delete the `C:\Skyline DataMiner\Webpages\Dashboards\db\` folder and `C:\Skyline DataMiner\Webpages\Reports\Templates\Templates.xml`.

  > [!NOTE]
  > Other DataMiner modules, such as Automation, Scheduler, and Visual Overview, may also make use of these.

- If you still need the legacy modules, set the [*LegacyReportsAndDashboards* soft-launch option](xref:Overview_of_Soft_Launch_Options#legacyreportsanddashboards) to *true*, run `C:\Skyline DataMiner\Tools\ConfigureIIS.bat` as Administrator, and restart the DataMiner Agent. This only works if the upgrade version still includes the legacy modules.

## [From DataMiner 10.7.x](#tab/soft-launch-check)

From DataMiner 10.7.0/10.7.1 onwards<!-- RN 47135 -->, this prerequisite checks whether the [*LegacyReportsAndDashboards* soft-launch option](xref:Overview_of_Soft_Launch_Options#legacyreportsanddashboards) is disabled. The check is skipped if the **currently installed DataMiner version** is 10.7.0 or newer.

The check reads the option from the `SLNet` section of `C:\Skyline DataMiner\SoftLaunchOptions.xml`.

From this version onwards, the [legacy Reporter](xref:reporter) and [legacy Dashboards](xref:dashboards) modules are **End of Life** and can no longer be enabled with a soft-launch option.<!-- RN 47135+47136 --> Use the [Dashboards app](xref:newR_D) instead.

**If the soft-launch option is enabled**, the prerequisite blocks the upgrade. To resolve this:

1. Migrate any required legacy reporting and dashboard functionality to the [Dashboards app](xref:newR_D).

   > [!CAUTION]
   > Both full and web-only upgrades remove `C:\Skyline DataMiner\Webpages\Reports\` and `C:\Skyline DataMiner\Webpages\Dashboards\`, including their contents. Modern dashboards and `C:\Skyline DataMiner\Reports\` are unaffected.

1. Remove `LegacyReportsAndDashboards` from the `SLNet` section of `C:\Skyline DataMiner\SoftLaunchOptions.xml`.

   The prerequisite does not modify the configuration automatically.

1. Retry the upgrade.

Malformed XML or file-access errors also block the upgrade. If the check reports such an error, correct the configuration or file permissions before retrying.

***

> [!TIP]
> See also: [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement)
