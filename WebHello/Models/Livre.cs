using System; 


namespace WebHello
{ 
    public class Livre
    {
        
        public int ID { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public Livre()
        {

        }
        public Livre(string Title, string ISBN)
        {
            this.ISBN = ISBN;
            this.Title = Title;
        }
    }
}