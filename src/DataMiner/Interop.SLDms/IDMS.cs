using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Interop.SLDms
{
	/// <summary>
	/// IDMS interface.
	/// </summary>
	public interface IDMS
	{
		/// <summary>
		/// Performs a notify.
		/// </summary>
		/// <param name="iType">The type of message that will be sent.</param>
		/// <param name="iSubType">The message subtype. This value is always set to 0.</param>
		/// <param name="varValue">Input data, depends on the message type.</param>
		/// <param name="varValue2">Input data, depends on the message type.</param>
		/// <param name="pvarValue">The result.</param>
		/// <remarks>Refer to [SLDms Notify Types](xref:SLDmsNotifyTypes) for an overview of the available messages.</remarks>
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Notify([In] int iType, [In] int iSubType, [MarshalAs(UnmanagedType.Struct), In] object varValue, [MarshalAs(UnmanagedType.Struct), In] object varValue2, [MarshalAs(UnmanagedType.Struct)] out object pvarValue);

		/// <summary>
		/// Requests info.
		/// </summary>
		/// <param name="iWhat">The type of message that will be sent.</param>
		/// <param name="iSubType">The message subtype. This value is always set to 0.</param>
		/// <param name="pvarValue">Object reference used to send and receive the data.</param>
		/// <remarks>Refer to [SLDms Notify Types](xref:SLDmsNotifyTypes) for an overview of the available messages.</remarks>
		[DispId(3)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetInfo([In] int iWhat, [In] int iSubType, [MarshalAs(UnmanagedType.Struct), In, Out] ref object pvarValue);
	}
}
