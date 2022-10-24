---
uid: Trap_receiver
---

# Trap receiver

This functionality allows you to visualize traps and inform messages for all applicable SNMP versions, i.e. traps for SNMPv1/v2/v3 and inform messages for SNMPv2/v3. In addition, when the tool receives an inform message, it will reply with an acknowledgment.

You can access the trap sender functionality of the tool by selecting *Tools* > *Trap and Inform Monitor* in the menu bar. The following window then opens:

![](~/develop/images/QADS_TrapAndInformMonitor.png)
<br>Trap and Inform Monitor window

To start the tool, select an IP in the drop-down box and enter a port. Then click the *Start* button.

To allow the tool to decrypt SNMPv3 traps or informs, go to *File* > *Configure SNMPv3 Security* in the menu bar. A window then opens where you can configure the necessary settings.
