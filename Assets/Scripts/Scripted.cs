
using UnityEngine;

public class Scripted : MonoBehaviour
{

    private void KrewDiabla()
    {
        bool disarmed = true;
        bool wantToJoin = true;
        bool calestsisTrusts = true;

        //Klasztor
        //Czy dru¿yna sk³ada broñ?
        if (disarmed)
        {
            //Rozmowa z calesistem, czy gracze chca wstapiæ do klasztoru?
            if (wantToJoin)
            {
                //Caelestis pozwala im nocowac w klasztorze, korzystaæ z us³ug
                if (calestsisTrusts) ; //Nie s¹ pilnowani
                else if (!calestsisTrusts) ; //Faustus jest przydzielony im jako "przewodnik"                
            }
            else if (!wantToJoin && calestsisTrusts)
            {               
                //Calestis pozwala im zostaæ na noc w klasztorze, a potem maj¹ siê wynieœæ. Mog¹ jeszcze zmieniæ zdanie.
            }
            else if (!wantToJoin && !calestsisTrusts)
            {
                //Dru¿yna zostaje wyrzucona z klasztoru, jedynym sposobem na powrót jest wykonanie zadania z plag¹
            }
        }
        else if (!disarmed)
        {
            //Dru¿yna pozostaje na zewn¹trz klasztoru dopóki nie zmieni zdania
        }
    }

    private void PlagaGrzechu() //Quest
    {
        bool talkToPorphyrius = true;

        if (talkToPorphyrius)
        {
            //Porphyrius daruje im eliksir, który ma chroniæ im przed plag¹ przez 24 godziny po spo¿yciu (po 1 sztuce)
            //Mówi im o laboratorium poœrodku krwawego stawu z którego pewnie wziê³a siê plaga
        }

        //Dru¿yna podró¿uje do krwawego stawu, tego jednak nie da siê przejœæ
        //
    }

    private void Walka()
    {
        bool caelestisAlive = true;
        bool captured = true;

        //Druzyna musi walczyæ ze wszystkimi Pokutnikami
        if (captured)
        {
            //Druzyna jest wzieta w niewole, a póŸniej zostaje im powiedziane, ¿e bêd¹ z³o¿eni w ofierze
            Konfrontajca(captured, caelestisAlive);
        }
        else
        {
            //Pokutnicy zostaja pokonani, a wsciekly ryk diab³a rozbrzmiewa w powietrzu
            //Demon oczekuje ich, drzwi w tunelu otwieraj¹ siê
            Konfrontajca(captured, caelestisAlive);
        }
    }

    private void Konfrontajca(bool wereCaptured, bool caelestisAlive)
    {
        //Konfrontacja odbywa siê na o³tarzu na Kruczej Grani

        if (wereCaptured)
        {
            //Dru¿yna musi walczyæ bez broni, to bardzo trudna walka
        }
        else
        {
            //Dru¿yna mo¿e wzi¹æ ze sob¹ ca³y swój ekwipunek aby "czempioni zaprezentowali siê w pe³nej chwale"
        }

        if (caelestisAlive == false)
        {
            //Jeœli Caelestis zgin¹³, to pokutnicy rozpraszaj¹ siê, a diabe³ w walce przywo³uje grupê cieni którzy walcz¹ zamiast nich
        }

        //Walka koñczy siê pokonaniem Ragnaroka, z którego cia³a mo¿na zebraæ flakon czarnej krwi diab³a
    }
}
