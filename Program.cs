using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Assegnazione
                - Costruire una lista (li) di 1000 numeri casuali compresi tra 0 e 999 incluso
                - Costruire un SortedSet (ssi) contenente i numeri già presenti in lista
                - Costruire un vettore di booleani (vb), lungo 1000, che per ogni intero n presente in lista
                    vale vb[n]=true

                - calcolare quanto tempo impiegate per eseguire il seguente codice
                    - per 10000 volte
                        - genera n, numero casuale tra 0 e 999
                        - verifica se n è presente nel vettore vb (quindi if vb[n] == true). Non dovete stampare nulla

                - calcolare quanto tempo impiegate per eseguire il seguente codice
                    - per 10000 volte
                        - genera n, numero casuale tra 0 e 999
                        - verifica se n è presente nella lista li (quindi li.find...). Non dovete stampare nulla

                - calcolare quanto tempo impiegate per eseguire il seguente codice
                    - per 10000 volte
                        - genera n, numero casuale tra 0 e 999
                        - verifica se n è presente nell'insieme ordinato ssi (quindi ssi.find...). Non dovete stampare nulla

                Infine, stampare i tre tempi in secondi

                Opzionale: stampare il numero di ricerche/secondo.

               */

            //Costruisco una lista di 1000 numeri
            List<int> Numbers = new List<int>();

            while (Numbers.Count < 1000)
            {
                var rand = new Random();
                Numbers.Add(rand.Next(0, 999));
            }
            //Costruisco una SortedSet passando la lista di numeri interi
            SortedSet<int> sortNumbers = new SortedSet<int>(Numbers);

            // Costruisco un vettore di booleani che per ogni intero n di Numbers mi restituisca true  vale vb[n] = true
            // Metto tutti gli elementi false
            bool[] vb = new bool[1000];
            for (int i = 0; i < 1000; i++)
                vb[i] = false;
            
            //Controllo se è presente nella lista Numbers
            for (int j = 0; j < 10000; j++)
            { 
                foreach(int n in Numbers) 
                    vb[n] = true;
            }
            //Genero un numero casuale
            var r = new Random();
            int numSearched = r.Next(0, 999);
            //Inserire il vettore in cui sìintende effettuare la ricerca
            int Founded = 0;
            int notFounded = 0;
            double start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            for (int i = 0; i<10000; i++)
            {
                foreach (int n in Numbers)
                {
                    if (Numbers.Contains(n))
                        Founded++;
                    else
                        notFounded++;
                }

            };
            double end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            double total = end - start;
            Console.WriteLine("ms per cercare un numero in una lista:\t{0}", total);


            Founded = 0;
            notFounded = 0;
            start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            for (int i = 0; i < 10000; ++i)
            {
                foreach (int n in Numbers)
                {
                    //n è presente nella lista li?
                    if (sortNumbers.Contains(n))
                        Founded++;
                    else
                        notFounded++;
                }
            }
            end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            total = end - start;
            Console.WriteLine("ms per cercare un numero nel SortedSet:\t{0}", total);

            Founded = 0;
            notFounded = 0;
            start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            for (int i = 0; i < 10000; ++i)
            {
                foreach (int n in Numbers)
                {
                    if (vb[n])
                        Founded++;
                    else
                        notFounded++;
                }
            }
            end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            total = end - start;
            Console.WriteLine("ms per cercare un numero in un vettore di booleani:\t{0}", total);


            /*La ricerca in un insieme ordinato è logaritmica, se l'insieme contiene n el, il tempo di ricerca oppure il numero di 
            operazioni eseguite per la ricerca è pari a O(log(N));*/

            /*La ricerca in un insieme sequenziale (non ordinato) è lineare, se l'insieme contiene N elementi, il tempo di ricerca
            oppure il numero di operazioni eseguite per la ricerca è pari a O(N);*/




        }
    }
}
