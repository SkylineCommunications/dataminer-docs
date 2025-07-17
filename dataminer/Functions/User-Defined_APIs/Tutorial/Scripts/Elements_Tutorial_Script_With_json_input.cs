namespace ElementsAPI_1
{
    using System.Collections.Generic;
    using Models;
    using Skyline.DataMiner.Automation;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class Script
    {
        private readonly List<string> _knownAlarmLevels
            = new List<string> { "Warning", "Minor", "Major", "Critical" };

        private readonly JsonSerializerSettings _serializerSettings 
            = new JsonSerializerSettings()
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

            if (string.IsNullOrWhiteSpace(input.AlarmLevel) || !_knownAlarmLevels.Contains(input.AlarmLevel))
            {
                return new ApiTriggerOutput()
                {
                    ResponseBody =
                        $"Invalid alarm level passed, possible values are: ${string.Join(",", _knownAlarmLevels)}",
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
        public string AlarmLevel { get; set; }

        public int Limit { get; set; }
    }
}