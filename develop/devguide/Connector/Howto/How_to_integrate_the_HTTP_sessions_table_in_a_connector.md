---
uid: How_to_integrate_the_HTTP_sessions_table_in_a_connector
---

# How to integrate the HTTP Sessions Table in a connector

The HTTP Sessions table is a tool that has been integrated in multiple recent HTTP connectors. The main purpose of this table is to show the real-time HTTP communication between DataMiner and a data source. Each row contains the information of a request and the corresponding response.

![HTTP Sessions table in DataMiner Cube](~/develop/images/HTTPsessions1-1024x444.png)

## Benefits of the HTTP Sessions table

### Benefits over Stream Viewer

The functionality of the tool is similar to that of [Stream Viewer](xref:Connecting_to_an_element_using_Stream_Viewer), but it has some benefits over that built-in DataMiner tool:

- **The link between response and request**: Stream Viewer only shows incoming data, whereas the HTTP Sessions table also shows the outgoing data. Data of a request or the request itself may contain errors, which are not visible in Stream Viewer. Also, because Stream Viewer does not show the sent requests, it is harder to link the responses to their request.

- **Request grouping**: The responses in Stream Viewer are grouped according to the group they are sent from. If different requests are sent from the same group, this makes it harder to find and link responses. The HTTP Sessions table makes it easier to find a specific request/response, because they can be sorted by timestamp, URI, etc.

- **Request duration**: The HTTP Sessions table calculates the timespan of each request, which makes it easier to determine timer periods during development. You can see how much time on average the groups in a timer need to execute their content, and adjust the timer period accordingly. However, note that the request time is logged just before the group is put on the stack, and the response time is logged just after the response is received. The timespan is therefore not completely accurate, and the real timespan will likely be smaller.

![Stream Viewer example](~/develop/images/HTTPsessions3.png)

### Data loss information

Another benefit of the HTTP Sessions table is the **extra information it provides regarding data loss** compared to the element timeout state. If an element is in timeout, this means DataMiner has not received a single response from the data source in a specific time period. Usually, this indicates that the connection to the data source is lost. However, it is possible that data loss occurs without a timeout status.

Imagine, for example, that a data source is unable to respond to certain requests but responds at least once within the timeout period. Every request initially succeeds after the element starts up, so all tables and parameters are filled in. However, at some point, something goes wrong with the data source, e.g. it is unable to handle a certain request, or it receives too many requests. Then it is possible that half of the requested data is lost while the element will still not be in timeout. Users will not notice the data loss, because all data seems to be filled in as expected. With the HTTP Sessions table, the data loss will become obvious.

![HTTP Sessions table example](~/develop/images/HTTPsessions4.png)

The table in the image above shows an example of data loss where the element does not go into timeout. For requests 46 to 61, you can see multiple responses with the status "Too Many Requests". This means the data source responded but did not send the expected data. 7 out of 16 requests have failed, which means 43.8% of the data is lost. Without the HTTP Sessions table, this data loss would go unnoticed.

The table allows developers to see which requests fail. If logging is enabled, they can then check the responses and trace back the cause of the failure to a bad request, to the behavior of the data source, or to the response.

### Benefits over Wireshark

The HTTP Sessions table makes the use of Wireshark entirely unnecessary. Both tools allow you to see the communication between DataMiner and the data source. However, if you only have access to a DMA and not to the server running it, the HTTP Sessions table will be a lot more convenient.

## How to integrate the HTTP Sessions Table

### Parameters included in the HTTP Sessions table

To make sure that the table contains valuable information about the communication between DataMiner and a data source, ideally, the parameters listed below should be included in the table.

- The **primary key** of the table: An **ID** assigned by the protocol that must be unique for every request sent. Preferably, the ID is incremented after each request, in order to maintain the chronological order when you sort on this ID.
- The **URI** of the HTTP request, which can be reduced to its unique path, without the IP address, port, etc.
- The **HTTP method** of the HTTP request, e.g. GET, PUT, POST, etc.
- The **request data**: Additional data that is usually required for a POST request. This field is left empty if no data is sent with the request.
- The **time** when the **request** is sent.
- The **response status**: The reason phrase included in the status line of the HTTP response.
- The **response data** of the HTTP response.
- The **time** when the **response** is received.
- The **timespan**: The time it takes for the data source to respond to each request, which is calculated based on the time when a request is sent and when its response is received.

### Protocol flow

An entry in this table is created by adding data twice: Once with the information about the request and once with the information about the response.

The actions below must be executed one after the other in the indicated order:

1. Logging the request data.
1. Sending the request.
1. Receiving the response.
1. Logging the response data.

### Logging of requests

A request can be triggered in a QAction. The `HandleRequest` method can be used every time a request needs to be sent. This method performs 3 tasks:

- Preparing everything for the request, for example setting parameters.
- Checking a trigger that triggers an action to put a session group on the stack. This group will send the request and handle the response.
- Logging the request in the HTTP Sessions table. The `LogRequest` method adds an entry to the table with the information for parameters 1–5 listed above.

The ideal time to log a request is just before it is sent. That is why the `LogRequest` method is the last item to be executed in the QAction, after which the group with the request will be executed.

### Logging of responses

After a response is received, it should be logged by a QAction, which is triggered by an after-group trigger on the session group. The `LogRequest` method adds the response information for the corresponding request to parameters 6–9 listed above. For that, it needs the ID of the request, so there must be a way to link a response to the corresponding request:

- If a data source has a mirror functionality in its API, an ID can be added to the requests and the data source will mirror this ID in the corresponding responses. This is the preferred way of working.
- If the API includes a unique item of the request (e.g. the URI) in the body of the responses, you can use this. However, this item has to be unique for all the requests, as otherwise it will not be possible to link certain responses to a request.
- If a data source does not support any form of linking, the linking must be done in the protocol, through the creation of different groups/sessions for each unique request.

### Additional configuration parameters

The HTTP Sessions table should be volatile and have a limited number of entries, because it is meant to be a real-time debugging tool.

The following configuration parameters should be made available:

- **HTTP Sessions State**: Enables or disables the logging of the communication in the table.
- **HTTP Sessions Max Count**: Determines the maximum number of entries in the table.

![Configuration parameters for HTTP Sessions table](~/develop/images/HTTPsessions2.png)

You can also add other configuration parameters to further customize the HTTP Session table.

### Possible additional functionality

As described above, the HTTP Sessions table is already a great tool to help notify users about data loss. However, you can add even more parameters to further enhance this functionality. For example:

- **Data Loss**: A parameter that calculates the percentage of all requests with a response containing an error code.
- **Data Loss State**: When the above parameter exceeds a certain limit (configurable or not), this parameter can indicate this with an error state.
