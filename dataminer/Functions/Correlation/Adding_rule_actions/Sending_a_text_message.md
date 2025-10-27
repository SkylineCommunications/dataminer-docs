---
uid: Sending_a_text_message
---

# Sending a text message

Use this action to make a Correlation rule send a text message to one or more recipients.

In the *Actions* section of the details pane:

1. Click *Add Action* and select *Send text message*.

1. Next to *To*, enter the recipients’ telephone numbers. Use semicolons to separate multiple numbers.

   Alternatively, you can also click *To* to select users and/or groups from the DMS.

   > [!NOTE]
   > You can combine multiple users, groups, and/or numbers, using a semicolon as separator between each entry. However, make sure there is no whitespace between the different entries.

1. In the *Message* field, enter the message that is to be sent.

1. Optionally, to also send the message when the conditions are no longer fulfilled, select *Execute on clear*.

1. Optionally, to also send the message when there is a change to the base alarms of the Correlated alarm, select *Execute on base alarm updates*.
