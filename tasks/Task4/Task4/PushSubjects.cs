using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Task4
{
    class PushSubjects
    {
        public static void Run(IKonto[] genBestand)
        {
            int a = 0;
            uint j = 10000000;
            var producer = new Subject<Girokonto>();

            producer
                .Sample(TimeSpan.FromSeconds(1.0))
                .Subscribe(x => genBestand[a++] = x);

            var t = new Thread(() =>
            {
                
                while (a < 10)
                {
                    var genKonto = new Girokonto(++j);
                    Thread.Sleep(50);
                    producer.OnNext(genKonto);
                    //Console.WriteLine("Gesendet: {0}", j);
                }
            });
            t.Start();
        }
    }
}
