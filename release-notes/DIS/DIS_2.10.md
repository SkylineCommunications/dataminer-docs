---
uid: DIS_2.10
---

# DIS 2.10

## New features

### IDE

#### Display editor: Editing multiple parameters at once \[ID_17829\]

In the Display editor, it is now possible to enable or disable alarm monitoring and trending for multiple parameters at once.

Also, after selecting an option in the right-click menu (e.g. *Trending \> Enabled*), the menu will now stay open, allowing you to immediately select another option (e.g. *Alarm \> Enabled*).

> [!NOTE]
> Menu options that can only be used after selecting one single item will be unavailable after selecting multiple items.

#### Display editor: Enhanced behavior when multiple parameters were placed at the same location \[ID_17848\]

Up to now, in the Display editor, when you placed two parameters at the same location, a warning would appear when those parameters were not a valid read/write pair.

From now on, when you place two parameters at the same location, a red box will be drawn around those parameters, and a warning icon will appear next to the page. You can then drag one of the parameters to another location to resolve the problem.

#### DIS tree: Enhanced visualization of parameter groups \[ID_17908\]

In the DIS tree, the visualization of the Protocol.ParameterGroups tag and all its subtags has been improved.

| Tag                                         | Information displayed             |
|---------------------------------------------|-----------------------------------|
| Protocol.ParameterGroups                    | Amount of parameter groups        |
| Protocol.ParameterGroups.Group              | id, name and type                 |
| Protocol.ParameterGroups.Group.Params       | Amount of parameters in the group |
| Protocol.ParameterGroups.Group.Params.Param | id                                |

#### DIS settings are now stored per Visual Studio instance \[ID_18256\]

As from Visual Studio 2017, it is possible to install multiple Visual Studio instances next to each other (Professional, Community, Enterprise), each with its own settings, extensions, modules, etc.

Up to now, all DIS settings were shared across all instances. Now, DIS settings will be stored per instance.

If no settings file exists yet for a particular instance, then DIS will first try to copy it from its former location in order to prevent existing settings from getting lost while upgrading to DIS v.2.10.

### XML Schema

#### New attribute added to schema: Protocol.SeverityBubbleUp@statePid \[ID_17950\]

The following attribute has been added to the protocol schema:

- Protocol.SeverityBubbleUp@statePid

#### New attribute added to schema: Protocol.Params.Param.Database.ColumnDefinition@default \[ID_17952\]

The following attribute has been added to the protocol schema:

- Protocol.Params.Param.Database.ColumnDefinition@default

#### New tag added to schema: Protocol.Params.Param.ArrayOptions.ColumnOptions \[ID_17953\]

The following tag has been added to the protocol schema:

- Protocol.Params.Param.ArrayOptions.ColumnOptions

#### New tag added to schema: Protocol.Ownership \[ID_17955\]

The following tag has been added to the protocol schema:

- Protocol.Ownership

## Changes

### Enhancements

#### IDE: Enhanced performance during DIS startup \[ID_17769\]

Due to a number of enhancements, overall performance has increased during DIS startup.

#### Validator: Enhanced attribute checks \[ID_17853\]

A number of enhancements have been made with regard to attribute checks.

#### Validator: List of restricted parameter names has been updated \[ID_17906\]

The list of restricted parameter names has been updated.

#### Validator: Enhanced behavior in case of non-existing trending attribute \[ID_17912\]

From now on, when a \<Param> tag does not contain a *trending* attribute, the Validator will act as follows:

- If the parameter is of type “read”, the Validator will consider the value of the *trending* attribute to be equal to the value of the *RTDisplay* tag.
- If the parameter is of type “write”, the Validator will consider the value of the *trending* attribute to be false.

#### Protocol schema: Updated attribute rules \[ID_17945\]

The following attribute now has to contain a non-empty string when present:

- Protocol.App@type

The following attributes are now required attributes:

- Protocol.AlarmLevelLinks.AlarmLevelLink@destination
- Protocol.AlarmLevelLinks.AlarmLevelLink@id
- Protocol.AlarmLevelLinks.AlarmLevelLink@remoteElement
- Protocol.Chains.Chain@name
- Protocol.Chains.Chain.Field@name
- Protocol.Chains.Chain.Field@pid
- Protocol.ExportRules.ExportRule@table
- Protocol.ExportRules.ExportRule@tag
- Protocol.ExportRules.ExportRule@value
- Protocol.ParameterGroups.Group@type
- Protocol.Http.Session.Connection.Response.Headers.Header@pid
- Protocol.Params.Param.Display.ParametersView@type
- Protocol.Params.Param.Display.ParametersView.Parameters.Parameter@id
- Protocol.Params.Param.Icon@ref
- Protocol.Params.Param.Interprete.Scale@low
- Protocol.Params.Param.Interprete.Scale@lowdata
- Protocol.Params.Param.Interprete.Scale@high
- Protocol.Params.Param.Interprete.Scale@highdata
- Protocol.QActions.QAction@name
- Protocol.Relations.Relation@path
- Protocol.Threads.Thread@connection
- Protocol.Timers.Timer@id
- Protocol.Topologies.Topology.Cell@name
- Protocol.Topologies.Topology.Cell@table
- Protocol.Topologies.Topology.Cell.Link@dest
- Protocol.Topologies.Topology.Cell.Link@source
- Protocol.TreeControls.TreeControl@parameterId
- Protocol.TreeControls.TreeControl.Hierarchy.Table@id

#### Protocol schema: A number of ids can no longer start with a zero \[ID_17946\]

The following ids can no longer start with a zero:

- Protocol.Params.Param@id
- Protocol.Actions.Action@id
- Protocol.Commands.Command@id
- Protocol.Groups.Group@id
- Protocol.HTTP.Session@id
- Protocol.Pairs.Pair@id
- Protocol.QActions.QAction@id
- Protocol.Responses.Response@id
- Protocol.Timers.Timer@id
- Protocol.Triggers.Trigger@id

#### Protocol schema: SlowTime tag removed \[ID_17948\]

The following tag has been removed from the protocol schema:

- Protocol.Timers.Timer.SlowTime

#### Protocol schema: Trigger.On ‘element’ and Trigger.Time ‘after create’ removed \[ID_17949\]

The following values have been removed from the protocol schema:

- The “element” value has been removed from the EnumTriggerOn list (which lists the values that can be used in the Protocol.Triggers.Trigger.On tag).
- The “after create” value has been removed from the EnumTriggerTime list (which lists the values that can be used in the Protocol.Triggers.Trigger.Time tag).

#### Protocol schema: Protocol.IntegrationID tag now has to contain 'DMS-DRV-XXXX' \[ID_17951\]

The Protocol.IntegrationID tag now has to contain “DMS-DRV-XXXX” (XXXX being a number).

#### Protocol schema: Icon tag enhancements \[ID_17954\]

The Protocol.Icon tag is now of type “TypeNonEmptyString”.

Also, the Protocol.Params.Param.Icon@ref attribute is no longer required.

### Fixes

#### IDE: Problem with snippets after updating or reinstalling DIS \[ID_17754\]

After updating or reinstalling DIS, in some cases, it would no longer be possible to select a DIS snippet. This problem has now been fixed.

#### Validator: Incorrect warning could appear when a \<Param> tag contained a dependencyId attribute \[ID_17907\]

When a \<Param> tag contained a *dependencyId* attribute, in some cases, an incorrect warning could appear. This problem has now been fixed.
