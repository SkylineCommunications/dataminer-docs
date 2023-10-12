---
uid: Copy_Element_Data
---

# Copy Element Data

This tool can be used to simulate problems and build projects based on real data. It consists of two Automation scripts:

- ***RetrieveAllParams***: Allows you to retrieve all parameters from an element and store them in a JSON file.

- ***SetAllParams***: Allows you to set all parameters from a JSON file to an element.

> You can download these scripts from [DataMiner Dojo](https://community.dataminer.services/download/copy-element-data/).

To use the ***RetrieveAllParams*** script:

1. Upload the script on the DMA containing the element from which you want to retrieve the parameters, and execute it in the Automation module.

1. Specify the following input parameters and then select *Execute Now*:

   - *Location*: The full file path of the location where the output should be placed (e.g. `C:\Skyline_Data\output.json`).

   - *ElementID*: The element ID of the element from which you want to retrieve the parameters, in the format DataMiner ID/element ID.

To use the ***SetAllParams*** script:

1. On the DMA where you want to simulate the element, create an element using the same protocol and protocol version.

1. Upload the script to this DMA and execute it in the Automation module.

1. Specify the following input parameters and then select *Execute Now*:

   - *Location*: The full file path of the location from which input should be read (e.g. `C:\Skyline_Data\output.json`).

   - *ElementID*: The element ID of the element you created in the first step, in the format DataMiner ID/element ID.
