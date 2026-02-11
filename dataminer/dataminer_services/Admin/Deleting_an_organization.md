---
uid: Deleting_an_organization
keywords: temporary organization
---

# Deleting an organization

Often, temporary organizations are created as sandbox environments with a [trial DaaS](xref:Creating_a_DMS_on_dataminer_services) system. However, to keep your organization selector clean and avoid unnecessary clutter, you may want to remove these again.

> [!CAUTION]
> Deleting an organization has significant consequences. All users will lose access, all keys associated with the organization will stop working, and any **remaining credits will be lost**.

## Prerequisites

- Only users with the **Owner** role on dataminer.services for an organization can delete it.

- To avoid accidental deletion of a production organization, an organization can only be deleted if it **does not contain any active systems**.

  If your organization only contained a [trial DaaS](xref:Creating_a_DMS_on_dataminer_services) system, the system will be automatically decommissioned and removed after one week. Any other systems in the organization must be [deleted manually](xref:Removing_a_DaaS_system) before you can remove the organization.

## Procedure

1. In the [Admin app](xref:Accessing_the_Admin_app), verify that the correct organization is displayed in the header bar.

1. If you need to switch organizations, click the organization selector ![Organization selector](~/dataminer/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the correct organization.

1. In the pane on the left, under *Organization*, open the *Settings* page.

1. At the bottom of the page, click the **Delete organization** button.

   ![Delete organization](~/dataminer/images/Cloud_Delete_Organization.png)

   If you are not the Owner, or if the organization still contains systems, this button will not be available. Hover your mouse pointer over the button to see the exact reason. Fix the issue and refresh the page to continue.

1. Confirm the deletion by typing the organization name exactly as written, including capitalization.

1. Click **Delete** to finalize the deletion.
