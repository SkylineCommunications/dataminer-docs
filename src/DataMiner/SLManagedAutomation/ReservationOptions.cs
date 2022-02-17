using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Automation
{
	public class ReservationOptions
	{
		public static string Guid
		{
			get
			{
				return "GUID";
			}
		}

		public static string StartTime
		{
			get
			{
				return "Start time";
			}
		}

		public static string EndTime
		{
			get
			{
				return "End time";
			}
		}

		public static string Name
		{
			get
			{
				return nameof(Name);
			}
		}

		public static string Description
		{
			get
			{
				return nameof(Description);
			}
		}

		public static string CreatedAt
		{
			get
			{
				return "Created at";
			}
		}

		public static string CreatedBy
		{
			get
			{
				return "Created by";
			}
		}

		public static string LastModifiedAt
		{
			get
			{
				return "Last modified at";
			}
		}

		public static string LastModifiedBy
		{
			get
			{
				return "Last modified by";
			}
		}

		public static string HostingAgentId
		{
			get
			{
				return "Hosting agent ID";
			}
		}

		public static string ServiceDefinitionId
		{
			get
			{
				return "Service definition ID";
			}
		}

		public static string ServiceDefinition
		{
			get
			{
				return "Service definition";
			}
		}

		public static string ServiceId
		{
			get
			{
				return "Service ID";
			}
		}
	}
}