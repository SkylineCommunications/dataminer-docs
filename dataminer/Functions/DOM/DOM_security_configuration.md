---
uid: DOM_security_ui
---

# Configuring DOM security

<!-- RN 43622 -->

From DataMiner 10.5.11/10.6.0 onwards<!--RN 43622-->, you can configure definition-level security settings for DOM. From DataMiner 10.5.0 [CU12]/10.6.3 onwards<!--RN 44385-->, you can also configure security at DOM instance level. In the background, this will make use of the [link security](xref:DOM_security#link-security) feature.

![Configuring DOM security](~/dataminer/images/DOMSecurityApp.png)<br>*Configuring DOM security in DataMiner 10.6.9*

## Accessing the DOM security UI

If you have the required user permission ([Modules > System configuration > Object Manager > Module settings](xref:DataMiner_user_permissions#modules--system-configuration--object-manager--module-settings)), you can configure DOM security in either of the following ways:

- Browse to `https://<DMA IP or hostname>/dom`.

- In DataMiner Cube, go to *System Center* > *DOM*.

> [!NOTE]
> The UI can also be embedded in a low-code app to allow direct access from within that low-code app. To do so, use a URL like `https://<DMA IP or hostname>/dom/#/?embed=true` in a [Web component](xref:DashboardWeb). You can also make the embedded UI show specific DOM modules by adding the IDs of those modules in the URL, for example: `https://<DMA IP or hostname>/dom/#/?embed=true&moduleIds=myDomModule1,myDomModule2,myDomModule3`.

## Configuring security

The UI displays all available DOM modules in a list on the left, with a filter box at the top so you can quickly find the module you are looking for.

By default, all users will have full access to all DOM modules, which means that they will all be allowed to create, read, update, and delete DOM definitions in all available DOM modules.

From DataMiner 10.6.9 onwards<!--RN 45886-->, the security configuration uses a redesigned table-based group editor. In earlier DataMiner versions, the UI may look different.

To restrict access for specific definitions and their instances:

1. Select a module, and switch to *Restrict access* with the button on the right.

   At this point, no one will have access to the definitions in the module. The list of DOM definitions within the module will expand so you can select a definition.

1. Select a definition.

   The right panel shows a table of user groups that have access to that definition.

1. Click *+ Add groups* in the top-right corner and select the groups you want to add.

   Each added group gets *Full* access by default, meaning it can read, update, and delete instances of that definition.

1. To restrict a group to specific DOM instances, add a condition in the *Condition* column (available from DataMiner 10.5.0 [CU12]/10.6.3 onwards<!--RN 44385-->):

   - Select a field descriptor from the dropdown.

   - Specify the value(s) the field must contain.

   When a condition is set, the access level badge changes to *Limited*, meaning the group can only access DOM instances where the specified field contains the specified value(s).

   For example, the *Frankfurt Teleport Engineers* group can be configured to only access *Transmission Bookings* instances where the *Teleport Location* field contains the value *Frankfurt*.

   ![Instance-level security condition](~/dataminer/images/DOMSecurityInstanceLevel.png)<br>*Instance-level security condition in DataMiner 10.6.9*

1. To give a group read-only access, enable the *Read-only* toggle for that row.

   > [!NOTE]
   > The *Read-only* toggle is only available when the connected DataMiner server supports read-only link security (available from DataMiner 10.6.6/10.7.0 onwards<!-- RN 45275 -->).

1. To remove a group's access to the definition, click the delete button at the end of that group's row.

1. Repeat this for each definition users should have access to.

1. In the lower-right corner, click *Apply* to save your changes.

   If the *Apply* button is not available yet, this means that at least one DOM module still has invalid settings. To correct this, make sure that for each module at least one user group has full access to at least one definition in that module.

> [!NOTE]
> When changes are applied to the security configuration of a DOM module, that module will be reinitialized.
