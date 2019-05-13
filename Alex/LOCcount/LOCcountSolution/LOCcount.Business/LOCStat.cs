using System;
namespace LOCcount.Business
{
    public class LOCStat
    {
        public string Filename { get; set; } = string.Empty;
        public int AnzahlZeilen { get; set; } = 0;
        public int AnzahlCodezeilen { get; set; } = 0;
    }
}
