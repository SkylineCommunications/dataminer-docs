---
uid: Turning_SLA_tracking_on_and_off
---

# Turning SLA tracking on and off

It is possible either to turn SLA tracking off completely, or to disable outages, so that outages are no longer registered but you can still see the current active service alarms.

> [!TIP]
> You could for example turn off SLA tracking when you do maintenance on a DataMiner System and you do not want any generated alarms to be taken into account for your SLA. After maintenance is done, you can then enable SLA tracking again.

To activate or deactivate tracking of the SLA completely:

- On the *SLA Configuration* page of the SLA element, in the *Extra settings* section, click the *Admin State* toggle button.

To disable outages for the SLA:

- Go to the *Advanced Configuration* page and set *Outages* to *Disabled*.

  > [!NOTE]
  >
  > - You need at least security level 3 in order to change any of the settings on the *Advanced Configuration* page.
  > - If you disable outages, the SLA will no longer register any outages and most SLA functionality can no longer be used. However, any outages that occurred until outages were disabled are not removed, and the outage impact is still calculated for current active service alarms.
