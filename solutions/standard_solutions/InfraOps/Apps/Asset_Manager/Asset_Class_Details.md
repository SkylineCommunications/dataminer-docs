---
uid: Asset_Class_Details
---

# Asset Class Details

To finalize the configuration of an Asset Class, the user can go to its details panel and fill in the rest of the missing information. While on “Draft” state, everything is still editable, but once is set to active, only a few fields will be available for the user to edit.

![Asset Class Information Wizard](~/solutions/images/Asset_Manager_Asset_Class_Information_Wizard.png)

From the available fields, the Height (cm) will be used to consume rack units once an Asset from this Asset Class is assigned to a Rack. After the user fills in this field, a conversion is applied and displayed on the details section in U (Rack Units, 1U = 4.445cm).

Also relevant is the Max Power Consumption (kW), this will be used when a user is assigning an Asset to a Rack, he will be informed of how much power (percentage wise) will be consuming from the available Power consumption assigned to the Rack.

**Lifecycle section**

In this section, the user will be able to define the End of Life (when the manufacturer stops selling this equipment), the End of Service (when the vendor no longer provides support for this equipment) and the Nominal Lifetime (Days).

The Nominal Lifetime will be used against the Installation Date of the Asset, to calculate the Expected End-of-Life Date of the Asset.

![Asset Class Lifecycle Wizard](~/solutions/images/Asset_Manager_Asset_Class_Lifecycle_Wizard.png)

**Images section**

Here the user can assign images to Asset Class (using the Web File Manager), so these can be displayed on the Rack View, once the asset is placed on the Rack.
