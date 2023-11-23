---
uid: Skyline_DataMiner_DataSources_OpenConfig_2.0.0
---

# Skyline DataMiner DataSources OpenConfig 2.0.0

## New features

#### Improvements related to data grids [ID_37758]

Several improvements have been implemented related to connector data grids:

- Depending on the vendor, a YANG model could be added as a prefix to the name of a node leaf or not. Up to now, the DataMinerConnectorDataGridColumn needed to have the YANG model as prefix in the path to be able to support both situations. This is now no longer required. For example, in the past `openconfig-interfaces:admin-status` had to be defined, while now it will suffice to define `admin-status`.

  > [!NOTE]
  > We still strongly recommended adding the YANG module name as a prefix to have a unique identifier when a value needs to be mapped with a column.

- It is possible that a YANG path contains multiple keys, for example `components/component[name='Ethernet49']/transceiver/physical-channels/channel[index='3']/state/input-power`. Previously, this could cause duplicate key issues, e.g. Ethernet49 could contain index 3 while Ethernet50 also contained index 3. To prevent this, parent keys are now also included as part of the primary key, e.g. `Ethernet49.3` and `Ethernet50.3`, unless the DataMinerConnectorDataGrid is already filtering on the key in its YANG path, e.g. `[name='Ethernet49']`. In the case of this last example, only parent rows with the key Ethernet49 would be allowed, and the primary key of the row would no longer contain that parent value and would for example only be "3".

- Values that are included in JSON can now also be mapped to a data grid. For example, when the path `interfaces` enters with all content in a JSON value, and the data grid has as its path `interfaces/interface/state`, then the values will be mapped to the data grid. When the JSON value contains one single string or one single integer value, together with other container values, then this string value will be taken as the key. When the JSON value contains an array, and no key can be determined in the array list item, the zero-based index of the array will be used as the key. Note that this is a best effort to determine a key, and this requires more processing to iterate over everything. We recommend subscribing or polling the data as close to the data grid path as possible (e.g. subscribe to `interfaces/interface/state` instead of `interfaces`), as the path then clearly indicates the key value, while it is not clear from a JSON value if a property is the key or another value.
