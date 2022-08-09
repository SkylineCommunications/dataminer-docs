---
uid: Granting_admin_consent
---

# Granting admin consent

In order to use the Chat Integration functionality for Microsoft Teams, admin consent has to be granted for some permissions, e.g. to create Teams, Channels and add members to a Team. After consent is granted, the Microsoft tenant has to be configured for your Cloud Connected organization.

To grant admin consent and configure your tenant:

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector in the top-right corner and select the organization in the list.

   ![Organization selector](~/user-guide/images/CloudAdmin_Selector.png)

1. In the sidebar on the left, go to *Organization* > *Overview*.

1. Click the *Grant Admin Consent* button. This will redirect you to the admin consent endpoint from Microsoft to grant consent for the required permissions.

    ![Admin Consent](~/user-guide/images/CloudAdmin_Admin_Consent.png)

    > [!NOTE]
    > In order to grant tenant-wide consent you have to be an administrator from that tenant, e.g. Global Administrator.

1. Review the requested permissions, and if you agree, click the *Accept* button.

1. After clicking *Accept*, you will be redirected to a configuration screen where you can link your Microsoft tenant with your organization.

    ![Tenant Configuration](~/user-guide/images/CloudAdmin_Tenant_Configuration.png)

1. When clicking *Confirm*, a popup will be shown where you can login to our multi-tenant app with your Microsoft account. After logging in successfully, your tenant is configured.

    > [!NOTE]
    > Make sure to login with the same user as you granted consent with.
