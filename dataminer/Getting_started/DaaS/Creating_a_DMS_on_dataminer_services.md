---
uid: Creating_a_DMS_on_dataminer_services
keywords: dms in the cloud
description: To create a new DaaS system, go to dataminer.services, click Add a DataMiner System, specify the necessary details, and click Deploy.
---

# Creating a new DMS on dataminer.services

Watch this short video to learn how to create a new DataMiner System hosted on dataminer.services, or follow the steps below:

<div style="width: 100%; max-width: 800px;">
  <video style="width: 100%; aspect-ratio: 16 / 9; height: auto;" controls>
    <source src="~/dataminer/images/DaaS.mp4" type="video/mp4">
  </video>
</div>

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%; margin-top: 20px;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DFF6DD; margin-right: 20px; color: black;">
    <b><span style="color: #2A7661;">💡 TIP</span></b><br>
    You can also watch our interactive exercise on DataMiner Dojo: 
    <a href="https://community.dataminer.services/courses/kata-11/">Kata #11: Create a DMS on dataminer.services</a>.
  </div>
</div>

<br />

1. [Log on to dataminer.services](xref:Logging_on_to_dataminer_services).

1. Next to *DataMiner Systems*, click *Add a DataMiner System*.

   ![Add a new DataMiner System button](~/dataminer/images/daas_create_001.png)

1. Click *DataMiner as a Service*.

1. Select the *Organization* under which you want to register the DataMiner System.

   > [!NOTE]
   > If the organization is not available yet in the dropdown list, you can add a new organization by clicking *Create new*. You will be able to specify the name and the URL for the organization. Note that in the URL of the organization only lowercase alphanumerical characters (a-z and 0-9) are allowed, and the URL cannot consist of numbers only.

1. Enter a *DataMiner System Name*.

1. Enter a custom *DataMiner System URL* if you want the URL to be different from the *DataMiner System Name*.

   > [!NOTE]
   > Only lowercase alphanumerical characters (a-z and 0-9) are allowed in the URL, and it cannot consist of numbers only.

1. Optionally, in the *Time zone* box, select the time zone for your DataMiner System.

   By default, the time zone is set to the time zone of your current location.

1. Enter a username and password for your DataMiner account.

1. Select the box next to *I agree to the terms of service*.

1. Click *Deploy*.

> [!NOTE]
>
> - It is possible to create a DaaS system as a staging system. Our Pay-per-Use model is used for this. For detailed information, see [DataMiner Community Edition](xref:Pricing_Commercial_Models#dataminer-community-edition).
> - When you create a DaaS system, your dataminer.services account will automatically be linked to your DataMiner account, so you can easily access DataMiner web apps such as the Monitoring app via remote access.

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 UP NEXT</b><br><a href="xref:Accessing_a_new_DMS"></a>
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>
