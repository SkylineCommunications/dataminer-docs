namespace ElementsAPI_1
{
    using System.Linq;
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

            List<ElementInfo> elements;
            try
            {
                elements = GetElements(engine, input);
            }
            catch
            {
                return new ApiTriggerOutput()
                {
                    ResponseBody = "Something went wrong fetching the Elements.",
                    ResponseCode = (int)StatusCode.InternalServerError,
                };
            }

            return new ApiTriggerOutput
            {
                ResponseBody = JsonConvert.SerializeObject(elements, _serializerSettings),
                ResponseCode = (int)StatusCode.Ok,
            };
        }

        private List<ElementInfo> GetElements(IEngine engine, Input input)
        {
            var elementFilter = new ElementFilter();
            switch (input.AlarmLevel)
            {
                case "Minor":
                    elementFilter.MinorOnly = true;
                    break;
                case "Warning":
                    elementFilter.WarningOnly = true;
                    break;
                case "Major":
                    elementFilter.MajorOnly = true;
                    break;
                case "Critical":
                    elementFilter.CriticalOnly = true;
                    break;
            }

            var rawElements = engine.FindElements(elementFilter);

            var elements = new List<ElementInfo>();
            foreach (var rawElement in rawElements)
            {
                elements.Add(new ElementInfo()
                {
                    DataMinerId = rawElement.RawInfo.DataMinerID,
                    ElementId = rawElement.RawInfo.ElementID,
                    Name = rawElement.ElementName,
                    ProtocolName = rawElement.ProtocolName,
                    ProtocolVersion = rawElement.ProtocolVersion,
                });
            }

            return elements.Take(input.Limit).ToList();
        }
    }
}

namespace Models
{
    public class ElementInfo
    {
        public int ElementId { get; set; }

        public int DataMinerId { get; set; }

        public string ProtocolName { get; set; }

        public string ProtocolVersion { get; set; }

        public string Name { get; set; }
    }

    public class Input
    {
        public string AlarmLevel { get; set; }

        public int Limit { get; set; }
    }
}