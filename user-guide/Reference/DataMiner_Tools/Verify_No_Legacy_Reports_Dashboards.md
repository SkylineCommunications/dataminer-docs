---
uid: Verify_No_Legacy_Reports_Dashboards
---

# Verify No Legacy Reports Dashboards

From DataMiner 10.4.0/10.4.1 onwards<!--RN 37922-->, the *VerifyNoLegacyReportsDashboards* prerequisite check is included in upgrade packages. This check verifies that no legacy reports and legacy dashboards still exist on your DataMiner System before upgrading, as these will no longer work after the upgrade.

From DataMiner 10.4.0 onwards, the [legacy Reporter](xref:reporter) and [legacy Dashboards](xref:dashboards) modules are *End of Life*. These have been replaced by the [Dashboards app](xref:newR_D).

> [!TIP]
> See also: [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement)

## Fixing a failing prerequisite check

If the *VerifyNoLegacyReportsDashboards* check fails, there are still legacy reports and dashboards on your system.

- If you no longer need the legacy Reporter and Dashboards modules, remove any existing legacy reports and legacy dashboards by deleting the `C:\Skyline DataMiner\Webpages\Dashboards\db\` folder as well as `C:\Skyline DataMiner\Webpages\Reports\Templates\Templates.xml`.

  > [!NOTE]
  > Other DataMiner modules, such as Automation, Scheduler, and Visual Overview, may also make use of these.

- If you still rely on certain functionality and want to keep on using the legacy Reporter and Dashboards modules, set the [*LegacyReportsAndDashboards* soft-launch option](xref:Overview_of_Soft_Launch_Options#legacyreportsanddashboards) to *true*, then run `C:\Skyline DataMiner\Tools\ConfigureIIS.bat` as Administrator, and restart the DataMiner Agent.
