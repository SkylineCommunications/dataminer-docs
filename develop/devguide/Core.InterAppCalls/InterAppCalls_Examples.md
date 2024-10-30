---
uid: InterAppCalls_Examples
---

# InterApp examples

## Simple FillArray

In this example, the QAction receives a message to fill in a table.

### Data classes

```csharp
    public class TableDataMessage : Message
    {
        /// <summary>
        /// Gets or sets the table parameter id.
        /// </summary>
        public int TablePid { get; set; }

        /// <summary>
        /// Gets or sets the rows for the table.
        /// </summary>
        public List<object[]> Rows { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the table needs to be overwritten or appended to.
        /// </summary>
        public bool OverwriteTable { get; set; }
    }

    public class TableDataResponse : Message
    {
        /// <summary>
        /// Gets or sets a value indicating whether the table was set.
        /// </summary>
        public bool Success { get; set; }
    }
```

### Executor

```csharp
    public class TableDataExecutor : SimpleMessageExecutor<TableDataMessage>
    {
        public TableDataExecutor(TableDataMessage message) : base(message)
        {
        }

        public override bool TryExecute(object dataSource, object dataDestination, out Message optionalReturnMessage)
        {
            if (!(dataSource is SLProtocol protocol))
            {
                optionalReturnMessage = null;
                return false;
            }

            NotifyProtocol.SaveOption option = Message.OverwriteTable ? NotifyProtocol.SaveOption.Full : NotifyProtocol.SaveOption.Partial;

            protocol.FillArray(Message.TablePid, Message.Rows, option);

            optionalReturnMessage = new TableDataResponse { Success = true };
            return true;
        }
    }
```

### QAction

```csharp
using System;
using System.Collections.Generic;

using Example;

using Skyline.DataMiner.Core.InterAppCalls.Common.CallBulk;
using Skyline.DataMiner.Core.InterAppCalls.Common.CallSingle;
using Skyline.DataMiner.Scripting;

/// <summary>
/// DataMiner QAction Class: InterApp.
/// </summary>
public static class QAction
{
    private static readonly Dictionary<Type, Type> MsgToExecutor = new Dictionary<Type, Type>
    {
        { typeof(TableDataMessage), typeof(TableDataExecutor) }
    };

    private static readonly List<Type> KnownTypes = new List<Type>
    {
        typeof(TableDataMessage),
        typeof(TableDataResponse),
    };

    /// <summary>
    /// The QAction entry point.
    /// </summary>
    /// <param name="protocol">Link with SLProtocol process.</param>
    public static void Run(SLProtocol protocol)
    {
        try
        {
            HandleIncomingMessages(protocol);
        }
        catch (Exception ex)
        {
            protocol.Log($"QA{protocol.QActionID}|{protocol.GetTriggerParameter()}|Run|Exception thrown:{Environment.NewLine}{ex}", LogType.Error, LogLevel.NoLogging);
        }
    }

    private static void HandleIncomingMessages(SLProtocol protocol)
    {
        // Retrieve incoming message
        string raw = Convert.ToString(protocol.GetParameter(protocol.GetTriggerParameter()));
        IInterAppCall receivedCall = InterAppCallFactory.CreateFromRaw(raw, KnownTypes);

        // Run the execute logic on each message
        foreach (var message in receivedCall.Messages)
        {
            if (message.TryExecute(protocol, protocol, MsgToExecutor, out Message returnMessage))
            {
                message.Reply(protocol.SLNet.RawConnection, returnMessage, KnownTypes);
            }
        }
    }
}
```
