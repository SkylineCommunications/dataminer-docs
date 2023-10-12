---
uid: SRM_launching_service_profile_wizard
---

# Launching the Service Profile Booking Wizard from a custom script

You can configure a custom front-end script to launch the Service Profile Booking Wizard.

The example below shows the basic configuration for this.

```csharp
using System;
using Skyline.DataMiner.Library.Solutions.SRM;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Library.Solutions.SRM.Model.DefineBooking;
using Skyline.DataMiner.Net.ResourceManager.Objects;
using DefineBookingMainInfo = Skyline.DataMiner.Library.Solutions.SRM.Model.DefineBookingMainInfo;


namespace SRMSolution_SilentActions.ServiceProfile
{
    public class Script
    {
        public static void Run(Engine engine)
        {
            // Replace with Element Name of the Booking Manager
            string BookingManagerElementName = "Booking Manager";

     var defineBookingInputData = new InputData
            {
                IsSilent = false
            };

            ReservationInstance reservationInstance;

            var mainBookingInfoInputData = new DefineBookingMainInfo.InputData();
            
            bookingManager.TryCreateNewBooking(engine, defineBookingInputData,
            out reservationInstance);

        }
    }
}
```

When you launch the Service Profile Booking Wizard from a custom script, you can also:

- Hide specific fields in the wizard<!-- RN 27973 -->
- Make specific fields get filled in automatically<!-- RN 27946 -->
- Make some fields read-only.
- Override the label of fields.
- Override the title.

Use Visual Studio to see all possible options.

For example:

```csharp
using System;
using Skyline.DataMiner.Library.Solutions.SRM;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Library.Solutions.SRM.Model.DefineBooking;
using Skyline.DataMiner.Net.ResourceManager.Objects;
using DefineBookingMainInfo = Skyline.DataMiner.Library.Solutions.SRM.Model.DefineBookingMainInfo;

    public class Script
    {
        public static void Run(Engine engine)
        {

            // Replace with Element Name of the Booking Manager
            string BookingManagerElementName = "01-SRM Application";
            
            var bookingManager = new BookingManager(engine, engine.FindElement(BookingManagerElementName));

            
            var defineBookingMainInfo = new Skyline.DataMiner.Library.Solutions.SRM.Model.DefineBookingMainInfo.InputData
            {
                IsSilent = false
            };

            // OPTION: hide fields, prefill fields, rename fields,  read-only fields
defineBookingMainInfo.FieldsToHide.Add(DefineBookingMainInfo.MainBookingInfoEditableFields.EndDateWithPostRoll);
            defineBookingMainInfo.FieldsToHide.Add(DefineBookingMainInfo.MainBookingInfoEditableFields.StartDateWithPreRoll);
            defineBookingMainInfo.DefaultValues.Add(DefineBookingMainInfo.MainBookingInfoEditableFields.StartDate, DateTime.SpecifyKind(DateTime.Now.AddMinutes(35), DateTimeKind.Local));
            defineBookingMainInfo.NotEditableFields.Add(DefineBookingMainInfo.MainBookingInfoEditableFields.StartDate);
            defineBookingMainInfo.OverrideFieldLabels.Add(DefineBookingMainInfo.MainBookingInfoEditableFields.StartDate, "Custom Start time");

            // OPTION: rename script title
defineBookingMainInfo.DefaultValues.Add(DefineBookingMainInfo.MainBookingInfoEditableFields.Title, "sdf");
            
            
            var bookingInputData = new Skyline.DataMiner.Library.Solutions.SRM.Model.DefineBooking.InputData
            {
                IsSilent = false
            };
            bookingInputData.MainBookingInfo = bookingManager.FetchMainBookingInfo(engine, defineBookingMainInfo);
            

            var serviceProfileInputData = new Skyline.DataMiner.Library.Solutions.SRM.Model.ServiceProfileProcessing.InputData
            {
               IsSilent = false
            };

            bookingInputData.MainBookingServiceProfileInfo = bookingManager.FetchServiceProfileInfo(engine, serviceProfileInputData);
            
            bookingInputData.IsSilent = true;
            ReservationInstance reservationInstance;
            bookingManager.TryCreateNewBooking(engine, bookingInputData, out reservationInstance);
        }
    }
```
