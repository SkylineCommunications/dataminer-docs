---
uid: Connector_help_Telenet_Ticket_Gateway
---

# Telenet Ticket Gateway

The Telenet Ticket Gateway connector is part of the Telenet SAM Ticketing project. The connector communicates with OSB, a custom web service of Telenet.

## About

This connector will receive commands that need to be sent to a custom web service of Telenet, i.e. **OSB**. These commands will **Create**, **Update**, **Close**, and **Search** **Tickets** or **Edit Ninas Counters** in a custom database of Telenet. The tickets are called **'MO'** or **'PLM'** depending on the request.

The commands will receive a response from OSB: *ACK*/*NACK* or *search* *result.* Create, Update, and Close commands will also receive an *Async* response. This is received by a custom SAMSERVICE web service created by Skyline to receive this response and put it in the correct cell in the communication table, which is a list of all requests sent to OSB. Each error returned from OSB will be logged in an Offload file, though this can be disabled if necessary*.*

Each Create, Update, and Close command can be offloaded to the **RFC service** of Telenet. This will generate an **Update MO** or **Update** **PLM** request. As this needs to be sent to a different service, this is done via a second connection.

When a request receives a response, it will be returned to the element that requested the command. This *DMA*/*Element*/*paramID* is found in the request. A retry system is built in to execute a failed request 3 times after the original request.

As Create, Update, Close, and Edit NinasCounter commands have a higher priority than Search requests, they are handled separately. The Search requests are kept in a buffer table and will be executed at a configurable rate.

For each Create, Update, or Close command, the Telenet RFC service (web service created by Telenet) needs to receive an Update, either for PLM or MO. But as mentioned above, the Create, Update, and Close commands have a higher priority than this RFCUpdate, because they affect tickets. The RFCUpdate has a built-in retry system configurable in Element Display.

Debug possibility:

- Ninas Counters can be received and edited.
- A ticket search can be executed.

Master Data:

- This data can be configured by the customer, and in the future it will be used as possible values in Scripts generating the requests.
- Displayed in tree structure.

The new feature "**makeCommandByProtocol**" will make sure that data in a "to be executed" command (on DataMiner Stack) is correct and not overwritten by the last changed data. This is necessary for the RFC updates, because multiple commands can stay on the stack when OSB commands get execute priorities.

To reduce the logging in the element log, the connector will generate an extended log file each hour. This is done via a buffer table, from which the data is offloaded in a file every half hour.

MO CleanUp:
When a **CleanUp** request is received from the **MailProc**, the Gateway will execute a series of requests in order to update/close the requested case with the provided MasterData from the MailProc. All this data can be found in the CleanUp request. The following is needed to fulfill the **MO** **Cleanup**:

1. Search the Case, in order to retrieve the current condition / networkElement / . needed for the Update.
1. Update of the Case with provided master data.
1. Close the Case with the provided master data.
1. Update Ninas Counters if the counter itself is higher than the current open Cases.

Whenever an error occurs, it is returned to the MailProc. After finishing the MO CleanUp an *OK state* is returned to the MailProc.

## Installation and configuration

### Creation

This connector uses a **Serial** connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the connected device: fixed to *8650.*

**RFC**:

- **IP address/host**: The polling IP of the device, e.g. *at.inet.telenet.be.*
- **IP port**: The port of the connected device, e.g. *8126*.

### Configuration

- Add **Service** **info** or import CSV file and select the service. This will change the Polling IP/Port.

- Configure the **Assurance Manager** parameter.

- **Script Params**, e.g.: Generate extra logging when x cases are found within y days.

- Configure the rate at which search requests are to be executed.

- DMA/Element/Param - ID of mail processor.

- **Element** **Name** of **Topology** **Element**.

- List of all **NetworkServices**.

- Communication settings on the **OffloadConfig** pop-up page of the **Communications** page:

  - **Offload** **OSB**:

    - Path
    - File
    - Enable/Disable

  - **Offload** **RFC**:

    - RFC Uri = dynamic polling second connection
    - Enable/Disable
    - Communication Log file path
    - Retry

## Usage

### Connection Details page

This page displays the **Dynamic Polling IP** address of the RFC and the **Service** **Selection**. The Service Selection parameter can be set to one of the values displayed in the **Service Info Table**.

In the **Service** **Info** **Table**, all the different services are displayed. Services can be added in two ways:

- Fill in the service name in the **Add Service Name** parameter and then click the **Add** **Service** button.
- Enter the path to a CSV file in the **CSV** **File** parameter and click the **Import** **CSV** button.

It is possible to create a CSV file of the current **Service** **Info** **Table**, by entering a file path and name and then clicking the **Export** **CSV** button.

To delete services, place the Service Name in the **Delete Service Name** parameter and click the **Delete Service** button.

### Config page

On this page, different settings regarding the MO can be configured.

The **Assurance Manager** parameter needs to be defined in order for the **Ticket Gateway** to select the right Assurance Manager.

The Network Services Table displays the different available Network Services. To add new Network Services, click the **Add NT Service** button and fill in the different cells in the table. Alternatively, you can also do this by importing a CSV file.

To delete Network Services, set the **Delete** **Network** **Service** **Id** parameter with the value of the **NTService** **Id** **\[IDX\]** column of the row that needs to be removed and then click the **Delete** **NT** **Service** button.

### Config Master Data page

On this page, the **Master** **Data** parameters can be configured. In the future, this data will be used as possible values in Scripts generating requests.

The three pages **Master Data CaseType Overview**, **Master Data NetworkLevel Overview** and **Master Data Close Overview** each contain a tree view displaying a certain part of the Master Data.

### Communication page

On this page, two tables are displayed:

- **Communication - Response Table**: This table displays the outgoing requests to OSB and their responses,
- **RFC Communication Table**: This table displays the communication with the RFC.

To clear the two tables, click the **Clear Comm** button.

The page also contains three page buttons that each will open a pop-up page where additional data is displayed. On the **OffloadConfig** page, there are also settings that can be configured.

### Debug page

On this page, the **Ninas** **Counters** can be received and edited. The page also provides the possibility to execute Ticket Searches.

### Logging page

On this page, you can save the **Log** **Buffer** table by pressing the **Save** **Log** button.
