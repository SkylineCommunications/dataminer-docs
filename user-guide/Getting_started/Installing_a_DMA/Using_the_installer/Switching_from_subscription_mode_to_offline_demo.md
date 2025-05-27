---
uid: Switching_from_subscription_mode_to_offline_demo
---

# Switching from subscription mode to an offline demo license

When you deploy a DataMiner Agent using the [DataMiner Installer v10.4](xref:Installing_DM_using_the_DM_installer) or by [using a pre-installed VHD](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk), your system will automatically be licensed with a [Community Edition license](xref:Pricing_Commercial_Models#dataminer-community-edition) and run in subscription mode. A DataMiner Agent running in subscription mode **has to remain connected** to [dataminer.services](xref:about_dataminer_services) to keep it licensed. If for some reason you cannot keep your Agent connected to [dataminer.services](xref:about_dataminer_services), it will automatically shut down after 1 month.

If after this period you want to extend the usage of the system, you can convert your subscription installation to an offline demo installation:

1. [Stop the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).

1. Open the `C:\Skyline DataMiner\` folder.

1. Remove all *\*.lic* files, if any.

1. [Start the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).

1. After a short while, a *Request.lic* file should appear in the `C:\Skyline DataMiner\` folder.

1. Contact [dataminer.licensing@skyline.be](mailto:dataminer.licensing@skyline.be) and provide them with the *Request.lic* file.

   In your email, mention that it concerns a conversion from a subscription to a demo license.

1. Wait until you receive a *Response.lic* file from Skyline.

1. When you have the *Response.lic* file, copy it to the `C:\Skyline DataMiner\` folder.

1. [Restart the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).
