---
uid: Configuring_dashboard_access_rights
---

# Configuring dashboard access rights

> [!IMPORTANT]
> This information is applicable to the DMS Dashboards module, which is being retired as of DataMiner version 10.4.x. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement). For more information on the Dashboards web app available from DataMiner 9.6.9 onwards, see [Dashboards app](xref:newR_D).

To configure access to dashboards:

1. Open the dashboard overview, either using DataMiner Cube or Dashboard Gateway.

    > [!NOTE]
    > Make sure you log in with a user account that has at least the rights “Dashboards: Edit” and “Security: Changing Settings”.

2. Click the downward triangle next to *Home*, and select *Configure Security*.

3. Either select a folder under *Folder security* or select a dashboard under *Dashboard security*.

    When you use *Folder security*, all the dashboards in that folder have the same security rules. With *Dashboard security*, the rules are configured for one dashboard at a time.

4. Click the *Edit Security* button next to the selected folder or dashboard.

5. Add the users who are allowed to use a particular dashboard or folder to the *Allow* column with the *\<* button. Remove users who are not allowed access by means of the *\>* button.

6. If necessary, add users who are denied access to the *Denied* column with the *\<* button. Remove users who are not denied access by means of the *\>* button.

    > [!NOTE]
    > “Deny” rules always take precedence over “Allow” rules. Therefore, if a user is allowed access to a folder, but denied access to a specific dashboard, this dashboard will not be available in their list.

7. Click the downward triangle at the top of the screen again, and repeat the procedure until all necessary access rules have been specified.
