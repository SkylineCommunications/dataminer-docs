---
uid: General_Main_Release_10.2.0_new_features_3
---

# General Main Release 10.2.0 - New features (part 3)

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!NOTE]
> A DataMiner Installer v10.2 is available on [DataMiner Dojo](https://community.dataminer.services/download/dataminer-installer-v10-2/).
>
> - For 64-bit systems only.
> - No longer contains the necessary files to install MySQL.
> - Unattended cluster installation is not supported.
> - On Windows Server 2022, an “Internal server error” is thrown after installation. Workaround:
>   - Go to <https://www.iis.net/downloads/microsoft/url-rewrite>.
>   - Download and install the URL rewrite module.
>   - Go to <http://localhost/root> and verify whether the root page is shown.

### DMS Security

#### Importing domain users and user groups from an Azure Active Directory \[ID_28444\]

DataMiner is now able to import domain users and user groups from an Azure Active Directory.

In the *DataMiner.xml* file, an \<AzureAD> element should be present. See the following example.

```xml
<DataMiner>
  ...
  <AzureAD tenantId=""
           clientId=""
           clientSecret=""
           username=""
           password=""/>
  ...
</DataMiner>
```

> [!NOTE]
>
> - Currently, users imported from an Azure AD can only log in via SAML.
> - In an upcoming release, functionality will be added so that this can be configured directly in DataMiner Cube instead.

#### DataMiner Cube - System Center: New Planned Maintenance app permissions \[ID_28164\] \[ID_28541\]

In the *Users/Groups* section of System Center, it is now possible to configure the following new user permissions.

| User permission | Description                                                   |
|-----------------|---------------------------------------------------------------|
| UI available    | Permission to view the Planned Maintenance (PLM) app in Cube. |
| Add/Edit        | Permission to add or edit items in the PLM app.               |
| Delete          | Permission to delete items in the PLM app.                    |
| Configure       | Permission to configure the PLM app.                          |

#### Jobs and ReservationInstances: SecurityViewID property replaced by SecurityViewIDs property \[ID_28311\]

In Jobs and ReservationInstances, the single-value SecurityViewID property has now been replaced by a multiple-value SecurityViewIDs property.

If, for a particular job or ReservationInstance, this property contains view IDs, then the job or ReservationInstance will only be accessible to users who have access to at least one of the specified views.

For example, users with Read access to the view with ID 10 who display a list of jobs or ReservationInstances will only see the jobs or ReservationInstances of which the list of values in the SecurityViewIDs property includes “10” or no IDs at all.

> [!NOTE]
> The values in this property can be filter using a 'Contains' filter.
> Example: JobExposers.SecurityViewIDs.Contains(136)

#### DataMiner Cube - System Center: User permissions for 'Live Sharing' and 'Cloud Connected Agents' features have been reorganized \[ID_29004\]

In the *Users/Groups* section of *System Center*, the user permissions for the Live Sharing and Cloud Connected Agents features have been reorganized.

Under *General \> Live sharing*, you can now find the following user permissions:

- UI Available
- Share
- Edit
- Unshare

Under *System configuration \> Cloud gateway*, you can now find the following user permissions:

- Connect to cloud
- Disconnect from cloud
- Configure gateway service

> [!NOTE]
>
> - The user permissions listed under *Live sharing* are included in the *Power users* preset and higher.
> - The user permissions under *Cloud gateway* are included in the *Administrators (read-only access to Security)* preset and higher.

#### DataMiner Cube - System Center: New user permission \[ID_29097\]\[ID_29291\]

In the *Users/Groups* section of System Center, you can now configure the following new user permission:

- System Configuration \> DataMiner Object Manager (DOM) \> Module Settings

> [!NOTE]
> This user permission is included in the *Administrators (read-only access to Security)* preset and higher.

#### New functions user permissions \[ID_29659\] \[ID_30114\] \[ID_30122\]

Under *Modules* > *Functions*, you can now find the following user permissions:

- Read
- Add
- Edit
- Delete
- Configure
- Generate protocol

These permissions apply to the upload and delete function options in the Protocols and Templates app, as well as to the Functions app, which is currently only available in soft launch. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

When upgrading to DataMiner version 10.1.7, these six permissions will automatically be granted to all user groups that have been granted the *Modules \> Resources \> Configure functions* permission.

#### Automatic LDAP notifications disabled by default \[ID_30290\]

Up to now, when Active Directory was used, DataMiner would automatically receive updates whenever changes occurred in the domain. From now on, this feature will be disabled by default. Instead, DataMiner will now poll the LDAP system on an hourly basis to check for changes.

> [!NOTE]
> If you want to enable the automatic LDAP notification feature, open the *DataMiner.xml* file and set the LDAP notifications attribute to true.

#### New user permission to send emails via DataMiner \[ID_30425\]

A new user permission *Email* > *Send via DataMiner System* is now available under the general user permissions in Users/Groups section of System Center. This user permission determines whether a user is allowed to send emails via the DataMiner System.

#### DataMiner Cube: Allow users to log in with a local user account even when external authentication via SAML is activated \[ID_30981\]\[ID_31043\]

By default, DataMiner Cube provides two methods to log in to a DataMiner Agent:

- Logging in “automatically” using Windows domain credentials.
- Entering an explicit username/password combination.

When external authentication is activated on a DataMiner Agent, bypassing the external authentication provider by entering an explicit username/password combination is only allowed for the Administrator user. However, from now on, when using external authentication via SAML, bypassing the external authentication by entering a username/password combination will be allowed for any local DataMiner user account.

#### DataMiner Cube - System Center: New & updated user permissions \[ID_30989\]\[ID_31208\]

In the *Users/Groups* section of System Center, new user permissions have been added and existing user permissions have been updated.

##### New user permissions

- Modules \> Process Automation \> Add/Edit
- Modules \> Process Automation \> Delete
- Modules \> Process Automation \> Read
- Modules \> Services \> Profiles \> Definitions \> Delete
- Modules \> Services \> Profiles \> Instances \> Delete

##### New and restructured user permissions

- Modules \> Profiles \> UI available
- Modules \> Profiles \> All except instances \> Add/Edit
- Modules \> Profiles \> All except instances \> Delete (NEW)
- Modules \> Profiles \> Instances \> Add/Edit
- Modules \> Profiles \> Instances \> Delete (NEW)
- Modules \> Profiles \> Configure (with tooltip providing more information) (NEW)

##### Updated user permissions

- Users are no longer allowed to add an instance to a newly created service profile definition that has not yet been saved.
- When a user who has been granted the Modules \> Services \> Profiles \> Definitions \> Delete permission deletes a service profile definition, all instances of that definition must also be deleted. A confirmation box will now appear to make the user aware of this. Also, a confirmation box will now appear when you try to delete definition instances.

#### Users authenticated by Azure AD using SAML can now automatically be created and assigned to groups \[ID_31057\] \[ID_31184\]

Users authenticated by Azure AD using SAML can now automatically be created and assigned to groups in DataMiner.

> [!NOTE]
> If you plan to implement this new feature, make sure DataMiner is not configured to import users and/or groups from Azure AD. This might cause users to be created twice.

To configure DataMiner to automatically (a) create users authenticated by Azure AD using SAML and (b) assign them to groups, proceed as follows:

1. Make sure DataMiner is registered as an Enterprise Application in Azure AD.
1. Go to *Users and groups* and add the necessary users and groups to the Enterprise Application.
1. Go to *Single sign-on*, select *SAML*, and edit the following settings in “Basic SAML Configuration”:

   - Set *Entity ID* to `https://[your application name]`.
   - Under *Reply URL*, specify the following URLs:

     ```txt
     https://[your application name]/root/ 
     https://[your application name]/ticketing 
     https://[your application name]/jobs 
     https://[your application name]/monitoring 
     https://[your application name]/dashboard 
     https://[your application name]/root 
     https://[your application name]/login 
     https://[your application name]
     ```

   - Set *Sign on URL* to `https://[your application name]`.

1. Go to *User Attributes & Claims* and add a group claim.

   > [!NOTE]
   > If you add a group claim, the account name of the group will only be sent via SAML when the groups are synchronized. Otherwise, the ID of the group will be sent instead.

1. In DataMiner Cube, add the necessary groups.

1. In the DataMiner.xml, configure the \<ExternalAuthentication> element as shown in the following example.

   ```xml
   <DataMiner ...>
     ...
     <ExternalAuthentication type="SAML" ipMetadata="[Path/URL of the identity provider’s metadata file]" spMetadata="[Path/URL of the service provider’s metadata file]" timeout="300">
       <AutomaticUserCreation enabled="true">
         <EmailClaim>http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress</EmailClaim>
         <Givenname>http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname</Givenname>
         <Surname>http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname</Surname>
         <Groups claims=“true”>[group claim name]</Groups>
       </AutomaticUserCreation>
     </ExternalAuthentication>
     ...
   </DataMiner>
   ```

   > [!NOTE]
   >
   > - In Azure AD, the ipMetadata URL can be found under *Single sign-on \> SAML Signing Certificate – App Federation Metadata*.
   > - If, in the *Groups* element, you set the *claims* attribute to “false”, no claims will be used to add users to groups. In that case, the name of the group as specified in Cube will be used instead. A user can only be added to a single group this way.
   > - If, in the *Groups* element, you set the *claims* attribute to “false”, the user information that is created will not be updated.

1. Save the DataMiner.xml file.

1. Create an spMetadata file as described in the DataMiner Help section “Creating a DataMiner metadata file”.

   > [!NOTE]
   > In Azure AD, the EntityID can be found under *Single sign-on*. It is not the application ID.

1. Restart the DataMiner Agent.

#### Azure AD application query support \[ID_31059\]

DataMiner now supports Azure AD application querying.

From now on, a DataMiner Agent will no longer need a user name and password to connect to Azure AD. An authentication secret will suffice.

For this feature to work, the following permissions must be set in Azure AD:

- Application permission for User.Read.All and GroupMember.Read.All
- Delegated permission for User.Read

#### Web apps: Using custom HTTP headers will now be allowed \[ID_31090\]

From now on, the DataMiner web apps will allow the use of custom HTTP headers. Up to now, custom HTTP headers would by default be deleted.

As a result, it will now be possible to configure custom HTTP headers in IIS Manager to allow web applications to be secured with policies like HSTS, XSS, CSP, CORS, etc.

> [!NOTE]
> DataMiner web applications might still overwrite certain HTTP headers.

### DMS Protocols

#### Extension methods moved from QActionHelperBaseClasses to SLManagedScripting \[ID_27995\] \[ID_28675\]

The following extension methods have now been moved from the QActionHelperBaseClasses library to the SLManagedScripting library and are now instance methods of the SLProtocol interface.

##### static class NotifyProtocol

- AddRow(this SLProtocol protocol, int tableId, string row)
- AddRow(this SLProtocol protocol, int tableId, object\[\] row)
- AddRow(this SLProtocol protocol, int tableId, object\[\] row, bool\[\] keyMask)
- AddRowReturnKey(this SLProtocol protocol, int tableId)
- AddRowReturnKey(this SLProtocol protocol, int tableId, object\[\] row)
- DeleteRow(this SLProtocol protocol, int tableId, string rowKey)
- DeleteRow(this SLProtocol protocol, int tableId, int row)
- DeleteRow(this SLProtocol protocol, int tableId, string\[\] rows)
- Exists(this SLProtocol protocol, int tableId, string key)
- GetKeyPosition(this SLProtocol protocol, int tableId, string key)
- RowCount(this SLProtocol protocol, int tableId)
- GetKeys(SLProtocol^ protocol, int tableId, KeyType type = KeyType.Index)
- ClearAllKeys(this SLProtocol protocol, int tableId)
- GetKeysForIndex(this SLProtocol protocol, int columnPid, string value)
- FillArray(this SLProtocol protocol, int tableId, object\[\] columns, DateTime? timeInfo = null)
- FillArray(this SLProtocol protocol, int tableId, List\<object\[\]\> columns, DateTime? timeInfo = null)
- FillArrayNoDelete(this SLProtocol protocol, int tableId, object\[\] columns, DateTime? timeInfo = null)
- FillArrayNoDelete(this SLProtocol protocol, int tableId, List\<object\[\]\> columns, DateTime? timeInfo = null)
- FillArray(this SLProtocol protocol, int tableId, List\<object\[\]\> rows, SaveOption option, DateTime? timeInfo = null)
- FillArrayWithColumn(this SLProtocol protocol, int tableId, int columnPid, object\[\] keys, object\[\] values, DateTime? timeInfo = null)
- SetParameterBinary(this SLProtocol protocol, int pid, byte\[\] data)

##### static class ProtocolExtenders

- void Log(this SLProtocol protocol, string message, LogType logType = LogType.Allways, LogLevel logLevel = LogLevel.DevelopmentLogging)

> [!NOTE]
>
> - All overloads of the above-mentioned methods, which take in a QActionTableRow object instead of an object\[\], have been deleted.
> - The static methods could not be deleted. They have been marked obsolete instead.
> - The following types have moved from the QActionHelperBaseClasses DLL file to the SLManagedScripting DLL file:
>   - class NotifyProtocol
>   - enum LogType
>   - enum LogLevel

#### Enhanced (direct) view column option 'view' \[ID_28448\]

The following (direct) view column option has been enhanced.

```txt
view=linkedPid:elementkeycolumnpid:remotedatatablepid:remotedatacolumnidx
```

This option can be configured in three different ways. See the table below. In the examples, table 11000 is a (direct) view on table 1000.

| Type of filtering | Example | Description |
|--|--|--|
| Local filtering | view=:1004:1000:1 | The elementkeycolumnpid refers to another column of the same table. Each row will be requested from the element referred to by the DMAID/EID found in parameter 1004. |
| Foreign key filtering | view=1003:1105:1000:2 | The elementkeycolumnpid refers to a column of the table linked by the foreign key found in parameter 1003. Each row will be requested from the element referred to by the DMAID/EID found in parameter 1105, which is linked via the foreign key in parameter 1003. |
| No filtering | view=:1401:1000:1 | The elementkeycolumnpid refers to a column of another table, which is not linked to the local table (no linkedPid is provided). Each row will be requested from the elements referred to by the DMAID/EID items found in column 1401. Note: If the remote elements contain duplicate keys, then this can cause data to be overwritten. |

#### New 'FlushPerDatagram' option for smart-serial UDP connections \[ID_28999\]

When configuring the port settings of a smart-serial UDP connection, it is now possible to specify a *FlushPerDatagram* option.

When this option is set to true, any datagram received on the connection will be forwarded to SLProtocol, which will then store it in the response parameter.

Example:

```xml
...
<PortSettings>
    <FlushPerDatagram>true</FlushPerDatagram>
</PortSettings>
...
```

#### InterfaceInfo now contains an IsInternal flag to mark whether an interface is external or internal \[ID_29314\]

The InterfaceInfo class has been extended with an IsInternal flag that allows you to specify whether an interface is external or internal.

In order to get the information in the InterfaceInfoEventMessage, the following flag needs to be set in the client that is subscribing on the event:

```csharp
ClientCompatibilityFlags.SupportsInternalInterfaces
```

Also, the Interface class in SLManagedAutomation and the ConnectivityInterface class in SLManagedScripting have been extended with the IsInternal flag. The following public methods have been provided.

- SLManagedScripting

    ```csharp
    Dictionary<int, ConnectivityInterface> GetInternalConnectivityInterfaces(int dmaId, int elementId);
    Dictionary<int, ConnectivityInterface> GetExternalConnectivityInterfaces(int dmaId, int elementId);
    ```

- SLManagedAutomation

    ```csharp
    Interface[] GetInternalInterfaces();
    Interface[] GetExternalInterfaces();
    ```

#### DataMiner Connectivity Framework: DCF interfaces can now be marked internal \[ID_29326\] \[ID_29438\]

In an element protocol, it is now possible to make a distinction between

- internal DCF interfaces (i.e. virtual interfaces used within the protocol), and
- external DCF interfaces (i.e. physical interfaces that will appear in interface lists in the UI).

By default, all DCF interfaces are considered external. Interfaces that should be considered internal, have to be explicitly marked as internal. See the following example.

```xml
<Protocol xmlns="http://www.skyline.be/protocol">
  ...
  <ParameterGroups>
    <Group id="1" name="500_in" type="in" dynamicId="500" dynamicIndex="*"       isInternal="true"/>
    <Group id="2" name="1000_out" type="out" dynamicId="1000" dynamicIndex="*"/>
    <Group id="3" name="1500_inout" type="inout" dynamicId="1500" dynamicIndex="*"/>
    <Group id="4" name="2000_inout" type="inout" dynamicId="2000" dynamicIndex="*"/>
    <Group id="5" name="fixed" type="inout" isInternal="true"/>
  </ParameterGroups>
  ...
```

#### SNMP polling: Retrieving polling delta time per row \[ID_29445\]

The notify protocol command NT_GET_BITRATE_DELTA, which can be launched from within a QAction, has been expanded to be able to retrieve the delta times per row when polling an SNMP table. However, this will only work for the multipleGetNext and multipleGetBulk polling schemes since only these polling schemes retrieve entire rows per request.

It is advised to enable this feature at startup using the notify protocol command NT_SET_BITRATE_DELTA_INDEX_TRACKING with either a single parameter ID or multiple parameter IDs. This information will not be saved and will only be kept as long as the element is running. See the following examples. The first call will enable the tracking for parameters 100 and 200. The second call will disable the tracking for parameter 100.

- `protocol.NotifyProtocol(/*NT_SET_BITRATE_DELTA_INDEX_TRACKING*/ 448, new int[] {100, 200}, true);`
- `protocol.NotifyProtocol(/*NT_SET_BITRATE_DELTA_INDEX_TRACKING*/ 448, 100, false);`

Once tracking has been enabled, the information can be retrieved by using the notify protocol command NT_GET_BITRATE_DELTA with a string as second argument. In the following example, the command will return the delta value for the specified key (“1”) of the specified parameter (100). If you set the second argument to an empty string (“”), then the command will return all currently tracked keys for the parameter in question.

`object delta = protocol.NotifyProtocol(269 /*NT_GET_BITRATE_DELTA*/, 100, "1");`

The information will be returned in the following format. If only a single key is requested, the initial array will have a length of 1:

`object[] { object[] {string key1, int delta1}, object[] {string key2, int delta2} }`

> [!NOTE]
>
> - If the requested key could not be found, or if no polling happened since the tracking was enabled, an empty array will be returned.
> - If there were no 2 poll cycles, or if the requested key was only present in 1 poll cycle, then the delta value will be returned as -1.

#### Aggregation: Using regular expressions in the filter \[ID_30199\]

It is now possible to a regular expression in the filtering options of an aggregate action.

##### Syntax 1: Equation with a regular expression defined in a regex attribute

When you use this syntax, add “equation:regex,” to the *options* attribute and specify the regular expression in a separate *regex* attribute.

Example:

```xml
<Action id="1">
  <Name>Regex aggregate with static equation</Name>
  <On id="304">parameter</On>
  <Type options="groupby:2;type:count;equation:regex,;return:3002"      regex="^[a-zA-Z]{2}$">aggregate</Type>
</Action>
```

##### Syntax 2: Equation with a regular expression defined in a parameter

When you use this syntax, add “equation:regex,” to the *options* attribute, followed by the ID of the parameter containing the regular expression.

Example:

```xml
<Action id="2">
  <Name>Regex aggregate with equation in parameter</Name>
  <On id="304">parameter</On>
  <Type options="groupby:2;type:count;equation:regex,3120;return:3102">aggregate</Type>
</Action>
```

##### Syntax 3: Equation value with a regular expression defined in a regex attribute

When you use this syntax, add “equationvalue:” to the *options* attribute, followed by four comma-separated arguments, and specify the regular expression in a separate *regex* attribute.

| Argument | Description                                                                                                |
|----------|------------------------------------------------------------------------------------------------------------|
| a        | Type of equation: “regex”                                                                                  |
| b        | Empty when regular expression is specified in a separate *regex* attribute. |
| c        | The ID of the column parameter to which the equation has to be applied.                                    |
| d        | The row index. If this argument is not specified, the matching will be done on a row by row basis.         |

Example:

```xml
<Action id="3">
  <Name>Regex aggregate with static equation value</Name>
  <On id="306">parameter</On>
  <Type options="groupby:2;type:avg;equationvalue:regex,,304,;return:3202"      regex="^[a-zA-Z]{2}$">aggregate</Type>
</Action>
```

##### Syntax 4: Equation value with a regular expression defined in a parameter

When you use this syntax, add “equationvalue:” to the *options* attribute, followed by four comma-separated arguments.

| Argument | Description                                                                                        |
|----------|----------------------------------------------------------------------------------------------------|
| a        | Type of equation: “regex”                                                                          |
| b        | The ID of the parameter containing the regular expression.                                         |
| c        | The ID of the column parameter to which the equation has to be applied.                            |
| d        | The row index. If this argument is not specified, the matching will be done on a row by row basis. |

Example:

```xml
<Action id="4">
  <Name>Regex aggregate with equation value in parameter</Name>
  <On id="306">parameter</On>
  <Type options="groupby:2;type:avg;equationvalue:regex,3120,304,;return:3302">aggregate</Type>
</Action>
```

> [!NOTE]
> When you opt to store a regular expression in a parameter, this parameter should be a standalone, single-value parameter of type string.

#### View table columns with options like 'view=:x:y:z' or 'view=a:b:c:z' can now be filtered by means of a 'VALUE=' filter \[ID_30237\] \[ID_30809\]

View tables containing a column with view options like “view=:x:y:z” or “view=a:b:c:z” now allow that column to be filtered by means of a “VALUE=” filter (e.g. VALUE=5 == abc).

> [!NOTE]
>
> - These filters will also work when filtering on a column of a view table that refers to a column of another view table.
> - When a directview table links to a view table with remote columns (i.e. view=:x:y:z), it is not yet possible to filter on those columns.
> - Combining filters with AND or OR is not supported.

#### New polling scheme polls SNMP tables by row \[ID_30780\]

A new polling scheme can now be used to poll SNMP tables.

This new scheme works similar to the GetNext/MultipleGet polling scheme, but polls by row instead of by column. In other words, similar to the GetNext/MultipleGet scheme, this new scheme will first poll the instances (if they have not been provided) and will then poll the data row by row.

To use this new polling scheme, add “multipleGet” to the SNMP options of the SNMP table to be polled.

- If you specify the “multipleGet” keyword without additional arguments, by default 10 rows will be polled in a single run. See the following example:

    ```xml
    <SNMP>
      <Enabled>true</Enabled>
      <OID type="complete"     options="instance;multipleGet">1.3.6.1.4.1.34086.2.2.17.5.1</OID>
    </SNMP>
    ```

- If you want to have a specific number of rows polled in a single run, you can specify the “multipleGet” keyword followed by a colon (“:”) and the number of rows to be polled in a single run. In the following example, 5 rows will be polled in a single run:

    ```xml
    <SNMP>
      <Enabled>true</Enabled>
      <OID type="complete"     options="instance;multipleGet:5">1.3.6.1.4.1.34086.2.2.17.5.1</OID>
    </SNMP>
    ```

> [!NOTE]
>
> - The multipleGet option cannot be used together with the multipleGetNext, multipleGetBulk and bulk options.
> - The multipleGet keyword can be used together with options like Subtable.
> - The notify protocol command NT_GET_BITRATE_DELTA, which can be launched from within a QAction, was expanded to be able to retrieve the delta times per row when polling an SNMP table. For more information, see [SNMP polling: Retrieving polling delta time per row \[ID_29445\]](#snmp-polling-retrieving-polling-delta-time-per-row-id_29445). This functionality will now also work in conjunction with the new multipleGet option.
