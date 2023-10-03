namespace ElementsAPI_1
{
    using System.Collections.Generic;
    using Skyline.DataMiner.Automation;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;

    public class Script
    {
        private readonly List<string> _knownAlarmLevels
            = new List<string> { "Warning", "Minor", "Major", "Critical" };

        [AutomationEntryPoint(AutomationEntryPointType.Types.OnApiTrigger)]
        public ApiTriggerOutput OnApiTrigger(IEngine engine, ApiTriggerInput requestData)
        {
            var alarmLevel = requestData.RawBody;

            if (string.IsNullOrWhiteSpace(alarmLevel) || !_knownAlarmLevels.Contains(alarmLevel))
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