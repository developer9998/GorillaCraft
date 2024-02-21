namespace GorillaCraft.Models
{
    public enum BlockPlaceType
    {
        /// <summary>
        /// The block was placed by the local player
        /// </summary>
        Local,
        /// <summary>
        /// The block was placed by another player
        /// </summary>
        Server,
        /// <summary>
        /// The block was placed in response to what another player had already built
        /// </summary>
        Recovery
    }
}
