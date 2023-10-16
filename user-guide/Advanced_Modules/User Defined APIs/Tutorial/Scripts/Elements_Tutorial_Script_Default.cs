namespace ElementsAPI_1
{
    using Skyline.DataMiner.Automation;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;

    public class Script
    {

        [AutomationEntryPoint(AutomationEntryPointType.Types.OnApiTrigger)]
        public ApiTriggerOutput OnApiTrigger(IEngine engine, ApiTriggerInput requestData)
        {
            return new ApiTriggerOutput
            {
                ResponseBody = "Succeeded",
                ResponseCode = (int)StatusCode.Ok,
            };
        }
    }
}