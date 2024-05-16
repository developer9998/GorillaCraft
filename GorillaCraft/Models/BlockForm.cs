namespace GorillaCraft.Models
{
    /// <summary>
    /// BlockForm is an enum which describes the form of a block.
    /// </summary>
    public enum BlockForm
    {
        /// <summary>
        /// The block is solid.
        /// </summary>
        Solid,
        /// <summary>
        /// The block is an "other-dev" spawner.
        /// </summary>
        DevSpawner,
        /// <summary>
        /// The block is a decoration, made out of a singular 2D-sprite on a set of 3D planes.
        /// </summary>
        Decoration,
        /// <summary>
        /// The block is a vertically-angled climbable. 
        /// </summary>
        Ladder
    }
}
