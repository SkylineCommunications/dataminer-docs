---
uid: Skyline_DataMiner_DataSources_OpenConfig_1.0.3
---

# Skyline DataMiner DataSources OpenConfig 1.0.3

## New features

#### Support for state column parameter [ID_37526]

The *DataMinerConnectorData* now supports a state column parameter. This will keep track of the state of the row, similar to how this is done for SNMP parameters. However, in this case the created parameter still needs to be of type "retrieved".

To add a state, add a new `DataMinerConnectorDataGridColumn(stateParameterId, Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Protocol.DataMapper.Enums.DataMinerConnectorDataGridColumnType.State)` to the data grid.

By default, when a state column is added, rows will no longer be automatically removed. You can activate automatic removal again by setting the state column property *IsAutoDelete* to true.

You can manually remove rows that have the deleted state by calling one of the following methods on the *DataMinerConnectorDataMapper*:

- `RemoveMissingRowForPid(int tablePid, string pk);`

  Removes the row with this PK if it has the deleted state.

- `RemoveMissingRowsForPid(int tablePid, IENumerable<string> pks);`

  Removes the rows with these PKs if they have the deleted state.

- `RemoveMissingRowsForPid(int tablePid)`

  Removes all the rows that have the deleted state.

The state parameter has the same discrete values as an SNMP state parameter. You can overwrite these values by assigning a function to *OnRawValueChange* of the state column. The incoming *args.Value* of that function can then be converted to an integer and cast as a *Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Protocol.DataMapper.Enums.DataMinerConnectorDataGridRowState* to indicate the state it represents. The returned object of this function will then be the parameter value of the cell that is written to the table. Note that this is only how this is filled in in the parameter, but this changes nothing to the internal deleted state of a row.

The state "Equal" is already present in the enum but is not used yet. At present, it will have the state "Updated" even if all values are equal.

#### Delete method added [ID_37548]

The *Delete* method has been added to the GnmiClient, so that it is now possible to clear a parameter with an OpenConfig set. The method accepts the path as string or the path as *Gnmi.Path* object.

When a path is specified for an element that has child elements, these child elements will be recursively deleted.

## Changes

### Enhancements

#### Non-basic value type now set as JSON [ID_37559]

When a value enters as a type that is not basic, e.g. a string array, this value will now be passed as JSON by the data mapper. This way, *OnRawValueChange* can then be used to fully custom-process this JSON value and set the parameter as desired. Alternatively, when this method is not implemented, the parameter will be set as JSON string.

#### DataMinerConnectorParameters filled in when parent container with data enters [ID_37599]

​When a container entered with data (e.g. system), the underlying values (e.g. system/state/current-datetime) were not mapped with a DataMinerConnectorParameter (i.e. a single parameter). This has been modified so that DataMinerConnectorParameters will be filled in when an parent container enters with data.

#### Support added for Path.Origin [ID_37608]

​When the beginning of a string path for a DataMinerConnectorDataGrid or DataMinerConnectorParameter is followed by `:/`, this first part of the path will now be used in the *Path.Origin* property. For example, if the string path is equal to `eos_native:/SysDb/ptp/status/parentDS`, *Path.Origin* will be `eos_native`, and *Path.Elem* will consist of `SysDb/ptp/status/parentDS`.

### Fixes

#### Not possible to subscribe to multiple tables in a container [ID_37545]

​When the data mapper contained a data grid with a path (e.g. interfaces/interface/state) and there was also another data grid present with a path to a subdirectory of the path of the first data grid (e.g. interfaces/interface/state/counters), not all tables were updated. In addition, when the key was part of a parent path and the value was returned in JSON format, the key was not resolved.

Parent keys will now also be resolved and included in the primary key, separated by periods, to make the primary key unique. If a data grid already filters on a key value in the path, that parent key will not be included in the primary key.
