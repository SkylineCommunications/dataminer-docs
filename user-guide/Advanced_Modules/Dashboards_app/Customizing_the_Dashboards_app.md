---
uid: Customizing_the_Dashboards_app
---

# Customizing the Dashboards app

The following advanced customization is possible for the redesigned Dashboards app:

- [Configuring the maximum JSON length](#configuring-the-maximum-json-length)

> [!NOTE]
> This customization does not influence the legacy Dashboards app. For information on advanced settings to customize the legacy app, see [Customizing the legacy Dashboards app](xref:Customizing_the_legacy_Dashboards_app).

## Configuring the maximum JSON length

From DataMiner 10.0.0/10.0.1 onwards, it is possible to configure the maxJSONLength setting, which is used when WebSocket messages are serialized and deserialized. By default, this is set to 20 MiB.

To customize this setting:

1. Open the *Web.config* file located in the *C:\\Skyline DataMiner\\Webpages\\API* folder.

1. Make sure that the *configuration.appSettings* section contains an element similar to the following example:

   ```xml
   <add key="maxJsonLength" value="?10485760?" />
   ```

   Note that the value should be specified in bytes. In the example above, maxJSONLength was set to 10 MiB.
