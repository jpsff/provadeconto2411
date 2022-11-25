using System;

namespace API_Copa.Models
{
    public class Jogo
    {
        public Jogo()
        {
            PlacarA = 0;
            PlacarB = 0;
            CriadoEm = DateTime.Now;
        }
        public int Id { get; set; }
        public Selecao SelecaoA { get; set; }
        public Selecao SelecaoB { get; set; }
        public int PlacarA { get; set; }
        public int PlacarB { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
