---
uid: Proactive_Support_Server_Time_Settings
---

# Proactive Support - server time settings (CCA)

If the DataMiner [Support application](xref:User_operations_support) detects a critical result for the [*Check Time Server* BPA test](xref:BPA_Check_Time_Server) on a cloud-connected DataMiner Agent (CCA), proactive support is triggered automatically.

In that case:

- An email notification is sent to inform you that a server time misconfiguration has been detected.

- A Collaboration task is generated to facilitate resolution of the issue.

Correctly synchronized server time is important for CCAs, as it is required for reliable cloud interaction, such as authentication and token renewal. Proactive detection helps detect and correct misconfigurations before they cause issues.

## What to do when you receive this notification

- If you are the **responsible person**:

  1. Verify that the server times within the cluster are synchronized.

  1. Verify the configuration settings of the NTP server, as described under [Check Time Server](xref:BPA_Check_Time_Server).

  1. Confirm that the BPA check remains in a healthy state to ensure server times stay synchronized.

- If you are a member of **Skyline Tech Support**:

  If the flow cannot determine the main customer stakeholder of the linked Maintenance & Support contract, the notification is forwarded to Skyline Tech Support to make sure the following actions are taken or delegated:

  1. Identify the customer stakeholder on Collaboration (for example, by confirming this with the Product Owner).

  1. Configure the main customer stakeholder in the Maintenance & Support contract and/or parent project.

  1. Send the notification to the customer so they can take the necessary actions to prevent further issues.
