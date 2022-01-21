---
uid: Accessing_DMS_Alerter
---

# Accessing DMS Alerter

#### Installing the software

1. Browse to *http(s)://\[DMA\]/tools*, where \[DMA\] is the hostname of your DMA.

2. In the section *Standalone applications*, click the MSI installer for Skyline Alerter.

3. When a message appears asking if you want to run SLAlerterSetup.msi, click *Run*.

4. Follow the instructions in the *Skyline Alerter Setup Wizard* to complete the installation.

#### Starting DMS Alerter for the first time

> [!TIP]
> See also:
> [Setting your startup preferences for DMS Alerter](../../part_7/DataminerTools/Configuring_DMS_Alerter.md#setting-your-startup-preferences-for-dms-alerter)

1. Open the *Skyline Alerter* application.

2. In the *Add Account* screen, specify the following details.

    - **connect to**: The name or IP address of the DataMiner Agent to which you want to connect.

    - **domainuser**: The username of the DMA’s local administrator account.

    - **password**: The password of the DMA’s local administrator account.

3. Click *Add Account*.

DMS Alerter will connect to the DataMiner Agent you specified. Two tabs will appear in the user interface:

- Alarms

- Collaboration

The *Alarms* tab will automatically be selected and the current alarms will be loaded. If there are new alarms, pop-up balloons will appear at the bottom of your screen.
