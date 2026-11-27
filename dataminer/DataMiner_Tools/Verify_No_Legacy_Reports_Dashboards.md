---
uid: Verify_No_Legacy_Reports_Dashboards
description: "Learn about the Verify No Legacy Reports Dashboards prerequisite check and how to resolve it before upgrading DataMiner."
---

# Verify No Legacy Reports Dashboards

From DataMiner 10.4.0/10.4.1 onwards<!--RN 37922-->, the *VerifyNoLegacyReportsDashboards* prerequisite check is included in upgrade packages.

Select the tab for the DataMiner version you are upgrading to.

## [DataMiner 10.7.x or higher](#tab/soft-launch-check)

From DataMiner 10.7.0/10.7.1 onwards<!-- RN 47135 -->, this prerequisite check verifies whether the [*LegacyReportsAndDashboards* soft-launch option](xref:Overview_of_Soft_Launch_Options#legacyreportsanddashboards) is disabled. The check is skipped if the **currently installed DataMiner version** is 10.7.0/10.7.1 or higher.

From this version onwards, the [legacy Reporter](xref:reporter) and [legacy Dashboards](xref:dashboards) modules are **End of Life** and can no longer be enabled with a soft-launch option.<!-- RN 47135+47136 --> Use the [Dashboards app](xref:newR_D) instead.

**If the soft-launch option is enabled**, the prerequisite blocks the upgrade. To resolve this:

1. Migrate any required legacy reporting and dashboard functionality to the [Dashboards app](xref:newR_D).

   > [!CAUTION]
   > Both full and web-only upgrades permanently delete your legacy reports and dashboards by removing `C:\Skyline DataMiner\Webpages\Reports\` and `C:\Skyline DataMiner\Webpages\Dashboards\` and their contents. Downgrading DataMiner will not restore the deleted content. Modern dashboards and `C:\Skyline DataMiner\Reports\` are unaffected.

1. Remove the [*LegacyReportsAndDashboards* soft-launch option](xref:Overview_of_Soft_Launch_Options#legacyreportsanddashboards) from `C:\Skyline DataMiner\SoftLaunchOptions.xml`.

   The prerequisite does not modify the configuration automatically.

1. Retry the upgrade.

Malformed XML or file-access errors also block the upgrade. If the check reports such an error, correct the configuration or file permissions before retrying.

## [Earlier DataMiner versions](#tab/legacy-content-check)

This prerequisite checks for existing legacy reports and dashboards. From DataMiner 10.4.8/10.5.0 onwards<!-- RN 39964 -->, this check is skipped if the **currently installed DataMiner version** is 10.4.0/10.4.1 or higher.

**If the check fails**, there are still legacy reports or dashboards on your system:

- If you no longer need the legacy modules, delete the `C:\Skyline DataMiner\Webpages\Dashboards\db\` folder and `C:\Skyline DataMiner\Webpages\Reports\Templates\Templates.xml`.

  > [!NOTE]
  > Other DataMiner modules, such as Automation, Scheduler, and Visual Overview, may also make use of these.

- If you still need the legacy modules and are upgrading to a version earlier than DataMiner 10.7.0/10.7.1, set the [*LegacyReportsAndDashboards* soft-launch option](xref:Overview_of_Soft_Launch_Options#legacyreportsanddashboards) to *true*, run `C:\Skyline DataMiner\Tools\ConfigureIIS.bat` as Administrator, and restart the DataMiner Agent.

***

> [!TIP]
> See also: [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement)
