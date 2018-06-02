namespace RCS.BLL.Mapper
{
    public class AutoMapperConfig
    {
        public static void Init()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<UserAutoMapperProfile>();
                cfg.AddProfile<FacilityAutoMapperProfile>();
                cfg.AddProfile<ResidentAutoMapperProfile>();
            });

            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}
