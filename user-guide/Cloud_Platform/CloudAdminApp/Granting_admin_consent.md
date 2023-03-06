---
uid: Granting_admin_consent
---

# Granting admin consent for Teams actions

When the Microsoft Teams Chat Integration functionality is used, admin consent is required for certain actions, e.g. to create teams or channels, or to add members to a team.

After you have granted this consent, you will need to configure the Microsoft tenant for your dataminer.services organization.

To grant admin consent and configure your tenant:

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

   > [!TIP]
   > See also: [Accessing the Admin app](xref:Accessing_the_Admin_app)

1. If a different organization should be selected, click the organization selector ![Organization selector](~/user-guide/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the sidebar on the left, go to *Organization* > *Overview*.

1. Click the *Grant Admin Consent* button.

   This will redirect you to Microsoft's admin consent endpoint to grant consent for the required permissions.

   ![Admin consent](~/user-guide/images/CloudAdmin_Admin_Consent.png)

   > [!NOTE]
   >
   > - The displayed permissions may differ from the ones in the example screenshot above. Permissions can change when new features are released or existing features are modified.
   > - In order to grant tenant-wide consent, you have to be an administrator for that tenant, e.g. Global Administrator.

1. Review the requested permissions, and if you agree, click the *Accept* button.

1. After clicking *Accept*, you will be redirected to a configuration screen where you can link your Microsoft tenant with your organization.

   ![Tenant configuration](~/user-guide/images/CloudAdmin_Tenant_Configuration.png)

1. Click *Confirm*.

1. In the pop-up window, log in to our multi-tenant app with your Microsoft account. **Make sure to log in with the same user as you granted consent with**.

   After you log in successfully, your tenant is configured.

> [!NOTE]
>
> - You can **revoke the permissions given to Skyline at any time in the Azure Portal**. For more information, refer to the [Microsoft documentation](https://docs.microsoft.com/en-us/azure/active-directory/manage-apps/manage-application-permissions?pivots=portal).
> - You can unlink the tenant by clicking the x next to the tenant ID. However, **unlinking the tenant** from the organization **will not remove the permissions given to Skyline**.
> - If there are **changes to the software** that cause new or different permissions to be required, you will need to **repeat** the grand admin consent procedure in order to also provide consent for those permissions. You can do this by **unlinking** your tenant first.
