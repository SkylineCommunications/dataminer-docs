---
uid: SLNetClientTest_configuring_SMTP
---

# Configuring SMTP

A DMS can be configured to send out email notifications and reports via an SMTP server. This can be configured directly in DataMiner.xml or via the SLNetClientTest tool. Using the SLNetClientTest tool has the advantage that no DataMiner restart is required.

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab and select *UpdateSmtpConfigMessage* in the drop-down box at the top.

1. Specify the necessary SMTP settings. See [SMTP server settings](xref:Configuring_outgoing_email#smtp-server-settings).

   > [!TIP]
   > If you are configuring SMTP in order to activate CDMR, refer to [SMTP configuration](xref:CDMR#smtp-configuration) for information on the required settings.

1. Click the *Send Message* button.

1. If there are several DataMiner Agents in your DataMiner System, send the message again for every DataMiner Agent that has to be able to send email messages. You do not need to reconnect for this. Instead you can fill in the DMA ID in the first field of the message each time.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
