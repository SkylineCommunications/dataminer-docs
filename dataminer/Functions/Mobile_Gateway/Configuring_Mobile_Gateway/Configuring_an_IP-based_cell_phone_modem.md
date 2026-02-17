---
uid: Configuring_an_IP-based_cell_phone_modem
---

# Configuring an IP-based cell phone modem

To configure an IP-based cell phone modem that is connected to your DataMiner System via the TCP/IP network:

1. Insert the SIM card in the device.

1. Connect the antenna to the device.

1. Connect the device to the network using a UTP cable.

1. Connect the device to a power source.

1. In an internet browser, go to the IP address of the device, and configure the PIN of the SIM card as well as the necessary user accounts.

1. In the `C:\Skyline DataMiner\Mobile Gateway` folder of one of your DataMiner Agents, make sure that there is a *Config.xml* file similar to the one in the example below.

   > [!NOTE]
   > You can add the password as plain text as illustrated in the example below. After the DMA has restarted, the password will be replaced by a GUID referring to the encrypted password, which is stored elsewhere.

1. After you have saved the *Config.xml* file, restart the DataMiner Agent.

1. In DataMiner Cube, go to *Apps* > *System Center.*

1. Select the *Mobile Gateway* tab and configure the necessary settings. For more information, see [Configuring Mobile Gateway in DataMiner Cube](xref:Configuring_Mobile_Gateway_in_DataMiner_Cube).

> [!NOTE]
> Since multiple DataMiner Agents can use the same IP-based device (e.g., SMSEagle, Turnpike), there is no way to know which DataMiner Agent will receive an incoming message.
>
> The first DataMiner Agent that sends a request to the device receives ALL unread messages.

## Example of a Config.xml file for an ip-based modem

```xml
<GSMConfig xmlns="http://www.skyline.be/config/config">
  <Device>SMSEagle</Device>
  <DMALostAfter>1</DMALostAfter>
  <FailedSMSRetry>100</FailedSMSRetry>
  <Files>
    <EncryptedConfig>C:\Skyline DataMiner\Mobile Gateway\MobileGateway.cfg</EncryptedConfig>
    <Macros>C:\Skyline DataMiner\Mobile Gateway\Macros.xml</Macros>
    <Messages>C:\Skyline DataMiner\Mobile Gateway\Messages.xml</Messages>
    <Logging></Logging>
  </Files>
  <GSM>
    <ServiceCenter>0475161616</ServiceCenter>
  </GSM>
  <CountryCode>32</CountryCode>
  <SendErrorMessages>true</SendErrorMessages>
  <SplitTimer>50</SplitTimer>
  <TimeOutTime>10000</TimeOutTime>
  <HttpGsm>
    <Location port="80">10.4.1.33</Location>
    <Schedule>30</Schedule>
    <SMSEagle user="Username" pass="Password" />
  </HttpGsm>
</GSMConfig>
```
