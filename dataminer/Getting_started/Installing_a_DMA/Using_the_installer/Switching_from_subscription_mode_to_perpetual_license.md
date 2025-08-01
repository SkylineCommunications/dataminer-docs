---
uid: Switching_from_subscription_mode_to_perpetual_license
---

# Switching from subscription mode to a perpetual license

When you deploy a DataMiner Agent using the [DataMiner Installer v10.4](xref:Installing_DM_using_the_DM_installer) or by [using a pre-installed VHD](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk), your system will automatically be licensed with a [Community Edition license](xref:Pricing_Commercial_Models#dataminer-community-edition) and run in subscription mode. Part of this process involves getting a DataMiner ID, which uniquely identifies your DataMiner Agent.

If you have purchased a [permanent license](xref:Pricing_Perpetual_Use_Licensing), follow the steps below to convert your subscription installation to a perpetual-license one:

1. [Stop the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).

1. Open the `C:\Skyline DataMiner\` folder.

1. Remove all *\*.lic* files, if any.

1. Open the *DataMiner.xml* file.

1. Find the *&lt;DataMiner&gt;* tag and locate the *id* attribute.

1. Note down the value in the *id* attribute.

1. [Start the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).

1. After a short while, a *Request.lic* file should appear in the `C:\Skyline DataMiner\` folder.

1. Contact [dataminer.licensing@skyline.be](mailto:dataminer.licensing@skyline.be) and provide them with the ID and the *Request.lic* file.

   In your email, mention that it concerns a conversion from a subscription to a perpetual license.

1. Wait until you receive a *dataminer.lic* file from Skyline.

1. When you have the *dataminer.lic* file, copy it to the `C:\Skyline DataMiner\` folder.

1. [Restart the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).
