---
uid: Activate_CDMR
---

# Activate CDMR tool

To activate CDMR on all DMAs in a cluster in one go, two scripts are available. These can be especially useful in DataMiner Systems consisting of many DMAs, so that CDMR does not need to be activated manually on each DMA.

> You can download these scripts from [DataMiner Dojo](https://community.dataminer.services/download/activate-cdmr-scripts/).

> [!TIP]
> For more information on CDMR, see [Customer DataMiner Reporting (CDMR)](xref:CDMR).

> [!NOTE]
> When you connect a DataMiner Agent to dataminer.services, the connection to CDMR (Customer DataMiner Reporting) is automatically enabled. See [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## About these scripts

- *Script_Execute Cluster Script.xml* makes it possible to execute a single script on each DMA in the cluster.

- *Script_Activate CDMR.xml* will activate CDMR email reporting. It will also check the *MaintenanceSettings.xml* file to verify that the activation was successful. The result will be shown in the information events. In Failover setups, the change also automatically gets synchronized towards the offline Agent, though information events are only displayed for the online Agent.

## Usage

1. Upload both scripts to the DataMiner System where you want to use them.

1. Run the Execute Cluster Script, provide the script name *Activate CDMR* and click *Execute*.

   > [!TIP]
   > For more information on running Automation scripts, see [Running Automation scripts](xref:Running_Automation_scripts).