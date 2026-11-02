namespace SzenzorApp
{
    public class Szenzor
    {
        public string Azonosito { get; set; }

        protected int fogyasztasmW;
        public int FogyasztasmW
        {
            get { return fogyasztasmW; }
            set
            {
                fogyasztasmW = value > 0 ? value : 50;
            }
        }

        private static int osszesSzenzorSzama;
        public static int OsszesSzenzorSzama
        {
            get { return osszesSzenzorSzama; }
        }

        public Szenzor(string _azonosito, int _fogyasztasmW)
        {
            Azonosito = _azonosito;
            FogyasztasmW = _fogyasztasmW;

            osszesSzenzorSzama++;
        }

        public virtual int NapiEnergiaIgeny(int orakSzama)
        {
            return FogyasztasmW * orakSzama;
        }

        public override string ToString()
        {
            return $"Szenzor {Azonosito} | Fogyasztás: {FogyasztasmW} mW";
        }
    }
}
