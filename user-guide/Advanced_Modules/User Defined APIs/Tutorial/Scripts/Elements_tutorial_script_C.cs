namespace ElementsAPI_1
{
    using Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Skyline.DataMiner.Automation;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Represents a DataMiner Automation script.
    /// </summary>
    public class Script
    {
        private readonly List<string> _knownAlarmTypes
            = new List<string> { "Warning", "Minor", "Major", "Critical" };
        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
        };

        [AutomationEntryPoint(AutomationEntryPointType.Types.OnApiTrigger)]
        public ApiTriggerOutput OnApiTrigger(IEngine engine, ApiTriggerInput requestData)
        {
            if (string.IsNullOrWhiteSpace(requestData.RawBody))
            {
                return new ApiTriggerOutput()
                {
                    ResponseBody = "Request body cannot be empty",
                    ResponseCode = (int)StatusCode.BadRequest,
                };
            }

            Input input;
            try
            {
                input = JsonConvert.DeserializeObject<Input>(
                    requestData.RawBody ?? string.Empty, _serializerSettings);
            }
            catch
            {
                return new ApiTriggerOutput()
                {
                    ResponseBody = "Could not parse request body.",
                    ResponseCode = (int)StatusCode.InternalServerError,
                };
            }

            if (string.IsNullOrWhiteSpace(input.AlarmType) || !_knownAlarmTypes.Contains(input.AlarmType))
            {
                return new ApiTriggerOutput()
                {
                    ResponseBody =
                        $"Invalid alarmType passed, possible values are: ${string.Join(",", _knownAlarmTypes)}",
                    ResponseCode = (int)StatusCode.BadRequest,
                };
            }

            return new ApiTriggerOutput
            {
                ResponseBody = "Succeeded",
                ResponseCode = (int)StatusCode.Ok,
            };
        }
    }
}

namespace Models
{
    public class Input
    {
        public string AlarmType { get; set; }

        public int Limit { get; set; }
    }
}