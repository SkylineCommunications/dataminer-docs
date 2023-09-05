namespace ElementsAPI_1
{
    using Skyline.DataMiner.Automation;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;
    /// <summary>
    /// Represents a DataMiner Automation script.
    /// </summary>
    public class Script
    {
        [AutomationEntryPoint(AutomationEntryPointType.Types.OnApiTrigger)]
        public ApiTriggerOutput OnApiTrigger(IEngine engine, ApiTriggerInput requestData)
        {
            var alarmState = requestData.RawBody;

            return new ApiTriggerOutput
            {
                ResponseBody = "Succeeded",
                ResponseCode = (int)StatusCode.Ok,
            };
        }
    }
}