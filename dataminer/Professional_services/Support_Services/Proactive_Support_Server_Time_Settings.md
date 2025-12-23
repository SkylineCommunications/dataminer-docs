---
uid: Proactive_Support_Server_Time_Settings
---

# Proactive Support -  Server Time Settings (CCA) - Issues Detected

If the DataMiner [support application](xref:User_operations_support) detects a critical level of the [BPA Check Time Server](xref:BPA_Check_Time_Server) for a specific Cloud Connected DataMiner Agent, the automatic proactive support will kick in. This means that you will receive an email notifying you that a misconfiguration of the server time has been detected, and a Collaboration task will be generated with the purpose of resolving this issue.
Why does this matter even more for Cloud Connected Agents (CCA)? A synchronized time is required to guarantee smoot cloud interaction e.g. authentications, token renewals... Hence it is important to detect and correct any misconfigurations.

**What to do when you receive this notification?**

**As the responsible person**

1. Verify that the server times within the cluster are synchronized

1. Verify the configuration settings of the NTP server as described in the [BPA Check Time Server](xref:BPA_Check_Time_Server)

1. Make sure that the server times stay synchronized to prevent this issues by validating the BPA status.

**As a member of Skyline Tech Support**

In case the flow cannot determine the main customer stakeholder of the linked Maintenance & Support contract, the notification is forwarded to Skyline Tech Support to make sure the following is done or delegated:

1. Identify the customer stakeholder on collaboration (e.g. confirm with the Product Owner).

1. Configure the main customer stakeholder in the Maintenance & Support contract and/or parent project.

1. Send the notification to the customer so they can take the necessary actions to prevent issues.
