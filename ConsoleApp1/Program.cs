namespace ConsoleApp1
{
    internal class Program
    {
        #region
        static int callCount = 0; // global değişken tanımlama yöntemi
        static void Main(string[] args)
        {
            // parametresiz method
            Parametresiz();
            int[] sayilar = { 1, 2, 3, 4, 5 };
            Console.WriteLine($"Ortalama : {DiziOrtalamasi(sayilar)}");
            var enBuyukKucuk = EnBuyukVeEnKucuk(sayilar);
            Console.WriteLine($"En Küçük : {enBuyukKucuk.Item1}, En Büyük : {enBuyukKucuk.Item2}");
            int a = 5;
            int b = 10;
            RefOutMethod(ref a, ref b, out int toplam, out int carpim);
            Console.WriteLine($"Yer Değişim Sonrası A : {a}, Yer Değişim Sonrası B : {b}, Toplam : {toplam}, Çarpım : {carpim}");
            Console.WriteLine($"üS Hesaplama : {UsHesapla(3)}");
            Console.WriteLine($"Dört İşlem Sonucu : {DortIslem(sayi1:10,sayi2:2,operatoru:'+')}");
            Console.WriteLine($"Fibonacci(5) : {Fibonacci(5)}");
            ZincirlemeMethod(5);
        }
        static void Parametresiz()
        {
            callCount++;
            Console.WriteLine($"Parametresiz Method Çalıştı.{callCount}");
        }
        static double DiziOrtalamasi(int[] sayilar)
        {
            int topla = 0;
            foreach (int sayi in sayilar)
            {
                topla += sayi;
            }
            return (double)topla / sayilar.Length;
        }
        static Tuple<int, int> EnBuyukVeEnKucuk(int[] sayilar)
        {
            int enBuyuk = int.MinValue, enKucuk = int.MaxValue;
            foreach (int sayi in sayilar)
            {
                if (sayi > enBuyuk) enBuyuk = sayi;
                if (sayi > enKucuk) enKucuk = sayi;
            }
            return Tuple.Create(enBuyuk, enKucuk);
            #endregion
        }
        static void RefOutMethod(ref int x, ref int y, out int toplam, out int carpim)
        {
            // Sayıları Yer Değiştiriyoruz.
            int temp = x;
            x = y;
            y = temp;
            toplam = x + y;
            carpim = x * y;
        }
        static double UsHesapla(int sayi, int us = 2)
        {
            return Math.Pow(sayi, us);
        }
        static double DortIslem(int sayi1, int sayi2, char operatoru)
        {
            return operatoru switch
            {
                '+' => sayi1 + sayi2,
                '-' => sayi1 - sayi2,
                '*' => sayi1 * sayi2,
                '/' => sayi1 / (double)sayi2,
               _=> throw new ArgumentException("Geçersiz Operator")
            };
        }
        static int Fibonacci(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        static void ZincirlemeMethod(int sayi)
        {
            int kare = (int)UsHesapla(sayi);
            int fiboSonuc = Fibonacci(sayi);
            Console.WriteLine($"Sayının Karesi : {kare}, Fibonacci Değeri : {fiboSonuc}");
        }
    }
}