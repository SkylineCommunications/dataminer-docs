﻿using System;

namespace Skyline.DataMiner.Net.Messages
{
	public enum NotifyType
	{
		Undefined = 0,
		Sms = 1,
		AddView = 2,
		AddElement = 3,
		DeleteView = 4,
		DeleteElement = 5,
		EditView = 6,
		AddSNMPManager = 7,
		DeleteSNMPManager = 8,
		EditSNMPManager = 9,
		Alarm = 10,
		ElementState = 11,
		DBSettings = 12,
		TrendingType = 13,
		TrendingAssignTemplate = 14,

		[Obsolete("Use TrendingAssignTemplate instead")]
		TrendingAssigneTemplate = 14,
		TrendingElement = 15,
		TrendingTemplateChange = 16,
		CreateSimulation = 17,
		UserAddToGroups = 18,
		UserDeleteFromGroups = 19,
		GroupAdd = 20,
		GroupDelete = 21,
		GroupChangeName = 22,
		GroupChangeLevel = 23,
		GroupAddViews = 24,
		GroupDeleteViews = 25,
		GroupRights = 26,
		VdxChangeViews = 27,
		Ping = 28,
		LogLevels = 29,
		TelnetClient = 30,
		Connections = 31,
		FileChanged = 32,
		FileRemoved = 33,
		FileAdd = 34,
		FileNameChanged = 35,
		NotifyConnectedElements = 36,
		DmaAdded = 37,
		DmaRemoved = 38,
		Normalize = 39,
		DataDisplayClient = 40,
		SendDmsFileChange = 41,
		ProtocolChanged = 42,
		ElementChanged = 43,
		SchedulerStateus = 44,
		StopDataMiner = 45,
		ElementAlarmState = 46,
		GetSpectrumInterface = 47,
		GetAlarmInfo = 48,
		ChangeProtocol = 49,
		SetParameter = 50,
		WatchdogSettings = 51,
		GroupEditViews = 52,
		RunTask = 53,
		PingSettings = 54,
		SetAsCurrentProtoocol = 55,
		GetCurrentProtocol = 56,
		ElementReceive = 57,
		RemoteElementState = 58,
		ReconnectClient = 59,
		GetData = 60,
		DeleteProperty = 61,
		EditProperty = 62,
		[Obsolete("No longer supported", error: true)]
		ConnectionsToRemove = 63,
		SetDMSRevisionTime = 64,
		RedundantTrigger = 65,
		SetDerivedElement = 66,
		RedundancyGroup = 67,
		RenewDescriptionXml = 68,
		GetValue = 69,
		AddDescriptionFile = 70,
		DeleteRedundancyGroup = 71,
		NotifyServiceStatus = 72,
		GetParameter = 73,
		DeleteService = 74,
		Service = 75,
		AssignSimulation = 76,
		GetName = 77,
		IsLocalIp = 78,
		DontForwardState = 79,
		DmaAlarmState = 80,
		GetClientInfo = 81,
		ReturnSet = 82,
		AddClient = 83,
		SetParameterByName = 84,
		GetParameterByName = 85,
		SetParameterByData = 86,
		GetParameterByData = 87,
		GetItemData = 88,
		SetItemData = 89,
		AgentFound = 90,
		ChangeAlarmColor = 91,
		SetKey = 92,
		DMARemoteBackupSettings = 93,
		GetXmlCookie = 94,
		GetDmaDocuments = 95,
		GetTaskInfo = 96,
		AddElementTypes = 97,
		GetAvailableFiles = 98,
		AddFile = 99,
		GetSubjectAndComment = 100,
		SetSubjectAndComment = 101,
		Removefile = 102,
		RemoveDocument = 103,
		SetSecurityInfo = 104,
		ThreadCheck = 105,
		MakeAlarm = 106,
		DataMinerInfo = 107,
		GetUser = 108,
		UpdateData = 109,
		SetMaintenanceInfo = 110,
		RegisterClient = 111,
		UnregisterClient = 112,
		SubscribeClient = 113,
		UnsubscribeClient = 114,
		SetElementState = 115,
		SetAlarmState = 116,
		AssignAlarmTemplate = 117,
		ViewChangeParent = 118,
		LoadRemoteRedundancy = 119,
		GetUserInfo = 120,
		PutParameterIndex = 121,
		GetParameterIndex = 122,
		NotifyDisplay = 123,
		ServiceTrigger = 124,
		SLNetSettings = 125,
		ParameterForSnmpManager = 126,
		UpdateDescriptionXml = 127,
		UpdatePortsXml = 128,
		GenerateMiniDump = 129,
		PasswordOnZip = 130,
		SetDescription = 131,
		SetDescriptionQueued = 132,
		GetDisplayValue = 133,
		CheckTrigger = 134,
		GetTriggerStatus = 135,
		DeleteElementData = 136,
		AnotherTelnetClient = 137,
		GetActiveRootkeys = 138,
		ClearCachedProtocol = 139,
		AddMultipleElements = 140,
		GetXmlCookies = 141,
		RemoteConnections = 142,
		SyncVdxTemplates = 143,
		GetElementName = 144,
		MaxDocumentSize = 145,
		RemoveFileChange = 146,
		SecurityChanged = 147,
		RegisterSLA = 148,
		AddRow = 149,
		AssignInformationTemplate = 150,
		GetProtocolOfType = 151,
		ResetSLNetPointers = 152,
		GetEncrypted = 153,
		GetLicensed = 154,
		SaveAndRecycle = 155,
		DeleteRow = 156,
		EditPropertyNoForward = 157,
		NewObject = 158,
		GetParameterDisplayValue = 159,
		CreateElement = 160,
		GetDisplayForPK = 161,
		GetPKForDisplay = 162,
		GetKeyPosition = 163,
		ParameterDistribution = 164,
		DeleteDistributionKey = 165,
		ElementNameChanged = 166,
		SetParameterWithWait = 167,
		GetIndexes = 168,
		CheckHyperlinks = 169,
		RefreshHyperlinks = 170,
		DbQuery = 171,
		XmlQuery = 172,
		GetIndexesWithTrend = 173,
		GetIndexesWithAlarm = 174,
		UpdateSimulationFile = 175,
		GetViewsOfElement = 176,
		SetBinaryData = 177,
		GetIdOfElementsInView = 178,
		GetViewId = 179,
		GetDocuments = 180,
		CreateFolder = 181,
		DeleteFolder = 182,
		RenameFolder = 183,
		RcaLevel = 184,
		CreateDynamicElement = 185,
		LockChangeNotifications = 186,
		GroupChangeFilters = 187,
		UserSetSchedule = 188,
		ClearDerivedInfo = 189,
		CleanDatabaseStack = 190,
		ReloadDatabaseStack = 191,
		ClearNormalizeInfo = 192,
		FillArray = 193,
		FillArrayNoDelete = 194,
		ArrayRowCount = 195,
		GetKeysForIndex = 196,
		ChangePrimaryIP = 197,
		DrsState = 198,
		GetDrsState = 199,
		AddNewElement = 200,
		FailoverSync = 201,
		ReloadElement = 202,
		GetSubViews = 203,
		SetStaticIpAddress = 204,
		SetSecondaryIpAddress = 205,
		NT_REFRESH_GENERIC_PROPERTIES = 206,
		NT_GET_UTF8_STRING = 207,
		NT_PARAMETER_FOR_SNMP_MANAGER_V2 = 208,
		NT_GENERIC_XML_UPDATE = 209,
		NT_UNLOAD_SERVICE = 210,
		NT_UNLOAD_REDUNDANCY = 211,
		NT_UNLOAD_ELEMENT = 212,
		NT_RG_ELEMENT_SWITCH = 214,
		NT_GET_ROW = 215,
		NT_GET_REMOTE_TREND = 216,
		NT_REQUEST_MERGE_INFO = 217,
		NT_RECEIVE_MERGE_REQUEST = 218,
		NT_ACK_MERGE_REQUEST = 219,
		NT_FILL_ARRAY_WITH_COLUMN = 220,
		NT_RUN_ACTION = 221,
		NT_RG_SET_MODE = 222,
		NT_RG_SET_MAINTENANCE = 223,
		NT_RG_SET_ELEMENTS = 224,
		NT_SET_ROW = 225,
		NT_DIAG = 226,
		NT_UPDATE_PORTS_XML2 = 227,
		NT_GET_DISTINCT_INDEXES = 228,
		NT_SCHEDULE_ROW_ON_TIMER = 229,
		NT_RG_DUPLICATE_TEMPLATE = 230,
		NT_ADD_EDIT_GENERIC_PROPERTY = 231,
		NT_SERVICE_SET_VDX = 232,
		NT_GET_LAST_POLL_TIME = 233,
		NT_ENABLE_STORE_POLL_TIME = 234,
		NT_DRS_RELOAD = 235,
		NT_DRS_RECREATE_VIP = 236,
		NT_PUT_PARAMETER_INDEX_WITH_LOG = 237,
		NT_REBUILD_INDEX = 238,
		NT_LOG_INDEX = 239,
		NT_ADD_ROW_RETURN_KEY = 240,

		[Obsolete]
		NT_IS_CLIENT_APP_LICENSED = 241,
		[Obsolete]
		NT_RELOAD_CLIENT_APP_LIC = 242,
		NT_VERIFY_CLIENT_COOKIE = 243,
		NT_GET_EXPIRATION_DATE = 244,
		NT_FORCE_REPLICATION = 245,
		NT_LOAD_OFFLINE_ELEMENT = 246,
		NT_UNLOAD_OFFLINE_ELEMENT = 247,
		NT_ASSIGN_DYNAMIC_OID = 248,
		NT_CHANGE_COMMUNICATION_STATE = 249,
		NT_REPLICATED_SERVICE_STATE = 250,
		NT_RESET_LATCH = 251,
		NT_GET_NEW_ELEMENT_ID = 252,
		NT_REGISTER_AUTOMATIC_ELEMENT = 253,
		NT_UNREGISTER_AUTOMATIC_ELEMENT = 254,
		NT_SQL_QUERY_DATA = 255,
		NT_SET_PARAMETER_WITH_HISTORY = 256,
		NT_PROPERTY_UPDATE_AUTOMATIC_ELEMENT = 257,
		NT_RENAME_AUTOMATIC_ELEMENT = 258,
		NT_PUSH_FILE = 259,
		NT_GET_REMOTE_TREND_AVG = 260,
		NT_LOAD_ROW = 261,
		NT_UNLOAD_ROW = 262,
		NT_SHRINK_TABLE = 263,
		NT_LOAD_TABLE = 264,
		NT_EXISTS_ROW = 265,
		NT_RETURN_GET = 266,
		NT_GET_BITRATE_STATE = 267,
		NT_SET_BITRATE_STATE = 268,
		NT_GET_BITRATE_DELTA = 269,
		NT_GET_BITRATE_DATA = 270,
		NT_DIS = 271,
		NT_ADD_VIEW_NO_LOCK = 272,
		NT_DELETE_DB_SETTINGS = 273,
		NT_LOAD_VIRTUAL_DYNAMIC_ELEMENT = 274,
		NT_BLINKING_SETTINGS = 275,
		NT_SURVEYOR_STATISTICS_SETTINGS = 276,
		NT_STORE_ENCRYPTED_KEY = 277,
		NE_GET_INDEXES_WITH_TREND_AVG = 278,
		NE_GET_INDEXES_WITH_TREND_RT = 279,
		NT_REFRESH_LDAP = 280,
		NT_PARAMETER_FOR_SNMP_MANAGER_V3 = 281,
		NT_SERVICE_REMOTE = 282,
		NT_ALARM_LEVEL_LINK_INIT = 283,
		NT_ALARM_LEVEL_LINK_REMOVE = 284,
		NT_ALARM_LEVEL_LINK_UPDATE = 285,
		NT_ALARM_LEVEL_LINK_CHANGE = 286,
		NT_ALL_TRAP_INFO = 287,
		NT_GET_ALARM_TEMPLATE_INFO = 288,
		NT_TIMEOUT_DISPLAY_SETTING = 289,
		NT_GET_BASELINE_INFO = 290,
		NT_GET_TREND_TEMPLATE_INFO = 291,
		NT_SNMP_SET = 292,
		NT_INCREMENT_ROW = 293,
		NT_DATABASE_STATUS = 294,
		NT_SNMP_GET = 295,
		NT_OFFLOAD_FOLDER = 296,
		NT_GET_DVE_INFO = 297,
		NT_COMPARE_AUTOMATIC_ELEMENTS = 298,
		NT_GET_DVE_CHILDS = 299,
		NT_HTTP_RESULT = 300,
		NT_GET_COLUMN = 301,
		NT_ADD_MULTIPLE_ELEMENTS_NO_VIEWS_UPDATE = 302,
		NT_GET_VIEW_NAME = 303,
		NT_FIND_LOCAL_ELEMENTS_FOR_ALARM_TEMPLATE = 304,
		NT_NORMALIZE_CELL = 305,
		NT_SNMP_SEND_HISTORY_ALARMS = 306,
		NT_INVALIDATE_PARAMETER = 307,
		NT_LINK_INFORMATION_EVENTS = 308,
		NT_GET_PARENT_ALARM_TEMPLATE_GROUPS = 309,
		NT_SEND_ALL_UPDATES = 310,
		NT_GET_PARAMETER_BY_OID = 311,
		NT_GET_DB_ID = 312,
		NT_WMI_RESULT = 313,
		NT_GET_SPECTRUM_ELEMENTS = 314,
		NT_ACTIVATE_WATCHDOG_EMAIL = 315,
		NT_GET_VIEW_PROPERTIES = 316,
		NT_SYNC_SNMP_MANAGER = 317,
		NT_GET_ACTIVE_ALARMS = 318,
		NT_FAILOVERSYNC_SET_STATE = 319,
		NT_FAILOVERSYNC_GET_STATE = 320,
		NT_GET_TABLE_COLUMNS = 321,
		NT_GET_CAPABILITIES = 322,
		NT_DOES_ELEMENT_EXIST = 323,
		NT_GET_FAILOVER_CONFIG = 324,
		NT_RELOAD_SECURITY = 325,
		NT_ADD_VIEW_PARENT_AS_NAME = 326,
		NT_RESET_THREAD_POOL = 327,
		NT_SET_THREAD_POOL_STATE = 328,
		NT_ENABLE_FEATURE = 329,
		NT_IS_FEATURE_ACTIVE = 330,
		NT_REPLICATION_TRANSLATION = 331,
		NT_GET_LOCKED_ELEMENTS = 332,
		NT_SET_HIGH_RESOLUTION_TIMER = 333,
		NT_REQ_INTERNAL_TICKET = 334, // [DCP15637]
		NT_SET_ID_RANGE = 335,
		NT_FILL_ARRAY_WITH_COLUMN_ONLY_UPDATES = 336,
		NT_GET_HYPERLINKS = 337,
		NT_UPDATE_HYPERLINKS = 338,
		NT_EXECUTE_DYNAMIC_ACTION = 339,
		NT_DVE_CREATION_FLAG = 340,
		NT_REPLICATION_TABLE_UPDATE = 341,
		NT_SET_READ_PARAMETER_BY_NAME = 342,
		NT_SET_WRITE_PARAMETER_BY_NAME = 343,
		NT_GET_IMPACTED_PROTOCOLS_FOR_BASE = 344,   // [WD-DRS13-01]
		NT_MAP_BASE_PARAM_TO_DEVICE = 345,  // [WD-DRS13-01]
		NT_MAP_DEVICE_PARAM_TO_BASE = 346,  // [WD-DRS13-01]
		NT_GET_BASE_PROTOCOL_NAMES = 347, // [WD-DRS13-01]
		NT_GET_BASE_PROTOCOL_LINKING = 348, // [WD-DRS13-01]
		NT_MAP_BASE_ID_TO_DEVICE_ID = 349,      // [JVH-DRS13-01]
		NT_GET_VIEW_PROPERTY = 350,         // [JVH-DRS13-01]
		NT_GET_KEYS_FOR_INDEX_NO_LOCK = 351,
		NT_GET_ELEMENT_TREND_WINDOWS = 352,
		NT_GET_ACTIVATED_LICENSE_COUNTERS = 353,
		NT_PUSH_ALARM_STRUCTURE = 354,
		NT_PUT_PARAMETER_INDEX_INTERNAL = 355,
		NT_HISTORIC_SLA_QUERY = 356,
		NT_SMART_RECEIVE = 357,
		NT_SET_PARAMETER_BY_ID = 358,
		NT_PUSH_CACHED_ALARM_STRUCTURE = 359,
		NT_ASSIGN_PROTOCOL_VDX = 360,
		NT_GROUP_DELETE_ELEMENTS = 361,
		NT_GROUP_EDIT_ELEMENTS = 362,
		NT_EXPORT = 363,
		NT_INITIALIZE_SCHEDULE = 364,
		NT_IMPORT = 365,
		NT_GROUP_DELETE_PARAMETERS = 366,
		NT_GROUP_EDIT_PARAMETERS = 367,
		NT_EXPORT_TO_IMPORT_DESTINATION = 368,
		NT_FIND_HOSTING_AGENT = 369, //[DRS 2014 DELT]
		NT_INVALIDATE_HOSTING_AGENT_CACHE = 370, //[DRS 2014 DELT]
		NT_GET_ELEMENT_REPORT = 371,
		NT_GET_PROTOCOL_INTERFACE = 372,
		NT_PUSH_HISTORY_PROPERTY = 373,
		NT_CLOSE_HISTORY_TREND_WINDOW = 374,
		NT_REQUEST_PARAMETER_CHANGES_INFO = 375,
		NT_IMPORT_REMOTE_DATA = 376,
		NT_ELEMENT_STARTUP_COMPLETE = 377,
		NT_CLEAR_SCHEDULE = 378,
		NT_WATCHDOG_REST = 379,
		NT_CLEAN_ALARM_RESIDUE = 380,
		NT_REQUEST_ALARM_CHANGES_INFO = 381,
		NT_EXTERNAL_AUTH_SETTINGS = 382,
		NT_ADVANCED_NAME_CHANGED = 383,
		NT_REMOVE_ENCRYPTED_KEY = 384,
		NT_DB_CLEANING = 385,
		NT_HTTP_GSM_REQUEST = 386,
		NT_WEBSOCKET_CONNECT_RESULT = 387,
		NT_RESTART_DATA_GATEWAY = 388,
		NT_GET_DVE_INDEX = 389,
		NT_FO_START_GOING_OFFLINE = 390,
		NT_SET_PARAMETER_CHECK_CONDITIONS = 396,
		NT_GET_KEYS_SLPROTOCOL = 397,
		NT_CASSANDRA_MIGRATION_STARTED = 398,
		NT_NOTIFY_ACTIVE_SERVICE_ALARMS = 399,
		NT_RELOAD_FUNCTIONS = 400,
		NT_LOAD_REMOTE_OWNERSHIP = 401,
		OBSOLETE_NT_NOTIFY_BEHAVIOR_CHANGE = 402,
		NT_GET_EXPORTED_ELEMENT_ID = 403,
		NT_SET_CURRENT_PROTOCOL_FUNCTIONS = 406,
		NT_REPLICATION_GET_COLUMN_COUNT = 407,
		NT_CLEAR_ALL_VIPS = 408,
		NT_SLNET_RECEIVE_ELEMENT_START_COMPLETE = 409,
		NT_REFRESH_WINDOWS_USERS = 410,
		NT_GET_KEYS_FOR_INDEX_CASED = 411,
		NT_COMPLIANCES = 412,
		NT_REMOVE_FUNCTIONS = 413,
		NT_NOTIFY_SLA = 414,
		NT_UPDATE_USER_DIRECTORY_SETTINGS = 415,
		NT_GET_TABLE_PARAMETER_VALUE_BY_INDEX = 416,
		NT_TEST_CONNECTION = 417,
		NT_SERVICE_ELEMENT_STOP = 418,
		NT_ADD_DVE_TO_VIEW = 419,
		NT_ADD_DVE_TO_VIEW_ONLY = 420,
		NT_HALT_POLLING = 421,
		NT_RCA_LEVELS = 422,
		NT_ISDOING_DOUBLECHECK = 423,
		NT_SNMP_RAW_GET = 424,
		NT_SNMP_RAW_SET = 425,
		NT_FLUSH_DATA_TO_DATAGATEWAY = 426,
		NT_SET_FAILOVER_OFFLOAD = 427,
		NT_ENABLE_POLLING = 428,
		NT_ENHANCE_VIEW_WITH_ELEMENT = 430,
		NT_SERVICE_ELEMENT_START = 431,
		NT_CHANGE_MASK_INFO = 432,
		NT_RELOAD_FAILOVERINFO = 433,
		NT_SERVICE_TRIGGERS = 434,
		NT_DOES_ELEMENT_EXIST_LOCALLY = 435,
		NT_CLEAN_SUBSCRIPTION_FOR_STOPPED_ELEMENT = 436,
		NT_GET_LINKED_OBJECT_REF_TREE = 437,
		NT_CHANGE_MASK_INFO_BULK = 438,
		NT_BIND_VIRTUAL_FUNCTION = 439,
		NT_UNBIND_VIRTUAL_FUNCTION = 440,
		NT_GET_REMOTE_ELEMENT_IDS = 442,
		NT_SET_PUSH_HOSTING_EXPOSERS_TO_SLNET = 443,
		NT_ASSIGN_ELEMENT_VDX = 444,
		NT_CONFIGURE_ELEMENT_VDX = 445,
		NT_GET_ACTIVE_HYSTERESIS_INFO = 446,
		NT_AZURE_AD_CONFIG = 447,
		NT_SET_BITRATE_DELTA_INDEX_TRACKING = 448,
		NT_LOAD_SIMULATIONS = 449,
		NT_GET_TRANSLATION_MAPPING_DV_UPDATES = 450,
		NT_SET_CLEARABLE_ALARM_PROTECTION_THRESHOLDS = 451,
		NT_UPDATE_SPECTRUM_MEASUREMENT_POINTS = 452,
		NT_SPECTRUM_ADVANCED_SETTINGS = 453,
		NT_ADD_VIEWS = 454,
		NT_ADD_VIEWS_NO_LOCK = 455,
		NT_ADD_VIEWS_PARENT_AS_NAME = 456,
		NT_RESERVE_DATA_COOKIES = 457,
		NT_DIRECT_VIEW_REMOTE_COOKIE = 458,
		NT_ELEMENT_DEINIT_COMPLETE = 459,
		NT_GET_SCRIPT_EXECUTER = 460,
		NT_GET_ELEMENT_STORAGE_INFO = 461,
		NT_GET_NEW_MAX_PROPERTY_ID = 463,
	}
}