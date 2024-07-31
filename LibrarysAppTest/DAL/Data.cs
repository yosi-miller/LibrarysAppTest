namespace LibrarysAppTest.DAL
{
    public class Data
    {
        // משתנה סטטי ששומר מופע יחיד של המחלקה
        static Data? GetData;

        // סטרינג החיבור לדאטה בייס
        string connectionString = "server=YOSEF-MILLER\\SQLEXPRESS; initial catalog=LibrarysApp; user id=sa; password=1234; TrustServerCertificate=Yes";

        // משתנה שיכיל הפניה לשכבת החיבור לדאטה
        public DataLayer Layer { get; set; }

        // קונסטרקטור שיוצר 
        private Data()
        {
            Layer = new DataLayer(connectionString);

        }
        public static DataLayer Get
        {
            get
            {
                if (GetData == null)
                {
                    GetData = new Data();
                }
                return GetData.Layer;
            }
        }
    }
}
