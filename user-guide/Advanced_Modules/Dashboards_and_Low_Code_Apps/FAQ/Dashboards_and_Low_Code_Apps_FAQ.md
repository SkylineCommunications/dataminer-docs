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
