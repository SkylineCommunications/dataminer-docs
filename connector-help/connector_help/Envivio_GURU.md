---
uid: Connector_help_Envivio_GURU
---

# Envivio GURU

The Envivio GURU connector is used to detect and create services.

## About

The Envivio GURU is a virtual connector that detects services with the use of service query files and can create services.

## Installation and configuration

### Creation

This connector uses a **virtual** connection and does not need any user information.

### Configuration of input files

Before using the detection and creation of services. The following parameters need to be defined on the **Settings** page:

- **Service Queries Folder**: the path of the folder where the service query files will be defined. The default location is: *"C:\Skyline DataMiner\Documents\Envivio Guru\Service Queries"*,
- **Service Scan**: the name of the file selected in the folder path defined in the **Service Queries Folder**. This file needs to have an *".xml"* extension,
- **SubService Queries Folder**: the path of the folder where the subservice query files will be defined. All the files defined in this folder will be used. The default location is: *"C:\Skyline DataMiner\Documents\Envivio Guru\SubService Queries"*,
- **Service Contents Location**: the path of the folder where the service content files will be defined. All the files defined in this folder will be used. The default location is: *"C:\Skyline DataMiner\Documents\Envivio Guru\Service Contents"*.

## Usage

### Detection page

On the detection page the user can perform a scan on the system and retrieve and modify the subservice types.

To perform a scan the user can press the **Start Scan** button. This will then use the content of the xml file defined in the **Service** **Scan** parameter on the **Settings** page. The content of this file can be modified by setting the new xml query in the **Service** **Query** **Input** parameter.

While the detection is executing the **Query** **Status** and **Query** **Duration** parameter will update continuously to indicate what is happening. Once the detection is finished the **Query** **Status** will be set to *Completed* and the result of the detection can be found in the **Output** **Query** parameter.

Next to the Service Detection there are the actions that can be performed for the Subservice Types.

The **Get** **Subservice** **Types** button will perform a search on the *Default.xml* file in the folder specified in the **Subservice** **Queries** **Folder** parameter. In this search it will detect all the available subservice types and give them back in an xml response message.

There is also the possibility to add a subservice type to the *Default.xml* file. To do so the user must place the new subservice xml message in the **Add** **Subservice** **Type** **Input** parameter and then press the **Add** **Subservice** button. There can be multiple types added at once and the xml message must always contain the root tag *"\<SubServiceQueries\>"*. If the type defined in the xml message already exists in the *Default.xml* file, then that type will be updated with the new values in the xml message.

A Subservice type can be removed out of the *Default.xml* file. To do so first select a type in the dropdown of the **Remove** **Subservice** **Type** **Input** parameter and afterwards press the **Remove** **Subservice** button.

After performing an **Add** or a **Remove** of subservices, the **Output** **Get** **Subservice** **Types** parameter will be updated with an xml message of the now available subservice types.

### Service Creation page

On the **Service** **Creation** page the user can create services, these services will be created according to an xml input message defined in the **Input** **Create** **Services** parameter.

A service will be created for each Channel and Application.

A channel service can contain multiple application services these will be the subservices of the channel service. Other than the application services the channel service will always have a default subservice.

The application services can contain multiple elements (this will depend on the connectivity of the elements). The data that will be displayed of the elements can be defined in the Service Content files. These files are located in the folder specified in the **Service** **Contents** **Location** parameter. If the protocol and version of an element added to the application service is defined in one of the files in this folder, then specific parameters will be displayed of this element. Otherwise the entire element will be displayed.

For each application service there can be an **SLA** **Element** created. To enable or disable the creation the creation of **SLAs** the user can set the **Create** **SLA** parameter to *Enable* or *Disable*. When the creation of **SLA Elements** is enabled, there will also be an **SLA** **Element** created for the default subservice of the channel service. Initially the **SLA** **Elements** have the "*Stopped*" element state, and after that all the services are created they will be activated. This to reduce the processor usage while creating services.

To start the creation of services, the user must fill in an xml message in the **Input** **Create** **Services** parameter and press the **Create** **Services** button. During the process of creating services (and **SLA** **Elements**) the **Service** **Creation** Status and **Service** **Creation** **Duration** parameter will continuously update to inform the user of what is happening. After that all the services are created the **Response** **Create** **Services** parameter will be updated with the xml response message that will be conform to the xml message that has been used to create the services, but will have some extra tags to define the Id of the **Service** (and id of the **SLA Element**) that have been created. Also the **Service** **Creation** **Status** will be updated to *"Completed"*.

### Settings page

All the parameters on this page have been discussed in the **Configuration** **of** Input **files** topic of the **Installation** **and** **Configuration** paragraph.

## Notes

### Service Query xml example:

\<ServiceQueries\>

\<ServiceQuery name="default"\>

\<Query\>

\<Where\>

\<Eq\>

\<FieldRef Name="Service Status" Type="Parameter"\>\</FieldRef\>

\<Value Type="Text"\>Active\</Value\>

\</Eq\>

\</Where\>

\<From\>

\<FieldRef Name="Service Table GURU" Type="Parameter"\>\</FieldRef\>

\</From\>

\<Fields\>

\<FieldRef Name="Service Name" Type="Parameter"\>\</FieldRef\>

\</Fields\>

\</Query\>

\</ServiceQuery\>

\</ServiceQueries\>

### Subservice Query xml example:

\<SubServiceQueries\>

\<SubServiceQuery name="Mobile"\>

\<Query\>

\<Where\>

\<And\>

\<Eq\>

\<FieldRef Name="Output Type" Type="Parameter"\>\</FieldRef\>

\<Value Type="Text"\>Mobile\</Value\>

\</Eq\>

\<Eq\>

\<FieldRef Name="Output Service Name" Type="Parameter"\>\</FieldRef\>

\<Value Type="Eval"\>#Candidate:name#\</Value\>

\</Eq\>

\</And\>

\</Where\>

\<From\>

\<FieldRef Name="Output GURU" Type="Parameter"\>\</FieldRef\>

\</From\>

\<Fields\>

\<FieldRef Name="Output ID" Type="Parameter"\>\</FieldRef\>

\</Fields\>

\</Query\>

\</SubServiceQuery\>

\</SubServiceQueries\>

### Service Content xml example:

\<ServiceContents\>

\<ServiceContent protocol="Envivio Dummy Service Table" version="Production" Type="Specific"\>

\<Query\>

\<Where\>

\<Eq\>

\<FieldRef Name="" Type="Filter"\>\</FieldRef\>

\<Value Type="Eval"\>Service=#Candidate.name#,Output=#Output Table:Output Id#\</Value\>

\</Eq\>

\</Where\>

\<From\>

\<FieldRef Name="Alarm Table" Type="Parameter"\>\</FieldRef\>

\</From\>

\<Fields\>

\<FieldRef Name="Alarm Severity" Type="Parameter"\>\</FieldRef\>

\</Fields\>

\</Query\>

\</ServiceContent\>

\<ServiceContent protocol="Envivio Dummy Service Table" version="Production" Type="Default"\>

\<Query\>

\<Fields\>

\<FieldRef Name="Element OK" Type="Parameter"\>\</FieldRef\>

\</Fields\>

\</Query\>

\</ServiceContent\>

\</ServiceContents\>
