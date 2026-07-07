---
uid: Dashboards_and_Low_Code_Apps_FAQ
---

# Frequently asked questions about Dashboards and Low-Code Apps

## What should I do if I get WebSocket errors when using Dashboards or Low-Code Apps?

When the DataMiner web applications are not able to use WebSocket communication, this will result in WebSocket errors in the browser console.

To resolve these:

- Make sure the *WebSocket Protocol* is installed and enabled in IIS. See [learn.microsoft.com](https://learn.microsoft.com/en-us/iis/configuration/system.webserver/websocket).

- Open the file `C:\Skyline DataMiner\Webpages\API\web.config`, and make sure the *targetFramework* attribute of the *httpRuntime* tag is set to 4.5 or higher. For example:

  `<httpRuntime executionTimeout="300" maxRequestLength="51200" targetFramework="4.6.2" />`

- Verify that no firewall or proxy is interfering with the setup of the WebSocket connection.

- Use a modern browser that supports WebSockets. The DataMiner web apps do not support Internet Explorer.

## What should I do if I do not see my protocol changes applied in a GQI query result?

If you have made protocol changes, but you do not see them reflected in your GQI query results, this is likely caused by GQI caching certain protocols for faster performance.

> [!IMPORTANT]
> This problem does **not** occur when the **GQI DxM** is used, as this invalidates the caches upon protocol changes. The approach below therefore only applies when using GQI in SLHelper.

To resolve this:

1. Launch your system's Task Manager utility.

1. Look through the list of processes for the *Skyline DataMiner Helper* process.

   This process is responsible for managing GQI.

1. Select the *Skyline DataMiner Helper* process and select to end it.

1. After terminating the process, refresh your dashboard or application.

   This will prompt GQI to fetch the latest protocol changes and display accurate query results.

## How can I embed the DataMiner web apps in a portal using a single sign-on experience?

To embed DataMiner web apps (e.g., dashboards or low-code apps) in a third-party portal with a seamless single sign-on (SSO) experience, keep the following requirements in mind:

- **Shared Identity Provider**: Both the portal and the hosting DataMiner Agent must use SAML authentication configured against the **same Identity Provider (IdP)**. Other Agents in the DataMiner System do not need to share this authentication flow, unless a load balancer is used.

- **Hosting Agent**: The DataMiner Agent hosting the web apps does not need to be a gateway; a regular DataMiner Agent is sufficient. However, it does need to use SAML authentication through the same IdP as the portal (see above).

- **Different domain or host names**: The portal and the hosting DataMiner Agent must be served from **different domain or host names**. This is required for the browser to correctly apply cross-origin security restrictions.

- **iframe sandbox attribute**: The `<iframe>` element used to embed the web app must **not** have the `sandbox` attribute set. Because the embedded page originates from a different domain, the browser already applies the necessary cross-origin restrictions automatically. The hosting Agent's webpage can still read its own authentication cookie because that access is same-origin.
