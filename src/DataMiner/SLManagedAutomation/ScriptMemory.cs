using Skyline.DataMiner.Net.Exceptions;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents a script memory.
	/// </summary>
	/// <remarks>For more information about memory files in Automation, refer to <see href="xref:Script_variables#creating-a-memory-file">Creating a memory file</see>.</remarks>
	public class ScriptMemory
	{
		/// <summary>
		/// Gets the ID of this script memory.
		/// </summary>
		/// <value>The ID of this script memory.</value>
		public int Id { get; }

		/// <summary>
		/// Gets a value indicating whether the memory file only exists during script execution.
		/// </summary>
		/// <value><c>true</c> if the memory only exists during script execution; otherwise, <c>false</c>.</value>
		public bool IsVolatile { get; }

		/// <summary>
		/// Gets the name of the persistent script memory.
		/// </summary>
		/// <value>The name of the persistent script memory.</value>
		/// <remarks>
		/// <note type="note">
		/// This is only applicable for persistent script memory files. For a volatile script memory, this property returns an empty string ("").
		/// </note>
		/// </remarks>
		public string LinkedFile { get; }

		/// <summary>
		/// Gets the name of this script memory.
		/// </summary>
		/// <value>The name of this script memory.</value>
		public string Name { get; }

		/// <summary>
		/// Clears the script memory.
		/// </summary>
		/// <example>
		/// <code>
		/// ScriptMemory memory = engine.GetMemory("memory");
		/// if(memory != null)
		/// {
		/// 	memory.Clear();
		/// }
		/// </code>
		/// </example>
		public void Clear() { }

		/// <summary>
		/// Gets the value from the script memory entry with the specified description.
		/// </summary>
		/// <param name="positionDesc">The description of the script memory entry.</param>
		/// <returns>The value of the script memory entry with the specified description.</returns>
		/// <exception cref="DataMinerException">There is no script memory entry with the specified description.</exception>
		/// <example>
		/// <code>
		/// ScriptMemory memory = engine.GetMemory("myMemory");
		/// object myValue = memory.Get("myEntryDescription");
		/// </code>
		/// </example>
		public object Get(string positionDesc) { return null; }

		/// <summary>
		///  Gets the specified value from the memory file.
		/// </summary>
		/// <param name="position">The position of the memory file entry.</param>
		/// <returns>The value of the specified memory position.</returns>
		/// <exception cref="DataMinerException">There is no script memory entry with the specified position.</exception>
		/// <example>
		/// <code>
		/// ScriptMemory memory = engine.GetMemory("myMemory");
		/// object myValue = memory.Get(1);
		/// </code>
		/// </example>
		public object Get(int position) { return null; }

		/// <summary>
		/// Sets the script memory entry with the specified description to the specified value.
		/// </summary>
		/// <param name="positionDesc">The description of the script memory entry.</param>
		/// <param name="val">The value to set.</param>
		/// <example>
		/// <code>
		/// ScriptMemory memory = engine.GetMemory("myMemory");
		/// object myValue = memory.Set("myEntryDescription", "myValue");
		/// </code>
		/// </example>
		public void Set(string positionDesc, object val) { }

		/// <summary>
		/// Sets the script memory entry with the specified position to the specified value.
		/// </summary>
		/// <param name="position">The position of the script memory entry.</param>
		/// <param name="val">The value to set.</param>
		/// <example>
		/// <code>
		/// ScriptMemory memory = engine.GetMemory("myMemory");
		/// object myValue = memory.Set(10, "myValue");
		/// </code>
		/// </example>
		public void Set(int position, object val) { }
	}
}