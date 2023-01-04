---
uid: IDP_1.1.10
---

# IDP 1.1.10

## New features

#### Management of deleted elements \[ID_27164\]\[ID_27332\]

DataMiner IDP can now automatically detect when elements are deleted from the DMS. The deleted elements will no longer be managed by IDP and will be removed from all IDP components as a result.

An overview of the deleted elements will be displayed in the *Deleted Elements* table, which you can find on the *Inventory* > *Deleted* tab of the IDP app. The *Element Deleted* column of this table is available for alarm monitoring.

You can delete individual rows in the table or clean up the entire table to permanently remove managed element records of deleted elements. There is also an option available that allows you to recreate an element that has been deleted. Once the element has been recreated, the entry representing the element will be removed from the *Deleted Elements* table. If recreating the element failed, the *Status* column of the table will indicate what went wrong.

#### 'Pending' tab renamed to 'Unmanaged' \[ID_27164\]

The *Pending* tab of the IDP app, which lists the elements that are not yet managed by IDP, has been renamed to *Unmanaged*.

#### Support for backup operation based on file location \[ID_27170\]

It is now possible to configure a backup script with a file location, so that IDP will copy the file from that location to the archive. This location can be on a DMA in the cluster or on a separate server, as long as it can be accessed with the IDP user credentials.

To configure this, in the backup script, set the *DataType* field of the *ConfigurationBackup* object to *LocationPath*. The *Data* field will then be interpreted as the path to the file that needs to be backed up. If *DataType* is set to *Content* instead, the *Data* field will be interpreted as the content of the file to be stored, like before this change.

For example:

```csharp
ConfigurationBackup configuration = new ConfigurationBackup
{
   ConfigurationType = ConfigurationSettings.ConfigurationType,
   DMAId = ConfigurationSettings.DataMinerId,
   ElementId = ConfigurationSettings.ElementId,
   ElementName = Element.ElementName,
   ExecutionTime = DateTime.UtcNow,
   Properties = new[]
   {
      new Property
      {
         Name = "Manufacturer",
         Value = Element.GetPropertyValue("Manufacturer")
      }
      new Property
      {
         Name = "Model",
         Value = Element.GetPropertyValue("Model")
      }
   }
   Data = Data,
   DataType = ConfigurationDataType.LocationPath
};
```

#### New Supported File Extensions table \[ID_27205\]

It is now possible to configure which types of files can be visualized in the *Configuration* section of the IDP app. You can do so by adding the extensions in the *Supported File Extensions* table, which is available via *Admin* > *Configuration* > *Visualization*. By default, the table contains the XML and TXT extensions. If a file has an extension that is not listed in the table, the *Show content* action on the *Configuration* > *Backups* tab and the *Compare* action on the *Configuration* > *Compare* tab will result in an error.

#### Support for \[DNSName\] keyword in CI type \[ID_27416\]

In addition to the *\[IPAddress\]* keyword, the provisioning item in a CI type now supports the *\[DNSName\]* keyword. This keyword is automatically resolved when elements are provisioned, including when CI types are reapplied or reassigned.

In case the new keyword cannot be resolved, it will not be replaced and the element will contain the string *\[DNSName\]* in the places corresponding to the location of the keyword in the CI type definition. In case *\[DNSName\]* is used as the Polling IP and cannot be resolved, the following status message is returned when the element is manually provisioned: *The element cannot be provisioned because \[DNSName\] cannot be resolved in the Polling IP*.

#### Configuration change detection \[ID_27274\]\[ID_27427\]

An extra method is now available to have IDP store a device configuration in the configuration archive. Previously, only the *StoreResult* method could be used, but now you can also use the *StoreResultAndChangeDetection* method, which will pass the comparison version and the change detection data along with the configuration backup.

The “version” makes it possible to control different structures of configurations that may arise when different data needs to be compared. For example, it could occur that you initially only want to perform change detection on the uplink interface configuration, but eventually you also want to compare other parts of the configuration such as specific downlink interfaces. In that case, if you include the new parts, e.g. the downlink interface configuration, this increases the version number to 2. This way, with the different version number, the subject of the change detection changes.

The “separate data” from the full backup can be used to exclude sections of the original that do not contain important information for the comparison.

In the IDP app, you can find the change detection information on the *Configuration* tab:

- On the *Summary* subtab, there is a new column that indicates when IDP last detected a change in the configuration.
- On the *Backups* subtab, there is a new column that indicates if a search result contains changes compared to the previous backup. The column will either display *Changed* or *Unchanged*, depending on whether a change was detected, or *Unknown*, if IDP could not determine whether there was a change.
- Also on the *Backups* subtab, when you select a file to visualize its content, you can now select to view the *Full Configuration Backup* or the *Core Configuration Only.*
- Similarly, on the *Compare* subtab, when you select a configuration file to visualize its content, you can now select to view the *Full Configuration Backup* or the *Core Configuration Only*.

#### Alarm notification in case configuration change is detected \[ID_27455\]

It is now possible to have an alarm generated when a configuration change is detected. For this purpose, the following parameters have been added in the *Configuration Management* table (available via *Admin* > *CI Types* > *Configuration Management*):

- Checksum Parameter
- Set Checksum in Alarm Template

To modify these parameters, edit the CI type and navigate to the *Configuration Management* page. Alternatively, you can go to *Admin* > *CI types* > *Configuration Management* and click the *Advanced* button.

If *Set Checksum in Alarm Template* is enabled and a configuration change is detected, *Checksum Parameter* is updated with the current checksum value and the previous value is set as the alarm baseline value. The difference between the parameter and the baseline value will cause an alarm to be generated with the severity configured in the element alarm template.

If *Set Checksum in Alarm Template* and/or *Take Backup* (via *Workflows* > *Automation*) are disabled, the value 0 will be set to both *Checksum Parameter* and the alarm baseline.

## Changes

### Enhancements

#### Update Progress column shows progress of copying data to configuration archive \[ID_27236\]

When data is copied to the configuration archive, the *Update Progress* column in the *Configuration Summary* table will now be updated with the amount of data transferred so far.

#### Changes to purge settings and mechanism to support configuration backup files for change detection \[ID_27351\]

A number of changes have been implemented in the IDP app in order to support the new possibility to store a partial backup used for change detection together with a full backup.

Under *Admin* > *Configuration* > *Purge Settings*, a number of parameter names have been updated to reflect the fact that now the number of backups is counted, rather than the number of files. For example, *Files in Archive* is now *Backups in Archive* and shows the number of full configuration backups, without taking into account the extra files used for change detection.

If purging happens based on the total number of backups or the number of backups per element, only full configuration backups are now taken into account. However, if it happens based on disk usage, the size of all files (including the extra files used for change detection) is taken into account.

In addition, if a full configuration backup is deleted from the archive during purging, any accompanying file used for change detection is now deleted as well.

#### List of IDP element properties updated \[ID_27383\]

The list of element properties managed by IDP has been updated. It now consists of the following properties:

- Location Name
- Location Building
- Location Floor
- Location Room
- Location Aisle
- Location Rack
- Location Rack Position
- Location Rack Units
- Location Device Visibility
- Location Slot
- Location Geo Latitude
- Location Geo Longitude
- Location Geo Elevation
- Location Rack Side
- Energy Expected Consumption
- Energy Peak Consumption
- IDP Information
- IDP CI Type
- IDP
- Manufacturer
- Model
- Device Path Picture

The following properties are no longer created when IDP is newly installed:

- Asset Model
- Location City
- Location Region
- Location Country
- Location Geo Location Known
- Deployment Type
- Deployment Status
- Deployment Installation Date
- Deployment End Of Warranty Date

### Fixes

#### Model and Manufacturer properties in CI type overwritten by update properties script \[ID_27249\]

Previously, when an element was created, it could occur that the *Model* and *Manufacturer* properties in the CI type were overwritten by the *IDP_Default_UpdateProperties* script. Now, if *Model* is not defined in the CI type, the value of this element property will be the name of the CI type. If *Manufacturer* is not defined in the CI type, its value will be *Unknown*. Note that a custom update property script can still overwrite the values of *Model* and *Manufacturer*.
