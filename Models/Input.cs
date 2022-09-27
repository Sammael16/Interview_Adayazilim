using System.Collections.Generic;

namespace Ada_PreInterview.Models{


//Base class to get as input from post request.
public class Input{
    public Train Tren{get;set;}
    public int RezervasyonYapilacakKisiSayisi{get;set;}
    public bool KisilerFarkliVagonlaraYerlestirilebilir{get;set;}
}

//Train model.
public class Train{
    public string Ad{get;set;}
    public List<Vagon> Vagonlar{get;set;}
}

//Vagon sub model.
public class Vagon{
    public string Ad{get;set;}
    public int Kapasite{get;set;}
    public int DoluKoltukAdet{get;set;}
}


}