namespace medical_services.api.Mapper
{
    internal interface IMapperCodeGen<TSource, TDestination>
    {
        TDestination Map(TSource source);
    }
}
