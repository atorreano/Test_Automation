namespace Test_Automation.Mappings
{
    class TorreanoMapping
    {
        private static TorreanoMapping instance;

        private TorreanoMapping()
        {

        }

        public static TorreanoMapping GetInstance()
        {
            if (instance == null)
            {
                instance = new TorreanoMapping();
            }
            return instance;
        }

        public string FamilyLink() { return "/html/body/table[3]/tbody/tr[2]/td/div[1]/a[2]";  }
        public string FynnLink() { return "/html/body/table[3]/tbody/tr[2]/td/div[1]/a[4]"; }
        public string DownloadLink() { return "/html/body/table[3]/tbody/tr[2]/td/div[1]/a[7]"; }
        public string DownloadTitle() { return "/html/body/h1"; }

        public string AdamImage() { return "//*[@id='thumb2']/table/tbody/tr/td[3]/img"; }
        public string FynnImage() { return "/html/body/table[2]/tbody/tr[12]/td[2]"; }
        public string RecentNews() { return "/html/body/table[3]/tbody/tr[1]/td[2]/p[2]/table/tbody/tr[1]/td[2]/b"; }
    }
}
