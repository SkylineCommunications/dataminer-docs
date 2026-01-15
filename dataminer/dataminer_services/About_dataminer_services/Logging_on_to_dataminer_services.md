---
uid: Logging_on_to_dataminer_services
description: Authenticate using a corporate email address linked to a Microsoft, Google, Amazon, or LinkedIn account, or create a dedicated account.
keywords: cloud logon, cloud log-on
reviewer: Alexander Verkest
---

# Logging on to dataminer.services

### Customers and DataMiner Strategic Partners

If you are a customer or a DataMiner Strategic Partner, you will need to authenticate yourself with your corporate email address when you access dataminer.services. This way, your dataminer.services account can be linked to your organization, so that you can access information that is exclusively available to authorized members of your organization (e.g. information related to your projects in the Collaboration app).

### Guests

It is also possible to access dataminer.services as a guest, i.e. someone who is neither a customer nor a DataMiner Strategic Partner. Guests can access a number of dataminer.services apps, such as the Dojo Community. While you can use any email address as a guest, we strongly encourage you to register with your corporate email address. Among others, this will allow you to keep your existing dataminer.services account should you ever become a customer or DataMiner Strategic Partner.

### Logging on

When you access <https://dataminer.services>, you will have the following options to authenticate yourself with your corporate email address:

- If your corporate email address is linked to a Microsoft (personal or work), Google, Amazon, or LinkedIn account, you can authenticate yourself via one of those identity providers. This option is to be preferred, as it will allow you to use an existing account rather than a new, dedicated one.

  > [!NOTE]
  > In case you are using the Microsoft login and get an error that says you need admin approval, below you can find [how your system administrator can resolve this](#having-trouble-signing-in-with-your-microsoft-account).

- If you cannot use an existing account, you can choose to create a dedicated dataminer.services account via the *Sign Up* option at the bottom. You will then be invited to enter your corporate email address and a password of your choice.

> [!NOTE]
>
> - Not all people who register with a corporate email address associated with your organization will automatically be granted access to all information that is exclusively available to your organization. This will only be the case for users who already had an account on the legacy dcp.skyline.be platform, i.e users who were already linked to your organization.
> - New people from your organization will have to create a user account on dataminer.services using their corporate email address (see above), which will then have to be linked to your organization. Currently, linking email addresses to organizations can only be done by Skyline staff on request. At a later time, we intend to provide you with an option to appoint an administrator in your organization, who will then be allowed to set up new dataminer.services accounts for your organization.

### Having trouble signing in with your Microsoft account?

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
