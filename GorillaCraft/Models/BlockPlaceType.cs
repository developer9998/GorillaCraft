namespace GorillaCraft.Models
{
    /// <summary>
    /// BlockPlaceTypes is a enum which describes the type of placement made by a block.
    /// </summary>
    public enum BlockPlaceType
    {
        /// <summary>
        /// The block was placed by our local player.
        /// </summary>
        Local,
        /// <summary>
        /// The block was placed by a player in the current room.
        /// </summary>
        Server,
        /// <summary>
        /// The block was placed through a request made to gather the block data of a player in the current room on joining.
        /// </summary>
        Recovery
    }
}
