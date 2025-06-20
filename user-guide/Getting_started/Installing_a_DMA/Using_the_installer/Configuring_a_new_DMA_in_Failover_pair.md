---
uid: Configuring_a_new_DMA_in_Failover_pair
---

# Configuring a new DataMiner Agent as a new Agent in a Failover pair

If you are installing an Agent that will be paired with an existing Agent in a Failover setup, after the core DataMiner software has been installed (either via the [DataMiner Installer v10.4](xref:Installing_DM_using_the_DM_installer) or by [using a pre-installed VHD](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk)), instead of clicking *Start* to configure the DataMiner Agent automatically, follow the steps below:

1. Make sure both the existing and new DMA are prepared and the necessary prerequisites are met, as detailed under [Preparing the two DataMiner Agents](xref:Preparing_the_two_DataMiner_Agents).

   > [!IMPORTANT]
   > Do not start DataMiner on the newly installed DMA before this preparation is fully done.

1. [Start the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).

1. After a short while, a *Request.lic* file should appear in the `C:\Skyline DataMiner\` folder.

1. Contact [dataminer.licensing@skyline.be](mailto:dataminer.licensing@skyline.be) and provide them with the ID of the existing DMA and the *Request.lic* file.

   In your email, mention that it concerns a Failover Agent for an existing Agent.

1. Wait until you receive either a *dataminer.lic* or *response.lic* file from Skyline.

1. When you have the *dataminer.lic* or *response.lic* file, copy it to the `C:\Skyline DataMiner\` folder.

1. [Restart the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).

Once the new DMA is running, continue with the [Failover configuration in Cube](xref:Failover_configuration_in_Cube).
