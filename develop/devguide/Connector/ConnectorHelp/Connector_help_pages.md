---
uid: Connector_help_pages
description: For every connector that is developed for DataMiner, two or more documentation pages should be made.
---

# Connector documentation

For every connector that is developed for DataMiner, a [marketing page](#marketing-page) must be made, which will be shown as its description in the Catalog. This page must be appealing and **focus on demonstrating the value the connector can bring** to users.

A **limited amount of technical and "how to" information** can be added directly on the marketing page. However, if your connector requires so much technical information that the marketing page would no longer be user-friendly, or if it requires technical information that may make the connector seem less attractive (for example, troubleshooting procedures), you should add this on a separate [technical page](#technical-page), which should be a subpage of the marketing page.

Note that if a technical page seems necessary, a good reflex is to first check if you can make the connector more user-friendly and intuitive instead. If you make sure your connector design is well thought-through and your parameter tooltips are well written, often no technical page will be needed.

If a connector exports **child connectors**, a subpage should also be created for each of these child connectors.

When you develop a connector using DIS, you can pre-generate the connector documentation with the *Plugins* > *Generate driver help* option in the [DIS menu](xref:DIS_menu). You can also create the documentation directly in Markdown, starting from our [marketing template](xref:Connector_marketing_template) and, if necessary, [technical template](xref:Connector_technical_template). When you have created the documentation, add it in the [dataminer-docs-connectors](https://github.com/SkylineCommunications/dataminer-docs-connectors) repository.

## Adding new connector documentation pages

### File names and folder

To make sure your pages can be automatically included in the [Catalog](https://catalog.dataminer.services/), it is important that you use the correct file names and place the files in the correct folder:

- Marketing page: Make sure the **file name** of your marketing page is the **exact name of the connector in the Catalog**, but with **underscores instead of spaces**. For example, the file name of the *Microsoft Platform* marketing page has to be *Microsoft_Platform.md*. Make sure the casing is the same, and do not replace any other characters with underscores. Any mismatch between the file name and the connector name will make the documentation **unavailable** in the Catalog.

  > [!IMPORTANT]
  > It is very important that the file name **does not contain any spaces**. If the file name contains spaces, this will cause an error when the new file is pushed to the Catalog.

- Technical page (only to be included when necessary): Make sure the **file name** follows the same rules as mentioned above for the Marketing page but is followed by a **_Technical** suffix. For example, the file name of the *Microsoft Platform* technical page has to be *Microsoft_Platform_Technical.md*.

- Add your documentation files in the following folder of the [dataminer-docs-connectors](https://github.com/SkylineCommunications/dataminer-docs-connectors) repository: */dataminer-docs-connectors/connector/doc*

### Table of contents

When you add **new pages** to the connector documentation, you will need to add them to the table of contents as well. To do so, add them to the *toc.yml* file in the *connector* folder. Please note:

- The connector documentation pages are listed in alphabetical order underneath each vendor node. Make sure to add your pages in the correct location.
- Add your pages to the toc.yml using a `topicUid` reference. The value you need to specify next to "topicUid:" is the UID specified at the top of your markdown file. See [Adding a page](xref:CTB_Adding_New_Page).
- Include the *toc.yml* update and the new files **within the same pull request**. The "Build" check for your pull requests will fail if you use separate pull requests.
- If you add both a marketing and a technical page, use the following syntax to add the pages:

  ```yml
  - name: Connector name
    topicUid: Connector_help_Connector_name
    items:
      - name: Connector name Technical
        topicUid: Connector_help_Connector_name_Technical
  ```

> [!TIP]
> If you do not configure the table of contents correctly, the automatic checks that run after you submit your pull request will fail. You can then click *Details* to find out what exactly went wrong.
>
> ![Pull request check failed](~/develop/images/Pull_request_check_failed.png)

## Writing connector documentation

When you write connector documentation, keep the instructions below in mind.

### Markdown syntax

Use DocFX Flavored Markdown (DFM). See [Markdown syntax](xref:CTB_Markdown_Syntax).

### Title

The title of your page should be the name of the connector in the [Catalog](https://catalog.dataminer.services/). If you add a technical page as well, give it exactly the same title.

### Marketing page

The format of the marketing page should be the same as for the documentation of other Catalog items. See [Best practices when documenting Catalog items](xref:Best_Practices_When_Documenting_Catalog_Items).

If technical information needs to be included, you can put this in the **Technical Reference** section. However, if your connector needs a lot of technical information, or if it needs technical information that may make the connector seem less attractive (such as troubleshooting), you should place it on a separate [technical page](#technical-page). In that case, place a link to the technical page in the Technical Reference section.

### Technical page

Only if a connector requires a lot of technical information or technical information that is unsuitable for a marketing page, a technical page can be made. It should be organized as follows.

#### 'About' section

In the **About** section, add a short paragraph explaining the **function of the connector**. Try to also include some **information about the data source**. If you copy this information from somewhere else, make sure it fits the informative context of documentation (e.g. remove meaningless praise like "best-of-breed", "top-of-the-line", etc.).

> [!NOTE]
> In this *About* section, older connector documentation will contain **tables** with version info, product info, and system info, but these are **no longer required** as this information is now included directly within the *Protocol.xml* via the various [VersionHistory](xref:Protocol.VersionHistory) tags. However, before you remove the version history info from existing connector help pages, **make sure all the necessary info is properly added to the relevant [VersionHistory](xref:Protocol.VersionHistory) tags** and make sure this is done **for every non-deprecated range** of the connector.

#### 'Configuration' section

In the **Configuration** section, add the information needed to create a DataMiner element with the connector. This section will need to have one or more subsections, depending on the connector. You can find more information about these below.

> [!NOTE]
> For an exported child connector, it is usually sufficient to mention that it is automatically exported by the parent connector (with a link to the parent connector and mention of the version exporting the child connector, if relevant).

##### 'Connections' subsection

Except for exported child connectors, every technical documentation page should have a **Connections** subsection. For each connection, you should add a title mentioning the name of the connection as defined in the connector, e.g. "SNMP Connection – Trap Input". For the Main connection, use "Main" as the name of the connection.

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

If no additional steps are needed to get the element running after it has been created, leave out this section.

##### 'Web Interface' subsection

If there is a Web Interface page, always add a **Web Interface** subsection, containing the remark: "The web interface is only accessible when the client machine has network access to the product."

If there is no Web Interface page, leave out this section.

##### 'Redundancy' subsection

If redundancy is defined in the connector, add a **Redundancy** subsection that explains how this should be configured.

If redundancy is not defined in the connector, leave out this section.

##### Other configuration subsections

Depending on the connector, other subsections may be needed, for example, in case automation scripts, correlation rules, Visio files, etc. need to be configured. You can find a number of possible subsections listed in the template. However, this list is not exclusive; you can add different configuration subsections if this makes sense for your connector.

#### 'How to Use' section

The **How to Use** section of your page is where you explain what users can actually do with the connector, and especially how they can do it.

Also specify the **communication method** if relevant. For example: "SOAP calls are used to retrieve the device information. SNMP traps can be retrieved when this is enabled on the device." In case no data traffic will be seen in the Stream Viewer, you should clearly mention this.

**Avoid just adding a list of pages and parameters**. Users can see the pages and parameters when they look at the element, so there is no value in simply repeating this. In fact, if no detailed technical information is needed on how to use the connector, consider not making a technical page at all and instead adding any required technical info on the marketing page.

If you need to add a lot of information in this section, use subheaders to keep the page easy to scan for the reader.

#### 'DataMiner Connectivity Framework' section

For a connector that supports DCF, add information on which connector range supports DCF, and from which version of DataMiner it can be used. If you start from the template, remember to replace the placeholder text and remove the square brackets surrounding it.

Always add this additional provision, to make sure user changes in DataMiner or changes from third-party connectors are covered: "DCF can also be implemented through the DataMiner DCF user interface and through third-party DataMiner connectors (e.g. a manager)."

For a page for a parent DVE element, to make it clear that DCF in a child DVE is actually managed by the parent, add this provision: "Connectivity for all exported connectors is managed by this connector."

For a DVE child element, no detailed description is necessary in this section. Instead it is sufficient to mention the following: "Connectivity for this connector is managed by the parent connector [connector name]."

If applicable, add the **Interfaces** and/or **DCF Connections** sections as detailed in the [technical template](xref:Connector_technical_template).

#### 'Notes' section

If you want to add information about the connector that does not fit under any of the other sections, add a **Notes** section for this. This section can also have subsections if it contains a lot of information.

If you do not need a Notes section, leave it out.
