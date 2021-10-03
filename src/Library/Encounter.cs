namespace Program
{
    public class Encounter
    //lo trabajo como singleton, ya que solo va a haber un encuentro a la vez, y permitiría a futuro
    //darle atributos y modificadores especiales a los escenarios a futuro.
    {
        private Encounter instance{get; set;}

        public Encounter Instance
        {
            get
            {
                if (this.instance==null)
                {
                    this.instance = new Encounter();
                    return this.instance;
                }
                return this.instance;
            }
        }
        private Encounter(){}
    }
}