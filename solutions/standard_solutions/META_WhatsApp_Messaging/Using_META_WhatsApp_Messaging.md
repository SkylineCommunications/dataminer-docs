---
uid: Using_META_WhatsApp_Messaging
---

# Using the META WhatsApp Messaging Solution

1. Configure the *META WhatsApp Messaging* connector.

   > [!TIP]
   > For detailed instructions on configuring the *META WhatsApp Messaging* connector, visit the [*connector documentation*](https://docs.dataminer.services/connector/doc/META_WhatsApp_Messaging.html#configuration).

1. Add contacts who will receive the WhatsApp notifications:

   1. Go to the *DATA* > *General* page of the *META WhatsApp Alerter* element.

   1. Click *New Contact* in the lower-right corner.

   1. Enter the contact's phone number and name, then confirm both by clicking the green check mark.

   1. Click *Add Contact*.

   1. After adding all necessary contacts, click the *X* button in the top-right corner.

1. Create a functional [Correlation rule](xref:Adding_a_new_Correlation_rule) to customize when notifications should be sent to WhatsApp. The alarm filter allows you to limit the number of alarms that will trigger the Correlation rule, such as only sending notifications for critical alarms on your DataMiner Agent.

   > [!TIP]
   >
   > - For an example of creating a Correlation rule that triggers a WhatsApp notification, see the [Example](#example-configuration) section.
   > - Follow our [Orchestration & Automation courses](https://community.dataminer.services/learning/courses/orchestration-automation/) on DataMiner Dojo.

   - **Alarm filter**: Specify which alarms should trigger this Correlation rule, e.g. critical alarms. See [Filtering and grouping base alarms for Correlation rules](xref:Filtering_and_grouping_base_alarms_for_Correlation_rules).

   - **Actions**: Configure the rule to execute the *META Alarm Detection* script when triggered. See [Adding rule actions in Correlation rules](xref:Adding_rule_actions_in_Correlation_rules).

     - Script: *META Alarm Detection*

     - MetaWhatsappElement: *META WhatsApp Alerter*

## Example configuration

In this example, a WhatsApp notification is sent whenever a critical alarm is generated on your DataMiner Agent.

1. Make sure the [*META WhatsApp Messaging* connector](xref:META_WhatsApp_Messaging_Installation#installing-the-meta-whatsapp-messaging-connector) is installed and properly configured.

1. Verify that one or more contacts have been added to the *Contacts* table on the *DATA* > *General* page of the *META WhatsApp Alerter* element.

1. Create the following configuration rule:

   ![Correlation rule configuration](~/dataminer/images/META_WhatsApp_Messaging_Correlation.png)

1. Click *Apply* in the lower-right corner.

   Now, when a critical alarm occurs (1), the contacts listed in the *Contacts* table will receive a WhatsApp notification (2), no matter their physical location.

   ![WhatsApp messages](~/dataminer/images/META_WhatsApp_Messaging_Cover.png)
