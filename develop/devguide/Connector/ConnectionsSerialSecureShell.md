---
uid: ConnectionsSerialSecureShell
---

# Secure Shell

## About SSH

Secure Shell (SSH) is a protocol for secure remote login and other secure network services over an insecure network. It replaces older protocols like Telnet or rlogin.

The specification of the SSH protocol (version 2) can be found in the following RFCs:

- [RFC 4251](https://datatracker.ietf.org/doc/html/rfc4251): The Secure Shell (SSH) Protocol Architecture
- [RFC 4252](https://datatracker.ietf.org/doc/html/rfc4252): The Secure Shell (SSH) Authentication Protocol
- [RFC 4253](https://datatracker.ietf.org/doc/html/rfc4253): The Secure Shell (SSH) Transport Layer Protocol
- [RFC 4254](https://datatracker.ietf.org/doc/html/rfc4254): The Secure Shell (SSH) Connection Protocol

> [!NOTE]
> This list is not exhaustive.

## Defining an SSH connection in a protocol

There are two methods of authentication when establishing an SSH connection:

1. **Password Authentication**:

   The protocol provides a username and password to the remote SSH server for verification.

1. **Public Key Authentication**:

   The protocol provides a digital signature created with a private key, and the server verifies it using the matching public key.

> [!NOTE]
> Typically, both methods of authentication are implemented in a protocol to give the user the choice how to connect. When both methods are configured, public key authentication has precedence over password authentication, as this is considered more secure.

> [!IMPORTANT]
> Refer to [Differences with serial communication](#differences-with-serial-communication) for an overview of some differences between regular serial connections and SSH connections in DataMiner.

### Password authentication

For this method, two parameters need to be created: one to hold the username and the other to hold the password.
Accompanying write parameters can be added so the credentials can be entered from the element.

```xml
<Param id="1100" trending="false" save="true">
    <Name>Username</Name>
    <Description>Username</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <LengthType>next param</LengthType>
        <Type>string</Type>
    </Interprete>
    <Display>
        <RTDisplay>true</RTDisplay>
        <Positions>
            <Position>
                <Page>Authentication</Page>
                <Row>0</Row>
                <Column>0</Column>
            </Position>
        </Positions>
    </Display>
    <Measurement>
        <Type>string</Type>
    </Measurement>
</Param>
<Param id="1150" setter="true">
    <Name>Username</Name>
    <Description>Username</Description>
    <Type>write</Type>
    <Interprete>
        <RawType>other</RawType>
        <LengthType>next param</LengthType>
        <Type>string</Type>
    </Interprete>
    <Display>
        <RTDisplay>true</RTDisplay>
        <Positions>
            <Position>
                <Page>Authentication</Page>
                <Row>0</Row>
                <Column>0</Column>
            </Position>
        </Positions>
    </Display>
    <Measurement>
        <Type>string</Type>
    </Measurement>
</Param>
<Param id="1101" trending="false" save="true">
    <Name>Password</Name>
    <Description>Password</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <LengthType>next param</LengthType>
        <Type>string</Type>
    </Interprete>
    <Display>
        <RTDisplay>true</RTDisplay>
        <Positions>
            <Position>
                <Page>Authentication</Page>
                <Row>1</Row>
                <Column>0</Column>
            </Position>
        </Positions>
    </Display>
    <Measurement>
    <Type options="password">string</Type>
    </Measurement>
</Param>
<Param id="1151" setter="true">
    <Name>Password</Name>
    <Description>Password</Description>
    <Type>write</Type>
    <Interprete>
        <RawType>other</RawType>
        <LengthType>next param</LengthType>
        <Type>string</Type>
    </Interprete>
    <Display>
        <RTDisplay>true</RTDisplay>
        <Positions>
            <Position>
                <Page>Authentication</Page>
                <Row>1</Row>
                <Column>0</Column>
            </Position>
        </Positions>
    </Display>
    <Measurement>
        <Type options="password">string</Type>
    </Measurement>
</Param>
```

> [!IMPORTANT]
> Use the [password](xref:Protocol.Params.Param.Measurement.Type-options#options-for-measurement-type-string) option on the parameter holding the password. Using this option ensures greater security.

The two parameters also need to be defined in the port settings. Note that all connections should have a [PortSettings](xref:Protocol.Ports.PortSettings) tag, and they have to be placed in the same order as defined in the [Protocol.Type](xref:Protocol.Type) advanced attribute.

```xml
<PortSettings name="SSH Connection">
    <IPport>
        <DefaultValue>22</DefaultValue>
    </IPport>
    <BusAddress>
        <Disabled>true</Disabled>
    </BusAddress>
    <PortTypeSerial>
        <Disabled>true</Disabled>
    </PortTypeSerial>
    <PortTypeUDP>
        <Disabled>true</Disabled>
    </PortTypeUDP>
    <SSH>
        <Credentials>
            <Username pid="1100"/>
            <Password pid="1101"/>
        </Credentials>
    </SSH>
</PortSettings>
```

The connection is then established by DataMiner, provided the correct username and password are filled in.

### Public key authentication

For this method, a parameter needs to be created to hold the path to the private key file.

The content of this parameter should be formatted like this: `key=C:\Users\User\.ssh\my_key_rsa`

> [!NOTE]
> If the private key is protected by a passphrase, it must be appended to the file path, separated by a semicolon. It should be formatted like this: `key=C:\Users\User\.ssh\my_key_rsa;pass=passphrase`

```xml
<Param id="1102" trending="false" save="true">
    <Name>PrivateKeyAndPassphrase</Name>
    <Description>Private Key and Passphrase</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <LengthType>next param</LengthType>
        <Type>string</Type>
    </Interprete>
</Param>
```

This parameter also needs to be defined in the port settings. Note that all connections should have a PortSettings tag, and they have to be placed in the same order as defined in the [Protocol.Type](xref:Protocol.Type) advanced attribute. Note also that the `Credentials/Username` tag is present, as this will indicate the user for the connection.

```xml
<PortSettings name="SSH Connection">
    <IPport>
        <DefaultValue>22</DefaultValue>
    </IPport>
    <BusAddress>
        <Disabled>true</Disabled>
    </BusAddress>
    <PortTypeSerial>
        <Disabled>true</Disabled>
    </PortTypeSerial>
    <PortTypeUDP>
        <Disabled>true</Disabled>
    </PortTypeUDP>
    <SSH>
       <Identity pid="1102"/>
       <Credentials>
          <Username pid="1100"/>
       </Credentials>
    </SSH>
</PortSettings>
```

The connection is then established by DataMiner, provided the parameter holds the private key and passphrase.

To give the user the choice how to connect, both methods of authentication are typically implemented in a connector:

```xml
    <SSH>
       <Identity pid="1102"/>
       <Credentials>
            <Username pid="1100"/>
            <Password pid="1101"/>
        </Credentials>
    </SSH>
</PortSettings>
```

When both methods are configured, public key authentication has precedence over password authentication, as this is considered more secure.

> [!NOTE]
> The approach where the parameter IDs are specified for the identity file and/or credentials supports having an SSH connection that is not the main (first) connection in the connector. There is another way to specify these parameters, which is now deprecated as it only supports connectors with a single SSH connection using the fixed port 22. This involves adding the following options to different parameters: [ssh username](xref:Protocol.Params.Param.Type-options#ssh-username), [ssh password](xref:Protocol.Params.Param.Type-options#ssh-pwd), and [ssh options](xref:Protocol.Params.Param.Type-options#ssh-options).

#### Remarks

Once authentication is successful, the socket timeout is set to zero (no timeout) to prevent the connection from being closed when no activity occurs on the SSH connection for *timeoutTime* ms (RN 3303).

## Differences with serial communication

There are a number of differences between implementing serial communication and implementing serial communication using an SSH connection.

- Headers are not supported for SSH. Only trailers.
- For commands sent via SSH, you do not need to send the Carriage Return (0x0D) and New Line (0x0A) characters to indicate the end of the command. This is done automatically.
- Separating multiple SSH commands using ';' or 'enters' inside one DataMiner command is not supported.
- The first part of a response is the corresponding command that has been sent.

## Selecting a local port

In legacy DataMiner versions prior to 7.0.3 (RN 3859), DataMiner uses the same SSH connection if the polling IP is the same, which can cause problems. Because of this, in older protocols, a workaround may be used that allows the user to specify a different local IP port in the element wizard, by defining the following in the protocol:

```xml
<PortSettings>
    <LocalIPport>
        <DefaultValue>200</DefaultValue>
        <Disabled>false</Disabled>
    </LocalIPport>
</PortSettings>
```

![DataMiner Cube local IP port configuration](~/develop/images/Connection_Types_-_SshlocalIPPort.png)

## SSH logging

A dedicated log file is used for the SSH connections: "SLSSH.txt". Standard logging provides information about the following:

- Create Object
- Open 1.2.3.4
- Open Exception
- Open Completed
- Connect 1.2.3.4
- Connect Exception
- Connect Complete
- Close
- Close Exception
- Close Complete
- Set Timeout
- Set Timeout Exception
- Set RetryTime
- Trailer=\<none>
- Trailer=\<xxx> (x times)
- Read Exception
- Write Exception
- WriteLine Exception

More logging can be obtained by creating a file with the name "SLSSHExt.txt". This will activate extended logging and DataMiner will then write additional information regarding the beginning and end of reads/writes and what data is written/read to this log file.

> [!CAUTION]
> Extended logging uses a lot of memory, so do not keep this running if it is not needed.

## SSH support in DataMiner

### [From DataMiner 10.3.0/10.2.4 onwards](#tab/ssh1-1)

#### Key exchange algorithms

DataMiner will propose the following key exchange algorithms to the server in the following order:

1. ecdh-sha2-nistp521
1. ecdh-sha2-nistp384
1. ecdh-sha2-nistp256
1. diffie-hellman-group14-sha1
1. diffie-hellman-group1-sha1
1. diffie-hellman-group-exchange-sha1

#### Ciphers

DataMiner will propose the following ciphers to the server in the following order:

1. aes256-ctr
1. aes128-ctr
1. aes128-cbc
1. 3des-cbc

#### Hash-based Message Authentication Codes (HMAC)

DataMiner will propose the following hash-based message authentication algorithms (HMAC) to the server in the following order:

1. HMAC-SHA2-512-etm\@openssh.com (from DataMiner 10.3.0 [CU11]/10.4.2 onwards<!--RN 38213-->)
1. HMAC-SHA2-256-etm\@openssh.com (from DataMiner 10.3.0 [CU11]/10.4.2 onwards<!--RN 38213-->)
1. HMAC-SHA2-512 (from DataMiner 10.2.5/10.3.0 onwards)
1. HMAC-SHA2-256
1. HMAC-SHA1
1. HMAC-MD5

#### Host key types

- ecdsa-sha2-nistp521 (from DataMiner 10.2.6/10.3.0 onwards)
- ecdsa-sha2-nistp384 (from DataMiner 10.2.6/10.3.0 onwards)
- ecdsa-sha2-nistp256 (from DataMiner 10.2.6/10.3.0 onwards)
- ssh-rsa
- ssh-dss

#### [Prior to DataMiner 10.3.0/10.2.4](#tab/ssh-2)

#### Key exchange algorithms

DataMiner will propose the following key exchange algorithms to the server in the following order:

1. diffie-hellman-group-exchange-sha1
1. diffie-hellman-group1-sha1
1. diffie-hellman-group14-sha1<!-- RN 14766 -->
1. ecdh-sha2-nistp256<!-- RN 14877 -->

#### Ciphers

DataMiner will propose the following ciphers to the server in the following order:

1. 3des-cbc
1. aes128-cbc
1. aes128-ctr<!-- RN 14766 -->

#### Hash-based Message Authentication Codes (HMAC)

DataMiner will propose the following hash-based message authentication algorithms (HMAC) to the server in the following order:

1. HMAC-MD5
1. HMAC-SHA1
1. HMAC-SHA2-256<!-- RN 14877 -->

#### Host key types

- ssh-rsa
- ssh-dss

***

## Selecting the key exchange algorithm

To specify the key exchange algorithm to be used when connecting to an SSH server, define a serial connection that specifies the key exchange algorithm in the KexAlgorithms tag.<!-- RN 13897 -->

```xml
<Connection id="1" name="SSH Connection">
    <Type>serial</Type>
    <CommunicationOptions>
        <KexAlgorithms>
        <KexAlgorithm>diffie-hellman-group1-sha1</KexAlgorithm>
        <KexAlgorithm>diffie-hellman-group-exchange-sha1</KexAlgorithm>
        </KexAlgorithms>
    </CommunicationOptions>
</Connection>
```

## SCP/SFTP

When you need to implement SCP or SFTP in a protocol, we recommend referencing the SSH.NET library in a QAction. See <https://github.com/sshnet/SSH.NET>.

### See also

- [SSH](xref:Protocol.PortSettings.SSH)
- [password](xref:Protocol.Params.Param.Measurement.Type-options#options-for-measurement-type-string)
- [QActions](xref:LogicQActions)
- [Protocol.QActions.QAction](xref:Protocol.QActions.QAction)
