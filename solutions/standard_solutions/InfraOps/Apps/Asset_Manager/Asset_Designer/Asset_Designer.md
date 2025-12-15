---
uid: Asset_Designer
---

# Asset Designer

On the Asset Designer page, you can configure the asset classes used in your system. This is typically the first step when configuring the Asset Manager app. You can [import the classes](#importing-asset-classes) via CSV or from GitHub, but you can also [manually create classes](#manually-creating-an-asset-class).

This page also allows you to configure [device types](xref:AM_Configuring_device_types), [cable types](xref:AM_Configuring_cable_types), and [port types](xref:AM_Configuring_port_types) via the buttons in the top-left corner.

## Importing asset classes

To start importing asset classes, click *Import/Export Asset Classes* in the top-right corner. You can then choose between *Import Netbox Asset Classes* or *Import/export Asset Classes to/from CSV*.

The **Import Netbox Asset Classes** option allows you to import assets from Netbox using the following GitHub repositories:

- [devicetype-library](https://github.com/netbox-community/devicetype-library/tree/master/device-types).

- [netbox-devicetype-library](https://github.com/nrkno/netbox-devicetype-library/tree/master/device-types).

To do so, you will first have to select up to 60 files from the repositories, then click *Selected files*, and then click *Import*.

The **Import/export Asset Classes to/from CSV** option allows you to select whether to import or export the asset classes. To import them, keep the *Import* option selected, select and upload your CSV file, and click *Import*.

## Manually creating an asset class

1. In the header bar, select *New Asset Class*.

1. Specify the following details:

   - **Asset Class Name**: A unique descriptive identifier for the asset class.

   - **Device Type**: The device type. This is intended to provide a higher-level classification (e.g. encoder, video router) and to determine how the asset class and its associated assets behave within the system. For info on how to manage these device types, see [Configuring device types](xref:AM_Configuring_device_types).

   - **Manufacturer**: Allows you to select a manufacturer. You can select any of the organizations configured in the [People and Organization](xref:People_Organizations) app.

   ![Asset class wizard](~/solutions/images/Asset_Manager_Asset_Class_Wizard.png)

1. Click *Save*.

## Configuring an asset class

When you have added an asset class, you can fine-tune by clicking the details button (ⓘ) for the asset class in the table. This will open the *Asset details* pane

![Asset class details](~/solutions/images/Asset_Manager_Chassis_Asset_Class_Details.png)

In this pane, you can configure the following details:

- The **asset class information**:

  - The asset class **name**.
  - The corresponding **device type**.
  - The **description**.
  - The **manufacturer**.
  - The **height**, which determines how many rack units are consumed when an asset with this asset class is assigned to a rack. When you fill in this field, a conversion is applied in displayed in the details section in "U" (i.e. rack units, with 1 U being equal to 4.445 cm).
  - The **width** and **depth**.<!-- TBD: purpose? -->
  - The **max power consumption**, which will determine how much power (in percent) an asset assigned to the rack will consume compared to the available power consumption assigned to the rack.
  - The **typical power consumption**.<!-- TBD: purpose? -->
  - The **weight**.

  ![Asset class information wizard](~/solutions/images/Asset_Manager_Asset_Class_Information_Wizard.png)

- The **lifecycle** of the asset class:

  - The **End of Life (EOL) date** for the asset class, i.e. when the manufacturer stops selling this equipment.
  - The **End of Service (EOS) date** for the asset class, i.e. when the vendor no longer provides support for this equipment.
  - The **nominal lifetime** of the asset class (in days), which will be used along with the installation date of the asset to calculate the expected End-of-Life date of the asset.

  ![Asset class lifecycle wizard](~/solutions/images/Asset_Manager_Asset_Class_Lifecycle_Wizard.png)

- Any **images** for the asset class. These will be displayed in the rack visualization when the asset is placed on a rack. Additional images can be uploaded using the [Web File Manager app](xref:Web_File_Manager).

- The [**number of slots** for the asset class](#defining-the-number-of-slots-for-an-asset-class).

- [The **ports** for the asset class](#defining-the-ports-for-an-asset-class).

> [!NOTE]
> As long as the asset class is still in the Draft state, everything will be editable, but once it has been [activated](#activating-an-asset-class), you will only be able to edit some of the fields.

## Defining the number of slots for an asset class

If you have created an asset class using a device type with a hierarchy level, for example a Chassis asset, you can define the number of slots available for each hierarchy level:

1. Click the details button (ⓘ) for the asset class in the table.

   This will open the *Asset class details* pane.

1. Click the *Cards*, *Modules*, *Fans*, or *Power Supplies* button in the top-left corner of the pane, depending on the type of slots you want to define.

   For example, if you click *Cards*, this will open the following pane:

   ![Cards side panel](~/solutions/images/Asset_Manager_Cards_Side_Panel.png)

1. Click the *Add* button, specify the number of slots, and click *Save*.

   ![Adding card slots](~/solutions/images/Asset_Manager_Add_card_slots.png)

Assets created based on this asset class will have the same number of slots as configured on the asset class (this can still change this default configuration).<!-- TBD: content in parentheses needs to be better explained -->

## Defining the ports for an asset class

1. Click the details button (ⓘ) for the asset class in the table.

   This will open the *Asset class details* pane.

1. Click the *Ports* button in the top-left corner of the pane.

   This will open a pane with the ports details.

   ![Asset class ports pane](~/solutions/images/Asset_Manager_Asset_Class_Details_Ports_Side_Panel.png)

   In this pane, you can edit or remove a defined port via the hamburger button for that port, or add a port with the *Add Data Port* or *Add Power Port* buttons at the top.

   When you click the button to add a port, this will open a window where you can select the port type, the number of ports you want to add of this type, the exposure type (*Front* or *Back* of the rack), and the output type (*In*, *Out*, or *IO*).

   ![Add data port wizard](~/solutions/images/Asset_Manager_Add_Data_Port_Wizard.png)

## Activating an asset class

When an asset class has been imported or created, it will first be set to the Draft state. To activate it, click the state cell in the table and select *Set to Active*:<!-- TBD: limitations of draft state? -->

![Asset class state context menu](~/solutions/images/Asset_Manager_Asset_Class_State_Context_Menu.png)
