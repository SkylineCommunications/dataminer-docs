---
uid: Verify_No_Legacy_Reports_Dashboards
---

# Verify No Legacy Reports Dashboards

In DataMiner 10.4.0/10.4.1<!--RN 37922-->, the *VerifyNoLegacyReportsDashboards* prerequisite check is added to upgrade packages. This check verifies that no legacy reports and legacy dashboards still exist on your DataMiner System before upgrading, as these will no longer work after the upgrade.

From DataMiner 10.4.0 onwards, the [legacy Reporter](xref:reporter) and [legacy Dashboards](xref:dashboards) modules are *End of Life*. These have been replaced by the [Dashboards app](xref:newR_D).

> [!TIP]
> See also: [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement)

If the *VerifyNoLegacyReportsDashboards* check fails, refer to [Upgrade fails because of VerifyNoLegacyReportsDashboards.dll prerequisite](xref:KI_Upgrade_fails_VerifyNoLegacyReportsDashboards_prerequisite).
