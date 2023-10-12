---
uid: Configuring_outgoing_email
---

# Configuring outgoing email

A DMS can be configured to send out email notifications and reports via an SMTP server.

> [!NOTE]
> For this feature, this product includes software developed by the OpenSSL Project for use in the OpenSSL Toolkit (<http://www.openssl.org/>).
>
> - From DataMiner 8.5.5 up to DataMiner 9.5.12, OpenSSL library version v1.0.2a is used.
> - From DataMiner 9.5.13 onwards, OpenSSL library version v1.0.2m is used.
> - From DataMiner 9.6.1 onwards, OpenSSL library version v1.1.0h is used.
> - From DataMiner 9.6.8 onwards, OpenSSL library version v1.1.0j is used.
> - From DataMiner 9.6.11 onwards, OpenSSL library version v1.1.1c is used.

> [!TIP]
> See also: [Agents – configuring an email server](https://community.dataminer.services/video/agents-configuring-an-email-server/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Prerequisites

In order to send out email notifications or email reports, a DataMiner Agent has to be able to connect to an outgoing email server (SMTP server).

## Default “From” address

To specify the default “From” address to be used in outgoing email messages, do the following:

1. Go to *Apps* > *System Center*.

1. In System Center, go to *Agents* > *system*.

1. In the *Email* box, specify the default “From” address.

1. Click *Save*.

1. Restart the DataMiner Agent.

## DataMiner.xml configuration

If a DataMiner Agent has to be able to send out email messages, then the *DataMiner.xml* file located in the *C:\\Skyline DataMiner* directory of that DataMiner Agent has to have an *\<SMTP>* section containing the necessary email settings.

You can either configure this directly in *DataMiner.xml* or use the SLNetClientTest tool. To configure it directly in *DataMiner.xml*, a DataMiner restart is required.

- For information on how to configure this using the **SLNetClientTest tool**, see [Configuring SMTP](xref:SLNetClientTest_configuring_SMTP).

- To configure this **directly in *DataMiner.xml*** instead:

  1. Log on to the DataMiner Agent, either locally or through a remote desktop session.

  1. Stop the DataMiner software.

  1. Open the file *C:\\Skyline DataMiner\\DataMiner.xml*.

  1. Go to the *\<SMTP>* section. If this section does not exist yet, add it.

  1. In this section, enter the correct SMTP server settings. See [SMTP server settings](#smtp-server-settings).

  1. **Restart** the DataMiner Agent in order to apply the new settings.

  > [!NOTE]
  > If there are several DataMiner Agents in your DataMiner System, execute the above-mentioned procedure on every DataMiner Agent that has to be able to send email messages.

## SMTP server settings

### Basic SMTP server settings

- **Host**: The name or IP address of the SMTP server.

- **HostPort**: Default port is 25.

  - If the server supports or requires SSL communication, use port 465 instead of port 25.

  - If SSL has to be used on a non-standard port (e.g. 123), specify “*123-ssl*”.

  - If you explicitly do not want to use SSL, specify “*465-nossl*”.

  - If you want to use STARTTLS, specify e.g. “*123-starttls*”.

- **LoginMethod**: The method that will be used to authenticate the DataMiner Agent when it logs on to the SMTP server. The following methods can be specified:

  - **NoLoginMethod**: The user will not be authenticated by the server.

  - **LoginPlainMethod**: Username and password will be sent to the server unencrypted.

  - **CramMD5Method**: The user will be authenticated using CRAM MD5 (Challenge-Response Authentication Mechanism, see RFC 2195). The server generates a challenge, to which the user has to respond with a username and the MD5 HMAC (Hash-based Message Authentication Code) of the challenge (with the user password as the key).

  - **AuthLoginMethod**: Username and password will be sent to the server using simple base64 encoding.

  - **NTLM**: The user will be authenticated using the MS NTLM (NT LAN Manager) protocol.

  - **Auto**: The authentication protocol to be used will be auto-negotiated.

- **User**: The username with which the DataMiner Agent will log on to the SMTP server.

  If LoginMethod is set to “NoLoginMethod”, no username has to be specified.

- **Password**: The password with which the DataMiner Agent will log on to the SMTP server.

  If LoginMethod is set to “NoLoginMethod”, no password has to be specified.

### Advanced SMTP server settings

You can specify the following advanced settings. However, these are not mandatory.

- **Helo**: The fully qualified domain name of the client, which will be sent to the SMTP server in the HELO command.

  Example: *\<Helo>pc.company.local\</Helo>*

- **MaxSubjectLength**: The maximum length of the message subject.

  Example: *\<MaxSubjectLength>78\</MaxSubjectLength>*

- **From**: A custom “From” address that will override the default “From” address specified in the DataMiner Agent interface.

  Example: *\<From>address@example.com\</From>*
  
## Example of SMTP server configuration

The example below shows how the SMTP element in DataMiner.xml should be configured.

```xml
<SMTP>
  <Host>smtp.mail.com</Host>
  <HostPort>587-starttls</HostPort>
  <LoginMethod>AuthLoginMethod</LoginMethod>
  <User>MyMailName@mail.com</User>
  <Password>MyMailPassword</Password>
</SMTP>
```
