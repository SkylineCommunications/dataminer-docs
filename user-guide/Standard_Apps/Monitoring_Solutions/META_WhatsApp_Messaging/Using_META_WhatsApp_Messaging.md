---
uid: Using_META_WhatsApp_Messaging
---

# Using the META WhatsApp Messaging solution

## Configuring the 'META WhatsApp Messaging' connector

For detailed instructions on configuring the *META WhatsApp Messaging connector*, visit the [*connector documentation*](https://docs.dataminer.services/connector/doc/META_WhatsApp_Messaging.html#configuration).

## Creating a correlation rule

1. Create a [correlation rule](xref:Adding_a_new_Correlation_rule).

   - Set the alarm filter: Define the specific alarms that should trigger this correlation rule.

   - Configure the action: Set the rule to execute the *META Alarm Detection* **script** and select the **element** running the *META WhatsApp Messaging* connector desired to send the alarm notifications.

   > [!TIP]
   > See also: [Orchestration & Automation courses](https://community.dataminer.services/learning/courses/orchestration-automation/) on DataMiner Dojo.

> [!IMPORTANT]
> You can create as many correlation rules and elements as you need to send different alarms to different contacts.

## Sample Configuration

1. Complete the [solution installation process.](xref:META_WhatsApp_Messaging_Installation#installing-the-meta-whatsapp-messaging-connector).
1. In this case, we want to receive the **critical alarms** generated in our DMA. Therefore, this is the way to configure the correlation rule:
    ![Correlation rule configuration](~\user-guide\images\META_WhatsApp_Messaging_Correlation.png)
1. If everything went well during the installation and configuration, and an alarm occurs (1) that matches the filtering criteria defined (a critical alarm for this case), the people in the Contacts table will receive an alarm message in their WhatsApp apps (2), informing them about the generated alarm.
    ![WhatsApp messages according the alarms generated](~\user-guide\images\META_WhatsApp_Messaging_Cover.png)
