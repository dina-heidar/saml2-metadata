namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TIn">The type of the in.</typeparam>
    /// <typeparam name="TOut">The type of the out.</typeparam>
    public interface IMetadataMapper<in TIn, out TOut>
       where TIn : class
       where TOut : class
    {
        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        TOut MapEntity(TIn input);
    }
}
