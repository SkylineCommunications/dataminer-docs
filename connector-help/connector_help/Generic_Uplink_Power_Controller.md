---
uid: Connector_help_Generic_Uplink_Power_Controller
---

# Generic Uplink Power Controller

## About

The Generic Uplink Power Controller acts as a replacement for a hardware-based UPC system, by controlling the attenuation of HPAs based on the strength of the received beacon signal. On top of UPC also ALC (Automatic Level Control) can be activated. ALC will result in a stable output power (for example to compensate for slow temperature changes).

## Installation and configuration

### Creation

This connector uses a virtual connection and does not need any user input during creation.

### Configuration

This connector makes use of HPA elements that it needs to be linked to. This linking is done on the **General** page of the connector. By clicking on the **Add** **HPA** **Backup** or **Add** **HPA** button, you can add a new row to the **HPA** table. For each row, you can then select in the drop-down list which **HPA** **Element** to set. Configurations up to a 3+1 (redundant) system are supported.

## Usage

### General page

On the left side of this page, you can view and modify different parameters concerning the signal strength of the beacon receiver..

On the right side of this page, there is a table where you can add the different available **HPAs**, as described in the Configuration section above.

It is also possible to set all the **HPA** **Elements** to disabled by clicking the **Disable** **All** button. Each row of the **HPA** table can be enabled or disabled individually. When you set the **UPC** **Status** to *disabled*, the **HPA** **Default** **Attenuation** will be applied without any further actions.

### Skyline

On this page you can see three tables:

- **Elements:** Displays all the elements active on the DMA.
- **Elements Saved:** Displays the different HPAs that have been selected in the **HPA** table.
- **Beacon Level Average Table:** Displays the average beacon levels.
