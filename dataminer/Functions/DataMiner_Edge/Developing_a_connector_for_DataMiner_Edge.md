---
uid: Developing_a_connector_for_DataMiner_Edge
---

# Developing a connector for DataMiner Edge

To run a Python-based integration on an Edge Node, include the integration in the DataMiner connector package.

A connector package (i.e. a *.dmprotocol* package) can contain one or more Python scripts, together with the dependencies and metadata required to execute them on supported Edge Nodes.

## Connector package structure

The connector package contains the following main items:

- A `Description.txt` file.

- The connector protocol, including the `Protocol.xml` file.

- A `Scripts` folder containing a separate subfolder for each Python-based integration.

![](~/dataminer/images/Edge_Connector_Package_Structure.png)

## Uploading a connector package

When you upload an Edge-enabled *.dmprotocol* package, DataMiner stores the scripts in `Protocol/<connector name>/<connector version>/Scripts`. Each script is stored in a separate folder named after its GUID.

DataMiner generates a *dependencies.json* file that lists each script's dependencies, file size, and content hash. The script files and the *dependencies.json* file are synchronized throughout the cluster. Script files larger than 20 MB are not synchronized throughout the cluster.
