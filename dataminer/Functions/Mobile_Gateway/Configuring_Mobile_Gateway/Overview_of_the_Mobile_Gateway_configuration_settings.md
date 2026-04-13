---
uid: Overview_of_the_Mobile_Gateway_configuration_settings
---

# Overview of the Mobile Gateway configuration settings

Below you can find an alphabetical list of the possible settings in the file `C:\Skyline DataMiner\Mobile Gateway\Config.xml`.

## CountryCode

The two-digit ISO country code.

DataMiner tries to transform all phone numbers to internationally formatted phone numbers. If no country code is found in the phone number itself, the value of this tag will be added to the number.

We strongly recommend entering all telephone numbers in the DataMiner System in international format (starting with a "+" sign).

Default: 32 (Belgium).

## Device

The type of modem used.

- Falcom A2D (discontinued) \> *A2D*
- Falcom Tango55 (discontinued) \> *Tango55*
- Erco&Gener GenPro 18e (discontinued) \> *Tango55*
- Erco&Gener GenPro 20e (discontinued) \> *Tango55*
- SMSEagle \> *SMSEagle*
- Turnpike \> *Turnpike*

Default: *A2D*

## DMALostAfter

Every DataMiner Agent regularly sends an MGN_I\_AM_STILL_ONLINE notification to Mobile Gateway. If a particular DMA has not sent such a notification for \[DMALostAfter\] minutes, then Mobile Gateway will consider that DMA to be disconnected.

Default: 30 (minutes).

## FailedSMSRetry

The number of times Mobile Gateway has to retry sending a text message.

Default: 100 (retries).

## Files.EncryptedConfig

The file that contains all encrypted settings used by Mobile Gateway (e.g., the modem’s PIN and PUK codes).

Default: `C:\Skyline DataMiner\Mobile Gateway\MobileGateway.cfg`.

## Files.Logging

Obsolete. All Mobile Gateway log information is now stored in the folder` C:\Skyline DataMiner\Logging\Mobile Gateway.txt`.

## Files.Macros

The XML file that contains all commands that have been configured.

In a Failover setup, this file is synchronized among the two DataMiner Agents.

Default: `C:\Skyline DataMiner\Mobile Gateway\Macros.xml`

## Files.Messages

The XML file that contains the translations of the default Mobile Gateway (error) messages.

Default: `C:\Skyline DataMiner\Mobile Gateway\Messages.xml`

## GSM.ServiceCenter

The telephone number of the SMS Service Center, which is needed to send text messages.

If no number is specified in this tag, the telephone number of the service center is read from the SIM card.

Default: +32475161616

## HttpGsm.Location

The IP address of the device (e.g., SMSEagle, Turnpike).

The "port" attribute is the port to which DataMiner has to send its requests. This will usually be port 80. In case of HTTPS communication with an SMSEagle device, the port will most likely be 443.

See [Configuring Mobile Gateway to communicate with an SMSEagle device via HTTPS](xref:Configuring_Mobile_Gateway_to_communicate_with_an_SMSEagle_device_via_HTTPS).

## HttpGsm.RequireValidSsl

Set both this tag and the tag *HttpGsm.UseHttps* to *true* to enable communication with an SMSEagle device via HTTPS.

See [Configuring Mobile Gateway to communicate with an SMSEagle device via HTTPS](xref:Configuring_Mobile_Gateway_to_communicate_with_an_SMSEagle_device_via_HTTPS).

## HttpGsm.Schedule

The number of seconds between each processing of received messages.

If, for example, Schedule is set to "30", every 30 seconds all unread messages will be retrieved from the device and processed.

## HttpGsm.SMSEagle

The user name and the password of the account that will be used to access the SMSEagle device.

Since SMSEagle requires a plain-text transfer of both parameters, they are not encrypted in the *config.xml* file. For security reasons, try to use a password that is not used for other purposes.

From DataMiner 10.2.0/10.1.5 onwards, you can also add the *unicode="true"* attribute to this element to make the SMSEagle device use Unicode characters when sending text messages.

## HttpGsm.Turnpike

In this tag, enter the originator and the service:

- Originator is either a string of maximum 11 characters or a phone number of maximum 16 characters.
- Service is a string.

## HttpGsm.UseHttps

Set both this tag and the tag *HttpGsm.RequireValidSsl* to *true* to enable communication with an SMSEagle device via HTTPS. See [Configuring Mobile Gateway to communicate with an SMSEagle device via HTTPS](xref:Configuring_Mobile_Gateway_to_communicate_with_an_SMSEagle_device_via_HTTPS).

## Port.Baudrate

The baud rate of the modem.

Default: 9600 (bps)

## Port.DataBits

The number of data bits.

Default: 8

## Port.FlowCtrl

The flow control setting. Possible values: *no*, *CtsRts*, *CtsDtr*, *DsrDtr*, and *XonXoff*.

Default: no

## Port.Nr

The number of the COM port to which the modem is physically connected.

If the modem is connected to the DMA via a serial gateway, then enter the number of the virtual COM port you configured on the serial gateway.

Default: 1

## Port.Parity

The parity setting. Possible values: *no*, *even*, *mark*, *odd*, and *space*.

Default: no

## Port.StopBits

The number of stop bits. Possible values: *1*, *1.5*, and *2*.

Default: 1

## SendErrorMessages

If *true*, Mobile Gateway will return an error message to the user when a text message contains an invalid command.

Default: true

## SplitTimer

When a text message is longer than 160 characters (or less, depending on the encoding), the message will be split into multiple messages.^

The SplitTimer setting contains the number of milliseconds the mobile gateway will wait before it sends the next partial message.

Default: 50 (milliseconds)

See also: [Encoding and decoding of character sets in text messages](xref:Encoding_and_decoding_of_character_sets_in_text_messages)

## TimeOutTime

The number of seconds Mobile Gateway will wait for the modem to respond. If Mobile Gateway does not receive a response in time, it will go into timeout.

Default: 10000 (seconds)

## Trimmingoptions

In the *start* and *end* attributes of this tag, you can specify the prefix and/or the suffix to be cut off from any incoming text message.

For example: `<TrimmingOptions start="SLC" end=""/>`
