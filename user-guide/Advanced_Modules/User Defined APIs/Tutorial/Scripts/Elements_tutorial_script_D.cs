namespace ElementsAPI_1
{
    using Models;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
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

            List<ElementInfo> elements;
            try
            {
                elements = GetElements(engine, input).Take(input.Limit).ToList();
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
            if (input.AlarmType.Equals("Minor"))
            {
                elementFilter.MinorOnly = true;
            }
            else if (input.AlarmType.Equals("Warning"))
            {
                elementFilter.WarningOnly = true;
            }
            else if (input.AlarmType.Equals("Major"))
            {
                elementFilter.MajorOnly = true;
            }
            else if (input.AlarmType.Equals("Critical"))
            {
                elementFilter.CriticalOnly = true;
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

            return elements;
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
        public string AlarmType { get; set; }

        public int Limit { get; set; }
    }
}