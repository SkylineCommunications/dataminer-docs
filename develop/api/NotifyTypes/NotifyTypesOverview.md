---
uid: NTNotifyTypesOverview
---

# NT Notify Types

> [!WARNING]
> The table below gives an overview of all the defined NT Notify types. This is part of the internal communication between DataMiner processes. Notify types for which no additional documentation is provided should therefore not be used.
> These types are shared between the SLDataMiner and SLProtocol processes, but many of them are only supported by one of the two processes. Their documentation should mention if they are to be used with a [NotifyProtocol](xref:Skyline.DataMiner.Scripting.SLProtocol.NotifyProtocol(System.Int32,System.Object,System.Object)), a [NotifyDataMiner](xref:Skyline.DataMiner.Scripting.SLProtocol.NotifyDataMiner(System.Int32,System.Object,System.Object))([Queued](xref:Skyline.DataMiner.Scripting.SLProtocol.NotifyDataMinerQueued(System.Int32,System.Object,System.Object))), or both.

|ID|Name|Description|
|--- |--- |--- |
|0|NT_UNDEF||
|1|<xref:NT_SMS>|Sends an SMS.|
|2|<xref:NT_ADD_VIEW>|Creates a new view.|
|3|<xref:NT_ADD_ELEMENT>|Adds an element to a view.|
|4|<xref:NT_DELETE_VIEW>|Deletes a view.|
|5|<xref:NT_DELETE_ELEMENT>|Removes an element from a view.|
|6|<xref:NT_EDIT_VIEW>|Renames a view.|
|7|NT_ADD_SNMP_MANAGER||
|8|NT_DELETE_SNMP_MANAGER||
|9|NT_EDIT_SNMP_MANAGER||
|10|NT_ALARM||
|11|NT_ELEMENT_STATE||
|12|NT_DB_SETTINGS||
|13|NT_TRENDING_TYPE||
|14|<xref:NT_TRENDING_ASSIGN_TEMPLATE>|Assigns a trend template to an element.|
|15|NT_TRENDING_ELEMENT||
|16|NT_TRENDING_TEMPLATE_CHANGE||
|17|NT_CREATE_SIMULATION||
|18|NT_USER_ADDTOGROUPS||
|19|NT_USER_DELFROMGROUPS||
|20|NT_GROUP_ADD||
|21|NT_GROUP_DEL||
|22|NT_GROUP_CHANGENAME||
|23|NT_GROUP_CHANGELEVEL||
|24|NT_GROUP_ADDVIEWS||
|25|NT_GROUP_DELVIEWS||
|26|NT_GROUP_RIGHTS||
|27|<xref:NT_VDX_CHANGE_VIEWS>|Sets a Visio file on a view.|
|28|NT_PING||
|29|NT_LOG_LEVELS||
|30|NT_TELNET_CLIENT||
|31|NT_CONNECTIONS||
|32|NT_FILE_CHANGED||
|33|NT_FILE_REMOVED||
|34|NT_FILE_ADDED||
|35|NT_FILE_NAME_CHANGED||
|36|NT_NOTIFY_CONNECTED_ELEMENTS||
|37|NT_DMA_ADDED||
|38|NT_DMA_REMOVED||
|39|NT_NORMALIZE||
|40|NT_DATA_DISPLAY_CLIENT||
|41|<xref:NT_SEND_DMS_FILE_CHANGE>|Notifies DataMiner that a file has changed.|
|42|NT_PROTOCOL_CHANGED||
|43|NT_ELEMENT_CHANGED||
|44|NT_SCHEDULER_STATUS||
|45|NT_STOP_DATAMINER||
|46|NT_ELEMENT_ALARM_STATE||
|47|NT_GET_SPECTRUM_INTERFACE||
|48|<xref:NT_GET_ALARM_INFO>|Gets the alarm info of the specified standalone parameter(s).|
|49|NT_CHANGE_PROTOCOL||
|50|<xref:NT_SET_PARAMETER>|Sets a parameter.|
|51|NT_WATCHDOG_SETTINGS||
|52|NT_GROUP_EDITVIEWS||
|53|NT_RUN_TASK||
|54|NT_PING_SETTINGS||
|55|<xref:NT_SET_AS_CURRENT_PROTOCOL>|Sets the specified protocol as the production version.|
|56|<xref:NT_GET_CURRENT_PROTOCOL>|Gets the version of the protocol that is set as production.|
|57|NT_ELEMENT_RECEIVE||
|58|NT_REMOTE_ELEMENT_STATE||
|59|NT_RECONNECT_CLIENT||
|60|<xref:NT_GET_DATA>|Gets the raw data of the specified item.|
|61|NT_DELETE_PROPERTY||
|62|<xref:NT_EDIT_PROPERTY>|Edits a property.|
|63|NT_CONNECTIONS_TO_REMOVE|Deprecated. No longer available from DataMiner 10.4.1/10.5.0 onwards.<!-- RN 37595 -->|
|64|NT_SET_DMSREVISION_TIME||
|65|NT_REDUNDANT_TRIGGER||
|66|NT_SET_DERIVED_ELEMENT||
|67|NT_REDUNDANCY_GROUP|Creates a redundancy group.|
|68|NT_RENEW_DESCRIPTION_XML||
|69|<xref:NT_GET_VALUE>|Gets the value of the specified parameter.|
|70|NT_ADD_DESCRIPTION_FILE|**Deprecated since DataMiner 10.3.4.**|
|71|<xref:NT_DELETE_REDUNDANCY_GROUP>|Removes a redundancy group.|
|72|NT_NOTIFY_SERVICE_STATUS||
|73|<xref:NT_GET_PARAMETER>|Gets a parameter value.|
|74|<xref:NT_DELETE_SERVICE>|Removes a service.|
|75|<xref:NT_SERVICE>|Creates or updates a service.|
|76|<xref:NT_ASSIGN_SIMULATION>|Assigns a DataMiner simulation to an element.|
|77|<xref:NT_GET_DESCRIPTION>|Gets the description of the specified parameter.|
|78|NT_IS_LOCAL_IP||
|79|NT_DONT_FORWARD_STATE||
|80|NT_DMA_ALARM_STATE||
|81|NT_GET_CLIENT_INFO||
|82|NT_RETURN_SET||
|83|NT_ADD_CLIENT||
|84|NT_SET_PARAMETER_BY_NAME||
|85|<xref:NT_GET_PARAMETER_BY_NAME>|Gets the value of the parameter with the specified name.|
|86|NT_SET_PARAMETER_BY_DATA|**Deprecated since DataMiner 10.3.4.**|
|87|<xref:NT_GET_PARAMETER_BY_DATA>|Gets the parameter value corresponding with the parameter that has the specified data stored in the ElementData.xml file. **Deprecated since DataMiner 10.3.4.**|
|88|<xref:NT_GET_ITEM_DATA>|Gets the value stored for the specified parameter in the ElementData.xml file. **Deprecated since DataMiner 10.3.4.**|
|89|<xref:NT_SET_ITEM_DATA>|Sets the values stored for the specified parameters in the ElementData.xml file. **Deprecated since DataMiner 10.3.4.**|
|90|NT_AGENT_FOUND||
|91|NT_CHANGE_ALARM_COLOR||
|92|NT_SET_KEY||
|93|NT_DMA_REMOTE_BACKUP_SETTINGS||
|94|NT_GET_XML_COOKIE|**Deprecated since DataMiner 10.3.4.**|
|95|NT_GET_DMA_DOCUMENTS||
|96|NT_GET_TASK_INFO||
|97|NT_ADD_ELEMENT_TYPES||
|98|<xref:NT_GET_AVAILABLE_FILES>||
|99|<xref:NT_ADD_FILE>|Adds a new alarm or trend template or updates an existing alarm or trend template.|
|100|NT_GET_SUBJECT_AND_COMMENT||
|101|NT_SET_SUBJECT_AND_COMMENT||
|102|NT_REMOVE_FILE||
|103|NT_REMOVE_DOCUMENT|See NT_REMOVE_DOCUMENT (103).|
|104|NT_SET_SECURITY_INFO||
|105|NT_THREAD_CHECK||
|106|<xref:NT_MAKE_ALARM>|Creates an alarm.|
|107|<xref:NT_DATAMINER_INFO>|Gets DataMiner information.|
|108|<xref:NT_GET_USER>|Retrieves a user.|
|109|NT_UPDATE_DATA||
|110|NT_SET_MAINTENANCE_INFO||
|111|NT_REGISTER_CLIENT||
|112|NT_UNREGISTER_CLIENT||
|113|NT_SUBSCRIBE_CLIENT||
|114|NT_UNSUBSCRIBE_CLIENT||
|115|<xref:NT_SET_ELEMENT_STATE>|Changes the state of an element.|
|116|<xref:NT_SET_ALARM_STATE>|Masks or unmasks an element and allows you to provide a comment on an alarm.|
|117|<xref:NT_ASSIGN_ALARM_TEMPLATE>|Assigns an alarm template to an element.|
|118|<xref:NT_CHANGE_PARENT_OF_VIEW>|Changes the parent view of a view.|
|119|NT_LOAD_REMOTE_REDUNDANCY||
|120|<xref:NT_GET_USER_INFO>|Retrieves user information.|
|121|<xref:NT_PUT_PARAMETER_INDEX>|Sets the value of a cell in a table, identified by the primary key (or row number) of the row and column position, with the specified value.|
|122|<xref:NT_GET_PARAMETER_INDEX>|Gets the value of the specified cell in the specified table.|
|123|NT_NOTIFY_DISPLAY||
|124|NT_SERVICE_TRIGGER||
|125|NT_SLNET_SETTINGS||
|126|NT_PARAMETER_FOR_SNMP_MANAGER_V1||
|127|<xref:NT_UPDATE_DESCRIPTION_XML>|Adjusts parameter settings at runtime.|
|128|<xref:NT_UPDATE_PORTS_XML>|Updates the configuration of the specified matrix.|
|129|NT_GENERATE_MINI_DUMP||
|130|NT_PASSWORD_ON_ZIP||
|131|<xref:NT_SET_DESCRIPTION>|Sets the description of the specified parameter.|
|132|NT_SET_DESCRIPTION_QUEUED||
|133|NT_GET_DISPLAY_VALUE||
|134|<xref:NT_CHECK_TRIGGER>|Triggers the trigger with the specified ID.|
|135|NT_GET_TRIGGER_STATUS||
|136|NT_DELETE_ELEMENT_DATA||
|137|NT_ANOTHER_TELNET_CLIENT||
|138|NT_GET_ACTIVE_ROOTKEYS||
|139|NT_CLEAR_CACHED_PROTOCOL||
|140|NT_ADD_MULTIPLE_ELEMENTS||
|141|NT_GET_XML_COOKIES||
|142|NT_REMOTE_CONNECTIONS||
|143|NT_SYNC_VDX_TEMPLATES||
|144|<xref:NT_GET_ELEMENT_NAME>|Gets the name of the specified element.|
|145|NT_MAX_DOCUMENT_SIZE||
|146|NT_REMOVE_FILE_CHANGE||
|147|NT_SECURITY_CHANGED||
|148|NT_REGISTER_SLA||
|149|<xref:NT_ADD_ROW>|Adds a row to a table.|
|150|NT_ASSIGN_INFORMATION_TEMPLATE||
|151|NT_GET_PROTOCOL_OF_TYPE||
|152|NT_RESET_SLNET_POINTERS||
|153|NT_GET_ENCRYPTED||
|154|<xref:NT_GET_LICENSES>|Retrieves license information.|
|155|NT_SAVE_AND_RECYCLE||
|156|<xref:NT_DELETE_ROW>|Removes a row from a table.|
|157|NT_EDIT_PROPERTY_DONT_FORWARD||
|158|NT_NEW_OBJECT||
|159|NT_GET_PARAMETER_DISPLAY_VALUE||
|160|<xref:NT_CREATE_ELEMENT>|Creates an element on the specified DMA.|
|161|<xref:NT_GET_DISPLAY_FOR_PK>|Gets the display key that corresponds with the specified primary key.|
|162|<xref:NT_GET_PK_FOR_DISPLAY>|Gets the primary key that corresponds with the specified display key.|
|163|<xref:NT_GET_KEY_POSITION>|Gets the (1-based) internal position of the row.|
|164|NT_PARAMETER_DISTRIBUTION||
|165|NT_DELETE_DISTRIBUTION_KEY||
|166|NT_ELEMENT_NAME_CHANGED||
|167|<xref:NT_SET_PARAMETER_WITH_WAIT>|Sets a parameter with wait.|
|168|<xref:NT_GET_INDEXES>|Gets the primary keys and display keys of a table.|
|169|NT_CHECK_HYPERLINKS||
|170|NT_REFRESH_HYPERLINKS||
|171|NT_DB_QUERY|Executes a MySQL statement|
|172|NT_XML_QUERY||
|173|NT_GET_INDEXES_WITH_TREND||
|174|NT_GET_INDEXES_WITH_ALARM||
|175|NT_UPDATE_SIMULATION_FILE||
|176|<xref:NT_GET_VIEWS_OF_ELEMENT>|Gets the ID(s) of the view(s) containing the element.|
|177|<xref:NT_SET_BINARY_DATA>||
|178|<xref:NT_GET_ID_OF_ELEMENTS_IN_VIEW>|Retrieves the IDs of all elements included in the view|
|179|<xref:NT_GET_VIEW_ID>|Gets the ID of the view with the specified name.|
|180|<xref:NT_GET_DOCUMENTS>|Gets an overview of the documents in the specified Documents folder.|
|181|<xref:NT_CREATE_FOLDER>|Creates a folder in the C:\ Skyline DataMiner\Documents folder.|
|182|<xref:NT_DELETE_FOLDER>|Deletes a folder in the C:\ Skyline DataMiner\Documents folder.|
|183|<xref:NT_RENAME_FOLDER>|Renames a folder.|
|184|NT_RCA_LEVEL||
|185|NT_CREATE_DYNAMIC_ELEMENT||
|186|NT_LOCK_CHANGE_NOTIFICATIONS||
|187|NT_GROUP_CHANGEFILTERS||
|188|NT_USER_SET_SCHEDULE||
|189|NT_CLEAR_DERIVED_INFO||
|190|NT_CLEAN_DB_STACK||
|191|NT_RELOAD_DB_STACK||
|192|NT_CLEAR_NORMALIZE_INFO||
|193|<xref:NT_FILL_ARRAY>|Fills the table with the provided content.|
|194|<xref:NT_FILL_ARRAY_NO_DELETE>|Adds the provided content to the specified table.|
|195|<xref:NT_ARRAY_ROW_COUNT>|Gets the number of rows in a table.|
|196|<xref:NT_GET_KEYS_FOR_INDEX>|Gets the primary keys of all rows that have the specified value for the specified column.|
|197|NT_CHANGE_PRIMARY_IP||
|198|NT_DRS_STATE||
|199|NT_GET_DRS_STATE||
|200|<xref:NT_ADD_NEW_ELEMENT>|Creates an element on the DMA executing this method call.|
|201|NT_FAILOVER_SYNC||
|202|NT_RELOAD_ELEMENT|**Deprecated since DataMiner 10.3.4.**|
|203|<xref:NT_GET_SUBVIEWS>|Gets the names and IDs of all child views of a view.|
|204|NT_SET_STATIC_IP||
|205|NT_CHANGE_SECONDARY_IP||
|206|NT_REFRESH_GENERIC_PROPERTIES||
|207|NT_GET_UTF8_STRING||
|208|NT_PARAMETER_FOR_SNMP_MANAGER_V2||
|209|NT_GENERIC_XML_UPDATE||
|210|NT_UNLOAD_SERVICE||
|211|NT_UNLOAD_REDUNDANCY||
|212|NT_UNLOAD_ELEMENT||
|213|NT_BECOME_SLAVE||
|214|NT_RG_ELEMENT_SWITCH||
|215|<xref:NT_GET_ROW>|Retrieves a row from a table.|
|216|<xref:NT_GET_REMOTE_TREND>|Gets the real-time trend data of a view table column.|
|217|NT_REQUEST_MERGE_INFO||
|218|NT_RECEIVE_MERGE_REQUEST||
|219|NT_ACK_MERGE_REQUEST||
|220|<xref:NT_FILL_ARRAY_WITH_COLUMN>|Sets or updates one or more table columns with provided values.|
|221|<xref:NT_RUN_ACTION>|Runs an action.|
|222|NT_RG_SET_MODE||
|223|NT_RG_SET_MAINTENANCE||
|224|NT_RG_SET_ELEMENTS||
|225|<xref:NT_SET_ROW>|Sets the data of the specified row to the specified values.|
|226|<xref:NT_DIAG>|Obtains additional information about a DMA or DMS.|
|227|NT_UPDATE_PORTS_XML2||
|228|NT_GET_DISTINCT_INDEXES||
|229|<xref:NT_SCHEDULE_ROW_ON_TIMER>|Allows the triggering of a specific row to be run by the multi-threaded timer outside of its normal behavior.|
|230|NT_RG_DUPLICATE_TEMPLATE||
|231|NT_ADD_EDIT_GENERIC_PROPERTY||
|232|<xref:NT_SERVICE_SET_VDX>|Sets a Visio file on a service.|
|233|NT_GET_LAST_POLL_TIME||
|234|NT_ENABLE_STORE_POLL_TIME||
|235|NT_DRS_RELOAD||
|236|NT_DRS_RECREATE_VIP||
|237|NT_PUT_PARAMETER_INDEX_WITH_LOG||
|238|<xref:NT_REBUILD_INDEX>|Rebuilds the index of the specified column.|
|239|<xref:NT_LOG_INDEX>|Writes content of the index for the specified column to the element log file.|
|240|<xref:NT_ADD_ROW_RETURN_KEY>|Adds a row to a table and returns the primary key of the created row.|
|241|NT_IS_CLIENT_APP_LICENSED||
|242|NT_RELOAD_CLIENT_APP_LIC||
|243|NT_VERIFY_CLIENT_COOKIE||
|244|NT_GET_EXPIRATION_DATE||
|245|NT_FORCE_REPLICATION||
|246|NT_LOAD_OFFLINE_ELEMENT||
|247|NT_UNLOAD_OFFLINE_ELEMENT||
|248|<xref:NT_ASSIGN_DYNAMIC_OID>|Assigns a dynamic OID to a parameter that will be read by a multi-threaded timer.|
|249|<xref:NT_CHANGE_COMMUNICATION_STATE>|Sets the communication state of an element.|
|250|NT_REPLICATED_SERVICE_STATE||
|251|NT_RESET_LATCH||
|252|NT_GET_NEW_ELEMENT_ID||
|253|NT_REGISTER_AUTOMATIC_ELEMENT||
|254|NT_UNREGISTER_AUTOMATIC_ELEMENT||
|255|NT_SQL_QUERY_DATA||
|256|<xref:NT_SET_PARAMETER_WITH_HISTORY>|Sets a parameter with the provided timestamp.|
|257|NT_PROPERTY_UPDATE_AUTOMATIC_ELEMENT||
|258|NT_RENAME_AUTOMATIC_ELEMENT||
|259|NT_PUSH_FILE||
|260|<xref:NT_GET_REMOTE_TREND_AVG>|Gets the average trend data of a view table column.|
|261|NT_LOAD_ROW||
|262|NT_UNLOAD_ROW||
|263|NT_SHRINK_TABLE||
|264|NT_LOAD_TABLE||
|265|<xref:NT_EXISTS_ROW>|Checks if a row with the provided primary key exists in the table.|
|266|NT_RETURN_GET||
|267|NT_GET_BITRATE_STATE||
|268|NT_SET_BITRATE_STATE||
|269|<xref:NT_GET_BITRATE_DELTA>|Retrieves the delta between two consecutive group executions (in ms).|
|270|<xref:NT_GET_BITRATE_DATA>|Retrieves the raw counter information of the last two iterations.|
|271|NT_DIS||
|272|NT_ADD_VIEW_NO_LOCK||
|273|NT_DELETE_DB_SETTINGS||
|274|NT_LOAD_VIRTUAL_DYNAMIC_ELEMENT||
|275|NT_BLINKING_SETTINGS||
|276|NT_SURVEYOR_STATISTICS_SETTINGS||
|277|NT_STORE_ENCRYPTED_KEY||
|278|NT_GET_INDEXES_WITH_TREND_AVG||
|279|NT_GET_INDEXES_WITH_TREND_RT||
|280|NT_REFRESH_LDAP||
|281|NT_PARAMETER_FOR_SNMP_MANAGER_V3||
|282|<xref:NT_SERVICE_REMOTE>|Creates or updates a service on a remote DMA.|
|283|NT_ALARM_LEVEL_LINK_INIT||
|284|NT_ALARM_LEVEL_LINK_REMOVE||
|285|NT_ALARM_LEVEL_LINK_UPDATE||
|286|NT_ALARM_LEVEL_LINK_CHANGE||
|287|<xref:NT_ALL_TRAP_INFO>||
|288|NT_GET_ALARM_TEMPLATE_INFO||
|289|NT_TIMEOUT_DISPLAY_SETTING||
|290|NT_GET_BASELINE_INFO||
|291|NT_GET_TREND_TEMPLATE_INFO||
|292|<xref:NT_SNMP_SET>|Performs SNMP set operation(s).|
|293|<xref:NT_INCREMENT_ROW>|Adds the specified numeric values to the current values in the row.|
|294|NT_DATABASE_STATUS||
|295|<xref:NT_SNMP_GET>|Performs SNMP get operation(s).|
|296|NT_OFFLOAD_FOLDER||
|297|NT_GET_DVE_INFO||
|298|NT_COMPARE_AUTOMATIC_ELEMENTS||
|299|NT_GET_DVE_CHILDS||
|300|NT_HTTP_RESULT||
|301|NT_GET_COLUMN||
|302|NT_ADD_MULTIPLE_ELEMENTS_NO_VIEWS_UPDATE||
|303|<xref:NT_GET_VIEW_NAME>|Gets the name of a view using the view ID.|
|304|NT_FIND_LOCAL_ELEMENTS_FOR_ALARM_TEMPLATE||
|305|NT_NORMALIZE_CELL||
|306|NT_SNMP_SEND_HISTORY_ALARMS||
|307|<xref:NT_INVALIDATE_PARAMETER>|Set the validity state of the specified parameter(s).|
|308|NT_LINK_INFORMATION_EVENTS||
|309|NT_GET_PARENT_ALARM_TEMPLATE_GROUPS||
|310|NT_SEND_ALL_UPDATES||
|311|NT_GET_PARAMETER_BY_OID||
|312|NT_GET_DB_ID||
|313|NT_WMI_RESULT||
|314|NT_GET_SPECTRUM_ELEMENTS||
|315|NT_ACTIVATE_WATCHDOG_EMAIL||
|316|<xref:NT_GET_VIEW_PROPERTIES>|Gets the properties of a view.|
|317|<xref:NT_SYNC_SNMP_MANAGER>|Triggers the resend mechanism for a particular SNMP manager (SNMPv1 traps, SNMPv2 traps and inform messages).|
|318|NT_GET_ACTIVE_ALARMS||
|319|NT_FAILOVERSYNC_SET_STATE||
|320|NT_FAILOVERSYNC_GET_STATE||
|321|<xref:NT_GET_TABLE_COLUMNS>|Retrieves the selected columns of a table.|
|322|<xref:NT_GET_CAPABILITIES>|Retrieves the defined Notify Types and provides some information about the expected format and content of the parameter values for the corresponding NotifyProtocol or NotifyDataMiner(Queued) method call.|
|323|<xref:NT_DOES_ELEMENT_EXIST>|Checks if an element, service or redundancy group exists in the cluster.|
|324|<xref:NT_GET_FAILOVER_CONFIG>|Retrieves the Failover configuration.|
|325|NT_RELOAD_SECURITY||
|326|<xref:NT_ADD_VIEW_PARENT_AS_NAME>|Adds a new view to the view with the provided name.|
|327|<xref:NT_RESET_THREAD_POOL>|Resets the thread pool of the specified multi-threaded timer.|
|328|<xref:NT_SET_THREAD_POOL_STATE>|Resets the thread pool of the specified multi-threaded timer.|
|329|NT_ENABLE_FEATURE||
|330|NT_IS_FEATURE_ACTIVE||
|331|NT_REPLICATION_TRANSLATION||
|332|NT_GET_LOCKED_ELEMENTS||
|333|NT_SET_HIGH_RESOLUTION_TIMER||
|334|NT_REQ_INTERNAL_TICKET||
|335|<xref:NT_SET_ID_RANGE>|Sets a view ID range.|
|336|<xref:NT_FILL_ARRAY_WITH_COLUMN_ONLY_UPDATES>|Sets or updates one or more table columns with the provided values.|
|337|NT_GET_HYPERLINKS||
|338|NT_UPDATE_HYPERLINKS||
|339|NT_EXECUTE_DYNAMIC_ACTION||
|340|<xref:NT_DVE_CREATION_FLAG>|Enables or disables the creation of DVEs.|
|341|NT_REPLICATION_TABLE_UPDATE||
|342|NT_SET_READ_PARAMETER_BY_NAME||
|343|NT_SET_WRITE_PARAMETER_BY_NAME||
|344|NT_GET_IMPACTED_PROTOCOLS_FOR_BASE||
|345|NT_MAP_BASE_PARAM_TO_DEVICE||
|346|NT_MAP_DEVICE_PARAM_TO_BASE||
|347|NT_GET_BASE_PROTOCOL_NAMES||
|348|NT_GET_BASE_PROTOCOL_LINKING||
|349|NT_MAP_BASE_ID_TO_DEVICE_ID||
|350|<xref:NT_GET_VIEW_PROPERTY>)|Retrieves the value of the specified view property.|
|351|NT_GET_KEYS_FOR_INDEX_NO_LOCK||
|352|NT_GET_ELEMENT_TREND_WINDOWS||
|353|<xref:NT_GET_ACTIVATED_LICENSE_COUNTERS>|Retrieves the number of activated elements, spectrum elements, protocol names and elements using the protocol.|
|354|NT_PUSH_ALARM_STRUCTURE||
|355|NT_PUT_PARAMETER_INDEX_INTERNAL||
|356|NT_HISTORIC_SLA_QUERY||
|357|NT_SMART_RECEIVE||
|358|NT_SET_PARAMETER_BY_ID||
|359|NT_PUSH_CACHED_ALARM_STRUCTURE||
|360|NT_ASSIGN_PROTOCOL_VDX||
|361|NT_GROUP_DELETE_ELEMENTS||
|362|NT_GROUP_EDIT_ELEMENTS||
|363|NT_EXPORT||
|364|NT_INITIALIZE_SCHEDULE||
|365|NT_IMPORT||
|366|NT_GROUP_DELETE_PARAMETERS||
|367|NT_GROUP_EDIT_PARAMETERS||
|368|NT_EXPORT_TO_IMPORT_DESTINATION||
|369|<xref:NT_FIND_HOSTING_AGENT>|Retrieves the DataMiner Agent ID of the Agent hosting the specified element.|
|370|NT_INVALIDATE_HOSTING_AGENT_CACHE||
|371|NT_GET_ELEMENT_REPORT||
|372|NT_GET_PROTOCOL_INTERFACE||
|373|NT_PUSH_HISTORY_PROPERTY||
|374|<xref:NT_CLOSE_HISTORY_TREND_WINDOW>|Closes a trend window.|
|375|NT_REQUEST_PARAMETER_CHANGES_INFO||
|376|NT_IMPORT_REMOTE_DATA||
|377|<xref:NT_ELEMENT_STARTUP_COMPLETE>|Checks if element startup is completed.|
|378|NT_CLEAR_SCHEDULE||
|379|NT_WATCHDOG_RESET||
|380|NT_CLEAN_ALARM_RESIDUE||
|381|NT_REQUEST_ALARM_CHANGES_INFO||
|382|NT_EXTERNAL_AUTH_SETTINGS||
|383|NT_ADVANCED_NAME_CHANGED||
|384|NT_REMOVE_ENCRYPTED_KEY||
|385|<xref:NT_DB_CLEANING>|Enables or disables the database cleaning and forwarding thread in the SLDataMiner process.|
|386|NT_HTTP_GSM_REQUEST||
|387|NT_WEBSOCKET_CONNECT_RESULT||
|388|NT_RESTART_DATA_GATEWAY||
|389|NT_GET_DVE_INDEX||
|390|NT_FO_START_GOING_OFFLINE||
|391|NT_GET_PORT_COOKIE||
|392|NT_FORWARD_BUBBLE_UP_ALARM||
|393|<xref:NT_GET_TABLE_ID_BY_COLUMN_ID>|Retrieves the ID of the table parameter to which the column with the specified ID belongs.|
|394|<xref:NT_GET_PK_ID_BY_TABLE_ID>|Retrieves the column index of the column that contains the primary keys of the table with the specified ID.|
|395|NT_LOCAL_DB_CHANGE||
|396|NT_SET_PARAMETER_CHECK_CONDITIONS||
|397|<xref:NT_GET_KEYS_SLPROTOCOL>|Retrieves the primary keys of a table from the SLProtocol process without interacting with the SLElement process.|
|398|NT_CASSANDRA_MIGRATION_STARTED||
|399|NT_NOTIFY_ACTIVE_SERVICE_ALARMS||
|400|NT_RELOAD_FUNCTIONS||
|401|NT_NOTIFY_REMOTE_OWNERSHIP||
|402|OBSOLETE_NT_NOTIFY_BEHAVIOR_CHANGE||
|403|NT_GET_EXPORTED_ELEMENT_ID||
|404|NT_SET_KQI_VALUES||
|405|NT_PUSH_TO_ELEMENT_DATA||
|406|NT_SET_CURRENT_PROTOCOL_FUNCTIONS||
|407|NT_REPLICATION_GET_COLUMN_COUNT||
|408|NT_CLEAR_ALL_VIPS||
|409|NT_SLNET_RECEIVE_ELEMENT_START_COMPLETE||
|410|NT_REFRESH_WINDOWS_USERS||
|411|<xref:NT_GET_KEYS_FOR_INDEX_CASED>|Gets the primary keys of all rows that have the specified value (case sensitive) for the specified column.|
|412|NT_COMPLIANCES||
|413|NT_REMOVE_FUNCTIONS||
|414|NT_NOTIFY_SLA||
|415|NT_UPDATE_USER_DIRECTORY_SETTINGS||
|416|NT_GET_TABLE_PARAMETER_VALUE_BY_INDEX||
|417|NT_TEST_CONNECTION||
|418|NT_SERVICE_ELEMENT_STOP||
|419|NT_ADD_DVE_TO_VIEW||
|420|NT_ADD_DVE_TO_VIEW_ONLY||
|421|NT_HALT_POLLING||
|422|NT_RCA_LEVELS||
|423|NT_ISDOING_DOUBLECHECK||
|424|<xref:NT_SNMP_RAW_GET>|Performs an SNMP GET request without requiring an SNMP connection to be defined in the protocol.|
|425|<xref:NT_SNMP_RAW_SET>|Performs an SNMP SET request without requiring an SNMP connection to be defined in the protocol.|
|426|NT_FLUSH_DATA_TO_DATAGATEWAY||
|427|NT_SET_FAILOVER_OFFLOAD||
|428|NT_ENABLE_POLLING||
|429|NT_START_ELEMENT||
|430|NT_ENHANCE_VIEW_WITH_ELEMENT||
|431|NT_SERVICE_ELEMENT_START||
|432|NT_CHANGE_MASK_INFO||
|433|NT_RELOAD_FAILOVERINFO||
|434|NT_SERVICE_TRIGGERS||
|435|NT_DOES_ELEMENT_EXIST_LOCALLY||
|436|NT_CLEAN_SUBSCRIPTION_FOR_STOPPED_ELEMENT||
|437|NT_GET_LINKED_OBJECT_REF_TREES||
|438|NT_CHANGE_MASK_INFO_BULK||
|439|NT_BIND_VIRTUAL_FUNCTION||
|440|NT_UNBIND_VIRTUAL_FUNCTION||
|441|NT_REPLICATION_TABLE_TRANSLATION||
|442|NT_GET_REMOTE_ELEMENT_IDS||
|443|NT_SET_PUSH_HOSTING_EXPOSERS_TO_SLNET||
|444|NT_ASSIGN_ELEMENT_VDX||
|445|NT_CONFIGURE_ELEMENT_VDX||
|446|NT_GET_ACTIVE_HYSTERESIS_INFO||
|447|NT_AZURE_AD_CONFIG||
|448|<xref:NT_SET_BITRATE_DELTA_INDEX_TRACKING>|Enables or disables the bitrate delta tracking for the specified table parameters.|
|449|NT_LOAD_SIMULATIONS||
|450|NT_GET_TRANSLATION_MAPPING_DV_UPDATES||
|451|NT_SET_CLEARABLE_ALARM_PROTECTION_THRESHOLDS||
|452|NT_UPDATE_SPECTRUM_MEASUREMENT_POINTS||
|453|NT_SPECTRUM_ADVANCED_SETTINGS||
|454|<xref:NT_ADD_VIEWS>|Creates multiple views.|
|455|NT_ADD_VIEWS_NO_LOCK||
|456|NT_ADD_VIEWS_PARENT_AS_NAME||
|457|NT_RESERVE_DATA_COOKIES||
|458|NT_DIRECT_VIEW_REMOTE_COOKIE||
|459|NT_ELEMENT_DEINIT_COMPLETE||
