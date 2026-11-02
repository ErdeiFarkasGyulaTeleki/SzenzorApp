using SzenzorApp;

List<Szenzor> szenzorok = new List<Szenzor>();

int hibasSorokSzama = 0;

try
{
    string[] olvasott = File.ReadAllLines("szenzorok.txt").Skip(1).ToArray();

    foreach (var sor in olvasott)
    {
        if (string.IsNullOrEmpty(sor))
        {
            hibasSorokSzama++;
            continue;
        }

        string[] adatok = sor.Split('|');

        if (adatok.Length != 4)
        {
            hibasSorokSzama++;
            continue;
        }

        string tipus = adatok[0];

        if (!(tipus == "S" || tipus == "K"))
        {
            hibasSorokSzama++;
            continue;
        }

        string azonosito = adatok[1];

        if (string.IsNullOrEmpty(azonosito))
        {
            hibasSorokSzama++;
            continue;
        }

        int fogyasztas = 0;

        if (!int.TryParse(adatok[2], out fogyasztas))
        {
            hibasSorokSzama++;
            continue;
        }

        int felbontas = 0;

        if (!int.TryParse(adatok[3], out felbontas))
        {
            hibasSorokSzama++;
            continue;
        }

        if (tipus == "S")
        {
            Szenzor szenzor = new Szenzor(azonosito, fogyasztas);
            szenzorok.Add(szenzor);
        } 
        else if (tipus == "K")
        {
            KameraSzenzor kameraSzenzor = new KameraSzenzor(azonosito, fogyasztas, felbontas);
            szenzorok.Add(kameraSzenzor);
        }
    }

    Console.WriteLine($"Sikeresen beolvasott szenzorok: {szenzorok.Count} db");
    Console.WriteLine($"Kiszűrt hibás sorok száma: {hibasSorokSzama} db");
    Console.WriteLine($"\nBeolvasott szenzorok listája:");
    szenzorok.ForEach(Console.WriteLine);
    Console.WriteLine($"\nKameraszenzorok külön elemzése:");
    szenzorok.ForEach(s =>
    {
        if (s is KameraSzenzor k)
        {
            Console.WriteLine($"- {k.Azonosito} kamera felbontása: {k.FelbontasMP} MP.");
        }
    });
    Console.WriteLine($"\nÖsszesített napi energiaigény (24 óra): {szenzorok.Sum(s => s.NapiEnergiaIgeny(24))} mWh");
    Console.WriteLine($"Szenzor példányok száma (static): {Szenzor.OsszesSzenzorSzama} db");

} catch (Exception exc)
{
    Console.WriteLine(exc);
}