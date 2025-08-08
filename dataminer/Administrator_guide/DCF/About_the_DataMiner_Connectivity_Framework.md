---
uid: About_the_DataMiner_Connectivity_Framework
---

# About the DataMiner Connectivity Framework

With the DataMiner Connectivity Framework, you can set up element connectivity. This means that you can configure and visualize signal paths throughout your infrastructure.

In the element protocol, in/out interfaces can be defined, which allow two types of connections to be made in DataMiner:

- Internal connections: connections within the same element.

- External connections: connections from one element to another.

Connections can be set in different ways:

- In Cube, in the element’s *Properties* window or the DCF configuration window. See [Configuring element connectivity in Cube](xref:Editing_element_connections_in_the_Properties_window).

- In the matrix interface of a matrix element. See [Configuring matrix parameters](xref:Configuring_matrix_parameters).

- In Visual Overview. See [Implementing DataMiner Connectivity Framework functions](xref:Implementing_DataMiner_Connectivity_Framework_functions).

- In *Connectivity.xml* files in the folder `C:\Skyline DataMiner\Connectivity`. See [Defining connectivity chains in XML files](xref:Defining_connectivity_chains_in_XML_files).

- By importing connection data from an external source (e.g. a configuration management database).

- By means of automatic detection (via a DataMiner App, e.g. IP Network Manager).
