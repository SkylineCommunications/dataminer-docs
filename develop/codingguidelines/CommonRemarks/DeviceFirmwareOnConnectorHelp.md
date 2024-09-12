---
uid: Device_Firmware_On_Connector_Help
---

# Device Firmware on Connector Help

It's very important that the Device Firmware is filled in, it can greatly help with investigation 'issues' in the future and noticing that it's because of a new firmware version. Did you check with the TAM or on the actual device interface (if one exists?) Knowing the firmware version is very important and these devices almost always have a hardware revision, firmware version, software version, ...

In case of SNMP:
You can also try retrieving the default snmp parameters for version and location and name. The generic SNMP OIDs that are included for every SNMP Device.

'''xml
<Param id="1" trending="false">
    <Name>sysDescr</Name>
    <Description>System Description</Description>
        <Information>
            <Subtext>
                <![CDATA[A textual description of the entity.  This value should include the full name and version identification of the system's hardware type, software operating-system,
and networking software.]]>
            </Subtext>
        </Information>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <LengthType>next param</LengthType>
        <Type>string</Type>
    </Interprete>
    <SNMP>
        <Enabled>true</Enabled>
        <OID type="complete">1.3.6.1.2.1.1.1.0</OID>
        <Type>octetstring</Type>
    </SNMP>
    <Display>
        <RTDisplay>true</RTDisplay>
        <Positions>
            <Position>
                <Page>System Info</Page>
                <Row>0</Row>
                <Column>0</Column>
            </Position>
        </Positions>
    </Display>
    <Measurement>
        <Type>string</Type>
    </Measurement>
</Param>
.'''