---
uid: General_Feature_Release_10.3.1
---

# General Feature Release 10.3.1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.3.1](xref:Cube_Feature_Release_10.3.1).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

#### Dashboards app & Low-Code Apps: Icon component [ID_34867]

<!-- MR 10.4.0 - FR 10.3.1 -->

The new icon component allows you to display an icon on a dashboard or a low-code app.

#### Interactive Automation scripts: New button style 'CallToAction' [ID_34904]

<!-- MR 10.4.0 - FR 10.3.1 -->

In an interactive Automation script launched from a dashboard or a low-code app, you can now apply the *CallToAction* style to a button.

When you apply this style to a button

- the background color of the button will be the color of the app,
- the color of the text on the button will be white, and
- the button will have a shadow.

To set the style of a button in an interactive Automation script, set the *Style* property of the button's *UIBlockDefinition* to the name of the style. All supported styles are available via `Style.Button`.

Alternatively, you can also pass a button style directly to the `AppendButton` method on an `UIBuilder` object.

> [!NOTE]
>
> - Up to now, `StaticText` blocks already supported a number of styles. Those styles are now also available via `Style.Text`: *Title1*, *Title2* and *Title3*.
> - The *CallToAction* style will only be applied in interactive Automation scripts launched from a web app. It will not be applied in interactive Automation scripts launched from Cube.

## Other features

#### New table matrix [ID_34645] [ID_34661] [ID_34839] [ID_34879] [ID_34933]

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

#### SLNetClientTest tool - 'Connect' window: Enhanced 'Connection Type' and 'Authentication' sections [ID_34712]

<!-- MR 10.3.0 - FR 10.3.1 -->

In the *SLNetClientTest* tool, to connect to a DataMiner Agent, you select *Connection* > *Connect*, and specify the necessary information in the *Connect* window. That window has now been updated.

In the *Connection Type* section, you now have to indicate how the connection has to be established:

| Select...              | in order to... |
|------------------------|----------------|
| Autodetect             | connect to the local machine or a remote machine using the method that will be detected automatically. |
| gRPC                   | connect to the local machine or a remote machine via the APIGateway service using the GRPCWeb protocol.<br>When you choose this option, you can specify a custom port (default: `443`) and a custom endpoint (default: `/APIGateway`). |
| .NET Remoting (legacy) | connect to the local machine or a remote machine using .NET Remoting.<br>When you choose this option, you can specify a custom port (default: `8004`) |
| IPC (only local)       | connect to the local machine using IPC. |

In the *Authentication* section (formerly known as *User Info* section), you now have the following authentication options:

- Single sign-on

    > [!NOTE]
    > External authentication not yet supported.

- Explicit credentials (with *Force Authenticate Local User* option)

- Ticket

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Service & Resource Management: Exposers for resource capacities and capabilities [ID_34841]

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
> See also: [Visual Overview: Session variable YAxisResources now supports filters to pass exposers](xref:Cube_Feature_Release_10.3.1#visual-overview-session-variable-yaxisresources-now-supports-filters-to-pass-exposers-id_34857)

## Changes

### Enhancements

#### Enhanced parameter locking in SLElement [ID_34688]

<!-- MR 10.2.0 [CU12] - FR 10.3.1 [CU0] -->

In SLElement, a number of enhancements have been made with regard to parameter locking.

#### SLLogCollector now also collects DxM version info and APIGateway app settings [ID_34701]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

SLLogCollector packages will now also include:

- Version information of all DataMiner Extension Modules (DxM).
- The appsettings.json file of the APIGateway service.

#### Elasticsearch: Sending a GetInfoMessage of type 'IndexingConfiguration' with an invalid DataMiner ID will now only return the Elasticsearch configuration of the local DMA [ID_34774]

<!-- MR 10.1.0 [CU22]/10.2.0 [CU10] - FR 10.3.1 -->

When a *GetInfoMessage* of type "IndexingConfiguration" was sent containing an invalid DataMiner ID, up to now, the Elasticsearch configuration of all DMAs would be returned.

From now on, when the DataMiner ID in a *GetInfoMessage* request of type "IndexingConfiguration" is invalid, only the Elasticsearch configuration of the local DMA will be returned instead.

#### DataMiner upgrade: Enhanced method to delete locked files [ID_34779]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU10] - FR 10.3.1 -->

When, during a DataMiner upgrade, an attempt was made to delete files that were locked by certain processes, up to now, that attempt would fail, causing those files to remain on the system until the next upgrade.

From now on, when an attempt to delete a file during a DataMiner upgrade fails, the extension of that file will be replaced by `.SLReplace` and, later on in the upgrade process, the file will then be deleted by SLHelper.

#### Size of log entries in log files generated by SLLog will now be limited [ID_34801]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

In log files generated by SLLog, the size of the entries will now be limited:

- Messages will be trimmed to 5120 characters.
- Methods will be trimmed to 200 characters.
- Program names will be trimmed to 200 characters.

> [!NOTE]
> Method data typically also includes the process and thread IDs.

#### Web apps now support trending of string parameters and exceptions [ID_34836]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

Web apps now support trending of string parameters and exceptions.

#### GQI: Enhanced performance when retrieving DomInstances that have a DomBehaviorDefinition [ID_34853]

<!-- MR 10.3.0 - FR 10.3.1 -->

Because of a number of enhancements, overall performance has increased when retrieving DomInstances that have a DomBehaviorDefinition.

#### BREAKING CHANGE - Dashboards app & Low-Code Apps - GQI: Certain cell values in a GQI query result will no longer include the object type [ID_34895]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

Previously, cell values of GQI result rows for DomInstanceIds, DomDefinitionIds, ProfileInstanceIds, and ProfileDefinitionIds contained both the display value of the GUID and the object type (e.g. "DomDefinitionId[00000000-0000-0000-0000-000000000000]"). Now the cell value will only contain the display value of the GUID.

#### SLAnalytics: Enhanced automatic evaluation of trend predictions [ID_34901]

<!-- MR 10.3.0 - FR 10.3.1 -->

Because of a number of enhancements, the automatic evaluation of trend predictions has improved.

#### Port initialization error messages have been improved [ID_34920]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 [CU0] -->

The following port initialization error messages have been improved:

- The log message `InitializePort <n> for Element <x> failed with <y>.` has been replaced by `InitializePort(<n>) for Element <x> failed with <y>.`

- The alarm message `Initializing the communication <n> for <x> failed.` has been replaced by `Initializing the communication of port <n> for <x> failed.`

#### Element errors and notices will now be closed as soon as the element in question is stopped [ID_34927]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU10] - FR 10.3.1 -->

The following element errors/notices generated by SLDataMiner will now automatically be closed when the elements in question are stopped.

``` txt
Creating log-factory for <x> failed.
Creating the log-file for <x> failed.
Initialize xml for <x> failed.
Parsing the settings for <x> failed.
Creating element-object for <x> failed with <y>.
Initializing the element <x> failed.
Starting the element <x> failed.
Starting the element <x> failed. No element object.
Creating Database tables for <x> failed.
Creating element-objects for <x> failed.
Initializing the communication <p> for <x> port failed. / Initializing the communication of port <p> for <x> failed.
Initializing the protocol for <x> failed.
Initializing the element for <x> failed.
Starting the protocol for <x> failed.
Starting the protocol for <x> failed. No Protocol object.
Starting the derived element for <x> failed.
Starting the element <x> failed. No element object.
Creating element-object for <x> failed with <y>.
```

#### SLAnalytics: Number of 'GetParameterMessages' requests has been optimized [ID_34936]

<<!-- MR 10.3.0 [CU1] - FR 10.3.1 -->

The number of *GetParameterMessages* sent by SLAnalytics in order to check whether a trended table parameter is still active has been optimized.

#### Dashboards app & Low-Code Apps: A table row with a column containing a parameter table index is now capable of feeding a linked parameter [ID_34957]

<!-- Main Release Version 10.2.0 [CU10] - Feature Release Version 10.3.1 -->

From now on, a table row with a column containing a parameter table index will now also be capable of feeding a linked parameter when all necessary data is available. As a result, one data input will now suffice to visualize table row data in a line chart.

### Fixes

#### SLDMS would leak memory when processing a large number of distribution traps [ID_34525]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

Up to now, SLDMS could leak memory when it had to process a large number of distribution traps. From now on, the number of distribution traps that can be processed by SLDMS will be limited to 250,000. When SLDMS notices that the queue of distribution traps has reached 250,000, it will reject new traps until the number of traps in the queue has dropped to 100,000.

#### Cassandra cluster migration: Enhanced performance of SLElement when migrating alarms [ID_34668]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

Because of a number of enhancements, overall performance of SLElement has increased when migrating alarms during a Cassandra cluster migration.

#### Dashboards app - Time range feed: Quick pick buttons would not be displayed in the correct order [ID_34759]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU10] - FR 10.3.1 -->

When a time range feed was configured to show quick pick buttons, those buttons would not be displayed in the correct order. From now on, quick pick buttons will be displayed in chronological order.

#### Web apps - Interactive Automation scripts: All other tree view components in a dialog box would incorrectly collapse when you selected an item in a tree view component [ID_34773]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

When, in a dialog box of an interactive Automation script, you selected an item in a tree view component, other tree view components on that dialog box would incorrectly collapse.

#### Standalone parameters belonging to another child of the same DVE parent element could be set to 'Not Initialized' when a row linked to a DVE child element was deleted [ID_34785]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU10] - FR 10.3.1 -->

When a row linked to a DVE child element was deleted, in some cases, standalone parameters belonging to another child of the same DVE parent element could be set to "Not Initialized".

#### GQI: Filter operations would not be forwarded to the correct query when multiple data sources were joined [ID_34819]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

When multiple data sources were joined, in some cases, filter operations would not be forwarded to the correct query.

#### GQI: Problem when retrieving DCF interfaces [ID_34820]

<!-- MR 10.4.0 - FR 10.3.1 -->

When a GQI query returned all DCF interfaces from all agents in the DataMiner System, the NATS message broker would throw a *MaxPayloadException* when *MaxPayload* exceeded the value configured in `C:\Skyline DataMiner\NATS\nats-streaming-server\nats-server.config`.

From now on, when a GQI query has to retrieve DCF interfaces, it will do so by querying one agent at a time.

#### Problem with SLElement when a trend template was being assigned [ID_34824]

<!-- MR 10.2.0 [CU12] - FR 10.3.1 -->

In some cases, an error could occur in SLElement when a trend template was being assigned.

#### Known Elasticsearch errors would incorrectly get logged in the SLSearch.txt log file [ID_34827]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

Up to now, when custom data was requested by ID from an Elasticsearch database, a "404" error would be logged in the *SLSearch.txt* log file when the ID did not exist.

From now on, only unknown Elasticsearch errors will be logged in the *SLSearch.txt* log file. Known errors will be logged as level-5 errors in the debug logs.

#### Memory leak in SLDataGateway during a Cassandra Cluster migration [ID_34829]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU10] - FR 10.3.1 -->

During a Cassandra Cluster migration, SLDataGateway would leak memory due to paging handlers not being cleaned up correctly.

#### Dashboards app & Low-Code Apps: Contents of colored table cells would incorrectly not be visible when conditional coloring was applied and actions had been configured [ID_34842]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

When conditional coloring was applied on the first column of a table in which actions had been configured, in some cases, the contents of the colored cells would incorrectly not be visible.

#### DataMiner upgrade: 'Webpages\\App' and 'Webpages\\Automation' folders would incorrectly not be cleaned up [ID_34844]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

After a DataMiner upgrade, files belonging to previous app versions would incorrectly not be removed from the `C:\Skyline DataMiner\Webpages\App` and `C:\Skyline DataMiner\Webpages\Automation` folders. From now on, those folders will be deleted before new versions of those apps are installed.

#### Problem with SLElement when a description.xml file was updated while an alarm was being unmasked [ID_34860]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

In some cases, an error could occur in SLElement when a *description.xml* file was updated while an alarm was being unmasked.

#### Problem with SLElement [ID_34861]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

In some cases, an error could occur in SLElement when a DVE child or a virtual function was started, and when a parameter description was changed.

#### Dashboards app: Empty groups would incorrectly not be removed from parameter feeds listing EPM parameters [ID_34884]

<!-- MR 10.3.0 - FR 10.3.1 -->

When, in a parameter feed listing EPM parameters, the parameters were grouped, empty groups would incorrectly not be removed after switching to another EPM object.

#### HTTP requests would incorrectly not be retried when WinHTTP threw a SEC_E_BUFFER_TOO_SMALL error [ID_34888]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

When an HTTP request is sent, in some cases, WinHTTP can incorrectly throw a `SEC_E_BUFFER_TOO_SMALL` error when the server is using TLS 1.2.

From now on, when this error is thrown, DataMiner will retry the HTTP request the number of times specified for the HTTP connection in question.

#### Low-Code Apps: Problem with 'Close a panel' action [ID_34892]

<!-- MR 10.3.0 - FR 10.3.1 -->

When a *Close a panel* action was configured as a post action on a button component, in some cases, it would incorrectly not cause the panel to close.

#### Dashboards & Low-Code Apps: Decimal values would incorrectly not be allowed in range filters [ID_34897]

<!-- MR 10.3.0 - FR 10.3.1 -->

In some cases, a range filter in a query filter or a table column filter would incorrectly not allow decimal values.

> [!NOTE]
> When using a query filter with filter assistance enabled, the statistics will determine the number of decimals that can be used.

#### Problem with SLElement when a parameter update was being processed while an element was starting up [ID_34899]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

In some cases, an error could occur in SLElement when a parameter update was being processed while an element was starting up.

#### Low-Code Apps: 'Fetch the data' action of a table component would resolve too soon [ID_34902]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

In some cases, a *Fetch the data* action of a table component would resolve too soon. This would cause post actions to be executed while the data was still being retrieved. From now on, the *Fetch the data* action will resolve when all data is retrieved.

#### Dashboards & Low-Code Apps: Feed component selections would incorrectly be lost after applying a built-in theme [ID_34908]

<!-- MR 10.3.0 - FR 10.3.1 -->

When you applied a built-in theme, feed component selections would incorrectly be lost after refetching the data.

#### SLLogCollector would become unresponsive after executing a nodetool command [ID_34909]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

When the JAVA_HOME variable was not set, SLLogCollector would become unresponsive after executing a nodetool command.

From now on, when SLLogCollector times out after executing a nodetool command, it will log a timeout message in its log file and proceed.

#### Dashboards app & Low-Code Apps - Table component: Data of different types displayed in the same row would not get fed correctly to linked feed components [ID_34915]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

When a row in a table component contained data of different types, that data would not get fed correctly to linked feed components.

Moreover, in some cases, the table would even not be able to feed the data in its rows.

#### SLDataGateway was not always able to parse the result of a 'nodetool status' command [ID_34929]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

The SLDataGateway process periodically checks the status of the local Cassandra node by executing a `nodetool status` command and parsing the result. When Cassandra was still starting up, some values in the output could not always be parsed, leading to SLDataGateway incorrectly marking the database as unavailable.

#### Dashboards & Low-Code Apps: Not possible to group the data in a timeline populated using a query with a query filter [ID_34932]

<!-- MR 10.3.0 - FR 10.3.1 -->

When a timeline was populated using a query with a query filter, it would incorrectly not be possible to group the data.

#### Problem with SLProtocol when trying to update a parameter of type 'read bit' [ID_34935]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

In some cases, an error could occur in SLProtocol when trying to update a parameter of type `read bit`.

#### Alarm state changes could be generated at an incorrect time in the trend graph of a monitored parameter that needed to be compared to a relative baseline value [ID_34952]

<!-- Main Release Version 10.2.0 [CU11] - Feature Release Version 10.3.1 -->

In the trend graph of a monitored parameter that needed to be compared to a relative baseline value, in some cases, alarm state changes could be generated at an incorrect time.

> [!NOTE]
> When both the baseline and the factor are stored in parameters, then the baseline parameter, the factor parameter and the monitored parameter must all have the history set option enabled. Also, all history sets should be executed chronologically.

#### Elements would not show up in client applications due to an incorrect credential library GUID stored in their Element.xml file [ID_34956]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

In some cases, an incorrect credential library GUID could get stored in the *Element.xml* file of certain elements. As a result, although they were active and working as expected, those elements would not get loaded into SLNet and would not show up in client applications such as DataMiner Cube.

#### Web apps - Line chart component: Chart would incorrectly display non-existing data when the time window included a period in the future [ID_34959]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

When the time window of a line chart component showing trend data included a period in the future, the chart would incorrectly display non-existing data for that period in the future. From now on, the chart will stop at the current time.

#### Dashboards app & Low-Code Apps: Problem with 'Number of columns' input box [ID_34966]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

When you were editing a dashboard or a low-code app, and the edit side panel was very narrow, in some cases, the *Number of columns* input box on the *Settings* tab could not be used as it would only be partly visible.

Also, in some cases, the value in the *Number of columns* input box could incorrectly not be reset to the factory default.

#### Dashboards app: Tables would lose their conditional coloring after being sorted or filtered [ID_34979]

<!-- MR 10.3.0 - FR 10.3.1 -->

When you sorted or filtered a table fed by e.g. a query filter, the table would incorrectly lose its conditional coloring.

#### Problem with Resource Manager when ResourceStorageType was not specified in Resource Manager settings [ID_34981]

<!-- MR 10.4.0 - FR 10.3.1 -->

In some cases, Resource Manager could throw a NullReferenceException when *ResourceStorageType* was not specified in the `C:\Skyline DataMiner\ResourceManager\Config.xml` file.

#### Web apps: Problem when a trend graph displaying multiple parameters showed data that was partly in the future [ID_34982]

<!-- MR 10.3.0 - FR 10.3.1 -->

When a trend graph displaying multiple parameters showed data that was partly in the future, in some cases, an error could occur.

#### GQI: Problem when a column select or a column manipulation operator was applied before an aggregation operator [ID_35009]

<!-- MR 10.4.0 - FR 10.3.1 [CU0] -->

When a column select or a column manipulation operator was applied before an aggregation operator, the column select or column manipulation operator would incorrectly be ignored. As a result, all columns would be visible in the *group by node* or columns created by the column manipulation would not be added to the options of the *group by node*.

#### Skyline Device Simulator: Problem when running a proxy simulation [ID_35059]

<!-- MR 10.3.0 [CU0]/10.2.0 [CU10] - FR 10.3.1 -->

In some cases, an error could occur in the Skyline Device Simulator when a proxy simulation was being run.

#### Protocols: Problem when working with large timer values and Timerbase [ID_35097]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 [CU0] -->

When working with large timer values and *Timerbase*, in some cases, an integer overflow could occur.

- In x86 versions of SLProtocol, this would result in a default time of 5 minutes for run-time error detection, while waiting a pseudo-random time to continue polling (around 10 days). The run-time error would get reset about every 10 days.

- In x64 versions of SLProtocol, this would cause the timer to become inaccurate. No run-time errors would occur.
