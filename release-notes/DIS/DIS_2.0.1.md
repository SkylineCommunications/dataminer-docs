---
uid: DIS_2.0.1
---

# DIS 2.0.1

## New features and enhancements

### IDE

#### Enhanced way of connecting to DataMiner Agents \[ID_12067\]\[ID_12403\]

From now on, when DIS connects to a DataMiner Agent, it will always use polling.

Also, a number of changes have been made to the *DMA* tab page of the *DIS Settings* window:

- The *Host* box now only has to contain the IP address of the DataMiner Agent to which you want DIS to connect.

  - Both HTTP and HTTPS are supported.
  - Specifying the IP port is now optional. Default port: 8004
  - Specifying the suffix “/SLNetService” is now optional.

- After having changed the host name, the user name and/or the password, you can now click the *Test connection* button to check the new login settings.

> [!NOTE]
> When you change the host name, the user name and/or the password, the current connection will be closed.

#### Protocols are now saved in UTF-8 with signature \[ID_12126\]

From now on, after informing the user by means of a message box, DIS will automatically save protocol.xml files using the following encoding:

- Unicode (UTF-8 with signature) - Codepage 65001

#### DIS user guide now in HTML5 format \[ID_12250\]

DIS now ships with a user guide in HTML5 format instead of in PDF format.

#### Protocol tag shortcut menus \[ID_12253\]

In the protocol editor, you can now click a small *Down* arrow in front of certain protocol tags to open a shortcut menu. See the table below for an overview of all available commands per protocol tag.

| Protocol tag | Command | Function |
|--------------|---------|----------|
| Param | Edit Table | Open the parameter in the table editor. (Only for table parameters.) |
|       | Generate Write For Read Param | Create an identical parameter of type “Write”. (Only for read parameters.) |
|       | Include in Group | Include the parameter in one of the listed groups of type “poll”. |
|       | Generate new Trigger | Create a new “on change” trigger that will get activated when the parameter changes. |
|       | Generate new QAction | Creates a new blank QAction that will be run when the parameter changes. |
| Trigger | Include in Group | Include the trigger in one of the listed groups of type “trigger” or “poll trigger”. |
|         | Generate new Action | Create a new action. (Only if the trigger is of type “action”.) |
| Action | Include in Group | Include the action in one of the listed groups of type “action” or “poll action”. |
|        | Include in Trigger | Include the action in one of the listed triggers. |
| Session | Include in Group | Include the session in one of the listed groups of type “poll”. |
| Group | Include in Timer | Include the group in one of the listed timers. |
|       | Generate new Trigger (after group) | Create a new “after group” trigger. |
|       | Generate new Parameter | Create a new parameter. (Only if the group is of type “poll”.) |
|       | Generate new Pair | Create a new pair. (Only if the group is of type “poll”.) |
|       | Generate new Session | Create a new session. (Only if the group is of type “poll”.) |
|       | Generate new Action | Create a new action. (Only if the group is of type “action” or “poll action”.) |
| Timer | Generate new Group | Create a new group. |
| Pair | Include in Group | Include the pair in one of the listed groups of type “poll”. |
|      | Generate new Command | Create a new command. |
|      | Generate new Response | Create a new response. |
| Command | Include in Pair | Include the command in one of the listed pairs. |
|         | Generate new Parameter | Create a new parameter. |
| Response | Include in Pair | Include the response in one of the listed pairs. |
|          | Generate new Parameter | Create a new parameter. |

##### IntelliSense

When adding content to Commands, Responses, Pairs, Groups, Triggers, and Timers, an IntelliSense popup will now appear, listing all existing items that can be added.

In case of a group, the listed items will depend on the type of the group, e.g. actions are only added to the list when the type is “action” or “poll action”.

### Validator

### XML Schema

#### RTDisplay tag: New onAppLevel attribute \[ID_12249\]

The *Protocol.Params.Param.Display.RTDisplay* tag now has a new *onAppLevel* attribute.

Set this attribute to “true” if the parameter needs to be accessible on Application Level, i.e. outside the protocol. In a Visio drawing for instance.

#### HTTP header types \[ID_12252\]

The *EnumHttpHeaderField* enumeration now contains all HTTP headers listed on the following pages:

- <http://www.iana.org/assignments/message-headers/message-headers.xhtml>
- <https://en.wikipedia.org/wiki/List_of_HTTP_header_fields>

This new enum is used by the following two attributes:

- Http.Session.Request.Headers.Header@key
- Http.Session.Response.Headers.Header@key

#### New HTTP request verb: DELETE \[ID_12255\]

It is now possible to use the HTTP request verb “DELETE”.

See the following example.

```xml
<Session id="21" name="DeletePreset">
  <Connection id="21">
    <Request verb="DELETE" pid="26">
      <Headers>
        <Header key="Accept">application/xml</Header>
      </Headers>
    </Request>
    <Response>
      <Content pid="120"></Content>
    </Response>
  </Connection>
</Session>
```

#### Interprete tag: New DefaultValue subtag \[ID_12256\]

The *Protocol.Params.Param.Interprete* tag now has a new *DefaultValue* subtag.

#### Command tag: New ascii attribute \[ID_12258\]

The *Protocol.Commands.Command* tag now has a new *ascii* attribute.

This attribute allows you to specify that parameters should be sent as ASCII even if the protocol is in Unicode. You can specify that you want all parameters in the command to be sent as ASCII (e.g. ascii="true") or just some of the parameters, delimited with a semicolon (e.g. ascii="18;40").

The type of this new attribute is the new type *TypeTrueOrSemicolonSeparatedNumbers*.

#### Discreet.Display tag: state attribute now uses type EnumEnabledDisabled \[ID_12259\]

The type of the *state* attribute of the *Protocol.Params.Param.Measurement.Discreets.Discreet.Display* tag is now *EnumEnabledDisabled*.

#### Database tag \[ID_12260\]

In the new *Params.Param.Database* tag, you can now group a number of database-related settings for a particular parameter.

| Tag | Description |
|-----|-------------|
| CQLOptions | Tag that groups a number of Cassandra database options. |
| Clustering | The semicolon-separated list of clustering columns, i.e. the columns that are part of the compound primary key definition. |
| TableProperty | The WITH clause you want to use to set the necessary table properties. |
| Finalizer | The query that has to be executed after the creation of the table. This can be, for example, a query that will preload data or create indexes. |

Example:

```xml
<Param>
  <Database>
    <CQLOptions>
      <Clustering>1;2</Clustering>
      <TableProperty>
        CLUSTERING ORDER BY (&quot;[PID:52]&quot; DESC)
      </TableProperty>
      <Finalizer>
        CREATE INDEX IF NOT EXISTS ON [TABLE] ([PID:52])
      </Finalizer>
    </CQLOptions>
  </Database>
</Param>
```

#### New XML tags and attributes \[ID_12261\]

When writing a protocol.xml file, you can now replace a number of legacy tags and attributes by new counterparts.

See the following tables for an overview of the new tags and attributes.

| Legacy tag/attribute | New tag/attribute |
| -------------------- | ----------------- |
| Protocol.ExportRules | Protocol.DVEs.ExportRules |
| Protocol.Icon | Protocol.Options.Icon |
| Protocol.NoTimeout | Protocol.Options.NoTimeouts.NoTimeout |
| Protocol.SNMP | Protocol.Options.GenerateMIB<br>- auto<br>- true<br>- false |
| Protocol.SNMP@includePages | Protocol.Options.GenerateMIB<br>@includePages<br>- true<br>- false |
| Protocol.Type | Protocol.Connections.Connection.Type |
| Protocol.Type@advanced | Protocol.Connections |
| Protocol.Type@advancedConnections (“names:” section) | Protocol.Connections.Connection@Name |
| Protocol.Type@communicationOptions | \[see separate section below\] |
| Protocol.Type@databaseOptions | \[see separate section below\] |
| Protocol.Type@options | \[see separate section below\] |
| Protocol.Type@overrideTimeoutDVE | Protocol.Options.OverrideTimeoutDVE |
| Protocol.Type@relativeTimers | Protocol.Timers@relativeTimers<br>- true<br>- false |

##### Protocol.Type@communicationOptions

| Existing tag/attribute | New tag/attribute |
| ---------------------- | ----------------- |
| postPonePortInitialisation | Protocol.Options.PostPonePortInitialisation<br>- true<br>- false (default) |
| closeConnectionOnResponse | Protocol.Connections.Connection.<br>CommunicationOptions.<br>CloseConnectionOnResponse<br>- true<br>- false (default) |
| redundantPolling | Protocol.Connections.Connection.<br>RedundancyGroup<br> -  redundancy group ID (uint) |
| chunkedHTML | Protocol.Connections.Connection.<br>CommunicationOptions.ChunkedHTML<br>- true<br>- false (default) |
| asyncWMI | \[no longer used\] |
| makeCommandByProtocol | Protocol.Connections.Connection.<br>CommunicationOptions.<br>MakeCommandByProtocol<br>- true<br>- false (default) |
| maxReceiveBuffer:\<int value> | Protocol.Connections.Connection.<br>CommunicationOptions.MaxReceiveBuffer<br>- Number of bytes received before they are buffered in SLProtocol (uint) |
| smartIpHeader | Protocol.Connections.Connection.<br>CommunicationOptions.SmartIpHeader<br>- true<br>- false (default) |
| notifyConnectionPIDs:\<pid>\[,\<pid>\] | Protocol.Connections.Connection.<br>CommunicationOptions.<br>NotifyConnectionPID.Connections<br>- Parameter ID (uint)<br>Protocol.Connections.Connection.<br>CommunicationOptions.<br>NotifyConnectionPID.Disconnections<br>- Parameter ID (uint) |
| customRedirect | Protocol.Connections.Connection.<br>CommunicationOptions.CustomRedirect<br>- true<br>- false (default) |
| packetInfo:\<string> | Protocol.Connections.Connection.<br>CommunicationOptions.PacketInfo.<br>LengthIdentifierOffset<br>- uint<br>Protocol.Connections.Connection.<br>CommunicationOptions.PacketInfo.<br>LengthIdentifierLength<br>- uint<br>Protocol.Connections.Connection.<br>CommunicationOptions.PacketInfo.<br>IncludeLengthIdentifier<br>- true<br>- false (default)<br>Protocol.Connections.Connection.<br>CommunicationOptions.PacketInfo.<br>LittleEndian<br>- true<br>- false (default) |
| maxConcurrentConnections:\<int> | Protocol.Connections.Connection.<br>CommunicationOptions.<br>MaxConcurrentConnections<br>- Number of clients that can connect to the port (uint)<br>Protocol.Connections.Connection@ID<br>- 0-based connection ID (uint) |
| useAgentBinding | Protocol.Options.UseAgentBinding<br>- true<br>- false (default) |

##### Protocol.Type@databaseOptions

| Existing tag/attribute | New tag/attribute |
| ---------------------- | ----------------- |
| customDataIDs | Protocol.Options.DataBaseOptions.CustomDataIDs<br>- true<br>- false (default) |
| partitionedTrending | Protocol.Options.DataBaseOptions.PartitionedTrending<br>- true<br>- false (default) |

##### Protocol.Type@options

| Existing tag/attribute | New tag/attribute |
| ---------------------- | ----------------- |
| forceDefaultAlarming | Protocol.Options.ForceDefaultAlarming |
| exportProtocol | Protocol.DVEs.DVEProtocols<br>Protocol.DVEs.DVEProtocols.DVEProtocol@name<br>- Name of the DVE protocol (string)<br>Protocol.DVEs.DVEProtocols.DVEProtocol@tablePID<br>- Parameter ID of table used to create the DVE elements (uint)<br>Protocol.DVEs.DVEProtocols.DVEProtocol.ElementPrefix<br>- true<br>- false (default) |
| UNICODE | Protocol.Options.Encoding<br>- ascii (default)<br>- unicode |
| DISABLEVIEWREFRESH | Protocol.Options.DisableViewRefresh<br>- true<br>- False (default) |

## Bug fixes

#### Error when re-attaching after an element restart \[ID_11806\]

In some cases, an error message would appear when re-attaching to an element that had been restarted while Microsoft Visual Studio was being attached to the SLScripting process.

When the error message was closed, Microsoft Visual Studio would automatically restart, and the SLScripting process on the DataMiner Agent would encounter a problem.

#### XML tooltips difficult to read when Visual Studio is set to Dark Theme \[ID_11857\]

When in Visual Studio, the color theme was set to “Dark”, the tooltips in the XML editor would be hard to read. Now, all parts of the DIS user interface have been made compatible with the available color themes in Visual Studio.

#### Problem with XML/C# synchronization \[ID_12131\]

In some cases, the QAction code in the protocol.xml file would no longer match the code in the C# project. A number of enhancements have now been made to the way in which the protocol.xml file and the C# project are synchronized.

#### Problem when opening the display editor \[ID_12402\]

In some cases, an error could be thrown when you opened the display editor.
