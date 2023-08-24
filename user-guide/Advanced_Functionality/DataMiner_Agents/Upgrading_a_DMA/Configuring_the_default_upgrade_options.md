---
uid: Configuring_the_default_upgrade_options
---

# Configuring the default upgrade options

In System Center, you can configure the default settings for upgrade options.

To do so:

1. In DataMiner Cube, go to *System Center* > *Settings* > *Upgrade*.

   The following options are available on this page:

   - *Extract all files*: This option is recommended and is selected by default. It ensures that all DataMiner system files are replaced.

   - *Delayed start*: Select this option if you want the Windows system services to be started before the DataMiner services. (Recommended on systems running a large number of services.)

   - *Automatically start DMA after startup*: Select this option if you want the DataMiner Agent software to start up automatically after the upgrade. If you do not select this option, the DataMiner Agent software will have to be started manually.

   - *Stop SNMP*: Select this option if you want the Windows SNMP Service to be stopped before starting the upgrade procedure. If you choose not to stop the Windows SNMP service, the latter is likely to interfere with the DataMiner SLSNMPAgent process. To prevent interference, you will have to change either the listening port of SLSNMPAgent or the listening port of the Windows SNMP service. See also: [Changing SNMP agent ports](xref:Changing_SNMP_agent_ports).

   - *Reboot after upgrade*: Select this option if you want the DataMiner Agent(s) to be automatically rebooted at the end of the upgrade procedure.

   - *Failover policy*: This option allows you to select the default policy for upgrading a Failover setup. This determines in which order the DMA in a Failover setup are upgraded by default.

     > [!IMPORTANT]
     > We highly recommend that you set this to *Upgrade main and backup Agent simultaneously*.

1. After you have configured the options to your preferences, click the *Save* button in the lower right corner.
