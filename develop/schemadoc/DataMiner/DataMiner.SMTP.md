---
uid: DataMiner.SMTP
---

# SMTP element

Configures outgoing mail.

See [Configuring outgoing email](xref:Configuring_outgoing_email).

## Parents

[DataMiner](xref:DataMiner)

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| All |  |  |
| &#160;&#160;[From](xref:DataMiner.SMTP.From) | [0, 1] | Configures a custom "From" address that will override the default "From" address specified in the DataMiner Agent interface. |
| &#160;&#160;[Helo](xref:DataMiner.SMTP.Helo) | [0, 1] | Specifies the fully qualified domain name of the client, which will be sent to the SMTP server in the HELO command. |
| &#160;&#160;[Host](xref:DataMiner.SMTP.Host) | [0, 1] | Specifies the name or IP address of the SMTP server. |
| &#160;&#160;[HostPort](xref:DataMiner.SMTP.HostPort) | [0, 1] | Specifies the port. |
| &#160;&#160;[LoginMethod](xref:DataMiner.SMTP.LoginMethod) | [0, 1] | Specifies the method that will be used to authenticate the DataMiner Agent when it logs on to the SMTP server. |
| &#160;&#160;[MaxSubjectLength](xref:DataMiner.SMTP.MaxSubjectLength) | [0, 1] | Specifies the maximum length of the message subject. |
| &#160;&#160;[Password](xref:DataMiner.SMTP.Password) | [0, 1] | Specifies the password with which the DataMiner Agent will log on to the SMTP server. |
| &#160;&#160;[User](xref:DataMiner.SMTP.User) | [0, 1] | Specifies the username with which the DataMiner Agent will log on to the SMTP server. |
