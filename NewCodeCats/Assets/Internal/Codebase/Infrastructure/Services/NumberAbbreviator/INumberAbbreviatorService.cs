namespace Internal.Codebase.Infrastructure.Services.NumberAbbreviator
{
    public interface INumberAbbreviatorService
    {
        public string AbbreviateNumber(double value, bool includeSuffixName = false);
    }
}