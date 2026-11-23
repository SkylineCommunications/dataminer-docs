---
uid: Dashboards_and_Low_Code_Apps
description: With the Dashboards app, Low-Code Apps, and New Apps, you can consolidate any data from your monitored system, so you can access it on any device.
---

# Dashboards and Apps

With the [Dashboards app](xref:newR_D), [Low-Code Apps](xref:Application_framework), and [New Apps](xref:New_apps), you can consolidate any data from your monitored system, so you can access it on any device.

Apps created using the Low-Code Apps module and apps added through the New DataMiner Apps experience are both part of [DataMiner Apps](xref:DataMiner_Apps). These apps are accessible from the same places and share the same header bar, sign-in, and user permissions.

## New Apps

From DataMiner 10.6.0 [CU10]/10.7.0 [CU0]/10.7.1 onwards<!-- RN 45878 -->, you can also add apps using the [New DataMiner Apps experience](xref:New_apps). These apps are built outside DataMiner, for example with AI-assisted tooling, and are uploaded to your system. Low-Code Apps remain fully available, so you can choose the type of app that best suits your needs. See [Choosing between New Apps and Low-Code Apps](#choosing-between-new-apps-and-low-code-apps).

## Dashboards and Low-Code Apps

Dashboards and low-code apps can be as simple or complex as you want, using [components](xref:Available_visualizations) that are configured in the same way across both modules. They are particularly useful for selectively [sharing specific data with third parties](xref:Sharing_a_dashboard), without the need to grant access to your entire system.

The main difference between a dashboard and a low-code app is that the latter can combine multiple "dashboards" in one application, with additional functionality: [actions can be triggered based on specific events](xref:LowCodeApps_event_config) (e.g., a user clicks a button, a page is loaded, a panel is closed, etc.), you can [configure panels](xref:LowCodeApps_panel_config) that can for instance be shown as a pop-up window or an overlay, and you can [incorporate menus and submenus into the header bar](xref:LowCodeApps_header_config).

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 TIPS TO TAKE FLIGHT</b><br>
    More of a visual learner? Watch <a href="xref:Creating_a_completely_new_dashboard" style="color: #657AB7;">this short video</a> to see how a new dashboard can be created from scratch, or watch <a href="xref:Creating_custom_apps" style="color: #657AB7;">this video</a> to see a low-code app in action.
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>

## Choosing between New Apps and Low-Code Apps

|  | Low-Code Apps | New Apps |
|---|---|---|
| **How to create them** | In the DataMiner low-code editor, by configuring pages, components, and actions. | Outside DataMiner, for example with AI-assisted tooling. The finished app is then uploaded. |
| **Typical use** | Apps that you want to build and adjust directly in DataMiner, without writing code. | Apps that need a custom look and feel or functionality that goes beyond what the low-code editor offers. |
| **Editing** | In the low-code editor in DataMiner. | Outside DataMiner. You upload the updated app again. |

Low-Code Apps remain fully supported. New Apps are an additional option, not a replacement.

For more information, see [DataMiner Apps](xref:DataMiner_Apps), [Low-Code Apps](xref:Application_framework), and [New Apps](xref:New_apps).
