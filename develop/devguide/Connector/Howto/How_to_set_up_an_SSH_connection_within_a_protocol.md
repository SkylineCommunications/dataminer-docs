---
uid: How_to_set_up_an_SSH_connection_within_a_protocol
---

# How to set up an SSH connection within a protocol

Below, you can learn how to efficiently establish an SSH connection within a protocol and how to tackle the obstacles you can encounter during setup.

SSH can ensure a more secure remote connection to network services that are in an insecure network. SSH connections are only possible when the services can communicate through serial connections of type TCP.

## Authentication

To establish an SSH connection, you need authentication. This can be done using a password or using public key authentication. Password authentication is used most frequently.

You can define both kinds of authentication in a protocol, but keep in mind that **public key authentication has precedence** over password authentication.

### Password authentication

There are **two ways** to make a protocol recognize the password authentication. However, you only can use one of them at a time. **Do not combine them.**

The first is **using the *options* attribute within the *Type* tag**.

```xml
<Param id="10" trending="false" save="true">
    <Name>sshUserName</Name>
    <Description>SSH User Name</Description>
    <Type options="SSH Username">read</Type>
    <Information>
        <Subtext>The user name credential for the ssh connection.</Subtext>
    </Information>
    <Interprete>
        <RawType>other</RawType>
        <Type>string</Type>
        <LengthType>next param</LengthType>
    </Interprete>
    <Display>
        <RTDisplay>true</RTDisplay>
        <Positions>
            <Position>
                <Page>General</Page>
                <Column>0</Column>
                <Row>5</Row>
            </Position>
        </Positions>
    </Display>
    <Measurement>
        <Type>string</Type>
    </Measurement>
</Param>
```

```xml
<Param id="11" trending="false" save="true">
    <Name>sshPassword</Name>
    <Description>SSH Password</Description>
    <Type options="SSH PWD">read</Type>
    <Information>
        <Subtext>The password credential for the ssh connection.</Subtext>
    </Information>
    <Interprete>
        <RawType>other</RawType>
        <Type>string</Type>
        <LengthType>next param</LengthType>
    </Interprete>
    <Display>
        <RTDisplay>true</RTDisplay>
        <Positions>
            <Position>
                <Page>General</Page>
                <Column>0</Column>
                <Row>6</Row>
            </Position>
        </Positions>
    </Display>
    <Measurement>
        <Type options="password">string</Type>
    </Measurement>
</Param>
```

The second is **adding SSH tags within the port settings** in combination with general username/password parameters without extra *options* attribute.

```xml
<SSH>
    <Credentials>
        <Username pid="10"/>
        <Password pid ="11"/>
    </Credentials>
</SSH>
```

### Public key authentication

This kind of authentication uses an identity file and is more secure than password authentication.

To make it possible to read out the identity file, you need to define an *SSH Options* parameter with the *SSH Options* option in the *Type* tag. The content of this parameter needs to include the path to the file and the passphrase `identity file path;passphrase`.

```xml
<Param id="1200" trending="false" save="true">
    <Name>SSH Options</Name>
    <Description>SSH Options</Description>
    <Type options="SSH Options">read</Type>
    <Interprete>
        <RawType>other</RawType>
        <LengthType>next param</LengthType>
        <Type>string</Type>
    </Interprete>
    <Display>
        <RTDisplay>true</RTDisplay>
        <Positions>
            <Position>
                <Page> General</Page>
                <Row>7</Row>
                <Column>0</Column>
            </Position>
        </Positions>
    </Display>
    <Measurement>
        <Type>string</Type>
    </Measurement>
</Param>
```

## Communication protocol conventions

SSH works through serial communication, so serial XML conventions need to be followed within the protocol to ensure optimal communication with the system.

The following things must be kept in mind:

- The beginning of the response corresponds with the command that has been sent. This is followed by the actual response. Like in the example below, the system can send a fixed combination at the end of the response. Make sure this matches to ensure proper handling of the response.
- There is no need for headers and trailers for commands and responses. Only trailers are supported, so if the system needs a trailer for the command or response to communicate, this can be used.

## Port settings

When you want a protocol to communicate through SSH, and the SSH connection is not the main connection, you need to define the ports tags illustrated below. SSH uses IP port 22 by default. All other port types need to be disabled.

```xml
<PortSettings name="SNMP Connection">
    <BusAddress>
        <Disabled>true</Disabled>
    </BusAddress>
    <PortTypeSerial>
        <Disabled>true</Disabled>
    </PortTypeSerial>
    <PortTypeIP>
        <Disabled>true</Disabled>
    </PortTypeIP>
</PortSettings>
```

```xml
<Ports>
    <PortSettings name="IP Connection">
        <BusAddress>
            <Disabled>true</Disabled>
        </BusAddress>
        <PortTypeUDP>
            <Disabled>true</Disabled>
        </PortTypeUDP>
        <PortTypeSerial>
            <Disabled>true</Disabled>
        </PortTypeSerial>
        <IPport>
            <DefaultValue>22</DefaultValue>
            <Disabled>false</Disabled>
        </IPport>
    </PortSettings>
</Ports>
```
