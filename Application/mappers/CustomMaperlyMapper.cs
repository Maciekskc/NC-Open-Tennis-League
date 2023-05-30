using Riok.Mapperly.Abstractions;

namespace Application.Mappers
{
    /// <summary>
    /// Base definition for mapperly mapper
    /// </summary>
    [Mapper(UseDeepCloning = true)]
    public partial class CustomMaperlyMapper
    {
        /* Store selected mapper method in separate files organized by main model name */
    }
}
