---
uid: Deleting_a_dashboard
description: "Find out how to delete a dashboard in the DataMiner Dashboards app and how to remove orphan dashboards directly from the server if necessary."
---

# Deleting a dashboard

To delete a dashboard in the Dashboards app:

1. In the list of dashboards on the left, select the dashboard you want to delete.

1. Right-click the dashboard and select *Delete*.

1. In the confirmation box, click *Delete* or *OK*, depending on your DataMiner version<!--RN 38278-->.

> [!NOTE]
> To delete a dashboard, you need **edit access** to that dashboard. However, this means that if the only user with edit access to a dashboard is no longer a DataMiner user, the dashboard can no longer be deleted from the user interface. Instead, you can delete such orphan dashboards directly from the server:
>
> 1. On the DataMiner Agent, navigate to `C:\Skyline DataMiner\dashboards` and delete the applicable `[dashboardname].json` files (making sure to leave `security.json` intact).
> 1. If you have a DataMiner System with multiple Agents, repeat this on each DMA.
