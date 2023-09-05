namespace ElementsAPI_1
{
    using System.Collections.Generic;
    using Skyline.DataMiner.Automation;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;

    /// <summary>
    /// Represents a DataMiner Automation script.
    /// </summary>
    public class Script
    {
        private readonly List<string> _knownAlarmTypes 
            = new List<string> { "Warning", "Minor", "Major", "Critical" };

        [AutomationEntryPoint(AutomationEntryPointType.Types.OnApiTrigger)]
        public ApiTriggerOutput OnApiTrigger(IEngine engine, ApiTriggerInput requestData)
        {
            var alarmStateInput = requestData.RawBody;

            if (string.IsNullOrWhiteSpace(alarmStateInput) || !_knownAlarmTypes.Contains(alarmStateInput))
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