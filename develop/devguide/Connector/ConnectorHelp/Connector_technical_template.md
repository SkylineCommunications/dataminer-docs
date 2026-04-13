---
uid: Connector_technical_template
---

# Connector technical documentation template

Below you can find the template for the technical page for connectors. When you copy-paste this, remember to replace all the placeholder text and remove any unnecessary square brackets.

> [!IMPORTANT]
> Only add a technical page when this is necessary. If very little or no technical information is needed to be able to use the connector, only add a marketing page.

```md
---
uid: Connector_technical_template
---

# Connector technical documentation template

## About

[Short description of the data source and of the function of the connector.]

## Configuration

### Connections

#### SNMP Connection - [Name of the connection]

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: [The polling IP or URL of the destination.]
- **Device address**: [Indicate if required or not. If it is, specify default value and range.]

SNMP Settings:

- **Port number**: [The port of the connected device, by default 161.]
- **Get community string**: [The community string used when reading values from the device (default: *public*).]
- **Set community string**: [The community string used when setting values on the device (default: *private*).]

#### Serial connection - [Name of the connection]

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: [Baudrate specified in the manual of the device, e.g., *9600*.]
  - **Databits**: [Databits specified in the manual of the device, e.g., *7*.]
  - **Stopbits**: [Stopbits specified in the manual of the device, e.g., *1*.]
  - **Parity**: [Parity specified in the manual of the device, e.g., *No*.]
  - **FlowControl**: [FlowControl specified in the manual of the device, e.g., *No*.]

- Interface connection:

  - **IP address/host**: [The polling IP of the device.]
  - **IP port**: [The IP port of the device. Indicate if required or not. If so, specify default value and range.]
  - **Bus address**: [The bus address of the device. Indicate if required or not. If so, specify default value, range and format.]

#### HTTP Connection – [Name of the connection]

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- IP address/host: [The polling IP or URL of the destination.]
- IP port: [The IP port of the destination.]
- Bus address: [If the proxy server has to be bypassed, specify *bypassproxy*.]

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

[Indicate if additional configuration of parameters is necessary in a newly created element.]

### Web Interface

[If there is a Web Interface page, include this section; otherwise, remove it.]

The web interface is only accessible when the client machine has network access to the product.

### Redundancy

[If redundancy is defined in the connector, include this section; otherwise, remove it.]

### Automation Scripts

[If any automation scripts need to be configured, indicate this in this section. Otherwise, this section can be removed.]

### Correlation rules

[If any correlation rules need to be configured, indicate this in this section. Otherwise, this section can be removed.]

### Visio Files

[If any Visio files need to be configured, indicate this in this section. Otherwise, this section can be removed.]

### Report Templates

[If any report templates need to be configured, indicate this in this section. Otherwise, this section can be removed.]

### Dashboards

[If any dashboards need to be configured, indicate this in this section. Otherwise, this section can be removed.]

## How to Use

[In this section, provide a more detailed description of how the connector functions. For more information, refer to <https://aka.dataminer.services/writing-connector-documentation>.]

## DataMiner Connectivity Framework

The [x.x.x.x] range of the [connector name] connector supports the usage of DCF.

DCF can also be implemented through the DataMiner DCF user interface and through third-party DataMiner connectors (e.g., a manager).

[REMOVE IF NOT RELEVANT:] Connectivity for this connector is managed by the parent connector [connector name].

### Interfaces

[Add the subsections below if applicable.]

#### Fixed Interfaces

[Use this section for interfaces that correspond to a single parameter. Add the applicable subsections, with a bulleted list describing the interfaces. Use the "Virtual fixed interfaces" subsection for virtual interfaces configured in the connector, use "Physical fixed interfaces" for physical interfaces of the device.]

Virtual fixed interfaces:

- [Description of the interface: for what parameter is the virtual dynamic interface created and what is the interface type (in / out / inout).]

Physical fixed interfaces:

- [Description of the interface: for what parameter is the physical dynamic interface created and what is the interface type (in / out / inout).]

#### Dynamic Interfaces

[Use this section for interfaces that correspond to a table parameter. Add the applicable subsections, with a bulleted list describing the interfaces. Use the "Virtual dynamic interfaces" subsection for virtual interfaces configured in the connector, use "Physical dynamic interfaces" for physical interfaces of the device.]

Virtual dynamic interfaces:

- [Description of the interface: for what parameter is the virtual dynamic interface created and what is the interface type (in / out / inout).]

Physical dynamic interfaces:

- [Description of the interface: for what parameter is the physical dynamic interface created and what is the interface type (in / out / inout).]

### DCF Connections

#### Internal Connections

[In this section, describe all internal connections in a bulleted list. For each connection, add the properties in an indented bulleted list.]

- Between [...], an internal connection is created with the following properties:

  - [...] connection property of type [ in / out / inout /  generic] with value [...].

#### External Connections

[In this section, describe all external connections in a bulleted list. For each connection, add the properties in an indented bulleted list.]

- Between [...], an external connection is created with the following properties:

  - [...] connection property of type [ in / out / inout /  generic] with value [...].

## Notes

[In this section, you can provide additional information about the connector that does not fit in the other sections. Remove this section if it does not contain any info.]
```
