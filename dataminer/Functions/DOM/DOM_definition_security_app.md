---
uid: DOM_definition_security_app
---

# DOM definition-level security app

<!-- RN 43622 -->

From DataMiner 10.5.11/10.6.0 onwards, an app is available where you can configure definition-level security settings for DOM. In the background, this will make use of the [link security](xref:DOM_security#link-security) feature.

![DOM definition-level security app](~/dataminer/images/DOMSecurityApp.png)<br>*DOM definition-level security app in DataMiner 10.5.11*

## Accessing the DOM definition-level security app

If you have the required user permission ([Modules > System configuration > Object Manager > Module settings](xref:DataMiner_user_permissions#modules--system-configuration--object-manager--module-settings)), you can access this app in either of the following ways:

- Browse to `https://<DMA IP or hostname>/dom`.

- In DataMiner Cube, go to *System Center* > *DOM*.

  If you are using a [remote access URL](xref:Cloud_Remote_Access_URL), you will then need to click a link to open the app in a browser. With a regular Cube connection, the app is shown directly in DataMiner Cube.

> [!NOTE]
> The app can also be embedded in a low-code app to allow direct access from within that low-code app. To do so, use a URL like `https://<DMA IP or hostname>/dom/#/?embed=true` in a [Web component](xref:DashboardWeb). You can also make the embedded app show specific DOM modules by adding the IDs of those modules in the URL, for example: `https://<DMA IP or hostname>/dom/#/?embed=true&moduleIds=myDomModule1,myDomModule2,myDomModule3`.

## Configuring security using the app

The app displays all available DOM modules in a list on the left, with a filter box at the top so you can quickly find the module you are looking for.

By default, all users will have full access to all DOM modules, which means that they will all be allowed to create, read, update, and delete DOM definitions in all available DOM modules.

To restrict access for specific definitions:

1. Select the module, and switch to *Restrict access* with the button on the right.

   At this point, no one will have access to the definitions in the module. The list of DOM definitions within the module will expand so you can select a definition.

1. Select a definition and switch the groups with users that need to be able to read, update, and delete that DOM definition to *Full Access*.

1. Repeat this for each definition users should have access to.

1. In the lower-right corner, click *Apply* to save your changes.

   If the *Apply* button is not available yet, this means that at least one DOM module still has invalid settings. To correct this, make sure that for each module at least one user group has full access to at least one definition in that module.

> [!NOTE]
> When changes are applied to the security configuration of a DOM module, that module will be reinitialized.
