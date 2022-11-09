
using UnityEngine;

public class Scripted : MonoBehaviour
{

    private void KrewDiabla()
    {
        bool disarmed = true;
        bool wantToJoin = true;
        bool calestsisTrusts = true;

        //Klasztor
        //Czy dru�yna sk�ada bro�?
        if (disarmed)
        {
            //Rozmowa z calesistem, czy gracze chca wstapi� do klasztoru?
            if (wantToJoin)
            {
                //Caelestis pozwala im nocowac w klasztorze, korzysta� z us�ug
                if (calestsisTrusts) ; //Nie s� pilnowani
                else if (!calestsisTrusts) ; //Faustus jest przydzielony im jako "przewodnik"                
            }
            else if (!wantToJoin && calestsisTrusts)
            {               
                //Calestis pozwala im zosta� na noc w klasztorze, a potem maj� si� wynie��. Mog� jeszcze zmieni� zdanie.
            }
            else if (!wantToJoin && !calestsisTrusts)
            {
                //Dru�yna zostaje wyrzucona z klasztoru, jedynym sposobem na powr�t jest wykonanie zadania z plag�
            }
        }
        else if (!disarmed)
        {
            //Dru�yna pozostaje na zewn�trz klasztoru dop�ki nie zmieni zdania
        }
    }

    private void PlagaGrzechu() //Quest
    {
        bool talkToPorphyrius = true;

        if (talkToPorphyrius)
        {
            //Porphyrius daruje im eliksir, kt�ry ma chroni� im przed plag� przez 24 godziny po spo�yciu (po 1 sztuce)
            //M�wi im o laboratorium po�rodku krwawego stawu z kt�rego pewnie wzi�a si� plaga
        }

        //Dru�yna podr�uje do krwawego stawu, tego jednak nie da si� przej��
        //
    }

    private void Walka()
    {
        bool caelestisAlive = true;
        bool captured = true;

        //Druzyna musi walczy� ze wszystkimi Pokutnikami
        if (captured)
        {
            //Druzyna jest wzieta w niewole, a p�niej zostaje im powiedziane, �e b�d� z�o�eni w ofierze
            Konfrontajca(captured, caelestisAlive);
        }
        else
        {
            //Pokutnicy zostaja pokonani, a wsciekly ryk diab�a rozbrzmiewa w powietrzu
            //Demon oczekuje ich, drzwi w tunelu otwieraj� si�
            Konfrontajca(captured, caelestisAlive);
        }
    }

    private void Konfrontajca(bool wereCaptured, bool caelestisAlive)
    {
        //Konfrontacja odbywa si� na o�tarzu na Kruczej Grani

        if (wereCaptured)
        {
            //Dru�yna musi walczy� bez broni, to bardzo trudna walka
        }
        else
        {
            //Dru�yna mo�e wzi�� ze sob� ca�y sw�j ekwipunek aby "czempioni zaprezentowali si� w pe�nej chwale"
        }

        if (caelestisAlive == false)
        {
            //Je�li Caelestis zgin��, to pokutnicy rozpraszaj� si�, a diabe� w walce przywo�uje grup� cieni kt�rzy walcz� zamiast nich
        }

        //Walka ko�czy si� pokonaniem Ragnaroka, z kt�rego cia�a mo�na zebra� flakon czarnej krwi diab�a
    }
}
