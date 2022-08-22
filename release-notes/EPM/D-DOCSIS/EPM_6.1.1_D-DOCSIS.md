---
uid: EPM_6.1.1_D-DOCSIS
---

# EPM 6.1.1 D-DOCSIS

## New features

#### Kafka file handling improvements \[ID_32800\]

To reduce the file size of exports, the Generic Kafka Consumer connector will now export compressed GZ files containing JSON files. In addition, on the *Configuration* page, you can now specify a local export location. When writing to a remote location, the connector will first export to this local location, and then it will copy the file to a remote location. This will speed up the process, preventing situations where a file stream is open for a long time, which can decrease performance in case of high network latency.

The CCAP Platform WM connector has been adjusted to read the new file format. Compression logic has also been added for the export of the Topics workflow, and here too a local export directory is used as an intermediary step when exporting remotely.

Finally, the Cox CBR-8 Platform D-DOCSIS connector has also been adjusted to read the topic response files.

## Changes

### Enhancements

#### Selecting an RPD now shows the associated CCAP cores \[ID_32895\]

The CBR-8 collectors now expose the RPD CCAP cores, so that when you select an RPD in the EPM topology, the CCAP cores associates with this RPD are now shown in the *Data* section.

#### Alarm state for device images adjusted \[ID_32896\]

On the *Overview* page for a CCAP Core, Core Leaf, Spine or Node Leaf device, the device image will now show the highest alarm severity of the data that are shown in the pop-up window when you click the image, instead of the highest alarm state of the entire device.

#### RPD Topology page can now show all service groups \[ID_32897\]

On the *Topology* page for an RPD, next to the device image, the list of service groups is no longer limited to one pair, so that the full list of downstream and upstream service groups can be displayed for an RPD with multiple fiber nodes.

#### Improved CCAP WM DCF workflow \[ID_32898\]

The CCAP WM DCF workflow will now only ingest files that have the same DMA ID as the element requesting the workflow. It will export a DCF EP file with the DMAID_DCF_EP file name. This way there will be only one WM per DMA handling requests from elements on that DMA, and not all DCF data from the system must be read in.

#### Juniper Networks Manager now uses element-level EPMConfig.xml file \[ID_32899\]

Up to now, the cell used for the topology exposer had to be hard-coded in the Juniper Networks Manager CIN Platform connector, which could cause issues when that connector was used for different topology types, e.g. when it was used for an amplifier and a node element and their temperature sensor alarms were linked to the EPM topology.

Since [DataMiner 10.2.2](xref:General_Feature_Release_10.2.2) (RN 32028), it is possible to specify an alias for a topology cell for a specific element by means of an *EPMConfig.xml* file. The connector will now make use of this feature. When an element starts up, it will check if an *EPMConfig.xml* file is needed for the exposer logic. If it is, it will create the file and restart, so that it can use the *EPMConfig.xml* file to make sure that the correct exposer tables are displayed in the Data section of the topology card when the Core Leaf entity is selected, and that the alarms from the exposed tables are correctly linked to the EPM entity.

#### Clicking fiber node now navigates to corresponding data page \[ID_32924\]

When you click a fiber node in the Network visual overview, this will now open the *Fiber Node* data page. At present there is no visual overview page linked to the fiber node.

#### Fine-tuned DMA security \[ID_32927\]

All Cox connectors as well as the DMA security have been fine-tuned to make sure parameter access is better attuned to the type of user.

### Fixes

#### DCF connections not displayed when multiple element tabs were opened \[ID_32925\]

When multiple element tabs were opened, it could occur that DCF connections were not displayed on the topology page. This did not happen when one tab was opened at a time.

#### Spine software version information overlapped with other information \[ID_32926\]

Up to now, the spine software version information could overlap with other system info data. Now more space is provided for this information, so that this will no longer occur.
