---
uid: ErrorCodeTable
---

# Error codes table

|Name|Code|Message|
|--- |--- |--- |
|SL_DM_INIT_PROBLEM|0x80040201|The DataMiner had problems during initialization.|
|SL_DM_XML_WRONG_ROOT|0x80040202|The XML file has a wrong root tag.|
|SL_DM_XML_WRONG_NODE|0x80040203|The XML file contains a wrong node.|
|SL_LOG_NOT_INITIALIZED|0x80040204|The Logging module is not initialized.|
|SL_DM_XLM_SAME_NODE_TWICE|0x80040205|The XML file contains the same node twice.|
|SL_DM_PROTOCOL_FACTORY_ALLREADY_CREATED|0x00040206|The protocol factory is already created.|
|SL_PROTOCOL_BAD_ARGUMENTS|0x80040207|The protocol contains bad arguments.|
|SL_PROTOCOL_FILE_NOT_FOUND|0x80040208|The protocol file was not found.|
|SL_UNABLE_TO_INIT_SOCKET|0x80040209|Unable to initialize the socket.|
|SL_UNABLE_TO_CREATE_SOCKET|0x8004020A|Unable to create the socket.|
|SL_UNABLE_TO_BIND_SOCKET|0x8004020B|Unable to bind to the socket.|
|SL_UNABLE_TO_LISTEN_TO_SOCKET|0x8004020C|Unable to listen to the socket.|
|SL_UNABLE_TO_ACCEPT_CLIENT_TO_SOCKET|0x8004020D|Unable to accept the client to the socket.|
|SL_UNABLE_TO_INIT_IO_MODEL_TO_SOCKET|0x8004020E|Unable to initialize IO model to the socket.|
|SL_UNABLE_TO_CREATE_EVENT|0x8004020F|Unable to create an event.|
|SL_UNABLE_TO_EVENT_SELECT|0x80040210|Unable to select an event.|
|SL_UNABLE_TO_OBTAIN_ADAPTER_INFO|0x80040211|Unable to obtain the adapter info.|
|SL_UNABLE_TO_OBTAIN_IPNETTABLE_INFO|0x80040212|Unable to obtain the IP network table.|
|SL_NO_INDEX_FOR_ADDING_IP_ADDRESS|0x80040213|No index to add the IP address.|
|SL_FAILED_ADDING_IP_ADDRESS|0x80040214|Unable to add the IP address.|
|SL_ELEMENT_FILE_NOT_FOUND|0x80040215|The file “Element.xml” was not found.|
|SL_XML_NOT_INITIALIZED|0x80040216|The XML module is not initialized.|
|SL_LOAD_XML_FAILED|0x80040217|Unable to load the XML file.|
|SL_NO_VALID_PROTOCOL_FOR_ELEMENT|0x80040218|No valid protocol was found for the element.|
|SL_ERROR_ADDING_ELEMENT_TO_PROTOCOL|0x80040219|An error occurred while adding the element to the protocol.|
|SL_ERROR_ADDING_ELEMENT_TO_PORT|0x8004021A|An error occurred while adding the element to the port.|
|SL_NO_VALID_PORT_FOR_ELEMENT|0x8004021B|No valid port specified for this element.|
|SL_XML_ALLREADY_INITIALIZED|0x8004021C|The XML module is already initialized.|
|SL_DM_ELEMENT_FACTORY_ALLREADY_CREATED|0x0004021D|The element factory is already created.|
|SL_ELEMENT_NOT_INITIALIZED|0x8004021E|The Element module is not initialized.|
|SL_NEW_VALUE|0x0004021F|New value.|
|SL_DM_PORT_FACTORY_ALLREADY_CREATED|0x00040220|The port factory is already created.|
|SL_INVALID_DATA|0x80040221|Invalid data.|
|SL_INVALID_DATA_FOR_PARAMETER|0x80040222|Invalid data for the parameter.|
|SL_S_CONNECTFAILED|0x80040223|The database connect failed.|
|SL_S_ODBCLOADFAILED|0x80040224|The ODBC load failed.|
|SL_S_ODBCNOTCONFORMANT|0x80040225|The ODBC is not conformant.|
|SL_S_GENERALDBFAILURE|0x80040226|General database failure.|
|SL_S_QUERY_COULD_NOT_BE_EXECUTED|0x80040227|The query could not be executed.|
|SL_S_DATABASE_ISNOT_OPENED_YET|0x80040228|The database is not opened yet.|
|SL_S_CANCELLED|0x80040229|The database operation is cancelled.|
|SL_S_TABLECREATIONSUCCEEDED|0x0004022A|The table is successfully created.|
|SL_S_TABLECREATIONFAILED|0x8004022B|The table could not be created.|
|SL_COULD_NOT_DETERMINE_RESPONSE_LENGTH|0x8004022C|The response length could not be determined.|
|SL_FAILED|0x8004022D|Failed.|
|SL_FAILEDTOCREATEFILE|0x8004022E|Unable to create the file.|
|SL_FAILEDFILEINUSE|0x8004022F|The operation failed because the file is in use.|
|SL_FAILED_TOO_MANY_FILES_COPIED_ FOR_THE_MOMENT|0x80040230|The operation failed because too many files are being copied now (please try again later).|
|SL_FAILED_CRC|0x80040231|The CRC check failed.|
|SL_FAILED_WRITE|0x80040232|Unable to write the data.|
|SL_INVALID_SIZE_FOR_INTERPRETE_AS_DOUBLE|0x80040233|Invalid size for interprete type “double”.|
|SL_INVALID_SIZE_FOR_INTERPRETE_AS_SIGNED_NUMBER|0x80040234|Invalid size for interprete type “signed number”.|
|SL_ALLOCATION_PROBLEM|0x80040235|An allocation problem occurred.|
|SL_PROTOCOL_NAME_NOT_CORRECT|0x80040236|The name of the protocol is not correct.|
|SL_PROTOCOL_VERSION_NOT_CORRECT|0x80040237|The version of the protocol is not correct.|
|SL_PROTOCOL_TYPE_NOT_CORRECT|0x80040238|The type of the protocol is not correct.|
|SL_FAILED_NOT_FOUND|0x80040239|The object or file was not found.|
|SL_SETPOSNAV|0x0004023A|SETPOSNAV|
|SL_SETVISNAV|0x0004023B|SETVISNAV|
|SL_WRITE_COMM_BLOCK_FAILED|0x8004023C|The write comm block failed.|
|SL_CREATE_SEMAPHORE_FAILED|0x8004023D|Creating a semaphore failed.|
|SL_SET_COMM_MASK_FAILED|0x8004023E|Setting the comm mask failed.|
|SL_SETUP_COMM_FAILED|0x8004023F|The comm setup failed.|
|SL_PURGE_COMM_FAILED|0x80040240|The comm purge failed.|
|SL_SET_COMM_TIMEOUTS_FAILED|0x80040241|Setting the comm timeouts failed.|
|SL_BEGIN_READ_THREAD_FAILED|0x80040242|Starting the read thread failed.|
|SL_SET_COMM_STATE_FAILED|0x80040243|Setting the comm state failed.|
|SL_OUT_OF_BOUNDS|0x80040244|Out of bounds.|
|SL_NEARLY_IMPOSSIBLE_ERROR|0x80040245|Exceptional error.|
|SL_SMART_SERIAL_WITH_DIFFERENT_SETTINGS|0x80040246|Smart serial with different settings.|
|SL_IN_USE_BY_SMART_SERIAL|0x80040247|Port is in use by smart serial.|
|SL_SMART_SERIAL_NOT_INITIALIZED|0x80040248|The smart serial is not initialized.|
|SL_IN_USE_BY_SERIAL|0x80040249|Port is in use by serial.|
|SL_PARAMETER_CHANGED|0x0004024A|The parameter changed.|
|SL_ADDRESS_NOT_YET_CREATED|0x0004024B|The address is not created yet.|
|SL_NO_SUCH_ELEMENT|0x8004024C|The element is unknown.|
|SL_UNABLE_TO_LOAD_FILE|0x0004024D|File is already loaded.|
|SL_ALLREADY_LOADED|0x0004024E|File is already loaded.|
|SL_UNSUCCESSFULL_LOOKUP|0x8004024F|Unsuccessful lookup.|
|SL_UNSUCCESSFULL_REMOVE|0x80040250|Unsuccessful remove.|
|SL_NO_ASSOC_WITH_COOKIE|0x80040251|The XML file is not found.|
|SL_XML_FILE_NOT_LOADED|0x80040252|The XML file is not loaded.|
|SL_XML_TAG_NOT_FOUND|0x80040253|The XML tag is not found.|
|SL_UNKNOWN_QUERY|0x80040254|Unknown query.|
|SL_INVALID_PARAMETER|0x80040255|Invalid parameter.|
|SL_XML_INVALID_NUMBER_OF_TAGS|0x80040256|The XML contains an invalid number of tags.|
|SL_END_OF_RECORDSET|0x00040257|End of recordset.|
|SL_NO_SUCH_FILE|0x00040258|No such file.|
|SL_RT_DISPLAY_RECONNECTED|0x00040259|The data display is reconnected.|
|SL_ALARM_DISPLAY_RECONNECTED|0x0004025A|The alarm display is reconnected.|
|SL_DATAMINER_HAS_NO_ID|0x8004025B|The DataMiner has no ID.|
|SL_ELEMENT_HAS_NO_ID|0x8004025C|The element has no ID.|
|SL_SERIAL_SERVER_NOT_INITIALIZED|0x8004025D|The serial server is not initialized.|
|SL_INVALID_PORT|0x8004025E|Invalid port.|
|SL_PORT_NOT_CLOSED_YET|0x8004025F|The port is not closed yet.|
|SL_ESCAPE_COMM_FAILED|0x80040260|The comm escaped failed.|
|SL_CREATE_OVERLAPPED_FAILED|0x80040261|The overlapped creation failed.|
|SL_TIMEOUT|0x00040262|Timeout.|
|SL_GET_COMM_STATE_FAILED|0x80040263|Unable to get the comm state.|
|SL_NO_PROTOCOLS_TO_LOAD|0x00040264|There are no protocols to load.|
|SL_NO_ELEMENTS_TO_LOAD|0x00040265|There are no elements to load.|
|SL_ELEMENT_ID_NOT_UNIQUE|0x80040266|The ID of the element is not unique.|
|SL_DOUBLE_PARAMETER_NUMBER|0x80040267|A parameter ID is not unique.|
|SL_NOT_REGISTERED_IN_LOCATOR|0x80040268|The DataMiner is not registered in the Locator module.|
|SL_S_DATABASEENGINE_IS_BUSY|0x80040269|The database engine is busy.|
|SL_LOOKUPACCOUNT_FAILED|0x8004026A|The account is not found.|
|SL_UNABLE_TO_GET_TOKEN_INFO|0x8004026B|Unable to get the token info.|
|SL_NOPROCESSTOKEN|0x8004026C|No process token found.|
|SL_NOPRIVILEGES|0x8004026D|There are no privileges.|
|SL_NOT_EVERYTHING_RECEIVED_YET|0x0004026E||
|SL_INVALID_CRC|0x8004026F|Invalid CRC.|
|SL_INVALID_SEND_DATA|0x80040270|Invalid data to send.|
|SL_UNKNOWN_CLIENT_TYPE|0x80040271|Unknown client type.|
|SL_NET_GET_JOIN_INFORMATION_FAILED|0x80040272|Getting the net join information failed.|
|SL_NET_GET_WKSTA_INFORMATION_FAILED|0x80040273|Getting the WKSTA information failed.|
|SL_ELEMENT_NAME_INVALID|0x80040274|The element name is invalid.|
|SL_NET_GET_DC_FAILED|0x80040275|Getting the domain controller failed.|
|SL_INVALID_INFO_FOR_THIS_USER|0x80040276|This user contains invalid information.|
|SL_NO_KNOWN_MEMBER_FOR_DATAMINER|0x80040277|This user is member of an unknown group.|
|SL_UNABLE_TO_OPEN_THREAD_TOKEN|0x80040278|Unable to open the thread token.|
|SL_CLIENT_NOT_YET_REGISTERED_IN_DATAMINER|0x80040279|The client is not registered yet.|
|SL_ELEMENT_NOT_KNOWN|0x8004027A|The element is not known. (Could be busy starting up.)|
|SL_UNKNOWN_CLIENT|0x8004028A|The client is unknown.|
|SL_INVALID_REPLACE_DATA|0x8004028B|Invalid data to replace.|
|SL_INVALID_TEMPLATE|0x8004028C|The template is invalid.|
|SL_DB_INACTIVE|0x0004028D|The database is inactive.|
|SL_CLIENT_NOT_ALLOWED_ON_ELEMENT|0x8004028E|The client is not allowed on this element.|
|SL_ELEMENT_ID_INCORRECT|0x8004028F|The element ID is not correct.|
|SL_NO_SUCH_LINK|0x80040290|No such link.|
|SL_MAC_ADDRESS_NOT_LICENSED|0x80040291|The MAC address is not licensed.|
|SL_S_OPENODBCTHREADCREATIONFAILED|0x80040292|Unable to create the thread to open ODBC.|
|SL_S_ODBCTIMEOUT|0x80040293|ODBC timeout.|
|SL_PRIMARY_IP_NOT_AVAILABLE|0x80040294|The primary IP address is not available.|
|SL_LOCATOR_NOT_CREATED|0x80040295|The Locator module is not created.|
|SL_TELEPHONE_NUMBER_NOT_ALLOWED|0x80040296|The telephone number is not allowed.|
|SL_INVALID_LENGTH|0x80040297|Invalid length.|
|SL_VALUE_OUT_OF_RANGE|0x00040298|The value is out of range.|
|SL_UNABLE_TO_CREATE_BKS_FILE|0x00040299|Unable to create the backup file.|
|SL_UNABLE_TO_CREATE_BAT_FILE|0x0004029A|Unable to create the batch file.|
|SL_PARAMETER_RESPONSE_NOT_FOUND|0x0004029B|The parameter response is not found.|
|SL_FILE_NOT_FOUND|0x8004029C|The file is not found.|
|SL_ALARM_UNAVAILABLE|0x8004029D|Alarm is unavailable.|
|SL_UNABLE_TO_RECYLE|0x8004029E|Unable to recycle.|
|SL_GSM_NOT_READY|0x8004029F|The mobile phone is not ready.|
|SL_MOBILE_GATEWAY_NOT_ACTIVE|0x800402A0|The Mobile Gateway is not active.|
|SL_MOBILE_GATEWAY_NOT_AVAILABLE_ON_THIS_DMA|0x800402A1|The Mobile Gateway is not available on this DataMiner Agent.|
|SL_NO_SUCH_TASK|0x800402A2|There is no such task.|
|SL_NO_SUCH_ACTION|0x800402A3|There is no such action.|
|SL_ACTION_NOT_PERFORMED|0x800402A4|The action is not performed.|
|SL_COMMAND_EXIST|0x800402A5|The command exists.|
|SL_UNKNOWN_COMMAND|0x800402A6|Unknown command.|
|SL_NO_RESULT|0x000402A7|No result.|
|SL_TO_MANY_BITS|0x000402A8|Too many bits.|
|SL_BRAIN_NOT_INITED|0x800402A9|The Correlation module is not initialized.|
|SL_SCHEDULER_NOT_INITED|0x800402AA|The Scheduler module is not initialized.|
|SL_PARAM_TO_LONG_FOR_RESPONSE|0x800402AB|The parameter is too long for the response.|
|SL_STANDARD_QUERY_NOT_FOUND|0x800402AC|The standard query is not found.|
|SL_CLIENT_NOT_NOTIFIED|0x000402AD|The client is not notified.|
|SL_MORE_ALARMS_AVAILABLE|0x000402AE|There are more alarms available.|
|SL_SCRIPT_STARTED|0x000402AF|The script has been queued for execution.|
|SL_SCRIPT_SUCCESS|0x000402B0|The script has successfully executed.|
|SL_SCRIPT_FAILURE|0x800402B1|The script failed to execute.|
|SL_ALREADY_RUNNING|0x800402B2|Already running.|
|SL_ELEMENT_NOT_ACTIVE|0x800402B3|The element is not active.|
|SL_TABLE_REPAIRED|0x000402B4|The table is repaired.|
|SL_ELEMENT_DATA_FILE_INCORRECT|0x800402B5|The protocol information in the elementdata file is incorrect.|
|SL_AUTOMATION_NOT_INITED|0x800402B6|The Automation module is not initialized.|
|SL_SYNCHRONIZING|0x800402B7|This DataMiner Agent is currently synchronizing.|
|SL_REMOTE_COMM_FAILED|0x800402B8|Could not communicate with remote DataMiner.|
|SL_UPDATE_IN_PROGRESS|0x800402B9|Cannot accept update at this time. Another update is currently being processed.|
|SL_ASP_NOT_INITIALIZED|0x800402BA|DMS Reporter is not initialized yet, or is currently updating its data.|
|SL_ASP_NO_DATA|0x000402BB|No data is available.|
|SL_SCRIPT_ELEMENTS_UNAVAILABLE|0x800402BC|One or more of the elements or dataminers used by the script are not available.|
|SL_BRAIN_NOSUCHRULE|0x800402BD|No such correlation rule exists.|
|SL_BRAIN_NOSUCHTRIGGER|0x800402BE|No such correlation trigger exists.|
|SL_BRAIN_NOSUCHACTION|0x800402BF|No such correlation action exists.|
|SL_SYNC_FAILED|0x800402C0|Synchronization failed.|
|SL_SCHEDULER_NOSUCHTASK|0x800402C1|No such scheduled task exists.|
|SL_SCHEDULER_TASKFINISHED|0x800402C2|Cannot execute already finished task.|
|SL_SCHEDULER_FINISHFAILED|0x800402C3|Failed to finish scheduled task.|
|SL_SCHEDULER_FAILED_INCREACE_EXECOUNT|0x800402C4|Increasing the execute count of a scheduled task failed.|
|SL_SCHEDULER_FAILED_ACTIONS|0x800402C5|One or more of the task actions failed.|
|SL_UPDATE_IGNORED|0x800402C6|Update ignored. Newer data is available.|
|SL_ASP_TRY_AGAIN|0x800402C7|Try again later.|
|SL_SPECTRUM_NO_SUCH_PRESET|0x800402C8|Preset does not exist.|
|SL_SPECTRUM_BAD_PRESET_VERSION|0x800402C9|The version in which the preset was saved is not supported.|
|SL_SPECTRUM_BAD_PROTOCOL|0x800402CA|An error occurred while loading the spectrum analyzer protocol information. Please verify that the protocol is really a spectrum analyzer protocol.|
|SL_BAD_XML|0x800402CB|Received non-wellformed XML data.|
|SL_NOT_ALLOWED|0x800402CC|You do not have permission to perform this action.|
|SL_NO_CONNECTION|0x800402CD|There is no connection available with this DataMiner.|
|SL_SERVICE_INFO|0x400402CE||
|SL_SERVICE_WARNING|0x800402CF||
|SL_SERVICE_ERROR|0xC00402D0||
|SL_AGENT_STARTING|0x800402D1|The DataMiner Agent is starting.|
|SL_REPORT_INVALID|0x800402D2|Cannot create an email report because either the template does not exist, or because there are no valid email destination addresses specified.|
|SL_REPORT_FAILED|0x800402D3|There was an error while trying to generate the report.|
|SL_MAIL_NODESTINATION|0x800402D4|No valid destination address was specified for email.|
|SL_MAIL_FAILED|0x800402D5|Failed to send email.|
|SL_SCHEDULER_DISABLED|0x800402D6|Cannot execute disabled task.|
|SL_SPECTRUM_PRESET_IN_USE|0x800402D7|Cannot delete this preset, since it is in use by one or more scripts.|
|SL_SPECTRUM_RECORDING_NOT_IDLE|0x800402D8|Recording or replay is currently in progress.|
|SL_SPECTRUM_SAVEID_EMPTY|0x800402D9|No name was specified.|
|SL_EXCEPTION|0x800402DA|An exception has occurred while executing the requested action.|
|SL_SPECTRUM_BAD_REC_VERSION|0x800402DB|The version in which the recording was saved is not supported.|
|SL_UNABLE_TO_SAVE_FILE|0x800402DC|Unable to save the file.|
|SL_ZIP_ERROR|0x800402DD|An error occurred while zipping/unzipping.|
|SL_FILE_ERROR|0x800402DE|An error occurred while saving/loading a file.|
|SL_MEMORY_ERROR|0x800402DF|A memory error occurred. It is possible that the system is running out of free memory.|
|SL_ELEMENT_INACTIVE|0x800402E0|Cannot perform this action. The element is currently paused.|
|SL_SCHEDULER_FAIL_ADDMSTASK|0x800402E1|The scheduled task was added, but job creation (in MS Task Scheduler) failed. The task will not be able to execute.|
|SL_SCHEDULER_FAIL_INVALID_DATETIME|0x800402E2|The scheduled task could not be added. One of the date/time values is invalid.|
|SL_SCHEDULER_FAIL_SETACCOUNT|0x800402E3|Failed to set account info for scheduled task. The task might not be able to execute.|
|SL_VERSION_INCOMPATIBILITY|0x800402E4|Cannot complete the requested action because of a version incompatibility.|
|SL_S_IGNORED_NOT_INITIALIZED|0x000402E5|The call was ignored because the module has not been initialized.|
|SL_SPECTRUM_INVALID_SETTINGS|0x800402E6|Current spectrum analyzer settings are invalid.|
|SL_AGENT_NOT_RUNNING|0x800402E7|The DataMiner Agent is not running.|
|SL_NO_ELEMENTS_SPECIFIED|0x800402E8|No elements were specified.|
|SL_AGENT_NOT_IN_CLUSTER|0x800402E9|The DataMiner Agent is not in any cluster.|
|SL_AUTO_DETECT_FAILED|0x800402EA|Automatically detecting settings failed.|
|SL_NO_SUCH_REMOTE_CONNECTION|0x800402EB|The client information has not yet been forwarded on the remote DataMiner Agent.|
|SLNET_CONNECTION_INVALID|0x800402EC|The connection does not exist, or has become invalid.|
|SLNET_CONNECTION_INVALID_REMOTE|0x800402ED|Your direct connection is still valid, but a connection further down the connection path has become invalid.|
|SL_SNMPAGENT_NOT_INITIALIZED|0x800402EE|The Skyline SNMP Agent has not yet been initialized.|
|SL_PARTIAL_FAILURE|0x800402EF|The operation partially failed.|
|SL_SWITCHING|0x800402F0|This DataMiner Agent is currently switching.|
|SL_REDUNDANCY_TRYDELETE_OPERATION|0x800402F1|It is not possible to delete primaries that have been taken over or backups that are operational.|
|SL_NO_DATA|0x800402F2|No data.|
|SL_UPLOAD_REPORT_FAILED|0x800402F3|Uploading the report to the remote location failed.|
|SL_AUTOMATION_REQUIRE_INTERACTION|0x800402F4|This script can only execute in interactive mode.|
|SL_AUTOMATION_NOT_INTERACTIVE|0x800402F5|Interactive UI can only be used in interactive mode.|
|SL_AUTOMATION_ABORTED|0x800402F6|The script has been aborted.|
|SL_ADMIN_NEEDS_EXPLICIT_LOGON|0x800402F7|To log in as Administrator, please log on explicitly.|
|SL_WINDOWS_AUTH_FAILED|0x800402F8|Windows Authentication Failed.|
|SL_AGENT_OFFLINE|0x800402F9|Agent is offline.|
|SL_INVALID_TICKET|0x800402FA|The authentication ticket is invalid or expired.|
|SL_TOO_MANY_AUTH_ATTEMPTS|0x800402FB|Too many connection attempts from your client. Try again later.|
|SL_INTERNAL_AUTH_FAIL|0x800402FC|Internal error on authentication.|
|SL_AUTH_SERVER_TOO_BUSY|0x800402FD|Authentication not currently possible. Too many authentications in progress.|
|SL_CONNECTION_NO_LONGER_EXISTS|0x800402FE|Connection no longer exists.|
|SL_DMA_AUTH_FAILED|0x80040300|DataMiner Authentication Failed. Check username/password or security rights.|
|SL_SYNC_AND_OFFLINE|0x80040301|Agent is Offline. And Synchronizing.|
|SL_MESSAGE_TIMEOUT|0x80040302|Timeout while contacting the DataMiner Agent. The Agent might be unreachable or stopped.|
|SL_FAILOVER_CONFIG|0x80040303|DataMiner Redundancy is being configured.|
|SL_CONN_TO_SELF|0x80040304|Attempt to connect to self. Verify the End-Points configuration on the remote agent.|
|SL_CLIENT_LOGON_FAILED|0x80040305|An issue on the client prevented logon from succeeding.|
|SL_REQ_HTTP_TCP_CHANNEL|0x80040306|An appropriate HTTP or TCP channel needs to be registered before creating a RemotingConnection object.|
|SL_WSE_RUNTIME_MISSING|0x80040307|Cannot connect using webservices. The WSE runtime is probably not installed on your system.|
|SL_INTER_DMA_DISALLOWED|0x80040308|Inter-agent connections are temporarily disallowed.|
|SL_AUTO_DETECT_SETTINGS_TIMEOUT|0x80040309|Timeout while discovering connection settings or endpoints. Usually caused by firewall settings.|
|SL_FAILOVER_DIFF_DMA_IDS|0x8004030A|DMA ID is different from Licensed DMA ID (the DMA is marked as a Failover).|
|SL_PARAMETER_CHANGED_RESEND_NEXT|0x0004030B|Value is equal, although resend to SLElement due to validity.|
|SL_AGENT_ONLINE|0x8004030C|This action can only be executed on an agent that is offline.|
|SL_FAILOVER_NOT_CONFIGURED|0x8004030D|Failover has not been configured|
|SL_ELEMENT_STARTING|0x8004030E|Element is starting up.|
|SL_CERTIFICATE_FAILURE|0x8004030F|The SSL certificate on the server cannot be trusted. It might have expired or is not valid for the given hostname.|
|SL_MG_INVALID_IP|0x80040310|The given IP address cannot be used as Mobile Gateway. For a Failover Agent, please use the virtual IP address.|
|SL_UPGRADE_IN_PROGRESS|0x80040311|A software upgrade is currently in progress.|
|SL_UNKNOWN_DESTINATION|0x80040312|Unknown destination DataMiner specified. In recent DataMiner versions, the corresponding message is "Unable to find hosting agent. The agent might still be starting up."<!-- RN 25976 -->|
|SL_PROTOCOL_NOT_LICENSED|0x80040313|This protocol is not licensed.|
|SL_AUTOMATION_DETACHED|0x80040314|User interaction was aborted by client.|
|SL_PROTOCOL_CHILD_IN_USE|0x80040315|Child protocol is used by another parent protocol.|
|SL_PROTOCOL_CASSANDRA_REQUIRED|0x80040316|The uploaded protocol requires Cassandra.|
|SL_PROTOCOL_CYCLIC_INHERITANCE|0x80040317|The uploaded protocol is defined as parent of itself. First level cyclical inheritance.|
|SL_NOT_APPLICABLE|0x80040318|The switched variable is not applicable.|
|SL_UNSUPPORTED_QUERY|0x80040319|The query is not supported.|
|SL_WINDOWS_PASSWORD_EXPIRED|0x80040320|The Windows password has expired for this user.|
|SL_CREDENTIAL_NAME_EXISTS|0x80040321|A credential with this name already exists.|
|SL_PROTOBUF_INIT_FAILED|0x80040322|ProtoBuf initialization failed.|
|SL_EXT_AUTH_FAILED|0x80040323|External authentication failed.|
|SL_AGENT_LEAVING_CLUSTER|0x80040324|The Agent is busy leaving the cluster.|
|SL_AGENT_JOINING_CLUSTER|0x80040325|The Agent is busy joining the cluster.|
|SL_PAGED_SESSION_CONCURRENT_LIMIT|0x80040326|Too many concurrent paged table sessions.|
|SL_PAGED_SESSION_NOT_FOUND|0x80040327|Paged table session not found.|
|SL_PAGED_SESSION_PAGE_NOT_FOUND|0x80040328|Paged table session page not found.|
|SL_SYSTEM_REQUIREMENTS_NOT_MET|0x80040329|The system does not meet the requirements for this functionality.|
