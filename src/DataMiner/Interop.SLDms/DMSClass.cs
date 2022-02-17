using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Interop.SLDms
{
	/// <summary>
	/// Implementation of the <see cref="IDMS"/> interface.
	/// </summary>
	public class DMSClass : IDMS, DMS
	{
		//[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		//public extern DMSClass();

		/// <summary>
		/// Performs a notification to obtain information or perform an action.
		/// </summary>
		/// <param name="iType">The type of message that will be sent.</param>
		/// <param name="iSubType">The message subtype. This value is always set to 0.</param>
		/// <param name="varValue">Input data, depends on the message type.</param>
		/// <param name="varValue2">Input data, depends on the message type.</param>
		/// <param name="pvarValue">The result.</param>
		/// <remarks>Refer to [SLDms Notify Types](xref:SLDmsNotifyTypes) for an overview of the available messages.</remarks>
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void Notify([In] int iType, [In] int iSubType, [MarshalAs(UnmanagedType.Struct), In] object varValue, [MarshalAs(UnmanagedType.Struct), In] object varValue2, [MarshalAs(UnmanagedType.Struct)] out object pvarValue);

		///// <exclude />
		//[DispId(2)]
		//[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		//public virtual extern void Init([MarshalAs(UnmanagedType.Struct), In] object varStream, [MarshalAs(UnmanagedType.Struct), In, Out] ref object pvarInfo);

		/// <summary>
		/// Performs an info request.
		/// </summary>
		/// <param name="iWhat">The type of message that will be sent.</param>
		/// <param name="iSubType">The message subtype. This value is always set to 0.</param>
		/// <param name="pvarValue">Object reference used to send and receive the data.</param>
		/// <remarks>Refer to [SLDms Notify Types](xref:SLDmsNotifyTypes) for an overview of the available messages.</remarks>
		[DispId(3)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void GetInfo([In] int iWhat, [In] int iSubType, [MarshalAs(UnmanagedType.Struct), In, Out] ref object pvarValue);
	}
}