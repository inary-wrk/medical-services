namespace businesslogic.abstraction.Contracts
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source)
            where TSource : notnull
            where TDestination : notnull;
    }
}
