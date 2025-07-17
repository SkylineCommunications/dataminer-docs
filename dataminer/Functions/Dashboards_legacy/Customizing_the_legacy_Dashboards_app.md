---
uid: Customizing_the_legacy_Dashboards_app
---

# Customizing the legacy Dashboards app

The legacy *Dashboards* app can be customized in several ways:

- [Activating two-step authentication](#activating-two-step-authentication)

- [Adding a custom provider logo](#adding-a-custom-provider-logo)

- [Customizing the memory cache size](#customizing-the-memory-cache-size)

> [!NOTE]
> These procedures only apply for the legacy Dashboards app, which is deprecated as of DataMiner 10.4.x. For information on customizing the current Dashboards app, see [Customizing the Dashboards app](xref:Customizing_the_Dashboards_app).

### Activating two-step authentication

By default, the *Dashboards* app in DataMiner Cube makes use of Windows authentication, so when you log on to DMS Dashboards with a Windows user account on a server where two-step authentication is enabled, no challenge will be presented since validation is done by Windows.

However, two-step authentication can be enabled by using a Dashboard Gateway, or by disabling Windows authentication in the web.config file. To do so:

1. Open the file `C:\Skyline DataMiner\webpages\Dashboards\web.config`.

1. Set the following tags as shown below:

   ```xml
   <formsAuthenticationWrapper enabled="true" />
   <windowsAuthentication enabled="false" />
   <anonymousAuthentication enabled="true" />
   ```

1. Save the file.

### Adding a custom provider logo

It is possible to configure the *Dashboards* app to show a custom provider logo. To do so:

1. Place a .jpg file displaying your logo in the folder `C:\Skyline DataMiner\Webpages\Dashboards`.

1. In the same folder, open the file *web.config*.

1. In the *web.config* file, in the tag configuration.dataminer.clusters.add, add the attributes *providedByUrl* and *providedByImage* as follows:

   ```xml
   <add id="local" connectionString="..." user="..." password="..." description="..." providedByUrl="http://provider/" providedByImage="image.jpg"/>
   ```

1. Save the file.

   As soon as you open or refresh the DMS Dashboards interface, the logo will now be shown in the top left corner, next to the DataMiner logo.

> [!NOTE]
> The maximum size for the image is 300x45 pixels. Larger images will be resized to fit within the allocated area.

### Customizing the memory cache size

When the Dashboards app requests protocols from the server, by default the 100 most recently used objects are cached. However, in some cases, it can be useful to override this default setting. For example, if a large number of users will need to use dashboards at the same time, to reduce the load on the CPU of the DMA, the memory cache size can be increased.

To modify the memory cache size:

1. Open the file `C:\Skyline DataMiner\webpages\Dashboards\web.config`.

1. In the web.config file, in the tag configuration.dataminer.clusters.add, add the attribute *memoryCacheSize* and set it to the desired value, as illustrated in the example below:

   ```xml
   <configuration>
     ...
     <dataminer appName="Dashboard">
       <clusters>
         <clear />
         <add id="local" connectionString="demoserver" user="" password="" description="Demo DataMiner" memoryCacheSize="500" />
       </clusters>
     </dataminer>
     ...
   </configuration>
   ```

1. Save the file.
