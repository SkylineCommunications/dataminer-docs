---
uid: Dashboards_and_Low_Code_Apps
---

# Dashboards and Low-Code Apps

With the [Dashboards app](xref:newR_D) and [Low-Code Apps](xref:Application_framework) module, you can consolidate any data from your monitored system, so you can access it on any device.

Dashboards and low-code apps can be as simple or complex as you want, using [components](xref:Available_visualizations) that are configured in the same way across both modules. They are particularly useful for selectively [sharing specific data with third parties](xref:Sharing_a_dashboard), without the need to grant access to your entire system.

The main difference between a dashboard and a low-code app is that the latter can combine multiple "dashboards" in one application, with additional functionality: [actions can be triggered based on specific events](xref:LowCodeApps_event_config) (e.g. a user clicks a button, a page is loaded, a panel is closed, etc.), you can [configure panels](xref:LowCodeApps_panel_config) that can for instance be shown as a pop-up window or an overlay, and you can [incorporate menus and submenus into the header bar](xref:LowCodeApps_header_config).

From DataMiner 10.3.11/10.3.0 [CU8] onwards<!--RN 37413-->, whenever you [upgrade your DMA](xref:Upgrading_a_DataMiner_Agent) or install a [DataMiner web upgrade](xref:Upgrading_a_DataMiner_Agent#other-types-of-upgrades), an automatic backup of all existing dashboards and low-code apps on the system is generated and stored in *C:\Skyline DataMiner\System Cache\Web\Backups*. After the upgrade process, your dashboards and low-code apps may be migrated to ensure compatibility with the updated software version. If an error occurs during this migration, or if you need to perform a DataMiner downgrade, you can manually restore your dashboards and low-code apps from the backup.
