---
uid: Deleting_an_organization
---

# Temporary organizations

Temporary organizations are typically created as sandbox environments, often using a [trial DaaS](xref:Creating_a_DMS_on_dataminer_services).

If you no longer need a temporary organization, you may want to delete it to keep your organization selector clean and avoid unnecessary clutter.

> [!NOTE]
> Deleting an organization has significant consequences. All users will lose access, all keys associated with the organization will stop working, and any remaining credits will be lost.

# Roles and precautions

Only users with the **Owner** role on dataminer.services for the organization can delete it.

To avoid accidental deletion of your production organization, an organization must not contain any active systems before it can be deleted.

If your organization only contained a [trial DaaS](xref:Creating_a_DMS_on_dataminer_services), the system will be automatically decommissioned and removed after one week. For all other systems, you must first [delete them manually](xref:Removing_a_DaaS_system).

# Deletion process

1. In the [Admin app](xref:Accessing_the_Admin_app), verify that the correct organization is displayed in the header bar.

1. If you need to switch organizations, click the organization selector ![Organization selector](~/dataminer/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the correct organization.

1. In the left-hand sidebar, under *Organization*, open the *Settings* page.

1. Click the **Delete organization** button.

   ![Delete organization](~/dataminer/images/Cloud_Admin_Selector_icon.png)

   > [!NOTE]
   > If you are not the Owner, or if the organization still contains systems, the button will be disabled.  
   > Hover over the button to see the exact reason.  
   > Fix the issue and refresh the page to continue.

1. After clicking the button, you will be shown a reminder that users will lose access and any remaining credits will be lost.  
   You must then confirm the action by typing the organization name exactly as written, including capitalization.

1. Click **Delete** to finalize the deletion.