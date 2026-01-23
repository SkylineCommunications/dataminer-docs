---
uid: investigating_dataminer_services_login_issues
description:
keywords: login, cloud login, dataminer.services, issues
---

# Investigating dataminer.services login issues

## Make sure your time is set correctly

Often when login issues are caused by time-outs, it's because the time is set incorrectly on the device you are using.

## Having trouble signing in with your Microsoft account?

When you want to log in using your existing corporate Microsoft account, the following notification may be shown:

![Need admin approval](~/dataminer/images/dataminerservices_need_admin_approval.png)

If you see this, you should contact your IT department, so they can approve the access to the required resources. They will only have to give consent once. When this is done, this message will no longer be shown.

There are two options for your IT department to give consent:

- They can go to dataminer.services and go through the normal process of registering an account.
- They can use use the following link to directly give consent to our application:

  `https://login.microsoftonline.com/{tenant-id}/adminconsent?client_id=2e25a456-a261-44cf-beb8-06da7f5199f5`

  In this link, `{tenant-id}` is your organization's tenant ID or any verified domain name.

In both cases, it is important to select the checkbox *Consent on behalf of your organization*. Selecting this also automatically allows access for regular users in the organization.

![Request for permissions](~/dataminer/images/dataminerservices_consent_on_behalf_of_organization.png)

If the window shown above is not displayed, make sure an account is used that has the **Global Administrator** role in Azure.

These are the only things to which access is needed:

- `openid - https://graph.microsoft.com/openid`

  Allows users to sign in to the app with their work or school accounts, and allows the app to see basic user profile information.

- `offline_access - https://graph.microsoft.com/offline_access`

  Allows the app to see and update the data you gave it access to, even when users are not currently using the app. This does not give the app any additional permissions.

> [!TIP]
> For more information, refer to the following Microsoft documentation pages:
>
> - [Consent experience for applications in Microsoft Entra ID](https://learn.microsoft.com/en-us/entra/identity-platform/application-consent-experience#common-consent-scenarios)
> - [Grant tenant-wide admin consent to an application](https://learn.microsoft.com/en-us/entra/identity/enterprise-apps/grant-admin-consent?pivots=portal)

## Contact support

If you have tried the procedures above, but the issues still persist, [contact DataMiner Support](xref:Contacting_tech_support).
