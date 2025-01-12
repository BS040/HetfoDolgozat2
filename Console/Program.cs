using ClassLibrary.Data;
using ClassLibrary.Models;

Adatbazis db = new Adatbazis();

if (!db.Huzas.Any())
{
    string[] sorok = File.ReadAllLines(@"D:\Programozas\Beadandó_202501\Asztali\VikingLottoSzamok.csv");

	foreach (var sor in sorok)
	{
		Huzas huzas = new Huzas();
		Boolean oks = true;
		try {
			huzas = new Huzas(sor);
		}
		catch {
			Console.WriteLine("Hibás sor: "+ sor);
			oks = false;
		}
		if (oks) { 
			db.Huzas.Add(huzas);
		}

	}

	db.SaveChanges();

	foreach (var item in db.Huzas)
	{
		Console.WriteLine(item);
	}
}