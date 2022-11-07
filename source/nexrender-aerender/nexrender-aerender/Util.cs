using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexrender_tutorial
{
    public static class Util
    {
        private static string dir = Directory.GetCurrentDirectory();
        private static string root = Directory.GetDirectoryRoot(dir) + "/nexrender-simple-usage/";

        public static List<string> _headlines = new List<string>
        {
            "1,5 Kilometer groß – und „für die Erde potenziell gefährlich“",
            "FDP macht Grünen in AKW-Frage schwere Vorwürfe",
            "Russischer Geheimdienstmann behauptet: Putin hat Krebs und Parkinson",
            "Musk will Twitter-Nutzer für Verifizierung ihrer Konten acht Dollar zahlen lassen",
            "Haaland zeigt sich mit neuer Frise",
            "Flaschen-Frust bei Coca-Cola-Fans",
            "Galeria Karstadt Kaufhof: ver.di will um Arbeitsplätze kämpfen"
        };

        public static List<string> _sublines = new List<string>
        {
            "Die Traumfabrik Hollywood hat es in Blockbustern wie Armageddon vorgemacht, ...",
            "Erst vor zwei Wochen spricht Kanzler Scholz im Streit um die deutschen Atomkraftwerke ein Machtwort. Doch jetzt gibt es neuen Ärger in der ...",
            "Ein Kreml-Insider behauptet, Russlands Präsident Wladimir Putin leide an Krebs und Parkinson. Putin werde „mit Steroiden vollgepumpt“, ...",
            "Blaue Häkchen Musk will Twitter-Nutzer für Verifizierung ihrer Konten acht Dollar zahlen lassen ... Erst feilschte er mit Horror-Autor Stephen ...",
            "Die Fans kannten Superstürmer Erling Haaland (22) bisher mit seiner blonden Mähne zum Pferdeschwanz gebunden.",
            "Wer im Supermarkt zur Coca-Cola greift, wird spätestens zu Hause eine Änderung bemerken. ... Flaschen-Frust bei Coca-Cola-Fans ...",
            "Nach der Ankündigung zahlreicher Filialschließungen bei Galeria Karstadt Kaufhof will die Gewerkschaft ver.di um die ..."
        };

        public static List<string> _days = new List<string>
        {
            "file:///" + root + "AE template/_img/input_img_0.jpg",
            "file:///" + root + "AE template/_img/input_img_1.jpg",
            "file:///" + root + "AE template/_img/input_img_2.jpg",
            "file:///" + root + "AE template/_img/input_img_3.jpg",
            "file:///" + root + "AE template/_img/input_img_4.jpg",
            "file:///" + root + "AE template/_img/input_img_5.jpg",
            "file:///" + root + "AE template/_img/input_img_6.jpg"
        };

    }
}
