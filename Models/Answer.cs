using System.Collections.Generic;

namespace Ada_PreInterview.Models{

    //Return model
    public class Answer{
        public bool RezervasyonYapilabilir {get;set;}
        public List<Details> YerlesimAyrinti {get;set;}
    }

    //Yerlesim ayrıntı sub class
    public class Details{
        public string VagonAdi {get;set;}
        public int KisiSayisi {get;set;}
    }
}