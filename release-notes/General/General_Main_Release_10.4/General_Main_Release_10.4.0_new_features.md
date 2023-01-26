---
uid: General_Main_Release_10.4.0_new_features
---

# General Main Release 10.4.0 – Other new features - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

### Core functionality

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

#### Client-server communication: gRPC instead of .NET Remoting [ID_34797] [ID_34983]

<!-- MR 10.4.0 - FR 10.3.2 -->

Up to now, DataMiner clients and servers communicated with each other using the *.NET Remoting* protocol. From now on, they are also able to communicate with each other via an *API Gateway* module using *gRPC* connections, which are much more secure. For example, as to the use of IP ports, *gRPC* uses the standard port 443, whereas *.NET Remoting* uses the non-standard port 8004. Moreover, the *API Gateway* module is able to restart itself during operation and to automatically recover the connections to clients and SLNet.

When you upgrade DataMiner, the *API Gateway* module will automatically be installed in the `C:\Program Files\Skyline Communications\DataMiner APIGateway\` folder. All logging and program-specific data associated with the *API Gateway* module will be stored in the `C:\ProgramData\Skyline Communications\DataMiner APIGateway\`.

> [!IMPORTANT]
> For now, *gRPC* communication has to be explicitly enabled. If you do not enable it, Cube clients and DMAs will continue to communicate using the *.NET Remoting* protocol.

##### Enabling the use of gRPC connections for communication between Cube and DMA

Do the following on each DMA you want DataMiner Cube instances to connect to via *gRPC* by default.

1. Open the `C:\Skyline DataMiner\Webpages\ConnectionSettings.txt` file.
1. Set the `type` option to *GRPCConnection*.

##### Enabling the use of gRPC connections for inter-DMA communication

In the `DMS.xml` file, you must add redirects for each DMA that should communicate with the other DMAs in the DMS over *gRPC*. Failover Agents also need a redirect to each other's IP address.

For example, in a cluster with two DMAs, with IPs 10.4.2.92 and 10.4.2.93, `DMS.xml` can be configured as follows.

- On the DMA with IP 10.4.2.92:

    ```xml
      <DMS errorTime="30000" synchronized="true" xmlns="http://www.skyline.be/config/dms">
         <Cluster name="pluto"/>
         <DMA ip="10.4.2.92" timestamp=""/>
         <DMA ip="10.4.2.93" id="35" timestamp="2023-01-05 01:24:38" contacted_once="TRUE" lostContact="2023-01-06 00:45:01"/>
         <Redirects>
            <Redirect to="10.4.2.93" via="https://10.4.2.93/APIGateway" user="MyUser" pwd="MyPassword"/>
         </Redirects>
      </DMS>
    ```

- On the DMA with IP 10.4.2.93:

    ```xml
      <DMS errorTime="30000" synchronized="true" xmlns="http://www.skyline.be/config/dms">
         <Cluster name="pluto" synchronize="" timestamp="2022-12-13 12:48:29"/>
         <DMA ip="10.4.2.93" timestamp="" contacted_once="" lostContact=""/>
         <DMA ip="10.4.2.92" timestamp="2023-01-03 23:38:42" contacted_once="TRUE" lostContact="2023-01-06 01:02:00" id="69" uri=""/>
         <Redirects>
            <Redirect to="10.4.2.92" via="https://10.4.2.92/APIGateway" user="MyUser" pwd="MyPassword"/>
         </Redirects>
      </DMS>
    ```

> [!NOTE]
> The passwords in the *pwd* attribute are encrypted and replaced with an encryption token when they are first read out by DataMiner.

#### All DOM objects now have 'LastModified', 'LastModifiedBy', 'CreatedAt' and 'CreatedBy' properties [ID_34980]

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

#### SLAnalytics - Proactive cap detection: Using alarm templates assigned to DVE child elements [ID_35194]

<!-- MR 10.4.0 - FR 10.3.2 -->

When proactive cap detection was enabled, up to now, in case of DVE elements, the alarm template of the parent would always be used.

From now on, if a DVE child element has an alarm template assigned to it, that alarm template will be used. Only when a DVE child element does not have an alarm template assigned to it will the alarm template of the parent be used.

#### DataMiner Object Models: Action buttons can now be configured to launch an interactive Automation script when clicked [ID_35226]

<!-- MR 10.4.0 - FR 10.3.3 -->

An action button can now be configured to launch an interactive Automation script when clicked. To do so, set the *IsInteractive* property of the action to true.

When such a button is clicked in a low-code app, the UI of the interactive Automation script will be displayed in a pop-up window on top of the low-code app.

> [!NOTE]
> One button can only execute one action. So, one button can only execute one interactive Automation script.

#### DataMiner Object Models: New field descriptors [ID_35278]

<!-- MR 10.4.0 - FR 10.3.3 -->

Two new field descriptors have been added to the DataMiner Object Models:

- GroupFieldDescriptor: Can be used to define that a field should contain the name of a DataMiner user group.

- UserFieldDescriptor: Can be used to define that a field should contain the name of a DataMiner user. There is a *GroupNames* property that can be used to define which groups the user can be a part of.

### Service & Resource Management

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
> See also: [Visual Overview: Session variable YAxisResources now supports filters to pass exposers](xref:Cube_Main_Release_10.4.0_other_features_changes#visual-overview-session-variable-yaxisresources-now-supports-filters-id_34857)

### Tools

#### SLNetClientTest tool - 'Connect' window: Enhanced 'Connection Type' and 'Authentication' sections [ID_34712]

<!-- MR 10.4.0 - FR 10.3.1 -->

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

#### SLLogCollector will now order the Standalone BPA Executor tool to execute all BPA tests available in the system [ID_35436]

<!-- MR 10.4.0 - FR 10.3.3 -->

Each time the *SLLogCollector* tool is run, it will now order the *Standalone BPA Executor* tool to execute all BPA tests available in the system and store the results in the `C:\Skyline DataMiner\Logging\WatchDog\Reports\Pending Reports` folder.

The names of the files containing the test results will have the following format: `<BPA Name>_<Date(yyyy-MM-dd_HH)>`
