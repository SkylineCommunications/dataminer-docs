---
uid: CDMR
---

# Customer DataMiner Reporting (CDMR)

CDMR, or "Customer DataMiner Reporting", is a fully automated management and reporting platform, operated by the Skyline IOC (Integrated Operations Center), designed to ingest and process status and performance data from live DataMiner Systems around the world. The platform enables IOC staff at Skyline to keep track of the health status and performance of these DataMiner Systems in a proactive manner, and is part of Skyline’s DataMiner Maintenance & Support Service offering.

The data forwarded by a DataMiner System to CDMR is limited to general system configuration details, system performance data, and any anomalies (e.g. CPU load, HDD free space, disk busy time, database size, performance of DataMiner software processes, software error reporting, etc.).

In order to facilitate the exchange of data between a production DataMiner System and Skyline's IOC CDMR platform, reporting of the data is based on a standard email exchange. Therefore, the only requirement for CDMR is that sending emails is enabled for the production DataMiner System (which is typically already the case for the purpose of email notifications and email reporting).

It is highly recommended to enable CDMR reporting, as it facilitates the services Skyline Communications provides as part of the DataMiner Maintenance & Support service, and it allows issues to be dealt with proactively, before they can effectively affect the operation of a DataMiner System.

## CDMR reports

When CDMR reporting is activated, reports are sent at the following times:

- Once a day at about 6 AM (local server time)
- When DataMiner starts up
- When an alarm of type Error is created

A copy of a report is saved in the `C:\Skyline DataMiner\logging\WatchDog\Notifications` folder. The body of the email can be found in *message.xml*, and the *.zip* files are sent as attachments the email.

For a daily report, an additional archive `<timestamp>_All_Reports.zip` is generated based on the contents of the `C:\Skyline DataMiner\logging\WatchDog\Reports\Pending Reports` folder. Daily reports contain the following information:

- Server performance statistics: CPU and memory usage, process, thread and handle counts, server uptime, etc.
- General DMA information, such as active protocols, uptime, IP addresses, etc.
- Task Manager information such as handles, threads, CPU and memory for DataMiner-related processes.
- The HD free space and busy time.
- Stack and NotifyType counts.
- DMA element, service, and redundancy group counts.
- The Failover status.
- License information.
- A DataMiner database summary.

## Activating CDMR

To activate CDMR, you must configure SMTP so that emails can be sent and configure *MaintenanceSettings.xml* so that emails are sent to the correct address. Once the configuration is complete, Skyline Communications must also be notified.

> [!NOTE]
>
> - When you connect a DataMiner Agent to **dataminer.services**, the connection to CDMR (Customer DataMiner Reporting) is **automatically enabled**. See [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
> - In DataMiner Systems with multiple DMAs, it can be time-consuming to do the manual configuration detailed below. In that case, it can be useful to use the [Activate CDMR](xref:Activate_CDMR) tool instead. Note that the final step below ([Notify Skyline Communications](#notify-skyline-communications)), is still necessary when you use this tool.

### SMTP configuration

To activate CDMR, first you must make sure emails can be sent. For this purpose, SMTP must be configured in `C:\Skyline DataMiner\DataMiner.xml`.

You can configure this directly in *DataMiner.xml* file or via the SLNetClientTest tool. To configure it directly in *DataMiner.xml*, a **DataMiner restart** is required.

- If you configure SMTP directly in DataMiner.xml, specify the host, port, and login method in the `<SMTP>` tag. For example:

  ```xml
  <SMTP> 
      <Host>mail.skyline.be</Host>
      <HostPort>25</HostPort>
      <LoginMethod>NoLoginMethod</LoginMethod>
      <User/>
      <Password/>
  </SMTP>
  ```

  For detailed information, see [Configuring outgoing email](xref:Configuring_outgoing_email).

- If you configure SMTP via the SLNetClientTest tool, use the following settings:

  - *DataMinerID*: -1 for a local DMA or the actual DMA ID for a remote DMA.
  - *Host*: The SMTP host, e.g. `mail.skyline.be`.
  - *LoginMethod*: The login method, e.g. *NoLogin*.
  - *Port*: The SMTP port, e.g. 25.

  For detailed information, see [Configuring SMTP](xref:SLNetClientTest_configuring_SMTP).

### MaintenanceSettings.xml configuration

The file `C:\Skyline DataMiner\MaintenanceSettings.xml` must be configured to send reports to the correct address. For new DataMiner installations from DataMiner 10.1.11/10.2.0 onwards, this will be configured automatically. In earlier DataMiner versions or upgraded systems based on earlier versions, configure the `<EMail>` tag as follows:

```xml
<Watchdog>
    <EMail active="true"> 
        <Destination>reports@skyline.be</Destination>
        <CCDestination></CCDestination> 
        <BCCDestination></BCCDestination> 
    </EMail>
</Watchdog>
```

In the `CCDestination` field, you can optionally specify an address where a copy of the report should be sent.

After changes have been made to the *MaintenanceSettings.xml* file, a **DataMiner restart** is required.

If the `<Email>` tag is already correctly configured and you just need to set the active attribute to true, you can avoid having to restart DataMiner by setting this to true using the SLNetClientTest tool.

Proceed as follows to activate the email settings via the SLNetClientTest tool:

1. Open the SLNetClientTest tool. See [Opening the SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool).
1. Connect to the DMA for which you want to configure SMTP. See [Connecting to a DMA with the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).
1. Go to the *Build Message* tab and select *Advanced.SetDataMinerInfoMessage* in the drop-down box at the top.
1. Specify the following settings:

    - *DataMinerID*: -1 for a local DMA or the actual DMA ID for a remote DMA.
    - *StrInfo1*: true
    - *What*: 315

1. Click the *Send Message* button.

> [!CAUTION]
> Extreme care is always required when the SLNetClientTest tool is used. Incorrect use of this tool can have far-reaching consequences on the functionality of a DataMiner System.

### Notify Skyline Communications

The final step in the activation of CDMR is notifying Skyline Communications so they can add your email domain to CDMR. For this purpose, send an email to <techsupport@skyline.be>.
