---
uid: General_Main_Release_10.4.0_new_features
---

# General Main Release 10.4.0 – Other new features

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

### Core functionality

#### New table matrix [ID 34645] [ID 34661] [ID 34839] [ID 34879] [ID 34933]

<!-- MR 10.4.0 - FR 10.3.1 -->

It is now possible to create a matrix control in a protocol in a more intuitive way, based on two tables.

For this purpose, three parameters must be configured in the protocol:

- A table parameter for the inputs of the matrix.
- A table parameter for the outputs of the matrix.
- A dummy parameter, which contains the matrix mappings and determines where the matrix control is displayed.

> [!NOTE]
> If a matrix control is configured like this, the severity colors of the crosspoints depend on the alarm monitoring configured for the outputs tables in the alarm template. This is not configured with the matrix alarm level editor like for classic matrix controls. The crosspoint severity color will be the highest severity color for all monitored column parameters of the outputs table for the relevant row.

##### Inputs table parameter

For a typical inputs table, the following columns are configured:

- Index: String column. Required. Indicates the index of the input.
- Label: String column. Required. Contains the label of the input.
- State: Discrete column. Required. Indicates whether the input is enabled.
- Lock: Discrete column. Required. Indicates whether the input is locked.
- Page: String column. Optional. Indicates on which page the input is located.

Example:

```xml
<Param id="1000" trending="false">
   <Name>tblInputs</Name>
   <Description>Inputs</Description>
   <Type>array</Type>
   <Information>
      <Subtext>Table representation of the matrix. This table will contain the information of the inputs.</Subtext>
   </Information>
   <ArrayOptions index="0" options=";naming=/1002">
      <ColumnOption idx="0" pid="1001" type="autoincrement" options=";save" />
      <ColumnOption idx="1" pid="1002" type="retrieved" options=";save" />
      <ColumnOption idx="2" pid="1003" type="retrieved" options=";save" />
      <ColumnOption idx="3" pid="1004" type="retrieved" options=";save" />
      <ColumnOption idx="4" pid="1005" type="retrieved" options=";save" />
   </ArrayOptions>
   <Display>
      <RTDisplay>true</RTDisplay>
      <Positions>
         <Position>
            <Page>Tables</Page>
            <Row>0</Row>
            <Column>0</Column>
         </Position>
      </Positions>
   </Display>
   <Measurement>
      <Type options="tab=columns:1001|0-1002|1-1003|2-1004|3-1005|4,width:80-200-60-60-100,sort:STRING-STRING-STRING-STRING-STRING,lines:15,filter:true">table</Type>
   </Measurement>
</Param>
```

##### Outputs table parameter

For a typical outputs table, the following columns are configured:

- Index: String column. Required. Indicates the index of the output.
- Label: String column. Required. Contains the label of the output.
- State: Discrete column. Required. Indicates whether the output is enabled.
- Lock: Discrete column. Required. Indicates whether the output is locked.
- Connected Input: String column. Required. Determines which input is connected to the output. Only one input can be connected.
- Page: String column. Optional. Indicates on which page the output is located.
- Tooltip: String column. Optional. The tooltip shown on the connected crosspoint for this output.
- Lock Override: String column. Optional. Can be used to change a crosspoint while it is locked.

Example:

```xml
<Param id="2000" trending="false">
   <Name>tblOutputs</Name>
   <Description>Outputs</Description>
   <Type>array</Type>
   <Information>
      <Subtext>Table representation of the matrix. This table will contain the information of the outputs.</Subtext>
   </Information>
   <ArrayOptions index="0" options=";naming=/2002">
      <ColumnOption idx="0" pid="2001" type="autoincrement" options=";save" />
      <ColumnOption idx="1" pid="2002" type="retrieved" options=";save" />
      <ColumnOption idx="2" pid="2003" type="retrieved" options=";save" />
      <ColumnOption idx="3" pid="2004" type="retrieved" options=";save" />
      <ColumnOption idx="4" pid="2005" type="retrieved" options=";save;foreignKey=1000" />
      <ColumnOption idx="5" pid="2006" type="retrieved" options=";save" />
      <ColumnOption idx="6" pid="2007" type="retrieved" options=";save" />
      <ColumnOption idx="7" pid="2008" type="retrieved" options=";save" />
      <ColumnOption idx="8" pid="2009" type="retrieved" options=";save" />
      <ColumnOption idx="9" pid="2010" type="retrieved" options=";save" />
   </ArrayOptions>
   <Display>
      <RTDisplay>true</RTDisplay>
      <Positions>
         <Position>
            <Page>Tables</Page>
            <Row>1</Row>
            <Column>0</Column>
         </Position>
      </Positions>
   </Display>
   <Measurement>
      <Type options="tab=columns:2001|0-2002|1-2003|2-2004|3-2005|4-2006|5-2007|6-2008|7-2009|8-2010|9,width:80-200-60-60-112-80-80-0-112-100,sort:STRING-STRING-STRING-STRING-STRING-STRING-STRING-STRING-STRING-STRING,lines:15,filter:true">table</Type>
   </Measurement>
</Param>
```

##### Dummy parameter

The dummy parameter should have the new parameter type "Matrix".

With this parameter, matrix mappings are configured for each table. This is done in the *Param.Matrix* element, as illustrated in the example below.

The value of each mapping is the parameter ID of the relevant column parameter from the inputs or outputs table.

In the *name* attribute for each mapping, you can specify one of the following values to indicate the function of a column (as detailed above):

- For the inputs: *index*, *label*, *state*, *lock*, and *page*.
- For the outputs: *index*, *label*, *state*, *lock*, *connectedInput*, *page*, *tooltip*, and *lockOverride*.

In addition to the mappings, matrix options can also be configured, in the *Param.Matrix.MatrixOptions* element:

- *matrixLayout*: This option determines where the inputs and outputs are displayed in the matrix control. The following values are supported: *InputTopOutputLeft* and *InputLeftOutputTop*.
- *pages*: Set this option to "true" to enable auto-paging for the matrix. You can set custom pages with the *page* column of the tables.
- *minimumConnectedInputsPerOutput*: Allows you to specify a minimum number of connected inputs for an output. If you set this to "0", there is no minimum.
- *maximumConnectedInputsPerOutput*: Determines the maximum number of connected inputs for an output. At present, this is always "1".
- *minimumConnectedOutputsPerInput*: Allows you to specify a minimum number of connected outputs for an input. If you set this to "0", there is no minimum.
- *maximumConnectedOutputsPerInput*: Allows you to specify the maximum number of connected outputs for an input. If you set this to "auto", there is no maximum, and this scales with the table.

Example:

```xml
<Param id="3" trending="false">
   <Name>DummyMatrixParam</Name>
   <Type>Matrix</Type>
   <Display>
      <RTDisplay>true</RTDisplay>
      <Positions>
         <Position>
            <Page>Matrix</Page>
            <Row>0</Row>
            <Column>0</Column>
         </Position>
      </Positions>
   </Display>
   <Matrix>
      <Inputs tablePid="1000">
         <!-- This is the table parameter ID of the inputs table of this matrix-->
         <Mappings>
            <Mapping type="pid" name="index">1001</Mapping><!-- This is the primary key column parameter ID of the inputs table of this matrix => Indicates the index of the input.-->
            <Mapping type="pid" name="label">1002</Mapping><!-- This is the label column parameter ID of the inputs table of this matrix => Contains the label of the input.-->
            <Mapping type="pid" name="state">1003</Mapping><!-- This is the state column parameter ID of the inputs table of this matrix => Indicates whether the input is enabled or not.-->
            <Mapping type="pid" name="lock">1004</Mapping><!-- This is the lock column parameter ID of the inputs table of this matrix => Indicates whether the input is locked or not.-->
            <Mapping type="pid" name="page">1005</Mapping><!-- This is the page column parameter ID of the inputs table of this matrix => Indicates on which page the input is located.-->
         </Mappings>
      </Inputs>
      <Outputs tablePid="2000">
         <!-- This is the table parameter ID of the outputs table of this matrix-->
         <Mappings>
            <Mapping type="pid" name="index">2001</Mapping><!-- This is the primary key column parameter ID of the outputs table of this matrix => Indicates the index of the output.-->
            <Mapping type="pid" name="label">2002</Mapping><!-- This is the label column parameter ID of the outputs table of this matrix => Contains the label of the output.-->
            <Mapping type="pid" name="state">2003</Mapping><!-- This is the state column parameter ID of the outputs table of this matrix => Indicates whether the output is enabled or not.-->
            <Mapping type="pid" name="lock">2004</Mapping><!-- This is the lock column parameter ID of the outputs table of this matrix => Indicates whether the output is locked or not.-->
            <Mapping type="pid" name="connectedInput">2005</Mapping><!-- This is the connectedInput column parameter ID of the inputs table of this matrix => Contains which input is connected to this output. Note: Tables only support one input per output.-->
            <Mapping type="pid" name="page">2006</Mapping><!-- This is the page column parameter ID of the outputs table of this matrix => Indicates on which page the output is located.-->
            <Mapping type="pid" name="tooltip">2007</Mapping><!-- This is the tooltip column parameter ID of the outputs table of this matrix => Contains the tooltip shown on the crosspoint of this output.-->
            <Mapping type="pid" name="lockOverride">2008</Mapping><!-- This is the lockOverride column parameter ID of the outputs table of this matrix => Contains the lock override parameter for this output. This can be used to (un)set a crosspoint while locked.-->
         </Mappings>
      </Outputs>
      <MatrixOptions>
         <MatrixOption type="value" name="matrixLayout">InputLeftOutputTop</MatrixOption><!--Set this option if you want the matrix UI to position inputs or outputs at the top or on the left. Note: For table matrices, the only supported values are 'InputTopOutputLeft' or 'InputLeftOutputTop'.-->
         <MatrixOption type="value" name="pages">true</MatrixOption><!-- Set this option if you want to enable auto-paging on this matrix. Note: Custom pages can be set via the page column on the tables.-->
         <MatrixOption type="value" name="minimumConnectedInputsPerOutput">0</MatrixOption><!-- Set this option if you want to specify a minimum of connected inputs for an output. Note: 0 for no minimum.-->
         <MatrixOption type="value" name="maximumConnectedInputsPerOutput">1</MatrixOption><!-- Set this option if you want to specify a maximum of connected inputs for an output. Note: Always 1 because of the nature of the table column (table matrix only). -->
         <MatrixOption type="value" name="minimumConnectedOutputsPerInput">0</MatrixOption><!-- Set this option if you want to specify a minimum of connected outputs for an input. Note: 0 for no minimum.-->
         <MatrixOption type="value" name="maximumConnectedOutputsPerInput">auto</MatrixOption><!-- Set this option if you want to specify a maximum of connected outputs for an input. Note: auto for no maximum (scales with the table).-->
      </MatrixOptions>
   </Matrix>
   <Information>
      <Subtext>Matrix representation(dummy parameter)</Subtext>
   </Information>
   <Alarm>
      <Monitored>false</Monitored>
      <!-- Monitoring on this parameter is not supported, since the monitoring is done on table level.-->
   </Alarm>
   <Measurement>
      <Type>matrix</Type>
   </Measurement>
</Param>
```

##### Matrix helper

To manipulate the inputs and outputs tables, we recommend using the matrix helper, especially for bigger matrices. This is a helper in DataMiner Integration Studio that can you can add to the protocol by running the Matrix macro in DIS. With the helper, you can manipulate the matrix in an easy and consistent manner without having to do the table manipulations yourself.

In the generated macro, use the *TableMatrixHelper* class. This class can read out the mappings of the dummy parameter.

To create an instance of the helper, fill in the following parameters in the constructor:

```csharp
public TableMatrixHelper(SLProtocol protocol, int matrixDummyParameterId,
   int matrixTablesVirtualSetsParameterId, int matrixTablesSerializedSetsParameterId,
   int matrixConnectionsBufferParameterId = -2, int matrixSerializedParameterID = -2,
   int maxInputCount = 0, int maxOutputCount = 0)
```

Once an instance has been created, you can manipulate the matrix with the helper instance as follows:

```csharp
matrix.Inputs[i].Label = "Input " + (i + 1);
matrix.Inputs[i].IsEnabled = true;
matrix.Inputs[i].IsLocked = false;
matrix.Inputs[i].Page = "Page" + (i / 10 +1);

matrix.Outputs[i].Label = "Output " + (i + 1);
matrix.Outputs[i].IsEnabled = true;
matrix.Outputs[i].IsLocked = false;
matrix.Outputs[i].Connect(i);
matrix.Outputs[i].Page = "Page" + (i / 10 +1);
matrix.Outputs[i].ToolTip = "Tooltip " + (i + 1);

matrix.ApplyChanges(protocol);
```

Every time a user makes a change to the matrix in the UI, this will trigger one of the override methods, depending on the action. This way, data can be sent to the device.

Example:

```csharp
/// <summary>
/// Gets triggered when crosspoint connections are changed.
/// </summary>
/// <param name = "set">Information about the changed crosspoint connections.</param>
protected virtual void OnCrossPointsSetFromUI(Skyline.DataMiner.Library.Protocol.Matrix.MatrixCrossPointsSetFromUIMessage set)
{
}

/// <summary>
/// Gets triggered when the label of an input or output is changed.
/// </summary>
/// <param name = "set">Information about the changed label.</param>
protected virtual void OnLabelSetFromUI(Skyline.DataMiner.Library.Protocol.Matrix.MatrixLabelSetFromUIMessage set)
{
}

/// <summary>
/// Gets triggered when an input or output is locked or unlocked.
/// </summary>
/// <param name = "set">Information about the changed lock.</param>
protected virtual void OnLockSetFromUI(Skyline.DataMiner.Library.Protocol.Matrix.MatrixLockSetFromUIMessage set)
{
}

/// <summary>
/// Gets triggered when an input or output is enabled or disabled.
/// </summary>
/// <param name = "set">Information about the changed state.</param>
protected virtual void OnStateSetFromUI(Skyline.DataMiner.Library.Protocol.Matrix.MatrixIOStateSetFromUIMessage set)
{
}

/// <summary>
/// Gets triggered when a crosspoint tooltip is changed
/// </summary>
/// <param name = "set">Information about the changed tooltip.</param>
protected virtual void OnToolTipSetFromUI(Skyline.DataMiner.Library.Protocol.Matrix.MatrixToolTipSetFromUIMessage set)
{
}

/// <summary>
/// Gets triggered when an input/output page is changed
/// </summary>
/// <param name = "set">Information about the changed page.</param>
protected virtual void OnPageSetFromUI(Skyline.DataMiner.Library.Protocol.Matrix.MatrixPageSetFromUIMessage set)
{
}

/// <summary>
/// Gets triggered when crosspoint connections are changed via the lockOverride parameter.
/// </summary>
/// <param name = "set">Information about the changed crosspoint connections.</param>
protected virtual void OnCrossPointsSetViaLockOverrideFromUI(Skyline.DataMiner.Library.Protocol.Matrix.MatrixCrossPointsSetFromUIMessage set)
{
}
```

#### All DOM objects now have 'LastModified', 'LastModifiedBy', 'CreatedAt' and 'CreatedBy' properties [ID 34980]

<!-- MR 10.4.0 - FR 10.3.2 -->

All DOM objects (DomInstance, DomTemplate, DomDefinition, DomBehaviorDefinition, SectionDefinition and ModuleSettings) will now contain the following additional properties:

- *LastModified*: Date/time (UTC) at which the object was last modified.
- *LastModifiedBy*: Full username of the user who last modified the object.
- *CreatedAt*: Date/time (UTC) at which the object was created.
- *CreatedBy*: Full username of the user who created the object.

> [!NOTE]
>
> - *CreatedAt* and *CreatedBy* are automatically populated when the object is created. Any value assigned to these two fields by a user will always be discarded.
> - *LastModified* and *LastModifiedBy* are automatically updated when the object is updated on the server. Any value assigned to these two fields by a user will always be discarded. When an object is created, these fields will contain the same values as *CreatedAt* and *CreatedBy*.
> - These four fields are not directly accessible on the object. You first need to cast them to either *ITrackBase* or their individual interfaces (*ITrackLastModified*, *ITrackLastModifiedBy*, *ITrackCreatedAt* and *ITrackCreatedBy*).
>
>   `string createdBy = ((ITrackBase) domInstance).CreatedBy;`
>
> - These four fields can all be used in a filter.
> - In the Elasticsearch database, existing data will not contain values for these new fields (except the *LastModified* field for all but *ModuleSettings*).
> - All four fields are also available in the GQI data source *Object Manager Instances*. The *Last Modified* and *Created At* columns should show the time in the time zone of the browser.

#### DataMiner Object Models: Action buttons can now be configured to launch an interactive automation script when clicked [ID 35226]

<!-- MR 10.4.0 - FR 10.3.3 -->

An action button can now be configured to launch an interactive automation script when clicked. To do so, set the *IsInteractive* property of the action to true.

When such a button is clicked in a low-code app, the UI of the interactive automation script will be displayed in a pop-up window on top of the low-code app.

> [!NOTE]
> One button can only execute one action. So, one button can only execute one interactive automation script.

#### DataMiner Object Models: New field descriptors [ID 35278] [ID 36556]

<!-- RN 35278: MR 10.4.0 - FR 10.3.3 -->
<!-- RN 36556: MR 10.4.0 - FR 10.3.9 -->

Two new field descriptors have been added to the DataMiner Object Models:

- GroupFieldDescriptor: Can be used to define that a field should contain the name of a DataMiner user group.

- UserFieldDescriptor: Can be used to define that a field should contain the name of a DataMiner user. There is a *GroupNames* property that can be used to define which groups the user can be a part of.

The form component will render these descriptors as filterable dropdown boxes.

- Fields defined as `GroupFieldDescriptor` will display the group name and use that same group name as value.

- Fields defined as `UserFieldDescriptor` will display the full name of the user, but will store the user name as value.

  When the field descriptor defines any group names, the dropdown box will only list the users belonging to those groups.

> [!NOTE]
> Up to now, only users with *Modules > System configuration > Security > UI available* permission were allowed to view the list of DataMiner users. From now on, even users without *Modules > System configuration > Security > UI available* permission will at least be able to view the list of DataMiner users who are a member of any of the groups they themselves are a member of.

#### DataMiner upgrade: Additional prerequisite will now check for incompatible connectors [ID 35605]

<!-- MR 10.4.0 - FR 10.3.4 -->

When you start a DataMiner upgrade, the `ValidateConnectors` prerequisite will now scan the system for any connectors that are known to be incompatible with the DataMiner version to which the DataMiner Agent is being upgraded. If such connectors are found, they will have to be removed before you can continue with the upgrade.

#### Process Automation: Support for PaToken bulk operations [ID 35685]

<!-- MR 10.4.0 - FR 10.3.8 -->

From now on, `PaToken` objects can be created, updated and deleted in bulk using the following methods provided by the `PaTokens` helper:

- **CreateOrUpdate**

  ```csharp
  /// <summary>
  /// Returns the created or updated <paramref name="objects"/>.
  /// </summary>
  /// <param name="objects"><see cref="List{PaToken}"/> of <typeparamref name="PaToken"/> to be created or updated.</param>
  /// <returns>The result containing a list of <paramref name="objects"/> that were successfully updated or created. And a list of <see cref="TraceData"/> per item.</returns>
  public BulkCreateOrUpdateResult<PaToken, Guid> CreateOrUpdate(List<PaToken> objects)
  ```

  The result will contain a list of tokens that were successfully created or updated. The trace data is available per token ID. If an issue occurs when an item gets created or updated, no exception will be thrown (even when `ThrowExceptionsOnErrorData` is true). The trace data of the last call is available and will contain the data for all items. If the list contains tokens with identical keys, only the first will be considered.

- **Delete**

  ```csharp
  /// <summary>
  /// Deletes the given <paramref name="objects"/>.
  /// </summary>
  /// <param name="objects"><see cref="List{PaToken}"/> of <typeparamref name="PaToken"/> to be deleted.</param>
  /// <returns>The result containing a list of IDs of <paramref name="objects"/> that were successfully deleted. And a list of <see cref="TraceData"/> per item.</returns>
  public BulkDeleteResult<Guid> Delete(List<PaToken> objects)
  ```

  The result will contain a list of tokens that were successfully deleted. The trace data is available per token ID. If an issue occurs when an item gets deleted, no exception will be thrown (even when `ThrowExceptionsOnErrorData` is true). The trace data of the last call is available and will contain the data for all items.

#### DataMiner installation/upgrade: Automatic installation of DataMiner Extension Modules [ID 36085] [ID 36513] [ID 36514] [ID 36799] [ID 37137] [ID 37895]

<!-- MR 10.4.0 - FR 10.3.7 -->
<!-- RNs 36799/37137: MR 10.4.0 - FR 10.3.9 -->
<!-- RNs 37895: MR 10.4.0 - FR 10.3.12 -->

When you install or upgrade a DataMiner Agent, the following DataMiner Extension Modules (DxMs) will now automatically be installed (if not present yet):

- DataMiner ArtifactDeployer (version 1.5.2)
- DataMiner CoreGateway (version 2.12.0)
- DataMiner FieldControl (version 2.9.1)
- DataMiner Orchestrator (version 1.4.1)
- DataMiner SupportAssistant (version 1.5.3)

The BPA test *Firewall Configuration* has been altered to also check if TCP port 5100 is properly configured in the firewall. This port is required for communication with the cloud via the endpoint hosted in DataMiner CloudGateway.

In addition, the DataMiner installer will now also add a firewall rule allowing inbound TCP port 5100 communication.

> [!NOTE]
>
> - For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).
> - The above-mentioned DxMs all use .NET 6.

#### DataMiner Object Models: Caching of DOM configuration data [ID 36412]

<!-- MR 10.4.0 - FR 10.3.9 -->

In each DOM manager,the `DomDefinition`, `DomBehaviorDefinition` and `SectionDefinition` objects will now be fully cached.

These caches are enabled by default, also for existing DOM managers. When a DOM manager is initialized, all above-mentioned configuration objects will be stored into the caches. Depending on the amount of data, this could lead to the first request taking some more time.

##### Disabling the caches

Since the caches rely on synchronization, which requires a stable connection, an option was added to disable the caches if too many issues would arise on unstable clusters. You can configure the caching behavior per object type in the `ModuleSettings.DomManagerSettings.DomManagerSettings.StorageSettings.CachingSettings` object. Using the `DomConfigCachingPolicy` enum, you can set the caching behavior to one of the following options:

- *Default*: The default caching option, which is currently equal to the *Full* option.
- *Disabled*: Disables caching for the object type in question.
- *Full*: Enables full caching for the object type in question.

> [!IMPORTANT]
> If you modify these settings, you need to re-initialize the DOM manager.

##### Synchronization

Among the agents in a DMS, the caches will stay in sync thanks to the events sent by all the DOM managers on the different agents. If, for some reason, the caching would get out of sync, this will automatically be fixed during the midnight sync, which will cause the caches to be reloaded from the database. During that cache reload, the DOM managers will remain available.

If you want to ensure that the caches are in sync with the database, you can manually send a `ManagerStoreMidnightSyncCustomManagerRequest`. This will refresh all caches on all running instances of a DomManager with a given ID across the DMS. To do so, open a DomManager in the *SLNetClientTest* tool, go to the *Maintenance* tab, and click the refresh button.

##### Logging

In the log files, you will be able to find out which caches are enabled and when they have been refreshed (either during a midnight sync or a user-initiated sync). Also, after a refresh, a log entry will be added, mentioning the number of objects that were added, updated, ignored and removed in the cache.

##### Impact on paging

When the caches are enabled, it is no longer possible to get paged results when retrieving DomDefinitions, DomBehaviorDefinitions or SectionDefinitions. Instead, the complete list of objects matching the given query will be returned, even if that list is larger than the configured page size.

#### API Gateway: DataMiner modules can now register with API Gateway [ID 36575] [ID 37734]

<!-- MR 10.4.0 - FR 10.4.2 -->

DataMiner modules can now register with API Gateway. These modules can be either "regular modules" (e.g., SLNet) or "proxy modules" (e.g., a DxM that wishes to expose an API).

All modules registered with API Gateway will be displayed under `/APIGateway/api/version`, showing the following properties:

- Name
- Version
- Endpoint on which they can be accessed via API Gateway (proxy modules only)

#### DataMiner Object Models: Soft-deletable objects [ID 36721] [ID 37121]

<!-- RN 36721: MR 10.4.0 - FR 10.3.9 -->
<!-- RN 37121: MR 10.4.0 - FR 10.3.10 -->
<!-- Additional fix of 37121 added under WebApps/Fixes -->

The following DOM objects can now be soft-deleted:

- [DomStatusSectionDefinitionLink](xref:DOM_status_system#configuring-fields)
- [FieldDescriptor](xref:DOM_SectionDefinition#fielddescriptor)
- GenericEnumEntry
- [SectionDefinitionLink](xref:DomDefinition#sectiondefinitionlink)

When the fields linked to a soft-deleted `FieldDescriptor` or part of a soft-deleted `SectionDefinitionLink` or `DomStatusSectionDefinitionLink` are marked as *IsSoftDeleted*, the following applies:

- The fields will not be shown in a UI form.
- The fields are not validated when the `SectionDefinition`, `DomDefinition`, or `DomBehaviorDefinition` is updated.
- The fields are never be required.
- Values are allowed to exist in the fields on a `DomInstance` for a soft-deleted `FieldDescriptor`, `SectionDefinitionLink`, or `DomStatusSectionDefinitionLink`.
- Updating a `DomInstance` with new/updated values will be blocked for a field that has a soft-deleted `FieldDescriptor`, or is part of a soft-deleted `SectionDefinitionLink` or `DomStatusSectionDefinitionLink` (for that status). A [ValueForSoftDeletedFieldNotAllowed error](xref:DomInstance#errors) will be returned.

Soft-deleting a *GenericEnumEntry* object will have the following consequences:

- The *GenericEnumEntry* will not be displayed on UI forms used to create an instance.
- The *GenericEnumEntry* will be displayed on a UI form used to update an instance of which the value is set to the soft-deleted *GenericEnumEntry* in question.
- It will not be possible to create an instance of which the value is set to the soft-deleted *GenericEnumEntry*.
- It will not be possible to update the value of an instance to the soft-deleted *GenericEnumEntry*.
- It is allowed to have instances of which the value is set to the soft-deleted *GenericEnumEntry*.

#### DataMiner Object Models: 'Full CRUD meta' scripts [ID 37004]

<!-- MR 10.4.0 - FR 10.3.10 -->

Apart from **ID only** scripts, which use the `OnDomInstanceCrud` entry point method and give you access to the CRUD type and the ID of the `DomInstance` in the script, it is now also possible to configure **Full CRUD meta** scripts. These use the `OnDomInstanceCrudWithFullMeta` entry point method and give you access to the CRUD type and the full `DomInstance` object(s).

For more detailed information, see [ExecuteScriptOnDomInstanceActionSettings](xref:ExecuteScriptOnDomInstanceActionSettings).

#### Support for real-time GQI row updates [ID 37060]

<!-- MR 10.4.0 - FR 10.3.10 -->

Real-time row updates are now supported for GQI session results for specific data sources and operators. This means that, when this is supported in the client, real-time updates can be displayed for row additions, modification, or deletions.

At present, this is supported for the following GQI data sources:

- Parameter table (except partial and view tables)
- Views

It is supported for the *Select* operator, but it can also be supported for other operators if they are combined with specific data sources, for instance for a filter on a parameter table.

#### Proactive cap detection extended to absolute and relative alarm types [ID 37373]

<!-- MR 10.4.0 - FR 10.3.11 -->

The proactive cap detection feature has been extended to dynamic alarm thresholds.

As a result, proactive detection will now predict when a parameter will cross one of the following bounds:

- A high and/or low data range value specified in the protocol.
- A (by default) critical alarm limit of type normal specified in the alarm template.
- A (by default) critical alarm limit of type "absolute" or "relative" specified in the alarm template if either a fixed baseline value is set or a dynamically updated baseline value is configured in the alarm template to detect a continuos degradation.
- A data range indirectly derived from the protocol info. Currently this is limited to the values 0 and 100 for percentage data for which no historical values were encountered outside the [0,100] interval.

#### DataMiner upgrade: Additional prerequisite will now check whether profiles and resources are stored in an indexing database [ID 37763]

<!-- MR 10.4.0 - FR 10.4.1 -->

Starting from DataMiner version 10.4.0, XML storage for profiles and resources is no longer supported. When you upgrade DataMiner to version 10.4.0, the `VerifyElasticStorageType` prerequisite will verify whether the system has successfully switched to an indexing database. If profiles and/or resources are still stored in XML files, this prerequisite will cause the upgrade to fail.

See also: [Verify Elastic Storage Type](xref:Verify_Elastic_Storage_Type)

### Protocols

#### 'ExportRule' elements can now have a 'whereAttribute' attribute [ID 36622]

<!-- MR 10.4.0 - FR 10.3.8 -->

`ExportRule` elements can now have a `whereAttribute` attribute. This will allow you to validate the value of an attribute when applying an export rule.

See the following example. If the `includepages` attribute of the *Protocol.SNMP* element is true, the export rule will change that value to false in the exported protocol. Without the `whereAttribute`, the `whereValue` check would be performed on the value of the *Protocol.SNMP* element itself (which is mostly set to "auto") instead of the value of the `includepages` attribute.

```xml
<ExportRule table="*" tag="Protocol/SNMP" attribute="includepages" value="false" whereTag="Protocol/SNMP" whereAttribute="includepages" whereValue="true"/>
```

In this next example, all *Column* elements of parameters that have a `level` attribute that is set to 5 will have their value set to 2 in the exported protocol.

```xml
<ExportRule table="*" tag="Protocol/Params/Param/Display/Positions/Position/Column" value="2" whereTag="Protocol/Params/Param" whereAttribute="level" whereValue="5"/>
```

#### Smart-serial communication now supports dynamic polling [ID 37404]

<!-- MR 10.4.0 - FR 10.3.11 -->

Smart-serial connection will now support dynamic polling, i.e., the ability to change the IP address and IP port while the element is active.

To enable dynamic polling for a smart-serial connection, add a parameter that contains the following:

`<Type options="dynamic ip">read</Type>`

> [!IMPORTANT]
>
> - Dynamic polling is only supported when the connection acts as a client. When you create the element, do not assign an IP address like "127.0.0.1", "any", etc. to it. If you do, the element will act as a server, and there is no way to make the element act as a client without stopping it. Also, trying to assign a value like "127.0.0.1" to the dynamic IP parameter at runtime will cause an error to occur.
> - We strongly advise you to always set the connection type to "smart-serial single" so the connection is assigned a dedicated socket in SLPort. If two or more smart-serial elements hosted on the same DMA are assigned the same IP address and port via the element wizard, they will share the same connection in SLPort. This means that, if one of these elements changes the IP address dynamically, the other ones will also start using the new IP address.

### Maps

#### DataMiner Maps: Marker images can now also be generated dynamically in layers with sourceType set to objects [ID 36246]

<!-- MR 10.4.0 - FR 10.3.7 -->

Marker images can now also be generated dynamically in layers with `sourceType` set to "objects".

To generate a marker image dynamically, you can use placeholders in the `url` attribute of the *\<MarkerImage\>* tag.

#### DataMiner Maps: ForeignKeyRelationsSourceInfo tag now supports an elementVar attribute [ID 38274]

<!-- MR 10.4.0 - FR 10.4.3 -->

In a `<ForeignKeyRelationsSourceInfo>` tag, it is now possible to specify an *elementVar* attribute.

```xml
<ForeignKeyRelationsSourceInfo elementVar="myElement">
...
</ForeignKeyRelationsSourceInfo>
```

This will allow you to pass an element in the map's URL. See the URL examples below (notice the “d” in front of the parameter name!):

```txt
maps.aspx?config=MyConfigFile&dmyElement=7/46840
maps.aspx?config=MyConfigFile&dmyElement=VesselData
```

### Service & Resource Management

#### Service & Resource Management: Exposers for resource capacities and capabilities [ID 34841]

<!-- MR 10.4.0 - FR 10.3.1 -->

Exposers have been added for resource capacities and capabilities. These can for example be used as follows:

```csharp
var helper = new ResourceManagerHelper(engine.SendSLNetSingleResponseMessage);

// Get all resources with a certain discrete option
var encodingQualityParameterId = Guid.Parse("..."); // GUID of the profile parameter
FilterElement<Resource> filter = ResourceExposers.Capabilities.DiscreteCapability(encodingQualityParameterId).Contains("UHD");
var resources = helper.GetResources(filter);

// Get all resources with a certain rangepoint capability
var frequencyParameterId = Guid.Parse("...");
filter = ResourceExposers.Capabilities.HasRangePoint(frequencyParameterId, 50);
resources = helper.GetResources(filter);

// Get all resources with a certain string capability (case-insensitive)
var locationParameterId = Guid.Parse("...");
filter = ResourceExposers.Capabilities.StringCapability(locationParameterId).Equal("Berlin");
filter = ResourceExposers.Capabilities.StringCapability(locationParameterId).Contains("New");
resources = helper.GetResources(filter);

// Get all resources with a bitrate capacity, with a max value of 100.1 or more
var bitrateParameterId = Guid.Parse("...");
filter = ResourceExposers.Capacities.MaxCapacityValue(bitrateParameterId).GreaterThanOrEqual(100.1);
resources = helper.GetResources(filter);
```

These are the string representations of the examples above:

| Filter in code | String representation |
|--|--|
| `ResourceExposers.Capabilities.DiscreteCapability(encodingQualityParameterId).Contains("UHD");` | `Resource.Capabilities.e551766950f9442da1232d2e0e0f5872[List<String>] contains UHD` |
| `ResourceExposers.Capabilities.HasRangePoint(frequencyParameterId, 50);` | `(Resource.Capabilities.f0c94ee8ab2444d1866fa2ce5b7a3290_Min[Double] <=50) AND (Resource.Capabilities.f0c94ee8ab2444d1866fa2ce5b7a3290_Max[Double] >=50)` |
| `ResourceExposers.Capabilities.StringCapability(locationParameterId).Equal("Berlin");` | `Resource.Capabilities.be64ec9a33e843e0a06111690cff0140[String] =='Berlin'` |
| `ResourceExposers.Capacities.MaxCapacityValue(bitRateParameterId).GreaterThanOrEqual(100.10);` | `Resource.Capacities.8ce08caa5c1f45f4a2f6566cca7754b0[Double] >=100.1` |

Please note the following:

- The capacities and capabilities are exposed as dictionaries, where the key is the ID of the profile parameter (without dashes).
- A range capability exposes two values: the minimum and maximum of the range. These are exposed as two keys in the dictionary: "[id]_Min" and "[id]_Max".
- Building the filter in code and calling the *ToString()* method on the *FilterElement* should return a usable string representation of the filter.
- When you filter on discrete values, use the discrete value itself instead of the display value, as the latter is not stored in the resource.
- The filter is case sensitive with regard to profile parameter keys.
- The exposers will filter based on the total capacity configured on the resources. The available capacity at a specific point in time will not be taken into account. The same applies for time-dependent capabilities: the current time-dependent value is not resolved, and the resources will be treated as not having an empty string value for the capability.
- The exposers will not work reliably if you have the same capacity or capability multiple times on the same resource.
- The capacity value is exposed as a double (though it is stored as a decimal on the resource), for compatibility with the ElasticSearch database.
- The following extension methods have been added to easily compose the filters: *HasRangePoint*, *DiscreteCapability*, *StringCapability* and *MaxCapacityValue*.

> [!TIP]
> See also: [Visual Overview: Session variable YAxisResources now supports filters to pass exposers [ID 34857]](xref:Cube_Feature_Release_10.3.1#visual-overview-session-variable-yaxisresources-now-supports-filters-to-pass-exposers-id-34857)

#### Service & Resource Management: Reinitializing Resource Manager [ID 36811]

<!-- MR 10.4.0 - FR 10.3.9 -->

You can now (re)initialize Resource Manager using the SLNetClientTest tool. This can be useful if Resource Manager fails to initialize on DataMiner startup, and you want to try to initialize it again without restarting DataMiner.

> [!CAUTION]
> When you reinitialize Resource Manager, it will first be deinitialized and then initialized again. This can cause pending calls to fail, and new calls that are made while Resource Manager is being deinitialized will fail with the *ModuleNotInitialized* error.

> [!NOTE]
> In order to do this, you need the user permission [Modules > System configuration > Tools > Admin tools](xref:DataMiner_user_permissions#modules--system-configuration--tools--admin-tools).

To (re)initialize Resource Manager:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, go to *Apps* > *SRM Surveyor*.

1. At the bottom of the window, click *Reinitialize ResourceManager*.

   Resource Manager will be (re)initialized on the DataMiner Agent you are connected to.

#### Service & Resource Management: Storage type for ProfileManager and ResourceManager will now always be Elasticsearch/OpenSearch [ID 37877]

<!-- MR 10.4.0 - FR 10.4.1 -->

From now on, the storage type for ProfileManager and ResourceManager will always be Elasticsearch/OpenSearch. XML storage is no longer supported.

When you retrieve the storage type, it will now always return Elasticsearch/OpenSearch, even if the ProfileManager or ResourceManager configuration states that the storage type is XML. If no ProfileManager configuration can be found, a default configuration will now be created with storage type set to Elasticsearch/OpenSearch.

If you would try to send a `SetResourceManagerConfigMessage` to change the storage type to XML, the response message will state that the attempt failed and will contain the following error message:

`Ignoring the config change, Xml is no longer supported as ResourceStorageType.`

If you would try to set the ProfileManager configuration to Elasticsearch/OpenSearch via the configuration manager, this will fail. The ProfileManager log file should then contain the following trace data:

```txt
TraceData: (amount = 1)
   - ErrorData: (amount = 1)
      - ProfileManagerErrorData: ErrorReason: InvalidConfigurationFile,
                                 Message: Xml is no longer supported as ProfileManagerStorageType,
```

> [!NOTE]
> The *SLNetClientTest* tool will no longer allow you to switch the storage type from XML to Elasticsearch/OpenSearch or vice versa, nor will it allow you to create a ProfileManager configuration anymore.

### Tools

#### SLLogCollector will now order the Standalone BPA Executor tool to execute all BPA tests available in the system [ID 35436]

<!-- MR 10.4.0 - FR 10.3.3 -->

Each time the *SLLogCollector* tool is run, it will now order the *Standalone BPA Executor* tool to execute all BPA tests available in the system and store the results in the `C:\Skyline DataMiner\Logging\WatchDog\Reports\Pending Reports` folder.

The names of the files containing the test results will have the following format: `<BPA Name>_<Date(yyyy-MM-dd_HH)>`

#### SLNetClientTest tool: New menu to manage the cloud connection of a DMA while it is offline [ID 36611]

<!-- MR 10.4.0 - FR 10.3.8 -->

In the *SLNetClientTest* tool, you can now go to *Offline tools > CcaGateway (offline)* to manage the cloud connection of the local DataMiner Agent while it is offline.

> [!WARNING]
> Always be extremely careful when using the *SLNetClientTest* tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
