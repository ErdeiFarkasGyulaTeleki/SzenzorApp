namespace SzenzorApp
{
    public class KameraSzenzor : Szenzor
    {
        public int FelbontasMP { get; set; }

        public KameraSzenzor(string _azonosito, int _fogyasztasmW, int _felbontasMP) : base(_azonosito, _fogyasztasmW)
        {
            FelbontasMP = _felbontasMP;
        }

        public override int NapiEnergiaIgeny(int orakSzama)
        {
            return base.NapiEnergiaIgeny(orakSzama) + FelbontasMP * 10 * orakSzama;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Felbontás: {FelbontasMP} MP";
        }
    }
}
