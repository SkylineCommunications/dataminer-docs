---
uid: Deleting_a_dashboard
---

# Deleting a dashboard

1. In the list of dashboards on the left, select the dashboard you want to delete.

1. Right-click the dashboard and select *Delete*.

1. In the confirmation box, click *Delete* or *OK*, depending on your DataMiner version<!--RN 38278-->.



# Deleting an orphan dashboard

Only users with edit access to a dashboard can delete it.  If that user is no longer a dataminer user there is no Delete option in the Right-click menu.

To delete them from the server:

1. On the Dataminer Agent navigate to C:\Skyline DataMiner\dashboards and delete the applicable [dashboardname].json files (making sure to leave security.json intact)

1. If you have a Dataminer System with multiple agents this will need to be repeated on each dma.
