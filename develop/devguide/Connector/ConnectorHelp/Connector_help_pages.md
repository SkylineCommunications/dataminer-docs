---
uid: Connector_help_pages
---

# Connector documentation

For every connector that is developed for DataMiner, a corresponding page should be available in the connector documentation. This "connector help" page details among others how the connections should be set up when you create an element with the connector, how the element should be used, etc. If a connector exports child connectors, a page should also be created for each of these child connectors.

When you develop a connector using DIS, you can generate the connector documentation with the *Plugins* > *Generate driver help* option in the [DIS menu](xref:DIS_menu). You can also create the page directly in Markdown, starting from our [template](xref:Connector_help_template). When you have created the page, add it in the [dataminer-docs-connectors](https://github.com/SkylineCommunications/dataminer-docs-connectors) repository.

## Adding a new connector documentation page

### File name and folder

To make sure your page can be automatically included in the [DataMiner Catalog](https://catalog.dataminer.services/), it is important that you use the correct file name and place the file in the correct folder:

- Make sure the **file name** is the **exact name of the connector in the Catalog**, but with **underscores instead of spaces**. For example, the file name of the *Microsoft Platform* documentation page has to be *Microsoft_Platform.md*.

- Add your documentation file in the following folder of the [dataminer-docs-connectors](https://github.com/SkylineCommunications/dataminer-docs-connectors) repository: */dataminer-docs-connectors/connector/doc*

### Table of contents

When you add a new page to the connector documentation, you will need to add it to the table of contents as well. To do so, add it to the *toc.yml* file in the *connector* folder. Please note:

- The connector documentation pages are listed in alphabetical order underneath each vendor node. Make sure to add your page in the correct location.
- Use the following syntax to add the page:

  ```yml
    - name: Connector name
      topicUid: Connector_help_Connector_name
  ```

> [!TIP]
> The value you need to specify next to "topicUid:" is a UID that should be specified at the top of the markdown file. See [Adding a page](xref:contributing#adding-a-new-page).

> [!NOTE]
> If you do not configure the table of contents correctly, the automatic checks that run after you submit your pull request will fail. You can then click *Details* to find out what exactly went wrong.
>
> ![Pull request check failed](~/develop/images/Pull_request_check_failed.png)

## Writing connector documentation

When you write connector documentation, keep the instructions below in mind.

### Markdown syntax

Use DocFX Flavored Markdown (DFM). See [Markdown syntax](xref:contributing#markdown-syntax).

### Title

The title of the page should be the name of the connector in the [DataMiner Catalog](https://catalog.dataminer.services/).

### Introduction paragraph

In the **first paragraph** below the title, add a short paragraph explaining the **function of the connector**. Try to also include some **information about the data source**. If you copy this information from somewhere else, make sure it fits the informative context of documentation (e.g. remove meaningless praise like "best-of-breed", "top-of-the-line", etc.).

### 'About' section

In the **About** section, you will need to add a number of tables, depending on the connector. You can find these tables in the [template](xref:Connector_help_template).

- For all connectors except exported child connectors, add the **Version Info** table.

- For all connectors except virtual connectors, add the **Product Info** table.

- For **all connectors**, add the **System Info** table. For exported connectors or connectors that cannot have exported connectors, you can leave out the *Exported Components* column in this table.

### 'Configuration' section

In the **Configuration** section, add the information needed to create a DataMiner element with the connector. This section will need to have one or more subsections, depending on the connector. You can find more information about these below.

> [!NOTE]
> For an exported child connector, it is usually sufficient to mention that it is automatically exported by the parent connector (with a link to the parent connector and mention of the version exporting the child connector, if relevant).

#### 'Connections' subsection

Except for exported child connectors, every connector documentation page should have a **Connections** subsection. For each connection, you should add a title mentioning the name of the connection as defined in the connector, e.g. "SNMP Connection – Trap Input". For the Main connection, use "Main" as the name of the connection.

Below are a couple of examples of such connections sections.

```md
#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The device address of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).
```

```md
#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.
```

```md
#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.
```

> [!TIP]
> You can find the structure for all possible connection sections in the [template](xref:Connector_help_template). If you copy from there, remember to remove the placeholder text and the square brackets surrounding it.

#### 'Initialization' subsection

If, once the element has been created, the connector requires more actions from the user before it can actually be used, you will need to add an **Initialization** section that explains what needs to be done. This could for example be configuring parameters for authentication. Make sure it is clear to the user what they need to fill in and where.

#### 'Web Interface' subsection

If there is a Web Interface page, always add a **Web Interface** subsection, containing the remark: "The web interface is only accessible when the client machine has network access to the product."

#### 'Redundancy' subsection

If redundancy is defined in the connector, add a **Redundancy** subsection that explains how this should be configured.

#### Other configuration subsections

Depending on the connector, other subsections may be needed, e.g. in case Automation scripts, Correlation rules, Visio files, etc. need to be configured. You can find a number of possible subsections listed in the template. However, this list is not exclusive; you can add different configuration subsections if this makes sense for your connector.

### 'How to Use' section

The **How to Use** section of your page is where you explain what users can actually do with the connector, and especially how they can do it.

Also specify the **communication method** if relevant. For example: "SOAP calls are used to retrieve the device information. SNMP traps can be retrieved when this is enabled on the device." In case no data traffic will be seen in the Stream Viewer, you should clearly mention this.

Make sure you **always specify something in this section**, keeping in mind what users may be looking for when they consult the documentation. Ask yourself the question, "If someone who knows nothing at all about this connector goes looking for help about it, what would they need to see?"

For example:

- Which information is the most important for the users and where can they find it?
- Are there any parameters of which the purpose is not obvious?
- If the connector allows configuration, which settings are the most important?
- Are there any settings that could have an impact users might not anticipate?
- Are there any potential problems that users should watch out for?

If you mention different pages and parameters, this should be for the purpose of explaining something more than what users can see by just looking at the element. Merely writing down which pages are available and which parameters are on them is not helpful.

For a very simple one-page connector, it can be sufficient to specify something like "You can find all the information you need to monitor the device on the General data page." This way, users will be reassured that they are not missing something.

If you need to add more than just a couple of lines of text because the connector is quite complicated or you need to go into a lot of detail for some of the features, use subheaders to keep the page easy to scan for the reader. These subheaders can either reflect the different pages you want to discuss, or the different topics, e.g. General Settings, Import and Export, Logging.

### 'DataMiner Connectivity Framework' section

For a connector that supports DCF, add information on which connector range supports DCF, and from which version of DataMiner it can be used. If you start from the template, remember to replace the placeholder text and remove the square brackets surrounding it.

Always add this additional provision, to make sure user changes in DataMiner or changes from third-party connectors are covered: "DCF can also be implemented through the DataMiner DCF user interface and through third-party DataMiner connectors (e.g. a manager)."

For a page for a parent DVE element, to make it clear that DCF in a child DVE is actually managed by the parent, add this provision: "Connectivity for all exported connectors is managed by this connector."

For a DVE child element, no detailed description is necessary in this section. Instead it is sufficient to mention the following: "Connectivity for this connector is managed by the parent connector [connector name]."

If applicable, add the **Interfaces** and/or **DCF Connections** sections as detailed in the [template](xref:Connector_help_template).

### 'Notes' section

If you want to add information about the connector that does not fit under any of the other sections, add a **Notes** section for this. This section can also have subsections if it contains a lot of information.

If you do not need a Notes section, leave it out.
