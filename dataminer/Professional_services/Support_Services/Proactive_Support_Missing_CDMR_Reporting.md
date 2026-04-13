---
uid: Proactive_Support_Missing_CDMR_Reporting
---

# Proactive Support - Missing CDMR Reporting

If the DataMiner [support application](xref:User_operations_support) detects that no reports have been received from your DataMiner System for more than one day, the automatic proactive support will kick in. This means that you will receive an email notifying you that there is an issue with the [CDMR](xref:CDMR) reporting, and a Collaboration task will be generated with the purpose of resolving this issue.

## What to do when you receive this notification?

### As the responsible person

If your system is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud):

1. Verify if this system is still valid (e.g., is this a test setup that has been removed or disabled?).

1. In case the system is no longer valid or in use, inform Skyline Tech Support that proactive support can be disabled.

   Aside from this, no further action is needed from you in this case.

1. In the [Admin app](https://admin.dataminer.services/), go to the *DxMs* page for the DataMiner System and verify the DxM status of the DataMiner Agent node.

   The *SupportAssistant* and *CoreGateway* DxMs are the most important for CDMR reporting, so check whether a green check mark is shown for these. If there is an issue with the DxMs, refer to [dataminer.services troubleshooting](xref:investigating_dataminer_services_feature_issues#check-if-all-dxms-are-running-and-up-to-date).

   ![DxMs overview](~/dataminer/images/DxMs_overview_Admin_app.png)

1. Check whether your system meets the [minimum requirements for remote log collection](xref:RemoteLogCollection#requirements).

1. If any of the DxMs listed in the Admin app need to be upgraded to meet the requirements, [upgrade the DxMs](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions).

   If you are unable to upgrade the DxMs with in the Admin app, install the [latest version of the DataMiner Cloud Pack](https://community.dataminer.services/dataminer-cloud-pack/).

If your system is **not** connected to dataminer.services:

1. Verify if mail reporting is enabled, as detailed under [Activating CDMR](xref:CDMR#activating-cdmr).

1. Check with your IT department to verify if mail reporting to Skyline Tech Support is still allowed.

### As a member of Skyline Tech Support

This type of notification will first go to Skyline Tech Support for verification. They will have to identify the root cause, and based on this different actions can be required.

- Verify the dataminer.services reporting flow:

  1. Verify whether the system is reporting via dataminer.services by opening the CDMR Agent element and navigating to the *General* page.

  1. Verify whether the system has a valid dataminer.services connection by navigating to [Skyline Admin](http://skyline-admin.dataminer.services/).

     Click the eye icon to view the DMS, and then check the status under *Cloud connection*. This should look like this:

     ![Skyline Admin: Cloud connection status](~/dataminer/images/Cloud_connection_status.png)

  1. Verify whether the system still exists and is still valid (e.g., the cloud coordination (DMS) ID and cloud node ID still exist).

  1. In the *DxMs* tab of the Skyline Admin tool, check the DxM status, especially for *DataMiner SupportAssistant* and *DataMiner CoreGateway*.

     ![Skyline Admin: DxM info](~/dataminer/images/Skyline_Admin_DxMs_info.png)

  1. In the *Support* tab, select the DataMiner Agent node that is no longer reporting and check if any errors are shown.

     ![Skyline Admin: Support info](~/dataminer/images/Skyline_Admin_Support_info.png)

  1. Follow the same steps as mentioned under [As the responsible person](#as-the-responsible-person).

  1. Send the notification with your findings to the main customer stakeholder configured in the Maintenance & Support contract and/or parent project so they can take the necessary actions to prevent issues.

- Verify the CDMR processing flow:

  1. Verify whether the dataminer.services flow is OK.

  1. Verify whether mail-only reporting is used.

  1. Send the notification to the Platform-Delivery team with your findings to verify why the reports are not processed.

- In case the main customer stakeholder is not configured, make sure the following is done or delegated:

  1. Identify the customer stakeholder on collaboration (e.g., confirm with the Product Owner).

  1. Configure the main customer stakeholder in the Maintenance & Support contract and/or parent project.

  1. Send the notification to the customer so they can take the necessary actions to prevent issues.
