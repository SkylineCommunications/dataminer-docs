---
uid: Connector_help_Skyline_Job_Manager
---

# Skyline Job Manager

This connector exposes a REST API that can be used to manage jobs and distribute them to operational domains (DataMiner SRM applications).

## About

### Version Info

| **Range**            | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      | No                  | Yes                     |
| 1.0.2.x              | Based on the 1.0.0.12 version. Breaking change in the API to support ISO8601 DateTime format (see the swagger file for details).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      | No                  | Yes                     |
| 2.0.0.x              | This range is intended to be used as an intermediary between the DataMiner Jobs app and the SRM Booking module.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       | No                  | Yes                     |
| 3.0.0.x \[SLC Main\] | This range is intended to be used as an intermediary between the DataMiner Jobs app and the SRM Booking module. It allows the user to configure which job fields are shown in the table. Information templates can be used to give the columns a name that reflects the job fields they contain. This range also allows operators to modify job fields from the connector interface. It supports immediate processing of jobs as well as bulk operations (Subscription Waiting Time) upon job changes due to subscription events. The triggering of the script can be configured on the Script Config subpage of the Configurations page. Note: Though the connector is mainly intended for use with DataMiner SRM, other use cases are also supported in this range. | No                  | Yes                     |

### About the 1.0.0.x range

A DataMiner job is a domain-specific description to set up SRM services. DataMiner Domain Orchestrators will be able to convert a DataMiner job into one or multiple DataMiner bookings. Whereas a job is an administrative description of a service that needs to be set up, a DataMiner booking is a detailed definition of the service, the configuration profiles and parameters, the exact resources to be used, the detailed schedule, etc.

The purpose of this connector is to manage and store a collection of jobs. Jobs can be ingested via a REST API that is hosted by a Job Manager element. When possible, jobs are distributed to one or multiple network domains (DataMiner Virtual Platforms), which then convert the jobs into full service bookings. Typically, Automation scripts are used to perform the complex operation of converting a job into a booking.

The following methods are currently supported by the API:

- /login

- GET: Authenticates the user and retrieves an access token that can be used with the other API methods. The user must have write access to the Job Manager element.

- /job

- GET: Retrieves a list of all jobs (only the summary of each job is returned).
  - POST: Creates a new job. A booking will automatically be created for each virtual platform in the new job.
  - PUT: Updates an existing job. Related bookings will be replaced by new instances.

- /job/{requesterID}/{jobID}

- GET: Retrieves all details of the specified job.
  - DELETE: Deletes the specified job. Related bookings will also be deleted.

Access tokens are used to authenticate a user on the service. In order to obtain such an access token, the /login API method must be used, with a valid DataMiner username and password as arguments. The specified user needs to have write access to the Job Manager element.

When the login is successful, an access token is returned, which should be used in all other API calls. The access token expires one hour after the last API call.

A Swagger ([https://swagger.io](https://swagger.io/)) YAML file is available with a more detailed description of the API (i.e. the exact JSON-XML messages that are expected). This file can also be used to automatically create a client that can communicate with the API.

### About the 2.0.0.x range

This range, together with the **SRM_ConvertToBooking** script, is intended to be used as an intermediary between the DataMiner Jobs app and the SRM Booking module.
The objective is to make a generic workflow that will be able to parse and convert the provided information into a booking, either through manual input from a user or by interfacing the DataMiner Jobs app API with an internal customer platform.

### About the 3.0.0.x range

This range was built to allow fully customizable presentation of data. It requires the development of custom solutions for the creation of bookings.

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## How to use (3.0.0.x range only)

The **Skyline Job Manager** connector is used to parse **generic booking info** provided by a job.

The connector can be configured to display certain job fields. A job field can be displayed in three ways: as a read-only string, a modifiable string, or a drop-down box. The **Jobs** **table** contains 20 generic columns for each display option. The field displayed in each column can be configured in the **Configuration** **table**. **Information templates** can be used to replace the generic column names of the Jobs table and to hide unused columns.

Via the right-click menu of the Jobs table, you can **convert a job into a booking**. This action will launch the **Automation script** defined on the **Script Config** subpage of the **Configurations** page.
Note that if the **Default Behavior** is set to *Enabled*, the script needs to be able to accept the following input parameters:

- JobGuid (string): GUID of the selected job.
- JobManager (string): Element name of the Job Manager (If the **Skyline Job Manager Element Name** is set to *Included*).

Otherwise, the Automation script input parameters will be defined according to the data configured in the Input Script Parameters table.

Note that the Automation script with the name defined in the Booking Script parameter will be triggered according to the configuration defined on the Script Config subpage. If **Run Booking Script on New Job** is set to *Enabled*, the script will be launched whenever there is a change to a job in the Jobs Application.

## How to use (2.0.0.x range only)

The **Skyline Job Manager** connector is used to parse **generic booking info**, provided by a job.

Since the job parameters available in the Jobs app are customizable, first the **Configuration Table** must be configured. This table indicates from which Jobs app section and field names the connector should retrieve the values.

When the **Administrative State** of a job is changed to *Approved*, the connector will try to launch the **SRM_ConvertJobToBooking** script. This script parses custom booking info and launches the execution of a "silent booking" via a custom script. Given that the custom info required to perform the booking depends on the type of booking, the script needs to be changed according to what is indicated in the Note section at the top of the script. This includes the definition of the parameters to be parsed and the mapping of the silent booking to be launched, depending on the type of booking.
Note that while by default the connector will try to launch the SRM_ConvertJobToBooking script, at the top of the **Configurations** page, you can configure it to launch a **different custom script**.

As a final step, the custom silent booking script that has been launched will try to create bookings according to the requirements. This script **must report back the** **"Booking Status"** information to the Job Manager connector, as the creation of new bookings is conditionally triggered by the state of the "Administrative State" and "Booking Status" values.

## How to use (1.0.0.x range only)

### Configuration of the virtual platforms (1.0.0.x range only)

Virtual platforms must be configured on the Configuration page before you start using a newly created element, as otherwise the jobs will not be automatically translated into bookings.

Use the context menu to add a new row to the table, representing a virtual platform. You will need to fill in the name of the virtual platform in a pop-up window.

After you have added the row, use the drop-down controls to specify the Booking Manager element and the create/delete booking scripts. Only valid elements (with protocol name "Skyline Booking Manager") and valid scripts (with correct input parameters - see notes section below) are available.

This connector uses a virtual connection and does not require any input during element creation.

### General page

This page displays the current status of the API service, together with the current endpoint URI on which the service can be reached.

### Jobs page

This page contains tables that are used to store the data of each job, along with the detailed information for each service that belongs to the job.

Use the page button to open a pop-up page with the properties for each job, service detail, and job profile.

### Configuration page

On this page, the **Virtual Platforms Table** provides a mapping between the virtual platform (defined in the job) and Automation scripts. Two scripts must be configured: one to create a booking and one to remove bookings. The Booking Manager element on which the booking should be registered must also be specified here for each VP.

The **Create Booking Script** will be executed for each virtual platform in a job that is added through the API. After a job has been deleted via the API, the **Delete Booking Script** will be executed.

Additionally, the address and port of the web service endpoint can be configured here. After the address or port have been changed, the web service will restart. Make sure that incoming traffic is allowed in the (Windows) firewall for the configured port.

### API Help page

This page displays the default WCF help page that describes the available methods and expected input/output of the REST web service.

## Notes

The Automation scripts that create and delete bookings for a specific domain must have the following input parameters:

Create booking:

- **jobManager**: DMA/element ID or element name of the Job Manager element that initiated the execution of the script.
- **bookingManager**: DMA/element ID or element name of the Booking Manager element on which the new booking should be registered.
- **newBookingRequestData**: XML document with all the data needed to create the new booking.

Delete booking:

- **jobManager**: DMA/element ID or element name of the Job Manager element that initiated the execution of the script.
- **bookingManager**: DMA/element ID or element name of the Booking Manager element that contains the booking that must be deleted.
- **deleteBookingRequestData**: XML document with the data needed to remove the booking (i.e. booking ID).
