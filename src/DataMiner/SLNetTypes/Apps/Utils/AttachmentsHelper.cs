using System;
using System.Collections.Generic;
using Skyline.DataMiner.Net.Exceptions;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net.Apps.Utils
{
	/// <summary>
	/// Helper class for ticket attachments.
	/// </summary>
	/// <remarks>
	/// <para>Available from DataMiner 10.0.8 (RN 25612) onwards.</para>
	/// <list type="bullet">
	/// <item><description>The maximum size of ticket attachments is determined by the Documents.MaxSize setting, located in the MaintenanceSettings.xml file. Default: 20 MB. Trying to upload a larger file will result in a DataMinerException.</description></item>
	/// <item><description>Manipulating ticket attachments requires the same user permissions as normal ticket management operations: read permission to view and download attachments and edit permission to add and delete attachments.</description></item>
	/// <item><description>If a ticket is deleted, all its attachments are physically deleted from the disk. They will not be recoverable.</description></item>
	/// <item><description>All ticket attachments are synchronized throughout the DataMiner System. To include them in a backup, select the All documents located on this DMA backup option.</description></item>
	/// <item><description>The Documents API can also be used to manage ticket attachments. Instead of using the above-mentioned methods, you can also use AddDocumentMessage, DeleteDocumentMessage, GetBinaryFileMessage and GetDocumentMessage. If you do so, specify the directory as "TICKET_ATTACHMENTS\{DataminerID}_{TicketId}" and make sure the property ID of type DMAObjectRef contains the ticket ID.</description></item>
	/// </list>
	/// </remarks>
	public class AttachmentsHelper
    {

		public AttachmentsHelper(string destinationPath, string destinationFolderName, Func<DMSMessage[], DMSMessage[]> messageHandler, string moduleId)
            //: this(destinationPath, destinationFolderName, messageHandler)
        {
        }

        /// <summary>
        /// Adds a new attachment to the <see cref="IDMAObjectRef"/>.
        /// </summary>
        /// <param name="objectRef">The ID of the object to add the attachment to.</param>
        /// <param name="fileName">The name of the attachment.</param>
        /// <param name="fileBytes">The contents of the attachment.</param>
        /// <exception cref="ArgumentNullException"><paramref name="fileBytes"/>, <paramref name="fileName"/>, or <paramref name="objectRef"/> is <see langword="null"/>.</exception>
        /// <exception cref="DataMinerException">
        /// <para>
        /// The <see cref="Exception.InnerException"/> will be an <see cref="ArgumentException"/> if the <paramref name="objectRef"></paramref> does not refer to an existing object.
        /// </para>
        /// <para>
        /// The <see cref="Exception.InnerException"/> will be <see langword="null"/> if something went wrong during communication with the server.
        /// </para>
        /// </exception>
        /// <exception cref="DataMinerCOMException">The provided fileName contains a relative path (e.g. '../file.txt').
        /// </exception>
        /// <exception cref="DataMinerSecurityException">
        /// The user does not have edit permissions for this object.
        /// </exception>
        public void Add(IDMAObjectRef objectRef, string fileName, byte[] fileBytes)
        {
        }

        /// <summary>
        /// Returns the names of the files attached to the <see cref="IDMAObjectRef"/> with ID <paramref name="objectRef"/>.
        /// </summary>
        /// <param name="objectRef">The ID of the <see cref="DMAObjectRef"/> to get the attachment names for.</param>
        /// <exception cref="ArgumentNullException">If <see cref="IDMAObjectRef"/> is <see langword="null"/>.</exception>
        /// <exception cref="DataMinerException">
        /// <para>
        /// <see cref="Exception.InnerException"/> will be an <see cref="ArgumentException"/> if the DMAObjectRef could not be found.
        /// </para>
        /// </exception>
        /// <exception cref="DataMinerSecurityException">If the user does not have read permissions for this.</exception>
        /// <returns>
        /// The names of the attachments. An empty list if the <paramref name="objectRef"/> does not have attachments.
        /// </returns>
        public List<string> GetFileNames(IDMAObjectRef objectRef)
        {
            return null;
        }

		/// <summary>
		/// Deletes the attachment with name <paramref name="attachmentName"/> from the object with ID <paramref name="objectRef"/>.
		/// </summary>
		/// <exception cref="ArgumentNullException"><paramref name="objectRef"/> or <paramref name="attachmentName"/> is <see langword="null"/>.</exception>
		/// <exception cref="DataMinerException">
		/// <para>
		/// <see cref="Exception.InnerException"/> will be an <see cref="ArgumentException"/> if the object could not be found.
		/// </para>
		/// </exception>
		/// <exception cref="DataMinerSecurityException">If the user does not have edit permissions on the object</exception>
		/// <param name="objectRef">The ID of the <see cref="DMAObjectRef"/> to delete an attachment from.</param>
		/// <param name="attachmentName">The name of the attachment to delete.</param>
		/// <remarks>
		/// <para>
		/// This method does not throw an exception if an attachment with the given name could not be found for the object.
		/// </para>
		/// </remarks>
		public void Delete(IDMAObjectRef objectRef, string attachmentName)
        {
        }

        /// <summary>
        /// Get the contents of the attachment with name <paramref name="attachmentName"/> for object with id <paramref name="objectRef"/>.
        /// </summary>
        /// <param name="objectRef">The id of the object to find the attachment for.</param>
        /// <param name="attachmentName">The name of the attachment to find.</param>
        /// <returns>The contents of the attachment</returns>
        /// <exception cref="ArgumentNullException">If a passed argument is null</exception>
        /// <exception cref="DataMinerCOMException">If the attachment could not be found</exception>
        /// <exception cref="DataMinerException">
        /// <para>
        /// The inner exception will be an <see cref="ArgumentException"/> if the object could not be found
        /// </para>
        /// </exception>
        /// <exception cref="DataMinerSecurityException">If the user does not have read permissions on the object</exception>
        public byte[] Get(IDMAObjectRef objectRef, string attachmentName)
        {
			return null;
        }
    }
}
