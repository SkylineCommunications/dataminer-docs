---
uid: LowCodeApps_earlier_version
---

# Retrieving an earlier version of a low-code app

When you make changes to an existing low-code app, the previous version will be kept in the system. Up to 15 versions of an app can be stored this way.

To go back to a previous version of a low-code app:

1. Open the application from the [DataMiner landing page](xref:Accessing_the_web_apps#dataminer-landing-page).

1. Access the version history of the app:

   - From DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 onwards<!--RN 40077-->, click the ellipsis button ("...") in the top-right corner and select *Versions*.

   - Prior to DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9, click the user icon in the top-right corner and select *Versions*.

   This will show the version history of the app.

   ![Version history](~/dataminer/images/Version_History.png)<br>*Low-Code App version history in DataMiner 10.4.12*

   - The currently published version, if any, is indicated with a green label. <!-- RN 32200 -->

   - The current draft is indicated with an orange label.

   - No label is displayed for old draft versions that were never published.

   - From DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12 onwards<!--RN 41034-->, version numbers are included in the version history as well.

1. Click the version you want to go back to. You can also click the pencil icon next to that version in the list to immediately start editing it.

> [!NOTE]
>
> - There can only be one published version of a specific application at the same time. If you publish a different version, the previous version will no longer be published.
> - When you roll back to a previous version of a low-code app, everything will revert to its state at the time of that version. This includes GQI queries, which are stored within the app version. Therefore, any changes you made to a GQI query or any new GQI queries created after that version will be lost if you revert.
