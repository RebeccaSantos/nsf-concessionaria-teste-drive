namespace backend.Models.Response
{
    public class erro
    {
        public int Codigo { get; set; }
        public string Msg { get; set; }

        public erro (int cod,string mes){
            this.Msg=mes; 
            this.Codigo=cod;
        }
    }
}