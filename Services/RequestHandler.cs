using Ada_PreInterview.Models;
using System.Collections.Generic;
namespace Ada_PreInterview.Services{

    public class RequestHandler{
        public Answer ProcessInput(Input input){
            //Döndürülecek veriler.
            Answer answer = new Answer();
            List<Details> details = new List<Details>();
            
            //Farklı vagonlara yerleştirilemez ise...
            if(!input.KisilerFarkliVagonlaraYerlestirilebilir)
            {
                for(int i=0;i<input.Tren.Vagonlar.Count;i++){
                    if(input.Tren.Vagonlar[i].DoluKoltukAdet+input.RezervasyonYapilacakKisiSayisi>(input.Tren.Vagonlar[i].Kapasite*0.7)){
                        continue;
                    }
                    else{
                        Details detail = new Details();
                        detail.VagonAdi = input.Tren.Vagonlar[i].Ad;
                        detail.KisiSayisi = input.RezervasyonYapilacakKisiSayisi;
                        details.Add(detail);
                        break;
                    }
                }
                answer.RezervasyonYapilabilir = true; 
                answer.YerlesimAyrinti = details;
            }

            //Farklı vagonlara yerleştirilebilir ise...
            if(input.KisilerFarkliVagonlaraYerlestirilebilir){
                int kisiSayisi=input.RezervasyonYapilacakKisiSayisi;
                for(int i=0;i<input.Tren.Vagonlar.Count;i++){
                    int yerlestirilebilirKisi = (int)(input.Tren.Vagonlar[i].Kapasite*0.7) - (input.Tren.Vagonlar[i].DoluKoltukAdet);
                    if(yerlestirilebilirKisi<0){continue;}
                    else{
                        Details detail = new Details();
                        if(yerlestirilebilirKisi<kisiSayisi){detail.KisiSayisi = yerlestirilebilirKisi;}
                        else{detail.KisiSayisi = kisiSayisi;}    
                        detail.VagonAdi = input.Tren.Vagonlar[i].Ad;
                        details.Add(detail);

                        kisiSayisi -=yerlestirilebilirKisi;
                    }
                    if(kisiSayisi<0){break;}
                }
                answer.RezervasyonYapilabilir = true;
                answer.YerlesimAyrinti = details;
            }
            return answer;
        }
    }
}