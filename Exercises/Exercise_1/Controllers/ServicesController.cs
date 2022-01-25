using Exercise_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercise_1.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            var services = new List<Service>()
            {
                new Service { Title = "IT-Drift", Description = "Vi hjälper er med en helhetslösning av er IT-drift, alternativt kan vi vara ett komplement till er interna IT-avdelning, problemfritt – ni överlåter ansvaret åt oss." },
                new Service { Title = "IT-Hosting/Outsourcing", Description = "Vi sköter företagets IT-drift såsom: Server, klienter, nätverk, användarstöd, mejl, affärssystem, programvaror läggs i vår serverhall som du som kund kan ansluta dig till från hela världen med säker VPN anslutning. Vår serverhall har hög säkerhetsklass hos vår samarbetspartner Ilait. Vi erbjuder även tjänster inom Office 365, Microsoft m.m" },
                new Service { Title = "Backup & Lagring", Description = "Vi erbjuder säkra backuplagringar som är framtidssäkrade." },
                new Service { Title = "Säkerhet", Description = "Vi kan stolt presentera vår backuplösning som räddat flera kunder från ”Cryptolock” viruset och liknande virus! Datasäkerhet som säker lagring på server/arbetsstationer tas allt som oftast inte på allvar, men vi har en enkel och kostnadseffektiv backuplösning. Glöm otillförlitliga media som band, CD/DVD och USB-minnen. Automatisk säkerhetskopiering via Internet, data krypteras, inga krånglande bandstationer, inga bandbyten att komma ihåg, inga problem med oläsbar media." },
                new Service { Title = "Nätverksinstallationer", Description = "Vi hjälper er med projektering och installationer av datorer och nätverk. Det kan vara allt ifrån inköp av nya servrar, arbetsstationer, skrivare och andra tillbehör som vi anpassar till befintliga eller nya nätverk genom snabba och korrekt utförda installationer för att förbättra och förenkla er vardag inom företaget." }
            };

            return View(services);
        }
    }
}
