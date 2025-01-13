---
uid: Connector_help_pages
---

# Connector documentation

For every connector that is developed for DataMiner, two or more documentation pages should be made.

The first page is the [marketing page](#marketing-page), which should be appealing and focus on demonstrating the value the connector can bring to users, similar to the packaging of a product in a store.

The second page is the [technical page](#technical-page), which should be a subpage of the marketing page containing further technical details. You could compare this to the instructions booklet included with a product in a store. The technical page details among others how the connections should be set up when you create an element with the connector, how the element should be used, etc.

If a connector exports child connectors, a subpage should also be created for each of these child connectors.

When you develop a connector using DIS, you can pre-generate the connector documentation pages with the *Plugins* > *Generate driver help* option in the [DIS menu](xref:DIS_menu). You can also create the pages directly in Markdown, starting from our [marketing](xref:Connector_marketing_template) and [technical](xref:Connector_technical_template) templates. When you have created the pages, add them in the [dataminer-docs-connectors](https://github.com/SkylineCommunications/dataminer-docs-connectors) repository.

## Adding new connector documentation pages

### File names and folder

To make sure your pages can be automatically included in the [DataMiner Catalog](https://catalog.dataminer.services/), it is important that you use the correct file names and place the files in the correct folder:

- Marketing page: make sure the **file name** of your marketing page is the **exact name of the connector in the Catalog**, but with **underscores instead of spaces**. For example, the file name of the *Microsoft Platform* marketing page has to be *Microsoft_Platform.md*. Make sure the casing is the same, and do not replace any other characters with underscores. Any mismatch between the file name and the connector name will make the documentation **unavailable** in the Catalog.

  > [!IMPORTANT]
  > It is very important that the file name **does not contain any spaces**. If the file name contains spaces, this will cause an error when the new file is pushed to the DataMiner Catalog.

- Technical page: make sure the **file name** follows the same rules as mentioned above for the Marketing page but is followed by a **_Technical** suffix. For example, the file name of the *Microsoft Platform* technical page has to be *Microsoft_Platform_Technical.md*.

- Add your documentation files in the following folder of the [dataminer-docs-connectors](https://github.com/SkylineCommunications/dataminer-docs-connectors) repository: */dataminer-docs-connectors/connector/doc*

### Table of contents

When you add new pages to the connector documentation, you will need to add them to the table of contents as well. To do so, add them to the *toc.yml* file in the *connector* folder. Please note:

- The connector documentation pages are listed in alphabetical order underneath each vendor node. Make sure to add your pages in the correct location.
- Use the following syntax to add the pages:

  ```yml
  - name: Connector name
    topicUid: Connector_help_Connector_name
    items:
      - name: Connector name Technical
        topicUid: Connector_help_Connector_name_Technical
  ```

> [!TIP]
> The value you need to specify next to "topicUid:" is a UID that should be specified at the top of the markdown files. See [Adding a page](xref:CTB_Adding_New_Page).

> [!NOTE]
> If you do not configure the table of contents correctly, the automatic checks that run after you submit your pull request will fail. You can then click *Details* to find out what exactly went wrong.
>
> ![Pull request check failed](~/develop/images/Pull_request_check_failed.png)

## Writing connector documentation

When you write connector documentation, keep the instructions below in mind.

### Markdown syntax

Use DocFX Flavored Markdown (DFM). See [Markdown syntax](xref:CTB_Markdown_Syntax).

### Title

The title of both pages should be the name of the connector in the [DataMiner Catalog](https://catalog.dataminer.services/).

### Marketing page

The format of the marketing page should be the same as for the documentation of other Catalog items. See [Best practices when documenting Catalog items](xref:Best_Practices_When_Documenting_Catalog_Items).

However, note that the Marketing page of a connector should always have a **Technical Reference** section, and this section must include a note with a link to the [technical page](#technical-page) for the connector (optionally in addition to other technical info that is important enough to include it here):

```md
> [!NOTE]
> For detailed technical information, refer to our [technical documentation](xref:Connector_help_My_connector_name_Technical).
```

### Technical page

#### Introduction paragraph

In the **first paragraph** below the title, add a short paragraph explaining the **function of the connector**. Try to also include some **information about the data source**. If you copy this information from somewhere else, make sure it fits the informative context of documentation (e.g. remove meaningless praise like "best-of-breed", "top-of-the-line", etc.).

#### 'About' section

**OBSOLETE**

Older connector documentation will contain an *About* section with tables with version info, product info, and system info, but this is no longer required as this information is now included directly within the protocol.xml via the various [VersionHistory](xref:Protocol.VersionHistory) tags.

#### 'Configuration' section

In the **Configuration** section, add the information needed to create a DataMiner element with the connector. This section will need to have one or more subsections, depending on the connector. You can find more information about these below.

> [!NOTE]
> For an exported child connector, it is usually sufficient to mention that it is automatically exported by the parent connector (with a link to the parent connector and mention of the version exporting the child connector, if relevant).

##### 'Connections' subsection

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
> You can find the structure for all possible connection sections in the [technical template](xref:Connector_technical_template). If you copy from there, remember to remove the placeholder text and the square brackets surrounding it.

##### 'Initialization' subsection

If, once the element has been created, the connector requires more actions from the user before it can actually be used, you will need to add an **Initialization** section that explains what needs to be done. This could for example be configuring parameters for authentication. Make sure it is clear to the user what they need to fill in and where.

##### 'Web Interface' subsection

If there is a Web Interface page, always add a **Web Interface** subsection, containing the remark: "The web interface is only accessible when the client machine has network access to the product."

##### 'Redundancy' subsection

If redundancy is defined in the connector, add a **Redundancy** subsection that explains how this should be configured.

##### Other configuration subsections

Depending on the connector, other subsections may be needed, e.g. in case Automation scripts, Correlation rules, Visio files, etc. need to be configured. You can find a number of possible subsections listed in the template. However, this list is not exclusive; you can add different configuration subsections if this makes sense for your connector.

#### 'How to Use' section

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

#### 'DataMiner Connectivity Framework' section

For a connector that supports DCF, add information on which connector range supports DCF, and from which version of DataMiner it can be used. If you start from the template, remember to replace the placeholder text and remove the square brackets surrounding it.

Always add this additional provision, to make sure user changes in DataMiner or changes from third-party connectors are covered: "DCF can also be implemented through the DataMiner DCF user interface and through third-party DataMiner connectors (e.g. a manager)."

For a page for a parent DVE element, to make it clear that DCF in a child DVE is actually managed by the parent, add this provision: "Connectivity for all exported connectors is managed by this connector."

For a DVE child element, no detailed description is necessary in this section. Instead it is sufficient to mention the following: "Connectivity for this connector is managed by the parent connector [connector name]."

If applicable, add the **Interfaces** and/or **DCF Connections** sections as detailed in the [technical template](xref:Connector_technical_template).

#### 'Notes' section

If you want to add information about the connector that does not fit under any of the other sections, add a **Notes** section for this. This section can also have subsections if it contains a lot of information.

If you do not need a Notes section, leave it out.
