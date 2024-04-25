---
uid: Info_template_quick_tips
---

# Info template quick tips

This tutorial will show you how to configure and use an information template to enhance the presentation and monitoring of parameters associated with satellite earth stations.

You will learn how to:

- [Step 1: Create and configure a new information template for a connector](#step-1-create-and-configure-a-new-information-template-for-a-connector)
- [Step 2: Use the information template to enhance data presentation within an element and the alarm console](#step-2-use-the-information-template-to-enhance-data-presentation-within-an-element-and-the-alarm-console)
- [Step 3: Override information template to change a parameter description for a specific element](#step-3-override-information-template-to-change-a-parameter-description-for-a-specific-element)

Expected duration: 20 minutes

> [!TIP]
> See also: [Information templates](href:Information_templates) for official documentation.

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner as a service (DaaS) 10.4.5.0-14239.

## Prerequisites

- Before starting, deploy the [Info Template Quick Tips](https://catalog.dataminer.services/details/32274506-07a4-4ecb-98d3-bea773c3903e) package to your DataMiner system.

    The package will create an *Info template quick tips* view and an element with the same name. The element will come with pre-provisioned data in the Master Table.
    ![Info template quick tips tutorial image 0](~/user-guide/images/Info_Template_Quick_Tips_img00.png)

## Step 1: Create and configure a new information template for a connector

1. In DataMiner Cube, go to *Apps -> Protocols & Templates*.

1. Under Protocols, select the Skyline Generic Virtual Connector.

1. Under Information Templates, right click and select New.

    ![Info template quick tips tutorial image 1](~/user-guide/images/Info_Template_Quick_Tips_img01.png)

1. Assign a name to the template and click OK.

    ![Info template quick tips tutorial image 2](~/user-guide/images/Info_Template_Quick_Tips_img02.png)

1. Configure the necessary parameters

    ![Info template quick tips tutorial image 3](~/user-guide/images/Info_Template_Quick_Tips_img03.png)

    - Master Table: Earth Stations
    - Column 1: Name
    - Column 2: Location
    - Column 3: Weather Conditions
    - Column 4: Hide Me

    ![Info template quick tips tutorial image 4](~/user-guide/images/Info_Template_Quick_Tips_img04.png)

1. When satisfied with the configuration, click Apply and then OK.

## Step 2: Use the information template to enhance data presentation within an element and the alarm console

1. Right click the newly created template and select *Set as active Information template*

    ![Info template quick tips tutorial image 5](~/user-guide/images/Info_Template_Quick_Tips_img05.png)

1. Visualize the changes within the *Info template quick tips* element

    ![Info template quick tips tutorial image 6](~/user-guide/images/Info_Template_Quick_Tips_img06.png)

1. Go to *Apps -> Protocols & Templates* and configure the *Info template quick tips* alarm template.

    ![Info template quick tips tutorial image 7](~/user-guide/images/Info_Template_Quick_Tips_img07.png)

1. Apply the alarm template to the *Info template quick tips* element and visualize in the alarm console the enhanced parameters added via the information template

    ![Info template quick tips tutorial image 8](~/user-guide/images/Info_Template_Quick_Tips_img08.png)

## Step 3: Override information template to change a parameter description for a specific element

1. Back in the element card, select the hamburger menu and click Parameter names.

    ![Info template quick tips tutorial image 9](~/user-guide/images/Info_Template_Quick_Tips_img09.png)

1. Change *Location* to *Region* and click Apply and OK.

    ![Info template quick tips tutorial image 10](~/user-guide/images/Info_Template_Quick_Tips_img10.png)

    ![Info template quick tips tutorial image 11](~/user-guide/images/Info_Template_Quick_Tips_img11.png)
