---
uid: Logging_on_to_the_Dashboards_App
---

# Logging on to the Dashboards App

> [!IMPORTANT]
> This information is applicable to the DMS Dashboards module, which is being retired as of DataMiner version 10.4.x. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement). We recommend using the [Dashboards app](xref:newR_D) instead.

In most cases, logging on to the *Dashboards* App is similar to logging on to DataMiner Cube. See [Logging on to DataMiner Cube](xref:Logging_on_to_DataMiner_Cube).

However, there are some differences:

- In the *Dashboards* App, users can not only log on with their regular username, but also with the email address that has been configured in their DataMiner user profile.

  > [!TIP]
  > See also: [Managing users](xref:Managing_users)

- By default, the *Dashboards* app in DataMiner Cube makes use of Windows authentication. So, when you log on to DMS Dashboards with a Windows user account onto a server on which two-step authentication is enabled, no challenge will be presented since validation is done by Windows.

  However, two-step authentication can be enabled by using a Dashboard Gateway, or by disabling Windows authentication in the web.config file. See [Activating two-step authentication](xref:Customizing_the_legacy_Dashboards_app#activating-two-step-authentication).
